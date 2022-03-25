using System;
using System.Windows.Forms;

namespace Liquid.Documents
{
	public partial class SalesLineInfo : Form
	{
		public string sCode = "", sDescription = "", sLastInvoiceDate = "";
		public DialogResult ShowDialog(string sLineCode, string sLineDescription, string sLineLastInvoiceDate)
		{
			sCode = sLineCode;
			sDescription = sLineDescription;
			sLastInvoiceDate = sLineLastInvoiceDate;
			return this.ShowDialog();
		}
		public SalesLineInfo()
		{
			InitializeComponent();
		}

		private void SalesLineInfo_Load(object sender, EventArgs e)
		{
			lblCode.Text = sCode;
			lblDescription.Text = sDescription;
			lblLastInvoice.Text = sLastInvoiceDate;
		}

	}
}