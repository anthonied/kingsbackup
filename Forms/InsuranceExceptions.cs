using Liquid.Domain;
using Liquid.Domain.Services;
using Liquid.Repository;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Liquid.Classes;

namespace Liquid.Forms
{
    public partial class InsuranceExceptions : Form
    {
        public InsuranceExceptions()
        {
            InitializeComponent();
        }

        public static string LiquidConnectionString = Connect.LiquidConnectionString;
        public static string PastelConnectionString = Connect.PastelConnectionString;

        private void InsuranceExceptions_Load(object sender, System.EventArgs e)
        {
            var salesOrderRepo = new SalesOrderRepository(LiquidConnectionString, PastelConnectionString);
            var inventoryRepo = new InventoryRepository(LiquidConnectionString, PastelConnectionString);
            var salesOrderExceptionService = new SalesOrderExceptionService(inventoryRepo, salesOrderRepo).ZeroInsuranceLines();
            buildDataGrid(dgInsurance, salesOrderExceptionService);
        }

        private void buildDataGrid(DataGridView dataGridView, List<Salesorder> insurance)
        {
            insurance.ForEach(set =>
            {
                var row = new string[] { set.Header.DocumentNumber, set.Header.Customer.CustomerCode};
                dataGridView.Rows.Add(row);
            });
        }

        private void dgInsurance_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var rowIndex = e.RowIndex;
            if (rowIndex < 0)
                return;
            switch (e.ColumnIndex)
            {
                case 0:
                    openSalesOrderInWindow(dgInsurance.Rows[rowIndex].Cells["clDocumentNumber"].Value.ToString());
                    break;
            }
        }

        private void openSalesOrderInWindow(string salesOrderNumber)
        {
            var frmSales = new Documents.SalesOrder();
            frmSales.ShowDialog(salesOrderNumber, Convert.ToDateTime(DateTime.Now));
        }
    }
}
