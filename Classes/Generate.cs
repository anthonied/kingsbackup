using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using Pervasive.Data.SqlClient;
using Liquid.Datasets;
using Liquid.Documents;
using Liquid.Documents.Templates.Delivery;
using Liquid.Documents.Templates.Qoute;
using Liquid.Domain.DefinitionObjects.HistoryHeaders;
using Liquid.Domain.Interfaces;
using Liquid.Domain.DefinitionObjects.OffHireOrders;
using Liquid.Documents.Templates.OffHiredOrders;

namespace Liquid.Classes
{
    public class Generate : IGenerate
    {
        private bool _isSaturday = false;
        private bool _isSunday = false;

        private DateTime _sCheckIfInvoicedBefore;
        private double _dDocumentTotal;

        public string buildSalesLine(List<string> aSalesLineUpdate, decimal dDTQty, int iInstruction)
        {
            decimal dUpdatedQty = 0;

            if (iInstruction == 0) //Normal Invoice Line
                dUpdatedQty = dDTQty;
            else if (iInstruction == 1) //Downtime to Process
                dUpdatedQty = Convert.ToDecimal(aSalesLineUpdate[1]) - dDTQty;

            var sLine = aSalesLineUpdate[0] + "|"; //Cost Price
            //LL Kings Hire
            if (dUpdatedQty != 0 || dUpdatedQty != 0.0m)
            {
                sLine += dUpdatedQty + "|"; //Line Quantity
                sLine += aSalesLineUpdate[2] + "|"; //Exclusive Price Per Unit
                sLine += aSalesLineUpdate[3] + "|"; //Inclusive Price Per Unit
                _dDocumentTotal += Convert.ToDouble(aSalesLineUpdate[3]);
            }
            else
            {
                sLine += "1|"; //Line Quantity
                sLine += "0|"; //Exclusive Price Per Unit
                sLine += "0|"; //Inclusive Price Per Unit
            }
            sLine += aSalesLineUpdate[4] + "|"; //Unit
            sLine += Convert.ToInt32(aSalesLineUpdate[5]).ToString("00").Trim() + "|"; //Tax Type
            sLine += aSalesLineUpdate[6] + "|"; //Discount Type
            sLine += aSalesLineUpdate[7] + "|"; //Discount %
            sLine += aSalesLineUpdate[8] + "|"; //Code
            //LL 24/03/2010
            var sDescriptionForLine = aSalesLineUpdate[9];
            if (aSalesLineUpdate[9].Length > 40)
            {
                var iDescripLength = sDescriptionForLine.Length - 40;
                sDescriptionForLine = sDescriptionForLine.Substring(0, sDescriptionForLine.IndexOf("~") - iDescripLength) + sDescriptionForLine.Substring(sDescriptionForLine.IndexOf("~"), sDescriptionForLine.Length - sDescriptionForLine.IndexOf("~"));
            }

            sLine += sDescriptionForLine + "|"; //Description
            sLine += aSalesLineUpdate[10] + "|"; //Line Type
            sLine += aSalesLineUpdate[11] + "|"; //Store
            sLine += aSalesLineUpdate[12] + "|"; //CostCode

            return sLine;
        }


        public static int CountDays(DayOfWeek day, DateTime start, DateTime end)
        {
            var ts = end - start; // Total duration
            var count = (int)Math.Floor(ts.TotalDays / 7);   // Number of whole weeks
            var remainder = (int)(ts.TotalDays % 7);         // Number of remaining days
            var sinceLastDay = (int)(end.DayOfWeek - day);   // Number of days since last [day]
            if (sinceLastDay < 0)
                sinceLastDay += 7;                           // Adjust for negative days since last [day]
            // If the days in excess of an even week are greater than or equal to the number days since the last [day], then count this one, too.
            if (remainder >= sinceLastDay)
                count++;
            return count;
        }

        public static void PrintCreditNote(Main frmMain, string sDocumentNumber, string sMessage01, string sMessage02)
        {
            using (var reportCredit = new CreditNote())
            {
                using (var frmPrint = new PrintInvoice())
                {
                    frmPrint.crystalReportViewer1.SelectionFormula = "{HistoryHeader.DocumentNumber} = \"" + sDocumentNumber + "\"";
                    foreach (FormulaFieldDefinition forReport in reportCredit.DataDefinition.FormulaFields)
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

                            case "{@sInvoiceMessage01}":
                                forReport.Text = sMessage01;
                                break;

                            case "{@sInvoiceMessage02}":
                                forReport.Text = sMessage02;
                                break;
                        }
                    }
                    frmPrint.crystalReportViewer1.ReportSource = reportCredit;
                    frmPrint.printThisDocument();
                }
            }
        }

        public static void printInvoice_Old(Main frmMain, string sDocumentNumber)
        {
            using (var reportInvoice = new InvoicePrint())
            {
                using (var frmPrint = new PrintInvoice())
                {
                    frmPrint.crystalReportViewer1.SelectionFormula = "{HistoryHeader.DocumentNumber} = \"" + sDocumentNumber + "\"";
                    var txtInvoiceMessage = (TextObject)reportInvoice.Section5.ReportObjects["txtInvoiceMessage"];
                    txtInvoiceMessage.Text = txtInvoiceMessage.Text.Replace("<I_NAME>", Global.sInvoiceContactName).Replace("<I_NUMBER123456>", Global.sInvoiceContactNumber).Replace("<ENTER>", "\r\n");

                    foreach (FormulaFieldDefinition forReport in reportInvoice.DataDefinition.FormulaFields)
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
                    frmPrint.crystalReportViewer1.ReportSource = reportInvoice;
                    frmPrint.printThisDocument();
                }
            }
        }

        public static void PrintQoute(string sDocumentNumber, string sPost01, string sPost02, string sPost03, string sPost04, string sCustDescription)
        {
            //build datatable for report
            var dtQoute = new dsQoute.dtQouteDataTable();
            var reportQoute = new SolQuote();


            using (var oConn = new PsqlConnection(Connect.LiquidConnectionString))
            {
                var sSqlHH = "Select * From SOLQHH where DocNumber = '" + sDocumentNumber + "'";
                using (var rdReaderQHH = Connect.getDataCommand(sSqlHH, oConn).ExecuteReader())
                {
                    while (rdReaderQHH.Read())
                    {
                        var sTotalTax = "";
                        var sTotalExcl = "";
                        var sTotalIncl = "";
                        foreach (FormulaFieldDefinition QouteReport in reportQoute.DataDefinition.FormulaFields)
                        {
                            switch (QouteReport.FormulaName)
                            {
                                case "{@sGlobCompanyName}":
                                    QouteReport.Text = "'" + Global.sCompanyName.Trim().Replace("'", "''") + "'";
                                    break;

                                case "{@sGlobCompanyRegName}":
                                    QouteReport.Text = "'" + Global.sRegName.Trim().Replace("'", "''") + "'";
                                    break;

                                case "{@sGlobVat}":
                                    QouteReport.Text = "'" + Global.sVAT.Trim() + "'";
                                    break;

                                case "{@sGlobReg}":
                                    QouteReport.Text = "'" + Global.sReg.Trim() + "'";
                                    break;

                                case "{@sGlobTel}":
                                    QouteReport.Text = "'" + Global.sCompanyTel.Trim().Replace("'", "''") + "'";
                                    break;

                                case "{@sGlobFax}":
                                    QouteReport.Text = "'" + Global.sCompanyFax.Trim().Replace("'", "''") + "'";
                                    break;

                                case "{@sGlobPost1}":
                                    QouteReport.Text = "'" + Global.sCompanyPostAd1.Trim().Replace("'", "''") + "'";
                                    break;

                                case "{@sGlobPost2}":
                                    QouteReport.Text = "'" + Global.sCompanyPostAd2.Trim().Replace("'", "''") + "'";
                                    break;

                                case "{@sGlobPost3}":
                                    QouteReport.Text = "'" + Global.sCompanyPostAd3.Trim().Replace("'", "''") + "'";
                                    break;

                                case "{@sGlobAdd1}":
                                    QouteReport.Text = "'" + Global.sCompanyAd1.Trim().Replace("'", "''") + "'";
                                    break;

                                case "{@sGlobAdd2}":
                                    QouteReport.Text = "'" + Global.sCompanyAd2.Trim().Replace("'", "''") + "'";
                                    break;

                                case "{@sGlobAdd3}":
                                    QouteReport.Text = "'" + Global.sCompanyAd3.Trim().Replace("'", "''") + "'";
                                    break;

                                case "{@CompanyCell}":
                                    QouteReport.Text = "'" + Global.sInvoiceContactNumber + "'";
                                    break;

                                case "{@DelAddress01}":
                                    QouteReport.Text = "'" + rdReaderQHH["DelAddress01"].ToString().Replace("'", "''") + "'";
                                    break;

                                case "{@DelAddress02}":
                                    QouteReport.Text = "'" + rdReaderQHH["DelAddress02"].ToString().Replace("'", "''") + "'";
                                    break;

                                case "{@DelAddress03}":
                                    QouteReport.Text = "'" + rdReaderQHH["DelAddress03"].ToString().Replace("'", "''") + "'";
                                    break;

                                case "{@DelAddress04}":
                                    QouteReport.Text = "'" + rdReaderQHH["DelAddress04"].ToString().Replace("'", "''") + "'";
                                    break;

                                case "{@DelAddress05}":
                                    QouteReport.Text = "'" + rdReaderQHH["DelAddress05"].ToString().Replace("'", "''") + "'";
                                    break;

                                case "{@PostAddress01}":
                                    QouteReport.Text = "'" + sPost01.Replace("'", "''") + "'";
                                    break;

                                case "{@PostAddress02}":
                                    QouteReport.Text = "'" + sPost02.Replace("'", "''") + "'";
                                    break;

                                case "{@PostAddress03}":
                                    QouteReport.Text = "'" + sPost03.Replace("'", "''") + "'";
                                    break;

                                case "{@PostAddress04}":
                                    QouteReport.Text = "'" + sPost04.Replace("'", "''") + "'";
                                    break;

                                case "{@DocDate}":
                                    QouteReport.Text = "'" + Convert.ToString(Convert.ToDateTime(rdReaderQHH["DocDate"].ToString()).ToString("dd/MM/yyyy")) + "'";
                                    break;

                                case "{@CustomerCode}":
                                    QouteReport.Text = "'" + rdReaderQHH["CustCode"].ToString().Replace("'", "''") + "'";
                                    break;

                                case "{@CustomerDescription}":
                                    QouteReport.Text = "'" + sCustDescription.Replace("'", "''") + "'";
                                    break;

                                case "{@CustRef}":
                                    QouteReport.Text = "'" + rdReaderQHH["CustRef"].ToString().Replace("'", "''") + "'";
                                    break;

                                case "{@SalesCode}":
                                    QouteReport.Text = "'" + rdReaderQHH["SalesCode"] + "'";
                                    break;

                                case "{@Note}":
                                    QouteReport.Text = "'" + rdReaderQHH["Notes"].ToString().Replace("\r\n", "  ").Replace("'", "''") + "'";
                                    break;

                                case "{@CustTel}":
                                    QouteReport.Text = "'" + rdReaderQHH["Tel"] + "'";
                                    break;

                                case "{@CustFax}":
                                    QouteReport.Text = "'" + rdReaderQHH["Fax"] + "'";
                                    break;

                                case "{@CustContact}":
                                    QouteReport.Text = "'" + rdReaderQHH["Contact"] + "'";
                                    break;

                                case "{@TotalDiscount}":
                                    QouteReport.Text = "'" + rdReaderQHH["TotalDiscount"] + "'";
                                    break;

                                case "{@TotalExcl}":
                                    QouteReport.Text = "'" + rdReaderQHH["TotalExcl"] + "'";
                                    sTotalExcl = rdReaderQHH["TotalExcl"].ToString();
                                    break;

                                case "{@TotalTax}":
                                    QouteReport.Text = "'" + rdReaderQHH["TotalTax"] + "'";
                                    sTotalTax = rdReaderQHH["TotalTax"].ToString();
                                    break;

                                case "{@TotalIncl}":
                                    QouteReport.Text = "'" + rdReaderQHH["Total"] + "'";
                                    sTotalIncl = rdReaderQHH["Total"].ToString();
                                    break;

                                case "{@DocNumber}":
                                    QouteReport.Text = "'" + rdReaderQHH["DocNumber"] + "'";
                                    break;
                            }
                        }
                        var sSqlHL = "Select * From SOLQHL where DocNumber = '" + sDocumentNumber + "' order by LinkNum";
                        using (var rdReaderQHL = Connect.getDataCommand(sSqlHL, oConn).ExecuteReader())
                        {
                            while (rdReaderQHL.Read())
                            {
                                var drRow = dtQoute.NewRow();
                                drRow["ItemCode"] = rdReaderQHL["ItemCode"].ToString();
                                drRow["Unit"] = rdReaderQHL["Unit"].ToString();
                                drRow["ItemDescription"] = rdReaderQHL["Description"].ToString();
                                drRow["Quantity"] = rdReaderQHL["Qty"].ToString();
                                drRow["Discount"] = rdReaderQHL["DiscountPercentage"].ToString();
                                drRow["ExclPrice"] = rdReaderQHL["UnitPrice"].ToString();
                                drRow["Nett"] = rdReaderQHL["LineTotalExcl"].ToString();
                                drRow["TotalExcl"] = sTotalExcl;
                                drRow["TotalTax"] = sTotalTax;
                                drRow["TotalIncl"] = sTotalIncl;

                                dtQoute.Rows.Add(drRow);
                            }
                            rdReaderQHL.Close();
                        }
                    }
                    oConn.Dispose();
                    rdReaderQHH.Close();
                }
            }
            var dsQoute = new DataSet();
            dsQoute.Tables.Add(dtQoute);
            reportQoute.SetDataSource(dsQoute.Tables["dtQoute"]);
            //convert attached pic to pdf
            var n = 1; //pdf counter
            using (var oConn = new PsqlConnection(Connect.LiquidConnectionString))
            {
                var sSql = "Select * From SOLQA where FkDocNumber = '" + sDocumentNumber + "'";
                using (var rdReader = Connect.getDataCommand(sSql, oConn).ExecuteReader())
                {
                    while (rdReader.Read())
                    {
                        var source = rdReader["Path"].ToString();
                        var iLength = source.Length;
                        if (source.Substring(iLength - 3, 3).ToUpper() == "PDF")
                        {
                            //only copy file
                            var destinaton = Application.StartupPath + "\\Attachments\\Pic" + n + ".pdf";
                            File.Copy(source, destinaton);
                        }
                        else
                        {
                            var destinaton = Application.StartupPath + "\\Attachments\\Pic" + n + ".pdf";
                            var doc = new PdfDocument();
                            doc.Pages.Add(new PdfPage());
                            var xgr = XGraphics.FromPdfPage(doc.Pages[0]);
                            var img = XImage.FromFile(source);
                            xgr.DrawImage(img, 0, 0);
                            doc.Save(destinaton);
                            doc.Close();
                        }

                        n++;
                    }
                }
            }

            reportQoute.ExportToDisk(ExportFormatType.PortableDocFormat, Application.StartupPath + "\\Attachments\\Qoute.pdf");
        }

        public void DeleteTempDirectory()
        {
            if (Directory.Exists(Application.StartupPath + "\\Temp"))
            {
                try
                {
                    Directory.Delete(Application.StartupPath + "\\Temp", true);
                }
                catch(Exception e)
                {
                    var x = e;
                }
                
            }
        }

        private static void convertToPdfAndPrint(List<ReportClass> reports, List<string> refNumbers, string refName, int salesOrderAmount = 1)
        {

            if (!Directory.Exists(Application.StartupPath + "\\Temp"))
            {
                Directory.CreateDirectory(Application.StartupPath + "\\Temp");
            }
            var reportName = "";
            //suppress Copy watermark for first copy
            int deliveryIndex = 0;
            var reportFileName = Application.StartupPath + $"\\Temp\\{refName}_{DateTime.Now.ToString("ddMMyyHHmmss")}";
            List<string> reportsToPrint = new List<string>();

            reports.ForEach(reportDelivery =>
            {
            reportDelivery.ReportDefinition.Sections[1].SectionFormat.EnableSuppress = true;
            reportName = $"{reportFileName}_{refNumbers[deliveryIndex]}";
            var copyNumber = 1;
            while (File.Exists(reportName))
            {
                reportName = $"{reportFileName}_{refNumbers[deliveryIndex]} ({copyNumber})";
                copyNumber++;
            }
            reportsToPrint.Add(reportName);
            reportDelivery.ExportToDisk(ExportFormatType.PortableDocFormat, $"{reportName}.pdf");
                var reportDeliveryCopy = new ReportClass();
                reportDeliveryCopy = reportDelivery;
                //show Copy Watermark
                reportDeliveryCopy.ReportDefinition.Sections[1].SectionFormat.EnableSuppress = false;
                var reportCopyName = $"{reportName}Copy.pdf";
                var copyCopyNumber = 1;
                while (File.Exists(reportCopyName))
                {
                    reportCopyName = $"{reportName}Copy ({copyCopyNumber}).pdf";
                    copyCopyNumber++;
                }
                reportDeliveryCopy.ExportToDisk(ExportFormatType.PortableDocFormat, reportCopyName);
                deliveryIndex++;
            });

            if (refName == "DeliveryNote")
            {
                using (var outputDocument = new PdfDocument())
                {
                    var filename = "";
                    var reportIndex = 0;
                    //merge terms and conditions with report
                    try
                        {
                            var inputDocument = new PdfDocument();
                            var pageIndex = 0;

                            var lastPageIndex = (4 * salesOrderAmount) - 1; //page amount
                            try
                            {
                                while (pageIndex <= lastPageIndex)
                                {
                                    if (pageIndex % 4 == 0) //1st page
                                    {
                                        deliveryIndex = pageIndex / 4;
                                        inputDocument = PdfReader.Open($"{reportsToPrint[reportIndex]}.pdf", PdfDocumentOpenMode.Import);
                                        
                                    }
                                    else if (pageIndex % 2 != 0) //odd
                                    {
                                        //add terms file
                                        if (File.Exists(Application.StartupPath + "\\Attachments\\Kings Hire terms and conditions.pdf"))
                                        {
                                            inputDocument = PdfReader.Open(Application.StartupPath + "\\Attachments\\Kings Hire terms and conditions.pdf", PdfDocumentOpenMode.Import);
                                        }
                                        else
                                        {
                                            MessageBox.Show("Please confirm that Terms and condition file exists");
                                        }
                                    }
                                    else if (pageIndex % 2 == 0) //even
                                    {
                                        inputDocument = PdfReader.Open($"{reportsToPrint[reportIndex]}Copy.pdf", PdfDocumentOpenMode.Import);
                                        reportIndex++;
                                }
                                    // Get the page from the external document...
                                    var page = inputDocument.Pages[0];
                                    // ...and add it to the output document.
                                    outputDocument.AddPage(page);
                                    pageIndex++;
                                }
                            }
                            catch
                            {
                            }

                        }
                        catch (Exception Ex)
                        {
                            MessageBox.Show("Error Merging PDF Files, Please verify path of attached pictures.");
                        }

                    
                    // Save the document...
                    try
                    {
                        filename = $"{reportFileName}.pdf";
                        outputDocument.Save(filename);
                        Process.Start(filename);
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show($"Error saving file to directory, please verify path in Company Setup - {ex.Message}");
                    }
                }

                
            }
            else
            {
                Process.Start(reportName);
            }
            
        }

        private static void createKingsHireReport(ref ReportClass reportDelivery, PsqlConnection oLiquidConn, PsqlConnection oPastelConn, string sCoordinates, string sCollected, string sMessage01, string sMessage02, string sDocumentNumber)
        {
            var sSql = "";
            reportDelivery = new Site();
            sSql = "Select HistoryHeader.DocumentNumber, HistoryHeader.CustomerCode, HistoryHeader.DocumentDate, HistoryHeader.SalesmanCode, DelAddress01, DelAddress02, DelAddress03, DelAddress04, DelAddress05, HistoryLines.ItemCode, UnitUsed, HistoryLines.Description, Qty, UnitPrice ";
            sSql += ",LinkNum, CustomerDesc, PostAddress01,PostAddress02,PostAddress03,PostAddress04,PostAddress05, OrderNumber,UserDefNum01, UserDefNum02, DiscountPercentage ";
            sSql += " From HistoryHeader Left Join HistoryLines on HistoryHeader.DocumentNumber = HistoryLines.DocumentNumber ";
            sSql += " Left Join CustomerMaster on HistoryHeader.CustomerCode = CustomerMaster.CustomerCode";
            sSql += " Left Join Inventory on HistoryLines.ItemCode = Inventory.ItemCode";
            sSql += " Where HistoryHeader.DocumentNumber = '" + sDocumentNumber + "'  and HistoryHeader.DocumentType in (102,2) and HistoryLines.DocumentType in (102,2) order by LinkNum";
            var dtDelivery = new dsDeliveryNote.delivery_01DataTable();

            using (var rdReader = Connect.getDataCommand(sSql, oPastelConn).ExecuteReader())
            {
                while (rdReader.Read())
                {
                    var drRow = dtDelivery.NewRow();

                    var authorizedSql = string.Format("select * from SOLHH where docnumber = '{0}'", sDocumentNumber);

                    using (var reader = Connect.getDataCommand(authorizedSql, oLiquidConn).ExecuteReader())
                        while (reader.Read())
                        {
                            drRow["AuthorizedPerson"] = reader["AuthorizedPerson"].ToString();
                        }

                    drRow["DocumentNumber"] = rdReader["DocumentNumber"];
                    drRow["CustomerCode"] = rdReader["CustomerCode"];
                    drRow["DocumentDate"] = rdReader["DocumentDate"];
                    //get salesman name from solus 06/13/2011
                    var salesmanCode = rdReader["SalesmanCode"].ToString().Trim();
                    string sUserName;
                    //todo try to find out why SalesmanCode code disapeared
                    if (salesmanCode != "")
                    {
                        //var sSqlUs = "Select UserName from SOLUS where Code = '" + rdReader["SalesmanCode"] + "'";
                        var sSqlUs = "Select UserName from SOLUS where Code = '" + salesmanCode + "'";
                        sUserName = Connect.getDataCommand(sSqlUs, oLiquidConn).ExecuteScalar().ToString();
                    }
                    else
                    {
                        sUserName = "Unknown";
                    }

                    drRow["SalesmanCode"] = sUserName;

                    using (var oConn = new PsqlConnection(Connect.LiquidConnectionString))
                    {
                        oConn.Open();
                        if (rdReader["SalesmanCode"].ToString().Trim() != "")
                        {
                            sSql = "Select top 1 TelephoneNumber From SOLUS where Code = '" + rdReader["SalesmanCode"] + "'";
                            drRow["TelephoneNumber"] = Connect.getDataCommand(sSql, oConn).ExecuteScalar().ToString();
                        }
                        else
                        {
                            drRow["TelephoneNumber"] = "";
                        }

                        oConn.Dispose();
                    }

                    using (var oConn = new PsqlConnection(Connect.LiquidConnectionString))
                    {
                        oConn.Open();
                        if (rdReader["SalesmanCode"].ToString().Trim() != "")
                        {
                            sSql = "Select top 1 Shortname From SOLUS where Code = '" + rdReader["SalesmanCode"] + "'";
                            drRow["ShortName"] = Connect.getDataCommand(sSql, oConn).ExecuteScalar().ToString();
                        }
                        else
                        {
                            drRow["ShortName"] = "";
                        }

                        oConn.Dispose();
                    }

                    using (var oConn = new PsqlConnection(Connect.LiquidConnectionString))
                    {
                        oConn.Open();
                        if (rdReader["SalesmanCode"].ToString().Trim() != "")
                        {
                            sSql = "Select top 1 Description From SOLUS where Code = '" + rdReader["SalesmanCode"] + "'";
                            drRow["SalesmanName"] = Connect.getDataCommand(sSql, oConn).ExecuteScalar().ToString();
                        }
                        else
                        {
                            drRow["SalesmanName"] = "";
                        }

                        oConn.Dispose();
                    }
                    drRow["DelAddress01"] = rdReader["DelAddress01"];
                    drRow["DelAddress02"] = rdReader["DelAddress02"];
                    drRow["DelAddress03"] = rdReader["DelAddress03"];
                    drRow["DelAddress04"] = rdReader["DelAddress04"];
                    drRow["DelAddress05"] = rdReader["DelAddress05"];
                    drRow["ItemCode"] = rdReader["ItemCode"];
                    drRow["UnitUsed"] = rdReader["UnitUsed"];
                    drRow["Description"] = rdReader["Description"];
                    drRow["Qty"] = rdReader["Qty"];
                    drRow["UnitPrice"] = rdReader["UnitPrice"];
                    drRow["LinkNum"] = rdReader["LinkNum"];
                    drRow["CustomerDesc"] = rdReader["CustomerDesc"];
                    drRow["PostAddress01"] = rdReader["PostAddress01"];
                    drRow["PostAddress02"] = rdReader["PostAddress02"];
                    drRow["PostAddress03"] = rdReader["PostAddress03"];
                    drRow["PostAddress04"] = rdReader["PostAddress04"];
                    drRow["PostAddress05"] = rdReader["PostAddress05"];
                    drRow["OrderNumber"] = rdReader["OrderNumber"];
                    drRow["LineDiscount"] = rdReader["DiscountPercentage"];
                    if (rdReader["ItemCode"].ToString().Trim() != "'" && !rdReader["ItemCode"].ToString().Trim().StartsWith("*D"))
                    {
                        if (rdReader["UserDefNum01"].ToString() == "1")
                        {
                            sSql = "select Convert(Multiplier,SQL_VARCHAR) + '|' + Convert(Status,SQL_VARCHAR)  from SOLHL where Header = '" + rdReader["DocumentNumber"].ToString().Trim() + "' and LinkNum =" + rdReader["LinkNum"];
                            var aMultiplierRet = Connect.getDataCommand(sSql, oLiquidConn).ExecuteScalar().ToString().Split("|".ToCharArray()[0]).ToList();
                            drRow["Multiplier"] = aMultiplierRet[0];
                            if (aMultiplierRet[1] == "1")
                            {
                                drRow["Returned"] = "*Ret";
                            }
                            else
                            {
                                drRow["Returned"] = "";
                            }
                        }
                        else
                        {
                            sSql = "select Convert(Multiplier,SQL_VARCHAR) + '|' + Convert(Status,SQL_VARCHAR) from SOLHL where Header = '" + rdReader["DocumentNumber"].ToString().Trim() + "' and LinkNum =" + rdReader["LinkNum"];
                            var aQtyRet = Connect.getDataCommand(sSql, oLiquidConn).ExecuteScalar().ToString().Split("|".ToCharArray()[0]).ToList();
                            drRow["Multiplier"] = aQtyRet[0];
                            if (aQtyRet[1] == "1")
                            {
                                drRow["Returned"] = "*Ret";
                            }
                            else
                            {
                                drRow["Returned"] = "";
                            }
                        }
                    }
                    dtDelivery.Rows.Add(drRow);
                }
                rdReader.Close();
            }

            var deliveryNoteMessage = (TextObject)((Site)reportDelivery).GroupFooterSection1.ReportObjects["DeliveryNoteMessage"];

            if (!String.IsNullOrEmpty(Global.DeliveryNoteMessage))
                deliveryNoteMessage.Text = Global.DeliveryNoteMessage;

            var txtDeliveryMessage = (TextObject)((Site)reportDelivery).Section5.ReportObjects["txtConditions"];

            if (txtDeliveryMessage != null)
            {
                txtDeliveryMessage.Text = txtDeliveryMessage.Text.Replace("<Company>", Global.sDeliveryNoteCompany);
            }
            var dtDel = new DataTable();
            dtDel = dtDelivery;
            try
            {
                reportDelivery.SetDataSource(dtDel);
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show(ex.ToString());
            }

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

                    case "{@sInvoiceMessage01}":
                        forReport.Text = sMessage01;
                        break;

                    case "{@sInvoiceMessage02}":
                        forReport.Text = sMessage02;
                        break;

                    case "{@sCoordinates}":
                        forReport.Text = "'" + sCoordinates + "'";
                        break;

                    case "{@Collected}":
                        if (sCollected == "COLLECTED")
                            sCollected = sCollected + " BY:";
                        else
                            sCollected = sCollected + " TO:";
                        forReport.Text = "'" + sCollected + "'";
                        break;

                    case "{@CompanyCell}":
                        forReport.Text = "'" + Global.sInvoiceContactNumber + "'";
                        break;

                    case "{@sBarcode}":
                        forReport.Text = "'" + "*" + sDocumentNumber + "*" + "'";
                        break;
                }
            }
        }

        private static void printReport(List<ReportClass> reports, bool sendToDepot, List<string> refNumbers, string fileName, int salesOrderAmount = 1)
        {
            //convert to pdf for terms attachment
            if (Global.sDeliveryNoteTemplate == "Kings Hire")
            {
                convertToPdfAndPrint(reports, refNumbers, fileName, salesOrderAmount);
            }

            if (sendToDepot)
            {
                var reportIndex = 0;
                reports.ForEach(reportDelivery =>
                {
                    //Send file to workstation
                    if (!Directory.Exists(Application.StartupPath + "\\Temp"))
                    {
                        Directory.CreateDirectory(Application.StartupPath + "\\Temp");
                    }
                    var sFilename = refNumbers[reportIndex] + ".rpt";

                    if (File.Exists(Application.StartupPath + "\\Temp\\" + sFilename))
                    {
                        File.Delete(Application.StartupPath + "\\Temp\\" + sFilename);
                    }
                    //                            reportDelivery.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Application.StartupPath + "\\Temp\\" + sFilename);
                    reportDelivery.SaveAs(Application.StartupPath + "\\Temp\\" + sFilename, true);
                    reportIndex++;
                });               

                return;
            }

            if (Global.sDeliveryNoteTemplate == "Talisman - Faerie Glenn")
            {
                reports.ForEach(reportDelivery =>
                {
                    reportDelivery.PrintOptions.PrinterName = Global.sDefaultDocPrinter;
                    reportDelivery.PrintToPrinter(2, false, 0, 0);
                });
                
            }
            else if (Global.sDeliveryNoteTemplate != "Kings Hire")
            {
                reports.ForEach(reportDelivery =>
                {
                    reportDelivery.PrintOptions.PrinterName = Global.sDefaultDocPrinter;

                    reportDelivery.PrintToPrinter(1, false, 0, 0);
                });                
            }
        }

        public static void PrintOffHiredOrders(List<OffHireOrder> offHiredOrders)
        {
            ReportClass offHiredOrdersReport = new OffHiredOrdersReport();

            var dataTable = new dsOffHiredOrders.dtOffHiredOrdersDataTable();
            const string _dateFormat = "dd/MM/yy";
            const string _timeFormat = "HH:mm";

            offHiredOrders.ForEach(order =>
            {
                var dtRow = dataTable.NewRow();
                dtRow["OffHireNumber"] = order.OffHireNumber;
                dtRow["Date"] = order.OffHiredOnDate.ToString(_dateFormat);
                dtRow["Time"] = order.OffHiredOnDate.ToString(_timeFormat);
                dtRow["OffHireDate"] = order.OffHireDate.ToString(_dateFormat);
                dtRow["ItemNumber"] = order.ItemNumber;
                dtRow["ClientCode"] = order.ClientCode;
                dtRow["Name"] = order.OffhiredBy;
                dtRow["DeliveryNoteNumber"] = order.DeliveryNoteNumber;
                dtRow["Comments"] = order.OffHireComments;
                dataTable.Rows.Add(dtRow);
            });

            DataTable dataSourse = dataTable;
            try
            {
                offHiredOrdersReport.SetDataSource(dataSourse);
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show(ex.ToString());
            }

            
            List<ReportClass> reports = new List<ReportClass>();
            reports.Add(offHiredOrdersReport);
            List<string> refNumbers = new List<string>();
            refNumbers.Add(DateTime.Now.ToString("dd_MM_yyyy"));
            printReport(reports, false, refNumbers, "OffHiredOrderReport");
            
        }

        public static void PrintDeliveryNote(string sDocumentNumber, string sMessage01, string sMessage02, string sCoordinates, string sCollected, bool bFirstPrint, bool sendToDepot, PrintDialog pdPrintDetails, DataGridView dgTest)
        {
            using (var oPastelConn = new PsqlConnection(Connect.PastelConnectionString))
            {
                using (var oLiquidConn = new PsqlConnection(Connect.LiquidConnectionString))
                {
                    ReportClass reportDelivery = null;

                    oPastelConn.Open();
                    var sSql = "";
                  
                    if (Global.sDeliveryNoteTemplate == "Kings Hire")
                    {
                        createKingsHireReport(ref reportDelivery, oLiquidConn, oPastelConn, sCoordinates, sCollected, sMessage01, sMessage02, sDocumentNumber);
                    }

                    var iFPQuantity = Convert.ToDecimal(ConfigurationSettings.AppSettings.Get("DeliveryNoteFirstPrintCopies"));
                    var iDPQuantity = Convert.ToDecimal(ConfigurationSettings.AppSettings.Get("DeliveryNoteDuplicatePrintCopies"));
                    var filename = "";

                    //Printing of delivery note
                    try
                    {
                        List<ReportClass> reportDeliveries = new List<ReportClass>();
                        reportDeliveries.Add(reportDelivery);
                        List<string> docNumbers = new List<string>();
                        docNumbers.Add(sDocumentNumber);
                        printReport(reportDeliveries, sendToDepot, docNumbers, "DeliveryNote");
                    }
                    catch (Exception Ex)
                    {
                        using (var frmPrint = new PrintInvoice())
                        {
                            frmPrint.crystalReportViewer1.ReportSource = reportDelivery;
                            frmPrint.printThisDocument();
                        }
                    }

                    oPastelConn.Dispose();
                }
            }
        }

        public void PrintDeliveryNotesDynamic(List<HistoryHeader> historyHeaders, bool bFirstPrint, bool sendToDepot,
            PrintDialog pdPrintDetails, DataGridView dgTest)
        {
            using (var oPastelConn = new PsqlConnection(Connect.PastelConnectionString))
            {
                using (var oLiquidConn = new PsqlConnection(Connect.LiquidConnectionString))
                {

                    List<ReportClass> reportDeliveries = new List<ReportClass>();
                    List<string> docNumbers = new List<string>();

                    oPastelConn.Open();
                    var sSql = "";

                    if (Global.sDeliveryNoteTemplate == "Kings Hire")
                    {
                        historyHeaders.ForEach(header =>
                        {
                            ReportClass reportDelivery = null;
                            var sCollected = header.Collected ? "COLLECTED" : "DELIVERED";
                            createKingsHireReport(ref reportDelivery, oLiquidConn, oPastelConn, header.Coordinates.Replace("|", "'"), sCollected, "", "", header.DocNumber);
                            reportDeliveries.Add(reportDelivery);
                            docNumbers.Add(header.DocNumber);
                        });                        
                    }

                    //Printing of delivery note
                    try
                    {
                        printReport(reportDeliveries, sendToDepot, docNumbers, "DeliveryNote", historyHeaders.Count);
                    }
                    catch (Exception Ex)
                    {
                        using (var frmPrint = new PrintInvoice())
                        {
                            frmPrint.crystalReportViewer1.ReportSource = reportDeliveries;
                            frmPrint.printThisDocument();
                        }
                    }

                    oPastelConn.Dispose();
                }
            }
        }

        public void PrintDeliveryNoteDynamic(string sDocumentNumber, string sMessage01, string sMessage02, string sCoordinates, string sCollected, bool bFirstPrint, bool sendToDepot, PrintDialog pdPrintDetails, DataGridView dgTest)
        {
            PrintDeliveryNote(sDocumentNumber, sMessage01, sMessage02, sCoordinates, sCollected, bFirstPrint, sendToDepot, pdPrintDetails, dgTest);
        }

        public string GetPeriodValue(DateTime dtDate)
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
                    if (dtDate >= Convert.ToDateTime(rdReader["PerStartThis01"].ToString()) && dtDate <= Convert.ToDateTime(rdReader["PerEndThis01"].ToString()).AddDays(1))
                        sReturn = "1";
                    else if (dtDate >= Convert.ToDateTime(rdReader["PerStartThis02"].ToString()) && dtDate < Convert.ToDateTime(rdReader["PerEndThis02"].ToString()).AddDays(1))
                        sReturn = "2";
                    else if (dtDate >= Convert.ToDateTime(rdReader["PerStartThis03"].ToString()) && dtDate < Convert.ToDateTime(rdReader["PerEndThis03"].ToString()).AddDays(1))
                        sReturn = "3";
                    else if (dtDate >= Convert.ToDateTime(rdReader["PerStartThis04"].ToString()) && dtDate < Convert.ToDateTime(rdReader["PerEndThis04"].ToString()).AddDays(1))
                        sReturn = "4";
                    else if (dtDate >= Convert.ToDateTime(rdReader["PerStartThis05"].ToString()) && dtDate < Convert.ToDateTime(rdReader["PerEndThis05"].ToString()).AddDays(1))
                        sReturn = "5";
                    else if (dtDate >= Convert.ToDateTime(rdReader["PerStartThis06"].ToString()) && dtDate < Convert.ToDateTime(rdReader["PerEndThis06"].ToString()).AddDays(1))
                        sReturn = "6";
                    else if (dtDate >= Convert.ToDateTime(rdReader["PerStartThis07"].ToString()) && dtDate < Convert.ToDateTime(rdReader["PerEndThis07"].ToString()).AddDays(1))
                        sReturn = "7";
                    else if (dtDate >= Convert.ToDateTime(rdReader["PerStartThis08"].ToString()) && dtDate < Convert.ToDateTime(rdReader["PerEndThis08"].ToString()).AddDays(1))
                        sReturn = "8";
                    else if (dtDate >= Convert.ToDateTime(rdReader["PerStartThis09"].ToString()) && dtDate < Convert.ToDateTime(rdReader["PerEndThis09"].ToString()).AddDays(1))
                        sReturn = "9";
                    else if (dtDate >= Convert.ToDateTime(rdReader["PerStartThis10"].ToString()) && dtDate < Convert.ToDateTime(rdReader["PerEndThis10"].ToString()).AddDays(1))
                        sReturn = "10";
                    else if (dtDate >= Convert.ToDateTime(rdReader["PerStartThis11"].ToString()) && dtDate < Convert.ToDateTime(rdReader["PerEndThis11"].ToString()).AddDays(1))
                        sReturn = "11";
                    else if (dtDate >= Convert.ToDateTime(rdReader["PerStartThis12"].ToString()) && dtDate < Convert.ToDateTime(rdReader["PerEndThis12"].ToString()).AddDays(1))
                        sReturn = "12";
                    else if (dtDate >= Convert.ToDateTime(rdReader["PerStartThis13"].ToString()) && dtDate < Convert.ToDateTime(rdReader["PerEndThis13"].ToString()).AddDays(1))
                        sReturn = "13";
                }
                rdReader.Close();
                oConn.Dispose();
            }
            return sReturn;
        }
    }
}