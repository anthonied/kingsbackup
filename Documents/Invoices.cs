using Liquid.Domain;
using Liquid.Repository;
using Liquid.Classes;
using System;
using System.Linq;
using System.Windows.Forms;
using Liquid.Domain.Services;
using Functions = Liquid.Classes.Functions;
using InvoiceLine = Liquid.Controls.InvoiceLine;

namespace Liquid.Documents
{
    public partial class Invoices : Form
    {
        public Invoices()
        {
            InitializeComponent();
        }

        private Invoice _selectedInvoice;
        public Control[] InvoiceLines = new Control[0];
        public int iInvoiceLineRowIndex;
        public string[] aInvoiceCommentLines = new string[0];

        public DialogResult ShowDialog(string sInvoice)
        {
            loadInvoice(sInvoice);
            return ShowDialog();
        }

        private void cmdSearchNumber_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            using (var frmInvoiceZoom = new Finder.InvoiceZoom())
            {
                if (frmInvoiceZoom.ShowDialog() == DialogResult.OK)
                {
                    if (frmInvoiceZoom.sResult != "")
                    {
                        txtInvoiceNumber.Text = frmInvoiceZoom.sResult;
                        txtInvoiceNumber.SelectionStart = 0;
                        txtInvoiceNumber.SelectionLength = txtInvoiceNumber.Text.Length;
                        loadInvoice(txtInvoiceNumber.Text);
                        ActiveControl = txtInvoiceNumber;
                        cmdUpdateBatch.Enabled = true;
                    }
                }
                Cursor = Cursors.Default;
            }
        }

        public void loadInvoice(string invoiceNumber)
        {
            if (invoiceNumber == "*Select*") return;
            ClearInvoiceLines();
            _selectedInvoice =
                new InvoiceRepository(Connect.LiquidConnectionString, Connect.PastelConnectionString).GetByNumber(
                    invoiceNumber);

            fillInvoiceHeaderFields(_selectedInvoice.Header as InvoiceHeader);
            fillCustomerFields(_selectedInvoice.Header.Customer);

            foreach (var invoiceLine in _selectedInvoice.Lines)
            {
                loadExistingInvoiceLines(invoiceLine as Liquid.Domain.InvoiceLine);
                cmdUpdateBatch.Enabled = invoiceLine.IsBatch;
            }

            if (_selectedInvoice.Lines.Count > 0)
                cmdNewLine.Visible = true;

            if (!cmdUpdateBatch.Enabled)
                makeInvoiceLinesReadOnly();
            Cursor = Cursors.Default;
        }

        private void fillCustomerFields(Customer customer)
        {
            txtInvPostAd1.Text = customer.PostAddress01;
            txtInvPostAd2.Text = customer.PostAddress02;
            txtInvPostAd3.Text = customer.PostAddress03;
            txtInvPostAd4.Text = customer.PostAddress04;
            txtInvoiceCustomerName.Text = customer.Description;
        }

        private void fillInvoiceHeaderFields(InvoiceHeader header)
        {
            txtInvoiceNumber.Text = header.DocumentNumber;
            txtInvoiceCustomer.Text = header.Customer.CustomerCode;
            txtInvDelAd1.Text = header.DeliveryAddress.Line1;
            txtInvDelAd2.Text = header.DeliveryAddress.Line2;
            txtInvDelAd3.Text = header.DeliveryAddress.Line3;
            txtInvDelAd4.Text = header.DeliveryAddress.Line4;
            txtInvDelAd5.Text = header.DeliveryAddress.Line5;
            txtInvContact.Text = header.ContactPerson;
            txtInvTel.Text = header.Telephone;
            txtInvFax.Text = header.Fax;
            txtOrdernumber.Text = header.OrderNumber;
            lblInvDate.Text = header.DocumentDate.ToString("yyyy-MM-dd");
            lblInvSalesCode.Text = header.SalesCode;
            lblInvPeriod.Text = header.Period;
            lblInvDiscount.Text = header.DiscountPercentage.ToString();
            lblInvTotalTax.Text = header.TotalTax.ToString("N2");
            lblInvTotExcl.Text = header.TotalExVat.ToString("N2");
            lblInvTotal.Text = header.TotalInclVat.ToString("N2");
            txtInvFreight.Text = header.Freight;
            txtInvShip.Text = header.Ship;
            txtInvMess1.Text = header.Message1;
            txtInvMess2.Text = header.Message2;
            txtInvMess3.Text = header.Message3;
            txtDiscount.Text = header.DiscountPercentage.ToString();
        }

        public void ClearInvoiceLines()
        {
            //Clear all existing lines
            for (var iLines = 0; iLines < InvoiceLines.Length; iLines++)
            {
                var slThisline = (((InvoiceLine)InvoiceLines[iLines]));
                pnlDetails.Controls.Remove(slThisline);
            }
            iInvoiceLineRowIndex = 0;
            InvoiceLines = new Control[0];
        }

        public void loadExistingInvoiceLines(Liquid.Domain.InvoiceLine invoiceLine)
        {
            try
            {
                var dDiscount = Convert.ToDouble(invoiceLine.DiscountPercentage) / 100;
                var newInvoiceLine = new InvoiceLine { IsAlreadyInvoiced = true };
                if (invoiceLine.Description.ToUpper() == "ROUNDING")
                {
                    lblInvDiscountTotal.Text = invoiceLine.UnitPrice.ToString();
                }

                if (invoiceLine.Item.Code.Trim().Replace("'", "") != "")
                {
                    newInvoiceLine.txtTaxType.Text = invoiceLine.TaxType;
                    newInvoiceLine.txtDiscountType.Text = invoiceLine.DiscountType;
                }

                newInvoiceLine.sPastelLineLink = invoiceLine.LinkNumber.ToString();
                newInvoiceLine.bDoCalculation = false; //Do totals only after the control has been loaded.
                newInvoiceLine.txtCode.Text = invoiceLine.Item.Code;
                newInvoiceLine.txtDescription.Text = invoiceLine.Description;
                newInvoiceLine.sOldDescription = invoiceLine.Description;

                newInvoiceLine.txtUnit.Text = invoiceLine.UnitUsed;
                if (invoiceLine.FromDate.Year != 1970)
                {
                    newInvoiceLine.dtDelivery.Text = invoiceLine.FromDate.ToString("yyyy-MM-dd");
                    newInvoiceLine.dtDelivery.Visible = true;
                }
                else
                    newInvoiceLine.dtDelivery.Visible = false;

                if (invoiceLine.ToDate.Year != 1970)
                {
                    newInvoiceLine.dtReturnDate.Text = invoiceLine.ToDate.ToString("yyyy-MM-dd");
                    newInvoiceLine.dtReturnDate.Visible = true;
                }
                else
                    newInvoiceLine.dtReturnDate.Visible = false;

                newInvoiceLine.cmdCodeSearch.Enabled = false;
                newInvoiceLine.lblReturnDate.Visible = false;
                newInvoiceLine.lblDeliveryDate.Visible = false;
                newInvoiceLine.txtPeriod.Text = invoiceLine.Quantity.ToString();
                newInvoiceLine.txtQuantity.Text = invoiceLine.Period.ToString();
                newInvoiceLine.txtQuantity.Visible = true;
                newInvoiceLine.txtExcPrice.Text = invoiceLine.UnitPrice.ToString("N2");
                newInvoiceLine.txtDiscount.Text = dDiscount.ToString("N2");
                newInvoiceLine.txtDiscount.ReadOnly = true;

                if (newInvoiceLine.txtPeriod.Text != "")
                {
                    var dTotalExDiscount = Convert.ToDouble(newInvoiceLine.txtPeriod.Text.Replace(",", "")) * Convert.ToDouble(newInvoiceLine.txtQuantity.Text.Replace(",", "")) * Convert.ToDouble(newInvoiceLine.txtExcPrice.Text.Replace(",", ""));
                    newInvoiceLine.txtNet.Text = (dTotalExDiscount - (dTotalExDiscount * (Convert.ToDouble(newInvoiceLine.txtDiscount.Text.Replace(",", "")) / 100))).ToString("N2");
                }
                else
                {
                    newInvoiceLine.txtNet.Text = newInvoiceLine.txtExcPrice.Text;
                }
                newInvoiceLine.bDoCalculation = true;

                addInvoiceLine(newInvoiceLine);
                newInvoiceLine.picDelete.Visible = false;
                dtDelivery.Text = newInvoiceLine.dtDelivery.Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void slNewLine_OnDelete(int lineIndexToDelete)
        {
            if (
                MessageBox.Show("Are you sure you want to delete this line?", "Confirm", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
            {
                deleteInvoiceLine(lineIndexToDelete);
            }
        }

        private void deleteInvoiceLine(int lineIndexToDelete)
        {
            var currentLine = (((InvoiceLine)InvoiceLines[lineIndexToDelete]));
            pnlDetails.Controls.Remove(currentLine);
            Array.Resize(ref InvoiceLines, InvoiceLines.Length - 1);
            iInvoiceLineRowIndex--;
            AddTotals();
            setCanAddNewLine();
            _selectedInvoice.Lines.Remove(_selectedInvoice.Lines.Last());
        }

        public void addInvoiceLine(InvoiceLine slNewLine)
        {
            slNewLine.OnDelete += slNewLine_OnDelete;
            Array.Resize(ref InvoiceLines, InvoiceLines.Length + 1);
            InvoiceLines[InvoiceLines.Length - 1] = slNewLine;
            slNewLine.Top = 17 + ((iInvoiceLineRowIndex) * 20);
            slNewLine.Left = 4;
            slNewLine.TabIndex = 50 + InvoiceLines.Length;
            slNewLine.TabStop = true;
            slNewLine.txtCode.Visible = true;
            slNewLine.lblDeliveryDate.Visible = false;
            slNewLine.lblReturnDate.Visible = false;
            slNewLine.txtPeriod.Visible = true;
            slNewLine.txtDiscount.Visible = true;
            slNewLine.txtExcPrice.Visible = true;
            slNewLine.txtNet.Visible = true;
            if (Global.iCreditInvoice == 0)
            {
                slNewLine.cmdCredit.Visible = false;
            }
            if (Global.iCreditInvoice == 0)
            {
                slNewLine.cmdCredit.Visible = false;
            }
            slNewLine.iLineIndex = InvoiceLines.Length - 1;
            slNewLine.Name = "slNewLine_" + (InvoiceLines.Length - 1);

            pnlDetails.Controls.Add(slNewLine);
            slNewLine.BringToFront();
            iInvoiceLineRowIndex++;
        }

        public void makeInvoiceLinesReadOnly()
        {
            foreach (var slThisline in InvoiceLines.Select(invoiceLine => (((InvoiceLine)invoiceLine))))
            {
                slThisline.makeLineReadOnly();
            }
        }

        private void cmdPrint_Click(object sender, EventArgs e)
        {
            if (txtInvoiceNumber.Text != "*Select*" && txtInvoiceNumber.Text != "")
            {
                if (Global.sInvoiceTemplate == "Kings Hire")
                {
                    if (printDialog1.ShowDialog() == DialogResult.OK)
                    {
                        Cursor = Cursors.WaitCursor;
                        Functions.printInvoice(txtInvoiceNumber.Text, false, lblInvSalesCode.Text.Trim(), printDialog1);
                        Cursor = Cursors.Default;
                    }
                }
                else
                {
                    var PdPrint = new PrintDialog();
                    Cursor = Cursors.WaitCursor;
                    Functions.printInvoice(txtInvoiceNumber.Text, false, lblInvSalesCode.Text.Trim(), PdPrint);
                    Cursor = Cursors.Default;
                }
            }
        }

        private void txtInvoiceNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && (txtInvoiceNumber.Text == "" || txtInvoiceNumber.Text == "*Select*"))
            {
                e.SuppressKeyPress = true;
                cmdSearchNumber_Click(sender, e);
            }
            else
            {
                loadInvoice(txtInvoiceNumber.Text);
            }
        }

        public void AddTotals()
        {
            decimal dTotal = 0;
            decimal dRounding = 0;
            decimal dDiscountCalcTotal = 0;
            decimal dDiscount = 0;
            decimal dNonTaxTotal = 0;
            decimal dLineNetTotal = 0;
            var sLastMasterItem = "";
            var sLastMasterItemDiscountType = "";

            for (var iLines = 0; iLines < InvoiceLines.Length; iLines++)
            {
                var slActive = (InvoiceLine)InvoiceLines[iLines];
                if (slActive.txtDescription.Text == "ROUNDING")
                {
                    dRounding = Convert.ToDecimal(slActive.txtNet.Text);
                }

                dTotal += Convert.ToDecimal(slActive.txtNet.Text);

                if (((InvoiceLine)InvoiceLines[iLines]).txtDiscountType.Text == "2" ||
                    ((InvoiceLine)InvoiceLines[iLines]).txtDiscountType.Text == "3")
                {
                    dDiscountCalcTotal += Convert.ToDecimal(slActive.txtNet.Text);
                }

                if (slActive.txtTaxType.Text == "0" || slActive.txtTaxType.Text == "2") //Tax free item
                {
                    dNonTaxTotal += Convert.ToDecimal(slActive.txtNet.Text);
                }
                if (txtDiscount.Text != "" && txtDiscount.Text != ".")
                {
                    dDiscount = Convert.ToDecimal(txtDiscount.Text) / 100 * dDiscountCalcTotal;
                }
                dLineNetTotal = dLineNetTotal + Convert.ToDecimal(slActive.txtNet.Text);
            }

            lblInvDiscountTotal.Text = dRounding.ToString();
            dTotal -= dDiscount;
            var dTaxTotal = dTotal - dNonTaxTotal;
            lblInvTotExcl.Text = dTotal.ToString("N2");
            lblInvTotalTax.Text = (dTaxTotal * 0.15m).ToString("N2");
            lblInvTotal.Text = ((dTaxTotal * 1.15m) + dNonTaxTotal).ToString("N2");
        }

        private void cmdSaveOrder_Click(object sender, EventArgs e)
        {
            syncInvoiceDomainWithForm();

            var batchInvoiceService = createBatchInvoiceService();

            var success = batchInvoiceService.Update(_selectedInvoice);
            if (success)
                MessageBox.Show("Batch updated successfully");
        }

        private static BatchInvoiceService createBatchInvoiceService()
        {
            var invoiceLineRepo = new InvoiceLineRepository(Connect.LiquidConnectionString, Connect.PastelConnectionString);
            var invoiceHeaderRepo = new InvoiceHeaderRepository(Connect.LiquidConnectionString, Connect.PastelConnectionString);
            var pastelService = Global.CreatePastelService();
            return new BatchInvoiceService(invoiceHeaderRepo, pastelService, invoiceLineRepo);
        }

        private bool isExistingLine(InvoiceLine thisLine)
        {
            return thisLine.IsAlreadyInvoiced;
        }

        private void syncInvoiceDomainWithForm()
        {
            _selectedInvoice.Header.OrderNumber = txtOrdernumber.Text;
            foreach (InvoiceLine line in InvoiceLines)
            {
                var currentDomainLine = _selectedInvoice.Lines[line.iLineIndex] as Liquid.Domain.InvoiceLine;
                currentDomainLine.DocumentNumber = txtInvoiceNumber.Text;
                currentDomainLine.Item = new Item {Code = line.txtCode.Text};
                currentDomainLine.LinkNumber = line.iLineIndex;
                currentDomainLine.ExistInPastel = line.IsAlreadyInvoiced;
                currentDomainLine.FromDate = line.dtDelivery.Value;
                currentDomainLine.ToDate = line.dtReturnDate.Value;
                currentDomainLine.Description = line.txtDescription.Text;
                currentDomainLine.Quantity = decimal.Parse(line.txtQuantity.Text);
                currentDomainLine.Period = decimal.Parse(line.txtPeriod.Text);
                currentDomainLine.UnitPrice = decimal.Parse(line.txtExcPrice.Text);
                currentDomainLine.SearchTypeRaw = "4";
            }
        }

        private void cmdNewLine_Click(object sender, EventArgs e)
        {
            var newLineControl = createNewLineControl();
            addInvoiceLine(newLineControl);
            newLineControl.txtCode.Focus();
            setCanOnlyAddOneLine();
            _selectedInvoice.Lines.Add(new Liquid.Domain.InvoiceLine());
        }

        private InvoiceLine createNewLineControl()
        {
            return new InvoiceLine
            {
                bNextLine = true,
                bFocusOnNextLine = false
            };
        }

        private void setCanOnlyAddOneLine()
        {
            cmdNewLine.Visible = false;
        }

        private void setCanAddNewLine()
        {
            cmdNewLine.Visible = true;
        }
    }
}