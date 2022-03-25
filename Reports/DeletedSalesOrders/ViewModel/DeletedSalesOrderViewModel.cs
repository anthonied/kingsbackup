using System.Collections.Generic;
using Liquid.Classes;
using Liquid.Domain;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using Liquid.Reports.DeletedSalesOrders.CrystalReports;
using Liquid.Reports.DeletedSalesOrders.Dataset;
using System.Data;

namespace Liquid.Reports.DeletedSalesOrders.ViewModel
{
    public class DeletedSalesOrderViewModel
    {
        Functions Functions = new Functions();
        public List<DeletedSalesOrderData> AllDeletedData = new List<DeletedSalesOrderData>();

        public void GetAllDeletedSalesOrders()
        {
            AllDeletedData = Functions.GetAllDeletedSalesOrders();
        }

        public void GetAllDeletedSalesOrders(string SalesOrderNumber)
        {
            AllDeletedData = Functions.GetAllDeletedSalesOrders(SalesOrderNumber);
        }

        public void Print(DataGridView dgDeletedSalesOrders)
        {
            
            ReportClass reportDeletedSalesOrders = null;
            reportDeletedSalesOrders = new crDeletedSalesOrders();
            DataTable dtDSO = new dsDeletedSalesOrders.dtDeletedSalesOrdersDataTable();
            foreach (DataGridViewRow dgvr in dgDeletedSalesOrders.Rows)
            {
                DataRow drRow = dtDSO.NewRow();
                drRow["SalesOrderNumber"] = dgvr.Cells["SalesOrderNumber"].Value;
                drRow["InvoiceNumber"] = dgvr.Cells["InvoiceNumber"].Value;
                if (dgvr.Cells["Date"].Value != "")
                    drRow["SalesOrderDate"] = dgvr.Cells["Date"].Value;                
                dtDSO.Rows.Add(drRow);
            }
            reportDeletedSalesOrders.SetDataSource((DataTable)dtDSO);

            reportDeletedSalesOrders.PrintOptions.PrinterName = Global.sDefaultDocPrinter;
            reportDeletedSalesOrders.PrintToPrinter(1, false, 0, 0);	       
        }

    }
}
