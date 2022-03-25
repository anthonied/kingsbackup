using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Liquid.CommRepository;
using Liquid.CommRepository.Domain;
using Liquid.Domain.Emails;
using Liquid.Repository;
using Pervasive.Data.SqlClient;
using Liquid.Classes;
using Liquid.Finder;
using Liquid.Models;
using Liquid.Reports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Threading;
using System.Windows.Forms;
using log4net;
using Functions = Liquid.Classes.Functions;

namespace Liquid.Forms
{
    public partial class EmailAndFaxSend : Form
    {
        private static readonly ILog _log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public Thread thrSendEmail;
        public bool bPrintInvoice;
        public string activeCustomerCode = "";
        public List<string> additionalAttachments = new List<string>();
        private readonly CommEmailRepository _commEmailRepo = new CommEmailRepository();
        private readonly List<EmailNoteModel> _emailNoteModels = new List<EmailNoteModel>();

        public EmailAndFaxSend()
        {
            InitializeComponent();
        }

        private void EmailAndFaxSend_Load(object sender, EventArgs e)
        {
            txtCustomer.CharacterCasing = CharacterCasing.Upper;
            txtCustomerTo.CharacterCasing = CharacterCasing.Upper;
           // loadInvoiceList();
            selCustLetter.SelectedIndex = 0;
        }

        private void loadInvoiceList()
        {
            var liquidConnectionString = Connect.LiquidConnectionString;
            var pastelConnectionString = Connect.PastelConnectionString;

            var customerFrom = txtCustomer.Text;
            var customerTo = txtCustomerTo.Text;
            var customerOrderLetter = selCustLetter.Text;
            var toDateValue = dtDocDateTo.Text == ""? new DateTime(1970,01,01) : dtDocDateTo.Value;

            var emailAndPrintInvoiceModels = new List<EmailAndPrintInvoiceModel>();

            using (var invoiceHeaderRepo = new InvoiceHeaderRepository(liquidConnectionString, pastelConnectionString))
            {
                var invoiceHeaders = invoiceHeaderRepo.GetInvoicesByDateAndCustomerLetter(customerOrderLetter, toDateValue, customerFrom, customerTo);

                using (var auditRepo = new AuditRepository(liquidConnectionString, pastelConnectionString))
                using (
                    var deliveryAddressesRepo = new DeliveryAddressesRepository(liquidConnectionString,
                        pastelConnectionString))
                {
                    foreach (var invoiceHeader in invoiceHeaders)
                    {
                        var customerDeliveryAddress =
                            deliveryAddressesRepo.GetCustomerContactDetailsByCustomerCode(
                                invoiceHeader.Customer.CustomerCode);
                        var wasEmailSent = auditRepo.WasEmailSent(invoiceHeader.DocumentNumber);
                        var isvalidEmail = isEmail(customerDeliveryAddress.EmailAddress);
                        var invoiceLine = EmailAndPrintInvoiceModel.FromInvoiceHeaderDomain(invoiceHeader, wasEmailSent,
                            customerDeliveryAddress, isvalidEmail);

                        emailAndPrintInvoiceModels.Add(invoiceLine);
                    }

                    dgInvoiceList.DataSource = emailAndPrintInvoiceModels;
                }
            }
        }

        public static bool isEmail(string inputEmail)
        {
            if (inputEmail == "") return false;

            try
            {
                new MailAddress(inputEmail);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public ISynchronizeInvoke SyncObject;

        public delegate void CompleteProcessDelegate();

        public delegate void WriteToDatagridDelegate(string sCustomer, string sDescription, bool bSent);

        public delegate void InitProgressBarDelegate(int iRowCount);

        public delegate void StepProgressBarDelegate();

        public void StepProgressBar()
        {
            if (SyncObject.InvokeRequired)
                SyncObject.BeginInvoke(new StepProgressBarDelegate(StepProgressBar), new object[] { });
            else
            {
                Refresh();
            }
        }

        private void cmdCustomer_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            using (
                var frmCustomerZoom =
                    new CustomerZoom())
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

        private void cmdCustomerTo_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            using (
                var frmCustomerZoom =
                    new CustomerZoom())
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

        private void cmdFilter_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            loadInvoiceList();
            Cursor = Cursors.Default;
        }


        private void chkAllEmail_CheckedChanged(object sender, EventArgs e)
        {
            var iCheckValue = chkAllEmail.Checked ? 1 : 0;
            for (var i = 0; i < dgInvoiceList.Rows.Count; i++)
            {
                dgInvoiceList.Rows[i].Cells["clSendEmail"].Value = iCheckValue == 1 ? clSendEmail.TrueValue : clSendEmail.FalseValue;
            }
        }

        private int _errors;

        private void processEmails()
        {
          
            var selectedRows = getSelectedRows();

            var emailsToSend = EmailEngine.GroupEmails(selectedRows);
            var count = 0;
            _totalEmails = emailsToSend.Count.ToString();
            var total =
                emailsToSend.Select(emailItems => emailItems.Select(emailItem => emailItem.EmailAddress))
                    .ToList()
                    .Distinct()
                    .Count();
            _log.Debug($"Emails to send to Bullhorh: {total}");
            foreach (var emailItems in emailsToSend)
            {
                var recipientEmail = emailItems[0].EmailAddress;
                var customerCode = emailItems[0].CustomerCode;
                var invoicesToSend = emailItems.Select(i => i.InvoiceNumber).ToList();
                var additionalAttachementsToSend = additionalAttachments;

                var source = string.Format(@"{0}\Temp\", Application.StartupPath);
                var target = string.Format(@"{0}\Release\", Application.StartupPath);
               
                foreach (var invoiceNumber in invoicesToSend)
                    exportReportAsPdfToTempFolder(invoiceNumber, invoiceNumber + ".pdf");
                _log.Debug($"Ready to Create invoice pdf - source {source} - target {target}");
                EmailEngine.CreatePdf(invoicesToSend, source, target, customerCode, chkMergeEmails.Checked);

                _log.Debug($"Ready to copy invoice pdf");
                EmailEngine.CopyFiles(additionalAttachementsToSend, target);
                _log.Debug($"Pdf created");

                CopyFilesToServer(target);
                _log.Debug($"Files copied to server");

                var serverAttachmentPaths = GetServerAttachmentPaths(target);

                var invoiceLetter = new InvoiceLetter(_emailNoteModels.Select(x => x.Note).ToList())
                {
                    AttachmentPaths = serverAttachmentPaths,
                    CompanyName = emailItems[0].CustomerCode,
                    MonthName = dtDocDateTo.Value.ToString("MMMM"),
                    CustomerCode = emailItems[0].CustomerCode,
                };
                _log.Debug($"Ready to send mail");

                var response = _commEmailRepo.SendMail(new Recipient { Name = customerCode, Email = recipientEmail },
                    invoiceLetter, ConfigurationManager.AppSettings["BullhornApi"]);
                if (!response.Success)
                    _errors++;

                count++;
                _progressPercentage = 100.0 * count / total;
                _completedEmails = count.ToString();

                saveAuditTrail(invoicesToSend, customerCode);
            }
        }

        private List<string> GetServerAttachmentPaths(string target)
        {
            var serverAttachmentPaths = new List<String>();
            var files = Directory.GetFiles(target);
            foreach (var file in files)
            {
                var fileName = string.Format("c:/temp/bullhorn/attachmentfiles/{0}", Path.GetFileName(file));
                serverAttachmentPaths.Add(fileName);
            }
            return serverAttachmentPaths;
        }

        private void CopyFilesToServer(string target)
        {
            var files = Directory.GetFiles(target);

            foreach (var file in files)
            {
                _commEmailRepo.UploadFile(file, ConfigurationManager.AppSettings["BullhornApi"]);
            }
        }

        private List<EmailItem> getSelectedRows()
        {
            var selectedRows = new List<EmailItem>();
            foreach (DataGridViewRow row in dgInvoiceList.Rows)
            {
                if (row.Cells["clSendEmail"].Value == null) continue;
                if (row.Cells["clSendEmail"].Value.ToString() == "1")
                {
                    selectedRows.Add(new EmailItem
                    {
                        CustomerCode = row.Cells["clCustomerCode"].Value.ToString(),
                        EmailAddress = row.Cells["clEmailAddress"].Value.ToString(),
                        InvoiceNumber = row.Cells["clInvoiceNr"].Value.ToString()
                    });
                }
            }
            return selectedRows;
        }

        private static void saveAuditTrail(List<string> invoicesToSend, string customerCode)
        {
            foreach (var invoiceNumber in invoicesToSend)
            {
                using (var connection = new PsqlConnection(Connect.LiquidConnectionString))
                {
                    connection.Open();

                    var sSql = "INSERT into SOLAUD (iTypeSend, InvoiceNumber, CustomerCode, DateSent) ";
                    sSql += " VALUES ";
                    sSql += " (1, '" + invoiceNumber + "','" + customerCode + "','" +
                            DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "')";
                    Connect.getDataCommand(sSql, connection).ExecuteNonQuery();

                    connection.Dispose();
                }
            }
        }

        private static void exportReportAsPdfToTempFolder(string sDocumentNumber, string sFilename)
        {
            if (sDocumentNumber == "")
            {
                var s = "fsda";
            }
                using (
                ReportClass deliveryReport = Functions.getInvoiceReport(sDocumentNumber, "", "", "", "", "",
                    "NormalPrint", Global.sLogedInUserCode))
            {
                deliveryReport.ExportToDisk(ExportFormatType.PortableDocFormat,
                    Application.StartupPath + "\\Temp\\" + sFilename);
            }
        }

        private void cmdProcess_Click_1(object sender, EventArgs e)
        {
            var emailsToSendCount = 0;
            var iEmailErrorCount = 0;

            foreach (DataGridViewRow row in dgInvoiceList.Rows)
            {
                if (isEmailMarkToSend(row))
                    emailsToSendCount++;

                if (hasValidEmail(row)) continue;

                if (isEmailMarkToSend(row))
                    iEmailErrorCount += handleIncorrectEmailAddresses(row);
            }
            var printCount = setInvoicesToPrint();

            if (emailsToSendCount == 0 && printCount == 0)
            {
                MessageBox.Show("No invoices were selected to email or print");
                return;
            }

            if (allEmailsHasErrors(emailsToSendCount, iEmailErrorCount))
            {
                MessageBox.Show("All selected Email addresses have errors in", "Email Address Error");
                return;
            }

            if (canProceed(emailsToSendCount, iEmailErrorCount))
            {
                bPrintInvoice = false;

                progressBar.Visible = true;
                _progressPercentage = 0;
                progressBarTimer.Start();

                thrSendEmail = new Thread(processEmails);
                thrSendEmail.Start();
            }
            
            if (printCount ==0 || !canPrint(printCount)) return;
            
            Cursor = Cursors.WaitCursor;
            using (var printInvoiceReport = new PrintInvoicesReport())
                printInvoiceReport.ShowDialog(_invoicePrint, "", "", "", "", "");

            Cursor = Cursors.Default;
        }

       
        private string _invoicePrint = " WHERE HistoryHeader.DocumentNumber in ('";

        private int setInvoicesToPrint()
        {
            var printCount = 0;
            _invoicePrint = " WHERE HistoryHeader.DocumentNumber in (";
            var invoicesToPrint = new List<string>();
            foreach (DataGridViewRow row in dgInvoiceList.Rows)
            {
                var value = row.Cells["clPrintInvoice"].Value;

                if (value == null)
                    continue;

                if (value.ToString() != "1") continue;
                printCount++;
                var invoiceNumber = string.Format("'{0}'", row.Cells["clInvoiceNr"].Value);

                invoicesToPrint.Add(invoiceNumber);
            }

            _invoicePrint += string.Join(",", invoicesToPrint);

            return printCount;
        }

        private static bool canPrint(int iPrintCount)
        {
            return
                MessageBox.Show(
                    string.Format("You have selected {0} Invoice(s) to print. \n\n Do you want to continue printing?",
                        iPrintCount), "Print Emails and Faxes", MessageBoxButtons.YesNo, MessageBoxIcon.Information) ==
                DialogResult.Yes;
        }

        private bool allEmailsHasErrors(int emailsToSendCount, int iEmailErrorCount)
        {
            if (emailsToSendCount > 0)
                if (emailsToSendCount == iEmailErrorCount)
                    return true;
            return false;
        }

        private bool canProceed(int emailsToSendCount, int iEmailErrorCount)
        {
            if (emailsToSendCount == 0) return false;

            return MessageBox.Show(
                string.Format(
                    "You have selected '{0}' Invoice(s) to send. \n\n {1} selected email addresses have errors in. \n\nDo you want to continue sending?",
                    emailsToSendCount, iEmailErrorCount),
                "Send Emails and Faxes", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes;
        }

        private bool hasValidEmail(DataGridViewRow row)
        {
            if (row.Cells["clEmailAddress"].Value == null) return false;
            return row.Cells["clEmailAddress"].Value.ToString().Trim() != "" && isEmail(row.Cells["clEmailAddress"].Value.ToString().Trim());
        }

        private bool isEmailMarkToSend(DataGridViewRow row)
        {
            var sendEmail = row.Cells["clSendEmail"].Value;
            if (sendEmail == null)
                return false;

            return int.Parse(sendEmail.ToString()) == 1;
        }

        private int handleIncorrectEmailAddresses(DataGridViewRow row)
        {
            var emailErrorCount = 0;
            row.DefaultCellStyle.BackColor = Color.Red;
            row.Cells["clSendEmail"].Value = 0;
            emailErrorCount++;
            return emailErrorCount;
        }

        private void chkAllPrint_CheckedChanged(object sender, EventArgs e)
        {
            var iCheckValue = chkAllPrint.Checked ? 1 : 0;
            for (var i = 0; i < dgInvoiceList.Rows.Count; i++)
            {
                dgInvoiceList.Rows[i].Cells["clPrintInvoice"].Value = iCheckValue == 1 ? clPrintInvoice.TrueValue : clPrintInvoice.FalseValue;
            }
        }

        private double _progressPercentage;
        private string _totalEmails = "0";
        private string _completedEmails = "0";

        private void progressBarTimer_Tick(object sender, EventArgs e)
        {
            if (_progressPercentage == 100)
            {
                progressBarTimer.Stop();
                checkboxPanel.Visible = true;
                loadInvoiceList();
                if (_errors > 0)
                    MessageBox.Show(
                        string.Format(
                            "There were errors while sending out the emails. The total emails that had errors were: {0}",
                            _errors), "Email Errors", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            totalCountLabel.Text = _totalEmails;
            completedEmailsLabel.Text = _completedEmails;

            progress.Value = (int)_progressPercentage;
        }

        private void closeSummary_Click(object sender, EventArgs e)
        {
            progressBar.Visible = false;
        }

        private void AddAttachments_Click(object sender, EventArgs e)
        {
            LoadNewGeneralAttachement();
        }

        private void LoadNewGeneralAttachement()
        {
            var openFileDialog = new OpenFileDialog();
            var dialogResult = openFileDialog.ShowDialog();

            if (dialogResult != DialogResult.OK) return;
            var userSelectedFilePath = Path.GetFileName(openFileDialog.FileName);
            additionalAttachments.Add(openFileDialog.FileName);
            initializeListBox(userSelectedFilePath);
        }

        private void initializeListBox(string userSelectedFilePath)
        {
            lbAttachments.Items.Add(userSelectedFilePath);
        }

        public void listBox1_Attachments(object sender, EventArgs e)
        {
            if (lbAttachments.GetItemText(lbAttachments.SelectedItem) == "") return;
            if (MessageBox.Show("Are you sure you want to delete this attachment?", "Delete Attachment",
                MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes) return;
            var attachmentName = lbAttachments.GetItemText(lbAttachments.SelectedItem);
            if (attachmentName == "") return;

            additionalAttachments.RemoveAll(x => x.Split(',').First().Contains(attachmentName));
            lbAttachments.Items.Remove(attachmentName);
        }

        private void addNote_Click(object sender, EventArgs e)
        {
            var noteModal = new NoteModal();
            if (noteModal.ShowDialog() != DialogResult.OK) return;

            _emailNoteModels.Add(new EmailNoteModel
            {
                Name = noteModal.NoteName,
                Note = noteModal.Note
            });

            lbNotes.Items.Add(noteModal.NoteName);
        }

        private void lbNotes_Click(object sender, EventArgs e)
        {
            var item = lbNotes.GetItemText(lbNotes.SelectedItem);
            if (item == "") return;
            if (MessageBox.Show("Are you sure you want to delete this note?", "Delete Note",
              MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes) return;
            lbNotes.Items.Remove(item);
            _emailNoteModels.Remove(_emailNoteModels.First(x => x.Name == item));
        }
    }
}