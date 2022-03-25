using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Liquid.Classes;

namespace Liquid.Forms
{
    public partial class ReportViewer : Form
    {
        
        public ReportViewer()
        {
            InitializeComponent();
        }


        private void ReportViewer_Load(object sender, EventArgs e)
        {
            
        }

        public void DisplayInvoice(string invoicenum)
        {
            Cursor = Cursors.WaitCursor;
            var rptInvoice = Functions.getInvoiceReport(invoicenum, "", "", "", "", "", "NormalPrint", Global.sLogedInUserCode);
            crystalReportViewer1.ReportSource = rptInvoice;
            Cursor = Cursors.Default;
        }


    }
}
