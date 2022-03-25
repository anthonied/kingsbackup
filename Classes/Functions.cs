using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Reflection;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using log4net;
using Liquid.Controls;
using Liquid.Datasets;
using Liquid.Documents;
using Liquid.Documents.Templates.Invoice;
using Liquid.Domain;
using Liquid.Domain.Services;
using Liquid.Repository;
using Pervasive.Data.SqlClient;

namespace Liquid.Classes
{
    public class Functions
    {
        public static DeletedSalesOrders deletedSalesOrders = new DeletedSalesOrders();
        private static readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public struct strDownTimeReturn
        {
            public string sItemcode;
            public string sQty;
            public DateTime dtStartDate;
            public DateTime dtEndDate;
            public string sLinkNum;
        }

        public struct strUserProfile
        {
            public bool bCreditInvoice;
            public bool bCancelReturnItem;
            public bool bCloseOrder;
            public string sUserType;
        }

        public static string sDepotFilename = "";

        public static bool isNumeric(string val, NumberStyles NumberStyle)
        {
            Double result;
            return Double.TryParse(val, NumberStyle,
                CultureInfo.CurrentCulture, out result);
        }

        /// <summary>
        /// Method for resizing a multi dimensional array
        /// </summary>
        /// <param name="original">Original array you want to resize</param>
        /// <param name="cols"># of columns in the new array</param>
        /// <param name="rows"># of rows in the new array</param>
        public static void ResizeArray(ref object[,] original, int cols, int rows)
        {
            //create a new 2 dimensional array with
            //the size we want
            object[,] newArray = new object[rows, cols];
            //copy the contents of the old array to the new one
            Array.Copy(original, newArray, original.Length);
            //set the original to the new array
            original = newArray;
        }

        public static Decimal CalculateCommission(string sCommissionType, string sCommissionCategory, Decimal dInvoiceValue)
        {
            decimal dTotalCommission = 0;
            decimal dCategory = 0;
            decimal dCommissionType = 0;
            //get category percentage
            using (PsqlConnection oConn = new PsqlConnection(Connect.LiquidConnectionString))
            {
                oConn.Open();
                String sSql = "Select CategoryPercentage from SOLMARKCAT where CategoryName = '" + sCommissionCategory + "'";
                string sPercentage = "0";
                var percentage = Connect.getDataCommand(sSql, oConn).ExecuteScalar();
                if (percentage != null)
                    sPercentage = percentage.ToString();
                dCategory = Convert.ToDecimal(sPercentage)/100;

                try
                {
                    sSql = "Select CommissionPercentage From SOLMARKCOMTIPE where CommissionTipe = '" + sCommissionType + "'";
                    string sComPercentage = Connect.getDataCommand(sSql, oConn).ExecuteScalar().ToString();
                    dCommissionType = Convert.ToDecimal(sComPercentage)/100;
                }
                catch
                {
                    dCommissionType = 1;
                }

                oConn.Dispose();
            }
            dTotalCommission = dInvoiceValue*dCategory*dCommissionType;

            return dTotalCommission;
        }

        

        public static strDownTimeReturn getDownTime(string sDownTimeLine)
        {
            strDownTimeReturn oDownTime = new strDownTimeReturn();
            oDownTime.sItemcode = sDownTimeLine.Substring(3, 15).Trim();
            oDownTime.sQty = Convert.ToDecimal(sDownTimeLine.Substring(18, 6).Trim()).ToString();
            oDownTime.dtStartDate = new DateTime(2000 + Convert.ToInt32(sDownTimeLine.Substring(28, 2)), Convert.ToInt32(sDownTimeLine.Substring(26, 2)), Convert.ToInt32(sDownTimeLine.Substring(24, 2)));
            oDownTime.dtEndDate = new DateTime(2000 + Convert.ToInt32(sDownTimeLine.Substring(34, 2)), Convert.ToInt32(sDownTimeLine.Substring(32, 2)), Convert.ToInt32(sDownTimeLine.Substring(30, 2)));
            oDownTime.sLinkNum = Convert.ToInt32(sDownTimeLine.Substring(36, 3)).ToString();
            return (oDownTime);
        }

        public static void setDownTimeLinkNum(string sOldLinkNum, string sNewLinkNum, string sDocumentNumber)
        {
            using (PsqlConnection oPastelConn = new PsqlConnection(Connect.PastelConnectionString))
            {
                using (PsqlConnection oPastelConn2 = new PsqlConnection(Connect.PastelConnectionString))
                {
                    oPastelConn.Open();
                    string sSql = "Select Description, Linknum from HistoryLines where DocumentNumber = '" + sDocumentNumber + "' and left(Description,2) = '*D' and DocumentType in (2,102)";
                        //Get all the remaining downtime rows for this document
                    using (PsqlDataReader rdReader = Connect.getDataCommand(sSql, oPastelConn).ExecuteReader())
                    {
                        while (rdReader.Read())
                        {
                            string sDownTimeLine = rdReader["Description"].ToString().Trim();
                            strDownTimeReturn strDownTimeLine = getDownTime(sDownTimeLine);
                            if (strDownTimeLine.sLinkNum.PadLeft(3, "0".ToCharArray()[0]) == sOldLinkNum.PadLeft(3, "0".ToCharArray()[0]))
                            {
                                sDownTimeLine = sDownTimeLine.Remove(sDownTimeLine.Length - 3, 3) + sNewLinkNum.PadLeft(3, "0".ToCharArray()[0]);
                                sSql = "Update HistoryLines ";
                                sSql += " SET Description  = '" + sDownTimeLine + "' ";
                                sSql += " WHERE DocumentNumber = '" + sDocumentNumber + "' and LinkNum = " + rdReader["LinkNum"] + " and DocumentType in (2,102)";
                                int iRet = Connect.getDataCommand(sSql, oPastelConn2).ExecuteNonQuery();
                            }
                        }
                        rdReader.Close();
                    }
                    oPastelConn2.Dispose();
                }
                oPastelConn.Dispose();
            }
        }

        public static void DecrementDownTimeLinkNum(string sDowntimeLinkNum, string sDocumentNumber)
        {
            using (PsqlConnection oPastelConn = new PsqlConnection(Connect.PastelConnectionString))
            {
                oPastelConn.Open();
                string sSql = "Select Description from HistoryLines where DocumentNumber = '" + sDocumentNumber + "' and LinkNum = " + sDowntimeLinkNum + " and DocumentType in (2,102)";
                    //Get all the remaining downtime rows for this document
                string sDownTimeLine = Connect.getDataCommand(sSql, oPastelConn).ExecuteScalar().ToString();
                strDownTimeReturn strDownTimeLine = getDownTime(sDownTimeLine);
                string sNewLinkNum = (Convert.ToInt32(strDownTimeLine.sLinkNum) - 1).ToString();
                sDownTimeLine = sDownTimeLine.Remove(sDownTimeLine.Length - 3, 3) + sNewLinkNum.PadLeft(3, "0".ToCharArray()[0]);
                sSql = "Update HistoryLines ";
                sSql += " SET Description  = '" + sDownTimeLine + "' ";
                sSql += " WHERE DocumentNumber = '" + sDocumentNumber + "' and LinkNum = " + sDowntimeLinkNum + " and DocumentType in (2,102)";
                int iRet = Connect.getDataCommand(sSql, oPastelConn).ExecuteNonQuery();
                oPastelConn.Dispose();
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sDocNumber"></param>
        /// <returns>The number of rows still in the Order</returns>
        public static int reOrderLiquidSalesLines(string sDocNumber)
        {
            int iRowCounter = 0;
            using (PsqlConnection oLiquidConn = new PsqlConnection(Connect.LiquidConnectionString))
            {
                using (PsqlConnection oLiquidConn2 = new PsqlConnection(Connect.LiquidConnectionString))
                {
                    oLiquidConn.Open();
                    oLiquidConn2.Open();

                    string sSql = "Select * from SOLHL where Header = '" + sDocNumber + "' order by LinkNum";
                    using (PsqlDataReader rdReader = Connect.getDataCommand(sSql, oLiquidConn).ExecuteReader())
                    {
                        while (rdReader.Read())
                        {
                            iRowCounter++;
                            sSql = "Update SOLHL set LinkNum = " + iRowCounter + " where LinkNum = " + rdReader["LinkNum"] + " and Header = '" + sDocNumber + "'";
                            int iRet = Connect.getDataCommand(sSql, oLiquidConn2).ExecuteNonQuery();

                            //Reset Downtime LinkNum For This Item
                            setDownTimeLinkNum(rdReader["LinkNum"].ToString().PadLeft(3, "0".ToCharArray()[0]), iRowCounter.ToString(), sDocNumber);
                        }
                    }

                    oLiquidConn.Dispose();
                    oLiquidConn2.Dispose();
                }
            }
            return (iRowCounter);
        }

        public static int reOrderPastelLinkNums(string sDocNumber)
        {
            int iRowCounter = 0;
            int iHLRowCounter = 0;
            using (PsqlConnection oPastelConn = new PsqlConnection(Connect.PastelConnectionString))
            {
                using (PsqlConnection oPastelConn2 = new PsqlConnection(Connect.PastelConnectionString))
                {
                    using (PsqlConnection oLiquidConn = new PsqlConnection(Connect.LiquidConnectionString))
                    {
                        oPastelConn.Open();
                        oPastelConn2.Open();
                        oLiquidConn.Open();

                        string sSql = "Select * from HistoryLines where DocumentNumber = '" + sDocNumber + "' and DocumentType in (2,102) order by LinkNum";
                        using (PsqlDataReader rdReader = Connect.getDataCommand(sSql, oPastelConn).ExecuteReader())
                        {
                            while (rdReader.Read())
                            {
                                iRowCounter++;
                                if (rdReader["SearchType"].ToString() != "7")
                                {
                                    sSql = "Update SOLHL set LinkNum = " + iRowCounter + " where LinkNum = " + rdReader["LinkNum"] + " and ItemCode = '" + rdReader["ItemCode"] + "' and Header = '" + sDocNumber + "'";
                                    int iRetLiquid = Connect.getDataCommand(sSql, oLiquidConn).ExecuteNonQuery();
                                    iHLRowCounter++;
                                }

                                sSql = "Update HistoryLines set LinkNum = " + iRowCounter + " where LinkNum = " + rdReader["LinkNum"] + " and DocumentNumber = '" + sDocNumber + "' and DocumentType in (2,102)";
                                int iRet = Connect.getDataCommand(sSql, oPastelConn2).ExecuteNonQuery();
                            }
                        }

                        oPastelConn.Dispose();
                        oPastelConn2.Dispose();
                        oLiquidConn.Dispose();
                    }
                }
            }
            return (iHLRowCounter);
        }

        public static int GetLiquidSalesLinesCountExcludingComments(string sDocNumber)
        {
            int iRowCounter = 0;
            using (PsqlConnection oLiquidConn = new PsqlConnection(Connect.LiquidConnectionString))
            {
                oLiquidConn.Open();

                string sSql = "Select * from SOLHL where ItemCode <> 'C' AND Header = '" + sDocNumber + "' order by LinkNum";
                using (PsqlDataReader rdReader = Connect.getDataCommand(sSql, oLiquidConn).ExecuteReader())
                {
                    while (rdReader.Read())
                    {
                        iRowCounter++;
                    }
                }
                oLiquidConn.Dispose();
            }
            return (iRowCounter);
        }

        //AJD Phalaborwa
        public static strUserProfile getUserProfile(string sSalesCode)
        {
            strUserProfile strUserProfileReturn = new strUserProfile();
            using (PsqlConnection oLiquidConn = new PsqlConnection(Connect.LiquidConnectionString))
            {
                oLiquidConn.Open();

                string sSql = "Select UserType, CreditInvoice,  CancelReturnItem, CloseOrder from SOLUS where Code = '" + sSalesCode + "'";
                using (PsqlDataReader rdReader = Connect.getDataCommand(sSql, oLiquidConn).ExecuteReader())
                {
                    while (rdReader.Read())
                    {
                        strUserProfileReturn.sUserType = rdReader["UserType"].ToString();
                        strUserProfileReturn.bCreditInvoice = false;
                        if (rdReader["CreditInvoice"].ToString() == "1")
                        {
                            strUserProfileReturn.bCreditInvoice = true;
                        }

                        strUserProfileReturn.bCancelReturnItem = false;
                        if (rdReader["CancelReturnItem"].ToString() == "1")
                        {
                            strUserProfileReturn.bCancelReturnItem = true;
                        }

                        strUserProfileReturn.bCloseOrder = false;
                        if (rdReader["CloseOrder"].ToString() == "1")
                        {
                            strUserProfileReturn.bCloseOrder = true;
                        }
                    }
                    rdReader.Close();
                }
                oLiquidConn.Dispose();
            }
            return (strUserProfileReturn);
        }

        public static void BackupDeletedSalesOrders(string DocumentNumber)
        {
            GetDeletedSalesOrderAndInvoices(DocumentNumber);
            SaveDeletedSalesOrder();
        }

        private static void SaveDeletedSalesOrder()
        {
            using (PsqlConnection oLiquidConn = new PsqlConnection(Connect.LiquidConnectionString))
            {
                oLiquidConn.Open();
                foreach (string s in deletedSalesOrders.InvoiceNumbers)
                {
                    string sSql = "INSERT into SOLDSO(SalesOrderNumber,InvoiceNumber,SalesOrderDate)";
                    sSql += " VALUES ";
                    sSql += String.Format("('{0}','{1}','{2}')", deletedSalesOrders.SalesOrderDocumentNumber, s, deletedSalesOrders.SalesOrderDate.ToString("yyyy-MM-dd"));
                    int Ret = Connect.getDataCommand(sSql, oLiquidConn).ExecuteNonQuery();
                }
                oLiquidConn.Close();
                oLiquidConn.Dispose();
            }
        }

        private static void GetDeletedSalesOrderAndInvoices(string documentNumber)
        {
            deletedSalesOrders = new DeletedSalesOrders();
            var LinkedInvoices = new List<string>();

            using (PsqlConnection oPasConn = new PsqlConnection(Connect.PastelConnectionString))
            {
                oPasConn.Open();
                string sSql = "select DocumentNumber, DocumentDate from HistoryHeader ";
                sSql += " where Freight01 = '" + documentNumber + "' order by DocumentDate";
                using (PsqlDataReader rdReader = Connect.getDataCommand(sSql, oPasConn).ExecuteReader())
                {
                    while (rdReader.Read())
                    {
                        var y = rdReader["DocumentNumber"].ToString();
                        //var y = x.Replace(" ","0");
                        deletedSalesOrders.SalesOrderDate = Convert.ToDateTime(rdReader["DocumentDate"].ToString());
                        LinkedInvoices.Add(y);
                    }
                    rdReader.Close();
                }

                oPasConn.Close();
                oPasConn.Dispose();
            }
            deletedSalesOrders.SalesOrderDocumentNumber = documentNumber;
            deletedSalesOrders.InvoiceNumbers = LinkedInvoices;
        }

        public List<DeletedSalesOrderData> GetAllDeletedSalesOrders(string salesOrderNumber)
        {
            var LastSalesOrderNumber = "";

            var AllDeletedData = new List<DeletedSalesOrderData>();

            using (PsqlConnection oLiquidConn = new PsqlConnection(Connect.LiquidConnectionString))
            {
                oLiquidConn.Open();
                string sSql = "SELECT SalesOrderNumber, InvoiceNumber, SalesOrderDate from SOLDSO";
                sSql += " WHERE SalesOrderNumber LIKE '%" + salesOrderNumber + "%'";
                using (PsqlDataReader rdReader = Connect.getDataCommand(sSql, oLiquidConn).ExecuteReader())
                {
                    while (rdReader.Read())
                    {
                        var DeletedData = new DeletedSalesOrderData();
                        DeletedData.SalesOrderNumber = rdReader["SalesOrderNumber"].ToString().TrimEnd();
                        DeletedData.Date = rdReader["SalesOrderDate"].ToString();
                        if (LastSalesOrderNumber == DeletedData.SalesOrderNumber)
                        {
                            DeletedData.SalesOrderNumber = "";
                            DeletedData.Date = "";
                        }
                        else
                        {
                            LastSalesOrderNumber = DeletedData.SalesOrderNumber;
                        }
                        DeletedData.InvoiceNumber = rdReader["InvoiceNumber"].ToString();

                        AllDeletedData.Add(DeletedData);
                    }
                }
                oLiquidConn.Close();
                oLiquidConn.Dispose();
            }
            return AllDeletedData;
        }

        public List<DeletedSalesOrderData> GetAllDeletedSalesOrders()
        {
            var LastSalesOrderNumber = "";

            var AllDeletedData = new List<DeletedSalesOrderData>();
            var count = 0;
            PsqlConnection oLiquidConn = new PsqlConnection(Connect.LiquidConnectionString);

            oLiquidConn.Open();
            string sSql = "SELECT SalesOrderNumber, InvoiceNumber, SalesOrderDate from SOLDSO ";
            using (PsqlDataReader rdReader = Connect.getDataCommand(sSql, oLiquidConn).ExecuteReader())
            {
                while (rdReader.Read())
                {
                    var DeletedData = new DeletedSalesOrderData();
                    DeletedData.SalesOrderNumber = rdReader["SalesOrderNumber"].ToString().TrimEnd();
                    DeletedData.Date = rdReader["SalesOrderDate"].ToString();
                    if (LastSalesOrderNumber == DeletedData.SalesOrderNumber)
                    {
                        DeletedData.SalesOrderNumber = "";
                        DeletedData.Date = "";
                    }
                    else
                    {
                        LastSalesOrderNumber = DeletedData.SalesOrderNumber;
                    }
                    DeletedData.InvoiceNumber = rdReader["InvoiceNumber"].ToString();

                    AllDeletedData.Add(DeletedData);
                }
            }
            oLiquidConn.Close();
            oLiquidConn.Dispose();

            return AllDeletedData;
        }

        public static void CloseOrder(string sDocumentNumber)
        {
            using (PsqlConnection oPastelConn = new PsqlConnection(Connect.PastelConnectionString))
            {
                using (PsqlConnection oLiquidConn = new PsqlConnection(Connect.LiquidConnectionString))
                {
                    string sSql = "";
                    int iRet = 0;
                    oLiquidConn.Open();

                    sSql = "UPDATE SOLHH ";
                    sSql += " SET Status = 3 ";
                    sSql += " WHERE DocNumber = '" + sDocumentNumber + "' ";
                    iRet = Connect.getDataCommand(sSql, oLiquidConn).ExecuteNonQuery();

                    sSql = "DELETE FROM SOLHL ";
                    sSql += " WHERE Header = '" + sDocumentNumber + "' ";
                    iRet = Connect.getDataCommand(sSql, oLiquidConn).ExecuteNonQuery();

                    sSql = "UPDATE Inventory SET "; //book this item back for rental
                    sSql += " UserDefText01 = '' ";
                    sSql += ", UserDefText02 = '' ";
                    sSql += ", UserDefText03 = '' ";
                    sSql += " WHERE ItemCode in (SELECT Itemcode from HistoryLines where DocumentNumber = '" + sDocumentNumber + "')";
                    iRet = Connect.getDataCommand(sSql, oPastelConn).ExecuteNonQuery();

                    sSql = "DELETE FROM HistoryLines ";
                    sSql += " WHERE DocumentNumber = '" + sDocumentNumber + "' and documentType in (2,102) ";
                    iRet = Connect.getDataCommand(sSql, oPastelConn).ExecuteNonQuery();

                    sSql = "DELETE FROM HistoryHeader ";
                    sSql += " WHERE DocumentNumber = '" + sDocumentNumber + "' and documentType in (2,102) ";
                    iRet = Connect.getDataCommand(sSql, oPastelConn).ExecuteNonQuery();

                    oLiquidConn.Dispose();
                    oPastelConn.Dispose();
                }
            }
        }

        public static string getLineInventoryType(string sItemCode)
        {
            string sReturn = "";
            if (sItemCode.Trim() == "'")
            {
                return "Comment";
            }
            else if (sItemCode.Trim() == "")
            {
                return "Empty";
            }
            using (PsqlConnection oPastelConn = new PsqlConnection(Connect.PastelConnectionString))
            {
                oPastelConn.Open();
                string sSql = "Select UserDefNum01 from Inventory where ItemCode = '" + sItemCode + "'";
                sReturn = Connect.getDataCommand(sSql, oPastelConn).ExecuteScalar().ToString();
                oPastelConn.Dispose();
            }
            return sReturn;
        }

        public static int getSalesLineIndex(string sCode, string sLinkNum, Control[] aSaleslines)
        {
            for (int iLines = 0; iLines < aSaleslines.Length; iLines++)
            {
                SalesLineForm slActive = (SalesLineForm) aSaleslines[iLines];
                if (slActive.sPastelLineLink == sLinkNum && slActive.txtCode.Text == sCode)
                {
                    return slActive.iLineIndex;
                }
            }
            return -1;
        }

        public static decimal getSalesLinePrice(string sCode, string sLinkNum, Control[] aSaleslines)
        {
            //Line Net Price / Line Quantity

            for (int iLines = 0; iLines < aSaleslines.Length; iLines++)
            {
                SalesLineForm slActive = (SalesLineForm) aSaleslines[iLines];
                if (slActive.sPastelLineLink == sLinkNum && slActive.txtCode.Text == sCode)
                {
                    decimal dQuantity = Convert.ToDecimal((string) slActive.txtQuantity.Text);
                    if (dQuantity == 0)
                        dQuantity = 1;
                    return Convert.ToDecimal((string) slActive.txtNet.Text)/dQuantity;
                }
            }
            return -1;
        }       

        public static void printInvoice(string sDocumentNumber, bool bFirstPrint, string sCurrentSalesman, PrintDialog pdPrintDetails)
        {
            var reportDelivery = getInvoiceReport(sDocumentNumber, "", "", "", "", "", "NormalPrint", sCurrentSalesman);
            if (reportDelivery == null) return;
            try
            {
                    reportDelivery.PrintOptions.PrinterName = pdPrintDetails.PrinterSettings.PrinterName;
                    reportDelivery.PrintToPrinter(Convert.ToInt16(pdPrintDetails.PrinterSettings.Copies), false, 0, 0);
            }
            catch
            {
                using (PrintInvoice frmPrint = new PrintInvoice())
                {
                    frmPrint.crystalReportViewer1.ReportSource = reportDelivery;
                    frmPrint.printThisDocument();
                }
            }
        }

        public static string CalculateQty_UnitRule(int numberOfDays, string ruleName, bool isReturned, DateTime startDate, DateTime endDate)
        {
            var rulesDomainService = new RulesDomainService(new RuleRepository(Connect.LiquidConnectionString));
            var period = rulesDomainService.CalcPeriod(ruleName, startDate, endDate, isReturned);
            return period == -1 ? numberOfDays.ToString("N2") : period.ToString("N2");
        }

        public static ReportClass getInvoiceReport(string sDocumentNumberFrom, string sDocumentNumberTo,
            string sDateFrom, string sDateTo, string customerFrom, string customerTo, string sTypePrint,
            string sCurrentSalesman)
        {
            var bLiquidDetail = false;
            ReportClass reportDelivery = null;
            using (var oPastelConn = new PsqlConnection(Connect.PastelConnectionString))
            {
                using (var oLiquidConn = new PsqlConnection(Connect.LiquidConnectionString))
                {

                    reportDelivery = new Inv_Kings();
                    var sql = "Select HistoryHeader.DocumentNumber, HistoryHeader.CustomerCode, HistoryHeader.DocumentDate, HistoryHeader.SalesmanCode, DelAddress01, DelAddress02, DelAddress03, DelAddress04, DelAddress05, HistoryLines.ItemCode, UnitUsed, HistoryLines.Description, Qty, UnitPrice, HistoryHeader.Freight01 ";
                    sql +=
                        ",LinkNum, CustomerDesc, PostAddress01,PostAddress02,PostAddress03,PostAddress04,PostAddress05, OrderNumber,UserDefNum01, UserDefNum02, HistoryLines.DiscountPercentage LineDiscount, HistoryLines.TaxAmt LineTax, HistoryLines.CostCode LineProjectCode, Total, TotalTax, ExemptRef, HistoryHeader.Telephone, (qty * UnitPrice) * ((1 - DiscountPercentage/10000)) LineTotal, HistoryHeader.DiscountPercent InvoiceDiscount ";
                    sql +=
                        " From HistoryHeader Left Join HistoryLines on HistoryHeader.DocumentNumber = HistoryLines.DocumentNumber ";
                    sql += " Left Join CustomerMaster on HistoryHeader.CustomerCode = CustomerMaster.CustomerCode";
                    sql += " Left Join Inventory on HistoryLines.ItemCode = Inventory.ItemCode";
                    switch (sTypePrint)
                    {
                        case "NormalPrint":
                            sql += " Where HistoryHeader.DocumentNumber = '" + sDocumentNumberFrom.Trim() +
                                   "' and HistoryLines.DocumentType in (103,3) and Historyheader.DocumentType in (103,3) order by HistoryLines.LinkNum";
                            break;
                        case "BulkPrint":
                            //Document Number Filters
                            if (sDocumentNumberFrom != "" && sDocumentNumberTo != "")
                            {
                                sql += " Where HistoryHeader.DocumentNumber >= '" + sDocumentNumberFrom.Trim() + "'";
                                sql += " and HistoryHeader.DocumentNumber <= '" + sDocumentNumberTo.Trim() + "'";
                            }
                            else if (sDocumentNumberFrom != "" && sDocumentNumberTo == "")
                            {
                                if (sDocumentNumberFrom.Length < 13)
                                {
                                    sql += " Where HistoryHeader.DocumentNumber >= '" + sDocumentNumberFrom.Trim() + "'";
                                }
                                else
                                {
                                    sql += sDocumentNumberFrom + ")";
                                }
                            }
                            else if (sDocumentNumberFrom == "" && sDocumentNumberTo != "")
                            {
                                sql += " Where HistoryHeader.DocumentNumber <= '" + sDocumentNumberTo.Trim() + "'";
                            }
                            else
                            {
                                sql += " Where '' = '" + sDocumentNumberFrom + "'";
                            }

                            //Customer Filters
                            if (customerFrom != "" && customerTo != "")
                            {
                                sql += " and HistoryHeader.CustomerCode >= '" + customerFrom + "'";
                                sql += " and HistoryHeader.CustomerCode <= '" + customerTo + "'";
                            }
                            else if (customerFrom != "" && customerTo == "")
                            {
                                sql += " and HistoryHeader.CustomerCode >= '" + customerFrom + "'";
                            }
                            else if (customerFrom == "" && customerTo != "")
                            {
                                sql += " and HistoryHeader.CustomerCode <= '" + customerTo + "'";
                            }

                            //Date Filters
                            if (sDateFrom != "" && sDateTo != "")
                            {
                                sql += " and HistoryHeader.DocumentDate >= '" + sDateFrom + "'";
                                sql += " and HistoryHeader.DocumentDate <= '" + sDateTo + "'";
                            }
                            else if (sDateFrom != "" && sDateTo == "")
                            {
                                sql += " and HistoryHeader.DocumentDate >= '" + sDateFrom + "'";
                            }
                            else if (sDateFrom == "" && sDateTo != "")
                            {
                                sql += " and HistoryHeader.DocumentDate <= '" + sDateTo + "'";
                            }

                            sql += " and HistoryLines.DocumentType in (103,3) and Historyheader.DocumentType in (103,3)";
                            break;
                    }


                    var dtInvoice = new dsInvoice.invoice_01DataTable();
                    using (var rdReader = Connect.getDataCommand(sql, oPastelConn).ExecuteReader())
                    {
                        while (rdReader.Read())
                        {
                            var drRow = dtInvoice.NewRow();
                            drRow["DocumentNumber"] = rdReader["DocumentNumber"];
                            drRow["CustomerCode"] = rdReader["CustomerCode"];
                            drRow["DocumentDate"] = rdReader["DocumentDate"];
                            drRow["DelAddress01"] = rdReader["DelAddress01"].ToString(); //.ToLower();
                            drRow["DelAddress02"] = rdReader["DelAddress02"].ToString(); //.ToLower();
                            drRow["DelAddress03"] = rdReader["DelAddress03"].ToString(); //.ToLower();
                            drRow["DelAddress04"] = rdReader["DelAddress04"].ToString(); //.ToLower();
                            drRow["DelAddress05"] = rdReader["DelAddress05"].ToString(); //.ToLower();
                            drRow["ItemCode"] = rdReader["ItemCode"].ToString(); //.ToLower();
                            drRow["UnitUsed"] = rdReader["UnitUsed"];
                            int iCount = rdReader["Description"].ToString().IndexOf('~');
                            if (iCount > 0)
                                drRow["Description"] = rdReader["Description"].ToString().Remove(iCount); //.ToLower();
                            else
                                drRow["Description"] = rdReader["Description"].ToString();
                            drRow["UnitPrice"] = rdReader["UnitPrice"];
                            drRow["LinkNum"] = rdReader["LinkNum"];
                            drRow["CustomerDesc"] = rdReader["CustomerDesc"].ToString(); //.ToLower();
                            drRow["PostAddress01"] = rdReader["PostAddress01"].ToString(); //.ToLower();
                            drRow["PostAddress02"] = rdReader["PostAddress02"].ToString(); //.ToLower();
                            drRow["PostAddress03"] = rdReader["PostAddress03"].ToString(); //.ToLower();
                            drRow["PostAddress04"] = rdReader["PostAddress04"].ToString(); //.ToLower();
                            drRow["PostAddress05"] = rdReader["PostAddress05"].ToString(); //.ToLower();
                            drRow["OrderNumber"] = rdReader["OrderNumber"];
                            var discount = int.Parse(rdReader["LineDiscount"].ToString());

                            drRow["LineDiscount"] = discount/100;
                            drRow["LineProjectCode"] = rdReader["LineProjectCode"]?.ToString().Trim();
                            drRow["LineTax"] = rdReader["LineTax"];
                            drRow["TaxTotal"] = rdReader["TotalTax"];
                            drRow["InvoiceTotal"] = rdReader["Total"];
                            drRow["Vat"] = rdReader["ExemptRef"];
                            drRow["Telephone"] = rdReader["Telephone"];
                            drRow["LineTotal"] = rdReader["LineTotal"];
                            drRow["InvoiceDiscount"] = rdReader["InvoiceDiscount"];
                            drRow["DeliveryNote"] = rdReader["Freight01"];
                            
                          
                                var sSqlUs = "Select UserName from SOLUS where Code = '" + sCurrentSalesman + "'";
                                var sUserName =
                                    Connect.getDataCommand(sSqlUs, oLiquidConn).ExecuteScalar().ToString();
                                drRow["SalesmanCode"] = sUserName;
                         

                            sql = "select Multiplier,Qty, FromDate, ToDate  from SOLIL where DocumentNumber = '" +
                                   rdReader["DocumentNumber"].ToString().Trim() + "' and LinkNum =" +
                                   rdReader["LinkNum"];
                            using (
                                var rdLiquidReader = Connect.getDataCommand(sql, oLiquidConn).ExecuteReader())
                            {
                                while (rdLiquidReader.Read())
                                {
                                    bLiquidDetail = true;
                                    //Combine qty and period to fit to new invoice template
                                    var qty = Convert.ToDecimal(rdLiquidReader["Multiplier"].ToString());
                                    var period = Convert.ToDecimal(rdLiquidReader["Qty"].ToString());



                                    drRow["Qty"] = period > 0 ? qty * period : qty;
                                            drRow["Period"] =   rdLiquidReader["Qty"];
                                    drRow["DeliveryDate"] = rdLiquidReader["FromDate"].ToString() == "1970-01-01" ? ""  : rdLiquidReader["FromDate"];
                                    drRow["ReturnDate"] = rdLiquidReader["ToDate"].ToString() == "1970-01-01" ? "" : rdLiquidReader["ToDate"]; ;
                                }
                                rdLiquidReader.Close();
                            }
                            if (!bLiquidDetail) //If invoice detail is not captured in Liquid show total qty from Pastel
                            {
                                drRow["Qty"] = rdReader["Qty"];
                                drRow["DeliveryDate"] = "-";
                                drRow["ReturnDate"] = "-";
                                drRow["Period"] = 1;
                            }
                            dtInvoice.Rows.Add(drRow);
                        }
                        rdReader.Close();
                    }
                    reportDelivery.SetDataSource((DataTable) dtInvoice);
                    foreach (FormulaFieldDefinition forReport in reportDelivery.DataDefinition.FormulaFields)
                    {
                        switch (forReport.FormulaName)
                        {
                            case "{@sGlobCompanyName}":
                                forReport.Text = "'" + Global.sCompanyName.Trim() + "'";
                                break;

                            case "{@sGlobCompanyRegName}":
                                forReport.Text = "'" + Global.sRegName.Trim() + "'";
                                break;

                            case "{@sGlobVat}":
                                forReport.Text = "'" + Global.sVAT.Trim() + "'";
                                break;

                            case "{@sGlobReg}":
                                forReport.Text = "'" + Global.sReg.Trim() + "'";
                                break;

                            case "{@sGlobTel}":
                                forReport.Text = "'" + Global.sCompanyTel.Trim() + "'";
                                break;

                            case "{@sGlobFax}":
                                forReport.Text = "'" + Global.sCompanyFax.Trim() + "'";
                                break;

                            case "{@sGlobPost1}":
                                forReport.Text = "'" + Global.sCompanyPostAd1.Trim() + "'";
                                break;

                            case "{@sGlobPost2}":
                                forReport.Text = "'" + Global.sCompanyPostAd2.Trim() + "'";
                                break;

                            case "{@sGlobPost3}":
                                forReport.Text = "'" + Global.sCompanyPostAd3.Trim() + "'";
                                break;

                            case "{@sGlobAdd1}":
                                forReport.Text = "'" + Global.sCompanyAd1.Trim() + "'";
                                break;

                            case "{@sGlobAdd2}":
                                forReport.Text = "'" + Global.sCompanyAd2.Trim() + "'";
                                break;

                            case "{@sGlobAdd3}":
                                forReport.Text = "'" + Global.sCompanyAd3.Trim() + "'";
                                break;

                            case "{@CompanyCell}":
                                forReport.Text = "'" + Global.sInvoiceContactNumber + "'";
                                break;
                        }
                    }

                }               

                oPastelConn.Dispose();
            }
            return reportDelivery;
        }

        public static string SyncPastelOrder(string sDocNumber, string sCustomerCode, string sDocDate, string sDeliveryDate, string sReturnDate)
        {
            string sSql = "";
            int iRet = 0;
            using (PsqlConnection liqConn = new PsqlConnection(Connect.LiquidConnectionString))
            {
                //Add Header Record

                sSql = "INSERT into SOLHH (DocType, DocNumber, Type, DepositType, DepositAmount, CustomerCode, DocDate, Status, Saturdays, Sundays, Coordinates,AdvPaymentAmount,Collected) ";
                sSql += " VALUES ";
                sSql += " (2, '" + sDocNumber + "',1,'',0,'" + sCustomerCode + "','" + sDocDate + "',1,1,0,'',0,0" + ")";
                iRet = Connect.getDataCommand(sSql, liqConn).ExecuteNonQuery();
                if (iRet < 1)
                {
                    return ("Error: Header Record not inserted into liquid database");
                }
                //Add Detail Record
                using (PsqlConnection pasConn = new PsqlConnection(Connect.PastelConnectionString))
                {
                    pasConn.Open();
                    sSql = "select ItemCode, LinkNum, Qty, UnitUsed from HistoryLines ";
                    sSql += " where DocumentNumber = '" + sDocNumber + "'";

                    using (PsqlDataReader pasReader = Connect.getDataCommand(sSql, pasConn).ExecuteReader())
                    {
                        while (pasReader.Read())
                        {
                            sSql = "INSERT into SOLHL";
                            sSql += " (Header, ItemCode, DeliveryDate, ReturnDate, Status,LinkNum, Multiplier, Qty, OrigDeliveryDate,sCalculationRule) ";
                            sSql += " VALUES ";
                            sSql += "(";
                            sSql += "'" + sDocNumber + "'";
                            sSql += ",'" + pasReader["ItemCode"].ToString().Trim() + "'";
                            sSql += ",'" + sDeliveryDate + "'";
                            sSql += ",'" + sReturnDate + "'";
                            sSql += ",0";
                            sSql += ", " + pasReader["LinkNum"].ToString().Trim();
                            sSql += ",1";
                            sSql += "," + pasReader["Qty"].ToString().Trim();
                            sSql += ", '" + sDeliveryDate + "'";
                            sSql += ",'" + pasReader["UnitUsed"].ToString().Trim() + "'";
                            sSql += ")";
                            iRet = Connect.getDataCommand(sSql, liqConn).ExecuteNonQuery();
                            if (iRet < 1)
                            {
                                return ("Error: Detail Record not inserted into liquid database");
                            }
                        }
                    }
                    pasConn.Close();
                }
                liqConn.Close();
            }
            return sDocNumber;
        }
    }
}
