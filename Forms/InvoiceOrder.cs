using Liquid.Domain;
using Liquid.Domain.Services;
using Liquid.Repository;
using Liquid.Services;
using Pervasive.Data.SqlClient;
using Liquid.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Liquid.Domain.Enums;
using Functions = Liquid.Classes.Functions;

namespace Liquid.Forms
{
    public partial class InvoiceOrder : Form
    {
        public InvoiceOrder()
        {
            InitializeComponent();
        }

        public string sDocNumber = "";
        public string sInvoiceNumber = "";
        public string sCustomerCode = "";
        public string sCustomerDescription = "";
        public string sInvoiceDate = "";
        public string sSalesCode = "";
        public string sDiscountPerc = "";
        public string sDeliveryDate = "";
        public string sOrderNumber = "";
        public string sSiteName = "";

        public Documents.SalesOrder frmSalesOrder;
        public Main frmMain;
        private const int WM_KEYDOWN = 0x100;
        private const int WM_SYSKEYDOWN = 0x104;

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            bool bHandled = false;
            if ((msg.Msg == WM_KEYDOWN) || (msg.Msg == WM_SYSKEYDOWN))
            {
                switch (keyData)
                {
                    case Keys.Tab:
                        manageEnterTab();
                        bHandled = true;
                        break;

                    case Keys.Enter:
                        manageEnterTab();
                        bHandled = true;
                        break;
                }
            }
            return bHandled;
        }

        private void manageEnterTab()
        {
            if (ActiveControl == dgInvoiceItems)
            {
                if (dgInvoiceItems.CurrentCell.RowIndex < dgInvoiceItems.RowCount - 1)
                {
                    dgInvoiceItems.CurrentCell = dgInvoiceItems.Rows[dgInvoiceItems.CurrentCell.RowIndex + 1].Cells["clInvoice"];
                }
                else
                {
                    dgInvoiceItems.ClearSelection();
                    ActiveControl = cmdCreateInvoice;
                }
            }
            else if (ActiveControl == cmdCreateInvoice)
            {
                cmdCreateInvoice_Click(null, null);
            }
        }

        public void cmdCreateInvoice_Click(object sender, EventArgs e)
        {
            if (Global.bAutoInvoiceOnReturn ||
                MessageBox.Show("This will create a Tax Invoice. Are You Sure?", "Create Invoice",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var salesorderHeader = buildSalesorderHeaderFromUi();
                var salesorderLines = buildSalesorderLinesFromUi(sDocNumber);
                if (salesorderLines.Count == 0)
                    MessageBox.Show("There is no valid lines to invoice.", "No lines", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                var salesorder = new SalesorderWithLines {Header = salesorderHeader, Lines = salesorderLines};

                
                // Price consolidation here
                ItemPriceUpdater.UpdatePrice(salesorder);
                updateInvoiceLines();
                salesorderLines = buildSalesorderLinesFromUi(sDocNumber);
                salesorder = new SalesorderWithLines { Header = salesorderHeader, Lines = salesorderLines };
                var salesOrderRepo = new SalesOrderRepository(Connect.LiquidConnectionString, Connect.PastelConnectionString);
                salesorder.LeaseLevyPercentage = salesOrderRepo.GetLeaseLevyBySalesOrderNumber(salesorder.Header.DocumentNumber);

                var invoiceService = createInvoiceService();
                var invoice = invoiceService.CreateInvoice(salesorder, DateTime.Now);

                if (invoice == null)
                {
                     MessageBox.Show("There was an error creating this invoice.  Please consult the logfile", "Error Creating Invoice", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                printInvoice(invoice.Header.DocumentNumber);
                
            }
            else
            {
                if (dgInvoiceItems.RowCount > 0)
                {
                    dgInvoiceItems.CurrentCell = dgInvoiceItems.Rows[0].Cells["clInvoice"];
                    ActiveControl = dgInvoiceItems;
                }
            }
            checkShouldCloseOrder();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void updateInvoiceLines()
        {
            decimal dInvoiceLineTotal = 0;
            using (var pastelConnection = new PsqlConnection(Connect.PastelConnectionString))
            {
                using (var liquidConnection = new PsqlConnection(Connect.LiquidConnectionString))
                {
                    pastelConnection.Open();
                    liquidConnection.Open();

                    var sql = "select * from SOLHL where Header = '" + sDocNumber + "'";
                    sql += " and (status = 1)"; //Can only invoice returned items
                    var liquidHLReader = Connect.getDataCommand(sql, liquidConnection).ExecuteReader();

                    int n = 0;

                    while (liquidHLReader.Read())
                    {
                        sql = " select HistoryLines.UnitPrice, HistoryLines.ItemCode,  HistoryLines.Description, HistoryLines.Qty ,inv1.UnitSize, inv1.UserDefNum01 'ItemType',inv1.UserDefNum02 'Duplicates', LinkNum, HistoryLines.DiscountAmount, HistoryLines.TaxAmt, HistoryLines.CostCode  from HistoryLines   ";
                        sql += " inner join Inventory inv1 on inv1.ItemCode = HistoryLines.ItemCode   ";
                        sql += " where HistoryLines.DocumentNumber = '" + sDocNumber + "' and HistoryLines.ItemCode = '" + liquidHLReader["ItemCode"].ToString().Trim() + "'  and LinkNum = " + liquidHLReader["LinkNum"] + " and DocumentType in (102,2)";
                        var pastelHistoryLinesReader = Connect.getDataCommand(sql, pastelConnection).ExecuteReader();
                        while (pastelHistoryLinesReader.Read())
                        {
                            dInvoiceLineTotal = Convert.ToDecimal(pastelHistoryLinesReader["Qty"]) * Convert.ToDecimal(pastelHistoryLinesReader["UnitPrice"]);
                        }
                        pastelHistoryLinesReader.Close();

                        dgInvoiceItems.Rows[n].Cells["clExValue"].Value = dInvoiceLineTotal.ToString("N2");

                        n = n + 1;
                    }
                    liquidHLReader.Close();

                    pastelConnection.Dispose();
                    liquidConnection.Dispose();
                }
            }
        }

        private InvoiceDomainService createInvoiceService()
        {
            var pastelService =
                new PastelService(new SdkSettings {User = Global.iPastelSdkUser, DataPath = Global.sDataPath, InvoiceUser = Global.iDefaultInvoiceUser});
            var salesOrderRepository = new SalesOrderRepository();
            var historyHeaderRepository = new HistoryHeaderRepository(RepoContext.LiquidConnectionString,
                RepoContext.PastelConnectionString);
            var invoiceRepository = new InvoiceRepository(RepoContext.LiquidConnectionString,
                RepoContext.PastelConnectionString);
            var ruleRepository = new RuleRepository(RepoContext.LiquidConnectionString);
            var invoiceLineRepo = new InvoiceLineRepository(RepoContext.LiquidConnectionString,
                RepoContext.PastelConnectionString);
            var roundingInfoRepo = new RoundingInfoRepository(RepoContext.LiquidConnectionString);
            var leaseLevyInfoRepo = new LeaseLevyInfoRepository(RepoContext.LiquidConnectionString);
            var holidayRepo = new HolidayRepository(RepoContext.LiquidConnectionString);
            return new InvoiceDomainService(salesOrderRepository, pastelService, invoiceRepository,
                historyHeaderRepository, null, ruleRepository, invoiceLineRepo, roundingInfoRepo, leaseLevyInfoRepo, holidayRepo, InvoiceTypeEnum.OffhireAddhoc);
        }

        private void checkShouldCloseOrder()
        {
            var iRemainingRows = Functions.GetLiquidSalesLinesCountExcludingComments(sDocNumber);
            if (iRemainingRows != 0) return;
            using (var oConn = new PsqlConnection(Connect.LiquidConnectionString))
            {
                oConn.Open();
                var sql = "UPDATE SOLHH SET ";
                if (
                    MessageBox.Show("There are no more lines in this order. Do you want to close this order?",
                        "Close Order?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    sql += " Status = 3";
                    sql += " WHERE DocNumber = '" + sDocNumber + "' ";
                    Connect.getDataCommand(sql, oConn).ExecuteNonQuery();
                    frmSalesOrder.setSalesOrderStatus(3);
                }
                else
                {
                    sql += " Status = 2 ";
                    sql += " WHERE DocNumber = '" + sDocNumber + "' ";
                    Connect.getDataCommand(sql, oConn).ExecuteNonQuery();
                    frmSalesOrder.setSalesOrderStatus(2);
                }
                oConn.Dispose();
            }
        }

        private void printInvoice(string invoiceNumber)
        {
            Cursor = Cursors.WaitCursor;
            if (Global.sInvoiceTemplate == "Kings Hire" && printDialog1.ShowDialog() == DialogResult.OK)
            {
                Functions.printInvoice(invoiceNumber, true, Global.sLogedInUserCode, printDialog1);
            }

            sInvoiceNumber = invoiceNumber;
            Cursor = Cursors.Default;
        }

        private List<IDocumentLine> buildSalesorderLinesFromUi(string documentNumber)
        {
            var lines = new List<IDocumentLine>();
            var itemRepository = new ItemRepository(Connect.LiquidConnectionString, Connect.PastelConnectionString);
            var salesorderLineRepository = new SalesOrderLineRepository(Connect.LiquidConnectionString, Connect.PastelConnectionString, itemRepository);
            foreach (DataGridViewRow dgRow in dgInvoiceItems.Rows)
            {
                if (!isRowTickedForInvoice(dgRow)) continue;
                
                var itemCode = dgRow.Cells["clItemCode"].Value.ToString().Trim();
                var linkNumber = int.Parse(dgRow.Cells["clNumber"].Value.ToString());

                var salesLine = itemCode == "Note"
                    ? getNoteLine(dgRow)
                    : salesorderLineRepository.GetByDocumentNumberItemCodeLinkNum(documentNumber, itemCode,
                        linkNumber);
                lines.Add(salesLine);
            }
            return lines;
        }

        private IDocumentLine getNoteLine(DataGridViewRow dgRow)
        {
            return  new SalesorderLine
            {
                Item = new Item { Code = "Note"},
                Description = dgRow.Cells["clDescription"].Value.ToString(),
                MultiStore = Global.DefaultMultiStore
            };
        }


        private static bool isRowTickedForInvoice(DataGridViewRow dgRow)
        {
            return dgRow.Cells["clInvoice"] != null && dgRow.Cells["clInvoice"].Value.ToString() == "True";
        }

        private SalesorderHeader buildSalesorderHeaderFromUi()
        {
            var salesorderRepo = new SalesOrderRepository(Connect.LiquidConnectionString, Connect.PastelConnectionString);
            var customerRepo = new CustomerRepository(Connect.LiquidConnectionString, Connect.PastelConnectionString);
            var header = salesorderRepo.GetByDocumentNumber(sDocNumber).Header;

            if (txtCustomerCode.Text != header.Customer.CustomerCode)
                header.Customer = customerRepo.GetByCode(txtCustomerCode.Text);

            if (Global.sLogedInUserCode.Trim() != txtSalesCode.Text.Trim())
                header.SalesCode = txtSalesCode.Text.Trim();

            if (sOrderNumber.Trim() != txtOrderNumber.Text.Trim())
                header.OrderNumber = txtOrderNumber.Text.Trim(); //Ordernumber has changed

            return (SalesorderHeader)header;
        }

        private void loadInvoiceLines()
        {
            decimal dInvoiceLineTotal = 0;
            using (var pastelConnection = new PsqlConnection(Connect.PastelConnectionString))
            {
                string sLineType = "", sItemDescription = "", sLineUnit = "", sDuplicates = "", sProjectCode = "";

                using (var liquidConnection = new PsqlConnection(Connect.LiquidConnectionString))
                {
                    pastelConnection.Open();
                    liquidConnection.Open();

                    var sql = "select * from SOLHL where Header = '" + sDocNumber + "'";
                    sql += " and (status = 1)"; //Can only invoice returned items
                    var liquidHLReader = Connect.getDataCommand(sql, liquidConnection).ExecuteReader();
                    while (liquidHLReader.Read())
                    {
                        int n = dgInvoiceItems.Rows.Add();
                        var cellstyle = new DataGridViewCellStyle
                        {
                            BackColor = Color.FromArgb(248, 248, 248),
                            Font = new Font("Arial", 8)
                        };
                        dgInvoiceItems.Rows[n].ReadOnly = true;
                        dgInvoiceItems.Rows[n].DefaultCellStyle = cellstyle;
                        dgInvoiceItems.Rows[n].Cells["clInvoice"].Style.BackColor = Color.White;
                        dgInvoiceItems.Rows[n].Cells["clInvoice"].ReadOnly = false;

                        sql = " select HistoryLines.UnitPrice, HistoryLines.ItemCode,  HistoryLines.Description, HistoryLines.Qty ,inv1.UnitSize, inv1.UserDefNum01 'ItemType',inv1.UserDefNum02 'Duplicates', LinkNum, HistoryLines.DiscountAmount, HistoryLines.TaxAmt, HistoryLines.CostCode  from HistoryLines   ";
                        sql += " inner join Inventory inv1 on inv1.ItemCode = HistoryLines.ItemCode   ";
                        sql += " where HistoryLines.DocumentNumber = '" + sDocNumber + "' and HistoryLines.ItemCode = '" + liquidHLReader["ItemCode"].ToString().Trim() + "'  and LinkNum = " + liquidHLReader["LinkNum"] + " and DocumentType in (102,2)";
                        var pastelHistoryLinesReader = Connect.getDataCommand(sql, pastelConnection).ExecuteReader();
                        while (pastelHistoryLinesReader.Read())
                        {
                            sLineType = pastelHistoryLinesReader["ItemType"].ToString();
                            sItemDescription = pastelHistoryLinesReader["Description"].ToString();
                            sProjectCode = pastelHistoryLinesReader["CostCode"].ToString();
                            sLineUnit = pastelHistoryLinesReader["UnitSize"].ToString();
                            sDuplicates = pastelHistoryLinesReader["Duplicates"].ToString();
                            dInvoiceLineTotal = Convert.ToDecimal(pastelHistoryLinesReader["Qty"]) * Convert.ToDecimal(pastelHistoryLinesReader["UnitPrice"]);
                        }
                        pastelHistoryLinesReader.Close();

                        var deliveryDate = liquidHLReader["DeliveryDate"].ToString();
                        var sReturnDate = liquidHLReader["ReturnDate"].ToString();

                        if (deliveryDate == "")
                        {
                            deliveryDate = "-";
                        }
                        if (sReturnDate == "")
                        {
                            sReturnDate = "-";
                        }

                       
                        dgInvoiceItems.Rows[n].Cells["clNumber"].Value = Convert.ToInt16(liquidHLReader["LinkNum"].ToString());
                        dgInvoiceItems.Rows[n].Cells["clItemCode"].Value = liquidHLReader["ItemCode"].ToString();
                        dgInvoiceItems.Rows[n].Cells["clDeliveryDate"].Value = deliveryDate;
                        dgInvoiceItems.Rows[n].Cells["clReturnDate"].Value = sReturnDate;
                        dgInvoiceItems.Rows[n].Cells["clDescription"].Value = sItemDescription;
                        dgInvoiceItems.Rows[n].Cells["clQuantity"].Value = liquidHLReader["Multiplier"].ToString();
                        dgInvoiceItems.Rows[n].Cells["clPeriod"].Value = liquidHLReader["Qty"].ToString();
                        dgInvoiceItems.Rows[n].Cells["clUnit"].Value = sLineUnit;
                        dgInvoiceItems.Rows[n].Cells["clInvoice"].Value = true;
                        dgInvoiceItems.Rows[n].Cells["clTypeCode"].Value = sLineType;
                        dgInvoiceItems.Rows[n].Cells["clProjectCode"].Value = sProjectCode;

                        dgInvoiceItems.Rows[n].Cells["clExValue"].Value = dInvoiceLineTotal.ToString("N2");
                        switch (sLineType)
                        {
                            case "0":
                                sLineType = "Consumable";
                                break;

                            case "1":
                                sLineType = "Lease Item";
                                if (sDuplicates == "1")
                                {
                                    sLineType += " - Duplicates Allowed";
                                }
                                break;

                            case "2":
                                sLineType = "Returnable Consumable - Qty";
                                break;
                        }
                        dgInvoiceItems.Rows[n].Cells["clItemType"].Value = sLineType;
                    }
                    liquidHLReader.Close();

                    sql = " select  HistoryLines.Description, LinkNum  from HistoryLines   ";
                    sql += " where HistoryLines.DocumentNumber = '" + sDocNumber + "' and HistoryLines.ItemCode = '''' and left(Description,2) <> '*D' and DocumentType in (102,2)";
                    liquidHLReader = Connect.getDataCommand(sql, pastelConnection).ExecuteReader();
                    while (liquidHLReader.Read())
                    {
                        var n = dgInvoiceItems.Rows.Add();
                        var cellstyle = new DataGridViewCellStyle
                        {
                            BackColor = Color.FromArgb(248, 248, 248),
                            Font = new Font("Arial", 8)
                        };
                        dgInvoiceItems.Rows[n].ReadOnly = true;
                        dgInvoiceItems.Rows[n].DefaultCellStyle = cellstyle;
                        dgInvoiceItems.Rows[n].Cells["clInvoice"].Style.BackColor = Color.White;
                        dgInvoiceItems.Rows[n].Cells["clInvoice"].ReadOnly = false;
                        dgInvoiceItems.Rows[n].Cells["clNumber"].Value = Convert.ToInt16(liquidHLReader["LinkNum"].ToString());
                        dgInvoiceItems.Rows[n].Cells["clItemCode"].Value = "Note";
                        dgInvoiceItems.Rows[n].Cells["clDeliveryDate"].Value = " - ";
                        dgInvoiceItems.Rows[n].Cells["clReturnDate"].Value = " - ";
                        dgInvoiceItems.Rows[n].Cells["clDescription"].Value = liquidHLReader["Description"].ToString();
                        dgInvoiceItems.Rows[n].Cells["clQuantity"].Value = "";
                        dgInvoiceItems.Rows[n].Cells["clUnit"].Value = "";
                        dgInvoiceItems.Rows[n].Cells["clInvoice"].Value = true;
                        dgInvoiceItems.Rows[n].Cells["clTypeCode"].Value = "7";
                    }
                    liquidHLReader.Close();
                    pastelConnection.Dispose();
                    liquidConnection.Dispose();
                }
            }

            dgInvoiceItems.Sort(dgInvoiceItems.Columns["clNumber"], ListSortDirection.Ascending);
            if (dgInvoiceItems.RowCount > 0)
            {
                cmdCreateInvoice.Enabled = true;
                ActiveControl = dgInvoiceItems;
                dgInvoiceItems.CurrentCell = dgInvoiceItems.Rows[0].Cells["clInvoice"];
            }
            dgInvoiceItems.Sort(dgInvoiceItems.Columns["clNumber"], ListSortDirection.Ascending);
        }

        public void InvoiceOrder_Load(object sender, EventArgs e)
        {
            lblSalesOrderNumber.Text = sDocNumber;
            txtSalesCode.Text = Global.sLogedInUserCode;
            txtInvoiceDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtDiscount.Text = sDiscountPerc;
            txtDeliveryDate.Text = sDeliveryDate;
            txtOrderNumber.Text = sOrderNumber;
            txtCustomerCode.Text = sCustomerCode;
            txtCustomerDescription.Text = sCustomerDescription;
            loadInvoiceLines();
        }
        
        private void cmdSalesPerson_Click(object sender, EventArgs e)
        {
            using (var frmVerify = new VerifyUser())
            {
                if (frmVerify.ShowDialog() == DialogResult.OK)
                {
                    txtSalesCode.Text = frmVerify.sUserCode;
                }
            }
        }

        private void cmdSearchCustomer_Click(object sender, EventArgs e)
        {
            findCustomer(txtCustomerCode);
        }

        private void findCustomer(TextBox srcBox)
        {
            Cursor = Cursors.WaitCursor;
            using (Finder.CustomerZoom frmCustomerZoom = new Finder.CustomerZoom())
            {
                if (frmCustomerZoom.ShowDialog() == DialogResult.OK)
                {
                    if (frmCustomerZoom.CustomerCode != "")
                    {
                        srcBox.Text = frmCustomerZoom.CustomerCode;
                        srcBox.Focus();
                        srcBox.SelectionStart = 0;
                        srcBox.SelectionLength = srcBox.Text.Length;
                        txtCustomerDescription.Text = frmCustomerZoom.CustomerDescription;
                    }
                }
                Cursor = Cursors.Default;
            }
        }
    }
}