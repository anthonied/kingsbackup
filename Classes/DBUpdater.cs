using System;
using Pervasive.Data.SqlClient;
using System.Windows.Forms;

namespace Liquid.Classes
{
	class DBUpdater
	{
	   
		public static string sReleaseNotes = "*** Update Notes *** \r\n";

		public static int iLatestVersion = 131;
		public static int iCurrVersion;

		public static void FetchVersionDetails()
		{		  
			using (PsqlConnection oConn = new PsqlConnection(Connect.LiquidConnectionString))
			{
				try
				{
					oConn.Open();

				}
				catch (Exception Ex)
				{
					MessageBox.Show("Error connecting to Liquid Database:" + Ex,"Connection Error");
					Application.Exit();
				}
		   
				string sSql = "SELECT * FROM SOLUPD";			 
				PsqlDataReader rdReader = Connect.getDataCommand(sSql, oConn).ExecuteReader();
				while (rdReader.Read())
				{                    
					iCurrVersion = Convert.ToInt32(rdReader["CurrentVersion"].ToString().Trim());                    
				}
			 
				rdReader.Close();
			}   
		}

		public static void UpdateToLatest()
		{            
			using (var liquidConnection = new PsqlConnection(Connect.LiquidConnectionString))
			{
				var sql = "";

				int iReturn;
				liquidConnection.Open();
				
				#region VER. 1 - 30

				if (iCurrVersion < 1)
				{
					sql = "UPDATE SOLAS SET Description = '' WHERE AssetNumber = ''";
					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();

					sReleaseNotes += " - Liquid Updater is now successfully installed \r\n\r\n";
				}

				if (iCurrVersion < 2)
				{
					sql = "    ALTER TABLE \"SOLHL\"(ADD COLUMN \"Multiplier\" DECIMAL(8,2) DEFAULT '1', ADD COLUMN \"Qty\" DECIMAL(8,2) DEFAULT '1');";
					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
					sReleaseNotes += "Version 1.2 - Author:  AJD \r\n";
					sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					sReleaseNotes += "Added multiplier in the Sales Order Table.\r\n\r\n";
				}

				if (iCurrVersion < 3)
				{
					sql = "ALTER TABLE \"SOLMBI\"(ADD COLUMN \"Target\" INTEGER);";


					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
					sReleaseNotes += "Version 1.3 - Author:  AJD \r\n";
					sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					sReleaseNotes += "Added Target Field for manufacturing module.\r\n\r\n";
				}

				if (iCurrVersion < 4)
				{
					sql = "ALTER TABLE \"SOLUS\"(ADD COLUMN \"CancelReturnItem\" INTEGER);";

					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
					sReleaseNotes += "Version 1.4 - Author:  AJD \r\n";
					sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					sReleaseNotes += "Enable/decline user to return items.\r\n\r\n";
				}

				if (iCurrVersion < 5)
				{
					sql = "CREATE TABLE \"SOLTS\"(";
					sql += "\"Customer_Ref\" VARCHAR(50) CASE ,";
					sql += "\"IP_Destination\" VARCHAR(50) CASE ,";
					sql += "\"Supplier_Ref\" VARCHAR(50) CASE ,";
					sql += "\"Data_Path\" VARCHAR(50) CASE ,";
					sql += "\"PKiTransferSetupID\" IDENTITY DEFAULT '0',";
					sql += "PRIMARY KEY (\"PKiTransferSetupID\"));";

					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();

					sReleaseNotes += "Version 1.5 - Author:  JR \r\n";
					sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					sReleaseNotes += "Added TRASNFER SETUP Table.\r\n\r\n";
				}

				if (iCurrVersion < 6)
				{
					sql = "ALTER TABLE \"SOLCS\"(ADD COLUMN \"DefaultSDKUser\" INTEGER DEFAULT '0');";

					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
					sReleaseNotes += "Version 1.6 - Author:  JR \r\n";
					sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					sReleaseNotes += "Enable Default SDK Users on Company Setup.\r\n\r\n";
				}

				if (iCurrVersion < 7)
				{
					sql = "ALTER TABLE \"SOLCS\"(ADD COLUMN \"DefaultDocPrinter\" VARCHAR(255), ADD COLUMN \"DefaultSlipPrinter\" VARCHAR(255));";

					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
					sReleaseNotes += "Version 1.7 - Author:  JR \r\n";
					sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					sReleaseNotes += "Enable Default Printer Settings on Company Setup.\r\n\r\n";
				}

				if (iCurrVersion < 8)
				{
					sql = "ALTER TABLE \"SOLMBI\"( MODIFY COLUMN \"Target\" INTEGER DEFAULT '0');";

					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
					sReleaseNotes += "Version 1.8 - Author:  DDK \r\n";
					sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					sReleaseNotes += "Default value for manufacture target.\r\n\r\n";
				}


				if (iCurrVersion < 9)
				{
					sql = "CREATE TABLE \"SOLMSM\"(\"ItemCode\" VARCHAR(15) NOT NULL  CASE ,\"ItemDesription\" VARCHAR(40) CASE ,\"Quantity\" DECIMAL(8,2),\"BatchReference\" VARCHAR(40) CASE ,\"DocumentNumber\" VARCHAR(15) CASE ,\"UserName\" VARCHAR(40) CASE ,\"ItemDate\" CHAR(50) CASE);";

					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
					sReleaseNotes += "Version 1.9 - Author:  DDK \r\n";
					sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					sReleaseNotes += "Create SolMSM.\r\n\r\n";

				}

				if (iCurrVersion < 10)
				{
					sql = "ALTER TABLE \"SOLCS\"( DROP COLUMN \"InvoiceMessage01\", DROP COLUMN \"InvoiceMessage02\", DROP COLUMN \"CreditNoteMessage01\", DROP COLUMN \"CreditNoteMessage02\");";
					sReleaseNotes += "Version 1.10 - Author:  ADK \r\n";
					sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					try
					{
						iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
						sReleaseNotes += "Drop invoice and credit note message fields.\r\n\r\n";
					}
					catch (Exception ex)
					{
						sReleaseNotes += "Invoice and credit note message fields already deleted.\r\n\r\n";
					}

					sql = "ALTER TABLE \"SOLCS\"(ADD COLUMN \"InvoiceContactName\" VARCHAR(50) CASE , ADD COLUMN \"InvoiceContactNumber\" VARCHAR(50) CASE , ADD COLUMN \"DeliveryNoteCompany\" VARCHAR(100) CASE );";
					try
					{
						iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
						sReleaseNotes += "Add Invoice Contact Name, InvoiceContactNumber and DeliveryNote CompanyName.\r\n\r\n";
					}
					catch (Exception ex)
					{
						sReleaseNotes += " Invoice Contact Name, InvoiceContactNumber and DeliveryNote CompanyName allready in database.\r\n\r\n";
					}


				}

				if (iCurrVersion < 11)
				{
					sql = "  ALTER TABLE \"SOLCS\"( ADD COLUMN \"AutoInvoiceOnReturn\" INTEGER);";

					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
					sReleaseNotes += "Version 1.11 - Author:  ADK \r\n";
					sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					sReleaseNotes += "Add option to invoice directly after items is returned.\r\n\r\n";
				}

				if (iCurrVersion < 12)
				{
					sql = "CREATE TABLE \"SOLMGS\"(\"GroupID\" IDENTITY DEFAULT '0',\"Name\" VARCHAR(40) CASE ,\"Description\" VARCHAR(40) CASE ,\"WeightUnit\" VARCHAR(20) CASE);";

					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
					sReleaseNotes += "Version 1.12 - Author:  DDK \r\n";
					sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					sReleaseNotes += "Create SolMGS.\r\n\r\n";
				}

				if (iCurrVersion < 13)
				{
					sql = "CREATE TABLE \"SOLMGI\"(\"GroupItemID\" IDENTITY DEFAULT '0',\"FkGroupID\" INTEGER NOT NULL ,\"FkItemID\" INTEGER NOT NULL ,\"WeightMeasurement\" DECIMAL(8,2));";

					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
					sReleaseNotes += "Version 1.13 - Author:  DDK \r\n";
					sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					sReleaseNotes += "Create SolMGI.\r\n\r\n";
				}

				if (iCurrVersion < 14)
				{
					sql = "CREATE TABLE \"SOLTCOMP\"(";
					sql += "\"iCompletedID\" IDENTITY,";
					sql += "\"sDocNum\" VARCHAR(50) CASE ,";
					sql += "\"sTransToIP\" VARCHAR(255) CASE ,";
					sql += "\"sTransToDataPath\" CHAR(50) CASE ,";
					sql += "\"dtTimeCompleted\" DATETIME,";
					sql += "PRIMARY KEY (\"iCompletedID\"));";

					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
					sReleaseNotes += "Version 1.14 - Author:  JR \r\n";
					sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					sReleaseNotes += "Creates table that captures completed transfers in Liquid Transfer.\r\n\r\n";
				}

				if (iCurrVersion < 15)
				{
					sql = "CREATE TABLE \"SOLTERR\"(";
					sql += "\"sTransferErrorID\" IDENTITY,";
					sql += "\"sDocNum\" VARCHAR(50) CASE ,";
					sql += "\"sTransToIP\" VARCHAR(255) CASE ,";
					sql += "\"sTransToDataPath\" VARCHAR(255) CASE ,";
					sql += "\"dtTimeFailed\" DATETIME,";
					sql += "\"sErrorInfo\" VARCHAR(255) CASE ,";
					sql += "PRIMARY KEY (\"sTransferErrorID\"));";

					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
					sReleaseNotes += "Version 1.15 - Author:  JR \r\n";
					sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					sReleaseNotes += "Creates table that captures transfer errors in Liquid Transfer.\r\n\r\n";
				}

				if (iCurrVersion < 16)
				{
					sql = "ALTER TABLE \"SOLTS\"( ADD COLUMN \"SOLPMS_ConnString\" VARCHAR(255) CASE);";

					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
					sReleaseNotes += "Version 1.16 - Author:  JR \r\n";
					sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					sReleaseNotes += "Add Column for SOLPMS Connection String in SOLTS.\r\n\r\n";
				}

				if (iCurrVersion < 17)
				{
					sql = "ALTER TABLE \"SOLTCOMP\"(ADD COLUMN \"sReceivedDocNum\" VARCHAR(50) CASE);";

					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
					sReleaseNotes += "Version 1.17 - Author:  JR \r\n";
					sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					sReleaseNotes += "Add Column for Received Doc Number in SOLTCOMP.\r\n\r\n";
				}

				if (iCurrVersion < 18)
				{
					sql = "ALTER TABLE \"SOLTCOMP\"(RENAME COLUMN \"sDocNum\" TO \"sSentDocNum\");";

					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
					sReleaseNotes += "Version 1.18 - Author:  JR \r\n";
					sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					sReleaseNotes += "Rename Column in SOLTCOMP.\r\n\r\n";
				}

				if (iCurrVersion < 21)
				{
					sql = "CREATE TABLE \"SOLRCOMP\"(";
					sql += "\"iRecCompletedID\" IDENTITY,";
					sql += "\"sSenderDocNum\" VARCHAR(50) CASE ,";
					sql += "\"sReceiverDocNum\" VARCHAR(50) CASE ,";
					sql += "\"sReceiverDocType\" VARCHAR(10) CASE ,";
					sql += "\"dtTimeCompleted\" DATETIME,";
					sql += "PRIMARY KEY (\"iRecCompletedID\"));";

					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
					sReleaseNotes += "Version 1.19 - Author:  JR \r\n";
					sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					sReleaseNotes += "Creates table that captures successfull Pastel entries on the receiving machine.\r\n\r\n";
				}

				if (iCurrVersion < 20)
				{
					sql = "ALTER TABLE \"SOLCS\"( ADD COLUMN \"ScannedStockPrefix\" CHAR(3) CASE, ADD COLUMN \"ScannedStockNumber\" INTEGER);";

					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
					sReleaseNotes += "Version 1.20 - Author:  DDK \r\n";
					sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					sReleaseNotes += "Alter Table SOLCS.\r\n\r\n";
				}

				//if (iCurrVersion < 21)
				//{
				//    sSql = "ALTER TABLE \"SOLTCOMP\"( ADD COLUMN \"sUserCode\" VARCHAR(50) CASE, ADD COLUMN \"sUserName\" VARCHAR(100) CASE);";

				//    iReturn = Connect.getDataCommand(sSql, oConn).ExecuteNonQuery();
				//    sReleaseNotes += "Version 1.21 - Author:  JR \r\n";
				//    sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
				//    sReleaseNotes += "Add \"Logged in User\" Columns to SOLTCOMP.\r\n\r\n";
				//}


				if (iCurrVersion < 22)
				{
					sql = "ALTER TABLE \"SOLRCOMP\"( ADD COLUMN \"sUserCode\" VARCHAR(50) CASE, ADD COLUMN \"sUserName\" VARCHAR(100) CASE);";

					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
					sReleaseNotes += "Version 1.22 - Author:  JR \r\n";
					sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					sReleaseNotes += "Add \"Logged in User\" Columns to SOLRCOMP.\r\n\r\n";
				}


				if (iCurrVersion < 23)
				{
					sql = "ALTER TABLE \"SOLTERR\"( ADD COLUMN \"sUserCode\" VARCHAR(50) CASE, ADD COLUMN \"sUserName\" VARCHAR(100) CASE);";

					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
					sReleaseNotes += "Version 1.23 - Author:  JR \r\n";
					sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					sReleaseNotes += "Add \"Logged in User\" Columns to SOLTERR.\r\n\r\n";
				}

				if (iCurrVersion < 24)
				{
					sql = "ALTER TABLE \"SOLRCOMP\"( RENAME COLUMN \"iRecCompletedID\" TO \"sRecCompletedID\");";

					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
					sReleaseNotes += "Version 1.24 - Author:  JR \r\n";
					sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					sReleaseNotes += "Allow for Unique Key on Transfer Receiving.\r\n\r\n";
				}

				if (iCurrVersion < 25)
				{
					sql = "ALTER TABLE \"SOLRCOMP\"( MODIFY COLUMN \"sRecCompletedID\" VARCHAR(50) NOT NULL CASE);";

					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
					sReleaseNotes += "Version 1.25 - Author:  JR \r\n";
					sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					sReleaseNotes += "Allow for Unique Key on Transfer Receiving.\r\n\r\n";
				}

				if (iCurrVersion < 26)
				{
					sql = "CREATE TABLE \"SOLMRBS\"(\"RawBatchID\" IDENTITY,\"RawBatchName\" VARCHAR(50) CASE ,\"RawBatchDescription\" VARCHAR(50) CASE);";

					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
					sReleaseNotes += "Version 1.26 - Author:  DDK \r\n";
					sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					sReleaseNotes += "Creates table for RawBatchSetup.\r\n\r\n";
				}

				if (iCurrVersion < 27)
				{
					sql = "CREATE TABLE \"SOLMRBI\"(\"RawBatchItemID\" IDENTITY DEFAULT '0',\"FkRawBatchID\" INTEGER NOT NULL ,\"FkItemCode\" VARCHAR(20) CASE ,\"ItemDescription\" VARCHAR(40) CASE ,\"Quantity\" DECIMAL(8,2));";

					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
					sReleaseNotes += "Version 1.27 - Author:  DDK \r\n";
					sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					sReleaseNotes += "Creates table for RawBatchInventory.\r\n\r\n";
				}
				if (iCurrVersion < 28)
				{
					sql = "ALTER TABLE \"SOLCS\"( ADD COLUMN \"RoundingCOD\" BIT DEFAULT '0' NOT NULL);";

					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
					sReleaseNotes += "Version 1.28 - Author:  ADK \r\n";
					sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					sReleaseNotes += "Allow Rounding for non COD clients\r\n\r\n";
				}

				if (iCurrVersion < 29)
				{
					sql = "ALTER TABLE \"SOLCS\"(ADD COLUMN \"DeliveryNoteTemplate\" CHAR(100) CASE , ADD COLUMN \"InvoiceTemplate\" CHAR(100) CASE );";

					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
					sReleaseNotes += "Version 1.29 - Author:  ADK \r\n";
					sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					sReleaseNotes += "Set templates for delivery notes and invoices in company setup.\r\n\r\n";
				}

				if (iCurrVersion < 30)
				{
					sql = "ALTER TABLE \"SOLTERR\"(ADD COLUMN \"iHandled\" INTEGER DEFAULT '0');";

					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
					sReleaseNotes += "Version 1.30 - Author:  JR \r\n";
					sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					sReleaseNotes += "Add column to show User Intervention on Error.\r\n\r\n";
				}

				#endregion 

				#region VER. 31 - 55
				if (iCurrVersion < 31)
				{
					sql = "ALTER TABLE \"SOLTS\"(ADD COLUMN \"Receiver_Alias\" VARCHAR(50) CASE);";

					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
					sReleaseNotes += "Version 1.31 - Author:  JR \r\n";
					sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					sReleaseNotes += "Add column to store Receiver Alias.\r\n\r\n";
				}
				if (iCurrVersion < 32)
				{
					sql = "   CREATE TABLE \"SOLIL\"( \"DocumentNumber\" CHAR(8) NOT NULL  CASE , \"ItemCode\" CHAR(15) NOT NULL  CASE , \"FromDate\" DATE, \"ToDate\" DATE, \"LinkNum\" INTEGER NOT NULL , \"Multiplier\" DECIMAL(8,2), \"Qty\" DECIMAL(8,2));";
					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
					sReleaseNotes += "Version 1.32 - Author:  ADK \r\n";
					sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					sReleaseNotes += "New table to handle invoice information not stored in Pastel.\r\n\r\n";
				}

				if (iCurrVersion < 33)
				{
					sql = "ALTER TABLE \"SOLMSM\"(ADD COLUMN \"POItemCode\" VARCHAR(15) NOT NULL  CASE, RENAME COLUMN \"ItemCode\" TO \"GeneralItemCode\", RENAME COLUMN \"Quantity\" TO \"QuantityScanned\", ADD COLUMN \"TotalBatchQuantity\" DECIMAL(8,2));";

					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
					sReleaseNotes += "Version 1.33 - Author:  JR \r\n";
					sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					sReleaseNotes += "Alter SOLMSM add linkedItem.\r\n\r\n";
				}

				if (iCurrVersion < 34)
				{
					sql = "ALTER TABLE \"SOLIL\"( MODIFY COLUMN \"FromDate\" CHAR(10) CASE , MODIFY COLUMN \"ToDate\" CHAR(10) CASE );";

					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
					sReleaseNotes += "Version 1.34 - Author:  LL \r\n";
					sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					sReleaseNotes += "Alter SOLIL changes dates to Char.\r\n\r\n";
				}

				if (iCurrVersion < 35)
				{
					sql = "CREATE TABLE \"SOLSS\"(";
					sql += "\"PKiSyncSetupID\" IDENTITY,";
					sql += "\"sReceiverRef\" VARCHAR(50) CASE ,";
					sql += "\"sReceiverAlias\" VARCHAR(50) CASE ,";
					sql += "\"sReceiverIP\" VARCHAR(50) CASE ,";
					sql += "\"sDataPath\" VARCHAR(100) CASE ,";
					sql += "\"sSourceRef\" VARCHAR(50) CASE ,";
					sql += "\"sLiquidConn\" VARCHAR(50) CASE ,";
					sql += "PRIMARY KEY (\"PKiSyncSetupID\"));";

					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();

					sReleaseNotes += "Version 1.35 - Author:  JR \r\n";
					sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					sReleaseNotes += "Added SOLSS Table.\r\n\r\n";
				}

				if (iCurrVersion < 36)
				{
					sql = "ALTER TABLE \"SOLIL\"( ADD COLUMN \"Description\" CHAR(40) CASE);";

					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
					sReleaseNotes += "Version 1.36 - Author:  ADK \r\n";
					sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					sReleaseNotes += "Added Description in invoice line to create key with historylines in order to get LinkNum of the invoice line.\r\n\r\n";
				}

				if (iCurrVersion < 37)
				{
					sql = "CREATE TABLE \"SOLMRBR\"(\"RBRID\" IDENTITY DEFAULT '0',\"FkRawBatchID\" INTEGER,\"UserName\" VARCHAR(40) CASE ,\"Date\" CHAR(50) CASE ,\"DocumentNumber\" VARCHAR(15) CASE );";

					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
					sReleaseNotes += "Version 1.37 - Author:  DDK \r\n";
					sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					sReleaseNotes += "Add Raw Batch Recieved Table";
				}

				if (iCurrVersion < 38)
				{
					sql = "CREATE TABLE \"SOLMRBFI\"(\"FkRawBatchID\" INTEGER,\"FinishedItemCode\" VARCHAR(30) CASE ,\"QuantityItems\" INTEGER,\"ItemDescription\" VARCHAR(40) CASE ,\"QuantityBatches\" INTEGER);";

					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
					sReleaseNotes += "Version 1.38 - Author:  DDK \r\n";
					sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					sReleaseNotes += "Add Raw Batch Finished Items Table";
				}

				if (iCurrVersion < 39)
				{
					sql = "CREATE TABLE \"SOLMSMBM\"(\"BarcodeID\" IDENTITY DEFAULT '0',\"PONumber\" VARCHAR(10) CASE ,\"POItemCode\" VARCHAR(20) CASE );";

					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
					sReleaseNotes += "Version 1.39 - Author:  DDK \r\n";
					sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					sReleaseNotes += "Add Raw Stock Barcode Mapping Table";
				}

				if (iCurrVersion < 40)
				{
					sql = "ALTER TABLE \"SOLSS\"( ADD COLUMN \"sPastelConn\" CHAR(50) CASE);";

					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
					sReleaseNotes += "Version 1.40 - Author:  JR \r\n";
					sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					sReleaseNotes += "Add Pastel Connection string in SyncSetup.\r\n\r\n";
				}

				if (iCurrVersion < 41)
				{
					sql = "CREATE TABLE \"SOLSCOMP\"(";
					sql += "\"iCompletedSyncID\" IDENTITY,";
					sql += "\"sSentGLCode\" VARCHAR(50) CASE ,";
					sql += "\"sReceiverIP\" VARCHAR(50) CASE ,";
					sql += "\"sReceiverDataPath\" CHAR(255) CASE ,";
					sql += "\"dtDateTimeCompleted\" DATETIME,";
					sql += "\"sLiquidUserCode\" CHAR(50) CASE ,";
					sql += "\"sLiquidUserName\" CHAR(50) CASE ,";
					sql += "PRIMARY KEY (\"iCompletedSyncID\"));";

					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
					sReleaseNotes += "Version 1.41 - Author:  JR \r\n";
					sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					sReleaseNotes += "Creates table that captures completed syncs in Liquid Transfer.\r\n\r\n";
				}

				if (iCurrVersion < 42)
				{
					sql = "CREATE TABLE \"SOLSERR\"(";
					sql += "\"iFailedSyncID\" IDENTITY,";
					sql += "\"sSentGLCode\" VARCHAR(50) CASE ,";
					sql += "\"sReceiverIP\" VARCHAR(50) CASE ,";
					sql += "\"sReceiverDataPath\" CHAR(255) CASE ,";
					sql += "\"dtDateTimeFailed\" DATETIME,";
					sql += "\"sErrorInfo\" VARCHAR(255) CASE ,";
					sql += "\"sLiquidUserCode\" CHAR(50) CASE ,";
					sql += "\"sLiquidUserName\" CHAR(50) CASE ,";
					sql += "\"iHandled\" INTEGER DEFAULT '0',";
					sql += "PRIMARY KEY (\"iFailedSyncID\"));";

					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
					sReleaseNotes += "Version 1.42 - Author:  JR \r\n";
					sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					sReleaseNotes += "Creates table that captures sync errors in Liquid Transfer.\r\n\r\n";
				}

				if (iCurrVersion < 43)
				{
					sql = "CREATE TABLE \"SOLINVENTSS\"(";
					sql += "\"PKiSyncSetupID\" IDENTITY,";
					sql += "\"sReceiverRef\" VARCHAR(50) CASE ,";
					sql += "\"sReceiverAlias\" VARCHAR(50) CASE ,";
					sql += "\"sReceiverIP\" VARCHAR(50) CASE ,";
					sql += "\"sDataPath\" VARCHAR(100) CASE ,";
					sql += "\"sSourceRef\" VARCHAR(50) CASE ,";
					sql += "\"sLiquidConn\" VARCHAR(50) CASE ,";
					sql += "\"sPastelConn\" VARCHAR(50) CASE ,";
					sql += "PRIMARY KEY (\"PKiSyncSetupID\"));";

					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();

					sReleaseNotes += "Version 1.43 - Author:  JR \r\n";
					sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					sReleaseNotes += "Added SOLINVENTSS Table - Inventory Synching.\r\n\r\n";
				}

				if (iCurrVersion < 44)
				{
					sql = "ALTER TABLE \"SOLINVENTSS\"( MODIFY COLUMN \"sLiquidConn\" CHAR(100) CASE, MODIFY COLUMN \"sPastelConn\" CHAR(100) CASE);";
					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();

					sql = "ALTER TABLE \"SOLSS\"( MODIFY COLUMN \"sLiquidConn\" CHAR(100) CASE, MODIFY COLUMN \"sPastelConn\" CHAR(100) CASE);";
					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();

					sReleaseNotes += "Version 1.44 - Author:  JR \r\n";
					sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					sReleaseNotes += "Adjust Size of Columns Storing Connection Strings.\r\n\r\n";
				}

				if (iCurrVersion < 45)
				{
					sql = "CREATE TABLE \"SOLINVSCOMP\"(";
					sql += "\"iCompletedInvSyncID\" IDENTITY,";
					sql += "\"sSentInvCode\" VARCHAR(50) CASE ,";
					sql += "\"sReceiverIP\" VARCHAR(50) CASE ,";
					sql += "\"sReceiverDataPath\" CHAR(255) CASE ,";
					sql += "\"dtDateTimeCompleted\" DATETIME,";
					sql += "\"sLiquidUserCode\" CHAR(50) CASE ,";
					sql += "\"sLiquidUserName\" CHAR(50) CASE ,";
					sql += "PRIMARY KEY (\"iCompletedInvSyncID\"));";

					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
					sReleaseNotes += "Version 1.45 - Author:  JR \r\n";
					sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					sReleaseNotes += "Creates table that captures completed Inventory Syncs in Liquid Transfer.\r\n\r\n";
				}

				if (iCurrVersion < 46)
				{
					sql = "ALTER TABLE \"SOLINVENTSS\"( ADD COLUMN \"sSourceStore\" CHAR(10) CASE, ADD COLUMN \"sReceiverStore\" CHAR(10) CASE);";

					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
					sReleaseNotes += "Version 1.46 - Author:  JR \r\n";
					sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					sReleaseNotes += "Add Store Code Columns to Inventory Sync Setup.\r\n\r\n";

				}
				if (iCurrVersion < 47)
				{
					sql = "CREATE TABLE \"SOLINVSERR\"(";
					sql += "\"iFailedInvSyncID\" IDENTITY,";
					sql += "\"sSentInvCode\" VARCHAR(50) CASE ,";
					sql += "\"sReceiverIP\" VARCHAR(50) CASE ,";
					sql += "\"sReceiverDataPath\" CHAR(255) CASE ,";
					sql += "\"dtDateTimeFailed\" DATETIME,";
					sql += "\"sErrorInfo\" VARCHAR(255) CASE ,";
					sql += "\"sLiquidUserCode\" CHAR(50) CASE ,";
					sql += "\"sLiquidUserName\" CHAR(50) CASE ,";
					sql += "\"iHandled\" INTEGER DEFAULT '0',";
					sql += "PRIMARY KEY (\"iFailedInvSyncID\"));";

					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
					sReleaseNotes += "Version 1.47 - Author:  JR \r\n";
					sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					sReleaseNotes += "Creates table that captures Invoice Sync errors in Liquid Transfer.\r\n\r\n";
				}

				if (iCurrVersion < 48)
				{
					sql = "ALTER TABLE \"SOLMSM\"(ADD COLUMN \"POItemDescription\" VARCHAR(40) CASE,";
					sql += " RENAME COLUMN \"ItemDesription\" TO \"GenItemDescription\")";

					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
					sReleaseNotes += "Version 1.48 - Author:  DDK \r\n";
					sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					sReleaseNotes += "Alter SOLMSM.\r\n\r\n";
				}

				if (iCurrVersion < 49)
				{
					sql = "ALTER TABLE \"SOLMSM\"(ADD COLUMN \"Status\" INTEGER DEFAULT '0')";

					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
					sReleaseNotes += "Version 1.49 - Author:  DDK \r\n";
					sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					sReleaseNotes += "Alter SOLMSM.\r\n\r\n";
				}


				if (iCurrVersion < 50)
				{
					sql = "CREATE TABLE \"SOLMRBRI\"(\"FkRBRID\" INTEGER,\"RBRItemReference\" VARCHAR(35) CASE);";

					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
					sReleaseNotes += "Version 1.50 - Author:  DDK \r\n";
					sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					sReleaseNotes += "Create table for raw batch recieved inv\r\n\r\n";
				}

				if (iCurrVersion < 51)
				{
					sql = "ALTER TABLE \"SOLHL\"(ADD COLUMN \"OrigDeliveryDate\" CHAR(10) DEFAULT '00-00-0000' CASE);";

					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
					sReleaseNotes += "Version 1.51 - Author:  LL \r\n";
					sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					sReleaseNotes += "Add Origional Delivery date for assets on site report\r\n\r\n";
				}

				if (iCurrVersion < 52)
				{
					sql = "ALTER TABLE \"SOLUS\"(ADD COLUMN \"CloseOrder\" INTEGER DEFAULT '0');";

					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
					sReleaseNotes += "Version 1.52 - Author:  LL \r\n";
					sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					sReleaseNotes += "Security to allow/block users from closing orders\r\n\r\n";
				}

				if (iCurrVersion < 53)
				{
					sql = "ALTER TABLE \"SOLUS\"(ADD COLUMN \"ShortName\" CHAR(2) CASE );";

					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
					sReleaseNotes += "Version 1.53 - Author:  LL \r\n";
					sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					sReleaseNotes += "Add short name to user for reporting purpose \r\n\r\n";
				}

				if (iCurrVersion < 54)
				{
					sql = "CREATE TABLE \"SOLMW\"(\"WorksheetId\" IDENTITY DEFAULT '0',\"UserName\" VARCHAR(30) CASE ,\"DateTime\" VARCHAR(30) CASE );";

					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
					sReleaseNotes += "Version 1.54 - Author:  DDK \r\n";
					sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					sReleaseNotes += "Worksheet table inv\r\n\r\n";
				}

				if (iCurrVersion < 55)
				{
					sql = "CREATE TABLE \"SOLMWI\"(\"FkWorksheetId\" INTEGER NOT NULL ,\"BatchName\" VARCHAR(30) CASE ,\"BatchQuantity\" INTEGER NOT NULL ,\"BatchId\" VARCHAR(10) CASE );";

					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
					sReleaseNotes += "Version 1.55 - Author:  DDK \r\n";
					sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					sReleaseNotes += "Worksheet inventory table inv\r\n\r\n";
				}

				#endregion

				#region VER 56 - 70
				if (iCurrVersion < 56)
				{
					sql = "CREATE TABLE \"SOLMRBM\"(\"ProductionLineId\" IDENTITY DEFAULT '0',\"ProductionLineName\" VARCHAR(50) CASE );";

					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
					sReleaseNotes += "Version 1.56 - Author:  DDK \r\n";
					sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					sReleaseNotes += "mapping of raw batch with production lines inv\r\n\r\n";
				}

				if (iCurrVersion < 57)
				{
					sql = "ALTER TABLE \"SOLMRBS\"(ADD COLUMN \"FkProductionLineId\" INTEGER NOT NULL );";

					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
					sReleaseNotes += "Version 1.57 - Author:  DDK \r\n";
					sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					sReleaseNotes += "add productionlineid to rawbatchsetup \r\n\r\n";
				}

				if (iCurrVersion < 58)
				{
					sql = "CREATE TABLE \"SOLMWBM\"(\"BarcodeID\" IDENTITY DEFAULT '0',\"FkBatchId\" INTEGER,\"FkWorksheetId\" INTEGER);";

					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
					sReleaseNotes += "Version 1.58 - Author:  DDK \r\n";
					sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					sReleaseNotes += "Worksheet barcode mapping inv\r\n\r\n";
				}

				if (iCurrVersion < 59)
				{
					sql = "ALTER TABLE \"SOLMRBRI\"(ADD COLUMN \"FkBarcodeId\" VARCHAR(10) CASE);";

					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
					sReleaseNotes += "Version 1.58 - Author:  DDK \r\n";
					sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					sReleaseNotes += "add barcodeID for mapping to worksheetId \r\n\r\n";
				}

				if (iCurrVersion < 60)
				{
					sql = "ALTER TABLE \"SOLRM\"(ADD COLUMN \"sRuleUnit\" VARCHAR(4) CASE);";

					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
					sReleaseNotes += "Version 1.60 - Author:  LL \r\n";
					sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					sReleaseNotes += "Rule unit for Rule setup \r\n\r\n";
				}

				if (iCurrVersion < 61)
				{
					sql = "ALTER TABLE \"SOLRM\"(MODIFY COLUMN \"FKiSpecialRule\" VARCHAR(50) CASE);";

					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
					sReleaseNotes += "Version 1.61 - Author:  LL \r\n";
					sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					sReleaseNotes += "Special formula for Rule setup \r\n\r\n";
				}

				if (iCurrVersion < 62)
				{
					sql = "ALTER TABLE \"SOLCS\"(ADD COLUMN \"iDefaultRuleId\" INTEGER,";
					sql += "ADD COLUMN \"sDefaultRuleName\" VARCHAR(50) CASE);";

					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
					sReleaseNotes += "Version 1.62 - Author:  LL \r\n";
					sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					sReleaseNotes += "Default Rule in Company Setup \r\n\r\n";
				}

				if (iCurrVersion < 63)
				{
					sql = "ALTER TABLE \"SOLHL\"(ADD COLUMN \"sCalculationRule\" CHAR(4) CASE);";

					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
					sReleaseNotes += "Version 1.63 - Author:  LL \r\n";
					sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					sReleaseNotes += "Add Calculation Rule per line \r\n\r\n";
				}


				if (iCurrVersion < 64)
				{
					sql = "ALTER TABLE \"SOLUS\"(ADD COLUMN \"TelephoneNumber\" VARCHAR(15) CASE);";
					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
					sReleaseNotes += "Version 1.65 - Author:  LL \r\n";
					sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					sReleaseNotes += "add Telephone Number info to user \r\n\r\n";
				}

				if (iCurrVersion < 65)
				{
					sql = "CREATE TABLE \"SOLMROS\"(\"ItemCode\" VARCHAR(50) CASE ,\"ItemDescription\" VARCHAR(50) CASE ,\"Quantity\" INTEGER,\"UserName\" VARCHAR(30) CASE ,\"Date\" VARCHAR(30) CASE );";

					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
					sReleaseNotes += "Version 1.65 - Author:  DDK \r\n";
					sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					sReleaseNotes += "Create table to Revieve Old Stock \r\n\r\n";
				}

				if (iCurrVersion < 66)
				{
					sql = "ALTER TABLE \"SOLCS\"(ADD COLUMN \"DelNoteFirst\" INTEGER NOT NULL,ADD COLUMN \"DelNoteDuplicate\" INTEGER NOT NULL, ADD COLUMN \"InvoiceFirst\" INTEGER NOT NULL, ADD COLUMN \"InvoiceDuplicate\" INTEGER NOT NULL  );";

					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
					sReleaseNotes += "Version 1.66 - Author:  DDK \r\n";
					sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					sReleaseNotes += "add print quantity to setup \r\n\r\n";
				}

				if (iCurrVersion < 67)
				{
					sql = "CREATE TABLE \"SOLCN\"(\"IDNumber\" VARCHAR(30) CASE ,\"CustomerCode\" VARCHAR(30) CASE ,\"Note\" VARCHAR(50) CASE);";

					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
					sReleaseNotes += "Version 1.67 - Author:  DDK \r\n";
					sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					sReleaseNotes += "Create table to add customer notes \r\n\r\n";
				}

				if (iCurrVersion < 68)
				{
					sql = "ALTER TABLE \"SOLRM\"(ADD COLUMN \"bDayOrDate\" TINYINT DEFAULT '0');";

					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
					sReleaseNotes += "Version 1.68 - Author:  LL \r\n";
					sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					sReleaseNotes += "Add field to rule setup to establish if day or date should be used in the calculation \r\n\r\n";
				}

				if (iCurrVersion < 69)
				{
					sql = "ALTER TABLE \"SOLRP\"(ADD COLUMN \"dReturnCalcPercentag\" DECIMAL(8,2) NOT NULL);";

					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
					sReleaseNotes += "Version 1.69 - Author:  LL \r\n";
					sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					sReleaseNotes += "Add field to rule setup to accomodate different values for returned and normal lease items \r\n\r\n";
				}

				if (iCurrVersion < 70)
				{
					sql = "ALTER TABLE \"SOLCN\"(MODIFY COLUMN \"Note\" VARCHAR(1024) CASE );";

					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
					sReleaseNotes += "Version 1.70 - Author:  LL \r\n";
					sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					sReleaseNotes += "Increase field size for Customer Notes from 50 to 1024 \r\n\r\n";
				}

				#endregion

				if (iCurrVersion < 71)
				{
					sql = "ALTER TABLE \"SOLCS\"(ADD COLUMN \"GenerateZeroInv\" BIT DEFAULT '0' NOT NULL , ";
					sql += "ADD COLUMN \"AutoBlockCust\" BIT DEFAULT '0' NOT NULL);";

					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
					sReleaseNotes += "Version 1.71 - Author:  LL \r\n";
					sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					sReleaseNotes += "Add 2 checkboxes to Company Setup Generate zero inv and Auto Block Customer\r\n\r\n";
				}

				if (iCurrVersion < 72)
				{
					sql = "ALTER TABLE \"SOLCS\"(ADD COLUMN \"NotifyIfCustOverLimi\" BIT DEFAULT '0' NOT NULL) ";
					
					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
					sReleaseNotes += "Version 1.72 - Author:  LL \r\n";
					sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					sReleaseNotes += "add checkbox to notify user if customer over credit limit or not.\r\n\r\n";
				}

				if (iCurrVersion < 73)
				{
					sql = "ALTER TABLE \"SOLUS\"(ADD COLUMN \"LockOrder\" INTEGER)";
				   
					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
					sReleaseNotes += "Version 1.73 - Author:  ddK \r\n";
					sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					sReleaseNotes += "Lockorder capapbility vir User \r\n\r\n";
				}
				if (iCurrVersion < 74)
				{
					sql = "ALTER TABLE \"SOLHH\"(ADD COLUMN \"LockedStatus\" INTEGER)";

					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
					sReleaseNotes += "Version 1.74 - Author:  ddK \r\n";
					sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					sReleaseNotes += "add lockedstatus to invoice header  \r\n\r\n";
				}
				if (iCurrVersion < 75)
				{
					sql =    "CREATE TABLE \"SOLMS\"(";
					sql +=  "\"id\" IDENTITY,";
					sql +=  "\"fkInventoryCategory\" VARCHAR(50) CASE ,";
					sql += "\"sUnit\" CHAR(4) CASE ,";
					sql += "\"sUnitNotes\" VARCHAR(200) CASE,";
					sql +=  "\"dNetMass\" FLOAT);";

					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
					sReleaseNotes += "Version 1.75 - Author:  AJD \r\n";
					sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					sReleaseNotes += "add the measurement scale table\r\n\r\n";
				}

				if (iCurrVersion < 76)
				{
					sql = "CREATE TABLE \"SOLPH\"(";
					sql += "\"id\" IDENTITY,";
					sql += "\"PublicHolidayName\" VARCHAR(30) CASE ,";
					sql += "\"PublicHolidayDate\" VARCHAR(30) CASE);";

					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
					sReleaseNotes += "Version 1.76 - Author:  DDK \r\n";
					sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					sReleaseNotes += "add table for Public Holidays table\r\n\r\n";
				}

				if (iCurrVersion < 77)
				{
					sql = "CREATE TABLE \"SOLAUD\"(\"id\" IDENTITY DEFAULT '0',\"iTypeSend\" INTEGER,\"InvoiceNumber\" VARCHAR(15) CASE ,\"CustomerCode\" VARCHAR(10) CASE, \"DateSent\" DATE)";

					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
					sReleaseNotes += "Version 1.77 - Author:  DDK \r\n";
					sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					sReleaseNotes += "add table for auditing of emails/fax sent table\r\n\r\n";
				}

				if (iCurrVersion < 78)
				{
					sql = "ALTER TABLE \"SOLHL\"(ADD COLUMN \"Description\" VARCHAR(50) CASE)";
					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
					sReleaseNotes += "Version 1.78 - Author:  DDK \r\n";
					sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					sReleaseNotes += "Add column to keep records of comments and for synching table\r\n\r\n";
				}

				if (iCurrVersion < 79)
				{
					sql = "ALTER TABLE \"SOLIL\"(ADD COLUMN \"SiteName\" CHAR(15) CASE)";
					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
					sReleaseNotes += "Version 1.79 - Author:  DDK \r\n";
					sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					sReleaseNotes += "enable filter per site\r\n\r\n";
				}

				if (iCurrVersion < 80)
				{
					sql = "ALTER TABLE \"SOLHH\"(ADD COLUMN \"SiteName\" CHAR(20) CASE )";
					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
					sReleaseNotes += "Version 1.80 - Author:  DDK \r\n";
					sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					sReleaseNotes += "enable filter per site thru solHH\r\n\r\n";
				}

				if (iCurrVersion < 81)
				{
					sql = "ALTER TABLE \"SOLCS\"(ADD COLUMN \"PartialDays\" INTEGER,ADD COLUMN \"GraceTime\" INTEGER,ADD COLUMN \"HalfdayValue\" DECIMAL(8,2))";
					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
					sReleaseNotes += "Version 1.81 - Author:  DDK \r\n";
					sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					sReleaseNotes += "partial days handler vir period\r\n\r\n";
				}
				
				if (iCurrVersion < 82)
				{
					sql = "ALTER TABLE \"SOLHL\"(MODIFY COLUMN \"DeliveryDate\" CHAR(20) CASE ,MODIFY COLUMN \"ReturnDate\" CHAR(20) CASE)";
					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
					sReleaseNotes += "Version 1.82 - Author:  DDK \r\n";
					sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					sReleaseNotes += "change date sizes to handle time\r\n\r\n";
				}

				if (iCurrVersion < 83)
				{
					sql = " CREATE TABLE \"SOLWAM\"(\"ItemCode\" VARCHAR(15) CASE ,\"PurchaseDate\" CHAR(20) CASE ,\"PurchasePrice\" DECIMAL(8,2),\"Supplier\" VARCHAR(45) CASE ,\"LifeCycle\" VARCHAR(20) CASE ,\"ServiceCycle\" VARCHAR(20) CASE)";
					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
					sReleaseNotes += "Version 1.83 - Author:  DDK \r\n";
					sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					sReleaseNotes += "create table for workshop maintenance plan \r\n\r\n";
				}

				if (iCurrVersion < 84)
				{
					sql = "CREATE TABLE \"SOLWC\"(\"id\" IDENTITY,\"ChecklistName\" VARCHAR(35) CASE ,\"ChecklistDescription\" VARCHAR(45) CASE ,\"UserDefined01\" VARCHAR(50) CASE ,\"UserDefined02\" VARCHAR(50) CASE ,\"UserDefined03\" VARCHAR(50) CASE ,\"UserDefined04\" VARCHAR(50) CASE ,\"UserDefined05\" VARCHAR(50) CASE ,\"UserDefined06\" VARCHAR(50) CASE ,\"UserDefined07\" VARCHAR(50) CASE ,\"UserDefined08\" VARCHAR(50) CASE ,\"UserDefined09\" VARCHAR(50) CASE ,\"UserDefined10\" VARCHAR(50) CASE)";
					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
					sReleaseNotes += "Version 1.84 - Author:  DDK \r\n";
					sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					sReleaseNotes += "create table for Checklist info \r\n\r\n";
				}

				if (iCurrVersion < 85)
				{
					sql = "CREATE TABLE \"SOLQHH\"(\"DocNumber\" VARCHAR(8) CASE , \"CustCode\" CHAR(6) CASE , \"DocDate\" DATE, ";
					sql += "\"CustRef\" VARCHAR(15) CASE , \"SalesCode\" CHAR(6) CASE , \"Notes\" LONGVARCHAR CASE , \"DelAddress01\" CHAR(30) CASE , ";
					sql += "\"DelAddress02\" CHAR(30) CASE ,\"DelAddress03\" CHAR(30) CASE ,\"DelAddress04\" CHAR(30) CASE ,\"DelAddress05\" CHAR(30) CASE , ";
					sql += "\"ExpDate\" DATE,\"Tel\" CHAR(16) CASE ,\"Fax\" CHAR(16) CASE ,\"Contact\" CHAR(16) CASE ,\"DiscPerc\" DECIMAL(8,2), ";
					sql += "\"Total\" DECIMAL(8,2),\"TotalTax\" DECIMAL(8,2),\"TotalDiscount\" DECIMAL(8,2),\"TotalExcl\" DECIMAL(8,2),\"Status\" INTEGER,\"Project\" VARCHAR(10) CASE)";
					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
					sReleaseNotes += "Version 1.85 - Author:  DDK** \r\n";
					sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					sReleaseNotes += "create table for Qoute Historyheader \r\n\r\n";
				}

				if (iCurrVersion < 86)
				{
					sql = "CREATE TABLE \"SOLQHL\"(\"DocNumber\" CHAR(8) CASE ,";
					sql += "\"ItemCode\" CHAR(15) CASE , \"CustCode\" CHAR(6) CASE ,";   
					sql += "\"Multiplier\" DECIMAL(8,2) DEFAULT '1', \"Qty\" DECIMAL(8,2) DEFAULT '1',\"UnitPrice\" DECIMAL(8,2), \"InclPrice\" DECIMAL(8,2), ";
					sql +=  "\"TaxAmt\" DECIMAL(8,2),\"DiscountPercentage\" DECIMAL(8,2), \"LinkNum\" INTEGER, \"Description\" VARCHAR(50) CASE, \"LineTotalExcl\" DECIMAL(8,2),\"Unit\" VARCHAR(10) CASE)";                
					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
					sReleaseNotes += "Version 1.86 - Author:  DDK** \r\n";
					sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					sReleaseNotes += "create table for Qoute HistoryLines \r\n\r\n";
				}
			 
				 if (iCurrVersion < 87)
				{
					sql = "ALTER TABLE \"SOLCS\"(ADD COLUMN \"QoutePrefix\" CHAR(5) CASE)";                  
					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
					sReleaseNotes += "Version 1.87 - Author:  DDK** \r\n";
					sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					sReleaseNotes += "add col 4 qoute prefix in solcs \r\n\r\n";
				}

				 if (iCurrVersion < 88)
				 {
					 sql = "CREATE TABLE \"SOLQN\"(\"FkDocNumber\" VARCHAR(10) CASE ,\"Note\" LONGVARCHAR CASE ,\"LinkNum\" INTEGER)";                  
					 iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
					 sReleaseNotes += "Version 1.88 - Author:  DDK** \r\n";
					 sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					 sReleaseNotes += "Table for notes attached to qoutes \r\n\r\n";
				 }

				 if (iCurrVersion < 89)
				 {
					 sql = "CREATE TABLE \"SOLQA\"(\"FkDocNumber\" VARCHAR(10) CASE ,\"Path\" VARCHAR(300) CASE)";
					 iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
					 sReleaseNotes += "Version 1.89 - Author:  DDK** \r\n";
					 sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					 sReleaseNotes += "Table for pic attachments to qoute \r\n\r\n";
				 }

				if (iCurrVersion < 90)
				 {
					 sql = " ALTER TABLE \"SOLCS\"(ADD COLUMN \"ProjectPrefix\" CHAR(3) CASE)";
					 iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
					 sReleaseNotes += "Version 1.90 - Author:  DDK** \r\n";
					 sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					 sReleaseNotes += "add column for prerfix of project management number \r\n\r\n";
				 }


				if (iCurrVersion < 91)
				{
					sql = " ALTER TABLE \"SOLHH\"(ADD COLUMN \"Contract\" VARCHAR(20) CASE)";
					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
					sReleaseNotes += "Version 1.91 - Author:  DDK** \r\n";
					sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					sReleaseNotes += "add contract date  \r\n\r\n";
				}

				 if (iCurrVersion < 92)
				{
					sql = "  ALTER TABLE \"SOLIL\"(ADD COLUMN \"DateStamp\" DATETIME)";
					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
					sReleaseNotes += "Version 1.92 - Author:  DDK** \r\n";
					sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					sReleaseNotes += "add datestamp to track invoices  \r\n\r\n";
				}

				 if (iCurrVersion < 93)
				 {
					 sql = @"CREATE TABLE SOLPDH(
								 DocNumber VARCHAR(8) CASE ,
								 CustCode CHAR(6) CASE ,
								 DocDate DATE,
								 CustRef VARCHAR(15) CASE ,
								 SalesCode CHAR(6) CASE ,
								 Notes LONGVARCHAR CASE ,
								 DelAddress01 VARCHAR(50) CASE ,
								 DelAddress02 CHAR(30) CASE ,
								 DelAddress03 CHAR(30) CASE ,
								 DelAddress04 CHAR(30) CASE ,
								 Tel CHAR(16) CASE ,
								 Fax CHAR(16) CASE ,
								 Contact CHAR(16) CASE ,
								 Project VARCHAR(10) CASE, 
								 Jcr VARCHAR(10) CASE
								);";
					 iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
					 sql = @"CREATE TABLE SOLPDL(
								 DocNumber CHAR(8) CASE ,
								 ItemCode CHAR(15) CASE ,
								 Qty DECIMAL(8,2) DEFAULT '1',                                 
								 LinkNum INTEGER,
								 Description VARCHAR(50) CASE ,                                 
								 Unit VARCHAR(10) CASE 
								);";

					 iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
					 sReleaseNotes += "Version 1.93 - Author:  ADK** \r\n";
					 sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					 sReleaseNotes += "Delivery note tables added  \r\n\r\n";
				 }
				if (iCurrVersion < 94)
				{
					sql = "ALTER TABLE \"SOLCS\"(ADD COLUMN \"QuoteTemplate\" CHAR(100) CASE)";
					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
					sReleaseNotes += "Version 1.94 - Author:  DDK** \r\n";
					sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					sReleaseNotes += "select template for quotes  \r\n\r\n";
				}

				if (iCurrVersion < 95)
				{
					sql = "ALTER TABLE \"SOLCS\"( ADD COLUMN \"DeliveryNotePrefix\" CHAR(3))";
					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
					sReleaseNotes += "Version 1.95 - Author:  DDK** \r\n";
					sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					sReleaseNotes += "del note prefix added  \r\n\r\n";
				}

				if (iCurrVersion < 96)
				{
					sql = "ALTER TABLE \"SOLCS\"(ADD COLUMN \"ReturnNotePrefix\" CHAR(50) CASE)";
					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
					sReleaseNotes += "Version 1.96 - Author:  DDK** \r\n";
					sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					sReleaseNotes += "return note prefix added  \r\n\r\n";
				}

				if (iCurrVersion < 97)
				{
					sql = @"CREATE TABLE SOLPRH(
								 DocNumber VARCHAR(8) CASE ,
								 CustCode CHAR(6) CASE ,
								 DocDate DATE,
								 CustRef VARCHAR(15) CASE ,
								 SalesCode CHAR(6) CASE ,
								 Notes LONGVARCHAR CASE ,
								 DelAddress01 VARCHAR(50) CASE ,
								 DelAddress02 CHAR(30) CASE ,
								 DelAddress03 CHAR(30) CASE ,
								 DelAddress04 CHAR(30) CASE ,
								 Tel CHAR(16) CASE ,
								 Fax CHAR(16) CASE ,
								 Contact CHAR(16) CASE ,
								 Project VARCHAR(10) CASE, 
								 Jcr VARCHAR(10) CASE,
								 LinkedDeliveryNote VARCHAR(8) CASE 
								);";
					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
					sql = @"CREATE TABLE SOLPRL(
								 DocNumber CHAR(8) CASE ,
								 ItemCode CHAR(15) CASE ,
								 Qty DECIMAL(8,2) DEFAULT '1',                                 
								 LinkNum INTEGER,
								 Description VARCHAR(50) CASE ,                                 
								 Unit VARCHAR(10) CASE 
								);";
					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
					sReleaseNotes += "Version 1.97 - Author:  DDK++ \r\n";
					sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					sReleaseNotes += "Return note tables added  \r\n\r\n";
				}

				
				if (iCurrVersion < 98)
				{
					sql = " CREATE TABLE \"SOLPROJ\"(\"ProjectNumber\" CHAR(10) CASE , \"ProjectDescription\" VARCHAR(30) CASE)";
					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
					sReleaseNotes += "Version 1.98 - Author:  DDK** \r\n";
					sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					sReleaseNotes += "table for projects \r\n\r\n";
				}
				
				if (iCurrVersion < 99)
				{
					sql = " CREATE TABLE \"SOLPJCR\"(\"DocNumber\" CHAR(10) CASE ,\"JCR\" CHAR(20) CASE )";
					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
					sReleaseNotes += "Version 1.99 - Author:  DDK** \r\n";
					sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					sReleaseNotes += "table for jcr picking slip link \r\n\r\n";
				}
			   
				if (iCurrVersion < 100)
				{
					sql = "CREATE TABLE \"SOLMOSAUD\"(\"CustomerCode\" CHAR(8) CASE ,\"DateSent\" DATE);";
					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
					sReleaseNotes += "Version 1.100 - Author:  DDK** \r\n";
					sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					sReleaseNotes += "table for tracking MOS emails + sms sent \r\n\r\n";
				}

				if (iCurrVersion < 101)
				{
					sql = " CREATE TABLE \"SOLMOSSMS\"(\"Message\" LONGVARCHAR CASE);";
					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
					sReleaseNotes += "Version 1.101 - Author:  DDK** \r\n";
					sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					sReleaseNotes += "table for text of sms message \r\n\r\n";
				}

				if (iCurrVersion < 102)
				{
					sql = " CREATE TABLE \"SOLKIT\"(\"KitName\" VARCHAR(30) CASE, \"MainItemCode\" VARCHAR(30) CASE ); ";
					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
					sReleaseNotes += "Version 1.102 - Author:  DDK** \r\n";
					sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					sReleaseNotes += "kit items table\r\n\r\n";
				}

				if (iCurrVersion < 103)
				{
					sql = " CREATE TABLE \"SOLKITDET\"(\"FkMainItemCode\" VARCHAR(30) CASE ,\"ItemCode\" VARCHAR(30) CASE ,\"Qty\" DECIMAL(8,2),  \"Description\" VARCHAR(30) CASE, \"LinkNum\" INTEGER ); ";
					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
					sReleaseNotes += "Version 1.103 - Author:  DDK** \r\n";
					sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					sReleaseNotes += "kit items table details\r\n\r\n";
				}

				if (iCurrVersion < 104)
				{
					sql = "ALTER TABLE \"SOLCS\"(ADD COLUMN \"QuotePath\" VARCHAR(50) CASE)";
					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
					sReleaseNotes += "Version 1.104 - Author:  DDK** \r\n";
					sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					sReleaseNotes += "add col for saving quote path \r\n\r\n";
				}

		  if (iCurrVersion < 105)
				{
					sql = @"CREATE TABLE SOLINVT(
								 ItemCode CHAR(20) CASE ,
								 BatchNumber CHAR(15) CASE ,								 
								 QtyOnHand DECIMAL(8,2)
								);";
					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();

					sql = @"CREATE TABLE SOLINVTTRANS(
							 DocNumber CHAR(20) CASE ,
							 ItemCode CHAR(20) CASE ,
							 BatchNumber CHAR(15) CASE ,
							 Qty DECIMAL(8,2),
							 Type TINYINT
							);";
					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();

					sql = @"ALTER TABLE SOLCS(
							ADD COLUMN LiquidHandlesInvt BIT
							);";
					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();

					sql = @"ALTER TABLE SOLINVTTRANS(
							ADD COLUMN DateTimeStamp DATETIME,
							ADD COLUMN AdjustReason CHAR(100) CASE 
							);";
					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
					
					sReleaseNotes += "Version 2.05 - Author:  JR13** \r\n";
					sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					sReleaseNotes += "new inventory and inventory transaction tables  \r\n\r\n";
				}

				if (iCurrVersion < 106)
				{
					sql = @"CREATE TABLE SOLSIH(
							 DocNumber CHAR(20) CASE ,
							 DocDate DATE,
							 RespPersonRef CHAR(20) CASE ,
							 SalesCode CHAR(6) CASE ,
							 Notes LONGVARCHAR CASE 
						);";

					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();

					sql = @"CREATE TABLE SOLSIL(
							 DocNumber CHAR(20) CASE ,
							 ItemCode CHAR(15) CASE ,
							 BatchNumber CHAR(15) CASE ,
							 Description VARCHAR(50) CASE ,
							 Qty DECIMAL(8,2),
							 Unit VARCHAR(10) CASE 
							);";

					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery(); 

					sReleaseNotes += "Version2.06 - Author:  JR13** \r\n";
					sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					sReleaseNotes += "Stock Issue Document - Header and Details  \r\n\r\n";
				}

				if (iCurrVersion < 107)
				{
					sql = @"CREATE TABLE SOLPRODH(
							 DocNumber CHAR(20) CASE ,
							 DocDate DATE,
							 RespPersonRef CHAR(20) CASE ,
							 SalesCode CHAR(6) CASE ,
							 Notes LONGVARCHAR CASE 
						);";                                    

					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();

					sql = @"CREATE TABLE SOLPRODL(
							 DocNumber CHAR(20) CASE ,
							 StockIssueNum CHAR(15) CASE ,
							 RawBatchNumber CHAR(15) CASE ,                             
							 RawItemCode CHAR(15) CASE ,
							 PBatchNumber CHAR(15) CASE ,
							 PItemCode CHAR(15) CASE ,
							 PDescription VARCHAR(50) CASE ,
							 PQty DECIMAL(8,2),
							 PUnit VARCHAR(10) CASE 
							);";

					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();

					sql = @"CREATE TABLE SOLFPINVT(
							BatchNumber CHAR(15) CASE ,								 								 
							ItemCode CHAR(20) CASE ,								 
							QtyOnHand DECIMAL(8,2)
							);";
					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();

					sql = @"CREATE TABLE SOLFPINVTTRANS(
							 DocNumber CHAR(20) CASE ,							 
							 BatchNumber CHAR(15) CASE ,
							 ItemCode CHAR(20) CASE ,
							 Qty DECIMAL(8,2),
							 Type TINYINT,
							 DateTimeStamp DATETIME,
							 AdjustReason CHAR(100) CASE
							);";
					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();

					sReleaseNotes += "Version 2.07 - Author:  JR13 12/07/2011 ** \r\n";
					sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					sReleaseNotes += "Production Document - Header and Details  \r\n\r\n";
				}

				if (iCurrVersion < 108)
				{
					sql = @"ALTER TABLE SOLINVTTRANS(
							 ADD COLUMN DocDate DATE							 							 
							);";

					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();

					sql = @"ALTER TABLE SOLFPINVTTRANS(
							 ADD COLUMN DocDate DATE							 							 
							);";

					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
					sReleaseNotes += "Version 2.08 - Author:  JR13 29/07/2011 ** \r\n";
					sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					sReleaseNotes += "Adding Document Dates to Manufacturing History \r\n\r\n";
					
				}

				if (iCurrVersion < 109)
				{
					sql = @"ALTER TABLE SOLQHH(
							 MODIFY COLUMN DiscPerc DECIMAL(12,2),
							 MODIFY COLUMN Total DECIMAL(12,2),
								MODIFY COLUMN TotalTax DECIMAL(12,2),
								MODIFY COLUMN TotalDiscount DECIMAL(12,2),
								MODIFY COLUMN TotalExcl DECIMAL(12,2)
							);";

					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
					
					sReleaseNotes += "Version 2.09 - Author:  ddk 29/07/2011 ** \r\n";
					sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					sReleaseNotes += "change decimal sizes to handle bigger amounts \r\n\r\n";

				}

				if (iCurrVersion < 110)
				{
					sql = @"ALTER TABLE SOLQHL(
							 MODIFY COLUMN UnitPrice DECIMAL(12,2),
							 MODIFY COLUMN InclPrice DECIMAL(12,2),
							 MODIFY COLUMN TaxAmt DECIMAL(12,2),
							 MODIFY COLUMN LineTotalExcl DECIMAL(12,2)
							);";

					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
					
					sReleaseNotes += "Version 2.10 - Author:  ddk 29/07/2011 ** \r\n";
					sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					sReleaseNotes += "change decimal sizes to handle bigger amounts \r\n\r\n";
				}

				if (iCurrVersion < 111)
				{
					sql = @"CREATE TABLE SOLMARKDET(
							MarketerCode VARCHAR(50) CASE ,
							Description VARCHAR(50) CASE ,
							Telephone VARCHAR(15) CASE ,
							Fax VARCHAR(15) CASE ,
							Mobile VARCHAR(15) CASE ,
							Email VARCHAR(30) CASE ,
							ID VARCHAR(20) CASE ,
							Address1 VARCHAR(50) CASE ,
							Address2 VARCHAR(50) CASE ,
							Address3 VARCHAR(50) CASE ,
							Address4 VARCHAR(50) CASE 
							);";
					
					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
					sReleaseNotes += "Version 2.11 - Author:  ddk 19/08/2011 ** \r\n";
					sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					sReleaseNotes += "add table 4 marketer detail setup \r\n\r\n";
				}

			   if (iCurrVersion < 112)
				{
					sql = @"CREATE TABLE SOLMARKCAT(
							CategoryName VARCHAR(50) CASE ,
							CategoryPercentage DECIMAL(8,2)
							);";
					
					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
					sReleaseNotes += "Version 2.12 - Author:  ddk 19/08/2011 ** \r\n";
					sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					sReleaseNotes += "marketing category table \r\n\r\n";
				}

				 if (iCurrVersion < 113)
				{
					sql = @"CREATE TABLE SOLMARKCUSTDET(
							CustomerCode CHAR(10) CASE ,
							MarketingCategory VARCHAR(50) CASE ,
							CommissionFloor DECIMAL(8,2),
							Marketer VARCHAR(20) CASE ,
							SiteName VARCHAR(15) CASE 
							);";
					
					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
					sReleaseNotes += "Version 2.13 - Author:  ddk 19/08/2011 ** \r\n";
					sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					sReleaseNotes += "customer marketing detail \r\n\r\n";
				}

				
				if (iCurrVersion < 114)
				{
					sql = @" CREATE TABLE SOLMARKCOMTIPE(
							CommissionTipe VARCHAR(30) CASE ,
							CommissionPercentage DECIMAL(8,2)
							);";
					
					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
					sReleaseNotes += "Version 2.14 - Author:  ddk 23/08/2011 ** \r\n";
					sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					sReleaseNotes += "CommissionPercentage tipe table \r\n\r\n";
				}

				if (iCurrVersion < 115)
				{
					sql = @"CREATE TABLE SOLMARKTRANS(
							 MarketerCode VARCHAR(10) CASE ,
							 Category VARCHAR(30) CASE ,
							 CommissionType VARCHAR(30) CASE ,
							 InvoiceValue DECIMAL(12,2) ,
							 CustomerCode VARCHAR(10) CASE ,
							 DocumentNumber VARCHAR(10) CASE 
							 );";
					
					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
					sReleaseNotes += "Version 2.15 - Author:  ddk 23/08/2011 ** \r\n";
					sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					sReleaseNotes += " marketer transactions details \r\n\r\n";
				}
				
			   if (iCurrVersion < 116)
				{
					sql = @"ALTER TABLE SOLHH(
							 ADD COLUMN Marketer VARCHAR(10) CASE ,
							 ADD COLUMN MarketingCategory VARCHAR(30) CASE ,
							 ADD COLUMN CommissionType VARCHAR(30) CASE                             
							 );";
					
					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
					sReleaseNotes += "Version 2.16 - Author:  ddk 23/08/2011 ** \r\n";
					sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					sReleaseNotes += " add columns for marketing details on Sales order \r\n\r\n";
				}
				

			   

				if (iCurrVersion < 117)
				{
					sql = @" ALTER TABLE SOLMARKCUSTDET(
							  ADD COLUMN UseSite INTEGER
								);";
					
					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
					sReleaseNotes += "Version 2.17 - Author:  ddk 23/08/2011 ** \r\n";
					sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					sReleaseNotes += " add columns for marketing details on Sales order \r\n\r\n";
				}

				if (iCurrVersion < 118)
				{
					sql = @" ALTER TABLE SOLCS(
							 ADD COLUMN DeliveryNoteTerms LONGVARCHAR CASE 
							 );";
					
					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
					sReleaseNotes += "Version 2.18 - Author:  ddk 23/08/2011 ** \r\n";
					sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					sReleaseNotes += " column for terms and conditions edit on company setup \r\n\r\n";
				}

				if (iCurrVersion < 119)
				{
					sql = @"ALTER TABLE SOLUS(ADD COLUMN ReturnItem INTEGER DEFAULT '0')";					
					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
					sReleaseNotes += "Version 2.19 - Author:  ddk 21/12/2011 ** \r\n";
					sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					sReleaseNotes += " give users rights to return items on Delivery note \r\n\r\n";
				}

				if (iCurrVersion < 120)
				{
					sql = @"CREATE TABLE SOLIM(ItemCode VARCHAR(20) CASE, Description VARCHAR(50) CASE);";					
					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
					sReleaseNotes += "Version 2.20 - Author:  ddk 21/12/2011 ** \r\n";
					sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					sReleaseNotes += " create table itemcode manager \r\n\r\n";
				}

				if (iCurrVersion < 121)
				{
					sql = @"ALTER TABLE SOLCS(ADD COLUMN SalesOrderType VARCHAR(30) CASE );";					
					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
					sReleaseNotes += "Version 2.21 - Author:  ddk 12/03/2012 ** \r\n";
					sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					sReleaseNotes += " create column for salesorder type / thubatse toilet programme \r\n\r\n";
				}
				
				 if (iCurrVersion < 122)
				{
					sql = @"ALTER TABLE SOLHH(ADD COLUMN SalesOrderType INTEGER DEFAULT '0');";					
					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
					sReleaseNotes += "Version 2.23 - Author:  ddk 12/03/2012 ** \r\n";
					sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					sReleaseNotes += " create column for salesorder type in solhh / thubatse toilet programme \r\n\r\n";
				}

				 if (iCurrVersion < 123)
				 {
					 try
					 {
						 sql = @"Drop Table SOLRM;";
						 iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
						 sql = @"CREATE TABLE SOLRM(PKiRuleID IDENTITY,sRuleName VARCHAR(50) NOT NULL ,sRuleDescription VARCHAR(250) CASE ,FKiSpecialRule VARCHAR(50) CASE ,sRuleUnit VARCHAR(50) CASE ,bDayOrDate TINYINT);";
						 iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
						 sReleaseNotes += "Version 2.23 - Author:  ddk 12/03/2012 ** \r\n";
						 sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
						 sReleaseNotes += " drop original table solrm and recreate to work correctly / thubatse toilet programme \r\n\r\n";
					 }
					 catch
					 {

					 }
				 }		

				if (iCurrVersion < 124)
				 {
					 
						 sql = @" CREATE TABLE SOLSPSA(FkSalesOrder VARCHAR(15) CASE );";
						 iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();												
						 sReleaseNotes += "Version 2.24 - Author:  ddk 12/03/2012 ** \r\n";
						 sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
						 sReleaseNotes += " add table om special sales orders te merk vir kingshire \r\n\r\n";									
				 }

				if (iCurrVersion < 125)
				{
					sql = @"CREATE TABLE SOLDSO(SalesOrderNumber CHAR(50) CASE , InvoiceNumber CHAR(50) CASE , SalesOrderDate DATETIME);";
					iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
					sReleaseNotes += "Version 2.25 - Author:  pk 10/08/2012 ** \r\n";
					sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
					sReleaseNotes += " add table om deleted SalesOrders se linked invoices te wys";

				}

                if (iCurrVersion < 127)
                {
                    sql = @"CREATE TABLE CustomerDetail(CustomerCode VARCHAR(12) CASE ,ConsolidatedCustomer INTEGER);";
                    iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
                    sReleaseNotes += "Version 2.26 - Author:  ddk 20/02/2013 ** \r\n";
                    sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
                    sReleaseNotes += " create table to keep liquid detail of customers like is consolidatecustomer";
                } 
                
                if (iCurrVersion < 128)
                {
                    sql = @" ALTER TABLE SOLHH(ADD COLUMN ConsolidateNumber VARCHAR(15) CASE );";
                    iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
                    sReleaseNotes += "Version 2.27 - Author:  ddk 20/02/2013 ** \r\n";
                    sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
                    sReleaseNotes += " alter table to add field to store consolidate number linked to S/O";
                }

                if (iCurrVersion < 129)
                {

                    sql = @"SELECT COUNT(*)
                            FROM X$File WHERE Xf$Name = 'ConsolidatedInvoices';";

                    var count = int.Parse(Connect.getDataCommand(sql, liquidConnection).ExecuteScalar().ToString());

                    if (count == 0)
                    {
                        sql =
                            @"CREATE TABLE ConsolidatedInvoices(InvoiceNumber VARCHAR(12) CASE ,SalesOrderNumber VARCHAR(12) CASE ,DocumentDate DATETIME );";

                        iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
                    }
                    sReleaseNotes += "Version 2.28 - Author:  ddk 20/02/2013 ** \r\n";
                    sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
                    sReleaseNotes += " create table to store info on consolidated invoice";
                }

                /*
                seems to be done manualy
                if (iCurrVersion < 130)
                {
                    sql = @" ALTER TABLE SOLHH(ADD COLUMN Excludeholiday SMALLINT  );";
                    iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
                    sReleaseNotes += "Version 2.29 - Author: DJS 14/06/2016 ** \r\n";
                    sReleaseNotes += "~~~~~~~~~~~~~~~~~~~~\r\n";
                    sReleaseNotes += "Exclude Saturdays now saved from sales order";
                }*/

                if (iCurrVersion < 130)
                {
                    sql = @"ALTER TABLE SOLCS
                                ADD COLUMN DefaultInvoiceUser int;";

                    iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
                }

                if (iCurrVersion < 131)
                {
                    sql = @"UPDATE SOLCS 
                                SET DefaultInvoiceUser = 0;";

                    iReturn = Connect.getDataCommand(sql, liquidConnection).ExecuteNonQuery();
                }

                //NEW UPDATES ABOVE THIS LINE 
                UpdateCurrentVersion(liquidConnection);				
				liquidConnection.Dispose();
			}            
		}

		private static void UpdateCurrentVersion(PsqlConnection oConn)
		{
			string sSql = "UPDATE SOLUPD SET ";
			sSql += "CurrentVersion = '" + iLatestVersion + "',";
			sSql += "LastUpdate = '" + DateTime.Now.ToString("yyyy-MM-dd") + "'";
			sSql += "WHERE id = 1";
		   
			int iReturn = Connect.getDataCommand(sSql, oConn).ExecuteNonQuery();

			if (iReturn == 1)
			{
				MessageBox.Show("DB Updated to Latest Version: " + iLatestVersion);
			}
		}
	}

	
}
