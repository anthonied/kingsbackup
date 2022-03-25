using Liquid.Domain;
using Liquid.Domain.Services;
using Liquid.Repository;
using Liquid.Services;
using Pervasive.Data.SqlClient;
using Liquid.Classes;
using Liquid.Forms.MonthEndProcessing.View;
using Liquid.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Liquid.Domain.Enums;
using Liquid.Services.ApiServices;

namespace Liquid.Forms
{
    public partial class MonthEndProcessings : Form
    {
        private List<Salesorder> _openSalesOrders = new List<Salesorder>();
        private int _activeRow;
        private string _contextDeliveryNoteItemNumber = "";

        private static readonly log4net.ILog _log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private List<DateTime> _dates = new List<DateTime>();

        private readonly SalesOrderRepository _salesOrderRepo = new SalesOrderRepository(
            Connect.LiquidConnectionString, Connect.PastelConnectionString);

        private readonly DataGridViewCellStyle _readOnlyStyle = new DataGridViewCellStyle();
        private readonly DataGridViewCellStyle _notReadOnlyStyle = new DataGridViewCellStyle();
        private readonly DataGridViewCellStyle _savedOrderStyle = new DataGridViewCellStyle();
        private readonly DataGridViewCellStyle _partialInvoicedStyle = new DataGridViewCellStyle();
        private readonly DataGridViewCellStyle _errorcodeStyle = new DataGridViewCellStyle();
        private readonly DataGridViewCellStyle _invoicedStyle = new DataGridViewCellStyle();
        private readonly DataGridViewLinkColumn _salesOrderNum = new DataGridViewLinkColumn();
        private readonly MonthEndFilter _filter = new MonthEndFilter();
        private List<BulkInvoiceGridOrderModel> _completeGridViewModel;
        public bool IsValidContract = false;
        private string _selectedSalesOrderByOderNumber;

        public MonthEndProcessings()
        {
            InitializeComponent();
        }

        private void MonthEndProcessings_Load(object sender, EventArgs e)
        {
            setFormStyle();
            loadPeriodEnd();
            _dates = getDatesForMonth();
        }

        private void setFormStyle()
        {
            dgOpenSalesOrder.AutoGenerateColumns = false;
            _readOnlyStyle.BackColor = Color.LightGray;
            _notReadOnlyStyle.BackColor = Color.White;
            _notReadOnlyStyle.ForeColor = Color.Black;
            _savedOrderStyle.BackColor = Color.DarkCyan;
            _savedOrderStyle.ForeColor = Color.White;
            _partialInvoicedStyle.BackColor = Color.Orange;
            _partialInvoicedStyle.ForeColor = Color.White;
            _errorcodeStyle.BackColor = Color.Red;
            _invoicedStyle.ForeColor = Color.White;
            _invoicedStyle.BackColor = Color.Indigo;
        }

        public DialogResult ShowDialog(string sOrderNumber)
        {
            _selectedSalesOrderByOderNumber = sOrderNumber;
            loadDataGridDetail();
            return ShowDialog();
        }

        private void paintOffHireItems(DataGridViewRow dgRow, Salesorder salesorder)
        {
            var startdate = salesorder.OffHireStartDate;
            var datesInThisMonth =
                _dates.Where(x => x.Date.ToString("yyyy-MM-dd") == startdate.ToString("yyyy-MM-dd")).ToList();
            var futureDate = _dates.Where(x => x.Date < startdate.Date).ToList();
            var style = new DataGridViewCellStyle {ForeColor = Color.Black};
            dgRow.Cells["clSalesOrderStatus"].Value = "Temp Offhire";
            dgRow.Cells["clSalesOrderStatus"].ToolTipText = string.Format("{0:yyyy-MM-dd} - {1:yyyy-MM-dd}",
                salesorder.OffHireStartDate, salesorder.OffHireEndDate);
            if (datesInThisMonth.Count > 0)
            {
                style.BackColor = Color.Lime;
                dgRow.Cells["clSalesOrderStatus"].Style = style;
            }
            else if (futureDate.Count > 0)
            {
                style.BackColor = Color.LimeGreen;
                 dgRow.Cells["clSalesOrderStatus"].Style = style;
            }
        }

        private void loadDataGridDetail()
        {
            _dates = getDatesForMonth();
            _openSalesOrders = new List<Salesorder>();
            initFilter();

            var salesOrders = new SalesOrderRepository().GetSalesOrdersByFilter(_filter);

            salesOrders.RemoveAll(order => string.IsNullOrEmpty(order.Header.DocumentNumber));
            _openSalesOrders = salesOrders;

            _completeGridViewModel = salesOrders.Select(BulkInvoiceGridOrderModel.FromDomain).ToList();
            reloadViewModelFilters();

            if (IsValidContract)
                //todo: fix grammer error if i may
                MessageBox.Show("Please be advised that there are contracts in this batch that is about to expire.",
                    "Contract Expiry Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private List<BulkInvoiceGridOrderModel> filterLockedItems(List<BulkInvoiceGridOrderModel> gridViewModel)
        {
            if (gridViewModel == null) return null;
            return chkViewLockedItems.Checked
                ? gridViewModel
                : gridViewModel.Where(item => item.LockedStatus != 1).ToList();
        }

        private List<BulkInvoiceGridOrderModel> filterAllreadyInvoicedItems(List<BulkInvoiceGridOrderModel> gridViewModel)
        {
            if (gridViewModel == null) return null;
            return chkInvoicedThisPeriod.Checked
                ? gridViewModel
                : gridViewModel.Where(item => !isOrderAllreadyInvoiced(item.LastInvoiceDate.ToDateTimeFromyyyyMMddDashDate())).ToList();
        }

        private void verifyAndAddVisibleElementsToDatagrid()
        {
            foreach (DataGridViewRow dgRow in dgOpenSalesOrder.Rows)
            {
                var salesOrder =
                    _openSalesOrders.Find(
                        order => order.Header.DocumentNumber == dgRow.Cells["clSalesOrderNum"].Value.ToString());

                try
                {

                    if (isRowLocked(dgRow))
                    {
                        dgRow.DefaultCellStyle.BackColor = Color.Black;
                        dgRow.DefaultCellStyle.ForeColor = Color.White;

                        dgRow.Cells["chkInvoice"].ReadOnly = true;
                        dgRow.Cells["chkFutureToActive"].ReadOnly = true;
                        dgRow.Cells["chkActiveToStanding"].ReadOnly = true;
                        dgRow.Cells["chkOffhire"].ReadOnly = true;
                    }
                    switch (dgRow.Cells["clSalesOrderStatus"].Value.ToString())
                    {
                        case "SAVED":
                            dgRow.Cells["clSalesOrderStatus"].Style = _savedOrderStyle;
                            break;

                        case "PARTIAL":
                            dgRow.Cells["clSalesOrderStatus"].Style = _partialInvoicedStyle;
                            break;
                    }

                    if (isOrderAllreadyInvoiced(dgRow.Cells["clLastInvoiceDate"].Value.ToString().ToDateTimeFromyyyyMMddDashDate()))
                    {
                        dgRow.Cells["chkInvoice"].ReadOnly = true;
                        dgRow.Cells["chkInvoice"].Value = false;
                        dgRow.DefaultCellStyle = _invoicedStyle;
                        ((DataGridViewLinkCell) (dgRow.Cells["clSalesOrderNum"])).LinkColor = Color.White;
                    }
                    else
                    {
                        dgRow.Cells["chkInvoice"].ReadOnly = false;
                        dgRow.DefaultCellStyle = _notReadOnlyStyle;
                        ((DataGridViewLinkCell)(dgRow.Cells["clSalesOrderNum"])).LinkColor = Color.Black;
                    }

                    if (salesOrder.HasActiveCustomOffHire)
                    {
                        paintOffHireItems(dgRow, salesOrder);
                    }
                }
                catch (Exception ex)
                {
                    _log.Error("Exception populating datagrid: ", ex);
                }

            }
        }

        private static bool isRowLocked(DataGridViewRow row)
        {
            return row.Cells["LockedStatus"].Value.ToString() == "1";
        }

        private bool isOrderAllreadyInvoiced(DateTime lastInvoiceDate)
        {
            return lastInvoiceDate >= dtInvoiceDate.Value;
        }

        private void initFilter()
        {
            _filter.CustomerFrom = txtCustomer.Text;
            _filter.CustomerTo = txtCustomerTo.Text;
            _filter.OrderNumber = _selectedSalesOrderByOderNumber ?? "";
            _filter.DocDateTo = dtDocDateTo.Text;
            _filter.CustomerPrefix = selCustLetter.Text;
            _filter.InvoiceUpToDate = Convert.ToDateTime(dtInvoiceUpToDate.Value.ToString());
            _filter.InvoiceDate = Convert.ToDateTime(dtInvoiceDate.Value.ToString());
        }

        private void cmdCustomer_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            using (var frmCustomerZoom = new Finder.CustomerZoom())
            {
                if (frmCustomerZoom.ShowDialog() == DialogResult.OK)
                {
                    if (frmCustomerZoom.CustomerCode != "")
                    {
                        txtCustomer.Text = frmCustomerZoom.CustomerCode;
                    }
                }
                Cursor = Cursors.Default;
            }
        }

        private void cmdFilter_Click(object sender, EventArgs e)
        {
            chkAllInvoice.Checked = false;
            progressBar1.Value = 0;
            progressBarText.Text = "";
            Cursor = Cursors.WaitCursor;
            loadDataGridDetail();
            Cursor = Cursors.Default;
            chkAllInvoice.Checked = true;
            cmdGenerateInvoices.Enabled = true;
        }

        private void chkAllInvoice_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAllInvoice.Checked)
            {
                foreach (DataGridViewRow dgRow in dgOpenSalesOrder.Rows)
                {
                    if (canInvoice(dgRow))
                    {
                        dgRow.Cells["chkInvoice"].Value = true;
                    }
                }
            }
            else
            {
                foreach (DataGridViewRow dgRow in dgOpenSalesOrder.Rows)
                {
                    dgRow.Cells["chkInvoice"].Value = false;
                }
            }
        }

        private bool canInvoice(DataGridViewRow row)
        {
            return !isOrderAllreadyInvoiced(row.Cells["clLastInvoiceDate"].Value.ToString().ToDateTimeFromyyyyMMddDashDate()) && !isRowLocked(row);
        }

        private void dgOpenSalesOrder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var dataGridViewColumn = dgOpenSalesOrder.Columns[e.ColumnIndex];

            if (dataGridViewColumn == dgOpenSalesOrder.Columns[0])
            {
                openSalesOrderInWindow(e);
            }
        }

        private void dgOpenSalesOrder_CellValueChanged_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgOpenSalesOrder.Columns[8].Index && e.RowIndex != -1)
            {
                updateSelectedSalesOrdersCount();
            }
        }

        private void dgOpenSalesOrder_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == dgOpenSalesOrder.Columns[8].Index && e.RowIndex != -1)
            {
                dgOpenSalesOrder.EndEdit();
            }
        }

        private void updateSelectedSalesOrdersCount()
        {
            var count = 0;

            foreach (DataGridViewRow dgRow in dgOpenSalesOrder.Rows)
            {
                if (dgRow.DefaultCellStyle.BackColor == Color.Black) continue;

                var cell = dgRow.Cells["chkInvoice"] as DataGridViewCheckBoxCell;
                if (cell != null && Convert.ToBoolean(cell.Value))
                {
                    count++;
                }
            }

            lblSelectCount.Text = count > 0 ? count.ToString() : "";
        }

        private void openSalesOrderInWindow(DataGridViewCellEventArgs e)
        {
            string sSalesOrderNumber = dgOpenSalesOrder.Rows[e.RowIndex].Cells["clSalesOrderNum"].Value.ToString();
            var frmSales = new Documents.SalesOrder();
            frmSales.bPermanentMonthEnd = true;
            frmSales.ShowDialog(sSalesOrderNumber, Convert.ToDateTime(dtInvoiceDate.Value));
            using (PsqlConnection oLiquidConn = new PsqlConnection(Connect.LiquidConnectionString))
            {
                oLiquidConn.Open();
                string sSql =
                    "select (Select Max(LastInvoiceDate)  from SOLHL where Header = H.DocNumber ) as LastInvoice, Status  from SOLHH h where DocNumber = '" +
                    dgOpenSalesOrder.Rows[e.RowIndex].Cells["clSalesOrderNum"].Value + "'";
                using (PsqlDataReader rdReader = Connect.getDataCommand(sSql, oLiquidConn).ExecuteReader())
                {
                    while (rdReader.Read())
                    {
                        if (rdReader["Status"].ToString() == "1")
                        {
                            dgOpenSalesOrder.Rows[e.RowIndex].Cells["clSalesOrderStatus"].Value = "SAVED";
                            dgOpenSalesOrder.Rows[e.RowIndex].Cells["clSalesOrderStatus"].Style = _savedOrderStyle;
                        }
                        else if (rdReader["Status"].ToString() == "2")
                        {
                            dgOpenSalesOrder.Rows[e.RowIndex].Cells["clSalesOrderStatus"].Value = "PARTIAL";
                            dgOpenSalesOrder.Rows[e.RowIndex].Cells["clSalesOrderStatus"].Style = _partialInvoicedStyle;
                        }
                        if (rdReader["LastInvoice"].ToString().Length >= 10)
                        {
                            dgOpenSalesOrder.Rows[e.RowIndex].Cells["clLastInvoiceDate"].Value =
                                Convert.ToDateTime(rdReader["LastInvoice"]).ToString("yyyy-MM-dd");
                        }
                    }
                }
                dgOpenSalesOrder.Rows[e.RowIndex].Cells[0].Selected = false;
                if (e.RowIndex + 1 < dgOpenSalesOrder.Rows.Count)
                {
                    dgOpenSalesOrder.Rows[e.RowIndex + 1].Cells[0].Selected = true;
                }
            }
        }

        private void loadPeriodEnd()
        {
            using (var oConn = new PsqlConnection(Connect.PastelConnectionString))
            {
                oConn.Open();

                string sSql = "Select NumberPeriodsThis, PerEndThis01, PerEndThis02, PerEndThis03, PerEndThis04, ";
                sSql += "PerEndThis05, PerEndThis06, PerEndThis07, PerEndThis08, PerEndThis09, PerEndThis10, ";
                sSql +=
                    "PerEndThis11, PerEndThis12, PerEndThis13,PerStartThis01, PerStartThis02, PerStartThis03, PerStartThis04, ";
                sSql +=
                    "PerStartThis05, PerStartThis06, PerStartThis07, PerStartThis08, PerStartThis09, PerStartThis10, ";
                sSql += "PerStartThis11, PerStartThis12, PerStartThis13, CurrentPeriod from LedgerParameters";

                PsqlDataReader rdReader = Connect.getDataCommand(sSql, oConn).ExecuteReader();

                while (rdReader.Read())
                {
                    selPeriodEnd.Items.Add(rdReader["PerEndThis01"].ToString().Substring(0, 10));
                    selPeriodEnd.Items.Add(rdReader["PerEndThis02"].ToString().Substring(0, 10));
                    selPeriodEnd.Items.Add(rdReader["PerEndThis03"].ToString().Substring(0, 10));
                    selPeriodEnd.Items.Add(rdReader["PerEndThis04"].ToString().Substring(0, 10));
                    selPeriodEnd.Items.Add(rdReader["PerEndThis05"].ToString().Substring(0, 10));
                    selPeriodEnd.Items.Add(rdReader["PerEndThis06"].ToString().Substring(0, 10));
                    selPeriodEnd.Items.Add(rdReader["PerEndThis07"].ToString().Substring(0, 10));
                    selPeriodEnd.Items.Add(rdReader["PerEndThis08"].ToString().Substring(0, 10));
                    selPeriodEnd.Items.Add(rdReader["PerEndThis09"].ToString().Substring(0, 10));
                    selPeriodEnd.Items.Add(rdReader["PerEndThis10"].ToString().Substring(0, 10));
                    selPeriodEnd.Items.Add(rdReader["PerEndThis11"].ToString().Substring(0, 10));
                    selPeriodEnd.Items.Add(rdReader["PerEndThis12"].ToString().Substring(0, 10));
                    if (rdReader["NumberPeriodsThis"].ToString() == "13")
                        selPeriodEnd.Items.Add(rdReader["PerEndThis13"].ToString().Substring(0, 10));

                    switch (rdReader["CurrentPeriod"].ToString())
                    {
                        case "1":
                            selPeriodEnd.SelectedItem = rdReader["PerEndThis01"].ToString().Substring(0, 10);
                            dtInvoiceUpToDate.Value = Convert.ToDateTime(rdReader["PerEndThis01"].ToString());
                            dtCurrPeriodEnd.Value = Convert.ToDateTime(rdReader["PerEndThis01"].ToString());
                            dtCurrPeriodStart.Value = Convert.ToDateTime(rdReader["PerStartThis01"].ToString());
                            lblFixedCurrPerEnd.Text += rdReader["PerEndThis01"].ToString().Substring(0, 10);
                            dtInvoiceDate.Value = Convert.ToDateTime(rdReader["PerEndThis01"].ToString());
                            break;

                        case "2":
                            selPeriodEnd.SelectedItem = rdReader["PerEndThis02"].ToString().Substring(0, 10);
                            dtInvoiceUpToDate.Value = Convert.ToDateTime(rdReader["PerEndThis02"].ToString());
                            lblFixedCurrPerEnd.Text += rdReader["PerEndThis02"].ToString().Substring(0, 10);
                            dtCurrPeriodEnd.Value = Convert.ToDateTime(rdReader["PerEndThis02"].ToString());
                            dtCurrPeriodStart.Value = Convert.ToDateTime(rdReader["PerStartThis02"].ToString());
                            dtInvoiceDate.Value = Convert.ToDateTime(rdReader["PerEndThis02"].ToString());
                            break;

                        case "3":
                            selPeriodEnd.SelectedItem = rdReader["PerEndThis03"].ToString().Substring(0, 10);
                            dtInvoiceUpToDate.Value = Convert.ToDateTime(rdReader["PerEndThis03"].ToString());
                            lblFixedCurrPerEnd.Text += rdReader["PerEndThis03"].ToString().Substring(0, 10);
                            dtCurrPeriodEnd.Value = Convert.ToDateTime(rdReader["PerEndThis03"].ToString());
                            dtCurrPeriodStart.Value = Convert.ToDateTime(rdReader["PerStartThis03"].ToString());
                            dtInvoiceDate.Value = Convert.ToDateTime(rdReader["PerEndThis03"].ToString());
                            break;

                        case "4":
                            selPeriodEnd.SelectedItem = rdReader["PerEndThis04"].ToString().Substring(0, 10);
                            dtInvoiceUpToDate.Value = Convert.ToDateTime(rdReader["PerEndThis04"].ToString());
                            lblFixedCurrPerEnd.Text += rdReader["PerEndThis04"].ToString().Substring(0, 10);
                            dtCurrPeriodEnd.Value = Convert.ToDateTime(rdReader["PerEndThis04"].ToString());
                            dtCurrPeriodStart.Value = Convert.ToDateTime(rdReader["PerStartThis04"].ToString());
                            dtInvoiceDate.Value = Convert.ToDateTime(rdReader["PerEndThis04"].ToString());
                            break;

                        case "5":
                            selPeriodEnd.SelectedItem = rdReader["PerEndThis05"].ToString().Substring(0, 10);
                            dtInvoiceUpToDate.Value = Convert.ToDateTime(rdReader["PerEndThis05"].ToString());
                            lblFixedCurrPerEnd.Text += rdReader["PerEndThis05"].ToString().Substring(0, 10);
                            dtCurrPeriodEnd.Value = Convert.ToDateTime(rdReader["PerEndThis05"].ToString());
                            dtCurrPeriodStart.Value = Convert.ToDateTime(rdReader["PerStartThis05"].ToString());
                            dtInvoiceDate.Value = Convert.ToDateTime(rdReader["PerEndThis05"].ToString());
                            break;

                        case "6":
                            selPeriodEnd.SelectedItem = rdReader["PerEndThis06"].ToString().Substring(0, 10);
                            dtInvoiceUpToDate.Value = Convert.ToDateTime(rdReader["PerEndThis06"].ToString());
                            lblFixedCurrPerEnd.Text += rdReader["PerEndThis06"].ToString().Substring(0, 10);
                            dtCurrPeriodEnd.Value = Convert.ToDateTime(rdReader["PerEndThis06"].ToString());
                            dtCurrPeriodStart.Value = Convert.ToDateTime(rdReader["PerStartThis06"].ToString());
                            dtInvoiceDate.Value = Convert.ToDateTime(rdReader["PerEndThis06"].ToString());
                            break;

                        case "7":
                            selPeriodEnd.SelectedItem = rdReader["PerEndThis07"].ToString().Substring(0, 10);
                            dtInvoiceUpToDate.Value = Convert.ToDateTime(rdReader["PerEndThis07"].ToString());
                            lblFixedCurrPerEnd.Text += rdReader["PerEndThis07"].ToString().Substring(0, 10);
                            dtCurrPeriodEnd.Value = Convert.ToDateTime(rdReader["PerEndThis07"].ToString());
                            dtCurrPeriodStart.Value = Convert.ToDateTime(rdReader["PerStartThis07"].ToString());
                            dtInvoiceDate.Value = Convert.ToDateTime(rdReader["PerEndThis07"].ToString());
                            break;

                        case "8":
                            selPeriodEnd.SelectedItem = rdReader["PerEndThis08"].ToString().Substring(0, 10);
                            dtInvoiceUpToDate.Value = Convert.ToDateTime(rdReader["PerEndThis08"].ToString());
                            lblFixedCurrPerEnd.Text += rdReader["PerEndThis08"].ToString().Substring(0, 10);
                            dtCurrPeriodEnd.Value = Convert.ToDateTime(rdReader["PerEndThis08"].ToString());
                            dtCurrPeriodStart.Value = Convert.ToDateTime(rdReader["PerStartThis08"].ToString());
                            dtInvoiceDate.Value = Convert.ToDateTime(rdReader["PerEndThis08"].ToString());
                            break;

                        case "9":
                            selPeriodEnd.SelectedItem = rdReader["PerEndThis09"].ToString().Substring(0, 10);
                            dtInvoiceUpToDate.Value = Convert.ToDateTime(rdReader["PerEndThis09"].ToString());
                            lblFixedCurrPerEnd.Text += rdReader["PerEndThis09"].ToString().Substring(0, 10);
                            dtCurrPeriodEnd.Value = Convert.ToDateTime(rdReader["PerEndThis09"].ToString());
                            dtCurrPeriodStart.Value = Convert.ToDateTime(rdReader["PerStartThis09"].ToString());
                            dtInvoiceDate.Value = Convert.ToDateTime(rdReader["PerEndThis09"].ToString());
                            break;

                        case "10":
                            selPeriodEnd.SelectedItem = rdReader["PerEndThis10"].ToString().Substring(0, 10);
                            dtInvoiceUpToDate.Value = Convert.ToDateTime(rdReader["PerEndThis10"].ToString());
                            lblFixedCurrPerEnd.Text += rdReader["PerEndThis10"].ToString().Substring(0, 10);
                            dtCurrPeriodEnd.Value = Convert.ToDateTime(rdReader["PerEndThis10"].ToString());
                            dtCurrPeriodStart.Value = Convert.ToDateTime(rdReader["PerStartThis10"].ToString());
                            dtInvoiceDate.Value = Convert.ToDateTime(rdReader["PerEndThis10"].ToString());
                            break;

                        case "11":
                            selPeriodEnd.SelectedItem = rdReader["PerEndThis11"].ToString().Substring(0, 10);
                            dtInvoiceUpToDate.Value = Convert.ToDateTime(rdReader["PerEndThis11"].ToString());
                            lblFixedCurrPerEnd.Text += rdReader["PerEndThis11"].ToString().Substring(0, 10);
                            dtCurrPeriodEnd.Value = Convert.ToDateTime(rdReader["PerEndThis11"].ToString());
                            dtCurrPeriodStart.Value = Convert.ToDateTime(rdReader["PerStartThis11"].ToString());
                            dtInvoiceDate.Value = Convert.ToDateTime(rdReader["PerEndThis11"].ToString());
                            break;

                        case "12":
                            selPeriodEnd.SelectedItem = rdReader["PerEndThis12"].ToString().Substring(0, 10);
                            dtInvoiceUpToDate.Value = Convert.ToDateTime(rdReader["PerEndThis12"].ToString());
                            lblFixedCurrPerEnd.Text += rdReader["PerEndThis12"].ToString().Substring(0, 10);
                            dtCurrPeriodEnd.Value = Convert.ToDateTime(rdReader["PerEndThis12"].ToString());
                            dtCurrPeriodStart.Value = Convert.ToDateTime(rdReader["PerStartThis12"].ToString());
                            dtInvoiceDate.Value = Convert.ToDateTime(rdReader["PerEndThis12"].ToString());
                            break;

                        case "13":
                            selPeriodEnd.SelectedItem = rdReader["PerEndThis13"].ToString().Substring(0, 10);
                            dtInvoiceUpToDate.Value = Convert.ToDateTime(rdReader["PerEndThis13"].ToString());
                            lblFixedCurrPerEnd.Text += rdReader["PerEndThis13"].ToString().Substring(0, 10);
                            dtCurrPeriodEnd.Value = Convert.ToDateTime(rdReader["PerEndThis13"].ToString());
                            dtCurrPeriodStart.Value = Convert.ToDateTime(rdReader["PerStartThis13"].ToString());
                            dtInvoiceDate.Value = Convert.ToDateTime(rdReader["PerEndThis13"].ToString());
                            break;
                    }
                }
                rdReader.Close();
                oConn.Dispose();
            }
        }

        private void selPeriodEnd_SelectedIndexChanged(object sender, EventArgs e)
        {
            dtInvoiceUpToDate.Value = Convert.ToDateTime(selPeriodEnd.SelectedItem.ToString());
            dtInvoiceDate.Value = Convert.ToDateTime(selPeriodEnd.SelectedItem.ToString());
            verifyAndAddVisibleElementsToDatagrid();
        }

        private void cmdGenerateInvoices_Click(object sender, EventArgs e)
        {
            initFilter();

            if (isInvoiceOutsideCurrentFinancialPeriod())
            {
                MessageBox.Show(string.Format("The invoice date {0} does not fall in the current period.",
                    Convert.ToDateTime(dtInvoiceDate.Value).ToString("dd/MM/yyyy")));
                return;
            }

            var salesOrdersToInvoice = getSelectedSalesOrders();

            if (salesOrdersToInvoice.Count == 0)
            {
                MessageBox.Show("There is no invoice to create.");
                return;
            }

            cmdGenerateInvoices.Enabled = false;

            var invoiceThread = new Thread(() => generateInvoices(salesOrdersToInvoice));
            invoiceThread.Start();
        }

        private List<Salesorder> getSelectedSalesOrders()
        {
            var ordersToInvoice = new List<Salesorder>();
            foreach (DataGridViewRow row in dgOpenSalesOrder.Rows)
            {
                if (row.Cells["chkInvoice"].Value == null) continue;

                var isSelected = bool.Parse(row.Cells["chkInvoice"].Value.ToString());

                if (isSelected)
                    ordersToInvoice.Add(
                        _openSalesOrders.First(
                            order => order.Header.DocumentNumber == row.Cells["clSalesOrderNum"].Value.ToString()));
            }

            return (ordersToInvoice);
        }

        private void generateInvoices(List<Salesorder> salesOrders)
        {
            SyncObject = this;

            var pastelService = Global.CreatePastelService();
              
            var salesOrderRepository = new SalesOrderRepository();
            var holidayRepo = new HolidayRepository(RepoContext.LiquidConnectionString);
            var itemRepository = new ItemRepository(RepoContext.LiquidConnectionString,
                RepoContext.PastelConnectionString);
            var salesOrderWithLinesRepository = new SalesOrderWithLinesRepository(RepoContext.LiquidConnectionString,
                RepoContext.PastelConnectionString, itemRepository);
            var historyHeaderRepository = new HistoryHeaderRepository(RepoContext.LiquidConnectionString,
                RepoContext.PastelConnectionString);
            var invoiceRepository = new InvoiceRepository(RepoContext.LiquidConnectionString,
                RepoContext.PastelConnectionString);
            var invoiceMessenger = new InvoiceMessenger(_log);
            var ruleRepository = new RuleRepository(RepoContext.LiquidConnectionString);
            var invoiceLineRepo = new InvoiceLineRepository(RepoContext.LiquidConnectionString,
                RepoContext.PastelConnectionString);
            var roundingInfoRepo = new RoundingInfoRepository(RepoContext.LiquidConnectionString);
            var leaseLevyInfoRepo = new LeaseLevyInfoRepository(RepoContext.LiquidConnectionString);
            var logService = new LogService(_log);

            invoiceMessenger.ProgressChanged += InvoiceMessager_ProgressChanged;
            invoiceMessenger.MessageChanged += InvoiceMessager_MessageChanged;

            var invoiceDomainService = new InvoiceDomainService(salesOrderRepository, pastelService, invoiceRepository,
                historyHeaderRepository, logService, ruleRepository, invoiceLineRepo, roundingInfoRepo, leaseLevyInfoRepo, holidayRepo, InvoiceTypeEnum.Bulk);
            var bulkInvoiceDomainService = new BulkInvoiceDomainService(invoiceDomainService,
                salesOrderWithLinesRepository, invoiceMessenger, logService);

            // Price consolidation here
            ItemPriceUpdater.UpdatePrices(salesOrders);

            var result = bulkInvoiceDomainService.CreateInvoices(salesOrders, _filter.InvoiceDate);
            result.Filter = _filter.CustomerPrefix;
            var resultsView = new InvoiceCompleteResultsView(result);
            resultsView.ShowDialog();
            FilterAfterInvoiced();
        }

        private void InvoiceMessager_MessageChanged(Liquid.Domain.EventArgs.MessageChangedEventArgs e)
        {
            SetProgressBarMessage(e.Message);
        }

        private void InvoiceMessager_ProgressChanged(Liquid.Domain.EventArgs.ProgressChangedEventArgs e)
        {
            SetProgressBar(e.Percentage);
        }

        public ISynchronizeInvoke SyncObject;

        public delegate void WriteStatusDelegate(
            string sStatus, string sInvoice, string sSalesOrder, string sDescription);

        public delegate void StopProgressDelegate();

        public delegate void InitFeedbackDelegate();

        public delegate void SetProgressBarDelegate(int percentage);

        public delegate void SetProgressBarMessageDelegate(string message);

        public delegate void FilterAfterInvoicedDelegate();

        public void FilterAfterInvoiced()
        {
            if (SyncObject.InvokeRequired)
                SyncObject.BeginInvoke(new FilterAfterInvoicedDelegate(FilterAfterInvoiced), null);
            else
                cmdFilter_Click(null, null);
        }

        public void SetProgressBar(int percentage)
        {
            if (SyncObject.InvokeRequired)
                SyncObject.BeginInvoke(new SetProgressBarDelegate(SetProgressBar), new object[] { percentage });
            else
            {
                if (percentage == progressBar1.Maximum)
                {
                    progressBar1.Value = percentage;
                    progressBar1.Value = percentage - 1;
                }
                else
                {
                    progressBar1.Value = percentage + 1;
                }
                progressBar1.Value = percentage;
            }
        }

        public void SetProgressBarMessage(string message)
        {
            if (SyncObject.InvokeRequired)
                SyncObject.BeginInvoke(new SetProgressBarMessageDelegate(SetProgressBarMessage), new object[] { message });
            else
            {
                progressBarText.Text = message;
            }
        }

        private bool isInvoiceOutsideCurrentFinancialPeriod()
        {
            dtInvoiceDate.Value = new DateTime(dtInvoiceDate.Value.Year, dtInvoiceDate.Value.Month,
                dtInvoiceDate.Value.Day, 0, 0, 0);
            return Convert.ToDateTime(dtInvoiceDate.Value) > Convert.ToDateTime(dtCurrPeriodEnd.Value) ||
                   Convert.ToDateTime(dtInvoiceDate.Value) < Convert.ToDateTime(dtCurrPeriodStart.Value);
        }

        private void cmdCustomerTo_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            using (Finder.CustomerZoom frmCustomerZoom = new Finder.CustomerZoom())
            {
                if (frmCustomerZoom.ShowDialog() == DialogResult.OK)
                {
                    if (frmCustomerZoom.CustomerCode != "")
                    {
                        txtCustomerTo.Text = frmCustomerZoom.CustomerCode;
                    }
                }
                Cursor = Cursors.Default;
            }
        }

        private void dgOpenSalesOrder_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex > -1)
                {
                    _activeRow = e.RowIndex;
                    _contextDeliveryNoteItemNumber = dgOpenSalesOrder.Rows[e.RowIndex].Cells[0].Value.ToString();
                    var salesOrder =
                        _openSalesOrders.Find(x => x.Header.DocumentNumber == _contextDeliveryNoteItemNumber);

                    if (salesOrder.HasActiveCustomOffHire)
                    {
                        ctxBulkInvoiceGrid.Items[0].Visible = false;
                        ctxBulkInvoiceGrid.Items[1].Visible = true;
                    }
                    else
                    {
                        ctxBulkInvoiceGrid.Items[0].Visible = true;
                        ctxBulkInvoiceGrid.Items[1].Visible = false;
                    }

                    ctxBulkInvoiceGrid.Show(dgOpenSalesOrder, dgOpenSalesOrder.PointToClient(Cursor.Position));
                }
            }
        }

        private void ctxBulkInvoiceGrid_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            var salesOrder = _openSalesOrders.Find(x => x.Header.DocumentNumber == _contextDeliveryNoteItemNumber);

            if (e.ClickedItem.Name == "tsmOffHire")
            {
                var offHire = new MarkOffHire(salesOrder);
                if (offHire.ShowDialog() == DialogResult.OK)
                {
                    paintOffHireItems(dgOpenSalesOrder.Rows[_activeRow], salesOrder);
                }
            }
            else
            {
                removeOffHire(salesOrder);
            }
        }

        private void removeOffHire(Salesorder salesorder)
        {
            salesorder.OffHireEndDate = new DateTime();
            salesorder.OffHireStartDate = new DateTime();

            var result = _salesOrderRepo.UpdateSalesOrderOffHireDates(salesorder);

            if (result)
            {
                removeOffHireStyling(_activeRow);
            }
        }

        private List<DateTime> getDatesForMonth()
        {
            var dates = new List<DateTime>();

            int year = dtInvoiceDate.Value.Year;
            int month = dtInvoiceDate.Value.Month;

            for (var date = new DateTime(year, month, 1); date.Month == month; date = date.AddDays(1))
            {
                dates.Add(date);
            }

            return dates;
        }

        private void removeOffHireStyling(int rowNumber)
        {
            dgOpenSalesOrder.Rows[rowNumber].DefaultCellStyle.BackColor = Color.White;
            dgOpenSalesOrder.Rows[rowNumber].Cells["txtOffHireStartDate"].Value = null;
            dgOpenSalesOrder.Rows[rowNumber].Cells["txtOffHireEndDate"].Value = null;
        }

        private void chkViewLockedItems_CheckedChanged(object sender, EventArgs e)
        {
            reloadViewModelFilters();
        }

        private void reloadViewModelFilters()
        {
            var filtered = filterLockedItems(_completeGridViewModel);
            filtered = filterAllreadyInvoicedItems(filtered);
            dgOpenSalesOrder.DataSource = filtered;
            chkAllInvoice.Checked = false;
            chkAllInvoice_CheckedChanged(null, null);
            verifyAndAddVisibleElementsToDatagrid();
        }

        private void chkInvoicedThisPeriod_CheckedChanged(object sender, EventArgs e)
        {
            reloadViewModelFilters();
        }

        private void btn_offHireReport_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            var offHire = new OffHireManager(_filter);
            offHire.ShowDialog();
            loadDataGridDetail();
            Cursor.Current = Cursors.Default;
        }
    }
}