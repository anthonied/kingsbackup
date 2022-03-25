using System;
using System.Windows.Forms;
using Liquid.Classes;

namespace Liquid.Reports
{
    public partial class PrintInvoicesReport : Form
    {
        public PrintInvoicesReport()
        {
            InitializeComponent();
        }

        private void PrintInvoicesReport_Load(object sender, EventArgs e)
        {

        }

        public DialogResult ShowDialog(string sInvoiceFrom, string sInvoiceTo, string sCustomerFrom, string sCustomerTo, string sInvoiceDateFrom, string sInvoiceDateTo)
        {
            crystalReportViewer1.ReportSource = Functions.getInvoiceReport(sInvoiceFrom, sInvoiceTo, sInvoiceDateFrom, sInvoiceDateTo, sCustomerFrom, sCustomerTo, "BulkPrint",Global.sLogedInUserCode);
            return this.ShowDialog();
        }
       
    }
}