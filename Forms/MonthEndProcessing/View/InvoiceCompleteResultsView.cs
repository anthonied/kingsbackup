using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Liquid.Domain;
using Liquid.Forms;

namespace Liquid.Forms.MonthEndProcessing.View
{
    public partial class InvoiceCompleteResultsView : Form
    {
        private readonly int _consolidatedInvoiceCount;
        private readonly int _individualInvoiceCount;
        private readonly int _salesOrderCount;
        private readonly decimal _totalInvoiceAmount;
        private readonly string _filter;
        private readonly  int _individualSalesorderCount;
        private readonly  int _consolidatedSalesorderCount;
        private readonly decimal _totalIndividualInvoiceAmount;
        private readonly decimal _totalConsolidatedInvoiceAmount;

        public InvoiceCompleteResultsView(BulkInvoiceResult bulkInvoiceResult)
        {
            InitializeComponent();
            dgResults.DefaultCellStyle.SelectionBackColor = dgResults.DefaultCellStyle.BackColor;
            dgResults.DefaultCellStyle.SelectionForeColor = dgResults.DefaultCellStyle.ForeColor;
            _consolidatedSalesorderCount = bulkInvoiceResult.ConsolidatedSalesOrderCount;
            _individualSalesorderCount = bulkInvoiceResult.IndividualSalesOrderCount;
            _filter = bulkInvoiceResult.Filter;
            _salesOrderCount = bulkInvoiceResult.SalesOrderCount;
            _consolidatedInvoiceCount = bulkInvoiceResult.ConsolidatedInvoiceCount;
            _individualInvoiceCount = bulkInvoiceResult.IndividualInvoiceCount;
            _totalInvoiceAmount = bulkInvoiceResult.TotalInvoiceAmount;
            _totalIndividualInvoiceAmount = bulkInvoiceResult.TotalIndividualInvoiceAmount;
            _totalConsolidatedInvoiceAmount = bulkInvoiceResult.TotalConsolidatedInvoiceAmount;

            updateResults();
        }

        private void updateResults()
        {
            ResultLabel.Text = _filter;
            var results = buildResultList();
            dgResults.DataSource = results;
        }

        private List<BuldINvoiceResultGridEntry> buildResultList()
        {
           return new List<BuldINvoiceResultGridEntry>
           {
               new BuldINvoiceResultGridEntry
               {
                   Header = "Total Salesorders to invoice",
                   SalesorderCount = _salesOrderCount.ToString(),
                   InvoiceCount = "-",
                   Value = ""
               },
               new BuldINvoiceResultGridEntry
               {
                   Header = "Individual",
                   SalesorderCount = _individualSalesorderCount.ToString(),
                   InvoiceCount = _individualInvoiceCount.ToString(),
                   Value = _totalIndividualInvoiceAmount.ToString("N2")
               },
               new BuldINvoiceResultGridEntry
               {
                   Header = "Consolidated",
                   SalesorderCount = _consolidatedSalesorderCount.ToString(),
                   InvoiceCount = _consolidatedInvoiceCount.ToString(),
                   Value = _totalConsolidatedInvoiceAmount.ToString("N2")
               },
               new BuldINvoiceResultGridEntry
               {
                   Header = "Total",
                   SalesorderCount = (_individualSalesorderCount + _consolidatedSalesorderCount).ToString(),
                   InvoiceCount = (_individualInvoiceCount + _consolidatedInvoiceCount).ToString(),
                   Value = _totalInvoiceAmount.ToString("N2")
               }
           };
        }
    }

    internal class BuldINvoiceResultGridEntry
    {
        public string Header { get; set; }
        public string SalesorderCount { get; set; }
        public string InvoiceCount { get; set; }
        public string Value { get; set; }
    }
}