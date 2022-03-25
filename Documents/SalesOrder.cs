using CodeProject.SystemHotkey;
using CrystalDecisions.CrystalReports.Engine;
using Liquid.Classes;
using Liquid.Controls;
using Liquid.Domain;
using Liquid.Domain.DefinitionObjects.HistoryHeaders;
using Liquid.Domain.Enums;
using Liquid.Domain.Services;
using Liquid.Finder;
using Liquid.Forms;
using Liquid.Repository;
using Liquid.Services;
using Pervasive.Data.SqlClient;
using Solsage_Pastel_API;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Functions = Liquid.Classes.Functions;
using Liquid.Domain.DefinitionObjects.SalesLines;
using Liquid.Services.Processes;

namespace Liquid.Documents
{
    //sales order type : 0 = Short Term ; 1 = Long Term

    [SuppressMessage("ReSharper", "PrivateFieldCanBeConvertedToLocalVariable")]
    public partial class SalesOrder : Form
    {
        public solPastelSDK clsSDK = new solPastelSDK();
        public int iLineCounter = 0;
        public int iSalesOrderStatus;
        public bool bLockedStatus;
        public Control[] Saleslines = new Control[0];
        public Control[] aCreditlines = new Control[0];
        public object[,] aUpdate = new object[0, 5];
        private string sCustDelivCode = "";
        public bool bInvoiceMode;
        public bool bMonthEndMode;
        public bool bPermanentMonthEnd = false;
        private bool bBlockedCustomer;
        private readonly SystemHotkey _saveHotKey;
        private readonly SystemHotkey _loadOrderHotKey;
        private readonly SystemHotkey _depositAccountHotKey;
        public bool DoGLTransaction = true;
        public bool bSaved;
        public string sDepositDebit = "", sDepositCredit = "";
        public int iLineRowIndex, iInvoiceLineRowIndex = 0, iCreditLineRowIndex;
        private const int WM_KEYDOWN = 0x100;
        private const int WM_SYSKEYDOWN = 0x104;
        public string[] aMainAddressList = new string[10];
        public Color[] aSalesOrderStatusColor = { Color.LimeGreen, Color.DarkCyan, Color.Orange, Color.Black };
        private ReportClass rptInvoice;
        public int iSalesOrderType;

        //Styles
        private readonly DataGridViewCellStyle _cssDowntimeRow = new DataGridViewCellStyle();

        private string _authorizedPerson;
        private bool _hasAuthorizedPersons;

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            var bHandled = false;
            if ((msg.Msg != WM_KEYDOWN) && (msg.Msg != WM_SYSKEYDOWN)) return false;
            var sTabName = tcPortal.SelectedTab.Name;
            switch (keyData)
            {
                case Keys.Tab:
                case Keys.Enter:
                    if (sTabName != "tpReturn")
                    {
                        manageFrontEnd();
                    }
                    bHandled = true;
                    break;
            }
            return bHandled;
        }

        public DialogResult ShowDialog(string sOrdernumber, DateTime dtMonthEndInvoiceDate)
        {
            if (bPermanentMonthEnd)
            {
                cmdViewMonthEnd.Visible = false;
                cmdNewOrder.Visible = false;
                bMonthEndMode = true;
            }
            loadSalesOrder(sOrdernumber);
            return ShowDialog();
        }

        public SalesOrder()
        {
            InitializeComponent();

            // 
            btnCustomerNotes.Visible = false;

            _saveHotKey = new SystemHotkey();
            _loadOrderHotKey = new SystemHotkey();
            _depositAccountHotKey = new SystemHotkey();

            _saveHotKey.Shortcut = Shortcut.CtrlS;
            _saveHotKey.Pressed += cmdSaveOrder_Click;

            _loadOrderHotKey.Shortcut = Shortcut.CtrlL;
            _loadOrderHotKey.Pressed += cmdSearchNumber_Click;

            _depositAccountHotKey.Shortcut = Shortcut.CtrlP;
            //Styles
            _cssDowntimeRow.BackColor = Color.Beige;
        }

        public void fillSalesInvoices()
        {
            selInvoices.Items.Clear();
            selInvoices.Items.Add("-Select Invoice-");

            var salesorderInvoiceDomainService = createSalesorderInvoiceDomainService();
            var invoiceHeaders = salesorderInvoiceDomainService.GetLinkedInvoiceHeadersBySalesorderNumber(txtNumber.Text);
            invoiceHeaders.ForEach(header => selInvoices.Items.Add(string.Format("{0} - {1:yyyy-MM-dd}", header.DocumentNumber, header.DocumentDate)));

            if (selInvoices.Items.Count > 0)
            {
                selInvoices.SelectedIndex = 0;
            }
        }

        private static SalesorderInvoiceDomainService createSalesorderInvoiceDomainService()
        {
            var invoiceHeaderRepository = new InvoiceHeaderRepository(Connect.LiquidConnectionString,
              Connect.PastelConnectionString);
            var salesorderRepo = new SalesOrderRepository(Connect.LiquidConnectionString,
                Connect.PastelConnectionString);
            return new SalesorderInvoiceDomainService(invoiceHeaderRepository, salesorderRepo);
        }

        private void SalesOrder_Load(object sender, EventArgs e)
        {
            btnDelete.Visible = false;
            chkContract.Enabled = false;
            dtContractDate.Enabled = false;

            cmdViewInvoiceMode.Visible = true;
            var objTStip = (ToolStrip)crystalReportViewer1.Controls[4];
            objTStip.Items[objTStip.Items.Count - 1].Visible = false;
            ActiveControl = txtNumber;
            txtNumber.Focus();
            txtSalesCode.Text = Global.sLogedInUserCode;
            txtCustomerCode.CharacterCasing = CharacterCasing.Upper;
            txtOrderNumber.CharacterCasing = CharacterCasing.Upper;

            if (Global.bAutoInvoiceOnReturn)
            {
                chkChangeInvoice.Visible = true;
            }
            else
            {
                chkChangeInvoice.Visible = false;
                chkChangeInvoice.Checked = false;
            }

            //Company Setup
            var oConn = new PsqlConnection(Connect.LiquidConnectionString);
            oConn.Open();
            var sSql = "select top 1 *   from SOLCS ";
            var rdReader = Connect.getDataCommand(sSql, oConn).ExecuteReader();
            while (rdReader.Read())
            {
                if (rdReader["GLonDeposit"].ToString().Trim() == "False")
                {
                    DoGLTransaction = false;
                }
                sDepositCredit = rdReader["DepositCredit"].ToString().Trim();
                sDepositDebit = rdReader["DepositDebit"].ToString().Trim();
            }
            rdReader.Close();
            //get Lockorder status from user
            var sLockorder = "";
            sSql = "Select LockOrder from SOLUS where UserName = '" + Global.sLogedInUserName + "'";
            rdReader = Connect.getDataCommand(sSql, oConn).ExecuteReader();
            while (rdReader.Read())
            {
                sLockorder = rdReader["LockOrder"].ToString();
            }
            if (sLockorder == "1")
            {
                cmdLockOrder.Enabled = true;
            }

            rdReader.Close();
            oConn.Dispose();
        }

        public void removeLine(object sender, EventArgs e)
        {
            if (txtNumber.Text.ToUpper() != "*NEW*") return;
            if (!ActiveControl.Name.StartsWith("slNewLine_")) return;
            var slDeletedLine = (SalesLineForm)ActiveControl;
            deleteSalesLine(slDeletedLine, false);
        }

        public void deleteSalesLine(SalesLineForm slDeletedLineForm, bool bDeleteLastLine)
        {
            var bDeleteControl = false;
            for (var iLines = 0; iLines < Saleslines.Length; iLines++)
            {
                var slThisline = (((SalesLineForm)Saleslines[iLines]));

                if (iLines == Saleslines.Length - 1 && !bDeleteLastLine) continue;
                if (slDeletedLineForm.Name == slThisline.Name)
                {
                    bDeleteControl = true;
                    pnlDetails.Controls.Remove(slDeletedLineForm);
                    if (iLines != Saleslines.Length - 1)
                    {
                        (((SalesLineForm)Saleslines[iLines + 1])).txtCode.Focus(); // focus on the next line
                    }
                }
                if (!bDeleteControl || iLines == Saleslines.Length - 1) continue;
                Saleslines[iLines] = Saleslines[iLines + 1]; //Move all the controls one up in the list
                (((SalesLineForm)Saleslines[iLines + 1])).Location = new Point((((SalesLineForm)Saleslines[iLines + 1])).Location.X, (((SalesLineForm)Saleslines[iLines + 1])).Location.Y - 20); // move location of control to new position
                (((SalesLineForm)Saleslines[iLines + 1])).iLineIndex--;//sync the lineindex of the control array
            }
            if (bDeleteControl)//update the line array
            {
                Array.Resize(ref Saleslines, Saleslines.Length - 1);
                iLineRowIndex--;
            }
            addTotals();
            //Check if you want to close the order
            if (Saleslines.Length != 0) return;
            if (MessageBox.Show("There are no more lines in this order. Do you want to close this order?", "Close Order?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Functions.CloseOrder(txtNumber.Text.Trim());
            }
        }

        public void deleteSalesLine(string sDeleteLinkNum, bool bDeleteLastLine)
        {
            var bDeleteControl = false;
            for (var iLines = 0; iLines < Saleslines.Length; iLines++)
            {
                var slThisline = (((SalesLineForm)Saleslines[iLines]));

                if (iLines == Saleslines.Length - 1 && !bDeleteLastLine) continue;
                if (sDeleteLinkNum == slThisline.sPastelLineLink)
                {
                    bDeleteControl = true;
                    pnlDetails.Controls.Remove(slThisline);
                    if (iLines != Saleslines.Length - 1)
                    {
                        (((SalesLineForm)Saleslines[iLines + 1])).txtCode.Focus(); // focus on the next line
                    }
                }
                if (!bDeleteControl || iLines == Saleslines.Length - 1) continue;
                Saleslines[iLines] = Saleslines[iLines + 1]; //Move all the controls one up in the list
                (((SalesLineForm)Saleslines[iLines + 1])).Location = new Point((((SalesLineForm)Saleslines[iLines + 1])).Location.X, (((SalesLineForm)Saleslines[iLines + 1])).Location.Y - 20); // move location of control to new position
                (((SalesLineForm)Saleslines[iLines + 1])).iLineIndex--;//sync the lineindex of the control array
            }
            if (bDeleteControl)//update the line array
            {
                Array.Resize(ref Saleslines, Saleslines.Length - 1);
                iLineRowIndex--;
            }
            addTotals();
            //Check if you want to close the order
            if (Saleslines.Length != 0) return;
            if (
                MessageBox.Show("There are no more lines in this order. Do you want to close this order?",
                    "Close Order?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) != DialogResult.Yes) return;
            Functions.CloseOrder(txtNumber.Text.Trim());
            cmdNewOrder_Click(null, null);
        }

        public bool CheckDuplicateSalesLine(string sCompareText)
        {
            foreach (Control control in Saleslines)
            {
                var slThisline = (((SalesLineForm)control));
                if (slThisline.txtCode.Text.Trim() == sCompareText.Trim())
                {
                    return !slThisline.bAllowDuplicateLines;
                }
            }
            return false;
        }

        public void InsertSalesLine(int iLineIndex, SalesLineForm slNewLineForm)
        {
            for (var iLines = 0; iLines < Saleslines.Length; iLines++)
            {
                var slThisline = (((SalesLineForm)Saleslines[iLines]));

                if (slThisline.iLineIndex == iLineIndex)//start line
                {
                    Array.Resize(ref Saleslines, Saleslines.Length + 1);//Add new row
                    iLineRowIndex++;
                    for (var iShiftLines = Saleslines.Length - 1; iShiftLines > iLines + 1; iShiftLines--)
                    {
                        Saleslines[iShiftLines] = Saleslines[iShiftLines - 1];
                        (((SalesLineForm)Saleslines[iShiftLines])).Location = new Point((((SalesLineForm)Saleslines[iShiftLines - 1])).Location.X, (((SalesLineForm)Saleslines[iShiftLines - 1])).Location.Y + 20); // move location of control to new position
                        (((SalesLineForm)Saleslines[iShiftLines])).iLineIndex++;//sync the lineindex of the control array
                    }
                    Saleslines[iLines + 1] = slNewLineForm;
                    slNewLineForm.Top = 17 + ((iLineIndex + 1) * 20);
                    slNewLineForm.Left = 4;
                    if (slNewLineForm.txtStore.Text == "")
                    {
                        slNewLineForm.txtStore.Text = Global.DefaultMultiStore;
                    }
                    slNewLineForm.TabIndex = 50 + Saleslines.Length;
                    slNewLineForm.TabStop = true;
                    slNewLineForm.iLineIndex = iLines + 1;
                    slNewLineForm.Name = "slNewLine_" + (Saleslines.Length - 1);
                    pnlDetails.Controls.Add(slNewLineForm);
                    slNewLineForm.BringToFront();
                    return;
                }
            }
        }

        public void AddSalesLine(SalesLineForm slNewLineForm)
        {
            slNewLineForm.chkReturn.Enabled = true;

            if (slNewLineForm.bInsertInMiddle == false)
            {
                Array.Resize(ref Saleslines, Saleslines.Length + 1);
                Saleslines[Saleslines.Length - 1] = slNewLineForm;

                if (iLineRowIndex < 14)
                    slNewLineForm.Top = 17 + ((iLineRowIndex) * 20);
                else
                    slNewLineForm.Top = 268;
                slNewLineForm.Left = 4;
                if (slNewLineForm.txtStore.Text == "")
                {
                    slNewLineForm.txtStore.Text = Global.DefaultMultiStore;
                }
                slNewLineForm.TabIndex = 50 + Saleslines.Length;
                slNewLineForm.TabStop = true;

                slNewLineForm.iLineIndex = Saleslines.Length - 1;
                slNewLineForm.Name = "slNewLine_" + (Saleslines.Length - 1);

                pnlDetails.Controls.Add(slNewLineForm);
                slNewLineForm.BringToFront();
                iLineRowIndex++;
            }
            else
            {
                Array.Resize(ref Saleslines, Saleslines.Length + 1);
                Saleslines[Saleslines.Length - 1] = slNewLineForm;

                if (iLineRowIndex < 14)
                    slNewLineForm.Top = 17 + ((Convert.ToInt16(slNewLineForm.sPastelLineLink) - 1) * 20);
                else
                    slNewLineForm.Top = 268;
                slNewLineForm.Left = 4;
                if (slNewLineForm.txtStore.Text == "")
                {
                    slNewLineForm.txtStore.Text = Global.DefaultMultiStore;
                }
                slNewLineForm.TabIndex = 50 + Saleslines.Length;
                slNewLineForm.TabStop = true;

                slNewLineForm.iLineIndex = Convert.ToInt16(slNewLineForm.sPastelLineLink) - 1;
                slNewLineForm.Name = "slNewLine_" + (Saleslines.Length - 1);

                pnlDetails.Controls.Add(slNewLineForm);
                slNewLineForm.BringToFront();
                iLineRowIndex++;
            }
        }

        public void addTotals()
        {
            decimal dTotal = 0;
            decimal dDiscountCalcTotal = 0;
            decimal dDiscount = 0;
            decimal dNonTaxTotal = 0;

            for (var iLines = 0; iLines < Saleslines.Length; iLines++)
            {
                var slActive = (SalesLineForm)Saleslines[iLines];

                dTotal += Convert.ToDecimal(slActive.txtNet.Text);
                if (((SalesLineForm)Saleslines[iLines]).txtDiscountType.Text == "2" || ((SalesLineForm)Saleslines[iLines]).txtDiscountType.Text == "3")
                {
                    dDiscountCalcTotal += Convert.ToDecimal(slActive.txtNet.Text);
                }

                if (slActive.txtTaxType.Text == "0" || slActive.txtTaxType.Text == "2") //Tax free item
                {
                    dNonTaxTotal += Convert.ToDecimal(slActive.txtNet.Text);
                }
                if (txtDiscount.Text != "" && txtDiscount.Text != ".")
                {
                    dDiscount = Convert.ToDecimal(txtDiscount.Text) / 100 * dDiscountCalcTotal;
                }
            }

            lblDiscountValue.Text = dDiscount.ToString("N2");
            dTotal -= dDiscount;
            var dTaxTotal = dTotal - dNonTaxTotal;
            lblTotalExValue.Text = dTotal.ToString("N2");
            lblTotalTaxValue.Text = (dTaxTotal * 0.15m).ToString("N2");
            lblTotalValue.Text = ((dTaxTotal * 1.15m) + dNonTaxTotal).ToString("N2");
        }

        public void focusNextLine(int iLineIndex)
        {
            if ((iLineIndex >= Saleslines.Length && txtNumber.Text == "*NEW*") || (iLineIndex >= Saleslines.Length && txtNumber.Text == ""))
            {
                if (txtNumber.Text == "")
                    txtNumber.Text = "*NEW*";
                var slNewline = new SalesLineForm();                
                AddSalesLine(slNewline);
            }
            if (iLineIndex >= Saleslines.Length) return;
            var slNewLine = (SalesLineForm)Saleslines[iLineIndex];
            if (slNewLine.sPastelLineLink == "")
            {
                slNewLine.sPastelLineLink = (iLineIndex + 1).ToString();
            }            
            slNewLine.txtCode.Focus();
        }

        private void cmdSearchNumber_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            using (var frmSalesZoom = new SalesOrderZoom())
            {
                if (frmSalesZoom.ShowDialog() == DialogResult.OK)
                {
                    if (frmSalesZoom.sResult != "")
                    {
                        txtNumber.Text = frmSalesZoom.sResult.Trim();
                        txtNumber.SelectionStart = 0;
                        txtNumber.SelectionLength = txtNumber.Text.Length;
                        loadSalesOrder(txtNumber.Text);
                        ActiveControl = txtNumber;
                        cmdViewInvoiceMode.Enabled = false;
                    }
                }
                Cursor = Cursors.Default;
            }
        }

        private void nextControl(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            e.SuppressKeyPress = true;
            manageFrontEnd();
            cmdViewInvoiceMode.Enabled = false;
        }

        private void manageFrontEnd()
        {
            var cntSelectedControl = ActiveControl;

            switch (cntSelectedControl.Name)
            {
                case "txtNumber":
                    if (txtNumber.Text == "")
                    {
                        cmdSearchNumber_Click(null, null);
                    }
                    else if (txtNumber.Text != "*NEW*")
                    {
                        loadSalesOrder(txtNumber.Text);
                    }
                    else
                    {
                        txtCustomerCode.Focus();
                    }
                    break;

                case "txtCustomerCode":
                    if (txtCustomerCode.Text == "")
                    {
                        findCustomer(txtCustomerCode);
                    }
                    else
                    {
                        loadCustomer(false, false);
                        if (Saleslines.Length == 0)
                        {
                            var slNewLine = new SalesLineForm();
                            AddSalesLine(slNewLine);
                        }
                    }
                    break;

                case "txtDelAd1":
                    txtDelAd2.Focus();
                    break;

                case "txtDelAd2":
                    txtDelAd3.Focus();
                    break;

                case "txtDelAd3":
                    txtDelAd4.Focus();
                    break;

                case "txtDelAd4":
                    txtDelAd5.Focus();
                    break;

                case "txtDelAd5":
                    txtContact.Focus();
                    break;

                case "txtContact":
                    txtTelephone.Focus();
                    break;

                case "txtTelephone":
                    txtFax.Focus();
                    break;

                case "txtFax":
                    txtMobile.Focus();
                    break;

                case "txtMobile":
                    txtEmail.Focus();
                    break;

                case "txtEmail":
                    dtDate.Focus();
                    break;
                //LL Phalaborwa
                case "selAddresses":
                    dtDate.Focus();
                    break;
                //LL end

                case "dtDate":
                    txtSalesCode.Focus();
                    break;

                case "txtSalesCode":
                    txtDiscount.Focus();
                    break;

                case "cmdSalesPerson":
                    txtDiscount.Focus();
                    break;

                case "txtDiscount":
                    dtDeliveryDate.Focus();
                    break;

                case "dtDeliveryDate":
                    txtOrderNumber.Focus();
                    break;

                case "txtOrderNumber":
                    focusNextLine(0);
                    break;
            }
        }

        private bool authorizeSalesOrder()
        {
            var authorizationView = new SalesOrderAuthorization(txtCustomerDescription.Text, txtCustomerCode.Text);
            authorizationView.ShowDialog();
            if (!authorizationView.SuccessfulAuthorization)
                return false;

            _authorizedPerson = authorizationView.AutorizedPerson.TrimEnd();
            _hasAuthorizedPersons = authorizationView.HasAuthorizedPersons;
            return true;
        }

        private void findCustomer(TextBox srcBox)
        {
            Cursor = Cursors.WaitCursor;
            using (var frmCustomerZoom = new CustomerZoom())
            {
                if (frmCustomerZoom.ShowDialog() == DialogResult.OK)
                {
                    if (frmCustomerZoom.CustomerCode != "")
                    {
                        srcBox.Text = frmCustomerZoom.CustomerCode;
                        srcBox.Focus();
                        srcBox.SelectionStart = 0;
                        srcBox.SelectionLength = srcBox.Text.Length;
                        sCustDelivCode = frmCustomerZoom.DeliveryCode;
                        loadCustomer(false, false);
                    }
                }
                Cursor = Cursors.Default;
            }
        }

        private void GetLiquidCustomerDetails()
        {
            using (var oConn = new PsqlConnection(Connect.LiquidConnectionString))
            {
                oConn.Open();
                var sSql = "Select ConsolidatedCustomer From CustomerDetail where CustomerCode = '" + txtCustomerCode.Text.Trim() + "'";
                try
                {
                    var sResult = Connect.getDataCommand(sSql, oConn).ExecuteScalar()?.ToString();
                    chkIsCustomerConsolidated.Checked = sResult != "0";
                }
                catch (Exception)
                {
                    chkIsCustomerConsolidated.Checked = false;
                }
                oConn.Dispose();
            }
        }



        private void loadCustomer(bool bAlertMessage, bool bReadOnly)
        {
            //Customer Notes
            var loadCustomerNotes = new SpecialCustomerNotes();
            var customerNotes = loadCustomerNotes.LoadCustomerNotes(txtCustomerCode.Text);
            btnCustomerNotes.Visible = customerNotes;

            var bRecord = false;
            bBlockedCustomer = false;

            if (txtCustomerCode.Text == "") return;
            var sCode = "";

            if (selAddresses.Text != "Main")
            {
                sCode = selAddresses.Text.Substring(selAddresses.Text.IndexOf("[") + 1, selAddresses.Text.Length - (selAddresses.Text.IndexOf("[") + 1)).Replace("]", "");
            }

            var oConn = new PsqlConnection(Connect.PastelConnectionString);
            oConn.Open();
            var sSql = "select Top 1 PostAddress01, PostAddress02, PostAddress03, PostAddress04, CustomerDesc, Discount, PaymentTerms, CreditLimit, ";
            sSql += "CurrBalanceThis01, CurrBalanceThis02, CurrBalanceThis03, CurrBalanceThis04, CurrBalanceThis05, CurrBalanceThis06, CurrBalanceThis07, CurrBalanceThis08, CurrBalanceThis09, CurrBalanceThis10, CurrBalanceThis11, CurrBalanceThis12, CurrBalanceThis13, ";
            sSql += "CurrBalanceLast01, IncExc, CurrBalanceLast02, CurrBalanceLast03, CurrBalanceLast04, CurrBalanceLast05, CurrBalanceLast06, CurrBalanceLast07, CurrBalanceLast08, CurrBalanceLast09, CurrBalanceLast10, CurrBalanceLast11, CurrBalanceLast12, CurrBalanceLast13, ";
            sSql += "DeliveryAddresses.*, Blocked, UserDefined05 from  CustomerMaster ";
            sSql += "inner join DeliveryAddresses on CustomerMaster.CustomerCode = DeliveryAddresses.CustomerCode ";
            sSql += "where CustomerMaster.CustomerCode = '" + txtCustomerCode.Text.Replace("'", "") + "' and  (CustDelivCode = '" + sCode + "' or CustDelivCode = '')";
            var drMessage = DialogResult.No;
            var rdReader = Connect.getDataCommand(sSql, oConn).ExecuteReader();

            while (rdReader.Read())
            {
                if (bAlertMessage)
                {
                    drMessage = MessageBox.Show("This customer record exists in the database. Do you want to load this customer data?", "Record Exist", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                }
                if (!bAlertMessage || drMessage == DialogResult.Yes)
                {
                    if (rdReader["Blocked"].ToString().Trim() == "0")
                        bRecord = true;
                    else
                        bBlockedCustomer = true;

                    txtDelAd1.Text = rdReader["DelAddress01"].ToString().Trim();
                    txtDelAd2.Text = rdReader["DelAddress02"].ToString().Trim();
                    txtDelAd3.Text = rdReader["DelAddress03"].ToString().Trim();
                    txtDelAd4.Text = rdReader["DelAddress04"].ToString().Trim();
                    txtDelAd5.Text = rdReader["DelAddress05"].ToString().Trim();
                    txtIncExc.Text = rdReader["IncExc"].ToString().Trim();

                    txtMobile.Text = rdReader["Cell"].ToString().Trim();

                    txtEmail.Text = rdReader["Email"].ToString().Trim();
                    aMainAddressList[0] = txtDelAd1.Text;
                    aMainAddressList[1] = txtDelAd2.Text;
                    aMainAddressList[2] = txtDelAd3.Text;
                    aMainAddressList[3] = txtDelAd4.Text;
                    aMainAddressList[4] = txtDelAd5.Text;
                    aMainAddressList[5] = txtContact.Text;
                    aMainAddressList[6] = txtTelephone.Text;
                    aMainAddressList[7] = txtMobile.Text;
                    aMainAddressList[8] = txtFax.Text;
                    aMainAddressList[9] = txtEmail.Text;

                    txtPosAd1.Text = rdReader["PostAddress01"].ToString().Trim();
                    txtPosAd2.Text = rdReader["PostAddress02"].ToString().Trim();
                    txtPostAd3.Text = rdReader["PostAddress03"].ToString().Trim();
                    txtPostAd4.Text = rdReader["PostAddress04"].ToString().Trim();

                    txtCustomerDescription.Text = rdReader["CustomerDesc"].ToString().Trim();
                    txtDiscount.Text = (Convert.ToDecimal(rdReader["Discount"].ToString().Trim()) / 100).ToString();
                    lblDiscountCode.Text = rdReader["UserDefined05"].ToString().Trim();

                    if (!bReadOnly)
                        if (!authorizeSalesOrder())
                        {
                            ((Main)MdiParent).LoadnewSalesOrder(this);
                            return;
                        }
                    if (bReadOnly)
                    {
                        txtPosAd1.ReadOnly = true;
                        txtPosAd2.ReadOnly = true;
                        txtPostAd3.ReadOnly = true;
                        txtPostAd4.ReadOnly = true;

                        txtCustomerDescription.ReadOnly = true;
                        txtDiscount.ReadOnly = true;
                    }

                    var sPaymentTerms = rdReader["PaymentTerms"].ToString().Trim();
                    if (sPaymentTerms == "0")
                    {
                        sPaymentTerms = "Current";
                    }
                    else
                    {
                        sPaymentTerms += " Days";
                    }
                    lblPaymentTermsValue.Text = sPaymentTerms;

                    double dCurrentBalance = 0;
                    var dCreditLimit = Convert.ToDouble(rdReader["CreditLimit"].ToString().Trim());
                    for (var iIndex = 1; iIndex <= 13; iIndex++)
                    {
                        dCurrentBalance += Convert.ToDouble(rdReader["CurrBalanceThis" + iIndex.ToString().PadLeft(2, "0".ToCharArray()[0])]);
                        dCurrentBalance += Convert.ToDouble(rdReader["CurrBalanceLast" + iIndex.ToString().PadLeft(2, "0".ToCharArray()[0])]);
                    }
                    //Check Credit Limit vs Balance if Customer should be blocked
                    if (dCurrentBalance > dCreditLimit)
                    {
                        overCreditLimtColor(Color.Red);
                        if (!bBlockedCustomer)
                        {
                            if (Global.bAutoBlockCustomer)
                            {
                                blockCustomer(txtCustomerCode.Text.Trim());
                            }
                            else if (Global.bNotifyIfcustoverCredtiLimit)
                            {
                                if (MessageBox.Show("Customer " + txtCustomerCode.Text.Trim() + " is over his credit limit. Do you want to block this customer?", "Customer Over Credit Limit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                                {
                                    blockCustomer(txtCustomerCode.Text.Trim());
                                }
                            }
                        }
                    }
                    else
                    {
                        overCreditLimtColor(bInvoiceMode ? Color.LightSteelBlue : Color.LemonChiffon);
                    }
                    lblCurrentBalanceValue.Text = "R" + dCurrentBalance.ToString("N2");
                    lblCreditLimitValue.Text = "R" + dCreditLimit.ToString("N2");
                    lblInfoCurrentBalance.Text = "R" + dCurrentBalance.ToString("N2");
                    lblInfoCreditLimit.Text = "R" + dCreditLimit.ToString("N2");
                    lblForecast.Text = "";
                    lblInfoForecastBalance.Text = "";
                    lblInfoForecast.Text = "";

                    ////// BEGIN ////////////////
                    selAddresses.Focus();

                    selAddresses.SelectedIndexChanged -= selAddresses_SelectedIndexChanged;

                    selAddresses.Items.Clear();
                    //load additional addresses
                    selAddresses.Items.Add("Main");
                    selAddresses.SelectedIndex = 0;

                    using (var repo = new CustAddressHeaderRepository(Connect.LiquidConnectionString, Connect.PastelConnectionString))
                    {
                        var custAddressHeaders = repo.GetByCustomerCode(txtCustomerCode.Text.Trim());
                        custAddressHeaders.ForEach(custAddressHeader =>
                        {
                            var sAddressLine = custAddressHeader.AddressHeader;
                            if (sAddressLine == "")
                            {
                                sAddressLine = "Main [" + custAddressHeader.CustDelivCode + "]";
                            }
                            else
                            {
                                sAddressLine += " [" + custAddressHeader.CustDelivCode + "]";
                            }
                            selAddresses.Items.Add(sAddressLine);
                        });
                    }
                    
                    if (sCustDelivCode == "\0\0\0\0\0\0\0\0\0\0 []" || sCustDelivCode == "")
                    {
                        sCustDelivCode = "Main";
                    }
                    
                    selAddresses.SelectedItem = sCustDelivCode;
                    buildCustDetail();

                    selAddresses.SelectedIndexChanged += selAddresses_SelectedIndexChanged;
                }
                else//no error message
                {
                }
                ////////////////END /////////////////////////////
            }
            if (!bRecord)//record does not exist
            {
                if (bBlockedCustomer) //Record Exists but Customer is Blocked
                {
                    MessageBox.Show("This Customer Account is blocked and cannot be used.", "Customer Blocked", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    disableButtons();
                }
                else
                {
                    MessageBox.Show("This customer record does not exists in the database.", "No Such Record Exist", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    clearCustomer();//no on alert message
                }
            }
            rdReader.Close();
            oConn.Dispose();

            // Deposit Balance
            try
            {
            var oLiqConn = new PsqlConnection(Connect.LiquidConnectionString);
            oLiqConn.Open();
                var sql = "SELECT DepositAccountCode FROM CustomerDetail WHERE CustomerCode = '" + txtCustomerCode.Text + "'";
                var depositAccountReader = Connect.getDataCommand(sql, oLiqConn).ExecuteScalar()?.ToString();
            oLiqConn.Dispose();

            var oDepConn = new PsqlConnection(Connect.PastelConnectionString);
            oDepConn.Open();
            var depSql = "SELECT Top 1 CurrBalanceThis01, CurrBalanceThis02, CurrBalanceThis03, CurrBalanceThis04, CurrBalanceThis05, CurrBalanceThis06, CurrBalanceThis07, CurrBalanceThis08, CurrBalanceThis09, CurrBalanceThis10, CurrBalanceThis11, CurrBalanceThis12, CurrBalanceThis13, ";
                depSql += "CurrBalanceLast01, IncExc, CurrBalanceLast02, CurrBalanceLast03, CurrBalanceLast04, CurrBalanceLast05, CurrBalanceLast06, CurrBalanceLast07, CurrBalanceLast08, CurrBalanceLast09, CurrBalanceLast10, CurrBalanceLast11, CurrBalanceLast12, CurrBalanceLast13 ";
                depSql += "FROM CustomerMaster WHERE CustomerCode = '" + depositAccountReader?.Replace("'", "") + "'";
            var depositReader = Connect.getDataCommand(depSql, oDepConn).ExecuteReader();
                while (depositReader.Read())
                {
                    double dCurrentDeposit = 0;
                    for (var iIndex = 1; iIndex <= 13; iIndex++)
                    {
                        dCurrentDeposit +=
                            Convert.ToDouble(
                                depositReader["CurrBalanceThis" + iIndex.ToString().PadLeft(2, "0".ToCharArray()[0])]);
                        dCurrentDeposit +=
                            Convert.ToDouble(
                                depositReader["CurrBalanceLast" + iIndex.ToString().PadLeft(2, "0".ToCharArray()[0])]);
                    }
                    lblDepositBalance.Text = "R" + dCurrentDeposit.ToString("N2");
                }

                oDepConn.Dispose();
            }
            catch (Exception)
            {
                lblDepositBalance.Text = "-";
            }
            //

            GetMarketingDetails();
            GetLiquidCustomerDetails();
        }

        private void GetMarketingDetails()
        {
            if (Global.sInvoiceTemplate != "Kings Hire") return;
            try
            {
                //get all marketing details.
                //get commission tipes:
                selCommissionTipe.Items.Clear();
                txtMarketer.Text = "";
                txtCategory.Text = "";
                txtCommissionFloor.Text = "";
                if (txtNumber.Text == "*NEW*") //new sales order
                {
                    using (var oConnLiq = new PsqlConnection(Connect.LiquidConnectionString))
                    {
                        oConnLiq.Open();
                        var sCTSql = "Select * From SOLMARKCOMTIPE";
                        var rdReaderCT = Connect.getDataCommand(sCTSql, oConnLiq).ExecuteReader();
                        while (rdReaderCT.Read())
                        {
                            selCommissionTipe.Items.Add(rdReaderCT[0].ToString());
                        }
                        rdReaderCT.Dispose();

                        var bUseSite = false;

                        //customer use site marketing details?
                        var sSql = "Select UseSite From SOLMARKCUSTDET where CustomerCode = '" + txtCustomerCode.Text.Trim() + "' AND SiteName = 'MAIN'";
                        var rdReader = Connect.getDataCommand(sSql, oConnLiq).ExecuteReader();
                        while (rdReader.Read())
                        {
                            bUseSite = rdReader[0].ToString() == "1";
                        }
                        rdReader.Close();

                        if (!bUseSite)
                        {
                            //get marketer of site/customer
                            var sMDSql = "Select Marketer,MarketingCategory,CommissionFloor From SOLMARKCUSTDET where CustomerCode = '" + txtCustomerCode.Text.Trim() + "' AND SiteName = 'MAIN'";
                            var rdReaderMarkDet = Connect.getDataCommand(sMDSql, oConnLiq).ExecuteReader();
                            while (rdReaderMarkDet.Read())
                            {
                                chkLinkMarketer.Checked = true;
                                txtMarketer.Text = rdReaderMarkDet[0].ToString();
                                txtCategory.Text = rdReaderMarkDet[1].ToString();
                                txtCommissionFloor.Text = rdReaderMarkDet[2].ToString();
                            }
                            rdReaderMarkDet.Close();
                            oConnLiq.Dispose();
                        }
                        else
                        {
                            //get marketer of site/customer
                            var sMDSql = "Select Marketer,MarketingCategory,CommissionFloor From SOLMARKCUSTDET where CustomerCode = '" + txtCustomerCode.Text.Trim() + "' AND SiteName = '" + selAddresses.Text.Trim() + "'";
                            var rdReaderMarkDet = Connect.getDataCommand(sMDSql, oConnLiq).ExecuteReader();
                            while (rdReaderMarkDet.Read())
                            {
                                chkLinkMarketer.Checked = true;
                                txtMarketer.Text = rdReaderMarkDet[0].ToString();
                                txtCategory.Text = rdReaderMarkDet[1].ToString();
                                txtCommissionFloor.Text = rdReaderMarkDet[2].ToString();
                            }
                            rdReaderMarkDet.Close();
                            oConnLiq.Dispose();
                        }
                    }
                }
                else
                {
                    using (var oConnLiq = new PsqlConnection(Connect.LiquidConnectionString))
                    {
                        var sGetDetails = "Select  Marketer, MarketingCategory, CommissionType, SiteName From SOLHH where DocNumber = '" + txtNumber.Text.Trim() + "'";
                        using (var rdReader = Connect.getDataCommand(sGetDetails, oConnLiq).ExecuteReader())
                        {
                            while (rdReader.Read())
                            {
                                if (rdReader[0].ToString() != "") //marketer linked to doc ?
                                {
                                    chkLinkMarketer.Checked = true;
                                    txtMarketer.Text = rdReader[0].ToString();
                                    txtCategory.Text = rdReader[1].ToString();
                                    selCommissionTipe.Text = rdReader[2].ToString();
                                    if (selCommissionTipe.Text.Trim() == "Full")
                                        selCommissionTipe.Text = "";
                                    var sSiteName = rdReader[3].ToString();
                                    selAddresses.Text = sSiteName;

                                    var bUseSite = false;
                                    //customer use site marketing details?
                                    var sSql = "Select UseSite From SOLMARKCUSTDET where CustomerCode = '" + txtCustomerCode.Text.Trim() + "' AND SiteName = 'MAIN'";
                                    var rdReader2 = Connect.getDataCommand(sSql, oConnLiq).ExecuteReader();
                                    while (rdReader2.Read())
                                    {
                                        bUseSite = rdReader2[0].ToString() == "1";
                                    }
                                    rdReader2.Close();

                                    if (!bUseSite)
                                    {
                                        var sMDSql = "Select CommissionFloor From SOLMARKCUSTDET where CustomerCode = '" + txtCustomerCode.Text.Trim() + "' AND SiteName = 'MAIN'";
                                        var rdReaderMarkDet = Connect.getDataCommand(sMDSql, oConnLiq).ExecuteReader();
                                        while (rdReaderMarkDet.Read())
                                        {
                                            txtCommissionFloor.Text = rdReaderMarkDet[0].ToString();
                                        }
                                        rdReaderMarkDet.Close();
                                    }
                                    else
                                    {
                                        var sMDSql = "Select CommissionFloor From SOLMARKCUSTDET where CustomerCode = '" + txtCustomerCode.Text.Trim() + "' AND SiteName = '" + sSiteName.Trim() + "'";
                                        var rdReaderMarkDet = Connect.getDataCommand(sMDSql, oConnLiq).ExecuteReader();
                                        while (rdReaderMarkDet.Read())
                                        {
                                            txtCommissionFloor.Text = rdReaderMarkDet[0].ToString();
                                        }
                                        rdReaderMarkDet.Close();
                                    }
                                }
                                else
                                {
                                    var sCTSql = "Select * From SOLMARKCOMTIPE";
                                    var rdReaderCT = Connect.getDataCommand(sCTSql, oConnLiq).ExecuteReader();
                                    while (rdReaderCT.Read())
                                    {
                                        selCommissionTipe.Items.Add(rdReaderCT[0].ToString());
                                    }
                                    rdReaderCT.Dispose();
                                }
                            }

                            rdReader.Close();
                        }
                        oConnLiq.Dispose();
                    }
                }
            }
            catch
            {
            }
        }

        private void overCreditLimtColor(Color sColor)
        {
            tpShip.BackColor = sColor;
            tpPostal.BackColor = sColor;
            tpForecast.BackColor = sColor;
            txtPosAd1.BackColor = sColor;
            txtPosAd2.BackColor = sColor;
            txtPosAd3.BackColor = sColor;
            txtPosAd4.BackColor = sColor;
            pnlSalesOrderStatus.BackColor = sColor;
        }

        private void blockCustomer(string sCustomerCode)
        {
            using (var oConnBlock = new PsqlConnection(Connect.PastelConnectionString))
            {
                oConnBlock.Open();
                var sSql = "update CustomerMaster set blocked = '1' where CustomerCode = '" + sCustomerCode + "'";
                var iReturn = Connect.getDataCommand(sSql, oConnBlock).ExecuteNonQuery();
                if (iReturn > 0)
                {
                    MessageBox.Show("Customer account is successfully blocked");
                    disableButtons();
                }
                oConnBlock.Dispose();
            }
        }

        private void clearCustomer()
        {
            txtDelAd1.Text = "";
            txtDelAd2.Text = "";
            txtDelAd3.Text = "";
            txtDelAd4.Text = "";
            txtPosAd1.Text = "";
            txtPosAd2.Text = "";
            txtPostAd3.Text = "";
            txtPostAd4.Text = "";
            txtContact.Text = "";
            txtTelephone.Text = "";
            txtFax.Text = "";
            txtMobile.Text = "";
            txtEmail.Text = "";
            txtCustomerDescription.Text = "";
            txtDiscount.Text = "";
        }

        private void disableButtons()
        {
            cmdSaveOrder.Enabled = false;
            cmdCloseOrder.Enabled = false;
            cmdInvoice.Enabled = false;
            cmdNewLine.Enabled = false;
            cmdViewMonthEnd.Enabled = false;
            cmdRePrintDelNote.Enabled = false;
        }

        private void cmdSearchCustomer_Click(object sender, EventArgs e)
        {
            TextBox srcBox = null;
            switch (((Button)sender).Name)
            {
                case "cmdSearchCustomer":
                    srcBox = txtCustomerCode;
                    break;
            }

            findCustomer(srcBox);
        }

        private HistoryHeader getHistoryHeaderFromForm()
        {
            return new HistoryHeader
            {
                DocType = 2,
                Type = radStandingOrder.Checked ? 1 : radFutureOrder.Checked ? 2 : 0,
                DepositType = "",
                DepositAmount = 0,
                CustomerCode = txtCustomerCode.Text,
                Status = 1,
                DocDate = dtDate.Value,
                Saturdays = chkSaturday.Checked,
                Sundays = chkSundays.Checked,
                Coordinates = txtCoordinates.Text.Replace("'", "|"),
                AdvPaymentAmount = 0,
                Collected = chkCollected.Checked,
                LockedStatus = bLockedStatus,
                SiteName = selAddresses.Text.Trim(),
                ContractExpiryDate = chkContract.Checked ? dtContractDate.Value : (DateTime?)null,
                Marketer = txtMarketer.Text.Trim().Replace("'", "''"),
                MarketingCategory = txtCategory.Text.Trim().Replace("'", "''"),
                CommissionType = selCommissionTipe.Text != "" ? selCommissionTipe.Text.Trim().Replace("'", "''") : "FULL",
                SalesOrderType = chkSalesOrderType.Checked ? 1 : 0,
                ConsolidateNumber = txtConsolidateNr.Text,
                OffHireEndDate = null,
                OffHireStartDate = null,
                AuthorizedPerson = "",
                CheckedBy = "",
                IsSpecial = false,
                ExcludeHoliday = chkPublicHolidays.Checked,
                AuditDate = null,
                LeaseLevyPercentage = Convert.ToDecimal(txtLevyPercentage.Text == "" ? "0" : txtLevyPercentage.Text)
            };
        }

        private double getInclusivePrice(string taxType, string exclusivePrice)
        {
            //0 rate
            if(taxType == "0" || taxType == "3")
            {
                return Convert.ToDouble(exclusivePrice.Replace(",", ""));
            }
            //14% rate
            if (taxType == "1" || taxType == "2")
            {
                return Convert.ToDouble(exclusivePrice.Replace(",", "")) * 1.14;
            }
            //100% rate
            if (taxType == "4")
            {
                return Convert.ToDouble(exclusivePrice.Replace(",", "")) * 2;
            }
            //15% rate
            if (taxType == "5" || taxType == "6")
            {
                return Convert.ToDouble(exclusivePrice.Replace(",", "")) * 1.15;
            }

            throw new NotImplementedException($"Invalid Tax Type {taxType}");
        }

        private PastelSalesLine getPastelSalesLineFromLineForm(SalesLineForm lineForm)
        {
            if (lineForm.txtCode.Text == "'")
            {
                return new PastelSalesLine
                {
                    Discription = lineForm.txtDescription.Text.Trim(),
                    LyneType = 7
                };
            }
            else if (lineForm.txtCode.Text != "")
            {
                return new PastelSalesLine
                {
                    LineQuantity = Convert.ToDecimal(lineForm.txtMultiplier.Text.Replace(",", "").Trim()) * Convert.ToDecimal(lineForm.txtQuantity.Text.Replace(",", "").Trim()),
                    ExlusivePricePerUnit = Convert.ToDecimal(lineForm.txtExcPrice.Text.Replace(",", "").Trim()),
                    InclusivePricePerUnit = getInclusivePrice(lineForm.txtTaxType.Text, lineForm.txtExcPrice.Text),
                    Unit = lineForm.txtUnit.Text.Trim(),
                    TaxType = int.Parse(lineForm.txtTaxType.Text.PadLeft(2, "0".ToCharArray()[0])),
                    DiscountType = 0,
                    DiscountPercentage = Convert.ToDecimal(lineForm.txtDiscount.Text.Replace(".", "").Replace(",", "")),
                    Code = lineForm.txtCode.Text.Trim(),
                    Discription = lineForm.txtDescription.Text.Trim(),
                    LyneType = 4,
                    MultiStore = lineForm.txtStore.Text.Trim(),
                    CostCode = lineForm.txtProject.Text.Trim()
                };
            }

            return null;
        }

        private PastelHistoryHeader getPastelHistoryHeader()
        {
            var pastelHistoryHeader = new PastelHistoryHeader
            {
                Deleted = false,
                PrintStatus = true,
                CustomerCode = txtCustomerCode.Text,
                Date = dtDate.Value,
                OrderNumber = txtOrderNumber.Text,
                InclusiveExclusive = true,
                Discount = decimal.Parse(txtDiscount.Text),
                InvoiceMessage1 = txtMessage1.Text,
                InvoiceMessage2 = txtMessage2.Text,
                InvoiceMessage3 = txtMessage3.Text,
                DeliveryAddress1 = txtDelAd1.Text,
                DeliveryAddress2 = txtDelAd2.Text,
                DeliveryAddress3 = txtDelAd3.Text,
                DeliveryAddress4 = txtDelAd4.Text,
                DeliveryAddress5 = txtDelAd5.Text,
                SalesCode = txtSalesCode.Text,
                SettlementTermCode = "00",
                JobCode = "",
                ClosingDate = dtDeliveryDate.Value,
                Telephone = txtTelephone.Text,
                Contact = txtContact.Text,
                Fax = txtFax.Text,
                ExchangeRate = 0,
                Discription = "",
                ExemptRef = "",
                PostalAddress1 = txtPosAd1.Text,
                PostalAddress2 = txtPosAd2.Text,
                PostalAddress3 = txtPosAd3.Text,
                PostalAddress4 = txtPosAd4.Text,
                PostalAddress5 = "",
                Ship = "",
                Freight = txtNumber.Text,
                OnHold = false
            };

            return pastelHistoryHeader;
        }

        private List<PastelSalesLine> getPastelSalesLines()
        {
            var pastelSalesLines = new List<PastelSalesLine>();

            Saleslines.ToList().ForEach(line =>
            {
                var lineForm = (SalesLineForm)line;
                if (lineForm.txtCode.Text == "")//Empty Line
                {
                    deleteSalesLine(lineForm, true);
                }

                var salesLine = getPastelSalesLineFromLineForm(lineForm);
                if (salesLine != null)
                {
                    pastelSalesLines.Add(salesLine);
                }
            });

            return pastelSalesLines;
        }

        private List<SalesLine> getLiquidSalesLines()
        {
            var liquidSalesLines = Saleslines.ToList().Select(line =>
            {
                var lineForm = (SalesLineForm)line;
                lineForm.dMaxMultiplierValue = Convert.ToDecimal(lineForm.txtMultiplier.Text);
                lineForm.sLineType = Functions.getLineInventoryType(lineForm.txtCode.Text);
                return getLiquidSalesLineFromForm(lineForm);
            }).ToList();

            return liquidSalesLines;
        }

        private SalesLine getLiquidSalesLineFromForm(SalesLineForm lineForm)
        {
            
            DateTime? deliveryDate, returnDate;
            var sStatus = lineForm.txtStatus.Text;
            if (sStatus == "")
            {
                sStatus = "0";
            }
            if (lineForm.dtReturnDate.Visible == false)//not a lease item
            {
                deliveryDate = null;
                returnDate = null;
            }
            else
            {
                var dtNow = DateTime.Now;
                if (dtNow.Day != lineForm.dtDelivery.Value.Day)
                {
                    deliveryDate = lineForm.dtDelivery.Value.AddHours(-(lineForm.dtDelivery.Value.Hour-8)).AddMinutes(-lineForm.dtDelivery.Value.Minute);
                }
                else
                {
                    deliveryDate = lineForm.dtDelivery.Value;
                }
                if (dtNow.Day != lineForm.dtReturnDate.Value.Day)
                {
                    returnDate = lineForm.dtReturnDate.Value;
                }
                else
                {
                    returnDate = lineForm.dtReturnDate.Value.AddHours(-(lineForm.dtDelivery.Value.Hour - 8)).AddMinutes(-lineForm.dtDelivery.Value.Minute);
                }
            }

            var returnLine = new SalesLine
            {
                DeliveryDate = deliveryDate,
                ReturnDate = returnDate,
                Status = int.Parse(sStatus),
                Multiplier = decimal.Parse(lineForm.txtMultiplier.Text.Replace(",", "").Trim()),
                Quantity = decimal.Parse(lineForm.txtQuantity.Text.Replace(",", "").Trim()),
                OrigDeliveryDate = deliveryDate,
                CalculationRule = lineForm.txtUnitFormula.Text
            };
            if (lineForm.bInsertInMiddle)
            {
                returnLine.LinkNum = Int16.Parse(lineForm.sPastelLineLink);
                lineForm.sPastelLineLink = (lineForm.sPastelLineLink);
                if (lineForm.txtCode.Text != "" && lineForm.txtCode.Text != "'")
                {
                    returnLine.ItemCode = lineForm.txtCode.Text;
                    returnLine.Description = lineForm.txtDescription.Text.Replace("'", "''");                    
                }
                else if (lineForm.txtCode.Text != "")
                {
                    returnLine.ItemCode = "C";
                    returnLine.Description = lineForm.txtDescription.Text;
                }
            }
            else
            {
                returnLine.LinkNum = lineForm.iLineIndex + 1;
                lineForm.sPastelLineLink = (lineForm.iLineIndex + 1).ToString();
                if (lineForm.txtCode.Text != "" && lineForm.txtCode.Text != "'")
                {
                    returnLine.ItemCode = lineForm.txtCode.Text;
                    returnLine.Description = lineForm.txtDescription.Text.Replace("'", "''");                    
                }
                else if (lineForm.txtCode.Text != "")
                {
                    returnLine.ItemCode = "C";
                    returnLine.Description = lineForm.txtDescription.Text;
                }                
            }
            return returnLine;
        }

        private void insertSolHistoryLine(SalesLineForm slThisLineForm, PsqlConnection oConn, string sHeaderDocumentNumber)
        {
            string sDelivery, sReturn, sSql;
            if (slThisLineForm.dtReturnDate.Visible && slThisLineForm.txtCode.Text != "" && slThisLineForm.txtQuantity.Text != "0")//line defined by Code and must be a lease item
            {
            }
            var sStatus = slThisLineForm.txtStatus.Text;
            if (sStatus == "")
            {
                sStatus = "0";
            }
            if (slThisLineForm.dtReturnDate.Visible == false)//not a lease item
            {
                sDelivery = "null";
                sReturn = "null";
            }
            else
            {
                var dtNow = DateTime.Now;
                if (dtNow.Day != slThisLineForm.dtDelivery.Value.Day)
                {
                    sDelivery = "'" + slThisLineForm.dtDelivery.Value.ToString("dd-MM-yyyy 08:00") + "'";
                }
                else
                {
                    sDelivery = "'" + slThisLineForm.dtDelivery.Value.ToString("dd-MM-yyyy HH:mm") + "'";
                }
                if (dtNow.Day != slThisLineForm.dtReturnDate.Value.Day)
                {
                    sReturn = "'" + slThisLineForm.dtReturnDate.Value.ToString("dd-MM-yyyy HH:mm") + "'";
                }
                else
                {
                    sReturn = "'" + slThisLineForm.dtReturnDate.Value.ToString("dd-MM-yyyy 08:00") + "'";
                }
            }
            if (slThisLineForm.bInsertInMiddle)
            {
                if (slThisLineForm.txtCode.Text != "" && slThisLineForm.txtCode.Text != "'")
                {
                    sSql = "INSERT into SOLHL";
                    sSql += " (Header, ItemCode, DeliveryDate, ReturnDate, Status,LinkNum, Multiplier, Qty, OrigDeliveryDate,sCalculationRule, Description) ";
                    sSql += " VALUES ";
                    sSql += "(";
                    sSql += "'" + sHeaderDocumentNumber.Trim() + "'";
                    sSql += ",'" + slThisLineForm.txtCode.Text + "'";
                    sSql += "," + sDelivery;
                    sSql += "," + sReturn;
                    sSql += "," + sStatus;
                    sSql += "," + (Convert.ToInt16(slThisLineForm.sPastelLineLink));
                    sSql += "," + slThisLineForm.txtMultiplier.Text.Replace(",", "").Trim();
                    sSql += "," + slThisLineForm.txtQuantity.Text.Replace(",", "").Trim();
                    sSql += "," + sDelivery;
                    sSql += ",'" + slThisLineForm.txtUnitFormula.Text + "'";
                    sSql += ",'" + slThisLineForm.txtDescription.Text.Replace("'", "''") + "'";
                    sSql += ")";
                    Connect.getDataCommand(sSql, oConn).ExecuteNonQuery();
                    slThisLineForm.sPastelLineLink = (slThisLineForm.sPastelLineLink);
                }
                else if (slThisLineForm.txtCode.Text != "")
                {
                    sSql = "INSERT into SOLHL";
                    sSql += " (Header, ItemCode, DeliveryDate, ReturnDate, Status,LinkNum, Multiplier, Qty, OrigDeliveryDate,sCalculationRule, Description) ";
                    sSql += " VALUES ";
                    sSql += "(";
                    sSql += "'" + sHeaderDocumentNumber.Trim() + "'";
                    sSql += ",'C'";
                    sSql += "," + sDelivery;
                    sSql += "," + sReturn;
                    sSql += "," + sStatus;
                    sSql += "," + (Convert.ToInt16(slThisLineForm.sPastelLineLink));
                    sSql += "," + slThisLineForm.txtMultiplier.Text.Replace(",", "").Trim();
                    sSql += "," + slThisLineForm.txtQuantity.Text.Replace(",", "").Trim();
                    sSql += "," + sDelivery;
                    sSql += ",'" + slThisLineForm.txtUnitFormula.Text + "'";
                    sSql += ",'" + slThisLineForm.txtDescription.Text + "'";
                    sSql += ")";
                    Connect.getDataCommand(sSql, oConn).ExecuteNonQuery();
                    slThisLineForm.sPastelLineLink = (slThisLineForm.sPastelLineLink);
                }
            }
            else
            {
                if (slThisLineForm.txtCode.Text != "" && slThisLineForm.txtCode.Text != "'")
                {
                    sSql = "INSERT into SOLHL";
                    sSql += " (Header, ItemCode, DeliveryDate, ReturnDate, Status,LinkNum, Multiplier, Qty, OrigDeliveryDate,sCalculationRule, Description) ";
                    sSql += " VALUES ";
                    sSql += "(";
                    sSql += "'" + sHeaderDocumentNumber.Trim() + "'";
                    sSql += ",'" + slThisLineForm.txtCode.Text + "'";
                    sSql += "," + sDelivery;
                    sSql += "," + sReturn;
                    sSql += "," + sStatus;
                    sSql += "," + (slThisLineForm.iLineIndex + 1);
                    sSql += "," + slThisLineForm.txtMultiplier.Text.Replace(",", "").Trim();
                    sSql += "," + slThisLineForm.txtQuantity.Text.Replace(",", "").Trim();
                    sSql += "," + sDelivery;
                    sSql += ",'" + slThisLineForm.txtUnitFormula.Text + "'";
                    sSql += ",'" + slThisLineForm.txtDescription.Text.Replace("'", "''") + "'";
                    sSql += ")";
                    Connect.getDataCommand(sSql, oConn).ExecuteNonQuery();
                    slThisLineForm.sPastelLineLink = (slThisLineForm.iLineIndex + 1).ToString();
                }
                else if (slThisLineForm.txtCode.Text != "")
                {
                    sSql = "INSERT into SOLHL";
                    sSql += " (Header, ItemCode, DeliveryDate, ReturnDate, Status,LinkNum, Multiplier, Qty, OrigDeliveryDate,sCalculationRule, Description) ";
                    sSql += " VALUES ";
                    sSql += "(";
                    sSql += "'" + sHeaderDocumentNumber.Trim() + "'";
                    sSql += ",'C'";
                    sSql += "," + sDelivery;
                    sSql += "," + sReturn;
                    sSql += "," + sStatus;
                    sSql += "," + (slThisLineForm.iLineIndex + 1);
                    sSql += "," + slThisLineForm.txtMultiplier.Text.Replace(",", "").Trim();
                    sSql += "," + slThisLineForm.txtQuantity.Text.Replace(",", "").Trim();
                    sSql += "," + sDelivery;
                    sSql += ",'" + slThisLineForm.txtUnitFormula.Text + "'";
                    sSql += ",'" + slThisLineForm.txtDescription.Text + "'";
                    sSql += ")";
                    Connect.getDataCommand(sSql, oConn).ExecuteNonQuery();
                    slThisLineForm.sPastelLineLink = (slThisLineForm.iLineIndex + 1).ToString();
                }
            }
        }

        private void startProcess()
        {
            var pastelHistoryHeader = getPastelHistoryHeader();
            var pastelSalesLines = getPastelSalesLines();
            var liquidHistoryHeader = getHistoryHeaderFromForm();
            var liquidSalesLines = getLiquidSalesLines();
            var salesOrderProcessService = new SalesOrderProcess(Connect.LiquidConnectionString, Connect.PastelConnectionString, Global.sDataPath, Global.iPastelSdkUser, Global.bLogCreateDocument, new Generate());
            string sDocNumber;
            try
            {
                sDocNumber = salesOrderProcessService.StartMultiple(Global.bUserMaxNewNumber, pastelHistoryHeader, pastelSalesLines, liquidHistoryHeader, liquidSalesLines, chkPrintOnSave.Checked
                    , Global.sDeliveryNoteTemplate, printDialog1, (int) numRepeatAmount.Value + 1, Global.sLogedInUserName, _authorizedPerson.TrimEnd(), _hasAuthorizedPersons);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                Cursor = Cursors.Default;
                return;
            }

            txtNumber.Text = sDocNumber.Trim();
            makeReadOnly(true);
            cmdNewLine.Visible = true;
            bSaved = true;
            setSalesOrderStatus(1);//set status to saved
        }

        private void printSalesOrder()
        {
            var sPrintCollected = chkCollected.Checked ? "COLLECTED" : "DELIVERED";
            if (chkPrintOnSave.Checked)
            {
                if (Global.sDeliveryNoteTemplate == "Kings Hire")
                {
                    Generate.PrintDeliveryNote(txtNumber.Text, "", "", txtCoordinates.Text, sPrintCollected, true, false, printDialog1, null);
                }
                else
                {
                    var pdPrint = new PrintDialog();
                    Generate.PrintDeliveryNote(txtNumber.Text, "", "", txtCoordinates.Text, sPrintCollected, true, false, pdPrint, null);
                }
            }                        
        }

        private void SaveNewSalesOrder()
        {
            #region New Document
            if (txtNumber.Text.Trim().ToUpper() == "*NEW*" || txtNumber.Text.Trim().ToUpper() == "*NEW*")//Save new sales order
            {
                if (MessageBox.Show("This will save the sales order  and reserve all lease items in this document. Are you sure this document is complete?", "Are you sure", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    startProcess();
                }//end messagebox if
                else
                {
                    Cursor = Cursors.Default;
                    return; //click no to save
                }
            }//end New Item
            else
            {
                printSalesOrder();
            }

            cmdSaveOrder.Enabled = false;
            cmdRePrintDelNote.Visible = true;            
            Cursor = Cursors.Default;
            #endregion New Document
        }

        private void setAuthorizationOnSalesOrder(string documentNumber, PsqlConnection connection)
        {
            if (!_hasAuthorizedPersons)
                return;

            var authorizationSql =
                string.Format("UPDATE SOLHH SET CheckedBy = '{0}',AuthorizedPerson = '{1}' WHERE DocNumber = '{2}'",
                    Global.sLogedInUserName, _authorizedPerson.TrimEnd(), documentNumber);
            Connect.getDataCommand(authorizationSql, connection).ExecuteNonQuery();
        }

        private void UpdateSalesOrder()
        {
            #region Update Order

            //Update Sales Order

            using (var oPasConn = new PsqlConnection(Connect.PastelConnectionString))
            {
                oPasConn.Open();
                using (var oConn = new PsqlConnection(Connect.LiquidConnectionString))
                {
                    string sSql;
                    for (var iRow = 0; iRow < aUpdate.GetLength(0); iRow++)
                    {
                        switch (aUpdate[iRow, 1].ToString())
                        {
                            case "0": // update line delivery date
                                if (aUpdate[iRow, 0].ToString() != "'")
                                {
                                    sSql = "UPDATE SOLHL set DeliveryDate = '" + aUpdate[iRow, 2] + "', OrigDeliveryDate = '" + aUpdate[iRow, 2] + "' ";
                                    sSql += " , Multiplier = " + Convert.ToDecimal(aUpdate[iRow, 3].ToString());
                                    if (aUpdate[iRow, 3].ToString() != "InvoiceLine")
                                        sSql += " , Qty = " + aUpdate[iRow, 4];
                                    sSql += " where Header = '" + txtNumber.Text + "' and ItemCode = '" + aUpdate[iRow, 0] + "'";
                                    Connect.getDataCommand(sSql, oConn).ExecuteNonQuery();
                                    bSaved = true;
                                }
                                break;

                            case "1": //update new line
                                var sLine = getPastelLine((SalesLineForm)aUpdate[iRow, 2]);
                                insertSolHistoryLine((SalesLineForm)aUpdate[iRow, 2], oConn, txtNumber.Text);

                                if (sLine.Trim() != "")
                                {
                                    clsSDK.EditPastelDocument(sLine, 102, txtNumber.Text, "I", Global.sDataPath);
                                    ((SalesLineForm)aUpdate[iRow, 2]).bEdited = false;
                                }
                                ((SalesLineForm)aUpdate[iRow, 2]).makeLineReadOnly();
                                ((SalesLineForm)aUpdate[iRow, 2]).dMaxMultiplierValue = Convert.ToDecimal((((SalesLineForm)aUpdate[iRow, 2]).txtMultiplier.Text));
                                ((SalesLineForm)aUpdate[iRow, 2]).sLineType = Functions.getLineInventoryType(((SalesLineForm)aUpdate[iRow, 2]).txtCode.Text);
                                bSaved = true;
                                break;
                        }
                    }
                    //clear previous data
                    var delSql = "delete From SOLHL where Header = '" + txtNumber.Text.Trim() + "'";
                    Connect.getDataCommand(delSql, oConn).ExecuteNonQuery();

                    for (var iLn = 0; iLn < Saleslines.Length; iLn++)
                    {
                        var slThisLine = (SalesLineForm)Saleslines[iLn];
                        if (slThisLine.bEdited)
                        {
                            sSql = "update HistoryLines set Description = '" + slThisLine.txtDescription.Text.Trim().Replace("'", "''");
                            sSql += "', CostCode = '" + slThisLine.txtProject.Text.Trim(); 
                            sSql += "' where DocumentNumber = '" + txtNumber.Text.Trim() + "' AND linkNum = '" + slThisLine.sPastelLineLink + "'";
                            sSql += " AND ItemCode = '" + slThisLine.txtCode.Text.Trim().Replace("'", "''") + "'";
                            Connect.getDataCommand(sSql, oPasConn).ExecuteNonQuery();
                        }
                        //insert updated data in SOLHL
                        insertSolHistoryLine(slThisLine, oConn, txtNumber.Text);
                    }
                    try
                    {
                        //SYNC historylines met solhl
                        var synqSql = "Select * From SOLHL where Header = '" + txtNumber.Text.Trim() + "' order by linknum";
                        var rdReader = Connect.getDataCommand(synqSql, oConn).ExecuteReader();
                        while (rdReader.Read())
                        {
                            if (rdReader["ItemCode"].ToString().Trim() == "C")
                            {
                                sSql = "update HistoryLines set LinkNum = '" + rdReader["linknum"] + "'";
                                sSql += " where DocumentNumber = '" + txtNumber.Text.Trim() + "' and DocumentType = '102' ";
                                sSql += "and Description = '" + rdReader["Description"] + "' AND ItemCode = ''''";
                                Connect.getDataCommand(sSql, oPasConn).ExecuteNonQuery();
                            }
                            else
                            {
                                sSql = "update HistoryLines set LinkNum = '" + rdReader["linknum"] + "'";
                                sSql += " where DocumentNumber = '" + txtNumber.Text.Trim() + "' and DocumentType = '102' ";
                                sSql += "and Description = '" + rdReader["Description"] + "' AND ItemCode = '" + rdReader["ItemCode"].ToString().Trim() + "'";
                                Connect.getDataCommand(sSql, oPasConn).ExecuteNonQuery();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error synching Database :" + ex);
                    }

                    var sSaturday = "";
                    var sSunday = "";

                    if (chkSaturday.Checked)
                    {
                        sSaturday = "1";
                    }
                    if (chkSundays.Checked)
                    {
                        sSunday = "1";
                    }

                    var levyPerc = txtLevyPercentage.Text == "" ? "0" : txtLevyPercentage.Text;
                    iSalesOrderType = chkSalesOrderType.Checked ? 1 : 0;
                    aUpdate = new object[0, 5];
                    sSql = "Update SOLHH set  Coordinates = '" + txtCoordinates.Text.Replace("'", "|") + "', LockedStatus = '" + (bLockedStatus ? 1 : 0) + "'";
                    if (chkContract.Checked)
                        sSql += " , Contract = '" + Convert.ToDateTime(dtContractDate.Value).ToString("MM/dd/yyyy") + "' ";
                    else
                        sSql += " , Contract = '' ";
                    sSql += ", Marketer = '" + txtMarketer.Text.Trim().Replace("'", "''") + "'";
                    sSql += ", MarketingCategory = '" + txtCategory.Text.Trim().Replace("'", "''") + "'";
                    sSql += ", CommissionType = '" + selCommissionTipe.Text.Trim().Replace("'", "''") + "'";
                    sSql += ", SalesOrderType = '" + iSalesOrderType + "'";
                    sSql += ", ConsolidateNumber = '" + txtConsolidateNr.Text.Trim() + "'";
                    sSql += ", Saturdays = '" + sSaturday + "'";
                    sSql += ", Sundays = '" + sSunday + "'";
                    sSql += ", Excludeholiday = '" + (chkPublicHolidays.Checked ? "1" : "0") + "'";
                    sSql += $", LeaseLevyPerc = {levyPerc} ";
                    sSql += " where DocNumber = '" + txtNumber.Text.Trim() + "'";
                    Connect.getDataCommand(sSql, oConn).ExecuteNonQuery();

                    sSql = "Update HistoryHeader set OrderNumber = '" + txtOrderNumber.Text.Trim() + "', ";
                    sSql += " DelAddress01 = '" + txtDelAd1.Text.Trim().Replace("'", "''") + "',";
                    sSql += " DelAddress02 = '" + txtDelAd2.Text.Trim().Replace("'", "''") + "',";
                    sSql += " DelAddress03 = '" + txtDelAd3.Text.Trim().Replace("'", "''") + "',";
                    sSql += " DelAddress04 = '" + txtDelAd4.Text.Trim().Replace("'", "''") + "',";
                    sSql += " DelAddress05 = '" + txtDelAd5.Text.Trim().Replace("'", "''") + "',";
                    sSql += " Telephone = '" + txtTelephone.Text.Trim() + "',";
                    sSql += " Fax = '" + txtFax.Text.Trim() + "',";
                    sSql += " Contact = '" + txtContact.Text.Trim().Replace("'", "") + "' ";
                    sSql += "where DocumentNumber = '" + txtNumber.Text.Trim() + "' ";
                    Connect.getDataCommand(sSql, oPasConn).ExecuteNonQuery();

                    cmdSaveOrder.Enabled = false;
                    Cursor = Cursors.Default;
                    oConn.Dispose();
                }
                oPasConn.Dispose();
            }

            #endregion Update Order
        }

        private bool SalesOrderValidation()
        {
            var bValidated = true;
            /////////////////////////////////////////// Validations
            if (txtCustomerCode.Text == "")
            {
                MessageBox.Show("The customer field must be supplied to save an order.", "Compulsory Field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCustomerCode.Focus();
                Cursor = Cursors.Default;
                bValidated = false;
            }
            else if (txtSalesCode.Text == "")
            {
                MessageBox.Show("The sales code field is compulsory.", "Compulsory Field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSalesCode.Focus();
                Cursor = Cursors.Default;
                bValidated = false;
            }
            else if (txtOrderNumber.Text == "")
            {
                MessageBox.Show("The order number field is compulsory.", "Compulsory Field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtOrderNumber.Focus();
                Cursor = Cursors.Default;
                bValidated = false;
            }
            else if (bBlockedCustomer)
            {
                MessageBox.Show("This Customer Account is blocked and connot be used.", "Blocked Customer", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCustomerCode.Focus();
                Cursor = Cursors.Default;
                bValidated = false;
            }
            else if (chkIsCustomerConsolidated.Checked && txtConsolidateNr.Text == "")
            {
                MessageBox.Show("This Customer is marked as a consolidater customer and a Consolidate Number is compulsory field", "Compulsory Field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConsolidateNr.Focus();
                Cursor = Cursors.Default;
                bValidated = false;
            }
            return bValidated;
            ////////////////////////////////////////// End Validations
        }

        private void getDeliveryNoteMessageFromPefix()
        {
            var lineItemCode = "";

            foreach (var item in Saleslines.Where(item => ((SalesLineForm)item).dtDelivery.Value != new DateTime(01, 01, 01)))
            {
                lineItemCode = ((SalesLineForm)item).txtCode.Text;
                break;
            }

            var itemRepository = new ItemRepository(Connect.LiquidConnectionString, Connect.PastelConnectionString);
            Global.DeliveryNoteMessage = itemRepository.GetDeliveryNoteMessage(lineItemCode);
        }

        public void SaveSalesOrder()
        {
            getDeliveryNoteMessageFromPefix();

            Cursor = Cursors.WaitCursor;
            var bValidated = SalesOrderValidation();
            if (bValidated)
            {
                if (!bSaved)
                {
                    SaveNewSalesOrder();
                }//bSaved
                else
                {
                    UpdateSalesOrder();
                }

                ReturnItems();

                makeReadOnly(true);
                loadSalesOrder(txtNumber.Text);
            }

            Global.DeliveryNoteMessage = "";
        }

        private void ReturnItems()
        {
            using (var oPasConn = new PsqlConnection(Connect.PastelConnectionString))
            {
                oPasConn.Open();
                using (var oConn = new PsqlConnection(Connect.LiquidConnectionString))
                {
                    oConn.Open();
                    if (!bMonthEndMode)
                    {
                        for (var iLines = 0; iLines < Saleslines.Length; iLines++)
                        {
                            var slActive = (SalesLineForm)Saleslines[iLines];
                            ProcessReturnItems(oPasConn, oConn, ref slActive);
                        }
                    }
                    oConn.Dispose();
                }
                oPasConn.Dispose();
            }
        }

        public void cmdSaveOrder_Click(object sender, EventArgs e)
        {
            SaveSalesOrder();
        }

        public void makeReadOnly(bool bUpdateInventory)
        {
            txtCustomerCode.ReadOnly = true;
            cmdSearchCustomer.Visible = false;
            cmdSalesPerson.Visible = false;
            txtSalesCode.ReadOnly = true;
            txtDiscount.ReadOnly = true;
            txtMessage1.ReadOnly = true;
            txtMessage2.ReadOnly = true;
            txtMessage3.ReadOnly = true;
            radActive.Enabled = false;
            radStandingOrder.Enabled = false;
            radFutureOrder.Enabled = false;

            dtDate.Enabled = false;
            txtSalesCode.ReadOnly = true;
            txtDiscount.ReadOnly = true;
            dtDeliveryDate.Enabled = false;

            //Readonly Line Items
            for (var iLines = 0; iLines < Saleslines.Length; iLines++)
            {
                var slThisline = (((SalesLineForm)Saleslines[iLines]));
                if (slThisline.txtCode.Text != "" && (slThisline.picReturned.Visible == false && slThisline.chkReturn.Checked == false))
                {
                    slThisline.makeLineReadOnly();
                    //book this inventory out
                    if (slThisline.dtReturnDate.Visible && bUpdateInventory) //Only lease items must be booked out
                    {
                        //AJD 13-09-2009 - Book inventory out directly in database
                        using (var oConn = new PsqlConnection(Connect.PastelConnectionString))
                        {
                            oConn.Open();
                            var sSql =
                                $@"Update Inventory
                                    SET UserDefText01 = 'Order' ,
                                        UserDefText02 = '{txtNumber.Text.Trim()}' ,
                                        UserDefText03 = '{slThisline.dtReturnDate.Value:dd/MM/yyyy}'
                                    where ItemCode = '{slThisline.txtCode.Text.Trim()}'";
                            Connect.getDataCommand(sSql, oConn).ExecuteNonQuery();
                        }
                    }
                }
                else
                {
                    tpSalesOrder.Controls.Remove(slThisline);
                }
            }
        }

        private void cmdNewOrder_Click(object sender, EventArgs e)
        {
            if (MdiParent == null)
            {
                //   ((Form)this.Parent).MdiParent
            }
            else
            {
                ((Main)MdiParent).LoadnewSalesOrder(this);
            }
        }

        public void loadSalesOrder(string salesorderNumber)
        {
            var salesorderRepo = new SalesOrderRepository(Connect.LiquidConnectionString, Connect.PastelConnectionString);
            salesorderRepo.SyncPastelAndLiquid(salesorderNumber);
            if (!bMonthEndMode)
            {
                SetFrontEndToNormal();
            }
            aUpdate = new object[0, 5];//Clear aUpdate if Sales order is loaded
            chkContract.Checked = false;
            bSaved = true;
            cmdCloseOrder.Visible = true;
            cmdSaveOrder.Enabled = false;
            cmdViewMonthEnd.Visible = true;
            cmdRePrintDelNote.Visible = true;
            crystalReportViewer1.ReportSource = null;
            lblSalesOrder.Text = salesorderNumber;
            var bLoaded = false;
            //Clear current order
            for (var iLines = 0; iLines < Saleslines.Length; iLines++)
            {
                var slThisline = (((SalesLineForm)Saleslines[iLines]));
                pnlDetails.Controls.Remove(slThisline);
            }
            iLineRowIndex = 0;
            Saleslines = new Control[0];
            cmdNewLine.Visible = true;
            // end Clear
            var sLockedStatus = "0";
            using (var oConn = new PsqlConnection(Connect.PastelConnectionString))
            {
                oConn.Open();

                var sql = "select * from HistoryHeader ";
                sql += " where HistoryHeader.DocumentNumber = '" + salesorderNumber.Replace("'", "") + "' ";
                sql += " and DocumentType = '102'";

                var rdReader = Connect.getDataCommand(sql, oConn).ExecuteReader();
                while (rdReader.Read())
                {
                    //Header
                    txtNumber.Text = rdReader["DocumentNumber"].ToString();
                    txtCustomerCode.Text = rdReader["CustomerCode"].ToString();
                    loadCustomer(false, true);

                    txtDelAd1.Text = rdReader["DelAddress01"].ToString().Trim();
                    txtDelAd2.Text = rdReader["DelAddress02"].ToString().Trim();
                    txtDelAd3.Text = rdReader["DelAddress03"].ToString().Trim();
                    txtDelAd4.Text = rdReader["DelAddress04"].ToString().Trim();
                    txtDelAd5.Text = rdReader["DelAddress05"].ToString().Trim();
                    txtTelephone.Text = rdReader["Telephone"].ToString();
                    txtContact.Text = rdReader["Contact"].ToString();
                    txtFax.Text = rdReader["Fax"].ToString();

                    txtSalesCode.Text = rdReader["SalesmanCode"].ToString();
                    dtDate.Value = Convert.ToDateTime(rdReader["DocumentDate"]);
                    txtDiscount.Text = rdReader["DiscountPercent"].ToString();
                    dtDeliveryDate.Visible = false;
                    pnlDeliveryDateValue.BackColor = Color.White;
                    txtMessage1.Text = rdReader["Message01"].ToString();
                    txtMessage2.Text = rdReader["Message02"].ToString();
                    txtMessage3.Text = rdReader["Message03"].ToString();
                    txtOrderNumber.Text = rdReader["OrderNumber"].ToString().Trim();

                    using (var liquidConnection = new PsqlConnection(Connect.LiquidConnectionString))
                    {
                        liquidConnection.Open();
                        sql = $@"SELECT LockedStatus,Type, Status, DepositAmount,Saturdays, Sundays, Coordinates, AdvPaymentAmount, DepositType,Collected,Contract,SiteName,SalesOrderType,ConsolidateNumber, Excludeholiday, AuditDate, LeaseLevyPerc 
                                FROM SOLHH where DocNumber = '{txtNumber.Text}'";

                        var bEntry = false;
                        var headerReader = Connect.getDataCommand(sql, liquidConnection).ExecuteReader();
                        while (headerReader.Read())
                        {
                            selAddresses.Text = headerReader["SiteName"].ToString();
                            switch (headerReader["Type"].ToString())
                            {
                                case "0":
                                    radActive.Checked = true;
                                    bEntry = true;
                                    break;

                                case "1":
                                    radStandingOrder.Checked = true;
                                    bEntry = true;
                                    break;

                                case "2":
                                    radFutureOrder.Checked = true;
                                    bEntry = true;
                                    break;
                            }
                            chkCollected.Checked = headerReader["Collected"].ToString() == "1";

                            if (headerReader["Contract"].ToString() != "")
                            {
                                try
                                {
                                    chkContract.Checked = true;
                                    dtContractDate.Value = Convert.ToDateTime(headerReader["Contract"].ToString());
                                }
                                catch
                                {
                                }
                            }
                            try
                            {
                                chkSalesOrderType.Checked = headerReader["SalesOrderType"].ToString() == "1";
                            }
                            catch
                            {
                            }

                            setSalesOrderStatus(Convert.ToInt32(headerReader["Status"]));
                            bLockedStatus = headerReader["LockedStatus"].ToString() == "1";
                            chkSaturday.Checked = headerReader["Saturdays"].ToString() == "1";
                            chkSundays.Checked = headerReader["Sundays"].ToString() == "1";
                            chkPublicHolidays.Checked = headerReader["Excludeholiday"].ToString() == "1";
                            txtCoordinates.Text = headerReader["Coordinates"].ToString().Replace("|", "'");
                            txtConsolidateNr.Text = headerReader["ConsolidateNumber"].ToString().Replace("|", "'");
                            txtLevyPercentage.Text = headerReader["LeaseLevyPerc"].ToString().Replace("|", "'");
                            grpAudit.Visible = true;
                            // Audit delivery note
                            var test = headerReader["AuditDate"].ToString();
                            if (headerReader["AuditDate"].ToString() != "")
                            {
                                lbAudit.Text = headerReader["AuditDate"].ToString().Trim();
                                pnlAudit.BackColor = Color.LimeGreen;
                                btnConfirmAudit.Text = "Reconfirm Filling";
                                btnRemoveAudit.Visible = true;
                            }
                            else
                            {
                                lbAudit.Text = "";
                                pnlAudit.BackColor = Color.Red;
                                btnConfirmAudit.Text = "Confirm Filling";
                                btnRemoveAudit.Visible = false;
                            }

                        }
                        if (!bEntry)
                        {
                            radActive.Checked = true;
                        }
                        headerReader.Close();
                        liquidConnection.Dispose();
                    }
                    //Lines
                    sql = "select * from HistoryLines ";
                    sql += "where HistoryLines.DocumentNumber = '" + salesorderNumber + "' ";
                    sql += "and DocumentType = '102' ";
                    sql += "order by LinkNum";
                    var rdLineReader = Connect.getDataCommand(sql, oConn).ExecuteReader();
                    while (rdLineReader.Read())
                    {
                        var sLineType = Functions.getLineInventoryType(rdLineReader["ItemCode"].ToString());
                        loadLines(salesorderNumber, rdLineReader["MultiStore"].ToString(), rdLineReader["ItemCode"].ToString(), rdLineReader["Description"].ToString(), rdLineReader["CostCode"].ToString(), rdLineReader["UnitUsed"].ToString(), rdLineReader["Qty"].ToString(), rdLineReader["UnitPrice"].ToString(), rdLineReader["DiscountPercentage"].ToString(), rdLineReader["TaxType"].ToString(), rdLineReader["LinkNum"].ToString(), rdLineReader["DiscountType"].ToString(), sLineType);
                    }
                    rdLineReader.Close();
                    //	oLineConn.Dispose();
                    bLoaded = true;
                    addTotals();
                    makeReadOnly(false);
                }
                rdReader.Close();
                oConn.Dispose();
            }
            if (bLoaded)
            {
                Cursor = Cursors.Default;
                fillSalesInvoices();
            }
            else
            {
                cmdSearchNumber_Click(null, null);
            }

            if (Saleslines.Length == 0)//AJD 30 September 2009
            {
                cmdCloseOrder.Visible = true;
            }
            if (bMonthEndMode)
            {
                cmdViewMonthEnd_Click(null, null);
                if (!bPermanentMonthEnd)
                {
                }
                else
                {
                    cmdViewMonthEnd.Visible = false;
                }
            }
            if (bBlockedCustomer)
                disableButtons();

            //lock order
            if (sLockedStatus != "1") return;

            disableButtons();
            makeReadOnly(true);
        }

        public void loadLines(string sSalesCode, string sStore, string sCode, string sDescription, string projectCode,string sUnit, string sQty, string sExcPrice, string sDiscount, string sTaxType, string linkNumber, string sDiscountType, string lineType)
        {
            var bInsert = false;
            var iInsertPos = 0;
            //LL Discount displyed incorrectly 18/09/2009
            var dDiscount = Convert.ToDouble(sDiscount.Trim()) / 100;
            var slNewLine = new SalesLineForm
            {
                bDoCalculation = false,
                txtStore = { Text = sStore.Trim() },
                txtCode = { Text = sCode.Trim() },
                txtDescription = { Text = sDescription.Trim() },
                txtProject = { Text = projectCode.Trim()},
                txtUnit = { Text = sUnit.Trim() },
                txtQuantity = { Text = Convert.ToDecimal(sQty.Trim()).ToString("N2") },
                txtExcPrice = { Text = (Convert.ToDouble(sExcPrice.Trim())).ToString("N2") },
                txtDiscount = { Text = dDiscount.ToString("N2") },
                txtDiscountType = { Text = sDiscountType },
                bNextLine = true
            };

            //Don't allow new rows if code field loose focus()
            var dTotalExDiscount = Convert.ToDouble(slNewLine.txtQuantity.Text.Replace(",", "")) * Convert.ToDouble(slNewLine.txtExcPrice.Text.Replace(",", ""));
            slNewLine.txtNet.Text = (dTotalExDiscount - (dTotalExDiscount * (Convert.ToDouble(slNewLine.txtDiscount.Text.Replace(",", "")) / 100))).ToString("N2");
            slNewLine.sPastelLineLink = linkNumber;
            slNewLine.txtTaxType.Text = sTaxType;

            if (sTaxType == "0" || sTaxType == "2")
            {
                slNewLine.txtNet.BackColor = Color.Yellow;
            }

            if (slNewLine.txtCode.Text == "'")
            {
                slNewLine.chkReturn.Visible = false;
                slNewLine.txtMultiplier.Visible = false;
                slNewLine.txtQuantity.Visible = false;
                slNewLine.txtDiscount.Visible = false;
                slNewLine.txtExcPrice.Visible = false;
                slNewLine.txtNet.Visible = false;
                slNewLine.lblReturnDate.Visible = false;
                slNewLine.lblDeliveryDate.Visible = false;
            }
            //Add dates to line
            var liquidConnection = new PsqlConnection(Connect.LiquidConnectionString);
            liquidConnection.Open();
            var sSql = "SELECT DeliveryDate, ReturnDate, LastInvoiceDate, Status, LinkNum, Multiplier, Qty, ItemCode, sCalculationRule from SOLHL where Header = '" + sSalesCode + "' and ItemCode = '" + sCode.Trim().Replace("'", "downtime") + "' and LinkNum = " + linkNumber;
            var liquidReader = Connect.getDataCommand(sSql, liquidConnection).ExecuteReader();
            while (liquidReader.Read())
            {
                var isLeaseItem = lineType == "1";

                if (!isLeaseItem)
                {
                    hideDates(slNewLine);
                }
                else
                {
                    showDates(slNewLine);
                    slNewLine.dtDelivery.Value = new DateTime(1900, 1, 1, 0, 0, 0);
                    slNewLine.dtDelivery.Enabled = false;
                    slNewLine.dtReturnDate.Value = new DateTime(1900, 1, 1);
                    slNewLine.dtReturnDate.Enabled = false;
                    if (liquidReader["ReturnDate"].GetType().Name != "DBNull")
                    {
                        try
                        {
                            try
                            {
                                var dtClock =
                                    new DateTime(
                                        Convert.ToInt32(liquidReader["ReturnDate"].ToString().Substring(6, 4)),
                                        Convert.ToInt32(liquidReader["ReturnDate"].ToString().Substring(3, 2)),
                                        Convert.ToInt32(liquidReader["ReturnDate"].ToString().Substring(0, 2)),
                                        Convert.ToInt32(liquidReader["ReturnDate"].ToString().Substring(11, 2)),
                                        Convert.ToInt32(liquidReader["ReturnDate"].ToString().Substring(14, 2)), 0);
                                slNewLine.dtReturnDate.Value =
                                    new DateTime(
                                        Convert.ToInt32(liquidReader["ReturnDate"].ToString().Substring(6, 4)),
                                        Convert.ToInt32(liquidReader["ReturnDate"].ToString().Substring(3, 2)),
                                        Convert.ToInt32(liquidReader["ReturnDate"].ToString().Substring(0, 2)));
                                slNewLine.toolTip1.SetToolTip(slNewLine.dtReturnDate,
                                    Convert.ToString(dtClock.TimeOfDay));
                            }
                            catch
                            {
                                slNewLine.dtReturnDate.Value =
                                    new DateTime(
                                        Convert.ToInt32(liquidReader["ReturnDate"].ToString().Substring(6, 4)),
                                        Convert.ToInt32(liquidReader["ReturnDate"].ToString().Substring(3, 2)),
                                        Convert.ToInt32(liquidReader["ReturnDate"].ToString().Substring(0, 2)));
                            }
                        }
                        catch (Exception)
                        {
                            slNewLine.dtReturnDate.Value = Convert.ToDateTime(liquidReader["LastInvoiceDate"]);
                        }
                    }

                    try
                    {
                        try
                        {
                            var dtClock = new DateTime(Convert.ToInt32(liquidReader["DeliveryDate"].ToString().Substring(6, 4)), Convert.ToInt32(liquidReader["DeliveryDate"].ToString().Substring(3, 2)), Convert.ToInt32(liquidReader["DeliveryDate"].ToString().Substring(0, 2)), Convert.ToInt32(liquidReader["DeliveryDate"].ToString().Substring(11, 2)), Convert.ToInt32(liquidReader["DeliveryDate"].ToString().Substring(14, 2)), 0);

                            slNewLine.dtDelivery.Value = new DateTime(Convert.ToInt32(liquidReader["DeliveryDate"].ToString().Substring(6, 4)), Convert.ToInt32(liquidReader["DeliveryDate"].ToString().Substring(3, 2)), Convert.ToInt32(liquidReader["DeliveryDate"].ToString().Substring(0, 2)));
                            slNewLine.toolTip1.SetToolTip(slNewLine.dtDelivery, Convert.ToString(dtClock.TimeOfDay));
                        }
                        catch
                        {
                            slNewLine.dtDelivery.Value = new DateTime(Convert.ToInt32(liquidReader["DeliveryDate"].ToString().Substring(6, 4)), Convert.ToInt32(liquidReader["DeliveryDate"].ToString().Substring(3, 2)), Convert.ToInt32(liquidReader["DeliveryDate"].ToString().Substring(0, 2)));
                        }
                    }
                    catch (Exception)
                    {
                        slNewLine.dtDelivery.Value = slNewLine.dtReturnDate.Value;
                    }
                }
                if (liquidReader["LastInvoiceDate"].ToString() != "")
                {
                    slNewLine.txtLastInvoiceDate.Text = Convert.ToDateTime(liquidReader["LastInvoiceDate"]).ToString("dd/MM/yyyy");
                    slNewLine.picInfo.Visible = false; //can delete allready invoiced items
                }
                if (liquidReader["status"].ToString() == "1")
                {
                    slNewLine.txtStatus.Text = "1";
                    slNewLine.picReturned.Visible = true;
                    slNewLine.dtDelivery.Enabled = false;
                    slNewLine.dtReturnDate.Enabled = false;

                    slNewLine.picDelete.Visible = false;
                    slNewLine.chkReturn.Visible = false;
                }
                else
                {
                    slNewLine.chkReturn.Visible = true;
                }

                slNewLine.dMaxMultiplierValue = Convert.ToDecimal(liquidReader["Multiplier"].ToString());
                slNewLine.txtMultiplier.Text = slNewLine.dMaxMultiplierValue.ToString("N2");
                slNewLine.txtQuantity.Text = Convert.ToDecimal(liquidReader["Qty"].ToString()).ToString("N2");
                slNewLine.txtUnitFormula.Text = liquidReader["sCalculationRule"].ToString().Trim();
            }
            if (slNewLine.dMaxMultiplierValue == 0)
            {
                slNewLine.dMaxMultiplierValue = 1;
            }

            liquidReader.Close();
            liquidConnection.Dispose();
            //LL Phalaborwa if else
            if (sDescription.StartsWith("*D"))
            {
                slNewLine.bAllowDuplicateLines = true;
            }
            else
            {
                using (var oPastel = new PsqlConnection(Connect.PastelConnectionString))
                {
                    oPastel.Open();
                    //Gee Error aas Item met Itemode ' gelaai word
                    if (sCode.Trim() != "'" && sCode.Trim() != "")
                    {
                        sSql = "Select UserDefNum02 from inventory where ItemCode ='" + sCode.Trim() + "'";			//AJD 20-08-2009 - Check if duplicates is allowed
                        if (Connect.getDataCommand(sSql, oPastel).ExecuteScalar().ToString() == "1")
                        {
                            slNewLine.bAllowDuplicateLines = true;
                        }
                    }

                    oPastel.Dispose();
                }
            }
            if (lineType == "1")
            {
                slNewLine.txtQuantity.ReadOnly = false;
                if (slNewLine.bAllowDuplicateLines && !(sDescription.StartsWith("*D")) && slNewLine.txtCode.Text != "'")
                {
                    slNewLine.txtMultiplier.ReadOnly = false;
                }
                else
                {
                    slNewLine.txtMultiplier.ReadOnly = true;
                }
            }
            else // Consumables
            {
                slNewLine.txtMultiplier.ReadOnly = false;
                slNewLine.txtQuantity.ReadOnly = true;
            }

            if (bLockedStatus)
            {
                slNewLine.dtDelivery.Enabled = false;
                slNewLine.picDelete.Enabled = false;
                slNewLine.chkReturn.Enabled = false;
                slNewLine.cmdCodeSearch.Enabled = false;
                slNewLine.txtCode.Enabled = false;
                slNewLine.txtDescription.Enabled = false;
                slNewLine.cmdFromulaFinder.Enabled = false;

                cmdSaveOrder.Enabled = false;
                gbExcludeDays.Enabled = false;
                dtForecastDate.Enabled = false;
                txtInfoForecastDate.Enabled = false;
                picEditAddress.Enabled = false;
                chkCollected.Enabled = false;
                chkPrintOnSave.Enabled = false;
                gbStatus.Visible = false;
                picLocked.Visible = true;
                lblLocked.Visible = true;
            }
            else
            {
                slNewLine.dtDelivery.Enabled = true;
                slNewLine.picDelete.Enabled = true;
                slNewLine.chkReturn.Enabled = true;
                slNewLine.cmdCodeSearch.Enabled = true;
                slNewLine.txtCode.Enabled = true;
                slNewLine.txtDescription.Enabled = true;
                slNewLine.cmdFromulaFinder.Enabled = true;

                cmdSaveOrder.Enabled = true;
                gbExcludeDays.Enabled = true;
                txtCoordinates.Enabled = true;
                dtForecastDate.Enabled = true;
                txtInfoForecastDate.Enabled = true;
                picEditAddress.Enabled = true;
                chkCollected.Enabled = false;
                chkPrintOnSave.Enabled = false;
                gbStatus.Visible = true;
                picLocked.Visible = false;
                lblLocked.Visible = false;
            }

            slNewLine.bDoCalculation = true;
            slNewLine.sLineType = lineType;

            if (bInsert)
            {
                InsertSalesLine(iInsertPos, slNewLine);
            }
            else
            {
                AddSalesLine(slNewLine);
            }
            if (bBlockedCustomer)
                slNewLine.picDelete.Visible = false;
        }

        private void showDates(SalesLineForm slNewLineForm)
        {
            slNewLineForm.dtDelivery.Visible = true;
            slNewLineForm.dtReturnDate.Visible = true;
            slNewLineForm.lblDeliveryDate.Visible = false;
            slNewLineForm.lblReturnDate.Visible = false;
        }

        private static void hideDates(SalesLineForm slNewLineForm)
        {
            slNewLineForm.dtDelivery.Visible = false;
            slNewLineForm.dtReturnDate.Visible = false;
            slNewLineForm.lblDeliveryDate.Visible = true;
            slNewLineForm.lblReturnDate.Visible = true;
        }

        private void selAddresses_SelectedIndexChanged(object sender, EventArgs e)
        {
            buildCustDetail();
            GetMarketingDetails();
            btnDelete.Visible = true;
        }

        private void buildCustDetail()
        {
            var code = selAddresses.Text == "Main" ? "" : selAddresses.Text.Substring(selAddresses.Text.IndexOf("[") + 1, selAddresses.Text.Length - (selAddresses.Text.IndexOf("[") + 1)).Replace("]", "");

            var oConn = new PsqlConnection(Connect.PastelConnectionString);
            oConn.Open();
            var sSql = "Select * from DeliveryAddresses where CustomerCode = '" + txtCustomerCode.Text.Trim() + "' and CustDelivCode = '" + code + "' order by CustomerCode";
            var rdReader = Connect.getDataCommand(sSql, oConn).ExecuteReader();
            while (rdReader.Read())
            {
                txtContact.Text = rdReader["Contact"].ToString().Trim();
                txtTelephone.Text = rdReader["Telephone"].ToString().Trim();
                txtMobile.Text = rdReader["Cell"].ToString().Trim();
                txtFax.Text = rdReader["Fax"].ToString().Trim();
                txtDelAd1.Text = rdReader["DelAddress01"].ToString().Trim();
                txtDelAd2.Text = rdReader["DelAddress02"].ToString().Trim();
                txtDelAd3.Text = rdReader["DelAddress03"].ToString().Trim();
                txtDelAd4.Text = rdReader["DelAddress04"].ToString().Trim();
                txtDelAd5.Text = rdReader["DelAddress05"].ToString().Trim();
                txtEmail.Text = rdReader["Email"].ToString().Trim();
            }
            rdReader.Close();
            oConn.Dispose();
        }

        private void cmdSalesPerson_Click(object sender, EventArgs e)
        {
            using (var frmVerify = new VerifyUser())
            {
                if (frmVerify.ShowDialog() == DialogResult.OK)
                {
                    txtSalesCode.Text = frmVerify.sUserCode;
                }
            }
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            addTotals();
        }

        private void ProcessReturnItems(PsqlConnection oPasConn, PsqlConnection oSolConn, ref SalesLineForm slActive)
        {
            var bUpdated = false;

            if (slActive.chkReturn.Checked)
            {
                //Validations
                if (Convert.ToDecimal(slActive.txtMultiplier.Text) > slActive.dMaxMultiplierValue)//check if multiplier returned is more than the original multiplier
                {
                    MessageBox.Show("You can't return more items than originally orderder. \r\n  The original order amout was: " + slActive.dMaxMultiplierValue, "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    slActive.txtMultiplier.Parent.BackColor = Color.Red;
                    return;
                }
                else if (slActive.txtMultiplier.Text != "" && Convert.ToDecimal(slActive.txtMultiplier.Text) <= 0)
                {
                    MessageBox.Show("You can't return zero or negative item.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    slActive.txtMultiplier.Parent.BackColor = Color.Red;
                    return;
                }
                else
                {//process returned item
                    for (var iLines = 0; iLines < Saleslines.Length; )   //find sales line that is linked to this entry
                    {
                        DateTime deliveryDate = DateTime.Now, dtReturnDate = DateTime.Now;
                        bUpdated = true;
                        string sSql;
                        if (slActive.sLineType == "1")//lease item
                        {
                            deliveryDate = slActive.dtDelivery.Value;
                            dtReturnDate = slActive.dtReturnDate.Value;

                            sSql = "UPDATE Inventory SET "; //book this item back for rental
                            sSql += " UserDefText01 = '' ";
                            sSql += ", UserDefText02 = '' ";
                            sSql += ", UserDefText03 = '' ";
                            sSql += " WHERE ItemCode = '" + slActive.txtCode.Text + "' ";
                            Connect.getDataCommand(sSql, oPasConn).ExecuteNonQuery();
                        }
                        if (slActive.sLineType != "Comment")
                        {
                            var sTotalQty = (Convert.ToDecimal(slActive.txtMultiplier.Text) * Convert.ToDecimal(slActive.txtQuantity.Text)).ToString("N2"); //Update Pastel directly because if updated through the SDK it gets a new linkedNum
                            sSql = "UPDATE HistoryLines SET ";
                            sSql += " Qty = " + sTotalQty.Replace(",", "");
                            sSql += ", UnitPrice = " + slActive.txtExcPrice.Text.Replace(" ", "").Replace(",", "");
                            sSql += ", DiscountPercentage = " + (Convert.ToDecimal(slActive.txtDiscount.Text.Replace(",", "")) * 100);
                            sSql += " where DocumentNumber = '" + txtNumber.Text.Trim() + "' and ItemCode = '" + slActive.txtCode.Text.Trim() + "' and LinkNum = " + slActive.sPastelLineLink;
                            Connect.getDataCommand(sSql, oPasConn).ExecuteNonQuery();

                            sSql = "UPDATE SOLHL SET "; //mark salesline as returned
                            sSql += " Status = 1";
                            sSql += ", Multiplier = " + slActive.txtMultiplier.Text.Replace(",", "");
                            sSql += ", Qty = " + slActive.txtQuantity.Text.Replace(",", "");
                            if (slActive.sLineType == "1")//lease item
                            {
                                sSql += ", DeliveryDate = '" + deliveryDate.ToString("dd-MM-yyyy hh:mm") + "'";
                                sSql += ", ReturnDate = '" + dtReturnDate.ToString("dd-MM-yyyy hh:mm") + "'";
                            }
                            sSql += " WHERE Header = '" + txtNumber.Text + "' and ItemCode = '" + slActive.txtCode.Text.Trim() + "' and LinkNum = " + slActive.sPastelLineLink;
                            Connect.getDataCommand(sSql, oSolConn).ExecuteNonQuery();
                            slActive.txtStatus.Text = "1";
                            addTotals();
                        }

                        #region Multiplier Test And Setup

                        //Multiplier returns
                        //If less items is returned in the multiplier field Add the remaining qty
                        var bMultiplierPartialReturn = false;
                        var aMultiplierDownTime = new string[0];

                        if (Convert.ToDecimal(slActive.txtMultiplier.Text) < slActive.dMaxMultiplierValue && slActive.sLineType == "1")//Less items returned and must be lease item
                        {
                            bMultiplierPartialReturn = true;
                        }

                        #endregion Multiplier Test And Setup

                        #region Multiplier Function

                        //Multiplier returns
                        //If less items is returned in the multiplier field Add the remaining qty
                        if (bMultiplierPartialReturn)
                        {
                            var sNewQty = (slActive.dMaxMultiplierValue - Convert.ToDecimal(slActive.txtMultiplier.Text) * Convert.ToDecimal(slActive.txtQuantity.Text)).ToString();
                            //Book linked item back via invoice
                            var sLine = "|";
                            sLine += sNewQty + "|"; //Line Quantity
                            sLine += slActive.txtExcPrice.Text + "|"; //Exclusive Price Per Unit
                            if (slActive.txtTaxType.Text == "0")
                                sLine += (Convert.ToDecimal(slActive.txtExcPrice.Text)).ToString().Replace(",", "") + "|"; //Inclusive Price Per Unit
                            else if (slActive.txtTaxType.Text == "1")
                                sLine += (Convert.ToDecimal(slActive.txtExcPrice.Text) * 1.15m).ToString().Replace(",", "") + "|"; //Inclusive Price Per Unit
                            sLine += slActive.txtUnit.Text + "|"; //Unit
                            sLine += slActive.txtTaxType.Text + "|"; //Tax Type
                            sLine += slActive.txtDiscountType.Text + "|"; //Discount Type
                            sLine += slActive.txtDiscount.Text + "|"; //Discount %
                            sLine += slActive.txtCode.Text + "|"; //Code
                            sLine += slActive.txtDescription.Text + "|"; //Description
                            sLine += "4|"; //Line Type
                            sLine += slActive.txtStore.Text + "|"; //MultiStore
                            sLine += "|"; //CostCode
                            var aMultiplierReturn = clsSDK.EditPastelDocument(sLine, 102, txtNumber.Text, "I", Global.sDataPath).Split("|".ToCharArray());
                            if (aMultiplierReturn[0] != "0")
                            {
                                MessageBox.Show("Error 100.  Failed to create new multiplier row. \r\n\r\n Error " + aMultiplierReturn[1], "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else //Pastel row added
                            {
                                //Get new Linknum for line - must get from Pastel because downtime lines and notes is not stored in SolHL
                                sSql = "Select max(LinkNum) from HistoryLines where DocumentNumber = '" + txtNumber.Text + "'";
                                var sNewLinkNum = Connect.getDataCommand(sSql, oPasConn).ExecuteScalar().ToString();
                                sSql = "INSERT into SOLHL";
                                sSql += " (Header, ItemCode, DeliveryDate, ReturnDate, Status,LinkNum, Multiplier, Qty) ";
                                sSql += " VALUES ";
                                sSql += "(";
                                sSql += "'" + txtNumber.Text.Trim() + "'";
                                sSql += ",'" + slActive.txtCode.Text + "'";
                                sSql += ", '" + slActive.dtDelivery.Value.ToString("dd-MM-yyyy") + "'";
                                sSql += ",'" + slActive.dtReturnDate.Value.ToString("dd-MM-yyyy") + "'";
                                sSql += ",0"; //status0 not returned
                                sSql += "," + sNewLinkNum;
                                sSql += "," + (slActive.dMaxMultiplierValue - Convert.ToDecimal(slActive.txtMultiplier.Text));
                                sSql += "," + slActive.txtQuantity.Text;
                                sSql += ")";
                                Connect.getDataCommand(sSql, oSolConn).ExecuteNonQuery();
                                //Add Downtime to new row
                                for (var i = 0; i < aMultiplierDownTime.Length; i++)
                                {
                                    if (aMultiplierDownTime[i].Trim() == "") continue;
                                    clsSDK.EditPastelDocument(aMultiplierDownTime[i].Replace("~~~", sNewLinkNum.PadLeft(3, "0".ToCharArray()[0])), 102, txtNumber.Text, "I", Global.sDataPath);
                                }
                            }
                        }

                        #endregion Multiplier Function

                        break;
                    }
                }
            }
            if (!bUpdated)
            {
                //  MessageBox.Show("No items were selected for return.", "No Returned Items", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (!Global.bAutoInvoiceOnReturn) return;
                Cursor = Cursors.WaitCursor;
                using (var frmInvoice = new InvoiceOrder())
                {
                    frmInvoice.frmSalesOrder = this;
                    frmInvoice.sDocNumber = txtNumber.Text;
                    frmInvoice.sCustomerCode = txtCustomerCode.Text;
                    frmInvoice.sCustomerDescription = txtCustomerDescription.Text;
                    frmInvoice.sDiscountPerc = txtDiscount.Text;
                    frmInvoice.sDeliveryDate = dtDeliveryDate.Value.ToString("dd/MM/yyyy");
                    frmInvoice.sOrderNumber = txtOrderNumber.Text;
                    frmInvoice.sSiteName = selAddresses.Text.Trim();
                    frmInvoice.frmMain = ((Main)MdiParent);
                    //autoinvoice
                    if (chkChangeInvoice.Checked)
                    {
                        chkChangeInvoice.Checked = false;
                        if (frmInvoice.ShowDialog() == DialogResult.OK)
                        {
                            loadSalesOrder(txtNumber.Text);
                        }
                        else//Closed application
                        {
                            frmInvoice.InvoiceOrder_Load(null, null);
                            frmInvoice.cmdCreateInvoice_Click(null, null);
                            loadSalesOrder(txtNumber.Text);
                        }
                    }
                    else
                    {
                        frmInvoice.InvoiceOrder_Load(null, null);
                        frmInvoice.cmdCreateInvoice_Click(null, null);
                        loadSalesOrder(txtNumber.Text);
                    }
                }
                Cursor = Cursors.Default;
            }
        }

        public void setSalesOrderStatus(int iStatus)
        {
            iSalesOrderStatus = iStatus;
            pnlSalesStatus.BackColor = aSalesOrderStatusColor[iStatus];
            if (iStatus == 3)
            {
                cmdNewLine.Enabled = false;
                cmdSaveOrder.Enabled = false;
            }
            else
            {
                cmdNewLine.Enabled = true;
                cmdSaveOrder.Enabled = true;
            }
        }

        public void addUpdateInstruction(string sObjectID, int iInstruction, object oData, string sQuantity, string sMultiplier)
        {
            //Instructions
            // 0 -  Update Sales Line Delivery Date
            // 1 - New Sales Order Line

            cmdSaveOrder.Enabled = true;
            //check if instruction allready exist
            for (var iRow = 0; iRow < aUpdate.GetLength(0); iRow++)
            {
                if ((aUpdate[iRow, 0] + aUpdate[iRow, 1].ToString()) == (sObjectID + iInstruction))
                {
                    aUpdate[iRow, 2] = oData;
                    aUpdate[iRow, 3] = sQuantity;
                    aUpdate[iRow, 4] = sMultiplier;
                    return;
                }
            }
            //Add row if instruction does not exist
            Functions.ResizeArray(ref aUpdate, aUpdate.GetLength(1), aUpdate.GetLength(0) + 1);
            aUpdate[aUpdate.GetLength(0) - 1, 0] = sObjectID;
            aUpdate[aUpdate.GetLength(0) - 1, 1] = iInstruction;
            aUpdate[aUpdate.GetLength(0) - 1, 2] = oData;
            aUpdate[aUpdate.GetLength(0) - 1, 3] = sQuantity;
            aUpdate[aUpdate.GetLength(0) - 1, 4] = sMultiplier;
        }

        private void cmdNewLine_Click(object sender, EventArgs e)
        {
            var slNewline = new SalesLineForm();
            AddSalesLine(slNewline);
            slNewline.bNextLine = true;
            slNewline.txtCode.Focus();
            slNewline.bFocusOnNextLine = false;
            addUpdateInstruction(slNewline.Name, 1, slNewline, slNewline.txtQuantity.Text, slNewline.txtMultiplier.Text);
        }

        private string getPastelLine(SalesLineForm slThisLineForm)
        {
            var sLine = "";
            var sLineType = "4";
            if (slThisLineForm.txtCode.Text == "'")
            {
                sLine += "|"; //Cost Price
                sLine += "|"; //Line Quantity
                sLine += "|"; //Exclusive Price Per Unit
                sLine += "|"; //Inclusive Price Per Unit
                sLine += "|"; //Unit
                sLine += "|"; //Tax Type
                sLine += "|"; //Discount Type
                sLine += "|"; //Discount %
                sLine += "|"; //Code
                sLine += slThisLineForm.txtDescription.Text.Trim() + "|"; //Description
                sLine += "7|"; //Line Type
                sLine += "|"; //Multistore
                sLine += "|"; //CostCode
            }
            else if (slThisLineForm.txtCode.Text != "")//line defined by Code
            {
                var sQuantity = (Convert.ToDecimal(slThisLineForm.txtMultiplier.Text.Replace(",", "").Trim()) * Convert.ToDecimal(slThisLineForm.txtQuantity.Text.Replace(",", "").Trim())).ToString();
                sLine += "|"; //Cost Price
                sLine += sQuantity + "|"; //Line Quantity
                sLine += slThisLineForm.txtExcPrice.Text.Replace(",", "").Trim() + "|"; //Exclusive Price Per Unit
                //LL 16/09/2009 -- start
                sLine += getInclusivePrice(slThisLineForm.txtTaxType.Text, slThisLineForm.txtExcPrice.Text).ToString().Replace(",", "") + "|"; 
                
                //LL 16/09/2009 -- end
                sLine += slThisLineForm.txtUnit.Text.Trim() + "|"; //Unit
                sLine += slThisLineForm.txtTaxType.Text.PadLeft(2, "0".ToCharArray()[0]) + "|"; //Tax Type
                sLine += "0|"; //Discount Type
                sLine += slThisLineForm.txtDiscount.Text.Replace(".", "").Replace(",", "") + "|"; //Discount %
                sLine += slThisLineForm.txtCode.Text.Trim() + "|"; //Code
                sLine += slThisLineForm.txtDescription.Text.Trim() + "|"; //Description
                sLine += sLineType + "|"; //Line Type
                sLine += slThisLineForm.txtStore.Text.Trim() + "|"; //Multistore
                sLine += slThisLineForm.txtProject.Text.Trim() + "|"; //CostCode
            }
            return (sLine);
        }

        private void cmdRePrintDelNote_Click(object sender, EventArgs e)
        {
            getDeliveryNoteMessageFromPefix();

            Cursor = Cursors.WaitCursor;
            var sCollected = chkCollected.Checked ? "COLLECTED" : "DELIVERED";
            Generate.PrintDeliveryNote(txtNumber.Text, "", "", txtCoordinates.Text, sCollected,
                false, false, printDialog1, null);
            Cursor = Cursors.Default;
        }

        private void picEditAddress_Click(object sender, EventArgs e)
        {
            var frmCustomer = new CustomerView();
            frmCustomer.ShowDialog(true, txtCustomerCode.Text.Trim());
            var bReadonly = txtDelAd1.ReadOnly;
            loadCustomer(false, bReadonly);
        }

        private void txtCoordinates_TextChanged(object sender, EventArgs e)
        {
            cmdSaveOrder.Enabled = true;
        }

        public void RenumberPastelLinkNumOnSalesLine(string sFromLinkNum)
        {
            if (sFromLinkNum == "") return;
            for (var iLines = 0; iLines < Saleslines.Length; iLines++)   //find sales line that is linked to this entry
            {
                var slThisline = (((SalesLineForm)Saleslines[iLines]));
                if (slThisline.sPastelLineLink == "") continue;
                if (Convert.ToInt32(slThisline.sPastelLineLink) < Convert.ToInt32(sFromLinkNum)) continue;

                slThisline.sPastelLineLink = (Convert.ToInt32(slThisline.sPastelLineLink) - 1).ToString();
            }
        }

        private void cmdCloseOrder_Click(object sender, EventArgs e)
        {
            if (Saleslines.Length > 0)
            {
                if (
                    MessageBox.Show("Do you want to close this order? Note that this action cannot be reversed.",
                        "Close Order?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) != DialogResult.Yes)
                    return;
                using (var frmVerify = new VerifyUser())
                {
                    if (frmVerify.ShowDialog() != DialogResult.OK) return;
                    if (Functions.getUserProfile(frmVerify.sUserCode).bCloseOrder)
                    {
                        //
                        Functions.BackupDeletedSalesOrders(txtNumber.Text);
                        //
                        Functions.CloseOrder(txtNumber.Text.Trim());
                        loadSalesOrder(txtNumber.Text);
                    }
                    else
                    {
                        MessageBox.Show("Your user account does not allow you to close sales orders.  Please contact your manager.", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else
            {
                if (
                    MessageBox.Show(
                        "There are no more lines, do you want to close this order? Note that this action cannot be reversed.",
                        "Close Order?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) != DialogResult.Yes)
                    return;
                Functions.CloseOrder(txtNumber.Text.Trim());
                loadSalesOrder(txtNumber.Text);
            }
        }

        private void dtDateFrom_ValueChanged(object sender, EventArgs e)
        {
            dtDateTo.Value = new DateTime(dtDateTo.Value.Year, dtDateTo.Value.Month, dtDateTo.Value.Day, 0, 0, 0);
            dtDateFrom.Value = new DateTime(dtDateFrom.Value.Year, dtDateFrom.Value.Month, dtDateFrom.Value.Day, 0, 0, 0);

            if (dtDateFrom.Value <= dtDateTo.Value)
            {
                var iDays = (dtDateTo.Value - dtDateFrom.Value).Days;
                iDays++;  //include the startday
                var iSaturdays = 0;
                var iSundays = 0;
                if (!chkSaturday.Checked)
                    iSaturdays = CountDays(DayOfWeek.Saturday, dtDateFrom.Value, dtDateTo.Value);
                if (!chkSundays.Checked)
                    iSundays = CountDays(DayOfWeek.Sunday, dtDateFrom.Value, dtDateTo.Value);
                iDays = iDays - iSaturdays - iSundays;

                txtDays.Text = iDays >= 0 ? Convert.ToDouble(iDays).ToString() : "0";
            }
            else
            {
                txtDays.Text = "0";
            }
        }

        private int CountDays(DayOfWeek day, DateTime start, DateTime end)
        {
            var ts = end - start; // Total duration
            var count = (int)Math.Floor(ts.TotalDays / 7);   // Number of whole weeks
            var remainder = (int)(ts.TotalDays % 7);         // Number of remaining days
            var sinceLastDay = end.DayOfWeek - day;   // Number of days since last [day]
            if (sinceLastDay < 0)
                sinceLastDay += 7;                           // Adjust for negative days since last [day]
            // If the days in excess of an even week are greater than or equal to the number days since the last [day], then count this one, too.
            if (remainder >= sinceLastDay)
                count++;
            return count;
        }

        private void txtDays_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < '0') || (e.KeyChar > '9')) && e.KeyChar.ToString() != "\b" && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void SetFrontEndToMonthEnd()
        {
            bMonthEndMode = true;

            cmdViewInvoiceMode.Enabled = false;

            tpSalesOrder.BackColor = Color.Orange;
            tpShip.BackColor = Color.Orange;
            txtCustomerDescription.BackColor = Color.Orange;
            pnlCodeLabel.BackColor = Color.Orange;
            pnlDescriptionLabel.BackColor = Color.Orange;
            pnlDelLabel.BackColor = Color.Orange;
            panel2.BackColor = Color.Orange;
            panel61.BackColor = Color.Orange;
            pnlUnitLabel.BackColor = Color.Orange;
            pnlQtyLabel.BackColor = Color.Orange;
            pnlDisLabel.BackColor = Color.Orange;
            pnlDiscountLabel.BackColor = Color.Orange;
            pnlExcPriceLabel.BackColor = Color.Orange;
            pnlNettLabel.BackColor = Color.Orange;
            panel25.BackColor = Color.Orange;
            tpPostal.BackColor = Color.Orange;
            tpForecast.BackColor = Color.Orange;
            txtPosAd1.BackColor = Color.Orange;
            txtPosAd2.BackColor = Color.Orange;
            txtPosAd3.BackColor = Color.Orange;
            txtPosAd4.BackColor = Color.Orange;

            gbMonthEnd.Visible = true;
            lblReturnHeading.Text = "Invoice";
            for (var iLine = Saleslines.Length - 1; iLine >= 0; iLine--)
            {
                var slThisLine = (SalesLineForm)Saleslines[iLine];
                if (!slThisLine.picReturned.Visible)
                {
                    if (chkInvoiceConsumables.Checked || slThisLine.sLineType == "1" || slThisLine.sLineType == "Comment")
                    {
                        slThisLine.chkReturn.Checked = true;
                    }
                    else
                    {
                        slThisLine.chkReturn.Checked = false;
                    }
                }
            }
        }

        private void SetFrontEndToNormal()
        {
            bMonthEndMode = false;
            bInvoiceMode = false;
            tpSalesOrder.BackColor = Color.LemonChiffon;
            tpShip.BackColor = Color.LemonChiffon;
            txtCustomerDescription.BackColor = Color.LemonChiffon;
            pnlCodeLabel.BackColor = Color.LemonChiffon;
            pnlDescriptionLabel.BackColor = Color.LemonChiffon;
            pnlProjectLabel.BackColor = Color.LemonChiffon;
            pnlDelLabel.BackColor = Color.LemonChiffon;
            panel2.BackColor = Color.LemonChiffon;
            panel61.BackColor = Color.LemonChiffon;
            pnlUnitLabel.BackColor = Color.LemonChiffon;
            pnlQtyLabel.BackColor = Color.LemonChiffon;
            pnlDisLabel.BackColor = Color.LemonChiffon;
            pnlDiscountLabel.BackColor = Color.LemonChiffon;
            pnlExcPriceLabel.BackColor = Color.LemonChiffon;
            pnlNettLabel.BackColor = Color.LemonChiffon;
            panel25.BackColor = Color.LemonChiffon;
            tpPostal.BackColor = Color.LemonChiffon;
            tpForecast.BackColor = Color.LemonChiffon;
            txtPosAd1.BackColor = Color.LemonChiffon;
            txtPosAd2.BackColor = Color.LemonChiffon;
            txtPosAd3.BackColor = Color.LemonChiffon;
            txtPosAd4.BackColor = Color.LemonChiffon;
            pnlSalesOrderStatus.BackColor = Color.LemonChiffon;
            gbMonthEnd.Visible = false;
            lblReturnHeading.Text = "Return";
        }

        private void cmdViewMonthEnd_Click(object sender, EventArgs e)
        {
            cmdSearchNumber.Enabled = true;
            if (bMonthEndMode && !bPermanentMonthEnd)
            {
                cmdViewInvoiceMode.Enabled = true;
                bMonthEndMode = false;
                loadSalesOrder(txtNumber.Text);
            }
            else
            {
                bMonthEndMode = true;
                SetFrontEndToMonthEnd();
                var sMonthEnd = GetPeriodEnd();
                var dtMonthEnd = new DateTime(Convert.ToInt32(sMonthEnd.Substring(6, 4)), Convert.ToInt32(sMonthEnd.Substring(0, 2)), Convert.ToInt32(sMonthEnd.Substring(3, 2)), 0, 0, 0);
                var bDoPartial = true;
                for (var iLines = 0; iLines < Saleslines.Length; iLines++)
                {
                    var slActive = (SalesLineForm)Saleslines[iLines];
                    if (slActive.txtLastInvoiceDate.Text != "" && slActive.sLineType == "1")
                    {
                        using (var oConn = new PsqlConnection(Connect.PastelConnectionString))
                        {
                            var sSql = "Select UserDefNum01 From Inventory where ItemCode = '" + slActive.txtCode.Text.Trim() + "'";
                            var rdReader = Connect.getDataCommand(sSql, oConn).ExecuteReader();
                            while (rdReader.Read())
                            {
                                var sResult = rdReader["UserDefNum01"].ToString().Trim();
                                if (sResult == "0" & sResult == "2")
                                {
                                    bDoPartial = false;
                                }
                            }
                        }
                        var sQty = calcDays(slActive);

                        if (slActive.txtUnitFormula.Text != "") //Check if calculation rule is used
                        {
                            var isLineReturned = slActive.txtStatus.Text == "1";
                            sQty = Functions.CalculateQty_UnitRule(int.Parse(sQty), slActive.txtUnitFormula.Text, isLineReturned, slActive.dtDelivery.Value, slActive.dtReturnDate.Value);
                        }

                        slActive.txtQuantity.Text = Convert.ToDecimal(sQty).ToString("N2");
                    }
                    if (slActive.txtStatus.Text == "1" || slActive.txtCode.Text.StartsWith("*D") ||
                        slActive.sLineType != "1") continue;
                    slActive.dtReturnDate.Value = dtMonthEnd;

                    bDoPartial = true;
                    using (var oConn = new PsqlConnection(Connect.PastelConnectionString))
                    {
                        oConn.Open();
                        var sSql = "Select UserDefNum01 From Inventory where ItemCode = '" + slActive.txtCode.Text.Trim() + "'";
                        var rdReader = Connect.getDataCommand(sSql, oConn).ExecuteReader();
                        while (rdReader.Read())
                        {
                            var sResult = rdReader["UserDefNum01"].ToString().Trim();
                            if (sResult == "0" & sResult == "2")
                            {
                                bDoPartial = false;
                            }
                        }
                        oConn.Close();
                    }
                    var sQty1 = calcDays(slActive);

                    if (slActive.txtUnitFormula.Text != "") //Check if calculation rule is used
                    {
                        bool bLineReturned = slActive.txtStatus.Text == "1";
                        sQty1 = Functions.CalculateQty_UnitRule(int.Parse(sQty1), slActive.txtUnitFormula.Text, bLineReturned, slActive.dtDelivery.Value, slActive.dtReturnDate.Value);
                    }
                    slActive.txtQuantity.Text = Convert.ToDecimal(sQty1).ToString("N2");
                    slActive.dtDelivery.Enabled = true;
                }
            }
        }

        private string GetPeriodEnd()
        {
            var sReturn = "";
            using (var oConn = new PsqlConnection(Connect.PastelConnectionString))
            {
                oConn.Open();
                var sSql = "Select NumberPeriodsThis, PerEndThis01, PerEndThis02, PerEndThis03, PerEndThis04, ";
                sSql += "PerEndThis05, PerEndThis06, PerEndThis07, PerEndThis08, PerEndThis09, PerEndThis10, ";
                sSql += "PerEndThis11, PerEndThis12, PerEndThis13,PerStartThis01, PerStartThis02, PerStartThis03, PerStartThis04, ";
                sSql += "PerStartThis05, PerStartThis06, PerStartThis07, PerStartThis08, PerStartThis09, PerStartThis10, ";
                sSql += "PerStartThis11, PerStartThis12, PerStartThis13, CurrentPeriod from LedgerParameters";

                var rdReader = Connect.getDataCommand(sSql, oConn).ExecuteReader();

                while (rdReader.Read())
                {
                    sReturn = Convert.ToDateTime(rdReader["PerEndThis" + rdReader["CurrentPeriod"].ToString().PadLeft(2, "0".ToCharArray()[0])]).ToString("MM/dd/yyyy");
                }
                rdReader.Close();
                oConn.Dispose();
            }
            return sReturn;
        }

        private void chkSaturday_CheckedChanged(object sender, EventArgs e)
        {
            cmdSaveOrder.Enabled = true;
            for (var iLines = 0; iLines < Saleslines.Length; iLines++)
            {
                var slActive = (SalesLineForm)Saleslines[iLines];

                var bDoPartial = true;
                if (slActive.txtCode.Text.Trim() != "'")
                {
                    using (var oConn = new PsqlConnection(Connect.PastelConnectionString))
                    {
                        var sSql = "Select UserDefNum01 From Inventory where ItemCode = '" + slActive.txtCode.Text.Trim() + "'";
                        var rdReader = Connect.getDataCommand(sSql, oConn).ExecuteReader();
                        while (rdReader.Read())
                        {
                            var sResult = rdReader["UserDefNum01"].ToString().Trim();
                            if (sResult == "0" & sResult == "2")
                            {
                                bDoPartial = false;
                            }
                        }
                    }
                    var sQty = calcDays(slActive);
                    slActive.txtQuantity.Text = Convert.ToDecimal(sQty).ToString("N2");
                }
            }
        }

        private void chkSundays_CheckedChanged(object sender, EventArgs e)
        {
            cmdSaveOrder.Enabled = true;
            for (var iLines = 0; iLines < Saleslines.Length; iLines++)
            {
                var slActive = (SalesLineForm)Saleslines[iLines];

                var bDoPartial = true;
                if (slActive.txtCode.Text.Trim() != "'")
                {
                    using (var oConn = new PsqlConnection(Connect.PastelConnectionString))
                    {
                        var sSql = "Select UserDefNum01 From Inventory where ItemCode = '" + slActive.txtCode.Text.Trim() + "'";
                        var rdReader = Connect.getDataCommand(sSql, oConn).ExecuteReader();
                        while (rdReader.Read())
                        {
                            var sResult = rdReader["UserDefNum01"].ToString().Trim();
                            if (sResult == "0" & sResult == "2")
                            {
                                bDoPartial = false;
                            }
                        }
                    }
                    var sQty = calcDays(slActive);
                    slActive.txtQuantity.Text = Convert.ToDecimal(sQty).ToString("N2");
                }
            }
        }

        private void selInvoices_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (selInvoices.Text == "" || selInvoices.Text.StartsWith("-")) return;

            Cursor = Cursors.WaitCursor;
            rptInvoice = Functions.getInvoiceReport(selInvoices.Text.Substring(0, selInvoices.Text.IndexOf("-")), "", "", "", "", "", "NormalPrint", Global.sLogedInUserCode);
            crystalReportViewer1.ReportSource = rptInvoice;
            Cursor = Cursors.Default;
        }

        private void cmdInvoice_Click(object sender, EventArgs e)
        {
            if (bInvoiceMode)
            {
                createNewInvoice();
                return;
            }
            using (var frmInvoice = new InvoiceOrder())
            {
                frmInvoice.frmSalesOrder = this;
                frmInvoice.sDocNumber = txtNumber.Text;
                frmInvoice.sCustomerCode = txtCustomerCode.Text;
                frmInvoice.sCustomerDescription = txtCustomerDescription.Text;
                frmInvoice.sDiscountPerc = txtDiscount.Text;
                frmInvoice.sDeliveryDate = dtDeliveryDate.Value.ToString("dd/MM/yyyy");
                frmInvoice.sOrderNumber = txtOrderNumber.Text;
                frmInvoice.sSiteName = selAddresses.Text.Trim();

                frmInvoice.frmMain = ((Main)this.MdiParent);
                if (frmInvoice.ShowDialog() == DialogResult.OK)
                {
                    loadSalesOrder(txtNumber.Text);
                }
            }
        }

        private void createNewInvoice()
        {
            var salesOrderWithLines = GetSalesorderWithLinesFromUi();
            var invoiceService = createInvoiceService();

            var invoice = invoiceService.CreateInvoice(salesOrderWithLines, DateTime.Now);

            if (invoice == null)
            {
                MessageBox.Show("There was an error creating this invoice.  Please consult the logfile", "Error Creating Invoice", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
            }

            if (MessageBox.Show("Invoice number " + invoice.Header.DocumentNumber + " is created.  Do you want to print the invoice?", "Message Box", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Cursor = Cursors.WaitCursor;
                Functions.printInvoice(invoice.Header.DocumentNumber, true, Global.sLogedInUserCode, printDialog1);
                Cursor = Cursors.Default;
            }
            cmdNewOrder_Click(null, null);
        }

        private InvoiceDomainService createInvoiceService()
        {
            var pastelService =
                new PastelService(new SdkSettings { User = Global.iPastelSdkUser, DataPath = Global.sDataPath, InvoiceUser = Global.iDefaultInvoiceUser });
            var salesOrderRepository = new SalesOrderRepository();
            var historyHeaderRepository = new HistoryHeaderRepository(RepoContext.LiquidConnectionString,
                RepoContext.PastelConnectionString);
            var invoiceRepository = new InvoiceRepository(RepoContext.LiquidConnectionString,
                RepoContext.PastelConnectionString);
            var ruleRepository = new RuleRepository(RepoContext.LiquidConnectionString);
            var invoiceLineRepo = new InvoiceLineRepository(RepoContext.LiquidConnectionString,
                RepoContext.PastelConnectionString);
            var roundingInfoRepo = new RoundingInfoRepository(RepoContext.LiquidConnectionString);
            var leaseLevyInfoRepo = new LeaseLevyInfoRepository(RepoContext.LiquidConnectionString);
            var holidayRepo = new HolidayRepository(RepoContext.LiquidConnectionString);
            return new InvoiceDomainService(salesOrderRepository, pastelService, invoiceRepository,
                historyHeaderRepository, null, ruleRepository, invoiceLineRepo, roundingInfoRepo, leaseLevyInfoRepo, holidayRepo, InvoiceTypeEnum.NewAddhoc);
        }

        private SalesorderWithLines GetSalesorderWithLinesFromUi()
        {
            var salesorderWithLines = new SalesorderWithLines
            {
                Header = GetHeaderDomainFromUi(),
                Lines = GetLinesFromGrid()
            };

            return salesorderWithLines;
        }

        private List<IDocumentLine> GetLinesFromGrid()
        {
            var salesorderLines = new List<IDocumentLine>();
            foreach (SalesLineForm salesline in Saleslines)
            {
                if (salesline.txtCode.Text.Trim() != "")
                    salesorderLines.Add(salesline.ToDomain());
                
            }
            return salesorderLines;
        }

        private SalesorderHeader GetHeaderDomainFromUi()
        {
            var customerRepository = new CustomerRepository(Connect.LiquidConnectionString,
                Connect.PastelConnectionString);

            var discountPerc = txtDiscount.Text == "" ? 0d : double.Parse(txtDiscount.Text);
            var header = new SalesorderHeader
            {
                DocumentNumber = txtNumber.Text,
                DocumentDate = dtDate.Value,
                Customer = customerRepository.GetByCode(txtCustomerCode.Text.Trim()),
                DiscountPercentage = discountPerc,
                OrderNumber = txtOrderNumber.Text,
                Message1 = txtMessage1.Text,
                Message2 = txtMessage2.Text,
                Message3 = txtMessage3.Text,
                DeliveryAddress = new Address
                {
                    Line1 = txtDelAd1.Text,
                    Line2 = txtDelAd2.Text,
                    Line3 = txtDelAd3.Text,
                    Line4 = txtDelAd4.Text,
                    Line5 = txtDelAd5.Text,
                },
                SalesCode = txtSalesCode.Text
            };

            return header;
        }

        private void chkInvoiceConsumables_CheckedChanged(object sender, EventArgs e)
        {
            for (var iLines = 0; iLines < Saleslines.Length; iLines++)
            {
                var slThisLine = (SalesLineForm)Saleslines[iLines];
                if (slThisLine.picReturned.Visible) continue;
                if (slThisLine.sLineType != "0" && slThisLine.sLineType != "2") continue;
                slThisLine.chkReturn.Checked = chkInvoiceConsumables.Checked;
            }
        }

        private void SetToFrontendInvoiceMode()
        {
            //this.cmdViewInvoiceMode.Image = global::Liquid.Properties.Resources.history2;
            bInvoiceMode = true;
            cmdSaveOrder.Enabled = false;
            tpSalesOrder.BackColor = Color.LightSteelBlue;
            tpShip.BackColor = Color.LightSteelBlue;
            txtCustomerDescription.BackColor = Color.LightSteelBlue;
            tpPostal.BackColor = Color.LightSteelBlue;
            pnlCodeLabel.BackColor = Color.LightSteelBlue;
            pnlDescriptionLabel.BackColor = Color.LightSteelBlue;
            pnlProjectLabel.BackColor = Color.LightSteelBlue;
            pnlDelLabel.BackColor = Color.LightSteelBlue;
            panel2.BackColor = Color.LightSteelBlue;
            panel61.BackColor = Color.LightSteelBlue;
            pnlUnitLabel.BackColor = Color.LightSteelBlue;
            pnlQtyLabel.BackColor = Color.LightSteelBlue;
            pnlDisLabel.BackColor = Color.LightSteelBlue;
            pnlDiscountLabel.BackColor = Color.LightSteelBlue;
            pnlExcPriceLabel.BackColor = Color.LightSteelBlue;
            pnlNettLabel.BackColor = Color.LightSteelBlue;
            panel25.BackColor = Color.LightSteelBlue;
            tpForecast.BackColor = Color.LightSteelBlue;
            txtPosAd1.BackColor = Color.LightSteelBlue;
            txtPosAd2.BackColor = Color.LightSteelBlue;
            txtPosAd3.BackColor = Color.LightSteelBlue;
            txtPosAd4.BackColor = Color.LightSteelBlue;
            pnlSalesOrderStatus.BackColor = Color.LightSteelBlue;
            lblReturnHeading.Text = "Invoice";
        }

        private void cmdViewInvoiceMode_Click(object sender, EventArgs e)
        {
            if (bInvoiceMode)
            {
                cmdSearchNumber.Enabled = true;
                txtNumber.Enabled = true;
                cmdSaveOrder.Enabled = true;
                bInvoiceMode = false;
                SetFrontEndToNormal();
                txtNumber.Focus();
            }
            else
            {
                SetToFrontendInvoiceMode();
                cmdSearchNumber.Enabled = false;
                txtNumber.Enabled = false;
                txtCustomerCode.Focus();
            }
        }

        private void cmdLockOrder_Click(object sender, EventArgs e)
        {
            if (txtNumber.Text == "*NEW*" & !bLockedStatus)
            {
                bLockedStatus = true;
                gbStatus.Visible = false;
                picLocked.Visible = true;
                lblLocked.Visible = true;
            }
            else if (txtNumber.Text == "*NEW*" & bLockedStatus)
            {
                bLockedStatus = true;
                gbStatus.Visible = true;
                picLocked.Visible = false;
                lblLocked.Visible = false;
            }
            else
            {
                if (bLockedStatus)
                {
                    bLockedStatus = false;
                    gbStatus.Visible = true;
                    picLocked.Visible = false;
                    lblLocked.Visible = false;
                    cmdSaveOrder.Enabled = true;
                    //loadSalesOrder(txtNumber.Text);
                }
                else
                {
                    bLockedStatus = true;
                    gbStatus.Visible = false;
                    picLocked.Visible = true;
                    lblLocked.Visible = true;
                }
            }
        }

        private void chkPublicHolidays_CheckedChanged(object sender, EventArgs e)
        {
            for (var iLines = 0; iLines < Saleslines.Length; iLines++)
            {
                var slActive = (SalesLineForm)Saleslines[iLines];

                var bDoPartial = true;
                if (slActive.txtCode.Text.Trim() != "'")
                {
                    using (var oConn = new PsqlConnection(Connect.PastelConnectionString))
                    {
                        var sSql = "Select UserDefNum01 From Inventory where ItemCode = '" + slActive.txtCode.Text.Trim() + "'";
                        var rdReader = Connect.getDataCommand(sSql, oConn).ExecuteReader();
                        while (rdReader.Read())
                        {
                            var sResult = rdReader["UserDefNum01"].ToString().Trim();
                            if (sResult == "0" & sResult == "2")
                            {
                                bDoPartial = false;
                            }
                        }
                    }

                    var sQty = calcDays(slActive);

                    slActive.txtQuantity.Text = Convert.ToDecimal(sQty).ToString("N2");
                }
            }
        }

        private string calcDays(SalesLineForm slActive)
        {
            var dateFunctionService = CreateDatesFunctionDomainService();
            var datePickerBackColor = Color.White;
            var days = dateFunctionService.CalculateDays(slActive.dtDelivery.Value, slActive.dtReturnDate.Value,
                new CalculateDaysSettings
                {
                    ExcludeHolidays = chkPublicHolidays.Checked,
                    ExcludeSundays = chkSundays.Checked,
                    ExcludeSaturdays = chkSaturday.Checked
                });
            if (days == -1)
            {
                datePickerBackColor = Color.Red;
            }

            slActive.dtDelivery.Parent.BackColor = datePickerBackColor;
            slActive.dtReturnDate.Parent.BackColor = datePickerBackColor;

            var sQty = days.ToString();
            return sQty;
        }

        private static DatesFunctionDomainService CreateDatesFunctionDomainService()
        {
            var holidayRepo = new HolidayRepository(Connect.LiquidConnectionString);
            return new DatesFunctionDomainService(holidayRepo);
        }

        private void chkContract_CheckedChanged(object sender, EventArgs e)
        {
            if (chkContract.Checked)
            {
                lblContract.Visible = true;
                dtContractDate.Visible = true;
            }
            else
            {
                lblContract.Visible = false;
                dtContractDate.Visible = false;
            }
        }

        private void cmdMarketerSearch_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            using (var frmMarkZoom = new MarketerZoom())
            {
                if (frmMarkZoom.ShowDialog() == DialogResult.OK)
                {
                    if (frmMarkZoom.sMarketerCode != "")
                    {
                        txtMarketer.Text = frmMarkZoom.sMarketerCode.Trim();
                    }
                }
                Cursor = Cursors.Default;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selAddresses.SelectedIndex > 0 && selAddresses.Text != "Main")
            {
                var DeliveryAddressService = new DeliveryAddressService();

                using(var custAddressHeaderRepo = new CustAddressHeaderRepository(Connect.LiquidConnectionString, Connect.PastelConnectionString))
                using (var SelectedAddressRepo = new DeliveryAddressesRepository(Connect.LiquidConnectionString,
                    Connect.PastelConnectionString))
                {
                    var deliveryAddressHeading = DeliveryAddressService.GetDeliveryAddressHeading(selAddresses.Text);
                    SelectedAddressRepo.DeleteAddressUsingCustomerCodeAndCustDelivCode(txtCustomerCode.Text, deliveryAddressHeading);
                    custAddressHeaderRepo.DeleteUsingCustomerCodeAndAddressHeader(txtCustomerCode.Text, deliveryAddressHeading);

                    selAddresses.Items.Remove(selAddresses.Text);
                    selAddresses.SelectedIndex = 0;
                }
            }
        }

        private void btnCustomerNotes_Click(object sender, EventArgs e)
        {
            //Customer Notes
            var loadCustomerNotes = new SpecialCustomerNotes();
            loadCustomerNotes.LoadCustomerNotes(txtCustomerCode.Text);
        }

        private void btnDeliveryNoteCheck_Click(object sender, EventArgs e)
        {
            // Audit delivery note
            string documentNumber = txtNumber.Text;
            using (var oConn = new PsqlConnection(Connect.LiquidConnectionString))
            {
                var test = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                
                oConn.Open();
                var sql = "UPDATE SOLHH ";
                sql += " SET SOLHH.AuditDate = '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' ";
                sql += " WHERE SOLHH.DocNumber = '" + documentNumber.Replace("'", "") + "' ";
                Connect.getDataCommand(sql, oConn).ExecuteNonQuery();
            }

            lbAudit.Text = DateTime.Now.ToString();
            pnlAudit.BackColor = Color.LimeGreen;
            btnConfirmAudit.Text = "Reconfirm Filling";
            btnRemoveAudit.Visible = true;
        }

        private void btnRemoveAudit_Click(object sender, EventArgs e)
        {
            // Audit delivery note
            string documentNumber = txtNumber.Text;
            using (var oConn = new PsqlConnection(Connect.LiquidConnectionString))
            {
                oConn.Open();
                var sql = "UPDATE SOLHH ";
                sql += " SET SOLHH.AuditDate = Null";
                sql += " WHERE SOLHH.DocNumber = '" + documentNumber.Replace("'", "") + "' ";
                Connect.getDataCommand(sql, oConn).ExecuteNonQuery();
            }

            lbAudit.Text = "";
            pnlAudit.BackColor = Color.Red;
            btnConfirmAudit.Text = "Confirm Filling";
            btnRemoveAudit.Visible = false;
        }

        private void txtLevyPercentage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void cmdCancleLevy_Click(object sender, EventArgs e)
        {
            txtLevyPercentage.Text = "0";
        }

        private void chkLinkMarketer_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLinkMarketer.Checked)
            {
                GetMarketingDetails();
                grpMarketing.Visible = true;
            }
            else
            {
                txtMarketer.Text = "";
                txtCategory.Text = "";
                selCommissionTipe.Text = "";
                txtCommissionFloor.Text = "";
                grpMarketing.Visible = false;
            }
        }

        private void cmdCategorySearch_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            using (var frmMarkCatZoom = new MarketingCategoryZoom())
            {
                if (frmMarkCatZoom.ShowDialog() == DialogResult.OK)
                {
                    if (frmMarkCatZoom.sResult != "")
                    {
                        txtCategory.Text = frmMarkCatZoom.sResult.Trim();
                    }
                }
                Cursor = Cursors.Default;
            }
        }

        private void chkUseOrderNumberAsConsolidate_CheckedChanged(object sender, EventArgs e)
        {
            txtConsolidateNr.Text = chkUseOrderNumberAsConsolidate.Checked ? txtOrderNumber.Text.Trim() : "";
        }
    }
}