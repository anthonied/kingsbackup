using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Liquid.Domain;
using Liquid.Domain.Enums;
using Liquid.Domain.Services;
using Liquid.Repository;
using Liquid.Classes;

namespace Liquid.Forms
{
    public partial class DuplicateInvoices : Form
    {
        public DuplicateInvoices()
        {
            InitializeComponent();
        }


        private void cmdFilter_Click(object sender, System.EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            var flatInvoiceRepository = new FlatInvoiceRepository(Connect.LiquidConnectionString, Connect.PastelConnectionString);
            var duplicateService = new DuplicateInvoiceDomainService(flatInvoiceRepository);
            var duplicateSets = duplicateService.GetDuplicatesByMonth(dtInvoiceMonth.Value).OrderBy(set=> set.FlatInvoices.First().CustomerCode);

            var definiteDuplicates = duplicateSets.Where(set => set.DuplicateStatus == DuplicateStatus.Definite).ToList();
            var probableDuplicates = duplicateSets.Where(set => set.DuplicateStatus == DuplicateStatus.Probable).ToList();

            buildDataGrid(dgDefiniteDuplicates, definiteDuplicates); 
            buildDataGrid(dgPropableDuplicate, probableDuplicates);
            Cursor = Cursors.Default;

            dgDefiniteDuplicates.Enabled = true;
            dgPropableDuplicate.Enabled = true;
        }

        private void buildDataGrid(DataGridView dataGridView, List<DuplicateInvoiceSet> definiteDuplicates)
        {

            definiteDuplicates.ForEach(set =>
            {
                var row = new string[] { set.FlatInvoices.First().CustomerCode, set.FlatInvoices.Count.ToString(), string.Join(";", set.FlatInvoices.Select(x=>x.InvoiceNumber)) };
                dataGridView.Rows.Add(row);
            });

        }


        private void dgDefiniteDuplicates_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var rowIndex = e.RowIndex;
            var currentCellValue = dgDefiniteDuplicates.Rows[rowIndex].Cells[2].Value.ToString();
            splitInvoiceNumberAndGenerateReport(currentCellValue);
        }

        private void DuplicateInvoices_Load(object sender, System.EventArgs e)
        {
            dgDefiniteDuplicates.Enabled = false;
            dgPropableDuplicate.Enabled = false;
        }

        private void splitInvoiceNumberAndGenerateReport(string invoicesToSplit)
        {
            string[] invoices = invoicesToSplit.Split(';');
            foreach (var invoiceNumber in invoices)
            {
                var reportViewer = new ReportViewer();
                reportViewer.DisplayInvoice(invoiceNumber);
                reportViewer.Show();

            }
        }

        private void dgPropableDuplicate_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var rowIndex = e.RowIndex;
            var currentCellValue = dgPropableDuplicate.Rows[rowIndex].Cells[2].Value.ToString();
            splitInvoiceNumberAndGenerateReport(currentCellValue);
        }
    }
}
