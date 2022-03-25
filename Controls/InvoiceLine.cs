using Pervasive.Data.SqlClient;
using Liquid.Classes;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Liquid.Controls
{
    public partial class InvoiceLine : UserControl
    {
        public Solsage_Pastel_API.solPastelSDK clsSDK = new Solsage_Pastel_API.solPastelSDK();
        public bool bNextLine;
        public bool bFocusOnNextLine = true;
        public bool bSaved;
        public string sOldDescription = "";
        public string sParentLinkNum = "";
        public int iLineIndex;
        public string sPastelLineLink = "";
        public bool bDoCalculation = true;
        private const int WM_KEYDOWN = 0x100;
        private const int WM_SYSKEYDOWN = 0x104;
        private CodeProject.SystemHotkey.SystemHotkey deleteHotKey;
        public bool bAllowDuplicateLines;
        public bool IsAlreadyInvoiced = false;
        public event DeleteHandler OnDelete;

        public delegate void DeleteHandler(int index);

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            var bHandled = false;
            if ((msg.Msg != WM_KEYDOWN) && (msg.Msg != WM_SYSKEYDOWN)) return false;
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
            return bHandled;
        }

        public InvoiceLine()
        {
            InitializeComponent();
            Paint += OnHandlePaint;
            CreateGraphics();
            deleteHotKey = new CodeProject.SystemHotkey.SystemHotkey();
            txtStore.Text = Global.DefaultMultiStore;
        }

        protected void OnHandlePaint(object sender, PaintEventArgs args)
        {
            var g1 = args.Graphics;
            var pen = new Pen(Color.FromArgb(100, 100, 100), 2);

            g1.DrawLine(pen, 111, 0, 111, 20);
            g1.DrawLine(pen, 361, 0, 361, 20);
            g1.DrawLine(pen, 462, 0, 462, 20);
            g1.DrawLine(pen, 562, 0, 562, 20);
            g1.DrawLine(pen, 622, 0, 622, 20);
            g1.DrawLine(pen, 687, 0, 687, 20);
            g1.DrawLine(pen, 752, 0, 752, 20);
            g1.DrawLine(pen, 812, 0, 812, 20);
            g1.DrawLine(pen, 893, 0, 893, 20);
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

        private void Populate_Inventory_Fields(bool bFocusDescription)
        {
            bool bExist = false;
            if (txtCode.Text == "'")
            {
                txtDiscount.ReadOnly = true;
                txtExcPrice.ReadOnly = true;
                txtLastInvoiceDate.Text = "";
                txtNet.ReadOnly = true;
                txtPeriod.ReadOnly = true;
                txtPeriod.Text = "0";
                txtUnit.ReadOnly = true;
                txtStore.ReadOnly = true;
                txtDescription.Focus();
                bDoCalculation = false;
            }
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
                    if ((inventoryReader["UserDefText01"].ToString().Trim().ToUpper() == "ORDER" ||
                         inventoryReader["UserDefText01"].ToString().Trim().ToUpper() == "RESERVED" ||
                         inventoryReader["UserDefText01"].ToString().Trim().ToUpper() == "WORKSHOP") &&
                        (inventoryReader["UserDefNum02"].ToString() != "1")) //UserDefNum02 = Allow duplicates
                    {
                        MessageBox.Show(
                            "Inventory is currently not available.\r\n\r\nStatus:			" +
                            inventoryReader["UserDefText01"].ToString().Trim() + "\r\nExpected date back:		" +
                            inventoryReader["UserDefText03"].ToString().Trim() + "\r\nReference number:		" +
                            inventoryReader["UserDefText02"].ToString().Trim(), "Item Not Available",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        clearLine();
                        txtCode.Focus();
                        bNextLine = false;
                    }

                    txtDescription.Text = inventoryReader["Description"].ToString().Trim();
                    txtUnit.Text = inventoryReader["UnitSize"].ToString();
                    try
                    {
                        txtExcPrice.Text = Convert.ToDouble(inventoryReader["SellExcl01"].ToString()).ToString("N2");
                    }
                    catch
                    {
                        txtExcPrice.Text = "0.00";
                    }

                    txtTaxType.Text = inventoryReader["SalesTaxType"].ToString().Trim();
                    txtDiscountType.Text = inventoryReader["DiscountType"].ToString().Trim();

                    txtNet.BackColor = txtTaxType.Text == "0" ? Color.Yellow : Color.White;

                    if (bFocusDescription)
                    {
                        txtDescription.Focus();
                    }
                    if (inventoryReader["UserDefNum02"].ToString() == "1")  //AJD 12-08-2009
                    {
                        bAllowDuplicateLines = true;
                    }
                    if (inventoryReader["DiscountType"].ToString() == "0" || inventoryReader["DiscountType"].ToString() == "1")//AJD 20-08-2009
                    {
                        txtDiscount.ReadOnly = true;
                    }
                }//end while
                inventoryReader.Close();
                pastelConnection.Dispose();
                if (!bExist)
                    MessageBox.Show("Code does not exist.", "Inventory Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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
                if (txtPeriod.Text != "")
                {
                    decimal dTotalExDiscount = Convert.ToDecimal(txtQuantity.Text.Replace(",", "")) * Convert.ToDecimal(txtPeriod.Text.Replace(",", "")) * dExPrice;
                    txtNet.Text = (dTotalExDiscount - (dTotalExDiscount * (Convert.ToDecimal(txtDiscount.Text.Replace(",", "")) / 100))).ToString("N2");
                }
                else
                {
                    txtNet.Text = dExPrice.ToString();
                }

                ((Documents.Invoices)(Parent.Parent)).AddTotals();
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
                txtPeriod.Text = "0.00";
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
            var selecteInvoiceLine = ActiveControl;

            switch (selecteInvoiceLine.Name)
            {
                case "txtStore":
                    txtCode.Focus();
                    break;

                case "txtCode":
                    {
                        if (txtCode.Text == "")
                            cmdCodeSearch_Click(null, null);
                        else
                            Populate_Inventory_Fields(true);
                    }
                    break;

                case "txtDescription":
                    if (dtDelivery.Visible)
                    {
                        dtDelivery.Focus();
                    }
                    else
                    {
                        txtQuantity.Focus();
                    }
                    break;

                case "dtDelivery":
                    dtReturnDate.Focus();
                    break;

                case "dtReturnDate":
                    txtQuantity.Focus();
                    break;

                case "txtMultiplier":
                    txtPeriod.Focus();
                    break;

                case "txtQuantity":
                    txtDiscount.Focus();
                    break;

                case "txtDiscount":
                    txtExcPrice.Focus();
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
            txtDescription.ReadOnly = true;
            txtDescription.BackColor = Color.White;
            dtDelivery.Enabled = false;
            dtDelivery.BackColor = Color.White;
            dtReturnDate.Enabled = false;
            dtReturnDate.BackColor = Color.White;
            txtPeriod.ReadOnly = true;
            txtPeriod.BackColor = Color.White;
            txtDiscount.ReadOnly = true;
            txtDiscount.BackColor = Color.White;
            txtExcPrice.ReadOnly = true;
            txtExcPrice.BackColor = Color.White;
            txtQuantity.ReadOnly = true;
            txtQuantity.BackColor = Color.White;
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
            txtPeriod.Text = "1.00";
            txtDiscount.Text = "0";
            txtExcPrice.Text = "0.00";
            txtNet.Text = "0.00";
            txtNet.BackColor = Color.White;
            txtTaxType.Text = "";
        }

        private void picInfo_Click(object sender, EventArgs e)
        {
            var frmInfo = new Documents.SalesLineInfo();
            frmInfo.ShowDialog(txtCode.Text, txtDescription.Text, txtLastInvoiceDate.Text);
        }

        private void InvoiceLine_Load(object sender, EventArgs e)
        {
            txtDescription.CharacterCasing = CharacterCasing.Upper;
            txtCode.CharacterCasing = CharacterCasing.Upper;
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

        private void picDelete_Click(object sender, EventArgs e)
        {
            if (OnDelete != null)
            {
                OnDelete(iLineIndex);
            }
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
                        ((Documents.Invoices)(Parent.Parent)).AddTotals();
                    }
                }
            }
            Cursor = Cursors.Default;
        }
    }
}