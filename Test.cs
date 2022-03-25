using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Solsage_Pastel_API;
using Pervasive.Data.SqlClient;
using Liquid.Classes;
using System.Drawing.Printing;

namespace Liquid
{
	public partial class Test : Form
	{
		public Test()
		{
			InitializeComponent();
		}

		private void cmdGetInventory_Click(object sender, EventArgs e)
		{
			//PastelInventoryJnl InvJSDK = new PastelInventoryJnl();

			//Functions.SetYourLicense(((Main)this.MdiParent).SDK);
			//string sSdkReturn = ((Main)this.MdiParent).SDK.SetDataPath(Functions.sDataPath);
			//if (sSdkReturn == "0")
			//{
			//    string sStore = "JHB";
			//    string sItem = "ACC/LOC";
			//    bool bThisYear = true;
			//    short iPeriod = 13;
			//    sSdkReturn = InvJSDK.OnHand(ref sStore, ref sItem, ref bThisYear, ref iPeriod).ToString();
			//    txtSdkResults.Text = sSdkReturn;
			//}

		}

		private void cmdInvoice_Click(object sender, EventArgs e)
		{
			Cursor = System.Windows.Forms.Cursors.WaitCursor;
			solPastelSDK clsPastelSDK = new solPastelSDK();
			string[] aLines = new string[3];
            aLines[0] = "0|0|0|0|    |0|0|0|'              |Invoiced: 09/11/09-09/11/09: 1 Day      |7|001|     |";
            aLines[1] = "0|1|105.26|120|DAY |1|0|0|020PHIREDRIVE  |DRIVE UNIT HONDA GX160                  |4|001|     |";
            aLines[2] = "";
            string sHeader = "|||MEGAPA|2009/11/06 12:00:00 AM|IN100100|Y|0||||VAT # 4410172417|POST-NET 17|PRIVATE BAG X 1013|PHALABORWA, 1390||00001|0||2009/11/06 12:00:00 AM|0157812461|DEON BEESELAAR|0157812314|1|||VAT # 4410172417|POST-NET 17|PRIVATE BAG X 1013|PHALABORWA, 1390|PHALABORWA, 1390|||0";
            //string sResult = clsPastelSDK.CreatePastelDocument(sHeader, aLines, 106, Global.sDataPath, Global.iPastelSdkUser, Global.bLogCreateDocument);
			
			//txtSdkResults.Text = sResult;
						
			Cursor = System.Windows.Forms.Cursors.Default;
		}

		private void cmdSalesTest_Click(object sender, EventArgs e)
		{
			Liquid.Documents.SalesOrder  frmSales = new Liquid.Documents.SalesOrder();
			frmSales.ShowDialog("IO100026",DateTime.Now);			    
		}

        private void button1_Click(object sender, EventArgs e)
        {
            string stest = "";
            string stest2 = "";
            string sSql = "";
            using (PsqlConnection oConn = new PsqlConnection(Liquid.Classes.Connect.PastelConnectionString))
            {
                oConn.Open();
                string str = char.ConvertFromUtf32(1);

                string sDocumentNumber = "GN100023";

                sSql = "Update HistoryHeader set GRNMisc = '" + str +"' where DocumentNumber = '" + sDocumentNumber + "'";

                int iReturn = Liquid.Classes.Connect.getDataCommand(sSql, oConn).ExecuteNonQuery();
                
                
                sSql = "Select * from HistoryHeader ";
                sSql += "left join HistoryLines on HistoryHeader.DocumentNumber = HistoryLines.DocumentNumber ";
                sSql += "where HistoryHeader.DocumentNumber = '" + sDocumentNumber + "'";

                PsqlDataReader rdReader = Liquid.Classes.Connect.getDataCommand(sSql, oConn).ExecuteReader();

                while (rdReader.Read())
                {
                    stest = rdReader["GRNMisc"].ToString();
                    char[] atest = rdReader["GRNMisc"].ToString().ToCharArray();
                    

                    stest2 = rdReader["CaseLotCode"].ToString();

                }
                rdReader.Close();
                MessageBox.Show("--"+stest+"--");

                oConn.Dispose();
            }
        }

        private void cmdPrint_Click(object sender, EventArgs e)
        {
           PrintDocument printDoc = new PrintDocument();
           printDoc.PrintPage += new PrintPageEventHandler(printDoc_PrintPage);
           PrinterSettings prtSettings = new PrinterSettings();
           prtSettings.PrinterName = Global.sDefaultSlipPrinter;
           
            
            PrinterResolution x = new PrinterResolution();
            x.Kind = PrinterResolutionKind.Draft;
            prtSettings.DefaultPageSettings.PrinterResolution = x;
           printDoc.PrinterSettings = prtSettings;         
           printDoc.Print();
        }
        private void printDoc_PrintPage(Object sender, PrintPageEventArgs e)
        {
            BarcodeStringConverter.EAN8 newString = new BarcodeStringConverter.EAN8();
            string sTest = "0002321";
            string textToPrint = newString.EAN8(ref sTest);
            Font printFont = new Font("Code EAN13",40);
            e.Graphics.DrawString(textToPrint, printFont, Brushes.Black, 0, 0);
        }

        private void Test_Load(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sConnString = "Server Name=localhost;Database Name=LSYNC;";
            using (PsqlConnection oPastelConn = new PsqlConnection(sConnString))
            {
                oPastelConn.Open();

                Cursor = System.Windows.Forms.Cursors.WaitCursor;
                solPastelSDK clsPastelSDK = new solPastelSDK();

                string[] aLines = new string[2];
                aLines[0] = "0|1|105.28|120|DAY |1|0|0|023PHIREDRILL|DRILL HILTI TE16                        |4|001|     |";
  //              aLines[0] = "0|1|162.28|162.28|DAY |0|0|0|039PHIREGENERA|6KVA GENERATOR HONDA MGS6000            |4|001|     |";
                aLines[1] = "0|1|0.02|0.02|    |0|0|0|1000020        |Rounding                                |6|001|     |";

                string sHeader = "|||ABS001|05/02/2010|IN100159|Y|0|||||||||00001|0||2010/02/05 12:00:00 AM||Blondie||1|||||||||26477506|0";

                string sDataPath = "C:\\Pastel09\\FAIREGLEN";
                string sResult = clsPastelSDK.CreatePastelDocument(sHeader, aLines, 106, sDataPath, Global.iPastelSdkUser, false, oPastelConn, 1);

                MessageBox.Show(sResult);
                //CreatePastelDocument(sHeader, aLines, 106, sDataPath, Global.iPastelSdkUser, Global.bLogCreateDocument);

                //txtSdkResults.Text = sResult;

                Cursor = System.Windows.Forms.Cursors.Default;
            }
                        

        }

        private void cmdInvoiceIntegrity_Click(object sender, EventArgs e)
        {
            Cursor = System.Windows.Forms.Cursors.WaitCursor;
            string sSql = "", sStatus = "";
            dgIntegrity.Rows.Clear();
            using (PsqlConnection oPastelConn = new PsqlConnection(Liquid.Classes.Connect.PastelConnectionString))
            {
                oPastelConn.Open();
                using (PsqlConnection oPastelConn2 = new PsqlConnection(Liquid.Classes.Connect.PastelConnectionString))
                {
                    using (PsqlConnection oLiquidConn2 = new PsqlConnection(Liquid.Classes.Connect.LiquidConnectionString))
                    {
                        oPastelConn2.Open();
                        oLiquidConn2.Open();
                        
                        sSql = "Select * from   HistoryHeader where documenttype in (103)";
                        using (PsqlDataReader rdPastelReader2 = Connect.getDataCommand(sSql, oPastelConn2).ExecuteReader())
                        {
                            while (rdPastelReader2.Read())
                            {
                                int iRowID = dgIntegrity.Rows.Add();
                                dgIntegrity.Rows[iRowID].Cells["clSalesOrder"].Value = rdPastelReader2["DocumentNumber"].ToString();
                                dgIntegrity.Rows[iRowID].Cells["clCustomer"].Value = rdPastelReader2["CustomerCode"].ToString();

                                sSql = "select count(*) from SOLIL where DocumentNumber = '" + rdPastelReader2["DocumentNumber"] + "'";
                                int iLiquid = Convert.ToInt32(Connect.getDataCommand(sSql, oLiquidConn2).ExecuteScalar());
                                dgIntegrity.Rows[iRowID].Cells["clLiquid"].Value = iLiquid.ToString();

                                if (iLiquid == 1)
                                {
                                    sSql = "select description from SOLIL where DocumentNumber = '" + rdPastelReader2["DocumentNumber"] + "'";
                                    string sItemDescrip = Connect.getDataCommand(sSql, oLiquidConn2).ExecuteScalar().ToString();
                                    dgIntegrity.Rows[iRowID].Cells["clitemdescrip"].Value = sItemDescrip;
                                }

                                sSql = "select count(*) from HistoryLines where DocumentNumber = '" + rdPastelReader2["DocumentNumber"] + "' and documentType in (3,103) and searchtype <> 7";
                                int iPastel = Convert.ToInt32(Connect.getDataCommand(sSql, oPastelConn).ExecuteScalar());
                                dgIntegrity.Rows[iRowID].Cells["clPastel"].Value = iPastel.ToString();

                                if (iLiquid == 0 || iPastel == 0)
                                    sStatus = "ERROR";
                                else
                                    sStatus = "";

                                if (iLiquid > iPastel)
                                {
                                    dgIntegrity.Rows[iRowID].Cells["clStatus"].Style.BackColor = Color.Red;
                                }
                                else if (iLiquid < iPastel)
                                {
                                    dgIntegrity.Rows[iRowID].Cells["clStatus"].Style.BackColor = Color.Orange;
                                }
                                dgIntegrity.Rows[iRowID].Cells["clStatus"].Value = sStatus;
                            }

                            dgIntegrity.Sort(dgIntegrity.Columns["clSalesOrder"], ListSortDirection.Descending);
                            rdPastelReader2.Close();
                        }
                    }
                }
            }
            Cursor = System.Windows.Forms.Cursors.Default;
        }

      

        private void chkPastelLiquidIntegrity_Click(object sender, EventArgs e)
        {
            Cursor = System.Windows.Forms.Cursors.WaitCursor;
            string sSql = "", sStatus = "";
            dgIntegrity.Rows.Clear();
            using (PsqlConnection oPastelConn = new PsqlConnection(Liquid.Classes.Connect.PastelConnectionString))
            {
                oPastelConn.Open();
                using (PsqlConnection oLiquidConn = new PsqlConnection(Liquid.Classes.Connect.LiquidConnectionString))
                {
                    using (PsqlConnection oLiquidConn2 = new PsqlConnection(Liquid.Classes.Connect.LiquidConnectionString))
                    {
                        oLiquidConn.Open();
                        oLiquidConn2.Open();                        

                        sSql = "Select * from   SOLHL order by header,LinkNum,ItemCode";
                        using (PsqlDataReader rdLiquidReader = Connect.getDataCommand(sSql, oLiquidConn).ExecuteReader())
                        {
                            while (rdLiquidReader.Read())
                            {
                                int iRowID = dgIntegrity.Rows.Add();
                                dgIntegrity.Rows[iRowID].Cells["clSalesOrder"].Value = rdLiquidReader["Header"].ToString();
                                dgIntegrity.Rows[iRowID].Cells["clLiquid"].Value = rdLiquidReader["LinkNum"].ToString();

                                sSql = "select count(*) from HistoryLines where DocumentNumber = '" + rdLiquidReader["Header"] + "' and documentType in (2,102) and LinkNum = " + rdLiquidReader["LinkNum"] + "  and ItemCode = '" + rdLiquidReader["ItemCode"].ToString().Trim() + "'";
                                int iPastel = Convert.ToInt32(Connect.getDataCommand(sSql, oPastelConn).ExecuteScalar());
                                dgIntegrity.Rows[iRowID].Cells["clPastel"].Value = iPastel.ToString();

                                if (iPastel == 0)
                                {
                                    dgIntegrity.Rows[iRowID].Cells["clStatus"].Value = "Error";
                                    dgIntegrity.Rows[iRowID].Cells["clStatus"].Style.BackColor = Color.Red;
                                }
                            }

                            dgIntegrity.Sort(dgIntegrity.Columns["clSalesOrder"], ListSortDirection.Descending);
                            rdLiquidReader.Close();
                        }
                    }
                }
            }
            Cursor = System.Windows.Forms.Cursors.Default;
        }

        private void chkSOIntegrity_Click(object sender, EventArgs e)
        {
            Cursor = System.Windows.Forms.Cursors.WaitCursor;
            string sSql = "", sStatus = "";
            dgIntegrity.Rows.Clear();
            using (PsqlConnection oPastelConn = new PsqlConnection(Liquid.Classes.Connect.PastelConnectionString))
            {
                oPastelConn.Open();
                using (PsqlConnection oLiquidConn = new PsqlConnection(Liquid.Classes.Connect.LiquidConnectionString))
                {
                    using (PsqlConnection oLiquidConn2 = new PsqlConnection(Liquid.Classes.Connect.LiquidConnectionString))
                    {
                        oLiquidConn.Open();
                        oLiquidConn2.Open();
                        sSql = "Select count(*) from SOLHH";
                        lblLiquidOrders.Text = Connect.getDataCommand(sSql, oLiquidConn).ExecuteScalar().ToString();
                        sSql = "Select count(*) from HistoryHeader where documenttype in (102, 2)";
                        lblPastelOrders.Text = Connect.getDataCommand(sSql, oPastelConn).ExecuteScalar().ToString();

                        sSql = "Select * from   SOLHH";
                        using (PsqlDataReader rdLiquidReader = Connect.getDataCommand(sSql, oLiquidConn).ExecuteReader())
                        {
                            while (rdLiquidReader.Read())
                            {
                                int iRowID = dgIntegrity.Rows.Add();
                                dgIntegrity.Rows[iRowID].Cells["clSalesOrder"].Value = rdLiquidReader["DocNumber"].ToString();
                                dgIntegrity.Rows[iRowID].Cells["clCustomer"].Value = rdLiquidReader["CustomerCode"].ToString();
                                sSql = "select count(*) from SOLHL where Header = '" + rdLiquidReader["DocNumber"] + "'";
                                int iLiquid = Convert.ToInt32(Connect.getDataCommand(sSql, oLiquidConn2).ExecuteScalar());
                                dgIntegrity.Rows[iRowID].Cells["clLiquid"].Value = iLiquid.ToString();
                                switch (rdLiquidReader["Status"].ToString())
                                {
                                    case "0":
                                        sStatus = "New";
                                        break;
                                    case "1":
                                        sStatus = "Saved";
                                        break;
                                    case "2":
                                        sStatus = "Partial";
                                        break; ;
                                    case "3":
                                        sStatus = "Closed";
                                        break;
                                }
                                sSql = "select count(*) from HistoryLines where DocumentNumber = '" + rdLiquidReader["DocNumber"] + "' and documentType in (2,102) and searchtype <> 7";
                                int iPastel = Convert.ToInt32(Connect.getDataCommand(sSql, oPastelConn).ExecuteScalar());
                                dgIntegrity.Rows[iRowID].Cells["clPastel"].Value = iPastel.ToString();

                                if (iLiquid > iPastel)
                                {
                                    dgIntegrity.Rows[iRowID].Cells["clStatus"].Style.BackColor = Color.Red;
                                }
                                else if (iLiquid < iPastel)
                                {
                                    dgIntegrity.Rows[iRowID].Cells["clStatus"].Style.BackColor = Color.Orange;
                                }
                                dgIntegrity.Rows[iRowID].Cells["clStatus"].Value = sStatus;

                                if (iLiquid != iPastel)
                                    dgIntegrity.Rows[iRowID].Cells["clitemdescrip"].Value = "Error";
                            }

                            dgIntegrity.Sort(dgIntegrity.Columns["clSalesOrder"], ListSortDirection.Descending);
                            rdLiquidReader.Close();
                        }
                    }
                }
            }
            Cursor = System.Windows.Forms.Cursors.Default;
        }
	}


}