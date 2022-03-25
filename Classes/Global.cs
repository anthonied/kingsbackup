using System;
using System.Windows.Forms;
using Liquid.Domain;
using Liquid.Domain.Interfaces;
using Liquid.Forms;
using Liquid.Services;

namespace Liquid.Classes
{
	public static class Global
	{
        public static string DeliveryNoteMessage;
        public static string sLogedInUserName;
		public static string sLogedInUserCode;
		public static string sLogedInUserType;
		public static Main frmMain;
		public static Login frmLogin;
		public static int iCreditInvoice;
		public static string DefaultMultiStore;
		public static string sCurrFinPeriod;
		public static string sDeliveryNoteCompany;
		public static string sInvoiceContactName;
        public static string sInvoiceContactNumber;
        public static bool bAutoInvoiceOnReturn;
		public static string sDefaultDocPrinter;
		public static string sDefaultSlipPrinter;
		public static string sDeliveryNoteFirstPrintCopies;
		public static string sDeliveryNoteDuplicatePrintCopies;
		public static string sInvoiceFirstPrintCopies;
		public static string sInvoiceDuplicatePrintCopies;
		public static int iPastelSdkUser;
        public static int iDefaultInvoiceUser;
        public static string sCompanyName = "", sRegName = "", sVAT = "", sReg = "", sCompanyTel = "", sCompanyAd1 = "", sCompanyAd2 = "", sCompanyAd3 = "", sCompanyFax = "", sCompanyPostAd1 = "", sCompanyPostAd2 = "", sCompanyPostAd3 = "", sCompanyPostAd4 = "";
		public static bool bUserMaxNewNumber; //New salesorder number creation
		public static bool bRoundingCOD;
		public static bool bGenerateZeroInvoice;
		public static bool bAutoBlockCustomer;
		public static bool bNotifyIfcustoverCredtiLimit;
		public static bool bLiquidHandlesInvt; //JR13 6/8/2011

		public static string sDeliveryNoteTemplate;
		public static string sInvoiceTemplate;
		public static string sQuoteTemplate;
		//Transfer SETUP Variables
		public static string sActiveCompanyName;
		public static string sDataPath;
		public static string sApplicationPath;
		public static string sPastelConn;
		public static string sSolPMSConn;
		public static bool bManufacturing;
		public static bool bUseBackground;
		public static bool bLogCreateDocument;
		public static string sGlobalDefaultRule;
		public static string sGlobalDefaultRuleID;
		public static bool bUseCalculationRules;
		public static bool bUseQuantityMeasure = false;
		public static string sEmailAddressFrom1;
		public static string sEmailPasswordFrom1;
		public static string sEmailAddressFrom2;
		public static string sEmailPasswordFrom2;
		public static string sEmailAddressFrom3;
		public static string sEmailPasswordFrom3;
		public static string sSmtpClient;
		public static string sSmtpClientPort;
        public static string sEmailBody;
        public static string sTermsAndConditions;

        public static string sQuotePath;
        public static int iReturnItem;
	    public static string sSmtpClientPassword;
	    public static string sSmtpOutgoing;
	    public static string sSmtpClientUserName { get; set; }


	    public static void ThrowError(Exception e)
	    {
	       var errorForm = new Error(e.Message);
	        if (errorForm.ShowDialog() == DialogResult.Abort)
	            Application.Exit();
	    }


	    public static IPastelService CreatePastelService()
	    {
            return new PastelService(new SdkSettings { User = iPastelSdkUser, DataPath = sDataPath, InvoiceUser = iDefaultInvoiceUser });
	    }
	}
}
