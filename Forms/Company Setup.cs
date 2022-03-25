using System;
using System.Windows.Forms;
using Pervasive.Data.SqlClient;
using System.Configuration;
using Liquid.Classes;

namespace Liquid.Forms
{
	public partial class Company_Setup : Form
	{
		public Company_Setup()
		{
			InitializeComponent();
		}

		private void cmdSearchStore_Click(object sender, EventArgs e)
		{
			Cursor = Cursors.WaitCursor;
			using (Finder.StoreZoom frmStore = new Finder.StoreZoom())
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

		private void cmdCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private bool ValidateTextField(TextBox tField, string sMessage,string sTabName)
		{
			if (tField.Text == "")
			{
				MessageBox.Show(sMessage);
				tcSetup.SelectedTab = tcSetup.TabPages[sTabName];
				tField.Focus();
				return true;
			}
			else
				return false;

		}

		private void cmdSave_Click(object sender, EventArgs e)
		{
			PsqlConnection oConn = new PsqlConnection(Connect.LiquidConnectionString);
			oConn.Open();

			//Deposits
			string sGLonDeposit = "0";
			string sDepositCashPmtAllocate = "0";
			string sDeposEftGl = "0";
			string sDeposEftpmtAllo = "0";
			string sDepositToCustomerAccount = "0";
			string schkTransactionsForDeposits = "1";
            if (!chkTransactionsForDeposits.Checked)
            {
                schkTransactionsForDeposits = "0";
                if (rbDepositGL.Checked)
                {
                    if (ValidateTextField(txtDebitAccount, "The Field may not be blank", "tpDeposit"))
                        return;
                    if (ValidateTextField(txtCreditAccount, "The Field may not be blank", "tpDeposit"))
                        return;
                    sGLonDeposit = "1";
                }
                //else
                //{
                //    if (ValidateTextField(txtDebitAccount, "The Field may not be blank", "tpDeposit"))
                //        return;
                //}

                if (rbDepositAcc.Checked)
                {
                    sDepositToCustomerAccount = "1";
                }


                if (chkCashDepositPaymentAllocate.Checked)
                {
                    if (ValidateTextField(txtCashDepAllocateDebitCode, "The Field may not be blank", "tpDeposit"))
                        return;

                    sDepositCashPmtAllocate = "1";
                }
                else
                {
                    if (ValidateTextField(txtCashDepAllocateDebitCode, "The Field may not be blank", "tpDeposit"))
                        return;
                    if (ValidateTextField(txtCashDepAllocateCreditCode, "The Field may not be blank", "tpDeposit"))
                        return;
                }


                if (rbDepositGlEft.Checked)
                {
                    if (ValidateTextField(txtDepositEftDebitCode, "The Field may not be blank", "tpDeposit"))
                        return;
                    if (ValidateTextField(txtDepositEftCreditCode, "The Field may not be blank", "tpDeposit"))
                        return;
                    sDeposEftGl = "1";
                }
                //else
                //{
                //    if (ValidateTextField(txtDepositEftDebitCode, "The Field may not be blank", "tpDeposit"))
                //        return;
                //}


                if (chkDepEftPmtAllocate.Checked)
                {
                    if (ValidateTextField(txtDepEftPmtAllocateDebitCode, "The Field may not be blank", "tpDeposit"))
                        return;

                    sDeposEftpmtAllo = "1";
                }
                else
                {
                    if (ValidateTextField(txtDepEftPmtAllocateDebitCode, "The Field may not be blank", "tpDeposit"))
                        return;
                    if (ValidateTextField(txtDepEftPmtAllocateCreditCode, "The Field may not be blank", "tpDeposit"))
                        return;
                }
            }


            //Advance Payment
            string sAdvPmtCashGL = "0";
			string sAdvPmtCashAllo = "0";
			string sAdvPmtEftGL = "0";
			string sAdvPmtEftAllo = "0";
			string schkTransactionsForAdvPmt = "1";
			if (!chkTransactionsForAdvPmt.Checked)
			{
				schkTransactionsForAdvPmt = "0";
				if (rbAdvPmtCashGL.Checked)
				{
					if (ValidateTextField(txtAdvPmtCashDebitCode, "The Field may not be blank", "tabGlSetup2"))
						return;
					if (ValidateTextField(txtAdvPmtCashCreditCode, "The Field may not be blank", "tabGlSetup2"))
						return;
					sAdvPmtCashGL = "1";
				}
				//else
				//{
				//    if (ValidateTextField(txtAdvPmtCashDebitCode, "The Field may not be blank", "tabGlSetup2"))
				//        return;
				//}

				
				if (chkAdvPmtAlloCash.Checked)
				{
					if (ValidateTextField(txtAdvPmyAlloCashDebitCode, "The Field may not be blank", "tabGlSetup2"))
						return;

					sAdvPmtCashAllo = "1";
				}
				else
				{
					if (ValidateTextField(txtAdvPmyAlloCashDebitCode, "The Field may not be blank", "tabGlSetup2"))
						return;
					if (ValidateTextField(txtAdvPmyAlloCashCreditCode, "The Field may not be blank", "tabGlSetup2"))
						return;
				}
				
				if (rbAdvPmtEftGL.Checked)
				{
					if (ValidateTextField(txtAdvPmtEftDebitCode, "The Field may not be blank", "tabGlSetup2"))
						return;
					if (ValidateTextField(txtAdvPmtEftCreditCode, "The Field may not be blank", "tabGlSetup2"))
						return;
					sAdvPmtEftGL = "1";
				}
				//else
				//{
				//    if (ValidateTextField(txtAdvPmtEftDebitCode, "The Field may not be blank", "tabGlSetup2"))
				//        return;
				//}
				
				if (chkAdvPmtAlloEft.Checked)
				{
					if (ValidateTextField(txtAdvPmyAlloEftDebitCode, "The Field may not be blank", "tabGlSetup2"))
						return;

					sAdvPmtEftAllo = "1";
				}
				else
				{
					if (ValidateTextField(txtAdvPmyAlloEftDebitCode, "The Field may not be blank", "tabGlSetup2"))
						return;
					if (ValidateTextField(txtAdvPmyAlloEftCreditCode, "The Field may not be blank", "tabGlSetup2"))
						return;
				}
			}

			//Cash Payments
			string sProcessCashGL = "0";
			string sProcessCardGL = "0";
			string sProcessChequeGL = "0";

			if (!chkCashCustomerAllwaysLink.Checked)
			{
				if (rbCashSalesGL.Checked)
				{
					if (ValidateTextField(txtCashDebit, "The Field may not be blank", "tabGlSetup3"))
						return;
					if (ValidateTextField(txtCashCredit, "The Field may not be blank", "tabGlSetup3"))
						return;

					sProcessCashGL = "1";
				}
				else
				{
					if (ValidateTextField(txtCashDebit, "The Field may not be blank", "tabGlSetup3"))
						return;

				}
				
				if (rbCardSalesGL.Checked)
				{
					if (ValidateTextField(txtCardDebit, "The Field may not be blank", "tabGlSetup3"))
						return;
					if (ValidateTextField(txtCardCreditCode, "The Field may not be blank", "tabGlSetup3"))
						return;
					sProcessCardGL = "1";
				}
				else
				{
					if (ValidateTextField(txtCardDebit, "The Field may not be blank", "tabGlSetup3"))
						return;

				}
				
				if (rbChequeSalesGL.Checked)
				{
					if (ValidateTextField(txtChequeDebitCode, "The Field may not be blank", "tabGlSetup3"))
						return;
					if (ValidateTextField(txtChequeCreditCode, "The Field may not be blank", "tabGlSetup3"))
						return;
					sProcessChequeGL = "1";
				}
				else
				{
					if (ValidateTextField(txtChequeDebitCode, "The Field may not be blank", "tabGlSetup3"))
						return;
				}
			}
			if (selRoundingAccMethod.Text != "None" && txtRoundingNearest.Text == "0")
			{
				MessageBox.Show("Rounding To The Nearest field must be greater than Zero", "Rounding", MessageBoxButtons.OK, MessageBoxIcon.Error);
				txtRoundingNearest.Focus();
				return;
			}
			else if (selRoundingAccMethod.Text != "None" && txtRoundingNearest.Text == "")
			{
				if (ValidateTextField(txtRoundingNearest, "Rounding To The Nearest field may not be blank", "tpDefaults"))
					return;
			}
			string sCashCustomerAllocate = "0";
			if (chkCashCustomerAllwaysLink.Checked)
			{
				sCashCustomerAllocate = "1";
			}

            string sAutoInvoice;
            if (chkAutoInvoice.Checked)
            {
                sAutoInvoice = "1";
                Global.bAutoInvoiceOnReturn = true;
            }
            else
            {
                sAutoInvoice = "0";
                Global.bAutoInvoiceOnReturn = false; ;
            }

            string sRoundingCOD;
            if (chkRoundingCOD.Checked)
            {
                sRoundingCOD = "1";
                Global.bRoundingCOD = true;
            }
            else
            {
                sRoundingCOD = "0";
                Global.bRoundingCOD = false;
            }

            string sGenerateZeroValueInvoices = "0";
			if (chkGenerateZeroValInvoice.Checked)
			{
				sGenerateZeroValueInvoices = "1";
				Global.bGenerateZeroInvoice = true;
			}
			else
			{
				sGenerateZeroValueInvoices = "0";
				Global.bGenerateZeroInvoice = false;
			}

			string sAutoBlockCustomers = "0";
			if (chkAutoBlockCustomer.Checked)
			{
				sAutoBlockCustomers = "1";
				Global.bAutoBlockCustomer = true;
			}
			else
			{
				sAutoBlockCustomers = "0";
				Global.bAutoBlockCustomer = false;
			}

			string sNotifyIfCustomerOverCreditLimit = "0";
			if (chkNotifyIfCustOverLimit.Checked)
			{
				sNotifyIfCustomerOverCreditLimit = "1";
				Global.bNotifyIfcustoverCredtiLimit = true;
			}
			else
			{
				sNotifyIfCustomerOverCreditLimit = "0";
				Global.bNotifyIfcustoverCredtiLimit = false;
			}

			//***********
			//JR13 6/8/2011
			string sLiquidHandlesInventory = "0";
			if (chkLiquidHandlesInvt.Checked)
			{
				sLiquidHandlesInventory = "1";
				Global.bLiquidHandlesInvt = true;
			}
			else
			{
				sLiquidHandlesInventory = "0";
				Global.bLiquidHandlesInvt = false;
			}
			//***********
			
			//Setup printer in app.config   and email settings
			Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
			AppSettingsSection configSection = config.AppSettings;
			try
			{

				if (configSection != null)
				{
					if (configSection.IsReadOnly() == false && configSection.SectionInformation.IsLocked == false)
					{
						configSection.Settings["DocumentPrinter"].Value = txtDocPrinterName.Text;
						configSection.Settings["SlipPrinter"].Value = txtSlipPrinterName.Text;
						configSection.Settings["DeliveryNoteFirstPrintCopies"].Value = txtDeliveryNoteFirstPrintCopies.Text;
						configSection.Settings["DeliveryNoteDuplicatePrintCopies"].Value = txtDeliveryNoteDuplicatePrintCopies.Text;
						configSection.Settings["InvoiceFirstPrintCopies"].Value = txtInvoiceFirstPrintCopies.Text;
						configSection.Settings["InvoiceDuplicatePrintCopies"].Value = txtInvoiceDuplicatePrintCopies.Text;

						configSection.Settings["MailAddressFrom1"].Value = txtEmailAddressFrom1.Text;
						configSection.Settings["MailPasswordFrom1"].Value = txtEmailPasswordFrom1.Text;
						configSection.Settings["MailAddressFrom2"].Value = txtEmailAddressFrom2.Text;
						configSection.Settings["MailPasswordFrom2"].Value = txtEmailPasswordFrom2.Text;
						configSection.Settings["MailAddressFrom3"].Value = txtEmailAddressFrom3.Text;
						configSection.Settings["MailPasswordFrom3"].Value = txtEmailPasswordFrom3.Text;
						configSection.Settings["SmtpClientPort"].Value = txtSmtpClientPort.Text;
						configSection.Settings["SmtpClient"].Value = txtSmtpClient.Text;
						configSection.Settings["SmtpOutgoing"].Value = txtSmtpOutgoing.Text;
						configSection.Settings["SmtpClientUserName"].Value = txtSmtpUserName.Text;
						configSection.Settings["SmtpClientPassword"].Value = txtSmtpPassword.Text;
						configSection.Settings["MailBody"].Value = txtEmailBody.Text;
						config.Save(ConfigurationSaveMode.Modified);
						ConfigurationManager.RefreshSection("appSettings");
					}
				}
			}
			catch (ConfigurationException ex)
			{
				MessageBox.Show(ex.Message, "Configuration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}


			
			string sSql = "UPDATE SOLCS";
			sSql += " SET CompanyName = '" + txtCompanyName.Text.Trim()+ "'";
			sSql += " ,StoreDefault = '" + txtStore.Text.Trim() + "'";

			//JR
			sSql += " ,DefaultSDKUser = '" + txtDefSDKUser.Text.Trim() + "'";
			sSql += " ,DefaultDocPrinter = '" + txtDocPrinterName.Text.Trim() + "'";
			sSql += " ,DefaultSlipPrinter = '" + txtSlipPrinterName.Text.Trim() + "'";

			sSql += " ,GLonDeposit = '" + sGLonDeposit.Trim() + "'";
			sSql += " ,DepositDebit = '" + txtDebitAccount.Text.Trim() + "'";
			sSql += " ,DepositCredit = '" + txtCreditAccount.Text.Trim() + "'";
			sSql += " ,DepositDebitName = '" + txtDebitAccountName.Text.Trim() + "'";
			sSql += " ,DepositCreditName = '" + txtCreditAccountName.Text.Trim() + "'";
			sSql += " ,DeliveryNoteCompany = '" + txtDelCompany.Text.Trim() + "'";
			sSql += " ,DelNoteFirst = '" + txtDeliveryNoteFirstPrintCopies.Text.Trim() + "'";
			sSql += " ,DelNoteDuplicate = '" + txtDeliveryNoteDuplicatePrintCopies.Text.Trim() + "'";
			sSql += " ,InvoiceFirst = '" + txtInvoiceFirstPrintCopies.Text.Trim() + "'";
			sSql += " ,InvoiceDuplicate = '" + txtInvoiceDuplicatePrintCopies.Text.Trim() + "'";
			sSql += " ,InvoiceContactName = '" + txtInvoiceContactName.Text.Trim() + "'";
			sSql += " ,InvoiceContactNumber = '" + txtInvoiceContactNumber.Text.Trim() + "'";
			sSql += " ,RegistrationNum = '" + txtRegNumber.Text.Trim() + "'";
			sSql += " ,VATNumber = '" + txtVatNumber.Text.Trim() + "'";
			sSql += " ,Postal1 = '" + txtPostalAddress1.Text.Trim() + "'";
			sSql += " ,Postal2 = '" + txtPostalAddress2.Text.Trim() + "'";
			sSql += " ,Postal3 = '" + txtPostalAddress3.Text.Trim() + "'";
			sSql += " ,PostalZip = '" + txtPostalAddress4.Text.Trim() + "'";
			sSql += " ,Physical1 = '" + txtPhysicalAddress1.Text.Trim() + "'";
			sSql += " ,Physical2 = '" + txtPhysicalAddress2.Text.Trim() + "'";
			sSql += " ,Physical3 = '" + txtPhysicalAddress3.Text.Trim() + "'";
			sSql += " ,PhysicalZip = '" + txtPhysicalAddress4.Text.Trim() + "'";
			sSql += " ,TelephoneNumber = '" + txtTelephoneNumber.Text.Trim() + "'";
			sSql += " ,FaxNumber = '" + txtFaxNumber.Text.Trim() + "'";
			sSql += " ,GroupName = '" + txtGroupName.Text.Trim() + "'";
			sSql += " ,SalesDebit = '" + txtCashDebit.Text.Trim().Replace("\0","") + "'";
			sSql += " ,SalesCredit = '" + txtCashCredit.Text.Trim().Replace("\0", "") + "'";
			sSql += " ,SalesDebitName = '" + txtCashDebitName.Text.Trim().Replace("\0", "") + "'";
			sSql += " ,SalesCreditName = '" + txtCashCreditName.Text.Trim().Replace("\0", "") + "'";
			sSql += " ,DepositToCustAccount = '" + sDepositToCustomerAccount.Trim().Replace("\0", "") + "'";
			sSql += " ,SalesCardDebit = '" + txtCardDebit.Text.Trim().Replace("\0", "") + "'";
			sSql += " ,SalesCardCredit = '" + txtCardCreditCode.Text.Trim().Replace("\0", "") + "'";
			sSql += " ,SalesCardDebitName = '" + txtCardDebitName.Text.Trim().Replace("\0", "") + "'";
			sSql += " ,SalesCardCreditName = '" + txtCardCreditName.Text.Trim().Replace("\0", "") + "'";
			sSql += " ,ProcessCardGl = '" + sProcessCardGL.Trim().Replace("\0", "") + "'";
			sSql += " ,SalesChequeDebit = '" + txtChequeDebitCode.Text.Trim().Replace("\0", "") + "'";
			sSql += " ,SalesChequeCredit = '" + txtChequeCreditCode.Text.Trim().Replace("\0", "") + "'";
			sSql += " ,SalesChequeDebitName = '" + txtChequeDebitName.Text.Trim().Replace("\0", "") + "'";
			sSql += " ,SalesChequeCreditNam = '" + txtChequeCreditName.Text.Trim().Replace("\0", "") + "'";
			sSql += " ,ProcessChequeGl = '" + sProcessChequeGL.Trim().Replace("\0", "") + "'";
			sSql += " ,ProcessCashGL = '" + sProcessCashGL.Trim().Replace("\0", "") + "'";            
			sSql += " ,CashCustomerAllocate = '" + sCashCustomerAllocate + "'";
			sSql += " ,DepositCashPmtAllo = '" + sDepositCashPmtAllocate + "'";
			sSql += " ,DeposCashAlloDtCode = '" + txtCashDepAllocateDebitCode.Text.Trim().Replace("\0", "") + "'";
			sSql += " ,DeposCashAlloCrCode = '" + txtCashDepAllocateCreditCode.Text.Trim().Replace("\0", "") + "'";
			sSql += " ,DeposCashAlloDtName = '" + txtCashDepAllocateDebitName.Text.Trim().Replace("\0", "") + "'";
			sSql += " ,DeposCashAlloCrName = '" + txtCashDepAllocateCreditName.Text.Trim().Replace("\0", "") + "'";
			sSql += " ,DeposEftGl = '" + sDeposEftGl + "'";
			sSql += " ,DeposEftDebitCode = '" + txtDepositEftDebitCode.Text.Trim().Replace("\0", "") + "'";
			sSql += " ,DeposEftCreditCode = '" + txtDepositEftCreditCode.Text.Trim().Replace("\0", "") + "'";
			sSql += " ,DeposEftDebitName = '" + txtDepositEftDebitName.Text.Trim().Replace("\0", "") + "'";
			sSql += " ,DeposEftCreditName = '" + txtDepositEftCreditName.Text.Trim().Replace("\0", "") + "'";
			sSql += " ,DeposEftpmtAllo = '" + sDeposEftpmtAllo + "'";
			sSql += " ,DeposEftAlloDtCode = '" + txtDepEftPmtAllocateDebitCode.Text.Trim().Replace("\0", "") + "'";
			sSql += " ,DeposEftAlloCrCode = '" + txtDepEftPmtAllocateCreditCode.Text.Trim().Replace("\0", "") + "'";
			sSql += " ,DeposEftAlloDtName = '" + txtDepEftPmtAllocateDebitName.Text.Trim().Replace("\0", "") + "'";
			sSql += " ,DeposEftAlloCrName = '" + txtDepEftPmtAllocateCreditName.Text.Trim().Replace("\0", "") + "'";
			sSql += " ,AdvPmtCashGL = '" + sAdvPmtCashGL + "'";
			sSql += " ,AdvPmtCashDebitCode = '" + txtAdvPmtCashDebitCode.Text.Trim().Replace("\0", "") + "'";
			sSql += " ,AdvPmtCashCreditCode = '" + txtAdvPmtCashCreditCode.Text.Trim().Replace("\0", "") + "'";
			sSql += " ,AdvPmtCashDebitName = '" + txtAdvPmtCashDebitName.Text.Trim().Replace("\0", "") + "'";
			sSql += " ,AdvPmtCashCreditName = '" + txtAdvPmtCashCreditName.Text.Trim().Replace("\0", "") + "'";
			sSql += " ,AdvPmtCashAllo = '" + sAdvPmtCashAllo + "'";
			sSql += " ,AdvPmtCashAlloDtCode = '" + txtAdvPmyAlloCashDebitCode.Text.Trim().Replace("\0", "") + "'";
			sSql += " ,AdvPmtCashAlloCrCode = '" + txtAdvPmyAlloCashCreditCode.Text.Trim().Replace("\0", "") + "'";
			sSql += " ,AdvPmtCashAlloDtName = '" + txtAdvPmyAlloCashDebitName.Text.Trim().Replace("\0", "") + "'";
			sSql += " ,AdvPmtCashAlloCrName = '" + txtAdvPmyAlloCashCreditName.Text.Trim().Replace("\0", "") + "'";
			sSql += " ,AdvPmtEftGL = '" + sAdvPmtEftGL + "'";
			sSql += " ,AdvPmtEftDebitCode = '" + txtAdvPmtEftDebitCode.Text.Trim().Replace("\0", "") + "'";
			sSql += " ,AdvPmtEftCreditCode = '" + txtAdvPmtEftCreditCode.Text.Trim().Replace("\0", "") + "'";
			sSql += " ,AdvPmtEftDebitName = '" + txtAdvPmtEftDebitName.Text.Trim().Replace("\0", "") + "'";
			sSql += " ,AdvPmtEftCreditName = '" + txtAdvPmtEftCreditName.Text.Trim().Replace("\0", "") + "'";
			sSql += " ,AdvPmtEftAllo = '" + sAdvPmtEftAllo + "'";
			sSql += " ,AdvPmtEftAlloDtCode = '" + txtAdvPmyAlloEftDebitCode.Text.Trim().Replace("\0", "") + "'";
			sSql += " ,AdvPmtEftAlloCrCode = '" + txtAdvPmyAlloEftCreditCode.Text.Trim().Replace("\0", "") + "'";
			sSql += " ,AdvPmtEftAlloDtName = '" + txtAdvPmyAlloEftDebitName.Text.Trim().Replace("\0", "") + "'";
			sSql += " ,AdvPmtEftAlloCrName = '" + txtAdvPmyAlloEftCreditName.Text.Trim().Replace("\0", "") + "'";
			sSql += " ,GoodsIssuePrefix = '" + txtGoodsIssuePrefix.Text.Trim().Replace("\0", "") + "'";
			sSql += " ,GoodsIssueNumber = " + txtGoodsIssueNumber.Text.Trim().Replace("\0", "");
			sSql += " ,NoDepositTransaction = '" + schkTransactionsForDeposits.Trim().Replace("\0", "") + "'";
			sSql += " ,NoAdvPmtTransaction = '" + schkTransactionsForAdvPmt.Trim().Replace("\0", "") + "'";
			sSql += " ,DepositReceivePrefix = '" + txtDepositReceivedPrefix.Text.Trim().Replace("\0", "") + "'";
			sSql += " ,DepositReceivedNumbe = " + txtDepositReceivedNumber.Text.Trim().Replace("\0", "");
			sSql += " ,PmtReceivedPrefix = '" + txtPaymentReceivedPrefix.Text.Trim().Replace("\0", "") + "'";
			sSql += " ,PmtReceivedNumber = " + txtPaymentReceivedNumber.Text.Trim().Replace("\0", "");
			sSql += " ,RoundingMethod = '" + selRoundingAccMethod.Text.Trim().Replace("\0", "") + "'";
			sSql += " ,RoundingAccountName = '" + txtRoundingAccDetail.Text.Trim().Replace("\0", "") + "'";
			sSql += " ,RoundingAccount = '" + txtRoundingAcc.Text.Trim().Replace("\0", "") + "'";
			sSql += " ,RoundingToNearest = " + txtRoundingNearest.Text.Trim().Replace("\0", "");
			sSql += " ,LeaseLevyAccountName = '" + txtLeaseLeavyAccDetail.Text.Trim().Replace("\0", "") + "'";
			sSql += " ,LeaseLevyAccount = '" + txtLeaseLevyAcc.Text.Trim().Replace("\0", "") + "'";
			sSql += " ,AutoInvoiceOnReturn = " + sAutoInvoice.Replace("\0", "");    
			
			if (txtDefaultRuleID.Text != "")
				sSql += " ,iDefaultRuleId = " + txtDefaultRuleID.Text;

			sSql += " ,sDefaultRuleName = '" + txtDefaultRule.Text + "'";

		
			sSql += " ,RoundingCOD = " + sRoundingCOD;
			sSql += " ,DeliveryNoteTemplate = '" + selDeliveryTemplate.Text + "'";
			sSql += " ,InvoiceTemplate = '" + selInvoiceTemplate.Text + "'";
			sSql += " ,QuoteTemplate = '" + selQuoteTemplate.Text.Trim() + "'";
			sSql += " ,GenerateZeroInv = '" + sGenerateZeroValueInvoices + "'";
			sSql += " ,AutoBlockCust = '" + sAutoBlockCustomers + "'";
			sSql += " ,NotifyIfCustOverLimi = '" + sNotifyIfCustomerOverCreditLimit + "'";

			sSql += " ,LiquidHandlesInvt = '" + sLiquidHandlesInventory + "'"; //JR13 6/8/2011
			
			if (chkPartialDays.Checked == true)
			 sSql += " ,PartialDays = 1";
			else
			 sSql += " ,PartialDays = 0";

			sSql += " ,GraceTime = '" + selGraceTime.Text + "'";
			sSql += " ,HalfdayValue = " + txtHalfdayValue.Text.Trim() + "";
			sSql += " ,QoutePrefix = '" + txtQoutePrefix.Text.Trim() + "'";
			sSql += " ,ProjectPrefix = '" + txtProjectPrefix.Text.Trim() + "'";
			sSql += " ,DeliveryNotePrefix = '" + txtDeliveryNotePrefix.Text.Trim() + "'";
			sSql += " ,ReturnNotePrefix = '" + txtReturnNotePrefix.Text.Trim() + "'";
			sSql += " ,QuotePath = '" + txtQuotePath.Text.Trim() + "'";
			sSql += " ,DeliveryNoteTerms = '" + txtTermsAndConditions.Text.Trim() + "'";
            sSql += " ,SalesOrderType = '" + selSalesOrderType.Text.Trim() + "'";
            sSql += " ,DefaultInvoiceUser = '" + txtDefInvoiceUser.Text.Trim() + "'";



            int Ret = Liquid.Classes.Connect.getDataCommand(sSql, oConn).ExecuteNonQuery();			
			oConn.Dispose();
			Global.sDeliveryNoteCompany = txtDelCompany.Text;
			Global.sInvoiceContactName = txtInvoiceContactName.Text;
			Global.sInvoiceContactNumber = txtInvoiceContactNumber.Text;
			Global.sDefaultDocPrinter = txtDocPrinterName.Text.Trim();
			Global.sDefaultSlipPrinter = txtSlipPrinterName.Text.Trim();
			Global.sDeliveryNoteFirstPrintCopies = txtDeliveryNoteFirstPrintCopies.Text.Trim();
			Global.sDeliveryNoteDuplicatePrintCopies = txtDeliveryNoteDuplicatePrintCopies.Text.Trim();
			Global.sInvoiceFirstPrintCopies = txtInvoiceFirstPrintCopies.Text.Trim();
			Global.sInvoiceDuplicatePrintCopies = txtInvoiceDuplicatePrintCopies.Text.Trim();
			Global.sEmailAddressFrom1 = txtEmailAddressFrom1.Text;
			Global.sEmailAddressFrom2 = txtEmailAddressFrom2.Text;
			Global.sEmailAddressFrom3 = txtEmailAddressFrom3.Text;
			Global.sEmailPasswordFrom1 = txtEmailPasswordFrom1.Text;
			Global.sEmailPasswordFrom2 = txtEmailPasswordFrom2.Text;
			Global.sEmailPasswordFrom3 = txtEmailPasswordFrom3.Text;
			Global.sSmtpClient = txtSmtpClient.Text;
			Global.sSmtpOutgoing = txtSmtpOutgoing.Text;
			Global.sSmtpClientUserName = txtSmtpUserName.Text;
			Global.sSmtpClientPassword = txtSmtpPassword.Text;
			Global.sSmtpClientPort = txtSmtpClientPort.Text;
			Global.sEmailBody = txtEmailBody.Text;
			Global.sTermsAndConditions = txtTermsAndConditions.Text.Trim();

			if (txtDefSDKUser.Text != "")
			{
				Global.iPastelSdkUser = Convert.ToInt32(txtDefSDKUser.Text);
			}
			else
			{
				Global.iPastelSdkUser = 0;
			}

            if (txtDefInvoiceUser.Text != "")
            {
                Global.iDefaultInvoiceUser = Convert.ToInt32(txtDefInvoiceUser.Text);
            }
            else
            {
                Global.iDefaultInvoiceUser = 0;
            }

            cmdSave.Enabled = false;
		}

		private void Company_Setup_Load(object sender, EventArgs e)
		{
			PsqlConnection oConn = new PsqlConnection(Liquid.Classes.Connect.LiquidConnectionString);
			oConn.Open();

			string sSql = "SELECT * FROM SOLCS ";
			selRoundingAccMethod.SelectedIndex = 0;
			PsqlDataReader rdReader = Liquid.Classes.Connect.getDataCommand(sSql, oConn).ExecuteReader();
			while (rdReader.Read())
			{
				txtCompanyName.Text = rdReader["CompanyName"].ToString().Trim();
				txtStore.Text = rdReader["StoreDefault"].ToString().Trim();

				//JR
				txtDefSDKUser.Text = rdReader["DefaultSDKUser"].ToString().Trim();
                txtDefInvoiceUser.Text = rdReader["DefaultInvoiceUser"].ToString().Trim();
                txtDocPrinterName.Text = Global.sDefaultDocPrinter;
				txtSlipPrinterName.Text = Global.sDefaultSlipPrinter;
				txtDeliveryNoteFirstPrintCopies.Text = Global.sDeliveryNoteFirstPrintCopies;
				txtDeliveryNoteDuplicatePrintCopies.Text = Global.sDeliveryNoteDuplicatePrintCopies;
				txtInvoiceFirstPrintCopies.Text = Global.sInvoiceFirstPrintCopies;
				txtInvoiceDuplicatePrintCopies.Text = Global.sInvoiceDuplicatePrintCopies;

				string sDepositGL = rdReader["GLonDeposit"].ToString().Trim();
				string sDepositToCustomerAccount = rdReader["DepositToCustAccount"].ToString().Trim();
				string sProcessCardGL = rdReader["ProcessCardGl"].ToString().Trim();
				string sProcessChequeGL = rdReader["ProcessChequeGl"].ToString().Trim();
				string sProcessCashGL = rdReader["ProcessCashGL"].ToString().Trim();
				string schkTransactionsForDeposits = rdReader["NoDepositTransaction"].ToString().Trim();
				string schkTransactionsForAdvPmt = rdReader["NoAdvPmtTransaction"].ToString().Trim();

				bool bTransactionDeposit = true;
				if (schkTransactionsForDeposits == "True")
				{
					chkTransactionsForDeposits.Checked = true;
					bTransactionDeposit = false;
				}

				bool bTransactionAdvPmt = true;
				if (schkTransactionsForAdvPmt == "True")
				{
					chkTransactionsForAdvPmt.Checked = true;
					bTransactionAdvPmt = false;
				}

				bool bGLDeposit = true;
				if (sDepositGL == "False")
				{
					rbDepositGL.Checked = false;
					rbDepositAcc.Checked = true;
					bGLDeposit = false;
				}
				else
				{
					rbDepositGL.Checked = true;
					rbDepositAcc.Checked = false;
					bGLDeposit = true;
				}
				bool bGLCard = true;
				if (sProcessCardGL == "False")
				{
					rbCardSalesGL.Checked = false;
					rbCardSalesAcc.Checked = true;
					bGLCard = false;
				}
				else
				{
					rbCardSalesGL.Checked = true;
					rbCardSalesAcc.Checked = false;
					bGLCard = true;
				}
				bool bGLCheque = true;
				if (sProcessChequeGL == "False")
				{
					rbChequeSalesGL.Checked = false;
					rbChequeSalesAcc.Checked = true;
					bGLCheque = false;
				}
				else
				{
					rbChequeSalesGL.Checked = true;
					rbChequeSalesAcc.Checked = false;
					bGLCheque = true;
				}

				bool bGLCash = true;
				if (sProcessCashGL == "False")
				{
					rbCashSalesGL.Checked = false;
					rbCashSalesAcc.Checked = true;
					bGLCash = false;
				}
				else
				{
					rbCashSalesGL.Checked = true;
					rbCashSalesAcc.Checked = false;
					bGLCash = true;
				}
				
				if (rdReader["CashCustomerAllocate"].ToString().Trim() == "False")
				{
					chkCashCustomerAllwaysLink.Checked = false;                    
				}
				else
				{
					chkCashCustomerAllwaysLink.Checked = true;                    
				}

				bool bDepositCashPmtAllocate = true;
				if (rdReader["DepositCashPmtAllo"].ToString().Trim() == "False")
				{
					chkCashDepositPaymentAllocate.Checked = false;                    
					bDepositCashPmtAllocate = true;
				}
				else
				{
					chkCashDepositPaymentAllocate.Checked = true;                    
					bDepositCashPmtAllocate = false;
				}

				bool bDeposEftGl = true;
				if (rdReader["DeposEftGl"].ToString().Trim() == "False")
				{
					rbDepositGlEft.Checked = false;
					rbDepositAccEft.Checked = true;
					bDeposEftGl = false;
				}
				else
				{
					rbDepositGlEft.Checked = true;
					rbDepositAccEft.Checked = false;
					bDeposEftGl = true;
				}

				bool bDeposEftpmtAllo = true;
				if (rdReader["DeposEftpmtAllo"].ToString().Trim() == "False")
				{
					chkDepEftPmtAllocate.Checked = false;
					bDeposEftpmtAllo = true;
				}
				else
				{
					chkDepEftPmtAllocate.Checked = true;
					bDeposEftpmtAllo = false;
				}

				bool bAdvPmtCashGL = true;
				if (rdReader["AdvPmtCashGL"].ToString().Trim() == "False")
				{
					rbAdvPmtCashGL.Checked = false;
					rbAdvPmtCashAcc.Checked = true;
					bAdvPmtCashGL = false;
				}
				else
				{
					rbAdvPmtCashGL.Checked = true;
					rbAdvPmtCashAcc.Checked = false;
					bAdvPmtCashGL = true;
				}

				bool bAdvPmtCashAllo = true;
				if (rdReader["AdvPmtCashAllo"].ToString().Trim() == "False")
				{
					chkAdvPmtAlloCash.Checked = false;
					bAdvPmtCashAllo = true;
				}
				else
				{
					chkAdvPmtAlloCash.Checked = true;
					bAdvPmtCashAllo = false;
				}

				bool bAdvPmtEftGL = true;
				if (rdReader["AdvPmtEftGL"].ToString().Trim() == "False")
				{
					rbAdvPmtEftGL.Checked = false;
					rbAdvPmtEftAcc.Checked = true;
					bAdvPmtEftGL = false;
				}
				else
				{
					rbAdvPmtEftGL.Checked = true;
					rbAdvPmtEftAcc.Checked = false;
					bAdvPmtEftGL = true;
				}

				bool bAdvPmtEftAllo = true;
				if (rdReader["AdvPmtEftAllo"].ToString().Trim() == "False")
				{
					chkAdvPmtAlloEft.Checked = false;
					bAdvPmtEftAllo = true;
				}
				else
				{
					chkAdvPmtAlloEft.Checked = true;
					bAdvPmtEftAllo = false;
				}

				if (rdReader["AutoInvoiceOnReturn"].ToString() == "1")
				{
					chkAutoInvoice.Checked = true;
				}
				else
				{
					chkAutoInvoice.Checked = false;
				}

				if (rdReader["RoundingCod"].ToString() == "True")
				{
					chkRoundingCOD.Checked = true;
				}
				else
				{
					chkRoundingCOD.Checked = false;
				}

				if (rdReader["GenerateZeroInv"].ToString() == "True")
				{
					chkGenerateZeroValInvoice.Checked = true;
				}
				else
				{
					chkGenerateZeroValInvoice.Checked = false;
				}

				if (rdReader["AutoBlockCust"].ToString() == "True")
				{
					chkAutoBlockCustomer.Checked = true;
					chkAutoBlockCustomer.Enabled = true;
				}
				else
				{
					chkAutoBlockCustomer.Checked = false;
				}

				if (rdReader["NotifyIfCustOverLimi"].ToString() == "True")
					chkNotifyIfCustOverLimit.Checked = true;
				else
					chkNotifyIfCustOverLimit.Checked = false;

				//********
				//JR 13 6/8/2011
				if (rdReader["LiquidHandlesInvt"].ToString() == "True")
					chkLiquidHandlesInvt.Checked = true;
				else
					chkLiquidHandlesInvt.Checked = false;

				//********

				if (rdReader["PartialDays"].ToString() == "1")
					chkPartialDays.Checked = true;
				else
					chkPartialDays.Checked = false;

				SetDepositEftFields(bDeposEftGl);
				SetDepositEftPmtAlloFields(bDeposEftpmtAllo);
				SetAdvPmtCashFields(bAdvPmtCashGL);
				SetAdvPmtCashAlloFields(bAdvPmtCashAllo);
				SetAdvPmtEftFields(bAdvPmtEftGL);
				SetAdvPmtEftAlloFields(bAdvPmtEftAllo);				
				setDepositFields(bGLDeposit);
				setDepositPaymentFields(bDepositCashPmtAllocate);
				setCashSalesFields(bGLCash);
				setCardSalesFields(bGLCard);
				setChequeSalesFields(bGLCheque);
				setTransactionDepositFields(bTransactionDeposit);
				setTransactionAdvPmtFields(bTransactionAdvPmt);
				txtCreditAccount.Text = rdReader["DepositCredit"].ToString().Trim();
				txtCreditAccountName.Text = rdReader["DepositCreditName"].ToString().Trim();
				txtDebitAccount.Text = rdReader["DepositDebit"].ToString().Trim();
				txtDebitAccountName.Text = rdReader["DepositDebitName"].ToString().Trim();
			  //txtInvoiceMessage1.Text = rdReader["InvoiceMessage1"].ToString().Trim();
			  //txtInvoiceMessage2.Text = rdReader["InvoiceMessage2"].ToString().Trim();
				txtRegNumber.Text = rdReader["RegistrationNum"].ToString().Trim();
				txtVatNumber.Text = rdReader["VATNumber"].ToString().Trim();
				txtPostalAddress1.Text = rdReader["Postal1"].ToString().Trim();
				txtPostalAddress2.Text = rdReader["Postal2"].ToString().Trim();
				txtPostalAddress3.Text = rdReader["Postal3"].ToString().Trim();
				txtPostalAddress4.Text = rdReader["PostalZip"].ToString().Trim();
				txtPhysicalAddress1.Text = rdReader["Physical1"].ToString().Trim();
				txtPhysicalAddress2.Text = rdReader["Physical2"].ToString().Trim();
				txtPhysicalAddress3.Text = rdReader["Physical3"].ToString().Trim();
				txtPhysicalAddress4.Text = rdReader["PhysicalZip"].ToString().Trim();
				txtTelephoneNumber.Text = rdReader["TelephoneNumber"].ToString().Trim();
				txtFaxNumber.Text = rdReader["FaxNumber"].ToString().Trim();
				txtGroupName.Text = rdReader["GroupName"].ToString().Trim();
				txtCashDebit.Text = rdReader["SalesDebit"].ToString().Trim();
				txtCashDebitName.Text = rdReader["SalesDebitName"].ToString().Trim();
				txtCashCredit.Text = rdReader["SalesCredit"].ToString().Trim();
				txtCashCreditName.Text = rdReader["SalesCreditName"].ToString().Trim();
				txtCardDebit.Text = rdReader["SalesCardDebit"].ToString().Trim();
				txtCardCreditCode.Text = rdReader["SalesCardCredit"].ToString().Trim();
				txtCardDebitName.Text = rdReader["SalesCardDebitName"].ToString().Trim();
				txtCardCreditName.Text = rdReader["SalesCardCreditName"].ToString().Trim();
				txtChequeDebitCode.Text = rdReader["SalesChequeDebit"].ToString().Trim();
				txtChequeCreditCode.Text = rdReader["SalesChequeCredit"].ToString().Trim();
				txtChequeDebitName.Text = rdReader["SalesChequeDebitName"].ToString().Trim();
				txtChequeCreditName.Text = rdReader["SalesChequeCreditNam"].ToString().Trim();
				txtCashDepAllocateDebitCode.Text = rdReader["DeposCashAlloDtCode"].ToString().Trim();
				txtCashDepAllocateCreditCode.Text = rdReader["DeposCashAlloCrCode"].ToString().Trim();
				txtCashDepAllocateDebitName.Text = rdReader["DeposCashAlloDtName"].ToString().Trim();
				txtCashDepAllocateCreditName.Text = rdReader["DeposCashAlloCrName"].ToString().Trim();
				txtDepositEftDebitCode.Text = rdReader["DeposEftDebitCode"].ToString().Trim();
				txtDepositEftCreditCode.Text = rdReader["DeposEftCreditCode"].ToString().Trim();
				txtDepositEftDebitName.Text = rdReader["DeposEftDebitName"].ToString().Trim();
				txtDepositEftCreditName.Text = rdReader["DeposEftCreditName"].ToString().Trim();
				txtDepEftPmtAllocateDebitCode.Text = rdReader["DeposEftAlloDtCode"].ToString().Trim();
				txtDepEftPmtAllocateCreditCode.Text = rdReader["DeposEftAlloCrCode"].ToString().Trim();
				txtDepEftPmtAllocateDebitName.Text = rdReader["DeposEftAlloDtName"].ToString().Trim();
				txtDepEftPmtAllocateCreditName.Text = rdReader["DeposEftAlloCrName"].ToString().Trim();
				txtAdvPmtCashDebitCode.Text = rdReader["AdvPmtCashDebitCode"].ToString().Trim();
				txtAdvPmtCashCreditCode.Text = rdReader["AdvPmtCashCreditCode"].ToString().Trim();
				txtAdvPmtCashDebitName.Text = rdReader["AdvPmtCashDebitName"].ToString().Trim();
				txtAdvPmtCashCreditName.Text = rdReader["AdvPmtCashCreditName"].ToString().Trim();
				txtAdvPmyAlloCashDebitCode.Text = rdReader["AdvPmtCashAlloDtCode"].ToString().Trim();
				txtAdvPmyAlloCashCreditCode.Text = rdReader["AdvPmtCashAlloCrCode"].ToString().Trim();
				txtAdvPmyAlloCashDebitName.Text = rdReader["AdvPmtCashAlloDtName"].ToString().Trim();
				txtAdvPmyAlloCashCreditName.Text = rdReader["AdvPmtCashAlloCrName"].ToString().Trim();
				txtAdvPmtEftDebitCode.Text = rdReader["AdvPmtEftDebitCode"].ToString().Trim();
				txtAdvPmtEftCreditCode.Text = rdReader["AdvPmtEftCreditCode"].ToString().Trim();
				txtAdvPmtEftDebitName.Text = rdReader["AdvPmtEftDebitName"].ToString().Trim();
				txtAdvPmtEftCreditName.Text = rdReader["AdvPmtEftCreditName"].ToString().Trim();
				txtAdvPmyAlloEftDebitCode.Text = rdReader["AdvPmtEftAlloDtCode"].ToString().Trim();
				txtAdvPmyAlloEftCreditCode.Text = rdReader["AdvPmtEftAlloCrCode"].ToString().Trim();
				txtAdvPmyAlloEftDebitName.Text = rdReader["AdvPmtEftAlloDtName"].ToString().Trim();
				txtAdvPmyAlloEftCreditName.Text = rdReader["AdvPmtEftAlloCrName"].ToString().Trim();
				txtGoodsIssuePrefix.Text = rdReader["GoodsIssuePrefix"].ToString().Trim();
				txtGoodsIssueNumber.Text = rdReader["GoodsIssueNumber"].ToString().Trim();
				txtDepositReceivedPrefix.Text = rdReader["DepositReceivePrefix"].ToString().Trim();
				txtDepositReceivedNumber.Text = rdReader["DepositReceivedNumbe"].ToString().Trim();
				txtPaymentReceivedPrefix.Text = rdReader["PmtReceivedPrefix"].ToString().Trim();
				txtPaymentReceivedNumber.Text = rdReader["PmtReceivedNumber"].ToString().Trim();
				selRoundingAccMethod.Text = rdReader["RoundingMethod"].ToString().Trim();
				txtRoundingAcc.Text = rdReader["RoundingAccount"].ToString().Trim();
				txtRoundingAccDetail.Text = rdReader["RoundingAccount"].ToString().Trim();
				
				if (rdReader["RoundingToNearest"].ToString().Trim() != "")
				{
					txtRoundingNearest.Text = rdReader["RoundingToNearest"].ToString().Trim(); 
				}
				txtLeaseLevyAcc.Text = rdReader["LeaseLevyAccount"].ToString().Trim();
				txtLeaseLeavyAccDetail.Text = rdReader["LeaseLevyAccountName"].ToString().Trim();
				txtInvoiceContactName.Text = rdReader["InvoiceContactName"].ToString().Trim();
				txtInvoiceContactNumber.Text = rdReader["InvoiceContactNumber"].ToString().Trim();
				txtDelCompany.Text = rdReader["DeliveryNoteCompany"].ToString().Trim();
				selDeliveryTemplate.Text = rdReader["DeliveryNoteTemplate"].ToString().Trim();
				selInvoiceTemplate.Text = rdReader["InvoiceTemplate"].ToString().Trim();
				selQuoteTemplate.Text = rdReader["QuoteTemplate"].ToString().Trim();
				txtQuotePath.Text = rdReader["QuotePath"].ToString().Trim();
				txtDefaultRuleID.Text = rdReader["iDefaultRuleId"].ToString().Trim();
				txtDefaultRule.Text = rdReader["sDefaultRuleName"].ToString().Trim();
				selGraceTime.Text = rdReader["GraceTime"].ToString().Trim();
				if (selGraceTime.Text == "")
				{
					selGraceTime.Text = "0";
				}
				txtHalfdayValue.Text = rdReader["HalfdayValue"].ToString().Trim();
				if (txtHalfdayValue.Text == "")
				{
					txtHalfdayValue.Text = "0";
				}
				txtQoutePrefix.Text = rdReader["QoutePrefix"].ToString().Trim();
				txtProjectPrefix.Text = rdReader["ProjectPrefix"].ToString().Trim();
				txtDeliveryNotePrefix.Text = rdReader["DeliveryNotePrefix"].ToString().Trim();
				txtReturnNotePrefix.Text = rdReader["ReturnNotePrefix"].ToString().Trim();
				try
				{
					txtTermsAndConditions.Text = rdReader["DeliveryNoteTerms"].ToString().Trim();
				}
				catch
				{
					txtTermsAndConditions.Text = "";
				}
                try
                {
                    selSalesOrderType.Text = rdReader["SalesOrderType"].ToString().Trim();
                }
                catch
                {
                    selSalesOrderType.Text = "";
                }
               
			}

			rdReader.Close();			
			oConn.Dispose();
			//get EmailDetails @global
			txtEmailAddressFrom1.Text = Global.sEmailAddressFrom1;
			txtEmailPasswordFrom1.Text = Global.sEmailPasswordFrom1;
			txtEmailAddressFrom2.Text = Global.sEmailAddressFrom2;
			txtEmailPasswordFrom2.Text = Global.sEmailPasswordFrom2;
			txtEmailAddressFrom3.Text = Global.sEmailAddressFrom3;
			txtEmailPasswordFrom3.Text = Global.sEmailPasswordFrom3;
			txtSmtpClient.Text = Global.sSmtpClient;
			txtSmtpOutgoing.Text = Global.sSmtpOutgoing;
			txtSmtpClientPort.Text = Global.sSmtpClientPort;
			txtSmtpUserName.Text = Global.sSmtpClientUserName;
			txtSmtpPassword.Text = Global.sSmtpClientPassword;
			txtEmailBody.Text = Global.sEmailBody;
			loadLinkInventory();

		}        

		private void txtCompanyName_TextChanged(object sender, EventArgs e)
		{
			cmdSave.Enabled = true;
		}

		
		private void setDepositFields(bool bEnabled)
		{
			lblCredit.Enabled = bEnabled;			
			cmdSearchCredit.Enabled = bEnabled;			
			txtCreditAccount.Enabled = bEnabled;
			txtCreditAccountName.Enabled = bEnabled;

			//lblDebit.Enabled = bEnabled;
			//cmdSearchDebit.Enabled = bEnabled;
			//txtDebitAccount.Enabled = bEnabled;
			//txtDebitAccountName.Enabled = bEnabled;

			setSaveButton();

			if (bEnabled)
			{
			}
			else
			{
				txtCreditAccount.Text = "";
				txtCreditAccountName.Text = "";
				//txtDebitAccount.Text = "";
				//txtDebitAccountName.Text = "";
			}
			
		}
		private void setDepositPaymentFields(bool bEnabled)
		{
			lblCashDepAllocateCredit.Enabled = bEnabled;
			cmdCashDepAllocateCreditSearch.Enabled = bEnabled;
			txtCashDepAllocateCreditCode.Enabled = bEnabled;
			txtCashDepAllocateCreditName.Enabled = bEnabled;
			setSaveButton();

			if (bEnabled)
			{
			}
			else
			{
				txtCashDepAllocateCreditCode.Text = "";
				txtCashDepAllocateCreditName.Text = "";
			}
			
		}
		


		private void cmdSearchDebit_Click(object sender, EventArgs e)
		{
			Cursor = System.Windows.Forms.Cursors.WaitCursor;
			using (Finder.LedgerZoom frmLedgerZoom = new Liquid.Finder.LedgerZoom())
			{
				if (frmLedgerZoom.ShowDialog() == DialogResult.OK)
				{
					if (frmLedgerZoom.sResult != "")
					{
						txtDebitAccount.Text = frmLedgerZoom.sResult;
						txtDebitAccountName.Text = frmLedgerZoom.sDescription;
					}
				}
				Cursor = System.Windows.Forms.Cursors.Default;
			}
		}

		private void cmdSearchCredit_Click(object sender, EventArgs e)
		{
			Cursor = System.Windows.Forms.Cursors.WaitCursor;
			using (Finder.LedgerZoom frmLedgerZoom = new Liquid.Finder.LedgerZoom())
			{
				if (frmLedgerZoom.ShowDialog() == DialogResult.OK)
				{
					if (frmLedgerZoom.sResult != "")
					{
						txtCreditAccount.Text = frmLedgerZoom.sResult;
						txtCreditAccountName.Text = frmLedgerZoom.sDescription;
					}
				}
				Cursor = System.Windows.Forms.Cursors.Default;
			}
		}

		private void cmdAddSourceInventory_Click(object sender, EventArgs e)
		{
			Cursor = System.Windows.Forms.Cursors.WaitCursor;
			using (Finder.SDKUsers frmSDKUserZoom = new Liquid.Finder.SDKUsers())
			{
				if (frmSDKUserZoom.ShowDialog() == DialogResult.OK)
				{
					if (frmSDKUserZoom.sSelectedSDKUserCode != "")
					{
						txtDefSDKUser.Text = frmSDKUserZoom.sSelectedSDKUserCode;
				   
					}
				}

				Cursor = System.Windows.Forms.Cursors.Default;
			}
		}

		private void cmdTargetInventory_Click(object sender, EventArgs e)
		{
			Cursor = System.Windows.Forms.Cursors.WaitCursor;
			using (Finder.Inventory frmInventoryZoom = new Liquid.Finder.Inventory())
			{
				if (frmInventoryZoom.ShowDialog() == DialogResult.OK)
				{
					if (frmInventoryZoom.sResult != "")
					{
						txtTargetInvetory.Text = frmInventoryZoom.sResult;
						txtTargetInventoryDesc.Text = frmInventoryZoom.sDescription;
					}
				}
				Cursor = System.Windows.Forms.Cursors.Default;
			}
		}

		private void cmdAddLinkInventory_Click(object sender, EventArgs e)
		{
			if (txtSrcInventory.Text == "" || txtTargetInvetory.Text == "")
			{
				MessageBox.Show("You have to supply a source and target inventory item to create the link", "Not enough info", MessageBoxButtons.OK, MessageBoxIcon.Error);				
			}
			else
			{
				PsqlConnection oConn = new PsqlConnection(Liquid.Classes.Connect.PastelConnectionString);
				oConn.Open();

				string sSql = "UPDATE  Inventory";
				sSql += " SET UserDefText01 = '" + txtTargetInvetory.Text + "'";
				sSql += "  WHERE  ";
				sSql +=  " ItemCode = '" + txtSrcInventory.Text + "'";				

				int Ret = Liquid.Classes.Connect.getDataCommand(sSql, oConn).ExecuteNonQuery();
				
				oConn.Dispose();

				loadLinkInventory();

				txtSrcInventory.Text = "";
				txtSrcInventoryDesc.Text = "";
				txtTargetInvetory.Text = "";
				txtTargetInventoryDesc.Text = "";
			}
		}

		private void dgLinkedInventory_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex == 3)//remove button
			{				
				if (MessageBox.Show("This will permanently remove this link.  Do you still want to remove this entry", "Are you sure", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					PsqlConnection oConn = new PsqlConnection(Liquid.Classes.Connect.PastelConnectionString);
					oConn.Open();

					string sSql = "UPDATE  Inventory";
					sSql += " SET UserDefText01 =  '' ";
					sSql += "  WHERE  ";
					sSql += " ItemCode = '" +dgLinkedInventory.Rows[dgLinkedInventory.SelectedCells[0].RowIndex].Cells[1].Value + "'";					
					int Ret = Liquid.Classes.Connect.getDataCommand(sSql, oConn).ExecuteNonQuery();

					dgLinkedInventory.Rows.Remove(dgLinkedInventory.Rows[dgLinkedInventory.SelectedCells[0].RowIndex]);
					oConn.Dispose();
				}
			}
		}

		private void loadLinkInventory()
		{
			dgLinkedInventory.Rows.Clear();

			int iRowCounter = 1;
			PsqlConnection oConn = new PsqlConnection(Liquid.Classes.Connect.PastelConnectionString);
			oConn.Open();
			string sSql = " select distinct Inventory.ItemCode, Inventory.UserDefText01, InventoryGroups.Description from Inventory ";
			sSql += " inner join MultiStoreTrn on Inventory.ItemCode = MultiStoreTrn.ItemCode ";
			sSql += " inner join InventoryGroups on MultiStoreTrn.InvGroup = InventoryGroups.InvGroup ";
			sSql += "where UserDefText01 not in('', 'Order', 'UserDef1') and InventoryGroups.Description <> 'LeaseItems'";

			PsqlDataReader rdReader = Liquid.Classes.Connect.getDataCommand(sSql, oConn).ExecuteReader();
			while (rdReader.Read())
			{							
					int n = dgLinkedInventory.Rows.Add();
					dgLinkedInventory.Rows[n].Cells[0].Value = iRowCounter.ToString();
					dgLinkedInventory.Rows[n].Cells[1].Value = rdReader["ItemCode"].ToString();
					dgLinkedInventory.Rows[n].Cells[2].Value = rdReader["UserDefText01"].ToString();
					dgLinkedInventory.Rows[n].Cells[3].Value = "Remove";
					iRowCounter++;				
			}
			rdReader.Close();
			oConn.Dispose();
		}

		
		private void rbCashSalesGL_CheckedChanged(object sender, EventArgs e)
		{
			if (rbCashSalesGL.Checked)
				setCashSalesFields(true);
			else
				setCashSalesFields(false);
		}

		private void setCashSalesFields(bool bEnabled)
		{
			txtCashCredit.Enabled = bEnabled;
			txtCashCreditName.Enabled = bEnabled;
			lblCashCredit.Enabled = bEnabled;
			cmdSalesCreditSearch.Enabled = bEnabled;
			setSaveButton();

			if (bEnabled)
			{
			}
			else
			{
				txtCashCredit.Text = "";
				txtCashCreditName.Text = "";
			}

		}

		private void rbDepositGL_CheckedChanged(object sender, EventArgs e)
		{
			if (rbDepositGL.Checked)
				setDepositFields(true);
			else
				setDepositFields(false);
		}

		private void setCardSalesFields(bool bEnabled)
		{
			txtCardCreditCode.Enabled = bEnabled;
			txtCardCreditName.Enabled = bEnabled;
			lblCardCredit.Enabled = bEnabled;
			cmdCardCreditSearch.Enabled = bEnabled;
			setSaveButton();

			if (bEnabled)
			{
			}
			else
			{
				txtCardCreditCode.Text = "";
				txtCardCreditName.Text = "";
			}

		}

		private void setChequeSalesFields(bool bEnabled)
		{
			txtChequeCreditCode.Enabled = bEnabled;
			txtChequeCreditName.Enabled = bEnabled;
			lblEftCredit.Enabled = bEnabled;
			cmdChequeCreditSearch.Enabled = bEnabled;
			setSaveButton();

			if (bEnabled)
			{
				//txtChequeDebitCode.BackColor = System.Drawing.Color.White;
			}
			else
			{
				txtChequeCreditCode.Text = "";
				txtChequeCreditName.Text = "";
				//txtChequeDebitCode.BackColor = System.Drawing.Color.LightGray;
			}

		}

		private void SetDepositEftFields(bool bEnabled)
		{
			txtDepositEftCreditCode.Enabled = bEnabled;
			txtDepositEftCreditName.Enabled = bEnabled;
			lblDepositEftCredit.Enabled = bEnabled;
			cmdDepositEftCreditSearch.Enabled = bEnabled;
			gbDepositsEft.Enabled = bEnabled;
			setSaveButton();

			if (bEnabled)
			{
				
			}
			else
			{
				txtDepositEftCreditCode.Text = "";
				txtDepositEftCreditName.Text = "";                
			}

		}
		
		private void SetDepositEftPmtAlloFields(bool bEnabled)
		{
			txtDepEftPmtAllocateCreditCode.Enabled = bEnabled;
			txtDepEftPmtAllocateCreditName.Enabled = bEnabled;
			lblDepEftPmtAllocateCredit.Enabled = bEnabled;
			cmdDepEftPmtAllocateCreditSearch.Enabled = bEnabled;
			setSaveButton();

			if (bEnabled)
			{
				
			}
			else
			{
				txtDepEftPmtAllocateCreditCode.Text = "";
				txtDepEftPmtAllocateCreditName.Text = "";                
			}
		}
		
		private void SetAdvPmtCashFields(bool bEnabled)
		{
			txtAdvPmtCashCreditCode.Enabled = bEnabled;
			txtAdvPmtCashCreditName.Enabled = bEnabled;
			lblAdvPmtCashCredit.Enabled = bEnabled;
			cmdAdvPmtCashCreditSearch.Enabled = bEnabled;
			setSaveButton();

			if (bEnabled)
			{
				
			}
			else
			{
				txtAdvPmtCashCreditCode.Text = "";
				txtAdvPmtCashCreditName.Text = "";                
			}
		}

		private void SetAdvPmtCashAlloFields(bool bEnabled)
		{
			txtAdvPmyAlloCashCreditCode.Enabled = bEnabled;
			txtAdvPmyAlloCashCreditName.Enabled = bEnabled;
			lblAdvPmyAlloCashCredit.Enabled = bEnabled;
			cmdAdvPmyAlloCashCreditSearch.Enabled = bEnabled;
			setSaveButton();

			if (bEnabled)
			{
				
			}
			else
			{
				txtAdvPmyAlloCashCreditCode.Text = "";
				txtAdvPmyAlloCashCreditName.Text = "";                
			}
		}
		
		private void SetAdvPmtEftFields(bool bEnabled)
		{
			txtAdvPmtEftCreditCode.Enabled = bEnabled;
			txtAdvPmtEftCreditName.Enabled = bEnabled;
			lblAdvPmtEftCredit.Enabled = bEnabled;
			cmdAdvPmtEftCreditSearch.Enabled = bEnabled;
			gbAdvPmtEft.Enabled = bEnabled;
			setSaveButton();

			if (bEnabled)
			{
				
			}
			else
			{
				txtAdvPmtEftCreditCode.Text = "";
				txtAdvPmtEftCreditName.Text = "";                
			}
		}

		private void SetAdvPmtEftAlloFields(bool bEnabled)
		{
			txtAdvPmyAlloEftCreditCode.Enabled = bEnabled;
			txtAdvPmyAlloEftCreditName.Enabled = bEnabled;
			lblAdvPmyAlloEftCredit.Enabled = bEnabled;
			cmdAdvPmyAlloEftCreditSearch.Enabled = bEnabled;
			setSaveButton();

			if (bEnabled)
			{
				
			}
			else
			{
				txtAdvPmyAlloEftCreditCode.Text = "";
				txtAdvPmyAlloEftCreditName.Text = "";                
			}
		}

		private void rbCardSalesGL_CheckedChanged(object sender, EventArgs e)
		{
			if (rbCardSalesGL.Checked)
				setCardSalesFields(true);
			else
				setCardSalesFields(false);
		}

		private void rbChequeSalesGL_CheckedChanged(object sender, EventArgs e)
		{
			if (rbChequeSalesGL.Checked)
				setChequeSalesFields(true);
			else
				setChequeSalesFields(false);
		}

		private void setSaveButton()
		{
			cmdSave.Enabled = true;
		}

		private void txtCashDebit_TextChanged(object sender, EventArgs e)
		{
			setSaveButton();

						
		}

		private void cmdCashDepAllocateDebitSearch_Click(object sender, EventArgs e)
		{
			Cursor = System.Windows.Forms.Cursors.WaitCursor;
			using (Finder.LedgerZoom frmLedgerZoom = new Liquid.Finder.LedgerZoom())
			{
				if (frmLedgerZoom.ShowDialog() == DialogResult.OK)
				{
					if (frmLedgerZoom.sResult != "")
					{
						txtCashDepAllocateDebitCode.Text = frmLedgerZoom.sResult;
						txtCashDepAllocateDebitName.Text = frmLedgerZoom.sDescription;
					}
				}
				Cursor = System.Windows.Forms.Cursors.Default;
			}
		}

		private void cmdCashDepAllocateCreditSearch_Click(object sender, EventArgs e)
		{
			Cursor = System.Windows.Forms.Cursors.WaitCursor;
			using (Finder.LedgerZoom frmLedgerZoom = new Liquid.Finder.LedgerZoom())
			{
				if (frmLedgerZoom.ShowDialog() == DialogResult.OK)
				{
					if (frmLedgerZoom.sResult != "")
					{
						txtCashDepAllocateCreditCode.Text = frmLedgerZoom.sResult;
						txtCashDepAllocateCreditName.Text = frmLedgerZoom.sDescription;
					}
				}
				Cursor = System.Windows.Forms.Cursors.Default;
			}
		}

		private void cmdDepositEftDebitSearch_Click(object sender, EventArgs e)
		{
			Cursor = System.Windows.Forms.Cursors.WaitCursor;
			using (Finder.LedgerZoom frmLedgerZoom = new Liquid.Finder.LedgerZoom())
			{
				if (frmLedgerZoom.ShowDialog() == DialogResult.OK)
				{
					if (frmLedgerZoom.sResult != "")
					{
						txtDepositEftDebitCode.Text = frmLedgerZoom.sResult;
						txtDepositEftDebitName.Text = frmLedgerZoom.sDescription;
					}
				}
				Cursor = System.Windows.Forms.Cursors.Default;
			}
		}

		private void cmdDepositEftCreditSearch_Click(object sender, EventArgs e)
		{
			Cursor = System.Windows.Forms.Cursors.WaitCursor;
			using (Finder.LedgerZoom frmLedgerZoom = new Liquid.Finder.LedgerZoom())
			{
				if (frmLedgerZoom.ShowDialog() == DialogResult.OK)
				{
					if (frmLedgerZoom.sResult != "")
					{
						txtDepositEftCreditCode.Text = frmLedgerZoom.sResult;
						txtDepositEftCreditName.Text = frmLedgerZoom.sDescription;
					}
				}
				Cursor = System.Windows.Forms.Cursors.Default;
			}
		}

		private void cmdDepEftPmtAllocateDebitSearch_Click(object sender, EventArgs e)
		{
			Cursor = System.Windows.Forms.Cursors.WaitCursor;
			using (Finder.LedgerZoom frmLedgerZoom = new Liquid.Finder.LedgerZoom())
			{
				if (frmLedgerZoom.ShowDialog() == DialogResult.OK)
				{
					if (frmLedgerZoom.sResult != "")
					{
						txtDepEftPmtAllocateDebitCode.Text = frmLedgerZoom.sResult;
						txtDepEftPmtAllocateDebitName.Text = frmLedgerZoom.sDescription;
					}
				}
				Cursor = System.Windows.Forms.Cursors.Default;
			}
		}

		private void cmdDepEftPmtAllocateCreditSearch_Click(object sender, EventArgs e)
		{
			Cursor = System.Windows.Forms.Cursors.WaitCursor;
			using (Finder.LedgerZoom frmLedgerZoom = new Liquid.Finder.LedgerZoom())
			{
				if (frmLedgerZoom.ShowDialog() == DialogResult.OK)
				{
					if (frmLedgerZoom.sResult != "")
					{
						txtDepEftPmtAllocateCreditCode.Text = frmLedgerZoom.sResult;
						txtDepEftPmtAllocateCreditName.Text = frmLedgerZoom.sDescription;
					}
				}
				Cursor = System.Windows.Forms.Cursors.Default;
			}
		}


		private void cmdAdvPmtCashDebitSearch_Click(object sender, EventArgs e)
		{
			Cursor = System.Windows.Forms.Cursors.WaitCursor;
			using (Finder.LedgerZoom frmLedgerZoom = new Liquid.Finder.LedgerZoom())
			{
				if (frmLedgerZoom.ShowDialog() == DialogResult.OK)
				{
					if (frmLedgerZoom.sResult != "")
					{
						txtAdvPmtCashDebitCode.Text = frmLedgerZoom.sResult;
						txtAdvPmtCashDebitName.Text = frmLedgerZoom.sDescription;
					}
				}
				Cursor = System.Windows.Forms.Cursors.Default;
			}
		}

		private void cmdAdvPmtCashCreditSearch_Click(object sender, EventArgs e)
		{
			Cursor = System.Windows.Forms.Cursors.WaitCursor;
			using (Finder.LedgerZoom frmLedgerZoom = new Liquid.Finder.LedgerZoom())
			{
				if (frmLedgerZoom.ShowDialog() == DialogResult.OK)
				{
					if (frmLedgerZoom.sResult != "")
					{
						txtAdvPmtCashCreditCode.Text = frmLedgerZoom.sResult;
						txtAdvPmtCashCreditName.Text = frmLedgerZoom.sDescription;
					}
				}
				Cursor = System.Windows.Forms.Cursors.Default;
			}
		}

		private void cmdAdvPmyAlloCashDebitSearch_Click(object sender, EventArgs e)
		{
			Cursor = System.Windows.Forms.Cursors.WaitCursor;
			using (Finder.LedgerZoom frmLedgerZoom = new Liquid.Finder.LedgerZoom())
			{
				if (frmLedgerZoom.ShowDialog() == DialogResult.OK)
				{
					if (frmLedgerZoom.sResult != "")
					{
						txtAdvPmyAlloCashDebitCode.Text = frmLedgerZoom.sResult;
						txtAdvPmyAlloCashDebitName.Text = frmLedgerZoom.sDescription;
					}
				}
				Cursor = System.Windows.Forms.Cursors.Default;
			}
		}

		private void cmdAdvPmyAlloCashCreditSearch_Click(object sender, EventArgs e)
		{
			Cursor = System.Windows.Forms.Cursors.WaitCursor;
			using (Finder.LedgerZoom frmLedgerZoom = new Liquid.Finder.LedgerZoom())
			{
				if (frmLedgerZoom.ShowDialog() == DialogResult.OK)
				{
					if (frmLedgerZoom.sResult != "")
					{
						txtAdvPmyAlloCashCreditCode.Text = frmLedgerZoom.sResult;
						txtAdvPmyAlloCashCreditName.Text = frmLedgerZoom.sDescription;
					}
				}
				Cursor = System.Windows.Forms.Cursors.Default;
			}
		}

		private void cmdAdvPmtEftDebitSearch_Click(object sender, EventArgs e)
		{
			Cursor = System.Windows.Forms.Cursors.WaitCursor;
			using (Finder.LedgerZoom frmLedgerZoom = new Liquid.Finder.LedgerZoom())
			{
				if (frmLedgerZoom.ShowDialog() == DialogResult.OK)
				{
					if (frmLedgerZoom.sResult != "")
					{
						txtAdvPmtEftDebitCode.Text = frmLedgerZoom.sResult;
						txtAdvPmtEftDebitName.Text = frmLedgerZoom.sDescription;
					}
				}
				Cursor = System.Windows.Forms.Cursors.Default;
			}
		}

		private void cmdAdvPmtEftCreditSearch_Click(object sender, EventArgs e)
		{
			Cursor = System.Windows.Forms.Cursors.WaitCursor;
			using (Finder.LedgerZoom frmLedgerZoom = new Liquid.Finder.LedgerZoom())
			{
				if (frmLedgerZoom.ShowDialog() == DialogResult.OK)
				{
					if (frmLedgerZoom.sResult != "")
					{
						txtAdvPmtEftCreditCode.Text = frmLedgerZoom.sResult;
						txtAdvPmtEftCreditName.Text = frmLedgerZoom.sDescription;
					}
				}
				Cursor = System.Windows.Forms.Cursors.Default;
			}
		}

		private void cmdAdvPmyAlloEftDebitSearch_Click(object sender, EventArgs e)
		{
			Cursor = System.Windows.Forms.Cursors.WaitCursor;
			using (Finder.LedgerZoom frmLedgerZoom = new Liquid.Finder.LedgerZoom())
			{
				if (frmLedgerZoom.ShowDialog() == DialogResult.OK)
				{
					if (frmLedgerZoom.sResult != "")
					{
						txtAdvPmyAlloEftDebitCode.Text = frmLedgerZoom.sResult;
						txtAdvPmyAlloEftDebitName.Text = frmLedgerZoom.sDescription;
					}
				}
				Cursor = System.Windows.Forms.Cursors.Default;
			}
		}

		private void cmdAdvPmyAlloEftCreditSearch_Click(object sender, EventArgs e)
		{
			Cursor = System.Windows.Forms.Cursors.WaitCursor;
			using (Finder.LedgerZoom frmLedgerZoom = new Liquid.Finder.LedgerZoom())
			{
				if (frmLedgerZoom.ShowDialog() == DialogResult.OK)
				{
					if (frmLedgerZoom.sResult != "")
					{
						txtAdvPmyAlloEftCreditCode.Text = frmLedgerZoom.sResult;
						txtAdvPmyAlloEftCreditName.Text = frmLedgerZoom.sDescription;
					}
				}
				Cursor = System.Windows.Forms.Cursors.Default;
			}
		}
		private void cmdSalesDebitSearch_Click(object sender, EventArgs e)
		{
			Cursor = System.Windows.Forms.Cursors.WaitCursor;
			using (Finder.LedgerZoom frmLedgerZoom = new Liquid.Finder.LedgerZoom())
			{
				if (frmLedgerZoom.ShowDialog() == DialogResult.OK)
				{
					if (frmLedgerZoom.sResult != "")
					{
						txtCashDebit.Text = frmLedgerZoom.sResult;
						txtCashDebitName.Text = frmLedgerZoom.sDescription;
					}
				}
				Cursor = System.Windows.Forms.Cursors.Default;
			}
		}

		private void cmdSalesCreditSearch_Click(object sender, EventArgs e)
		{
			Cursor = System.Windows.Forms.Cursors.WaitCursor;
			using (Finder.LedgerZoom frmLedgerZoom = new Liquid.Finder.LedgerZoom())
			{
				if (frmLedgerZoom.ShowDialog() == DialogResult.OK)
				{
					if (frmLedgerZoom.sResult != "")
					{
						txtCashCredit.Text = frmLedgerZoom.sResult;
						txtCashCreditName.Text = frmLedgerZoom.sDescription;
					}
				}
				Cursor = System.Windows.Forms.Cursors.Default;
			}
		}


		private void cmdCardDebitSearch_Click(object sender, EventArgs e)
		{
			Cursor = System.Windows.Forms.Cursors.WaitCursor;
			using (Finder.LedgerZoom frmLedgerZoom = new Liquid.Finder.LedgerZoom())
			{
				if (frmLedgerZoom.ShowDialog() == DialogResult.OK)
				{
					if (frmLedgerZoom.sResult != "")
					{
						txtCardDebit.Text = frmLedgerZoom.sResult;
						txtCardDebitName.Text = frmLedgerZoom.sDescription;
					}
				}
				Cursor = System.Windows.Forms.Cursors.Default;
			}
		}

		private void cmdCardCreditSearch_Click(object sender, EventArgs e)
		{
			Cursor = System.Windows.Forms.Cursors.WaitCursor;
			using (Finder.LedgerZoom frmLedgerZoom = new Liquid.Finder.LedgerZoom())
			{
				if (frmLedgerZoom.ShowDialog() == DialogResult.OK)
				{
					if (frmLedgerZoom.sResult != "")
					{
						txtCardCreditCode.Text = frmLedgerZoom.sResult;
						txtCardCreditName.Text = frmLedgerZoom.sDescription;
					}
				}
				Cursor = System.Windows.Forms.Cursors.Default;
			}
		}

		private void cmdChequeDebitSearch_Click(object sender, EventArgs e)
		{
			Cursor = System.Windows.Forms.Cursors.WaitCursor;
			using (Finder.LedgerZoom frmLedgerZoom = new Liquid.Finder.LedgerZoom())
			{
				if (frmLedgerZoom.ShowDialog() == DialogResult.OK)
				{
					if (frmLedgerZoom.sResult != "")
					{
						txtChequeDebitCode.Text = frmLedgerZoom.sResult;
						txtChequeDebitName.Text = frmLedgerZoom.sDescription;
					}
				}
				Cursor = System.Windows.Forms.Cursors.Default;
			}
		}

		private void cmdChequeCreditSearch_Click(object sender, EventArgs e)
		{
			Cursor = System.Windows.Forms.Cursors.WaitCursor;
			using (Finder.LedgerZoom frmLedgerZoom = new Liquid.Finder.LedgerZoom())
			{
				if (frmLedgerZoom.ShowDialog() == DialogResult.OK)
				{
					if (frmLedgerZoom.sResult != "")
					{
						txtChequeCreditCode.Text = frmLedgerZoom.sResult;
						txtChequeCreditName.Text = frmLedgerZoom.sDescription;
					}
				}
				Cursor = System.Windows.Forms.Cursors.Default;
			}
		}

		private void chkCashDepositPaymentAllocate_CheckedChanged(object sender, EventArgs e)
		{
			if(chkCashDepositPaymentAllocate.Checked)
				setDepositPaymentFields(false);
			else
				setDepositPaymentFields(true);
		}

		private void rbDepositGlEft_CheckedChanged(object sender, EventArgs e)
		{
			if (rbDepositGlEft.Checked)
				SetDepositEftFields(true);
			else
				SetDepositEftFields(false);
		}

		private void chkDepEftPmtAllocate_CheckedChanged(object sender, EventArgs e)
		{
			if (chkDepEftPmtAllocate.Checked)
				SetDepositEftPmtAlloFields(false);
			else
				SetDepositEftPmtAlloFields(true);
		}

		private void rbAdvPmtCashGL_CheckedChanged(object sender, EventArgs e)
		{
			if (rbAdvPmtCashGL.Checked)
				SetAdvPmtCashFields(true);
			else
				SetAdvPmtCashFields(false);
		}

		private void chkAdvPmtAlloCash_CheckedChanged(object sender, EventArgs e)
		{
			if (chkAdvPmtAlloCash.Checked)
				SetAdvPmtCashAlloFields(false);
			else
				SetAdvPmtCashAlloFields(true);
		}

		private void rbAdvPmtEftGL_CheckedChanged(object sender, EventArgs e)
		{
			if (rbAdvPmtEftGL.Checked)
				SetAdvPmtEftFields(true);
			else
				SetAdvPmtEftFields(false);
		}

		private void chkAdvPmtAlloEft_CheckedChanged(object sender, EventArgs e)
		{
			if (chkAdvPmtAlloEft.Checked)
				SetAdvPmtEftAlloFields(false);
			else
				SetAdvPmtEftAlloFields(true);
		}

		private void chkCashCustomerAllwaysLink_CheckedChanged(object sender, EventArgs e)
		{
			setSaveButton();

			bool bEnable = true;

			if (chkCashCustomerAllwaysLink.Checked)
				bEnable = false;

			gbCashSales.Enabled = bEnable;
			gbCardSales.Enabled = bEnable;
			gbEftSales.Enabled = bEnable;

			//txtCashDebit.Text = "";
			//txtCashDebitName.Text = "";
			//cmdSalesDebitSearch.Enabled = bEnable;
			//txtCashCredit.Text = "";
			//txtCashCreditName.Text = "";
			//cmdSalesCreditSearch.Enabled = bEnable;

			//txtCardDebit.Text = "";
			//txtCardDebitName.Text = "";
			//cmdCardDebitSearch.Enabled = bEnable;
			//txtCardCreditCode.Text = "";
			//txtCardCreditName.Text = "";
			//cmdCardCreditSearch.Enabled = bEnable;

			//txtChequeDebitCode.Text = "";
			//txtChequeDebitName.Text = "";
			//cmdChequeDebitSearch.Enabled = bEnable;
			//txtChequeCreditCode.Text = "";
			//txtChequeCreditName.Text = "";
			//cmdChequeCreditSearch.Enabled = bEnable;
		}

		private void chkTransactionsForDeposits_CheckedChanged(object sender, EventArgs e)
		{
			setSaveButton();

			bool bEnable = true;

			if (chkTransactionsForDeposits.Checked)
				bEnable = false;

			setTransactionDepositFields(bEnable);
		}

		private void setTransactionDepositFields(bool bEnable)
		{
			gbDeposits.Enabled = bEnable;
			gbDepositsEft.Enabled = bEnable;

		}

		private void chkTransactionsForAdvPmt_CheckedChanged(object sender, EventArgs e)
		{
			setSaveButton();

			bool bEnable = true;

			if (chkTransactionsForAdvPmt.Checked)
				bEnable = false;

			setTransactionAdvPmtFields(bEnable);
			
		}
		private void setTransactionAdvPmtFields(bool bEnable)
		{
			gbAdvPmtCash.Enabled = bEnable;
			gbAdvPmtEft.Enabled = bEnable;
		}

		private void txtGoodsIssueNumber_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!(Char.IsDigit(e.KeyChar) || Char.IsControl(e.KeyChar)))
				e.Handled = true;
		}

		private void txtDepositReceivedNumber_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!(Char.IsDigit(e.KeyChar) || Char.IsControl(e.KeyChar)))
				e.Handled = true;
		}

		private void txtPaymentReceivedNumber_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!(Char.IsDigit(e.KeyChar) || Char.IsControl(e.KeyChar)))
				e.Handled = true;
		}

		private void cmdFindRoundingAccount_Click(object sender, EventArgs e)
		{
			Cursor = System.Windows.Forms.Cursors.WaitCursor;
			using (Finder.LedgerZoom frmLedgerZoom = new Liquid.Finder.LedgerZoom())
			{
				if (frmLedgerZoom.ShowDialog() == DialogResult.OK)
				{
					if (frmLedgerZoom.sResult != "")
					{
						txtRoundingAcc.Text = frmLedgerZoom.sResult;
						txtRoundingAccDetail.Text = frmLedgerZoom.sDescription;
					}
				}
				Cursor = System.Windows.Forms.Cursors.Default;
			}
		}

		private void btnSearchSDKUser_Click(object sender, EventArgs e)
		{
			Cursor = System.Windows.Forms.Cursors.WaitCursor;
			using (Finder.SDKUsers frmSDKUser = new Liquid.Finder.SDKUsers())
			{
				if (frmSDKUser.ShowDialog() == DialogResult.OK)
				{
					if (frmSDKUser.sSelectedSDKUserCode != "")
					{
						txtDefSDKUser.Text = frmSDKUser.sSelectedSDKUserCode;
						txtDefSDKUser.Focus();
						txtDefSDKUser.SelectionStart = 0;
						txtDefSDKUser.SelectionLength = txtDefSDKUser.Text.Length;
					}
				}
			}

			Cursor = System.Windows.Forms.Cursors.Default;
		}

		private void btnDocPrinterSearch_Click(object sender, EventArgs e)
		{
			Cursor = System.Windows.Forms.Cursors.WaitCursor;
			using (Finder.PrintersZoom frmPrinters = new Liquid.Finder.PrintersZoom())
			{
				if (frmPrinters.ShowDialog() == DialogResult.OK)
				{
					if (frmPrinters.sSelectedPrinterName != "")
					{
						txtDocPrinterName.Text = frmPrinters.sSelectedPrinterName;

						txtDocPrinterName.Focus();
						txtDocPrinterName.SelectionStart = 0;
						txtDocPrinterName.SelectionLength = txtDocPrinterName.Text.Length;
					}
				}
			}

			Cursor = System.Windows.Forms.Cursors.Default;
		}

		private void btnSlipPrinterSearch_Click(object sender, EventArgs e)
		{
			Cursor = System.Windows.Forms.Cursors.WaitCursor;
			using (Finder.PrintersZoom frmPrinters = new Liquid.Finder.PrintersZoom())
			{
				if (frmPrinters.ShowDialog() == DialogResult.OK)
				{
					if (frmPrinters.sSelectedPrinterName != "")
					{
						txtSlipPrinterName.Text = frmPrinters.sSelectedPrinterName;

						txtSlipPrinterName.Focus();
						txtSlipPrinterName.SelectionStart = 0;
						txtSlipPrinterName.SelectionLength = txtSlipPrinterName.Text.Length;
					}
				}
			}

			Cursor = System.Windows.Forms.Cursors.Default;
		}

		private void txtDocPrinterName_TextChanged(object sender, EventArgs e)
		{
			cmdSave.Enabled = true;
		}

		private void cmdDefaultRule_Click(object sender, EventArgs e)
		{
			Cursor = System.Windows.Forms.Cursors.WaitCursor;
			using (Liquid.Finder.RuleZoom frmRuleZoom = new Liquid.Finder.RuleZoom())
			{
				if (frmRuleZoom.ShowDialog() == DialogResult.OK)
				{
					if (frmRuleZoom.sRuleID != "")
					{
						txtDefaultRule.Text = frmRuleZoom.sRuleNameReturn;
						txtDefaultRuleID.Text = frmRuleZoom.sRuleID;
					}
				}
			}

			Cursor = System.Windows.Forms.Cursors.Default;
		}

		private void chkNotifyIfCustOverLimit_CheckedChanged(object sender, EventArgs e)
		{
			if (chkNotifyIfCustOverLimit.Checked)
			{
				chkAutoBlockCustomer.Enabled = false;
				chkAutoBlockCustomer.Checked = false;
			}
			else
			{
				chkAutoBlockCustomer.Enabled = true;                
			}
		}

		private void txtEmailBody_TextChanged(object sender, EventArgs e)
		{

		}

		private void txtSmtpClient_TextChanged(object sender, EventArgs e)
		{

		}

		private void tpPartialDays_Click(object sender, EventArgs e)
		{

		}

		private void button3_Click(object sender, EventArgs e)
		{
			Cursor = System.Windows.Forms.Cursors.WaitCursor;
			using (Finder.PrintersZoom frmPrinters = new Liquid.Finder.PrintersZoom())
			{
				if (frmPrinters.ShowDialog() == DialogResult.OK)
				{
					if (frmPrinters.sSelectedPrinterName != "")
					{
						txtDocPrinterName.Text = frmPrinters.sSelectedPrinterName;

						txtDocPrinterName.Focus();
						txtDocPrinterName.SelectionStart = 0;
						txtDocPrinterName.SelectionLength = txtDocPrinterName.Text.Length;
					}
				}
			}

			Cursor = System.Windows.Forms.Cursors.Default;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Cursor = System.Windows.Forms.Cursors.WaitCursor;
			using (Finder.PrintersZoom frmPrinters = new Liquid.Finder.PrintersZoom())
			{
				if (frmPrinters.ShowDialog() == DialogResult.OK)
				{
					if (frmPrinters.sSelectedPrinterName != "")
					{
						txtSlipPrinterName.Text = frmPrinters.sSelectedPrinterName;

						txtSlipPrinterName.Focus();
						txtSlipPrinterName.SelectionStart = 0;
						txtSlipPrinterName.SelectionLength = txtSlipPrinterName.Text.Length;
					}
				}
			}

			Cursor = System.Windows.Forms.Cursors.Default;

		}

		private void label47_Click(object sender, EventArgs e)
		{

		}

		private void cmdQuotePath_Click(object sender, EventArgs e)
		{
			
			DialogResult result = this.folderBrowserDialog1.ShowDialog();
			if (result == DialogResult.OK)
			{
				txtQuotePath.Text = folderBrowserDialog1.SelectedPath;

			}
		}

        private void defaultInvoiceUserSearchBtn_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            using (Finder.SDKUsers frmSDKUser = new Liquid.Finder.SDKUsers())
            {
                if (frmSDKUser.ShowDialog() == DialogResult.OK)
                {
                    if (frmSDKUser.sSelectedSDKUserCode != "")
                    {
                        txtDefInvoiceUser.Text = frmSDKUser.sSelectedSDKUserCode;
                        txtDefInvoiceUser.Focus();
                        txtDefInvoiceUser.SelectionStart = 0;
                        txtDefInvoiceUser.SelectionLength = txtDefSDKUser.Text.Length;
                    }
                }
            }

            Cursor = Cursors.Default;
        }

        private void cmdFindLeavyAccount_Click(object sender, EventArgs e)
        {
			Cursor = Cursors.WaitCursor;
			using (Finder.LedgerZoom frmLedgerZoom = new Liquid.Finder.LedgerZoom())
			{
				if (frmLedgerZoom.ShowDialog() == DialogResult.OK)
				{
					if (frmLedgerZoom.sResult != "")
					{
						txtLeaseLevyAcc.Text = frmLedgerZoom.sResult;
						txtLeaseLeavyAccDetail.Text = frmLedgerZoom.sDescription;
					}
				}
				Cursor = Cursors.Default;
			}
		}

        //private void chkNoGLAllocDepCash_CheckedChanged(object sender, EventArgs e)
        //{
        //    setSaveButton();

        //    bool bEnable = true;

        //    if (chkNoGLAllocDepCash.Checked)
        //        bEnable = false;

        //    chkCashDepositPaymentAllocate.Enabled = bEnable;
        //    chkCashDepositPaymentAllocate.Checked = false;
        //    txtCashDepAllocateDebitCode.Enabled = bEnable;
        //    txtCashDepAllocateDebitCode.Text = "";
        //    txtCashDepAllocateDebitName.Enabled = bEnable;
        //    txtCashDepAllocateDebitName.Text = "";
        //    lblCashDepAllocateDebit.Enabled = bEnable;
        //    cmdCashDepAllocateDebitSearch.Enabled = bEnable;

        //    txtCashDepAllocateCreditCode.Enabled = bEnable;
        //    txtCashDepAllocateCreditCode.Text = "";
        //    txtCashDepAllocateCreditName.Enabled = bEnable;
        //    txtCashDepAllocateCreditName.Text = "";
        //    lblCashDepAllocateCredit.Enabled = bEnable;
        //    cmdCashDepAllocateCreditSearch.Enabled = bEnable;
        //}



    }
}