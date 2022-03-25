using Liquid.Domain;
using Liquid.Repository;
using System.Collections.Generic;
using System.Windows.Forms;
using Liquid.Models;
using System.Linq;
using System;
using System.Drawing;
using Liquid.Controls;

namespace Liquid.Forms.MonthEndProcessing.View
{
    public partial class OffHireManager : Form
    {
        private MonthEndFilter _filter;
        private List<Salesorder> _salesOrders = new List<Salesorder>();
        private List<OffHireManageModel> _completeGridViewModel;
        private DateTime _invoiceEndDate;
        private DateTime _invoiceStartDate;

        public OffHireManager(MonthEndFilter filter)
        {
            _filter = filter;
            InitializeComponent();
            txtCustomer.Text = _filter.CustomerFrom;
            txtCustomerTo.Text = _filter.CustomerTo;
            txtDocDateTo.Text = _filter.DocDateTo;
            txtCustomerPrefix.Text = _filter.CustomerPrefix;
            

            _invoiceEndDate = filter.InvoiceDate;
            _invoiceStartDate = new DateTime(filter.InvoiceDate.Year, filter.InvoiceDate.Month, 1);

            txtInvoiceDateFrom.Text = _invoiceStartDate.ToString("yyyy-MM-dd");
            txtInvoiceDateTo.Text = _invoiceEndDate.ToString("yyyy-MM-dd");
        }

        private void OffHireManager_Load(object sender, System.EventArgs e)
        {
            loadGrid();
        }

        private void loadGrid()
        {
            var salesOrders = new SalesOrderRepository().GetSalesOrdersByFilter(_filter);

            salesOrders.RemoveAll(order => string.IsNullOrEmpty(order.Header.DocumentNumber));
            _salesOrders = salesOrders;

            _completeGridViewModel = salesOrders.Select(so => OffHireManageModel.FromDomain(so, _invoiceStartDate, _invoiceEndDate)).ToList();

            dgSalesOrder.DataSource = _completeGridViewModel;

            paintDataGrid();
        }

        private void paintDataGrid()
        {
            foreach (DataGridViewRow row in dgSalesOrder.Rows)
            {
                var salesOrder =
                    _salesOrders.Find(
                        order => order.Header.DocumentNumber == row.Cells["clSalesOrderNum"].Value.ToString());

                
                    if (salesOrder.HasActiveCustomOffHire)
                    {
                        row.DefaultCellStyle.BackColor = Color.LightGreen;
                    }

                var btnCell = (DataGridViewLinkCell)row.Cells["clCancel"];
                btnCell.Value = "Remove";
                if( salesOrder.OffHireStartDate > new DateTime(1970, 1, 1))
                {
                    btnCell.Value = "Remove";
                }
                else
                {
                    btnCell.Value = "";
                    btnCell.ReadOnly = true;                   
                }

            }
        }

        private void dgSalesOrder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var dataGridViewColumn = dgSalesOrder.Columns[e.ColumnIndex];

            if (dataGridViewColumn == dgSalesOrder.Columns["clCancel"])
            {
                var frmConfirm = new Confirm("This will permanently remove the current dates.  Are you sure?");
                if (frmConfirm.ShowDialog() == DialogResult.OK)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    var salesOrder =
                      _salesOrders.Find(
                          order => order.Header.DocumentNumber == dgSalesOrder.Rows[e.RowIndex].Cells["clSalesOrderNum"].Value.ToString());
                    new SalesOrderRepository().RemoveOffHireDates(salesOrder.Header.DocumentNumber);
                    loadGrid();
                    Cursor.Current = Cursors.Default;
                }
            }
        }

        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            var countChecked = _completeGridViewModel.Count(order => order.Selected);

            foreach (DataGridViewRow row in dgSalesOrder.Rows)
            {
                ((DataGridViewCheckBoxCell)row.Cells["clSelected"]).Value = chkSelectAll.Checked;
            }

        }

        private void cmdRemoveAll_Click(object sender, EventArgs e)
        {
            var selectedCount = _completeGridViewModel.Count(row => row.Selected);
            var toRemove = _completeGridViewModel.FindAll(row => row.Selected).FindAll(selected => selected.OffHireStartDate != "");
            var frmConfirm = new Confirm($"This will permanently remove {toRemove.Count} of the {selectedCount} selected current dates rows.  Are you sure?");
            if (frmConfirm.ShowDialog() == DialogResult.OK)
            {
                var repo = new SalesOrderRepository();
                Cursor.Current = Cursors.WaitCursor;
                toRemove.ForEach(tempOffhire => repo.RemoveOffHireDates(tempOffhire.DocumentNumber));
                loadGrid();
                Cursor.Current = Cursors.Default;
            }
        }

        private void cmdOffHireAll_Click(object sender, EventArgs e)
        {
            var toOffHire = _completeGridViewModel.FindAll(row => row.Selected);
            var frmConfirm = new Confirm($"This will update {toOffHire.Count} order(s).  Are you sure?");
            if(toOffHire.Count == 0)
            {
                MessageBox.Show("No orders selected to update.", "Not selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (toOffHire.Count == 1 || frmConfirm.ShowDialog() == DialogResult.OK)
            {
                var repo = new SalesOrderRepository();
                Cursor.Current = Cursors.WaitCursor;
                toOffHire.ForEach(offHire =>
                {
                    var salesOrder = _salesOrders.Find(order => order.Header.DocumentNumber == offHire.DocumentNumber);
                    salesOrder.OffHireStartDate = dtOffhireStart.Value;
                    salesOrder.OffHireEndDate = dtOffhireEnd.Value;
                    repo.UpdateSalesOrderOffHireDates(salesOrder);
                });

                loadGrid();
                Cursor.Current = Cursors.Default;

            }
        }
    }
}
