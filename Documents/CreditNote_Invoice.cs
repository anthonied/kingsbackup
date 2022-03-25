using System;
using System.Windows.Forms;
using Pervasive.Data.SqlClient;
using Liquid.Classes;

namespace Liquid.Documents
{
	public partial class CreditNote_Invoice : Form
	{
		public string sInvoiceNumber = "";
		public SalesOrder soParent;

		public CreditNote_Invoice()
		{
			InitializeComponent();
		}
		public DialogResult ShowDialog(string sInvoice, SalesOrder soSource)
		{
			sInvoiceNumber = sInvoice;
			soParent = soSource;
			return (this.ShowDialog());
		}

		private void CreditNote_Invoice_Load(object sender, EventArgs e)
		{
			this.Text += sInvoiceNumber;
			using (PsqlConnection oConn = new PsqlConnection(Liquid.Classes.Connect.PastelConnectionString))
			{
				oConn.Open();
				string sSql = "SELECT DocumentNumber, DocumentDate from HistoryHeader where OrderNumber = '" + sInvoiceNumber + "'";
				PsqlDataReader rdReader = Liquid.Classes.Connect.getDataCommand(sSql, oConn).ExecuteReader();
				int iRowCount = 1;
				while(rdReader.Read())
				{
					dgCreditNotes.Rows.Add();
					dgCreditNotes.Rows[dgCreditNotes.Rows.Count - 1].Cells[0].Value = iRowCount.ToString();
					dgCreditNotes.Rows[dgCreditNotes.Rows.Count - 1].Cells[1].Value = rdReader["DocumentNumber"].ToString();
					dgCreditNotes.Rows[dgCreditNotes.Rows.Count - 1].Cells[2].Value = Convert.ToDateTime(rdReader["DocumentDate"]).ToString("dd/MM/yyyy");
				}
				rdReader.Close();
				oConn.Dispose();
				dgCreditNotes.ClearSelection();
			}
		}

		private void dgCreditNotes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			Cursor = System.Windows.Forms.Cursors.WaitCursor;
			using (Liquid.Documents.CreditNote reportCredit = new CreditNote())
			{
				using (PrintInvoice frmPrint = new PrintInvoice())
				{
					frmPrint.crystalReportViewer1.SelectionFormula = "{HistoryHeader.DocumentNumber} = \"" + dgCreditNotes.Rows[e.RowIndex].Cells[1].Value + "\"";
					
					foreach (CrystalDecisions.CrystalReports.Engine.FormulaFieldDefinition forReport in reportCredit.DataDefinition.FormulaFields)
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
								forReport.Text = "";
								break;
							case "{@sInvoiceMessage02}":
								forReport.Text = "'CREDIT NOTE AUTHORITY:__________________________'";
								break;
						}
					}					
					frmPrint.crystalReportViewer1.ReportSource = reportCredit;										
					frmPrint.ShowDialog();
				}				
			}
			Cursor = System.Windows.Forms.Cursors.Default;
		}

	}
}