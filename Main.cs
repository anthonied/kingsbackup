using Liquid.Domain;
using Liquid.Repository;
using Pervasive.Data.SqlClient;
using Liquid.Classes;
using Liquid.Finder;
using System;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Forms;
using Liquid.Domain.Interfaces;
using Liquid.Forms;

namespace Liquid
{
    [SuppressMessage("ReSharper", "LocalizableElement")]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public partial class Main : Form
    {
        private CustomerView _customerView;
        private DataSet dsRawItemLevel;

        //public PastelPartnerSDK SDK = new PastelPartnerSDK();
        public CodeProject.SystemHotkey.SystemHotkey systemHotkey1;

        public CodeProject.SystemHotkey.SystemHotkey systemHotkey2;

        public bool bDoGLonDeposit = true;
        public string[] aActiveComponents = new string[3];
        public string sReqDocNumbers = "";
        public DateTime dtFromDate = DateTime.Now;
        public DateTime dtToDate = DateTime.Now;
        public string sSQLFilter = "";
        private DataSet dsOpenOrders;

        public Main()
        {
            log4net.Config.XmlConfigurator.ConfigureAndWatch(new System.IO.FileInfo("C:\\LogConfig\\LiquidPastel.config"));

            InitializeComponent();

            //
            // systemHotkey1
            //
            systemHotkey1.Shortcut = Shortcut.F3;
            systemHotkey1.Pressed += new EventHandler(salesOrderToolStripMenuItem_Click);
            //
            // systemHotkey2

            //
            systemHotkey2.Shortcut = Shortcut.F4;
            systemHotkey2.Pressed += new EventHandler(manageCustomerToolStripMenuItem_Click);
        }

        ~Main()
        {
         
        }

        private void driversLicenseScannerRepo_IdNumberScanned(object sender, IdNumberScanEventArgs e)
        {
            MethodInvoker method = delegate
            {
                var customerCode = new CustomerRepository(Connect.LiquidConnectionString, Connect.PastelConnectionString).GetCustomerCodeByIdNumber(e.IdNumber);
                if (!string.IsNullOrEmpty(customerCode))
                {
                    if (_customerView != null)
                    {
                        _customerView.Close();
                        _customerView.Dispose();
                        _customerView = null;
                    }
                    _customerView = new CustomerView();
                    //customerView.MdiParent = this;
                    _customerView.ShowDialog(false, customerCode);
                }
                else
                {
                    MessageBox.Show(String.Format("Customer with Id '{0}' does not exist.", e.IdNumber), "Customer not found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            };
            BeginInvoke(method);
        }

        private void salesOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            if (checkOpenForm("Process Portal"))
            {
                var frmSalesOrder = new Documents.SalesOrder { MdiParent = this };

                frmSalesOrder.Show();
            }
            Cursor = Cursors.Default;
        }

        public void LoadnewSalesOrder(Documents.SalesOrder sopenSalesOrder)
        {
            sopenSalesOrder.Close();
            salesOrderToolStripMenuItem_Click(null, null);
        }

        private void manageCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            if (checkOpenForm("Customers"))
            {
                var frmCustomer = new CustomerView { MdiParent = this };
                frmCustomer.Show();
            }
            Cursor = Cursors.Default;
        }

        private bool checkOpenForm(string sForm)
        {
            Form[] aActiveChildren = MdiChildren;
            for (int i = 0; i < aActiveChildren.Length; i++)
            {
                if (aActiveChildren[i].Text == sForm)
                {
                    aActiveChildren[i].Focus();
                    MessageBox.Show(sForm + " allready open", "Document already open", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            return true;
        }

        private void companySetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            if (checkOpenForm("Company Setup"))
            {
                var frmCompanySetup = new Forms.Company_Setup { MdiParent = this };
                frmCompanySetup.Show();
            }
            Cursor = Cursors.Default;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            //get activecomponents
            string sActiveComponents = "hh";

            sActiveComponents = ConfigurationSettings.AppSettings.Get("ActiveComponents");

            if (sActiveComponents == null)
            {
                if (MessageBox.Show("Please specify ActiveComponents Parameters in Config file", "ActiveComponents Parameters", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                {
                    Application.Exit();
                }
            }
            if (sActiveComponents == "0")
                aActiveComponents = new string[6] { "1", "0", "0", "0", "0", "0" };
            if (sActiveComponents == "1")
                aActiveComponents = new string[6] { "0", "1", "0", "0", "0", "0" };
            if (sActiveComponents == "2")
                aActiveComponents = new string[6] { "0", "0", "1", "0", "0", "0" };
            if (sActiveComponents == "3")
                aActiveComponents = new string[6] { "0", "0", "0", "1", "0", "0" };
            if (sActiveComponents == "4")
                aActiveComponents = new string[6] { "0", "0", "0", "0", "1", "0" };
            if (sActiveComponents == "5")
                aActiveComponents = new string[6] { "0", "0", "0", "0", "0", "1" };
            //aActiveComponents = new string[6] { "0", "0", "0", "0", "0", "1" };
            // 0 = POS
            // 1 = Manufacturing
            // 2 = BUS
            // 3 = Sync
            // 4 = POS - Site Fasilities (Kings Hire)
            // 5 = DSNJHB

            if (Global.sLogedInUserName != "`1")
            {
                foreach (ToolStripMenuItem toolMenuItem in menuStrip1.Items)
                {
                    if (toolMenuItem != fileToolStripMenuItem)
                    {
                        toolMenuItem.Visible = false;

                        foreach (ToolStripDropDownItem toolMenuDropDownItem in toolMenuItem.DropDownItems)
                        {
                            toolMenuDropDownItem.Visible = false;
                            HideMenuItems(toolMenuDropDownItem);
                        }
                    }
                }
            }
          
            Generate clGenrate = new Generate();
            Global.sCurrFinPeriod = clGenrate.GetPeriodValue(DateTime.Now);
            Global.bUserMaxNewNumber = true;
            Global.sGlobalDefaultRule = "";
            Global.sGlobalDefaultRuleID = "";
            Global.bUseCalculationRules = false;

            if (aActiveComponents[0] == "1") //POS
            {
                //Documents
                documentsToolStripMenuItem.Visible = true;
                salesOrderToolStripMenuItem.Visible = true;
                invoicesToolStripMenuItem.Visible = true;
                //Customer
                customersToolStripMenuItem.Visible = true;
                manageCustomerToolStripMenuItem.Visible = true;
                //Administrator
                AdministratorToolStripMenuItem.Visible = true;
                bulkInvoicingToolStripMenuItem.Visible = true;
                itemCodeManagerToolStripMenuItem.Visible = true;
                duplicateInvoicesToolStripMenuItem.Visible = true;
                
                if (Global.sLogedInUserType == "1") //Administrator
                {
                    //Administrator
                    addUserToolStripMenuItem.Visible = true;
                    duplicateInvoicesToolStripMenuItem.Visible = true;
                    //Setup
                    setupToolStripMenuItem.Visible = true;
                    companySetupToolStripMenuItem.Visible = true;
                    emailAndFaxSendingToolStripMenuItem.Visible = true;
                    publicHolidaySetupToolStripMenuItem.Visible = true;
                    deliveryNoteMessagesToolStripMenuItem.Visible = true;

                    //Reports
                    avgTurnoverPerCustomerToolStripMenuItem.Visible = true;
                }
            }

            if (aActiveComponents[1] == "1") //Manu JR13 04/07/2011
            {
                //Documents
                documentsToolStripMenuItem.Visible = true;
                //Setup
                setupToolStripMenuItem.Visible = true;
                deliveryNoteMessagesToolStripMenuItem.Visible = true;

                //Reports
                productionSummaryToolStripMenuItem.Visible = true;
                salesOrderToolStripMenuItem.Visible = false;
                rawItemStockLevelToolStripMenuItem.Visible = false;
                invoicesToolStripMenuItem.Visible = false;

                if (Global.sLogedInUserType == "1") //Administrator
                {
                    //Manufacturing

                    //Batch Setup

                    //Administrator
                    AdministratorToolStripMenuItem.Visible = true;
                    addUserToolStripMenuItem.Visible = true;
                    duplicateInvoicesToolStripMenuItem.Visible = true;

                    //Setup
                    companySetupToolStripMenuItem.Visible = true;
                }
            }

            if (aActiveComponents[2] == "1") //BUS
            {
                //Documents
                documentsToolStripMenuItem.Visible = true;

                if (Global.sLogedInUserType == "1") //Administrator
                {
                    //Administrator
                    AdministratorToolStripMenuItem.Visible = true;
                    addUserToolStripMenuItem.Visible = true;
                    duplicateInvoicesToolStripMenuItem.Visible = true;
                    //Setup
                    setupToolStripMenuItem.Visible = true;
                    companySetupToolStripMenuItem.Visible = true;
                    deliveryNoteMessagesToolStripMenuItem.Visible = true;
                    //Reports
                }
            }

            if (aActiveComponents[3] == "1") //Sync
            {
                //Transfer
                documentTransferToolStripMenuItem.Visible = true;
                documentTransferToolStripMenuItem1.Visible = true;
                errorManagementToolStripMenuItem.Visible = true;

                if (Global.sLogedInUserType == "1") //Administrator
                {
                    //Administrator
                    AdministratorToolStripMenuItem.Visible = true;
                    addUserToolStripMenuItem.Visible = true;
                    duplicateInvoicesToolStripMenuItem.Visible = true;
                    //Setup
                    setupToolStripMenuItem.Visible = true;
                    companySetupToolStripMenuItem.Visible = true;
                 
                    deliveryNoteMessagesToolStripMenuItem.Visible = true;
                }
            }

            if (aActiveComponents[4] == "1") //POS - Site Fasilities
            {
                //Documents
                documentsToolStripMenuItem.Visible = true;
                salesOrderToolStripMenuItem.Visible = true;
                invoicesToolStripMenuItem.Visible = true;
                //Customer
                customersToolStripMenuItem.Visible = true;
                manageCustomerToolStripMenuItem.Visible = true;
                //Administrator
                AdministratorToolStripMenuItem.Visible = true;
                bulkInvoicingToolStripMenuItem.Visible = true;
                itemCodeManagerToolStripMenuItem.Visible = true;
                duplicateInvoicesToolStripMenuItem.Visible = true;

                //Reports
                emailAndFaxSendingToolStripMenuItem.Visible = true;
                publicHolidaySetupToolStripMenuItem.Visible = true;

                if (Global.sLogedInUserType == "1") //Administrator
                {
                    //Administrator
                    addUserToolStripMenuItem.Visible = true;
                    duplicateInvoicesToolStripMenuItem.Visible = true;
                    //Setup
                    setupToolStripMenuItem.Visible = true;
                    companySetupToolStripMenuItem.Visible = true;
                    ruleSetupToolStripMenuItem.Visible = true;
                    deliveryNoteMessagesToolStripMenuItem.Visible = true;
                    //Reports
                    avgTurnoverPerCustomerToolStripMenuItem.Visible = true;
                    itemCodeManagerToolStripMenuItem.Visible = true;
                }

                Global.bUseCalculationRules = true;
            }

            if (aActiveComponents[5] == "1") //DSN JHB
            {
                qoutesToolStripMenuItem.Visible = true;

                documentsToolStripMenuItem.Visible = true;
                AdministratorToolStripMenuItem.Visible = true;
                setupToolStripMenuItem.Visible = true;
                companySetupToolStripMenuItem.Visible = true;
                deliveryNoteToolStripMenuItem.Visible = true;
                returnNoteToolStripMenuItem.Visible = true;
                pickingSlipsToolStripMenuItem.Visible = true;
                if (Global.sLogedInUserType == "1") //Administrator
                {
                    //Administrator
                    AdministratorToolStripMenuItem.Visible = true;
                    addUserToolStripMenuItem.Visible = true;
                    duplicateInvoicesToolStripMenuItem.Visible = true;
                    customerNotesToolStripMenuItem.Visible = true;
                    //Setup
                    setupToolStripMenuItem.Visible = true;
                    companySetupToolStripMenuItem.Visible = true;
                }
            }
            //invoicesToolStripMenuItem1.Visible = true;

            invoiceSummaryToolStripMenuItem.Visible = true;
            customerNotesToolStripMenuItem.Visible = true;
            exportEmailAddressesToolStripMenuItem.Visible = true;
            Solsage_Pastel_API.solPastelSDK clsSDK = new Solsage_Pastel_API.solPastelSDK();
            string sRet = clsSDK.invokeSDK(Global.sDataPath);//Initialise the sdk
            if (sRet != "0")
            {
                MessageBox.Show("Error Failed to invoke Pastel SDK \r\n\r\n" + sRet, "SDK Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Restart();
            }

            using (PsqlConnection oConn = new PsqlConnection(Connect.LiquidConnectionString))
            {
                oConn.Open();
                string sSql = "Select * from SOLCS";

                PsqlDataReader rdReader = Connect.getDataCommand(sSql, oConn).ExecuteReader();
                while (rdReader.Read())
                {
                    Global.sCompanyName = rdReader["GroupName"].ToString().Trim();
                    Global.sRegName = rdReader["CompanyName"].ToString().Trim();
                    Global.sVAT = rdReader["VATNumber"].ToString().Trim();
                    Global.sReg = rdReader["RegistrationNum"].ToString().Trim();
                    Global.sCompanyTel = rdReader["TelephoneNumber"].ToString().Trim();
                    Global.sCompanyFax = rdReader["FaxNumber"].ToString().Trim();
                    Global.sCompanyAd1 = rdReader["Physical1"].ToString().Trim();
                    Global.sCompanyAd2 = rdReader["Physical2"].ToString().Trim();
                    Global.sCompanyAd3 = rdReader["Physical3"].ToString().Trim();
                    Global.sCompanyPostAd1 = rdReader["Postal1"].ToString().Trim();
                    Global.sCompanyPostAd2 = rdReader["Postal2"].ToString().Trim();
                    Global.sCompanyPostAd3 = rdReader["PostalZip"].ToString().Trim();
                    Global.sDeliveryNoteCompany = rdReader["DeliveryNoteCompany"].ToString();
                    Global.sInvoiceContactName = rdReader["InvoiceContactName"].ToString();
                    Global.sInvoiceContactNumber = rdReader["InvoiceContactNumber"].ToString();
                    Global.DefaultMultiStore = rdReader["StoreDefault"].ToString().Trim();
                    Global.sQuotePath = rdReader["QuotePath"].ToString().Trim();
                    try
                    {
                        Global.sTermsAndConditions = rdReader["DeliveryNoteTerms"].ToString().Trim();
                    }
                    catch
                    {
                        Global.sTermsAndConditions = "";
                    }

                    try
                    {
                        if (ConfigurationSettings.AppSettings.Get("UseQuantityMeasure") == "1")
                            Global.bUseQuantityMeasure = true;
                    }
                    catch
                    {
                        Global.bUseQuantityMeasure = false;
                    }

                    try
                    {
                        Global.sDefaultSlipPrinter = ConfigurationSettings.AppSettings.Get("SlipPrinter");
                    }
                    catch
                    {
                        Global.sDefaultSlipPrinter = rdReader["DefaultSlipPrinter"].ToString().Trim();
                    }
                    try
                    {
                        Global.sDefaultDocPrinter = ConfigurationSettings.AppSettings.Get("DocumentPrinter");
                    }
                    catch
                    {
                        Global.sDefaultDocPrinter = rdReader["DefaultDocPrinter"].ToString().Trim();
                    }
                    try
                    {
                        Global.sDeliveryNoteFirstPrintCopies = ConfigurationSettings.AppSettings.Get("DeliveryNoteFirstPrintCopies");
                    }
                    catch
                    {
                        Global.sDeliveryNoteFirstPrintCopies = rdReader["DellNoteFirst"].ToString().Trim();
                    }
                    try
                    {
                        Global.sDeliveryNoteDuplicatePrintCopies = ConfigurationSettings.AppSettings.Get("DeliveryNoteDuplicatePrintCopies");
                    }
                    catch
                    {
                        Global.sDeliveryNoteDuplicatePrintCopies = rdReader["DellNoteDuplicate"].ToString().Trim();
                    }
                    try
                    {
                        Global.sInvoiceFirstPrintCopies = ConfigurationSettings.AppSettings.Get("InvoiceFirstPrintCopies");
                    }
                    catch
                    {
                        Global.sInvoiceFirstPrintCopies = rdReader["InvoiceFirst"].ToString().Trim();
                    }
                    try
                    {
                        Global.sInvoiceDuplicatePrintCopies = ConfigurationSettings.AppSettings.Get("InvoiceDuplicatePrintCopies");
                    }
                    catch
                    {
                        Global.sInvoiceDuplicatePrintCopies = rdReader["InvoiceDuplicate"].ToString().Trim();
                    }

                    try
                    {
                        Global.sEmailAddressFrom1 = ConfigurationSettings.AppSettings.Get("MailAddressFrom1");
                    }
                    catch
                    {
                        Global.sEmailAddressFrom1 = "Magda@Kingshire.biz";
                    }
                    try
                    {
                        Global.sEmailAddressFrom2 = ConfigurationSettings.AppSettings.Get("MailAddressFrom2");
                    }
                    catch
                    {
                        Global.sEmailAddressFrom2 = "Magda@Kingshire.biz";
                    }
                    try
                    {
                        Global.sEmailAddressFrom3 = ConfigurationSettings.AppSettings.Get("MailAddressFrom3");
                    }
                    catch
                    {
                        Global.sEmailAddressFrom3 = "Magda@Kingshire.biz";
                    }
                    try
                    {
                        Global.sEmailPasswordFrom1 = ConfigurationSettings.AppSettings.Get("MailPasswordFrom1");
                    }
                    catch
                    {
                        Global.sEmailPasswordFrom1 = "";
                    }
                    try
                    {
                        Global.sEmailPasswordFrom2 = ConfigurationSettings.AppSettings.Get("MailPasswordFrom2");
                    }
                    catch
                    {
                        Global.sEmailPasswordFrom2 = "";
                    }
                    try
                    {
                        Global.sEmailPasswordFrom3 = ConfigurationSettings.AppSettings.Get("MailPasswordFrom3");
                    }
                    catch
                    {
                        Global.sEmailPasswordFrom3 = "";
                    }
                    try
                    {
                        Global.sSmtpClient = ConfigurationSettings.AppSettings.Get("SmtpClient");
                    }
                    catch
                    {
                        Global.sSmtpClient = "smtp.axxess.co.za";
                    }

                    try
                    {
                        Global.sSmtpOutgoing = ConfigurationSettings.AppSettings.Get("SmtpOutgoing");
                    }
                    catch
                    {
                        Global.sSmtpOutgoing = "smtp.kingshire.biz";
                    }

                    try
                    {
                        Global.sSmtpClientUserName = ConfigurationSettings.AppSettings.Get("SmtpClientUserName");
                    }
                    catch
                    {
                        Global.sSmtpClientUserName = "kings";
                    }

                    try
                    {
                        Global.sSmtpClientPassword = ConfigurationSettings.AppSettings.Get("SmtpClientPassword");
                    }
                    catch
                    {
                        Global.sSmtpClientPassword = "testpass";
                    }

                    try
                    {
                        Global.sSmtpClientPort = ConfigurationSettings.AppSettings.Get("SmtpClientPort");
                    }
                    catch
                    {
                        Global.sSmtpClientPort = "25";
                    }
                    try
                    {
                        Global.sEmailBody = ConfigurationSettings.AppSettings.Get("MailBody");
                    }
                    catch
                    {
                        Global.sEmailBody = "";
                    }
                    try
                    {
                        if (ConfigurationSettings.AppSettings.Get("Manufacturing") == "1")
                        {
                            Global.bManufacturing = true;
                        }
                        else
                        {
                            Global.bManufacturing = false;
                        }
                    }
                    catch
                    {
                        Global.bManufacturing = false;
                    }
                    try
                    {
                        if (ConfigurationSettings.AppSettings.Get("LogCreateDocument") == "1")
                        {
                            Global.bLogCreateDocument = true;
                        }
                        else
                        {
                            Global.bLogCreateDocument = false;
                        }
                    }
                    catch
                    {
                        Global.bLogCreateDocument = false;
                    }
                    Global.sDeliveryNoteTemplate = rdReader["DeliveryNoteTemplate"].ToString().Trim();
                    Global.sInvoiceTemplate = rdReader["InvoiceTemplate"].ToString().Trim();
                    Global.sQuoteTemplate = rdReader["QuoteTemplate"].ToString().Trim();
                    if (rdReader["DefaultSDKUser"].ToString().Trim() != "")
                    {
                        Global.iPastelSdkUser = Convert.ToInt32(rdReader["DefaultSDKUser"].ToString().Trim());
                    }
                    else
                    {
                        Global.iPastelSdkUser = 0;
                    }
                    if (rdReader["DefaultInvoiceUser"].ToString().Trim() != "")
                    {
                        Global.iDefaultInvoiceUser = Convert.ToInt32(rdReader["DefaultInvoiceUser"].ToString().Trim());
                    }
                    else
                    {
                        Global.iDefaultInvoiceUser = 0;
                    }
                    if (rdReader["AutoInvoiceOnReturn"].ToString() == "1")
                    {
                        Global.bAutoInvoiceOnReturn = true;
                    }
                    else
                    {
                        Global.bAutoInvoiceOnReturn = false;
                    }

                    if (aActiveComponents[4] == "1") //POS - Site Fasilities
                    {
                        Global.sGlobalDefaultRule = rdReader["sDefaultRuleName"].ToString().Trim();
                        Global.sGlobalDefaultRuleID = rdReader["iDefaultRuleId"].ToString().Trim();
                    }
                    else
                    {
                        Global.sGlobalDefaultRule = "";
                        Global.sGlobalDefaultRuleID = "";
                    }

                    if (rdReader["GenerateZeroInv"].ToString() == "True")
                    {
                        Global.bGenerateZeroInvoice = true;
                    }
                    else
                    {
                        Global.bGenerateZeroInvoice = false;
                    }

                    if (rdReader["AutoBlockCust"].ToString() == "True")
                    {
                        Global.bAutoBlockCustomer = true;
                    }
                    else
                    {
                        Global.bAutoBlockCustomer = false;
                    }

                    //JR 13 6/9/2011
                    if (rdReader["LiquidHandlesInvt"].ToString() == "True")
                        Global.bLiquidHandlesInvt = true;
                    else
                        Global.bLiquidHandlesInvt = false;

                    //********
                }
                //get returnitem status of user
                //check to see whether logged in user is allowed to return item?
                try
                {
                    string sSqlRI = "Select ReturnItem from SOLUS where Code = '" + Global.sLogedInUserCode + "'";
                    Global.iReturnItem = Convert.ToInt16(Connect.getDataCommand(sSqlRI, oConn).ExecuteScalar().ToString());
                    oConn.Dispose();
                }
                catch
                {
                    Global.iReturnItem = 0;
                    oConn.Dispose();
                }

                rdReader.Close();
                oConn.Dispose();
            }
            if (Global.bUseBackground)
            {
                BackgroundImage = Properties.Resources._09;
                BackgroundImageLayout = ImageLayout.Stretch;
            }
            Text = "Liquid [" + Global.sActiveCompanyName + "]";
        }

        private void HideMenuItems(ToolStripDropDownItem tsParentDropdownItem)
        {
            foreach (ToolStripDropDownItem tsChildDropdownItem in tsParentDropdownItem.DropDownItems)
            {
                tsChildDropdownItem.Visible = false;
                HideMenuItems(tsChildDropdownItem);
            }
        }

        private void addUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            if (checkOpenForm("Users"))
            {
                Forms.Users frmAdduser = new Forms.Users();
                frmAdduser.MdiParent = this;
                frmAdduser.Show();
                Cursor = Cursors.Default;
            }
        }

        private void bulkInvoicingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            if (!checkOpenForm("MonthEndProcessing")) return;
            var frmMonthEndProcessings = new Forms.MonthEndProcessings
            {
                MdiParent = this
            };
            frmMonthEndProcessings.Show();
            Cursor = Cursors.Default;
        }

        private void manufacturingToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                Application.Exit();
            }
            catch
            {
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Global.frmMain.Visible = false;
            Global.frmLogin.txtUserName.Text = "";
            Global.frmLogin.txtPassword.Text = "";
            Global.frmLogin.ActiveControl = Global.frmLogin.txtUserName;
            Global.frmLogin.Visible = true;
        }

        private void ruleSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            var frmRuleSetup = new Forms.RuleSetup {MdiParent = this};
            frmRuleSetup.Show();
            Cursor = Cursors.Default;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Application.Restart();
            Cursor = Cursors.Default;
        }
        
        private void invoicesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            if (checkOpenForm("Invoices"))
            {
                Documents.Invoices frmInvoices = new Documents.Invoices();
                frmInvoices.MdiParent = this;
                frmInvoices.Show();
            }
            Cursor = Cursors.Default;
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Test frmTest = new Test();
            frmTest.MdiParent = this;
            frmTest.Show();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Process.GetCurrentProcess().Kill();
                Application.Exit();
            }
            catch
            {
            }
        }

        private void publicHolidaySetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            Forms.PublicHoliday frmPublicHoliday = new Forms.PublicHoliday();
            frmPublicHoliday.MdiParent = this;
            frmPublicHoliday.Show();

            Cursor = Cursors.Default;
        }

        private void emailAndFaxSendingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            Forms.EmailAndFaxSend frmEmailAndFaxSend = new Forms.EmailAndFaxSend();
            frmEmailAndFaxSend.MdiParent = this;
            frmEmailAndFaxSend.Show();

            Cursor = Cursors.Default;
        }
        
        private void qoutesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            Forms.Qoutes.Qoute frmQoute = new Forms.Qoutes.Qoute();
            frmQoute.MdiParent = this;
            frmQoute.Show();

            Cursor = Cursors.Default;
        }

        public void LoadnewQoute(Forms.Qoutes.Qoute sopenQoute)
        {
            sopenQoute.Close();
            qoutesToolStripMenuItem_Click(null, null);
        }

        private void itemCodeManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            Forms.ItemCodeManager frmItemCodeManager = new Forms.ItemCodeManager();
            frmItemCodeManager.MdiParent = this;
            frmItemCodeManager.Show();

            Cursor = Cursors.Default;
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.documentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salesOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.invoicesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.qoutesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageCustomerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AdministratorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bulkInvoicingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.emailAndFaxSendingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportEmailAddressesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.duplicateInvoicesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemCodeManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.invoiceSummaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customerNotesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salesOrderExceptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.companySetupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ruleSetupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.publicHolidaySetupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deliveryNoteMessagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.documentTransferToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.documentTransferToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.errorManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deliveryNoteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.returnNoteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pickingSlipsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.avgTurnoverPerCustomerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rawItemStockLevelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productionSummaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.worksheetsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.businessUnitTrackingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setupToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.trackingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupSetupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.batchSetupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rawBatchSetupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recieveStockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.issueStockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.issueRawBatchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recieveOldStockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dsWorksheet1 = new Liquid.Datasets.dsWorksheet();
            this.systemHotkey1 = new CodeProject.SystemHotkey.SystemHotkey(this.components);
            this.systemHotkey2 = new CodeProject.SystemHotkey.SystemHotkey(this.components);
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsWorksheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.documentsToolStripMenuItem,
            this.customersToolStripMenuItem,
            this.AdministratorToolStripMenuItem,
            this.setupToolStripMenuItem,
            this.documentTransferToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(837, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.logOutToolStripMenuItem,
            this.exitToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.openToolStripMenuItem.Text = "Open...";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // logOutToolStripMenuItem
            // 
            this.logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            this.logOutToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.logOutToolStripMenuItem.Text = "Log Off";
            this.logOutToolStripMenuItem.Click += new System.EventHandler(this.logOutToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // documentsToolStripMenuItem
            // 
            this.documentsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salesOrderToolStripMenuItem,
            this.invoicesToolStripMenuItem,
            this.qoutesToolStripMenuItem});
            this.documentsToolStripMenuItem.Name = "documentsToolStripMenuItem";
            this.documentsToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
            this.documentsToolStripMenuItem.Text = "&Documents";
            // 
            // salesOrderToolStripMenuItem
            // 
            this.salesOrderToolStripMenuItem.Name = "salesOrderToolStripMenuItem";
            this.salesOrderToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.salesOrderToolStripMenuItem.Text = "&Sales Order";
            this.salesOrderToolStripMenuItem.Click += new System.EventHandler(this.salesOrderToolStripMenuItem_Click);
            // 
            // invoicesToolStripMenuItem
            // 
            this.invoicesToolStripMenuItem.Name = "invoicesToolStripMenuItem";
            this.invoicesToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.invoicesToolStripMenuItem.Text = "&Invoices";
            this.invoicesToolStripMenuItem.Click += new System.EventHandler(this.invoicesToolStripMenuItem_Click);
            // 
            // qoutesToolStripMenuItem
            // 
            this.qoutesToolStripMenuItem.Name = "qoutesToolStripMenuItem";
            this.qoutesToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.qoutesToolStripMenuItem.Text = "Quotes";
            this.qoutesToolStripMenuItem.Click += new System.EventHandler(this.qoutesToolStripMenuItem_Click);
            // 
            // customersToolStripMenuItem
            // 
            this.customersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manageCustomerToolStripMenuItem});
            this.customersToolStripMenuItem.Name = "customersToolStripMenuItem";
            this.customersToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.customersToolStripMenuItem.Text = "Customers";
            // 
            // manageCustomerToolStripMenuItem
            // 
            this.manageCustomerToolStripMenuItem.Name = "manageCustomerToolStripMenuItem";
            this.manageCustomerToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.manageCustomerToolStripMenuItem.Text = "Manage";
            this.manageCustomerToolStripMenuItem.Click += new System.EventHandler(this.manageCustomerToolStripMenuItem_Click);
            // 
            // AdministratorToolStripMenuItem
            // 
            this.AdministratorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addUserToolStripMenuItem,
            this.bulkInvoicingToolStripMenuItem,
            this.emailAndFaxSendingToolStripMenuItem,
            this.exportEmailAddressesToolStripMenuItem,
            this.duplicateInvoicesToolStripMenuItem,
            this.itemCodeManagerToolStripMenuItem,
            this.invoiceSummaryToolStripMenuItem,
            this.customerNotesToolStripMenuItem,
            this.salesOrderExceptionsToolStripMenuItem});
            this.AdministratorToolStripMenuItem.Name = "AdministratorToolStripMenuItem";
            this.AdministratorToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.AdministratorToolStripMenuItem.Text = "Admin";
            // 
            // addUserToolStripMenuItem
            // 
            this.addUserToolStripMenuItem.Name = "addUserToolStripMenuItem";
            this.addUserToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.addUserToolStripMenuItem.Text = "Add/Edit Users";
            this.addUserToolStripMenuItem.Click += new System.EventHandler(this.addUserToolStripMenuItem_Click);
            // 
            // bulkInvoicingToolStripMenuItem
            // 
            this.bulkInvoicingToolStripMenuItem.Name = "bulkInvoicingToolStripMenuItem";
            this.bulkInvoicingToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.bulkInvoicingToolStripMenuItem.Text = "Bulk Invoicing";
            this.bulkInvoicingToolStripMenuItem.Click += new System.EventHandler(this.bulkInvoicingToolStripMenuItem_Click);
            // 
            // emailAndFaxSendingToolStripMenuItem
            // 
            this.emailAndFaxSendingToolStripMenuItem.Name = "emailAndFaxSendingToolStripMenuItem";
            this.emailAndFaxSendingToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.emailAndFaxSendingToolStripMenuItem.Text = "Email Invoices";
            this.emailAndFaxSendingToolStripMenuItem.Click += new System.EventHandler(this.emailAndFaxSendingToolStripMenuItem_Click);
            // 
            // exportEmailAddressesToolStripMenuItem
            // 
            this.exportEmailAddressesToolStripMenuItem.Name = "exportEmailAddressesToolStripMenuItem";
            this.exportEmailAddressesToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.exportEmailAddressesToolStripMenuItem.Text = "Export Email Addresses";
            this.exportEmailAddressesToolStripMenuItem.Click += new System.EventHandler(this.exportEmailAddressesToolStripMenuItem_Click);
            // 
            // duplicateInvoicesToolStripMenuItem
            // 
            this.duplicateInvoicesToolStripMenuItem.Name = "duplicateInvoicesToolStripMenuItem";
            this.duplicateInvoicesToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.duplicateInvoicesToolStripMenuItem.Text = "Duplicate Invoices";
            this.duplicateInvoicesToolStripMenuItem.Click += new System.EventHandler(this.duplicateInvoicesToolStripMenuItem_Click);
            // 
            // itemCodeManagerToolStripMenuItem
            // 
            this.itemCodeManagerToolStripMenuItem.Name = "itemCodeManagerToolStripMenuItem";
            this.itemCodeManagerToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.itemCodeManagerToolStripMenuItem.Text = "ItemCode Manager";
            this.itemCodeManagerToolStripMenuItem.Click += new System.EventHandler(this.itemCodeManagerToolStripMenuItem_Click);
            // 
            // invoiceSummaryToolStripMenuItem
            // 
            this.invoiceSummaryToolStripMenuItem.Name = "invoiceSummaryToolStripMenuItem";
            this.invoiceSummaryToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.invoiceSummaryToolStripMenuItem.Text = "Invoice Summary";
            this.invoiceSummaryToolStripMenuItem.Click += new System.EventHandler(this.invoiceSummaryToolStripMenuItem_Click);
            // 
            // customerNotesToolStripMenuItem
            // 
            this.customerNotesToolStripMenuItem.Name = "customerNotesToolStripMenuItem";
            this.customerNotesToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.customerNotesToolStripMenuItem.Text = "Customer Notes";
            this.customerNotesToolStripMenuItem.Click += new System.EventHandler(this.customerNotesToolStripMenuItem_Click);
            // 
            // salesOrderExceptionsToolStripMenuItem
            // 
            this.salesOrderExceptionsToolStripMenuItem.Name = "salesOrderExceptionsToolStripMenuItem";
            this.salesOrderExceptionsToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.salesOrderExceptionsToolStripMenuItem.Text = "Sales Order Exceptions";
            this.salesOrderExceptionsToolStripMenuItem.Click += new System.EventHandler(this.insuranceExceptionsToolStripMenuItem_Click);
            // 
            // setupToolStripMenuItem
            // 
            this.setupToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.companySetupToolStripMenuItem,
            this.ruleSetupToolStripMenuItem,
            this.publicHolidaySetupToolStripMenuItem,
            this.deliveryNoteMessagesToolStripMenuItem});
            this.setupToolStripMenuItem.Name = "setupToolStripMenuItem";
            this.setupToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.setupToolStripMenuItem.Text = "Setup";
            // 
            // companySetupToolStripMenuItem
            // 
            this.companySetupToolStripMenuItem.Name = "companySetupToolStripMenuItem";
            this.companySetupToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.companySetupToolStripMenuItem.Text = "Company Setup";
            this.companySetupToolStripMenuItem.Click += new System.EventHandler(this.companySetupToolStripMenuItem_Click);
            // 
            // ruleSetupToolStripMenuItem
            // 
            this.ruleSetupToolStripMenuItem.Name = "ruleSetupToolStripMenuItem";
            this.ruleSetupToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.ruleSetupToolStripMenuItem.Text = "Rule Setup";
            this.ruleSetupToolStripMenuItem.Click += new System.EventHandler(this.ruleSetupToolStripMenuItem_Click);
            // 
            // publicHolidaySetupToolStripMenuItem
            // 
            this.publicHolidaySetupToolStripMenuItem.Name = "publicHolidaySetupToolStripMenuItem";
            this.publicHolidaySetupToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.publicHolidaySetupToolStripMenuItem.Text = "Public Holiday Setup";
            this.publicHolidaySetupToolStripMenuItem.Click += new System.EventHandler(this.publicHolidaySetupToolStripMenuItem_Click);
            // 
            // deliveryNoteMessagesToolStripMenuItem
            // 
            this.deliveryNoteMessagesToolStripMenuItem.Name = "deliveryNoteMessagesToolStripMenuItem";
            this.deliveryNoteMessagesToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.deliveryNoteMessagesToolStripMenuItem.Text = "Delivery Note Messages";
            this.deliveryNoteMessagesToolStripMenuItem.Click += new System.EventHandler(this.deliveryNoteMessagesToolStripMenuItem_Click);
            // 
            // documentTransferToolStripMenuItem
            // 
            this.documentTransferToolStripMenuItem.Name = "documentTransferToolStripMenuItem";
            this.documentTransferToolStripMenuItem.Size = new System.Drawing.Size(12, 20);
            // 
            // documentTransferToolStripMenuItem1
            // 
            this.documentTransferToolStripMenuItem1.Name = "documentTransferToolStripMenuItem1";
            this.documentTransferToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            // 
            // errorManagementToolStripMenuItem
            // 
            this.errorManagementToolStripMenuItem.Name = "errorManagementToolStripMenuItem";
            this.errorManagementToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            // 
            // deliveryNoteToolStripMenuItem
            // 
            this.deliveryNoteToolStripMenuItem.Name = "deliveryNoteToolStripMenuItem";
            this.deliveryNoteToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // returnNoteToolStripMenuItem
            // 
            this.returnNoteToolStripMenuItem.Name = "returnNoteToolStripMenuItem";
            this.returnNoteToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // pickingSlipsToolStripMenuItem
            // 
            this.pickingSlipsToolStripMenuItem.Name = "pickingSlipsToolStripMenuItem";
            this.pickingSlipsToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // avgTurnoverPerCustomerToolStripMenuItem
            // 
            this.avgTurnoverPerCustomerToolStripMenuItem.Name = "avgTurnoverPerCustomerToolStripMenuItem";
            this.avgTurnoverPerCustomerToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            // 
            // rawItemStockLevelToolStripMenuItem
            // 
            this.rawItemStockLevelToolStripMenuItem.Name = "rawItemStockLevelToolStripMenuItem";
            this.rawItemStockLevelToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            // 
            // productionSummaryToolStripMenuItem
            // 
            this.productionSummaryToolStripMenuItem.Name = "productionSummaryToolStripMenuItem";
            this.productionSummaryToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            // 
            // worksheetsToolStripMenuItem
            // 
            this.worksheetsToolStripMenuItem.Name = "worksheetsToolStripMenuItem";
            this.worksheetsToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // businessUnitTrackingToolStripMenuItem
            // 
            this.businessUnitTrackingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setupToolStripMenuItem1,
            this.trackingToolStripMenuItem,
            this.groupSetupToolStripMenuItem});
            this.businessUnitTrackingToolStripMenuItem.Name = "businessUnitTrackingToolStripMenuItem";
            this.businessUnitTrackingToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.businessUnitTrackingToolStripMenuItem.Text = "Business Unit Tracking";
            // 
            // setupToolStripMenuItem1
            // 
            this.setupToolStripMenuItem1.Name = "setupToolStripMenuItem1";
            this.setupToolStripMenuItem1.Size = new System.Drawing.Size(67, 22);
            // 
            // trackingToolStripMenuItem
            // 
            this.trackingToolStripMenuItem.Name = "trackingToolStripMenuItem";
            this.trackingToolStripMenuItem.Size = new System.Drawing.Size(67, 22);
            // 
            // groupSetupToolStripMenuItem
            // 
            this.groupSetupToolStripMenuItem.Name = "groupSetupToolStripMenuItem";
            this.groupSetupToolStripMenuItem.Size = new System.Drawing.Size(67, 22);
            // 
            // batchSetupToolStripMenuItem
            // 
            this.batchSetupToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rawBatchSetupToolStripMenuItem});
            this.batchSetupToolStripMenuItem.Name = "batchSetupToolStripMenuItem";
            this.batchSetupToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.batchSetupToolStripMenuItem.Text = "Batch Setup";
            // 
            // rawBatchSetupToolStripMenuItem
            // 
            this.rawBatchSetupToolStripMenuItem.Name = "rawBatchSetupToolStripMenuItem";
            this.rawBatchSetupToolStripMenuItem.Size = new System.Drawing.Size(67, 22);
            // 
            // recieveStockToolStripMenuItem
            // 
            this.recieveStockToolStripMenuItem.Name = "recieveStockToolStripMenuItem";
            this.recieveStockToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // issueStockToolStripMenuItem
            // 
            this.issueStockToolStripMenuItem.Name = "issueStockToolStripMenuItem";
            this.issueStockToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // issueRawBatchToolStripMenuItem
            // 
            this.issueRawBatchToolStripMenuItem.Name = "issueRawBatchToolStripMenuItem";
            this.issueRawBatchToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // recieveOldStockToolStripMenuItem
            // 
            this.recieveOldStockToolStripMenuItem.Name = "recieveOldStockToolStripMenuItem";
            this.recieveOldStockToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // dsWorksheet1
            // 
            this.dsWorksheet1.DataSetName = "dsWorksheet";
            this.dsWorksheet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // Main
            // 
            this.ClientSize = new System.Drawing.Size(837, 501);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
            this.Load += new System.EventHandler(this.Main_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsWorksheet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void deliveryNoteMessagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            var frmDeliveryMessageSetup = new Forms.DeliveryMessageSetup
            {
                MdiParent = this
            };
            frmDeliveryMessageSetup.Show();
            Cursor = Cursors.Default;
        }

        private void duplicateInvoicesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            var duplicateInvoiceForm = new Forms.DuplicateInvoices
            {
                MdiParent = this
            };
            duplicateInvoiceForm.Show();
            Cursor = Cursors.Default;
        }

        private void invoiceSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            var invoiceDetail = new Forms.MonthEndProcessing.View.InvoicedDetailView
            {
                MdiParent = this
            };
            invoiceDetail.Show();
            Cursor = Cursors.Default;
        }

        private void exportEmailAddressesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var exportEmailAddressesForm = new EmailExport()
            {
                MdiParent = this
            };

            exportEmailAddressesForm.Show();
        }

        private void customerNotesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var SpecialPriceListSetup = new SpecialPriceListSetup()
            {
                MdiParent = this
            };
            SpecialPriceListSetup.Show();
        }

        private void insuranceExceptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var InsuranceExceptions = new InsuranceExceptions()
            {
                MdiParent = this
            };

            InsuranceExceptions.Show();
        }
    }
}