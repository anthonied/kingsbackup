using CodeProject.SystemHotkey;
using Liquid.Domain;
using Liquid.Repository;
using Pervasive.Data.SqlClient;
using Liquid.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Liquid.Domain.DefinitionObjects.CustomerNotes;
using Liquid.Domain.Enums;
using Liquid.Services.CrudServices.CustomerNotes;
using Liquid.Services;
using System.ComponentModel;
using Liquid.Forms.Warnings;
using Liquid.Forms.Customers;

namespace Liquid.Finder
{
    public partial class CustomerView : Form
    {
        public Solsage_Pastel_API.solPastelSDK clsSDK = new Solsage_Pastel_API.solPastelSDK();
        public bool bCloseOnSave;
        public string sResult = "";
        private DataSet dsCustomerCategory = new DataSet();
        private List<Customer> customers = new List<Customer>();
        private Customer selectedCustomer;
        private BackgroundWorker backgroundWorker1;

       
        public CustomerView(string idNumber)
        {
        }

        public DialogResult ShowDialog(bool bCloseApp)
        {
            bCloseOnSave = bCloseApp;
            return ShowDialog();
        }

        public DialogResult ShowDialog(bool bCloseApp, string sCustomerCode)
        {
            txtAccountCode.Text = sCustomerCode;
            loadCustomer(false);
            bCloseOnSave = bCloseApp;
            return ShowDialog();
        }

        public CustomerView()
        {
            InitializeComponent();
            var searchCustomeHotKey = new SystemHotkey { Shortcut = Shortcut.CtrlF };


            searchCustomeHotKey.Pressed += cmdSearch_Click;
        }

        

        private void Customer_Load(object sender, EventArgs e)
        {
            txtAccountCode.CharacterCasing = CharacterCasing.Upper;
            toolTip1.SetToolTip(cmdSave, "Add/Save this customer to Pastel.");
            toolTip1.SetToolTip(cmdCancel, "Clear this customer form. Note you will lose all the current data in this form");
            toolTip1.SetToolTip(cmdSearch, "Existing customer lookup.");
            txtAccountCode.Focus();
            picAutoFormatCode.Visible = txtAccountCode.Text == "";
            selTaxCode.SelectedIndex = 5;

            dsCustomerCategory = new DataSet();
            using (var oConn = new PsqlConnection(Connect.PastelConnectionString))
            {
                oConn.Open();
                var sSql = "Select Convert(CCCODE,SQL_Varchar) + ' - ' + CCDesc as CustCode from CustomerCategories";
                dsCustomerCategory = Connect.getDataSet(sSql, "CustomerCategories", oConn);
                selCustomerCategory.DataSource = dsCustomerCategory.Tables["CustomerCategories"];
                selCustomerCategory.DisplayMember = "CustCode";
                oConn.Dispose();
            }

            var customerService = new CustomerDomainService();
            customers = customerService.GetAllCustomers(Connect.PastelConnectionString);
        }

        private void Customer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;

            cmdSave.Enabled = true;
            var cntSelectedControl = (Control)sender;
            e.SuppressKeyPress = true;
            SelectNextControl(cntSelectedControl, true, true, true, true);

            lblCash.ForeColor = ActiveControl.Name == "chkCash" ? Color.Orange : Color.Black;
        }

        private string GeneratePastelSaveString()
        {
            //Format Discount - Pastel Format
            double dCorrectDiscount = (Convert.ToDouble(txtDiscount.Text));


            string sSaveString = txtAccountCode.Text + "|";   //account code //1
            sSaveString += txtDescription.Text + "|"; //description //2

            //Postal address
            sSaveString += txtPostAdd1.Text + "|"; // Post Address 1  //3
            sSaveString += txtPostAd2.Text + "|"; // Post Address 2   //4
            sSaveString += txtPostAd3.Text + "|"; // Post Address 3    //5     
            sSaveString += txtPostAd4.Text + "||"; // Post Address 4  + 5   //7

            sSaveString += txtTelephone.Text + "|"; // Telephone    //8
            sSaveString += txtFax.Text + "|"; // Fax    //9
            sSaveString += txtContact.Text + "|"; // Contact    //10
            sSaveString += "N|"; // Tax Exemp   //11

            sSaveString += "|"; // Early Payments //settlement terms //12

            sSaveString += "|"; // Price List   //13
            sSaveString += txtSalesPerson.Text + "|"; // Sales Analysie Code    //14

            sSaveString += txtDelAd1.Text + "|"; // Delivery Address 1  //15
            sSaveString += txtDelAd2.Text + "|"; // Delivery Address 2  //16
            sSaveString += txtDelAd3.Text + "|"; // Delivery Address 3  //17
            sSaveString += txtDelAd4.Text + "||"; // Delivery Address 4 + 5 //19

            sSaveString += "N|"; // Blocked //20
            sSaveString += dCorrectDiscount.ToString("N2") + "|"; // Discount   //21			
            sSaveString += rdInclusive.Checked ?  "N|" : "Y|"; // Exclusive //22
            sSaveString += "|"; // Statements  //23
            if (rdOpenItem.Checked)
                sSaveString += "Y|"; // Open Item
            else
                sSaveString += "N|"; // Balance Forward

            //24
            // Customer Category
            string sCustomerCategory = "";
            if (selCustomerCategory.Text != "")
            {
                sCustomerCategory = Convert.ToInt16(selCustomerCategory.Text.Substring(0, selCustomerCategory.Text.IndexOf('-'))).ToString("00");
            }
            sSaveString += sCustomerCategory + "|"; // Customer Category    //25

            sSaveString += "00|"; // Currency   //26

            // Payment Terms
            string sPayment = "";
            switch (selPaymentTerms.Text)
            {
                case "Current":
                    sPayment = "0";
                    break;
                case "30 Days":
                    sPayment = "30";
                    break;
                case "60 Days":
                    sPayment = "60";
                    break;
                case "90 Days":
                    sPayment = "90";
                    break;
                case "120 Days":
                    sPayment = "120";
                    break;
            }

            var sInterestFrom = "";
            switch (selInterestFrom.Text)
            {
                case "Current":
                    sInterestFrom = "0";
                    break;
                case "30 Days":
                    sInterestFrom = "30";
                    break;
                case "60 Days":
                    sInterestFrom = "60";
                    break;
                case "90 Days":
                    sInterestFrom = "90";
                    break;
                case "120 Days":
                    sInterestFrom = "120";
                    break;
            }

            sSaveString += sPayment + "|";  //27

            sSaveString += txtCreditLimit.Text + "|"; // Credit Limit   //28
            sSaveString += txtID.Text + "|"; // Use User Field 1 for ID //29
            sSaveString += txtRegistration.Text + "|"; // Use User Field 2 for Registration Number  //30
            sSaveString += txtDebtorsContact.Text + "|"; // Use User Field 3 for Registration Number    //31
            sSaveString += txtUserDefined4.Text + "|"; // Use User Field 4 for Registration Number  //32
            sSaveString += txtKingsContract.Text + "|"; // Use User Field 5 for Registration Number //33
            sSaveString += "M|"; //Month or Day //34

            //Stat Print or Email
            string sStatPrintMail = "";
            switch (selStatePrinting.Text)
            {
                case "Print Statement":
                    sStatPrintMail = "1";
                    break;
                case "Email Statement":
                    sStatPrintMail = "2";
                    break;
                case "Print & Email Statement":
                    sStatPrintMail = "3";
                    break;
                case "Don't Print/Email Statement":
                    sStatPrintMail = "4";
                    break;
            }
            sSaveString += sStatPrintMail + "|"; //Stat Print or Email  //35

            //Doc Print or Email
            string sDocPrintMail = "";
            switch (selDocPrinting.Text)
            {
                case "Print Document":
                    sDocPrintMail = "1";
                    break;
                case "Email Document":
                    sDocPrintMail = "2";
                    break;
                case "Print & Email Document":
                    sDocPrintMail = "3";
                    break;
            }
            sSaveString += sDocPrintMail + "|"; //Doc Print or Email    //36

            sSaveString += txtMobile.Text + "|"; // Cellphone   //37
            sSaveString += txtEmail.Text + "|"; // Email    //38
            sSaveString += "|"; // Freight  //39
            sSaveString += "|"; // Ship //40
            sSaveString += txtVAT.Text + "|"; // Tax Reference  //41

            string sCash = "N";
            if (chkCash.Checked)
            {
                sCash = "Y";
            }
            sSaveString += sCash + "|"; // Cash Customer    //42

            //todo implement new fields

            sSaveString += "|";//Contact for Documents //43
            sSaveString += "|"; //Document Contact’s email //44
            sSaveString += "|";//Contact for Statements    //45
            sSaveString += "|";//Statement Contact’s email //46
            sSaveString += "Y|";//Sole Proprietor    //47 Y = Company N = Sole Proprietor
            sSaveString += "|"; //Customer Name //48
            sSaveString += "|";//Customer Surname   //49
            sSaveString += "|";//Customer ID    //50
            sSaveString += "|";//Bank Name   //51
            sSaveString += "|";//Bank Type  //52 0 = Cheque / Current,1 = Savings,2 = Transmission 
            sSaveString += "1|";//Bank Account Relation  //53 0 = Own,1 = Joint,2 = Third Party
            sSaveString += "|";//Third Party ID //54
            sSaveString += "";//Passport Number //55
                                 //sSaveString += "25464|";//Bank Branch Number    //53
                                 //sSaveString += "254674454|";//Bank Account Number   //54

            return sSaveString;
        }

        private bool checkIfCustomerIdNumberExist()
        {
            var bIDExist = false;

            using (var oConn = new PsqlConnection(Connect.PastelConnectionString))
            {
                oConn.Open();

                var sCheckIDSql = "SELECT CustomerCode FROM CustomerMaster WHERE LTRIM(RTRIM(UserDefined01)) = '" + txtID.Text.Trim() + "'";

                var rdReader = Connect.getDataCommand(sCheckIDSql, oConn).ExecuteReader();
                if (rdReader.HasRows)
                {
                    bIDExist = true;
                    while (rdReader.Read())
                    {
                    }
                }

                oConn.Dispose();
            }
            return bIDExist;
        }

        private void SaveLiquidCustomerDetail()
        {
            using (var oConn = new PsqlConnection(Connect.LiquidConnectionString))
            {
                oConn.Open();
                var delSql = "delete From CustomerDetail where CustomerCode  = '" + txtAccountCode.Text.Trim() + "'";
                Connect.getDataCommand(delSql, oConn).ExecuteNonQuery();

                var sql =
                    string.Format(@"INSERT INTO CustomerDetail (CustomerCode,ConsolidatedCustomer,DepositAccountCode, FraudId)
                                           VALUES ('{0}','{1}','{2}','{3}')", txtAccountCode.Text.Trim(),
                        Convert.ToInt32(chkConsolidatedCustomer.Checked), txtDepositAccountCode.Text, txtFraudCode.Text);

                Connect.getDataCommand(sql, oConn).ExecuteNonQuery();
                oConn.Dispose();
            }
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            var bSave = true;

            if (selCustomerCategory.Text.TrimEnd() != "21 - DEPOSITOS")
            {
                // Field Completed Validations
                if (txtAccountCode.Text == "")
                {
                    MessageBox.Show("Account Code is a compulsory fields. Please supply a value.", "Compulsory Field", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtAccountCode.Focus();
                    Cursor = Cursors.Default;
                    return;
                }
                if (txtContact.Text == "")
                {
                    MessageBox.Show("Contact Name is a compulsory fields. Please supply a value.", "Compulsory Field", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtContact.Focus();
                    Cursor = Cursors.Default;
                    return;
                }
                if (txtID.Text == "")
                {
                    MessageBox.Show("ID Number is a compulsory fields. Please supply a value.", "Compulsory Field", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtID.Focus();
                    Cursor = Cursors.Default;
                    return;
                }

                var bIdExist = checkIfCustomerIdNumberExist();

                if (bIdExist)
                {
                    if (MessageBox.Show(string.Format("The ID Number ({0}) already exist. Do you want to continue?", txtID.Text), "Existing ID Number", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    {
                        bSave = false;
                    }
                }
            }

            if (bSave)
            {
                //Import Customer To Pastel
                var customer = getCustomerFromForm();

                var saveString = GeneratePastelSaveString();

                var clsSdk = new Solsage_Pastel_API.solPastelSDK();

                var sReturn = clsSdk.AddCustomer(saveString, Global.sDataPath);
                if (sReturn != "0")
                {
                    MessageBox.Show(sReturn, "Error on save", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    updateCustomerNonSdkFields(customer);

                    cmdSave.Enabled = false;
                }

                var note = getNoteFromForm();

                if (note != null)
                {
                    var customerNoteCrudService = new CustomerNoteCrudService(Connect.LiquidConnectionString, Connect.PastelConnectionString);
                    customerNoteCrudService.DeleteByIdNumberAndCustomerCode(note.IdNumber, note.CustomerCode);
                    customerNoteCrudService.Create(note);
                }

                Cursor = Cursors.Default;

                if (bCloseOnSave)
                {
                    sResult = txtAccountCode.Text;
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }

            SaveLiquidCustomerDetail();
            Cursor = Cursors.Default;
            cmdSave.Enabled = true;
            //var customerService = new CustomerDomainService();
            // = customerService.GetAllCustomers(Connect.PastelConnectionString);
            clearForm();
        }


        private CustomerNote getNoteFromForm()
        {
            var noteNote = txtNote.Text.Trim();
            return noteNote == ""
                ? null
                : new CustomerNote
                {
                    IdNumber = txtID.Text,
                    CustomerCode = txtAccountCode.Text,
                    Note = noteNote
                };
        }

        private void updateCustomerNonSdkFields(Customer customer)
        {
            var customerRepo = new CustomerRepository(Connect.LiquidConnectionString, Connect.PastelConnectionString);
            customerRepo.UpdateNonSdkFields(customer);
        }

        private Customer getCustomerFromForm()
        {
            return new Customer
            {
                CustomerCode = txtAccountCode.Text,
                InterestAfter = EnumHelper.GetInterestEnumFromText(selInterestFrom.Text),
                DefaultTax = (DefaultTaxEnum)selDefaultTaxType.SelectedIndex,
                TaxCode =  (TaxCodeEnum)selTaxCode.SelectedIndex,
                TaxInclusive = rdInclusive.Checked
            };
        }

        private string findCustomerDelivery()
        {
            var aKeyValues = new string[5];
            aKeyValues[0] = txtAccountCode.Text;
            aKeyValues[1] = "   ";
            var clsSdk = new Solsage_Pastel_API.solPastelSDK();
            return (clsSdk.Read_Record("ACCDELIV", 4, 0, aKeyValues, Global.sDataPath));
        }

        private void txtAccountCode_Leave(object sender, EventArgs e)
        {
            if (txtAccountCode.ReadOnly == false)
            {
                cmdSave.Enabled = true;
                loadCustomer(true);
            }
        }

        private void GetPastelCustomerDetails(bool bAlertMessage)
        {
            txtAccountCode.ReadOnly = true;
            txtAccountCode.Text = txtAccountCode.Text.ToUpper();
            var aDeliveryRecord = findCustomerDelivery().Split("|".ToCharArray());
            if (aDeliveryRecord.Length <= 1) return;
            //string[] aMasterRecord = findCustomerHeader().Split("|".ToCharArray()).ToList();
            var sPost1 = "";
            var sPost2 = "";
            var sPost3 = "";
            var sPost4 = "";
            var sUser1 = "";
            var sUser2 = "";
            var sUser3 = "";
            var sUser4 = "";
            var sUser5 = "";
            var sDescription = "";
            var sVAT = "";
            var sPaymentT = "";
            var sDiscount = "";
            var sCreate = "";
            var sCreditLimit = "";
            var sCategory = "";
            var sOpenItem = "";
            var sStatement = "";
            var sDocument = "";
            var sInterestAfter = "";
            var inclusive = false;
            var defaultTax = "";
            var taxCode = "";
            var incExc = "";
            using (var oConn = new PsqlConnection(Connect.PastelConnectionString))
            {
                oConn.Open();

                var sSql1 = "Select CreateDate From CustomerMaster where CustomerCode = '" + txtAccountCode.Text + "'";
                try
                {
                    Connect.getDataCommand(sSql1, oConn).ExecuteReader();
                }
                catch
                {
                    sSql1 = "Update CustomerMaster set CreateDate = '1977-07-07' where CustomerCode = '" + txtAccountCode.Text + "'";
                    Connect.getDataCommand(sSql1, oConn).ExecuteNonQuery();
                }

                var sSql = "Select * From CustomerMaster where CustomerCode = '" + txtAccountCode.Text + "'";
                var rdReader = Connect.getDataCommand(sSql, oConn).ExecuteReader();
                while (rdReader.Read())
                {
                    sCategory = rdReader["Category"].ToString();
                    sOpenItem = rdReader["OpenItem"].ToString();
                    sStatement = rdReader["StatPrintorEmail"].ToString();
                    sPost1 = rdReader["PostAddress01"].ToString();
                    sPost2 = rdReader["PostAddress02"].ToString();
                    sPost3 = rdReader["PostAddress03"].ToString();
                    sPost4 = rdReader["PostAddress04"].ToString();
                    sUser1 = rdReader["UserDefined01"].ToString();
                    sUser2 = rdReader["UserDefined02"].ToString();
                    sUser3 = rdReader["UserDefined03"].ToString();
                    sUser4 = rdReader["UserDefined04"].ToString();
                    sUser5 = rdReader["UserDefined05"].ToString();
                    sDescription = rdReader["CustomerDesc"].ToString();
                    sVAT = rdReader["ExemptRef"].ToString();
                    sPaymentT = rdReader["PaymentTerms"].ToString();
                    sDiscount = (double.Parse(rdReader["Discount"].ToString()) / 100).ToString();
                    sInterestAfter = rdReader["InterestAfter"].ToString();
                    sCreate = rdReader["CreateDate"].ToString();
                    sCreditLimit = rdReader["CreditLimit"].ToString();
                    sDocument = rdReader["DocPrintorEmail"].ToString();
                    defaultTax = rdReader["OverRideTax"].ToString();
                    taxCode = rdReader["TaxCode"].ToString();
                    incExc = rdReader["IncExc"].ToString();
                }

                rdReader.Close();
                oConn.Close();
            }
            if (aDeliveryRecord[0] != "0" || aDeliveryRecord[1] != txtAccountCode.Text) return;

            var drMessage = DialogResult.No;

            if (bAlertMessage)
            {
                drMessage = MessageBox.Show("This customer record exists in the database. Do you want to load this customer data?", "Record Exist", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            }

            if (bAlertMessage && drMessage != DialogResult.Yes)
            {
                txtAccountCode.Text = "";
                txtAccountCode.Focus();
                clearForm();
                return;
            }
            txtContact.Text = aDeliveryRecord[4].Trim();
            txtTelephone.Text = aDeliveryRecord[5].Trim();
            txtMobile.Text = aDeliveryRecord[6].Trim();
            txtFax.Text = aDeliveryRecord[7].Trim();
            txtEmail.Text = aDeliveryRecord[13].Trim();

            txtDelAd1.Text = aDeliveryRecord[8].Trim();
            txtDelAd2.Text = aDeliveryRecord[9].Trim();
            txtDelAd3.Text = aDeliveryRecord[10].Trim();
            txtDelAd4.Text = aDeliveryRecord[11].Trim();

            txtPostAdd1.Text = sPost1.Trim();
            txtPostAd2.Text = sPost2.Trim();
            txtPostAd3.Text = sPost3.Trim();
            txtPostAd4.Text = sPost4.Trim();
            txtDescription.Text = sDescription.Trim();

            var sPaymentTerms = sPaymentT;
            if (sPaymentTerms == "0")
            {
                sPaymentTerms = "Current";
            }
            else
            {
                sPaymentTerms += " Days";
            }
            selPaymentTerms.Text = "";
            selPaymentTerms.SelectedText = sPaymentTerms;

            txtVAT.Text = sVAT.Trim();
            txtRegistration.Text = sUser2.Trim(); // User Defined Field 2
            txtDebtorsContact.Text = sUser3.Trim(); // User Defined Field 3
            txtUserDefined4.Text = sUser4.Trim(); // User Defined Field 4
            txtKingsContract.Text = sUser5.Trim(); // User Defined Field 5
            txtDiscount.Text = sDiscount.Trim();
            txtCreation.Text = sCreate;
            txtSalesPerson.Text = aDeliveryRecord[3];

            //get sales name
            var aKeyValuesSales = new string[5];
            aKeyValuesSales[0] = txtSalesPerson.Text;
            var aSalesInfo =
                clsSDK.Read_Record("ACCSALE", 7, 0, aKeyValuesSales, Global.sDataPath).Split("|".ToCharArray());
            txtSalesName.Text = aSalesInfo[2].Trim();

            var sID = sUser1.Trim();
            if (sID == "User Defined 1")
            {
                sID = "";
            }
            txtID.Text = sID; // User Defined Field 1

            txtCreditLimit.Text = sCreditLimit;

            //Open Item - Balance Forward
            if (sOpenItem.Trim() == "\0")
            {
                rbBalanceForward.Checked = true;
                rdOpenItem.Checked = false;
            }
            else
            {
                rbBalanceForward.Checked = false;
                rdOpenItem.Checked = true;
            }
            rbBalanceForward.Enabled = false;
            rdOpenItem.Enabled = false;

            rdInclusive.Checked = incExc == "1";
            rdExclusive.Checked = !rdInclusive.Checked;
            switch (sInterestAfter)
            {
                case "":
                    selInterestFrom.SelectedIndex = 0;
                    break;

                case "0":
                    selInterestFrom.SelectedIndex = 1;
                    break;

                case "30":
                    selInterestFrom.SelectedIndex = 2;
                    break;

                case "60":
                    selInterestFrom.SelectedIndex = 3;
                    break;

                case "90":
                    selInterestFrom.SelectedIndex = 4;
                    break;

                case "12":
                    selInterestFrom.SelectedIndex = 5;
                    break;
                default:
                    selInterestFrom.SelectedIndex = 0;
                    break;
            }

            //Statement Print-Mail
            switch (sStatement.Trim())
            {
                case "1":
                    selStatePrinting.Text = "Print Statement";
                    break;

                case "2":
                    selStatePrinting.Text = "Email Statement";
                    break;

                case "3":
                    selStatePrinting.Text = "Print & Email Statement";
                    break;

                case "4":
                    selStatePrinting.Text = "Don't Print/Email Statement";
                    break;
            }

            //Document Print-Mail
            switch (sDocument.Trim())
            {
                case "1":
                    selDocPrinting.Text = "Print Document";
                    break;

                case "2":
                    selDocPrinting.Text = "Email Document";
                    break;

                case "3":
                    selDocPrinting.Text = "Print & Email Document";
                    break;
            }

            //Customer Category
            var sCustomerCode = "00 - None";
            if (sCategory.Trim() != "0")
            {
                using (var oConn = new PsqlConnection(Connect.PastelConnectionString))
                {
                    oConn.Open();
                    var sSql =
                        "Select Convert(CCCODE,SQL_Varchar) + ' - ' + CCDesc as CustCode from CustomerCategories where CCCODE = '" +
                        sCategory.Trim() + "'";
                    sCustomerCode = Connect.getDataCommand(sSql, oConn).ExecuteScalar().ToString();
                    oConn.Dispose();
                }
            }
            selCustomerCategory.Text = sCustomerCode;
            selDefaultTaxType.SelectedIndex = int.Parse(defaultTax);
            selTaxCode.SelectedIndex = int.Parse(taxCode);
            cmdSave.Enabled = true;

        }

        private void GetLiquidCustomerDetails()
        {
            using (var oConn = new PsqlConnection(Connect.LiquidConnectionString))
            {
                oConn.Open();
                var sSql = "Select ConsolidatedCustomer, DepositAccountCode, FraudId From CustomerDetail where CustomerCode = '" + txtAccountCode.Text.Trim() + "'";
                try
                {
                    var rdReader = Connect.getDataCommand(sSql,oConn).ExecuteReader();
                    while (rdReader.Read())
                    {
                        chkConsolidatedCustomer.Checked = rdReader["ConsolidatedCustomer"].ToString() != "0";
                        txtDepositAccountCode.Text = rdReader["DepositAccountCode"].ToString();
                        txtFraudCode.Text = rdReader["FraudId"].ToString();
                        this.gbFraud.BackColor = txtFraudCode.Text.Trim() != "" ? Color.Red : SystemColors.Control;
                    }
                }
                catch
                {
                    chkConsolidatedCustomer.Checked = false;
                    txtDepositAccountCode.Text = "";
                    txtFraudCode.Text = "";
                }

                oConn.Dispose();
            }
        }

        private void loadCustomer(bool bAlertMessage)
        {
            if (txtAccountCode.Text == "") return;

            GetPastelCustomerDetails(bAlertMessage);
            GetLiquidCustomerDetails();
        }

        private void clearForm()
        {
            txtAccountCode.Text = "";
            chkCash.Checked = false;
            txtDescription.Text = "";
            txtPostAdd1.Text = "";
            txtPostAd2.Text = "";
            txtPostAd3.Text = "";
            txtPostAd4.Text = "";
            txtDelAd1.Text = "";
            txtDelAd2.Text = "";
            txtDelAd3.Text = "";
            txtDelAd4.Text = "";
            txtCreation.Text = "";
            txtContact.Text = "";
            txtTelephone.Text = "";
            txtFax.Text = "";
            txtMobile.Text = "";
            txtEmail.Text = "";
            txtID.Text = "";
            txtVAT.Text = "";
            selPaymentTerms.Text = "Current";
            selInterestFrom.Text = "<NONE>";
            txtDiscount.Text = "0.00";
            txtEarly.Text = "00";
            txtAccountCode.ReadOnly = false;
            cmdSave.Enabled = false;
            txtSalesPerson.Text = "";
            txtSalesName.Text = "";
            txtCreditLimit.Text = "";
            txtKingsContract.Text = "";
            txtDebtorsContact.Text = "";
            picAutoFormatCode.Visible = true;
            selDefaultTaxType.SelectedIndex = 0;
            selTaxCode.SelectedIndex = 5;
            rbBalanceForward.Enabled = true;
            rdOpenItem.Enabled = true;
            rbBalanceForward.Checked = false;
            rdOpenItem.Checked = true;
            rdExclusive.Checked = false;
            rdInclusive.Checked = true;
            selDocPrinting.Text = "Print Document";
            selStatePrinting.Text = "Print Statement";
            selCustomerCategory.Text = "00 - None";
            txtRegistration.Text = "";
            txtDepositAccountCode.Text = "";
            chkConsolidatedCustomer.Checked = false;
            txtNote.Text = "";
        }

        private void lblCash_Enter(object sender, EventArgs e)
        {
            lblCash.ForeColor = Color.Orange;
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This action will clear all the data on the customer form. This action cannot be reversed. Do you want to reload this customer form?", "Clear Form", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                clearForm();
            }
        }

        private DataSet getCustomerDataSet()
        {
            var pastelConnection = new PsqlConnection(Classes.Connect.PastelConnectionString);
            pastelConnection.Open();

            var sql = string.Format(@"SELECT CustomerMaster.CustomerCode,Telephone, CustomerDesc,CustomerMaster.UserDefined01 'IDNumber',  if(Blocked = '1','Blocked','Active') 'Blocked'
                        FROM CustomerMaster
			            LEFT JOIN DeliveryAddresses on (CustomerMaster.CustomerCode = DeliveryAddresses.CustomerCode and DeliveryAddresses.Telephone <> '')
			            WHERE (CustomerMaster.CustomerCode LIKE '%{0}%' or '{0}' = '') 
			            AND (upper(CustomerMaster.CustomerDesc) LIKE '%{1}%' or '{1}' = '')            
			            ORDER BY CustomerMaster.CustomerCode ", txtAccountCode.Text.Replace("\r", ""), txtDescription.Text);



            var customerDataSet = Classes.Connect.getDataSet(sql, "Customers", pastelConnection);

            pastelConnection.Dispose();

            return customerDataSet;
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            using (var frmCustomerZoom = new CustomerZoom())
            {
                if (frmCustomerZoom.ShowDialog() == DialogResult.OK)
                {
                    if (frmCustomerZoom.CustomerCode != "")
                    {
                        selectCustomer(frmCustomerZoom.CustomerCode);

                        selectedCustomer = customers.FirstOrDefault(customer => customer.CustomerCode == frmCustomerZoom.CustomerCode);
                        var selectedCustomerIndex = customers.IndexOf(selectedCustomer);
                        previousButton.Visible = selectedCustomerIndex > 0 && selectedCustomerIndex <= customers.Count - 1;
                        nextButton.Visible = selectedCustomerIndex >= 0 && selectedCustomerIndex < customers.Count - 1;

                    }
                }
                Cursor = Cursors.Default;
            }
        }

        private void selectCustomer(string customerCode)
        {
            txtAccountCode.Text = customerCode;
            loadCustomer(false);
            picAutoFormatCode.Visible = false;

            gbAuthorisedPerson.Visible = true;

            fillAuthorisedPersons(customerCode);
        }

        private void previousButton_Click(object sender, EventArgs e)
        {
            var selectedCustomerIndex = customers.IndexOf(selectedCustomer);
            var previousCustomerIndex = selectedCustomerIndex - 1;

            selectedCustomer = customers[previousCustomerIndex];
            selectCustomer(selectedCustomer.CustomerCode);
            previousButton.Visible = previousCustomerIndex > 0;
            nextButton.Visible = previousCustomerIndex < customers.Count - 1;
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            var selectedCustomerIndex = customers.IndexOf(selectedCustomer);
            var nextCustomerIndex = selectedCustomerIndex + 1;

            selectedCustomer = customers[nextCustomerIndex];
            selectCustomer(selectedCustomer.CustomerCode);
            previousButton.Visible = nextCustomerIndex > 0;
            nextButton.Visible = nextCustomerIndex < customers.Count - 1;
        }

        private void fillAuthorisedPersons(string customerCode)
        {
            lbAuthorisedPersons.DataSource = getCustomerAuthorisedPersons(customerCode);

            var customerNoteCrudService = new CustomerNoteCrudService(Connect.LiquidConnectionString, Connect.PastelConnectionString);
            var note = customerNoteCrudService.GetByIdNumberAndCustomerCode(txtID.Text, txtAccountCode.Text);

            txtNote.Text = 
                note != null ?
                note.Note
                :
                "";
        }

        private List<string> getCustomerAuthorisedPersons(string customerCode)
        {
            var persons = new List<string>();

            using (var connection = new PsqlConnection(Connect.LiquidConnectionString))
            {
                var sql = String.Format("SELECT * FROM SOLAP WHERE customer_code = '{0}'", customerCode);
                var rdReader = Connect.getDataCommand(sql, connection).ExecuteReader();
                while (rdReader.Read())
                {
                    persons.Add(rdReader["authorised_person"].ToString());
                }
            }

            return persons.OrderBy(x => x).ToList();
        }

        private void enableSave(object sender, EventArgs e)
        {
            cmdSave.Enabled = true;
            if(checkValidId())
                checkForBalcklistById(txtID.Text);
        }

        public   void checkForBalcklistById(string zaId)
        {
            var api = new BlackListApiClient();
     
            var fraudster =  api.GetPossibleBlackListRecord(zaId);

            if (fraudster == null)
                return;
            
            BlackListWarning frmBlackListWarning = new BlackListWarning(fraudster.Id.ToString());
            frmBlackListWarning.lblNameInfo.Text = fraudster.Alias;
            frmBlackListWarning.lblCustomerIdInfo.Text = fraudster.ZaId.ToString() ;
            frmBlackListWarning.lblPhoneInfo.Text = fraudster.Phone.ToString() ;
            frmBlackListWarning.lblNameInfo.Text = fraudster.Name.ToString() ;
            frmBlackListWarning.lblSurnameInfo.Text = fraudster.Surname.ToString() ;
            frmBlackListWarning.lblEmailInfo.Text = fraudster.Email.ToString() ;
            frmBlackListWarning.lblCodeInfo.Text = fraudster.Code.ToString() ;
                        
            frmBlackListWarning.ShowDialog();          
        }


        private bool checkValidId()
        {

            if (txtID.Text.Length == 13)
            {

                return true;
            }
            else
            {
                return false;
            }
        }

        private void cmdSalesPerson_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            using (var frmSalesZoom = new SalesZoom())
            {
                if (frmSalesZoom.ShowDialog() == DialogResult.OK)
                {
                    if (frmSalesZoom.sResult != "")
                    {
                        txtSalesPerson.Text = frmSalesZoom.sResult;
                        txtSalesName.Text = frmSalesZoom.sName;
                    }
                }
                Cursor = Cursors.Default;
            }
        }

        private void txtCreditLimit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < '0') || (e.KeyChar > '9')) && e.KeyChar.ToString() != "\b")
            {
                e.Handled = true;
            }
        }

        private void cmdAdditionDelivery_Click(object sender, EventArgs e)
        {
            if (txtAccountCode.Text == "")
            {
                MessageBox.Show("Please select a customer to add additional contact information.", "No Customer Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Cursor = Cursors.WaitCursor;
                using (var frmContactDetails = new Forms.ContactDetails())
                {
                    frmContactDetails.ShowDialog(txtAccountCode.Text, txtDescription.Text, txtDelAd1.Text, txtDelAd2.Text, txtDelAd3.Text, txtDelAd4.Text);
                }
                Cursor = Cursors.Default;
            }
        }

        private void picAutoFormatCode_Click(object sender, EventArgs e)
        {
            if (txtAccountCode.Text.Length < 3)
            {
                MessageBox.Show("To \"auto fill\" the customer number there need to be at lease 3 charcaters as prefix.", "Prefix Needed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                using (var oPastel = new PsqlConnection(Connect.PastelConnectionString))
                {
                    oPastel.Open();
                    var iNewNumber = 1;
                    var sSql = "select max(CONVERT(substring(CustomerCode, length('" + txtAccountCode.Text + "')+1,length(CustomerCode) - (length('" + txtAccountCode.Text + "'))), SQL_FLOAT)) as currentNumber from CustomerMaster where CustomerCode like '" + txtAccountCode.Text + "%'";
                    var rdReader = Connect.getDataCommand(sSql, oPastel).ExecuteReader();
                    while (rdReader.Read())
                    {
                        if (rdReader["currentNumber"].ToString() != "")
                            iNewNumber = Convert.ToInt32(rdReader["currentNumber"].ToString()) + 1;
                    }
                    txtAccountCode.Text += iNewNumber.ToString().PadLeft(6 - txtAccountCode.Text.Length, "0".ToCharArray()[0]);
                    rdReader.Close();
                    oPastel.Close();
                    picAutoFormatCode.Visible = false;
                }
            }
        }

        private void cmdNote_Click(object sender, EventArgs e)
        {
            if (txtAccountCode.Text != "" && txtID.Text != "")
            {
                Cursor = Cursors.Default;
                var frmCustomerNotes = new Forms.CustomerNotes();
                frmCustomerNotes.txtAcountCode.Text = txtAccountCode.Text;
                frmCustomerNotes.txtID.Text = txtID.Text;
                frmCustomerNotes.Show();
                Cursor = Cursors.Default;
            }
            else if (txtAccountCode.Text == "")
            {
                MessageBox.Show("Account Code is a compulsory field. Please supply a value.", "Compulsory Field", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAccountCode.Focus();
            }
            else if (txtID.Text == "")
            {
                MessageBox.Show("ID Number is a compulsory field. Please supply a value.", "Compulsory Field", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtID.Focus();
            }
        }

        private void txtCreation_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void cmdAction_Click(object sender, EventArgs e)
        {
            if (txtAuthorisedPerson.Text != "")
            {
                using (var connection = new PsqlConnection(Connect.LiquidConnectionString))
                {
                    connection.Open();

                    var sql = String.Format("INSERT INTO SOLAP VALUES ('{0}','{1}')", txtAuthorisedPerson.Text, txtAccountCode.Text);
                    Connect.getDataCommand(sql, connection).ExecuteNonQuery();

                    connection.Close();
                }
                txtAuthorisedPerson.Text = "";

                fillAuthorisedPersons(txtAccountCode.Text);
            }
        }

        private void lbAuthorisedPersons_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void cmdRemove_Click(object sender, EventArgs e)
        {
            using (var connection = new PsqlConnection(Connect.LiquidConnectionString))
            {
                connection.Open();

                var sql = String.Format("DELETE FROM SOLAP WHERE authorised_person = '{0}'", lbAuthorisedPersons.SelectedItem);
                Connect.getDataCommand(sql, connection).ExecuteNonQuery();

                connection.Close();
            }

            fillAuthorisedPersons(txtAccountCode.Text);
        }

        private void txtSameAsPostal_Click(object sender, EventArgs e)
        {
            txtDelAd1.Text = txtPostAdd1.Text;
            txtDelAd2.Text = txtPostAd2.Text;
            txtDelAd3.Text = txtPostAd3.Text;
            txtDelAd4.Text = txtPostAd4.Text;
        }

        private void cmdNew_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            using (var walkinCustomerForm = new WalkInCustomer())
            {
                if (walkinCustomerForm.ShowDialog() == DialogResult.OK)
                {
                    var tempCustomer = walkinCustomerForm.TempCustomer;
                    txtID.Text = tempCustomer.IdNumber;
                    txtEmail.Text = tempCustomer.Email;
                    txtMobile.Text = tempCustomer.Phone;
                }
            }
        }
    }
}