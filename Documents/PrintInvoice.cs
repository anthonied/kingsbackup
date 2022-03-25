using System;
using System.Windows.Forms;

namespace Liquid.Documents
{
	public partial class PrintInvoice : Form
	{
		public PrintInvoice()
		{
			InitializeComponent();
		}

		private void crystalReportViewer1_Load(object sender, EventArgs e)
		{
		
		}

		public void printThisDocument()
		{
			crystalReportViewer1.PrintReport();
			
			this.Close();
		}
	}
}