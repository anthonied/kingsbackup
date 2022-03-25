using Liquid.Domain;
using Liquid.Domain.Services;
using Liquid.Repository;
using Pervasive.Data.SqlClient;
using Liquid.Classes;
using System;
using System.Drawing;
using System.Windows.Forms;
using Functions = Liquid.Classes.Functions;
using Liquid.Finder;

namespace Liquid.Controls
{
    public partial class SalesLineForm : UserControl
    {
        public Solsage_Pastel_API.solPastelSDK clsSDK = new Solsage_Pastel_API.solPastelSDK();
        public bool bNextLine;
        public bool bFocusOnNextLine = true;
        public bool bSaved;
        public int iLineIndex;
        public string sPastelLineLink = "";
        public string sParentLinkNum = "";
        public bool bDoCalculation = true;
        private const int WM_KEYDOWN = 0x100;
        private const int WM_SYSKEYDOWN = 0x104;
        private CodeProject.SystemHotkey.SystemHotkey deleteHotKey;
        public bool bAllowDuplicateLines = true;
        public decimal dMaxMultiplierValue = 0;
        public string sLineType = "";
        private string sLineCalcRuleID;
        private string sLineCalcUnit;
        public decimal dNetMassPerUnit = 0;
        public decimal dUnitNetMass = 0;
        public decimal dQtyOnHand = 0;
        public decimal dScaleQty = 0;
        public bool bUseScale = false;
        public decimal dOriginalUnitPrice;
        public string sCategory;
        public bool bInsertInMiddle;
        public int iStructure = 0;
        public bool bEdited;

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            bool bHandled = false;
            if ((msg.Msg == WM_KEYDOWN) || (msg.Msg == WM_SYSKEYDOWN))
            {
                switch (keyData)
                {
                    case Keys.Tab:
                        manageFrontEnd();
                        bHandled = true;
                        break;

                    case Keys.Enter:
                        manageFrontEnd();
                        bHandled = true;
                        break;
                }
            }
            return bHandled; //handled
        }

        public SalesLineForm()
        {
            InitializeComponent();
            Paint += OnHandlePaint;

            deleteHotKey = new CodeProject.SystemHotkey.SystemHotkey();
        }

        public void RemoveLine(object sender, EventArgs e)
        {
            if (txtCode.Text == "") return;
            if (((Documents.SalesOrder) (Parent.Parent.Parent.Parent)).txtNumber.Text.ToUpper() != "*NEW*") return;
            var deletedLine = this;
            ((Documents.SalesOrder)(Parent.Parent.Parent.Parent)).deleteSalesLine(deletedLine, false);
        }

        protected void OnHandlePaint(object sender, PaintEventArgs args)
        {
            var g1 = args.Graphics;
            var pen = new Pen(Color.FromArgb(100, 100, 100), 2);

            g1.DrawLine(pen, 111, 0, 111, 20);
            g1.DrawLine(pen, 361, 0, 361, 20);
            g1.DrawLine(pen, 441, 0, 441, 20);
            g1.DrawLine(pen, 521, 0, 521, 20);
            g1.DrawLine(pen, 601, 0, 601, 20);
            g1.DrawLine(pen, 648, 0, 648, 20);
            g1.DrawLine(pen, 708, 0, 708, 20);
            g1.DrawLine(pen, 773, 0, 773, 20);
            g1.DrawLine(pen, 838, 0, 838, 20);
            g1.DrawLine(pen, 898, 0, 898, 20);
            g1.DrawLine(pen, 978, 0, 978, 20);
            g1.DrawLine(pen, 1068, 0, 1068, 20);
        }

        private void cmdSearchStore_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            using (var frmStore = new Finder.StoreZoom())
            {
                if (frmStore.ShowDialog() == DialogResult.OK)
                {
                    if (frmStore.sResult != "")
                    {
                        txtStore.Text = frmStore.sResult;
                        txtStore.Focus();
                        txtStore.SelectionStart = 0;
                        txtStore.SelectionLength = txtStore.Text.Length;
                    }
                }
            }
            Cursor = Cursors.Default;
        }

        private void cmdCodeSearch_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            using (var frmInventory = new Finder.Inventory())
            {
                if (frmInventory.ShowDialog(txtStore.Text, "", "") == DialogResult.OK)
                {
                    if (frmInventory.sResult != "")
                    {
                        txtCode.Text = frmInventory.sResult.Trim();

                        Populate_Inventory_Fields(true);
                        txtCode.Focus();
                        txtCode.SelectionStart = 0;
                        txtCode.SelectionLength = txtCode.Text.Length;
                        ((Documents.SalesOrder)(Parent.Parent.Parent.Parent)).addTotals();
                    }
                }
            }
            Cursor = Cursors.Default;
        }

        private void Populate_Inventory_Fields(bool bFocusDescription)
        {
            string sInventoryGroup = "";
            bool bExist = false;

            if (txtCode.Text == "'")
            {
                txtMultiplier.ReadOnly = true;
                txtDescription.ReadOnly = false;
                txtDiscount.ReadOnly = true;
                txtExcPrice.ReadOnly = true;
                txtLastInvoiceDate.Text = "";
                txtNet.ReadOnly = true;
                txtQuantity.ReadOnly = true;
                txtQuantity.Text = "0.00";
                txtUnit.ReadOnly = true;
                txtStore.ReadOnly = true;
                txtDescription.Focus();
                bDoCalculation = false;
            }
            else
            {
                txtMultiplier.ReadOnly = false;
                txtDiscount.ReadOnly = false;
                txtExcPrice.ReadOnly = false;
                txtQuantity.ReadOnly = false;

                bDoCalculation = true;
                using (var pastelConnection = new PsqlConnection(Connect.PastelConnectionString))
                {
                    pastelConnection.Open();
                    var sql = "SELECT distinct  Inventory.*, MultiStoreTrn.SellExcl01 from Inventory ";
                    sql += " left join MultiStoreTrn on Inventory.ItemCode = MultiStoreTrn.ItemCode ";
                    sql += " where (MultiStoreTrn.StoreCode = '" + txtStore.Text.Trim() + "')and (Inventory.ItemCode = '" + txtCode.Text.Trim() + "')";

                    var inventoryReader = Connect.getDataCommand(sql, pastelConnection).ExecuteReader();
                    while (inventoryReader.Read())
                    {
                        //check if inventory is available
                        bExist = true;
                        if ((inventoryReader["UserDefText01"].ToString().Trim().ToUpper() == "ORDER" || inventoryReader["UserDefText01"].ToString().Trim().ToUpper() == "RESERVED" || inventoryReader["UserDefText01"].ToString().Trim().ToUpper() == "WORKSHOP") && (inventoryReader["UserDefNum02"].ToString() != "1")) //UserDefNum02 = Allow duplicates
                        {
                            //inventory is not available
                            MessageBox.Show("Inventory is currently not available.\r\n\r\nStatus:			" + inventoryReader["UserDefText01"].ToString().Trim() + "\r\nExpected date back:		" + inventoryReader["UserDefText03"].ToString().Trim() + "\r\nReference number:		" + inventoryReader["UserDefText02"].ToString().Trim(), "Item Not Available", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            clearLine();
                            txtCode.Focus();
                            bNextLine = false;
                        }
                        if (!bNextLine)
                        {
                            bNextLine = true;
                            SalesLineForm slNewline = new SalesLineForm();
                            ((Documents.SalesOrder)(Parent.Parent.Parent.Parent)).AddSalesLine(slNewline);
                        }

                        sInventoryGroup = inventoryReader["UserDefNum01"].ToString(); // 0 = Consumable;   1 = Lease Item;   2 = Returable Consumable

                        txtUnit.Text = inventoryReader["UnitSize"].ToString();
                        if (sInventoryGroup == "1")
                        {
                            lblDeliveryDate.Visible = false;
                            lblReturnDate.Visible = false;
                            dtDelivery.Visible = true;
                            dtReturnDate.Visible = true;
                            dtDelivery.Value = ((Documents.SalesOrder)(Parent.Parent.Parent.Parent)).dtDeliveryDate.Value;
                            dtReturnDate.Value = dtDelivery.Value;

                            //LL 12/02/2010 - Adding rules for Site Fasilities
                            if (Global.bUseCalculationRules)
                            {
                                bool bCalcRuleExists = GetCalculationRule(txtUnit.Text.Trim());

                                if (bCalcRuleExists)
                                {
                                    txtUnitFormula.Visible = true;
                                    txtUnitFormula.Text = txtUnit.Text;
                                    txtLineRuleID.Text = sLineCalcRuleID;
                                    txtUnit.Text = sLineCalcUnit;
                                    cmdFromulaFinder.Visible = true;
                                    txtUnit.Visible = false;
                                }
                            }
                            //LL 12/02/2010 - Adding rules for Site Fasilities end
                        }
                        else
                        {
                            lblDeliveryDate.Visible = true;
                            lblReturnDate.Visible = true;
                            dtDelivery.Visible = false;
                            dtReturnDate.Visible = false;
                            cmdFromulaFinder.Visible = false;
                            txtUnitFormula.Visible = false;
                            txtUnit.Visible = true;
                        }
                        //LL Phalaborwa Trim()
                        txtDescription.Text = inventoryReader["Description"].ToString().Trim();

                        if (((Documents.SalesOrder)(Parent.Parent.Parent.Parent)).bInvoiceMode)
                        {
                            chkReturn.Checked = true;
                        }

                        try
                        {
                            txtExcPrice.Text = Convert.ToDecimal(inventoryReader["SellExcl01"].ToString()).ToString("N2");
                            dOriginalUnitPrice = Convert.ToDecimal(inventoryReader["SellExcl01"].ToString());
                        }
                        catch
                        {
                            txtExcPrice.Text = "0.00";
                        }

                        txtTaxType.Text = inventoryReader["SalesTaxType"].ToString().Trim();
                        txtDiscountType.Text = inventoryReader["DiscountType"].ToString().Trim();

                        sLineType = Functions.getLineInventoryType(txtCode.Text.Trim());
                        if (txtTaxType.Text == "0" || txtTaxType.Text == "2")
                        {
                            txtNet.BackColor = Color.Yellow;
                        }
                        else
                        {
                            txtNet.BackColor = Color.White;
                        }
                        if (bFocusDescription)
                        {
                            txtDescription.Focus();
                        }

                        if (inventoryReader["DiscountType"].ToString() == "0" || inventoryReader["DiscountType"].ToString() == "1")//AJD 20-08-2009
                        {
                            txtDiscount.ReadOnly = true;
                        }
                    }
                    inventoryReader.Close();
                    pastelConnection.Dispose();
                    if (!bExist)
                    {
                        MessageBox.Show("Code does not exist.", "Inventory Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtDescription.ReadOnly = true;
                    }
                    else
                    {
                        if (sInventoryGroup == "1")
                        {
                            txtQuantity.ReadOnly = false;
                            if (bAllowDuplicateLines && !(txtDescription.Text.StartsWith("*D")) && txtCode.Text != "'")
                            {
                                txtMultiplier.ReadOnly = false;
                            }
                            else
                            {
                                txtMultiplier.ReadOnly = true;
                            }
                        }
                        else // Consumables
                        {
                            txtMultiplier.ReadOnly = false;
                            txtQuantity.ReadOnly = true;
                        }

                        txtDescription.ReadOnly = false;
                    }
                }
            }
        }

        private bool GetCalculationRule(string sUnit)
        {
            bool bCalcRuleExists = false;
            sLineCalcRuleID = "";
            sLineCalcUnit = "";

            using (PsqlConnection oConnSol = new PsqlConnection(Connect.LiquidConnectionString))
            {
                oConnSol.Open();
                int iReturn = 0;
                string sSqlSol = "Select * from SOLRM where sRuleName = '" + sUnit + "'";

                PsqlDataReader rdReaderSol = Connect.getDataCommand(sSqlSol, oConnSol).ExecuteReader();
                while (rdReaderSol.Read())
                {
                    sLineCalcRuleID = rdReaderSol["PKiRuleID"].ToString();
                    sLineCalcUnit = rdReaderSol["SRuleUnit"].ToString();
                    iReturn++;
                }
                rdReaderSol.Close();

                if (iReturn > 0)
                    bCalcRuleExists = true;
                oConnSol.Dispose();
            }

            return bCalcRuleExists;
        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            if (sender.GetType().Name == "TextBox")
            {
                if (((TextBox)sender).Text == ".")
                {
                    ((TextBox)sender).Text = "0";
                }
            }
            decimal dExPrice = 0;
            if (txtExcPrice.Text != "")
            {
                dExPrice = Convert.ToDecimal(txtExcPrice.Text.Replace(",", ""));
            }
            if (((TextBox)sender).Text != "" && bDoCalculation)
            {
                decimal dTotalExDiscount = Convert.ToDecimal(txtMultiplier.Text.Replace(",", "")) * Convert.ToDecimal(txtQuantity.Text.Replace(",", "")) * dExPrice;
                txtNet.Text = (dTotalExDiscount - (dTotalExDiscount * (Convert.ToDecimal(txtDiscount.Text.Replace(",", "")) / 100))).ToString("N2");
                ((Documents.SalesOrder)(Parent.Parent.Parent.Parent)).addTotals();
            }
            if (bSaved && chkReturn.Checked)
            {
                ((Documents.SalesOrder)(Parent.Parent.Parent.Parent)).addUpdateInstruction(txtCode.Text, 0, dtDelivery.Value.ToString("dd-MM-yyyy"), txtMultiplier.Text, txtQuantity.Text);
            }
        }

        private void numeric_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (sender.GetType().Name == "TextBox")
            {
                if (((TextBox)sender).Text.IndexOf(".") > 0 && e.KeyChar == '.')
                {
                    e.Handled = true;
                    return;
                }
            }
            if (((e.KeyChar < '0') || (e.KeyChar > '9')) && e.KeyChar.ToString() != "\b" && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void txtQuantity_Leave(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text != "")
            {
                ((TextBox)sender).Text = Convert.ToDouble(((TextBox)sender).Text.Replace(",", "")).ToString("N2");
            }
            else
            {
                txtQuantity.Text = "0.00";
            }
                     
        }

        private void nextControl(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                manageFrontEnd();
            }
        }

        private void manageFrontEnd()
        {
            Control cntSelectedControl = ActiveControl;

            switch (cntSelectedControl.Name)
            {
                case "txtStore":
                    txtCode.Focus();
                    break;

                case "txtCode":
                    if (txtCode.Text == "")
                    {
                        cmdCodeSearch_Click(null, null);
                    }
                    else if (!cmdCodeSearch.Visible)
                    {
                        dtDelivery.Focus();
                    }
                    else
                    {
                        Populate_Inventory_Fields(true);
                    }
                    break;
                case "txtDescription":
                    txtProject.Focus();
                    break;
                case "txtProject":
                    if(txtProject.Text == "")
                    {
                        cmdProjectSearch_Click(null, null);
                    }
                    else
                    {
                        if (dtDelivery.Visible)
                        {
                            dtDelivery.Focus();
                        }
                        else if (!txtMultiplier.ReadOnly)
                        {
                            txtMultiplier.Focus();
                        }
                        else
                        {
                            txtQuantity.Focus();
                        }
                    }
                    break;

                case "dtDelivery":
                    if (dtReturnDate.Enabled)
                    {
                        dtReturnDate.Focus();
                    }
                    else if (!txtMultiplier.ReadOnly)
                    {
                        txtMultiplier.Focus();
                    }
                    else
                    {
                        txtQuantity.Focus();
                    }
                    break;

                case "dtReturnDate":
                    if (!txtMultiplier.ReadOnly)
                    {
                        txtMultiplier.Focus();
                    }
                    else if (!txtQuantity.ReadOnly)
                    {
                        txtQuantity.Focus();
                    }
                    else if (!txtDiscount.ReadOnly)
                    {
                        txtDiscount.Focus();
                    }
                    else
                    {
                        txtExcPrice.Focus();
                    }
                    break;

                case "txtMultiplier":
                    if (txtMultiplier.Text != "")
                    {
                        txtMultiplier.Text = Convert.ToDecimal(txtMultiplier.Text.Replace(",", "")).ToString("N2");
                    }
                    if (!txtQuantity.ReadOnly)
                    {
                        txtQuantity.Focus();
                    }
                    else if (!txtDiscount.ReadOnly)
                    {
                        txtDiscount.Focus();
                    }
                    else
                    {
                        txtExcPrice.Focus();
                    }
                    break;

                case "txtQuantity":
                    if (txtQuantity.Text != "")
                    {
                        txtQuantity.Text = Convert.ToDecimal(txtQuantity.Text.Replace(",", "")).ToString("N2");
                    }
                    if (!txtDiscount.ReadOnly)
                    {
                        txtDiscount.Focus();
                    }
                    else
                    {
                        txtExcPrice.Focus();
                    }

                    break;

                case "txtDiscount":
                    if (txtExcPrice.Text != "")
                    {
                        txtExcPrice.Text = Convert.ToDecimal(txtExcPrice.Text.Replace(",", "")).ToString("N2");
                    }
                    txtExcPrice.Focus();
                    break;

                case "txtExcPrice":
                    if (bFocusOnNextLine)
                    {
                        ((Documents.SalesOrder)(Parent.Parent.Parent.Parent)).focusNextLine(iLineIndex + 1);
                    }
                    break;
            }
        }

        public void makeLineReadOnly()
        {
            bSaved = true;
            cmdCodeSearch.Visible = false;
            cmdSearchStore.Visible = false;
            txtStore.ReadOnly = true;
            txtCode.ReadOnly = true;
            txtCode.BackColor = Color.White;
            if (txtStatus.Text != "1")
            {
                txtDescription.ReadOnly = false;
            }
            else
            {
                txtDescription.ReadOnly = true;
            }
            txtDescription.BackColor = Color.White;
            if (txtLastInvoiceDate.Text == "" && txtStatus.Text != "1") // only enable when not invoiced yet
            {
                dtDelivery.Enabled = true;
            }
            else
            {
                dtDelivery.Enabled = false;
            }
            //	dtDelivery.BackColor = Color.White;
            dtReturnDate.Enabled = false;
            //			dtReturnDate.BackColor = Color.White;
            txtQuantity.ReadOnly = true;
            //			txtQuantity.BackColor = Color.White;
            txtDiscount.ReadOnly = true;
            //			txtDiscount.BackColor = Color.White;
            txtExcPrice.ReadOnly = true;
            //			txtExcPrice.BackColor = Color.White;
            txtMultiplier.ReadOnly = true;
            txtNet.ReadOnly = true;
            if (txtLastInvoiceDate.Text == "" && picReturned.Visible == false && picDelete.Visible)
            {
                picDelete.Visible = true;
            }
        }

        public void openLineForEdit()
        {
            if (txtLastInvoiceDate.Text == "" && txtStatus.Text != "1") // only enable when not invoiced yet
            {
                dtDelivery.Enabled = true;
            }
            else
            {
                dtDelivery.Enabled = false;
            }
            txtQuantity.ReadOnly = false;
            if (sLineType == "1")
            {
                txtQuantity.ReadOnly = false;
                if (bAllowDuplicateLines && !(txtDescription.Text.StartsWith("*D")) && txtCode.Text != "'")
                {
                    txtMultiplier.ReadOnly = false;
                }
                else
                {
                    txtMultiplier.ReadOnly = true;
                }
            }
            else // Consumables
            {
                txtMultiplier.ReadOnly = false;
                txtQuantity.ReadOnly = true;
            }

            dtReturnDate.Enabled = true;
            if (txtDiscountType.Text == "0" || txtDiscountType.Text == "1")
            {
                txtDiscount.ReadOnly = true;
            }
            else
            {
                txtDiscount.ReadOnly = false;
            }
            txtExcPrice.ReadOnly = false;
            if (txtLastInvoiceDate.Text == "" && picReturned.Visible == false && picDelete.Visible)
            {
                picDelete.Visible = true;
            }
        }

        public void clearLine()
        {
            txtCode.Text = "";
            txtDescription.Text = "";
            dtDelivery.Visible = false;
            lblDeliveryDate.Visible = true;
            dtReturnDate.Visible = false;
            lblReturnDate.Visible = true;
            txtUnit.Text = "";
            txtQuantity.Text = "1.00";
            txtDiscount.Text = "0";
            txtExcPrice.Text = "0.00";
            txtNet.Text = "0.00";
            //LL Phalaborwa
            txtNet.BackColor = Color.White;
            txtTaxType.Text = "";
            //LL
        }
        
        private void picInfo_Click(object sender, EventArgs e)
        {
            var frmInfo = new Documents.SalesLineInfo();
            frmInfo.ShowDialog(txtCode.Text, txtDescription.Text, txtLastInvoiceDate.Text);
        }

        public void dtDelivery_ValueChanged(object sender, EventArgs e)
        {
            if (bSaved && !chkReturn.Checked)
            {
                ((Documents.SalesOrder)(Parent.Parent.Parent.Parent)).addUpdateInstruction(txtCode.Text, 0, dtDelivery.Value.ToString("dd-MM-yyyy "), txtMultiplier.Text, txtQuantity.Text);
            }
            else
            {
                if (Parent == null) return;
                var qty = calcDays();
                //LL 12/02/2010 - Site Fasilities Calculation Rules
                if (txtUnitFormula.Text == "")
                {
                    txtQuantity.Text = Convert.ToDecimal(qty).ToString("N2");
                }
                else
                {
                    qty = calcDays();
                    bool bLineReturned = chkReturn.Checked;
                    txtQuantity.Text = Functions.CalculateQty_UnitRule(int.Parse(qty), txtUnitFormula.Text.Trim(), bLineReturned, dtDelivery.Value, dtReturnDate.Value);
                }
                //End LL 12/02/2010 - Site Fasilities Calculation Rules
            }
        }

        private void SalesLine_Load(object sender, EventArgs e)
        {
            txtDescription.CharacterCasing = CharacterCasing.Upper;
            txtCode.CharacterCasing = CharacterCasing.Upper;
        }

        private void picDelete_Click(object sender, EventArgs e)
        {
            if (txtCode.Text == "") return;
            var bDeleteLastLine = false;
            using (var pastelConnection = new PsqlConnection(Connect.PastelConnectionString))
            {
                pastelConnection.Open();
                var sSalesOrder = ((Documents.SalesOrder) (Parent.Parent.Parent.Parent)).txtNumber.Text.ToUpper().Trim();

                if (sSalesOrder != "*NEW*" && sSalesOrder != "")
                {
                    //remove actual line from sales order...
                    if (
                        MessageBox.Show("This will permanently remove this item from this order. Are you sure?",
                            "Delete", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (txtCode.Text == "'")
                        {
                            sLineType = "7";
                        }
                        var sql = "";

                        bool bHistoryLineRemoved = false;
                        try
                        {
                            sql = "Delete from HistoryLines ";
                            sql += " WHERE DocumentNumber = '" + sSalesOrder + "' and LinkNum = " + sPastelLineLink +
                                   " and DocumentType in (2,102)";
                            ;
                            Connect.getDataCommand(sql, pastelConnection).ExecuteNonQuery();
                            bHistoryLineRemoved = true;
                        }
                        catch
                        {
                            bHistoryLineRemoved = false;
                        }
                        if (bHistoryLineRemoved)
                        {
                            sql = "UPDATE HistoryLines  ";
                            sql += " SET LinkNum = LinkNum - 1 ";
                            sql += "  WHERE DocumentNumber = '" + sSalesOrder + "' and LinkNum > " + sPastelLineLink +
                                   " and DocumentType in (2,102)";
                            ;
                            Connect.getDataCommand(sql, pastelConnection).ExecuteNonQuery();
                            bDeleteLastLine = true;
                            if (txtCode.Text != "'")
                            {
                                sql = "UPDATE Inventory SET ";
                                sql += " UserDefText01 = '',";
                                sql += " UserDefText02 = '',";
                                sql += " UserDefText03 = ''";
                                sql += " WHERE ItemCode = '" + txtCode.Text + "' and UserDefText02 = '" +
                                       sSalesOrder.Trim() + "' ";
                                Connect.getDataCommand(sql, pastelConnection).ExecuteNonQuery();

                                //LL 17/09/2009 Delete line in SOLHL - Start
                                using (PsqlConnection oConnSol = new PsqlConnection(Connect.LiquidConnectionString))
                                {
                                    oConnSol.Open();
                                    try
                                    {
                                        sql = "Delete from SOLHL ";
                                        sql += "where Header = '" + sSalesOrder.Trim() + "' ";
                                        sql += "and ItemCode = '" + txtCode.Text + "' ";
                                        sql += "and LinkNum = '" + sPastelLineLink + "' ";

                                        Connect.getDataCommand(sql, oConnSol).ExecuteNonQuery();

                                        sql = "UPDATE SOLHL  ";
                                        sql += " SET LinkNum = LinkNum - 1 ";
                                        sql += "  WHERE Header = '" + sSalesOrder + "' and LinkNum > " + sPastelLineLink +
                                               "";
                                        Connect.getDataCommand(sql, oConnSol).ExecuteNonQuery();
                                    }
                                    catch
                                    {
                                    }

                                    oConnSol.Dispose();
                                }
                                //LL 17/09/2009 Delete line in SOLHL - end
                            }
                            else
                            {
                                //LL 17/09/2009 Delete line in SOLHL - Start
                                using (PsqlConnection oConnSol = new PsqlConnection(Connect.LiquidConnectionString))
                                {
                                    oConnSol.Open();
                                    try
                                    {
                                        sql = "Delete from SOLHL ";
                                        sql += "where Header = '" + sSalesOrder.Trim() + "' ";
                                        sql += "and ItemCode = 'C' ";
                                        sql += "and LinkNum = '" + sPastelLineLink + "' ";

                                        Connect.getDataCommand(sql, oConnSol).ExecuteNonQuery();

                                        sql = "UPDATE SOLHL  ";
                                        sql += " SET LinkNum = LinkNum - 1 ";
                                        sql += "  WHERE Header = '" + sSalesOrder + "' and LinkNum > " + sPastelLineLink +
                                               "";
                                        Connect.getDataCommand(sql, oConnSol).ExecuteNonQuery();
                                    }
                                    catch
                                    {
                                    }

                                    oConnSol.Dispose();
                                }
                            }
                        }

                        ((Documents.SalesOrder) (Parent.Parent.Parent.Parent)).RenumberPastelLinkNumOnSalesLine(
                            sPastelLineLink);

                        ((Documents.SalesOrder) (Parent.Parent.Parent.Parent)).loadSalesOrder(sSalesOrder);
                    }
                    pastelConnection.Dispose();
                }
                else
                {
                    bDoCalculation = false;
                    SalesLineForm slNewDeletedLineForm = (SalesLineForm) this;
                    ((Documents.SalesOrder) (Parent.Parent.Parent.Parent)).deleteSalesLine(slNewDeletedLineForm,
                        bDeleteLastLine);

                    return;
                }
            }
        }

        private void txtDiscount_Leave(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text != "")
            {
                ((TextBox)sender).Text = Convert.ToDouble(((TextBox)sender).Text.Replace(",", "")).ToString("N2");
            }
            else
            {
                txtDiscount.Text = "0.00";
            }
        }

        //LL Phalaborwa void
        private void txtExcPrice_Leave(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text != "")
            {
                ((TextBox)sender).Text = Convert.ToDouble(((TextBox)sender).Text.Replace(",", "")).ToString("N2");
            }
            else
            {
                txtExcPrice.Text = "0.00";
            }
        }

       private void picReturned_DoubleClick(object sender, EventArgs e)
        {
            using (Forms.VerifyUser frmVerify = new Forms.VerifyUser())
            {
                if (frmVerify.ShowDialog() == DialogResult.OK)
                {
                    if (Functions.getUserProfile(frmVerify.sUserCode).bCancelReturnItem)
                    {
                        using (PsqlConnection oLiquidConnection = new PsqlConnection(Connect.LiquidConnectionString))
                        {
                            string sSalesOrder = ((Documents.SalesOrder)(Parent.Parent.Parent.Parent)).txtNumber.Text.ToUpper();
                            string sSql = "UPDATE SOLHL set Status = 0 where Header = '" + sSalesOrder + "' and LinkNum = " + sPastelLineLink;
                            int iRet = Connect.getDataCommand(sSql, oLiquidConnection).ExecuteNonQuery();
                            ((Documents.SalesOrder)(Parent.Parent.Parent.Parent)).loadSalesOrder(sSalesOrder);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Your user account does not allow you to cancel the returned item.  Please contact your manager.", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void chkReturn_CheckedChanged(object sender, EventArgs e)
        {
            if (chkReturn.Checked)
            {
                if (((Documents.SalesOrder)(Parent.Parent.Parent.Parent)).txtNumber.Text.ToUpper() != "*NEW*")
                    openLineForEdit();
                if (dtDelivery.Enabled && dtDelivery.Visible)
                {
                    dtDelivery.Focus();
                }
                else if (!txtMultiplier.ReadOnly)
                {
                    txtMultiplier.Focus();
                }
                else
                {
                    txtQuantity.Focus();
                }
                if (!((Documents.SalesOrder)(Parent.Parent.Parent.Parent)).bInvoiceMode)
                {
                    ((Documents.SalesOrder)(Parent.Parent.Parent.Parent)).cmdSaveOrder.Enabled = true;
                }
            }
            else
            {
                if (((Documents.SalesOrder)(Parent.Parent.Parent.Parent)).txtNumber.Text.ToUpper() != "*NEW*")
                    makeLineReadOnly();
            }

            string quantity = "";
            if (dtDelivery.Visible && dtReturnDate.Visible) //cant have period if it is a consumable DDK
            {
                quantity = calcDays();
            }
            else
            {
                quantity = "1";
            }

            //LL 12/02/2010 - Site Fasilities Calculation Rules
            if (txtUnitFormula.Text == "")
            {
                txtQuantity.Text = Convert.ToDecimal(quantity).ToString("N2");
            }
            else
            {
                quantity = calcDays();
                var isLineReturned = chkReturn.Checked;
                txtQuantity.Text = Functions.CalculateQty_UnitRule(int.Parse(quantity), txtUnitFormula.Text, isLineReturned,
                    dtDelivery.Value, dtReturnDate.Value);
            }
        }

        private string calcDays()
        {
            var dateFunctionService = CreateDatesFunctionDomainService();
            var datePickerBackColor = Color.White;
            var days = dateFunctionService.CalculateDays(dtDelivery.Value, dtReturnDate.Value,
                new CalculateDaysSettings
                {
                    ExcludeHolidays = ((Documents.SalesOrder)(Parent.Parent.Parent.Parent)).chkPublicHolidays.Checked,
                    ExcludeSundays = ((Documents.SalesOrder)(Parent.Parent.Parent.Parent)).chkSundays.Checked,
                    ExcludeSaturdays = ((Documents.SalesOrder)(Parent.Parent.Parent.Parent)).chkSaturday.Checked
                });
            if (days == -1)
            {
                datePickerBackColor = Color.Red;
            }

            dtDelivery.Parent.BackColor = datePickerBackColor;
            dtReturnDate.Parent.BackColor = datePickerBackColor;

            return days.ToString();
        }

        private static DatesFunctionDomainService CreateDatesFunctionDomainService()
        {
            var holidayRepo = new HolidayRepository(Connect.LiquidConnectionString);
            return new DatesFunctionDomainService(holidayRepo);
        }

        private void cmdFromulaFinder_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            if (Global.bUseQuantityMeasure)
            {
                using (Finder.MeasureZoom frmMeasureZoom = new Finder.MeasureZoom())
                {
                    if (frmMeasureZoom.ShowDialog() == DialogResult.OK)
                    {
                        txtUnit.Text = frmMeasureZoom.sUnit;
                    }
                }
            }
            else
            {
                using (Finder.RuleZoom frmRuleZoom = new Finder.RuleZoom())
                {
                    if (frmRuleZoom.ShowDialog() == DialogResult.OK)
                    {
                        if (frmRuleZoom.sRuleID != "")
                        {
                            txtUnitFormula.Text = frmRuleZoom.sRuleNameReturn;
                            txtLineRuleID.Text = frmRuleZoom.sRuleID;
                            txtUnit.Text = frmRuleZoom.sRuleUnit;

                            ((Documents.SalesOrder)(Parent.Parent.Parent.Parent)).addTotals();
                        }
                    }
                }
            }

            Cursor = Cursors.Default;
        }

        private void picAddLine_Click(object sender, EventArgs e)
        {
            if (
                MessageBox.Show("This will add a new line to the document. Do you want to continue?", "Add a New Line",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK) return;
            if (sPastelLineLink == "1")
            {
                if (MessageBox.Show("Do you want to add a new first line to document?", "Add First Line", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int iClickedLine = 0;
                    InsertNewLine(iClickedLine);
                }
                else
                {
                    int iClickedLine = Convert.ToInt16(sPastelLineLink);
                    InsertNewLine(iClickedLine);
                }
            }
            else
            {
                int iClickedLine = Convert.ToInt16(sPastelLineLink);
                InsertNewLine(iClickedLine);
            }
        }

        private void InsertNewLine(int iClickedLine)
        {
            var slLastLine = (SalesLineForm)((Documents.SalesOrder)(Parent.Parent.Parent.Parent)).Saleslines[((Documents.SalesOrder)(Parent.Parent.Parent.Parent)).Saleslines.Length - 1];
            int iInsertNewLine = iClickedLine + 1;
            int ilength = ((Documents.SalesOrder)(Parent.Parent.Parent.Parent)).Saleslines.Length;

            for (int iLines = 0; iLines < ilength; iLines++)
            {
                SalesLineForm slThisline = (((SalesLineForm)(SalesLineForm)((Documents.SalesOrder)(Parent.Parent.Parent.Parent)).Saleslines[iLines]));
                if (Convert.ToInt16(slThisline.sPastelLineLink) > iClickedLine)
                {
                    slThisline.Top = 17 + ((Convert.ToInt16(slThisline.sPastelLineLink)) * 20); //because controll counts line 1 as 0
                    slThisline.sPastelLineLink = Convert.ToString(Convert.ToInt16(slThisline.sPastelLineLink) + 1);
                    slThisline.iLineIndex = slThisline.iLineIndex + 1;
                }
            }
            var slNewline = new SalesLineForm
            {
                sPastelLineLink = iInsertNewLine.ToString(),
                bInsertInMiddle = true
            };
            ((Documents.SalesOrder)(Parent.Parent.Parent.Parent)).AddSalesLine(slNewline);
            ((Documents.SalesOrder)(Parent.Parent.Parent.Parent)).addUpdateInstruction(slNewline.Name, 1, slNewline, slNewline.txtQuantity.Text, slNewline.txtMultiplier.Text);
            int iCounter = 0;
            Control[] aNewSaleslines = new Control[0];
            bool bfound = false;
            for (int iNewLines = 1; iNewLines < ilength + 2; iNewLines++)
            {
                bfound = false;
                for (int iLines = 0; iLines <= ilength; iLines++)
                {
                    //create new controll that is in correct order according to spastellinelink
                    var slThisline = (SalesLineForm)((Documents.SalesOrder)(Parent.Parent.Parent.Parent)).Saleslines[iLines];
                    if (iNewLines != Convert.ToInt16(slThisline.sPastelLineLink)) continue;
                    Array.Resize<Control>(ref aNewSaleslines, aNewSaleslines.Length + 1);
                    aNewSaleslines[aNewSaleslines.Length - 1] = slThisline;
                    bfound = true;
                }
                if (bfound)
                {
                    iCounter++;
                }
            }
            ((Documents.SalesOrder)(Parent.Parent.Parent.Parent)).Saleslines = aNewSaleslines;
        }

        private void txtDescription_KeyPress(object sender, KeyPressEventArgs e)
        {
            bEdited = true;
        }

        public IDocumentLine ToDomain()
        {
            var itemRepo = new ItemRepository(Connect.LiquidConnectionString, Connect.PastelConnectionString);
            var salesorderLine = new SalesorderLine
            {
                Item = itemRepo.GetByCode(txtCode.Text.Trim()),
                Description = txtDescription.Text.Trim(),
                CostCode = txtProject.Text.Trim(),
                LinkNumber = iLineIndex,
                Period =  decimal.Parse(txtQuantity.Text),
                Quantity = decimal.Parse(txtMultiplier.Text),
                UnitPrice = decimal.Parse(txtExcPrice.Text),
                InclusivePrice = decimal.Parse(txtNet.Text),
                DiscountPercentage = (int)decimal.Parse(txtDiscount.Text),
                MultiStore = txtStore.Text,
                UnitUsed = txtUnit.Text,
                CalculationRule = txtUnitFormula.Text,
                SearchTypeRaw = sLineType == "" ? "7" : "4" ,
                TaxType = txtTaxType.Text,
            };

            if (isAsset())
            {
                salesorderLine.DeliveryDate = dtDelivery.Value;
                salesorderLine.ReturnDate = dtReturnDate.Value;
            }
            return salesorderLine;
        }

        private bool isAsset()
        {
            return sLineType == "1";
        }

        private void cmdProjectSearch_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            using (var jobCodeZoom = new JobCodeZoom())
            {
                if (jobCodeZoom.ShowDialog() == DialogResult.OK)
                {
                    txtProject.Text = jobCodeZoom.sJobCode;
                    bEdited = true;
                }
            }
            Cursor = Cursors.Default;
        }
    }
}