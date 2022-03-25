using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Liquid.Domain;
using Liquid.Repository;
using Solsage_Process_Management_System.Classes;

namespace Solsage_Process_Management_System.Forms
{
    public partial class Integrity_Check : Form
    {
        private List<NonLeaseInvoiceLine> _nonLeaseInvoiceLineLessThanUnitPrice;
        private List<Duplicate> _duplicates;
        private List<SalesLine> _deliveryDateSalesOrder;
        private InvoiceRepository _repo = new InvoiceRepository(Connect.LiquidConnectionString, Connect.PastelConnectionString);
        private SalesOrderRepository _salesOrderRepo = new SalesOrderRepository(Connect.LiquidConnectionString, Connect.PastelConnectionString);

        public Integrity_Check()
        {
            InitializeComponent();
        }
 
        private void btnProcess_Click(object sender, EventArgs e)
        {
            clearGrids();            
            runIntegrityCheck();
        }

        private void bg_DoWork(object sender, DoWorkEventArgs e)
        {
            if(rulesCheckBoxList.GetItemChecked(0))
                populateNonLeasePriceVariationsDataGrid();

            if(rulesCheckBoxList.GetItemChecked(1))
                populateDuplicateInvoicesDataGrid();

            if (rulesCheckBoxList.GetItemChecked(2))
                populateDeliveryDatesDataGrid();
        }

        private void bg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {   
            clearGrids();
            int rowIndex = 1;
            if (rulesCheckBoxList.GetItemChecked(0))
            {
                _nonLeaseInvoiceLineLessThanUnitPrice.ForEach(invoice =>
                {
                    var rowNumber = errorListDatagridView.Rows.Add();
                    errorListDatagridView.Rows[rowNumber].Cells["RowNumber"].Value = rowIndex;
                    errorListDatagridView.Rows[rowNumber].Cells["DocumentNumber"].Value = invoice.DocumentNumber;
                    errorListDatagridView.Rows[rowNumber].Cells["DeliveryDate"].Value = invoice.DeliveryDate.ToString("dd-MM-yy");
                    errorListDatagridView.Rows[rowNumber].Cells["ItemCode"].Value = invoice.ItemCode;
                    errorListDatagridView.Rows[rowNumber].Cells["Price"].Value = invoice.UnitPrice.ToString("N2");
                    errorListDatagridView.Rows[rowNumber].Cells["Discount"].Value = invoice.DiscountPercentage.ToString();
                    errorListDatagridView.Rows[rowNumber].Cells["Total"].Value = invoice.Total.ToString("N2");
                    rowIndex++;
                });
            }

            rowIndex = 1;
            if (rulesCheckBoxList.GetItemChecked(1))
            {
                foreach (var invoice in _duplicates)
                {
                    var rowNumber = duplicateDataGridView.Rows.Add();
                    duplicateDataGridView.Rows[rowNumber].Cells["DuplicateRowNumber"].Value = rowIndex;
                    duplicateDataGridView.Rows[rowNumber].Cells["DuplicateDocumentNumber"].Value = invoice.DocumentNumber;
                    duplicateDataGridView.Rows[rowNumber].DefaultCellStyle.BackColor = Color.LightBlue;

                    duplicateDataGridView.Rows[rowNumber].Cells["DuplicateDocumentDate"].Value = invoice.DocumentDate.ToString("dd-MM-yy");
                    duplicateDataGridView.Rows[rowNumber].Cells["DuplicateOrderNumber"].Value = invoice.OrderNumber;
                    rowIndex++;
                    foreach (var duplicate in invoice.DuplicateDocuments)
                    {
                        var duplicateRow = duplicateDataGridView.Rows.Add();                        
                        duplicateDataGridView.Rows[duplicateRow].Cells["DuplicateDocumentNumber"].Value = duplicate;
                        duplicateDataGridView.Rows[duplicateRow].DefaultCellStyle.BackColor = Color.White;                        
                    }
                    
                }
            }
            dgDeliveryDates.DataSource = _deliveryDateSalesOrder;
            StopBusy();
        }

        private void populateNonLeasePriceVariationsDataGrid()
        {
            _nonLeaseInvoiceLineLessThanUnitPrice = _repo.GetNonLeaseInvoiceLines(dtpFrom.Value, dtpTo.Value, new TotalLessThanUnitPrice());
        }

        private void populateDuplicateInvoicesDataGrid()
        {
            var allDuplicates = _repo.GetAllDuplicates(dtpFrom.Value, dtpTo.Value);
       //     _duplicates = _repo.GetDuplicates(allDuplicates);
        }

        private void populateDeliveryDatesDataGrid()
        {
            _deliveryDateSalesOrder = _salesOrderRepo.GetDeliveryDatesInWrongFormat();
           
        }


        private void StartBusy()
        {
            busyPanel.Visible = true;
            busyGiff.Enabled = true;
        }

        private void StopBusy()
        {
            busyPanel.Visible = false;
            busyGiff.Enabled = false;
        }

        private void errorListDatagridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var selectedRowDocumentNumberErrorListDatagridView = errorListDatagridView.Rows[e.RowIndex].Cells[1].Value.ToString().Trim();

            Documents.Invoices invoiceErrorDocument = new Solsage_Process_Management_System.Documents.Invoices();
            invoiceErrorDocument.MdiParent = this.ParentForm;
            invoiceErrorDocument.Show();
            invoiceErrorDocument.loadInvoice(selectedRowDocumentNumberErrorListDatagridView);
        }

        private void duplicateDatagridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var selectedRowDocumentNumberDuplicateDatagridView = duplicateDataGridView.Rows[e.RowIndex].Cells["DuplicateDocumentNumber"].Value.ToString().Trim();


            Documents.Invoices duplicateInvoiceDocument = new Solsage_Process_Management_System.Documents.Invoices();
            duplicateInvoiceDocument.MdiParent = this.ParentForm;
            duplicateInvoiceDocument.Show();
            duplicateInvoiceDocument.loadInvoice(selectedRowDocumentNumberDuplicateDatagridView);
        }

        private void Integrity_Check_Load(object sender, EventArgs e)
        {
            rulesCheckBoxList.SetItemChecked(0, true);
            rulesCheckBoxList.SetItemChecked(1, true);
            rulesCheckBoxList.SetItemChecked(2, true);
        }

        private void clearGrids()
        {
            errorListDatagridView.Rows.Clear();
            duplicateDataGridView.Rows.Clear();
            dgDeliveryDates.DataSource = null;
        }
        

        private void runIntegrityCheck()
        {
            StartBusy();
            var backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += new DoWorkEventHandler(bg_DoWork);
            backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bg_RunWorkerCompleted);
            backgroundWorker.RunWorkerAsync();
        }

      
       
        

        
    }
}
