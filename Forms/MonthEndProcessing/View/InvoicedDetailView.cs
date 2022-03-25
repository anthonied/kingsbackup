using Liquid.Classes;
using Liquid.Domain;
using Liquid.Repository;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Liquid.Forms.MonthEndProcessing.View
{
    public partial class InvoicedDetailView : Form
    {
        public InvoicedDetailView()
        {
            InitializeComponent();
        }

        private void cmdFilter_Click(object sender, EventArgs e)
        {
            using (
                var invoiceHeaderRepo = new InvoiceHeaderRepository(Connect.LiquidConnectionString,
                    Connect.PastelConnectionString))
            {
                var invoiceHeaders = invoiceHeaderRepo.GetInvoicesByDateAndCustomerLetter(selCustLetter.Text, dtInvoiceMonth.Value);
                if (invoiceHeaders.Count == 0)
                    MessageBox.Show("No results", "Nothing for this dates", MessageBoxButtons.OK);

                var order = invoiceHeaders.OrderBy(x => x.TotalInclVat);
                var model = order.Select(InvoiceSummaryModel.FromDomain).ToList();

                var zeroInvoiceModel = model.Where(x => x.Amount == "0.00").ToList();
                dgInvoice.DataSource = model;
                tabPage1.Text = $"All Invoices [{ model.Count}]";
                dgZeroInvoice.DataSource = zeroInvoiceModel;
                tabPage2.Text = $"Zero Invoices [{zeroInvoiceModel.Count}]";
            }
        }

        private void dgInvoice_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var rowIndex = e.RowIndex;
            if (rowIndex < 0)
                return;
            switch (e.ColumnIndex)
            {
                case 4://indexes is rendering funny
                    var invoiceNumber = dgInvoice.Rows[rowIndex].Cells["clInvoiceNumber"].Value.ToString();
                    var reportViewer = new ReportViewer();
                    reportViewer.DisplayInvoice(invoiceNumber);
                    reportViewer.ShowDialog();
                    break;
                case 1:
                    openSalesOrderInWindow(dgInvoice.Rows[rowIndex].Cells["clDeliveryNote"].Value.ToString());
                    break;
            }
           
        }

        private void openSalesOrderInWindow(string salesOrderNumber)
        {
            var frmSales = new Documents.SalesOrder();
            frmSales.ShowDialog(salesOrderNumber, Convert.ToDateTime(dtInvoiceMonth.Value));
        }
    }

    public class InvoiceSummaryModel
    {
        public string CustomerCode { get; set; }
        public string DeliveryNoteNumber { get; set; }
        public string Amount { get; set; }
        public string InvoiceNumber { get; set; }

        public static InvoiceSummaryModel FromDomain(InvoiceHeader invoiceHeader)
        {
            return new InvoiceSummaryModel
            {
                InvoiceNumber = invoiceHeader.DocumentNumber,
                CustomerCode = invoiceHeader.Customer.CustomerCode,
                DeliveryNoteNumber = invoiceHeader.SalesOrderNumber,
                Amount = invoiceHeader.TotalInclVat.ToString("N2")
            };
        }
    }
}