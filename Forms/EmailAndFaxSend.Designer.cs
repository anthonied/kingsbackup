namespace Liquid.Forms
{
    partial class EmailAndFaxSend
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmailAndFaxSend));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn3 = new System.Windows.Forms.DataGridViewImageColumn();
            this.progressBarTimer = new System.Windows.Forms.Timer(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbNotes = new System.Windows.Forms.ListBox();
            this.addNote = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.AddAttachments = new System.Windows.Forms.Button();
            this.lbAttachments = new System.Windows.Forms.ListBox();
            this.progressBar = new System.Windows.Forms.Panel();
            this.closeSummary = new System.Windows.Forms.Button();
            this.checkboxPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.completedEmailsLabel = new System.Windows.Forms.Label();
            this.totalCountLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.progress = new System.Windows.Forms.ProgressBar();
            this.label5 = new System.Windows.Forms.Label();
            this.cmdProcess = new System.Windows.Forms.Button();
            this.gbFilter = new System.Windows.Forms.GroupBox();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.selCustLetter = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtDocDateTo = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdCustomerTo = new System.Windows.Forms.Button();
            this.txtCustomerTo = new System.Windows.Forms.TextBox();
            this.lblOrderType = new System.Windows.Forms.Label();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.cmdFilter = new System.Windows.Forms.Button();
            this.cmdCustomer = new System.Windows.Forms.Button();
            this.dgInvoiceList = new System.Windows.Forms.DataGridView();
            this.clCustomerCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clInvoiceNr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clInvoiceDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clEmailAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clFaxNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clEmailSent = new System.Windows.Forms.DataGridViewImageColumn();
            this.clFaxSent = new System.Windows.Forms.DataGridViewImageColumn();
            this.clSendEmail = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clSendFax = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clPrintInvoice = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkMergeEmails = new System.Windows.Forms.CheckBox();
            this.chkAllPrint = new System.Windows.Forms.CheckBox();
            this.chkAllEmail = new System.Windows.Forms.CheckBox();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.progressBar.SuspendLayout();
            this.gbFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgInvoiceList)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "Status";
            this.dataGridViewImageColumn1.Image = ((System.Drawing.Image)(resources.GetObject("dataGridViewImageColumn1.Image")));
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewImageColumn1.Width = 40;
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.HeaderText = "Email Sent?";
            this.dataGridViewImageColumn2.Image = global::Liquid.Properties.Resources.delete21;
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn2.Visible = false;
            // 
            // dataGridViewImageColumn3
            // 
            this.dataGridViewImageColumn3.HeaderText = "Fax Sent?";
            this.dataGridViewImageColumn3.Image = global::Liquid.Properties.Resources.delete21;
            this.dataGridViewImageColumn3.Name = "dataGridViewImageColumn3";
            this.dataGridViewImageColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewImageColumn3.Visible = false;
            this.dataGridViewImageColumn3.Width = 40;
            // 
            // progressBarTimer
            // 
            this.progressBarTimer.Tick += new System.EventHandler(this.progressBarTimer_Tick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbNotes);
            this.groupBox2.Controls.Add(this.addNote);
            this.groupBox2.Location = new System.Drawing.Point(404, 17);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(233, 105);
            this.groupBox2.TabIndex = 204;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Notes";
            // 
            // lbNotes
            // 
            this.lbNotes.BackColor = System.Drawing.SystemColors.Control;
            this.lbNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNotes.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lbNotes.FormattingEnabled = true;
            this.lbNotes.ItemHeight = 12;
            this.lbNotes.Location = new System.Drawing.Point(16, 16);
            this.lbNotes.Margin = new System.Windows.Forms.Padding(1);
            this.lbNotes.Name = "lbNotes";
            this.lbNotes.Size = new System.Drawing.Size(171, 74);
            this.lbNotes.TabIndex = 195;
            this.lbNotes.Click += new System.EventHandler(this.lbNotes_Click);
            // 
            // addNote
            // 
            this.addNote.Location = new System.Drawing.Point(191, 67);
            this.addNote.Name = "addNote";
            this.addNote.Size = new System.Drawing.Size(36, 23);
            this.addNote.TabIndex = 0;
            this.addNote.Text = "Add";
            this.addNote.UseVisualStyleBackColor = true;
            this.addNote.Click += new System.EventHandler(this.addNote_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.AddAttachments);
            this.groupBox3.Controls.Add(this.lbAttachments);
            this.groupBox3.Location = new System.Drawing.Point(670, 17);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(233, 105);
            this.groupBox3.TabIndex = 203;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Attachments";
            // 
            // AddAttachments
            // 
            this.AddAttachments.Location = new System.Drawing.Point(188, 67);
            this.AddAttachments.Margin = new System.Windows.Forms.Padding(1);
            this.AddAttachments.Name = "AddAttachments";
            this.AddAttachments.Size = new System.Drawing.Size(36, 24);
            this.AddAttachments.TabIndex = 192;
            this.AddAttachments.Text = "Add";
            this.AddAttachments.UseVisualStyleBackColor = true;
            this.AddAttachments.Click += new System.EventHandler(this.AddAttachments_Click);
            // 
            // lbAttachments
            // 
            this.lbAttachments.BackColor = System.Drawing.SystemColors.Control;
            this.lbAttachments.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbAttachments.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAttachments.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lbAttachments.FormattingEnabled = true;
            this.lbAttachments.ItemHeight = 12;
            this.lbAttachments.Location = new System.Drawing.Point(15, 17);
            this.lbAttachments.Margin = new System.Windows.Forms.Padding(1);
            this.lbAttachments.Name = "lbAttachments";
            this.lbAttachments.Size = new System.Drawing.Size(171, 74);
            this.lbAttachments.TabIndex = 194;
            this.lbAttachments.Click += new System.EventHandler(this.listBox1_Attachments);
            // 
            // progressBar
            // 
            this.progressBar.BackColor = System.Drawing.Color.White;
            this.progressBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.progressBar.Controls.Add(this.closeSummary);
            this.progressBar.Controls.Add(this.checkboxPanel);
            this.progressBar.Controls.Add(this.completedEmailsLabel);
            this.progressBar.Controls.Add(this.totalCountLabel);
            this.progressBar.Controls.Add(this.label4);
            this.progressBar.Controls.Add(this.label1);
            this.progressBar.Controls.Add(this.flowLayoutPanel1);
            this.progressBar.Controls.Add(this.progress);
            this.progressBar.Controls.Add(this.label5);
            this.progressBar.Location = new System.Drawing.Point(352, 241);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(539, 138);
            this.progressBar.TabIndex = 202;
            this.progressBar.Visible = false;
            // 
            // closeSummary
            // 
            this.closeSummary.Location = new System.Drawing.Point(467, 3);
            this.closeSummary.Name = "closeSummary";
            this.closeSummary.Size = new System.Drawing.Size(63, 23);
            this.closeSummary.TabIndex = 198;
            this.closeSummary.Text = "Close";
            this.closeSummary.UseVisualStyleBackColor = true;
            this.closeSummary.Click += new System.EventHandler(this.closeSummary_Click);
            // 
            // checkboxPanel
            // 
            this.checkboxPanel.BackgroundImage = global::Liquid.Properties.Resources.Check_mark;
            this.checkboxPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.checkboxPanel.Location = new System.Drawing.Point(467, 31);
            this.checkboxPanel.Name = "checkboxPanel";
            this.checkboxPanel.Size = new System.Drawing.Size(63, 67);
            this.checkboxPanel.TabIndex = 197;
            this.checkboxPanel.Visible = false;
            // 
            // completedEmailsLabel
            // 
            this.completedEmailsLabel.AutoSize = true;
            this.completedEmailsLabel.Location = new System.Drawing.Point(464, 104);
            this.completedEmailsLabel.Name = "completedEmailsLabel";
            this.completedEmailsLabel.Size = new System.Drawing.Size(28, 13);
            this.completedEmailsLabel.TabIndex = 195;
            this.completedEmailsLabel.Text = "###";
            this.completedEmailsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // totalCountLabel
            // 
            this.totalCountLabel.AutoSize = true;
            this.totalCountLabel.Location = new System.Drawing.Point(502, 114);
            this.totalCountLabel.Name = "totalCountLabel";
            this.totalCountLabel.Size = new System.Drawing.Size(28, 13);
            this.totalCountLabel.TabIndex = 194;
            this.totalCountLabel.Text = "###";
            this.totalCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(203, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(163, 42);
            this.label4.TabIndex = 193;
            this.label4.Text = "Bullhorn";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 15);
            this.label1.TabIndex = 192;
            this.label1.Text = "Powered by";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackgroundImage = global::Liquid.Properties.Resources.Bullhorn_loogoe;
            this.flowLayoutPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(107, 8);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(90, 90);
            this.flowLayoutPanel1.TabIndex = 191;
            // 
            // progress
            // 
            this.progress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.progress.Location = new System.Drawing.Point(11, 104);
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(447, 23);
            this.progress.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(486, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 29);
            this.label5.TabIndex = 196;
            this.label5.Text = "/";
            // 
            // cmdProcess
            // 
            this.cmdProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdProcess.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cmdProcess.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdProcess.Image = global::Liquid.Properties.Resources.import24;
            this.cmdProcess.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdProcess.Location = new System.Drawing.Point(1046, 645);
            this.cmdProcess.Name = "cmdProcess";
            this.cmdProcess.Size = new System.Drawing.Size(92, 42);
            this.cmdProcess.TabIndex = 201;
            this.cmdProcess.Text = "Process";
            this.cmdProcess.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdProcess.UseVisualStyleBackColor = true;
            this.cmdProcess.Click += new System.EventHandler(this.cmdProcess_Click_1);
            // 
            // gbFilter
            // 
            this.gbFilter.Controls.Add(this.txtCustomer);
            this.gbFilter.Controls.Add(this.selCustLetter);
            this.gbFilter.Controls.Add(this.label3);
            this.gbFilter.Controls.Add(this.dtDocDateTo);
            this.gbFilter.Controls.Add(this.label2);
            this.gbFilter.Controls.Add(this.cmdCustomerTo);
            this.gbFilter.Controls.Add(this.txtCustomerTo);
            this.gbFilter.Controls.Add(this.lblOrderType);
            this.gbFilter.Controls.Add(this.lblCustomer);
            this.gbFilter.Controls.Add(this.cmdFilter);
            this.gbFilter.Controls.Add(this.cmdCustomer);
            this.gbFilter.Location = new System.Drawing.Point(14, 14);
            this.gbFilter.Margin = new System.Windows.Forms.Padding(5);
            this.gbFilter.Name = "gbFilter";
            this.gbFilter.Size = new System.Drawing.Size(382, 107);
            this.gbFilter.TabIndex = 197;
            this.gbFilter.TabStop = false;
            this.gbFilter.Text = "Filter Results";
            // 
            // txtCustomer
            // 
            this.txtCustomer.BackColor = System.Drawing.SystemColors.Control;
            this.txtCustomer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustomer.Location = new System.Drawing.Point(88, 19);
            this.txtCustomer.MaxLength = 16;
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Size = new System.Drawing.Size(97, 20);
            this.txtCustomer.TabIndex = 160;
            // 
            // selCustLetter
            // 
            this.selCustLetter.FormattingEnabled = true;
            this.selCustLetter.Items.AddRange(new object[] {
            "All",
            "0-9",
            "A",
            "B",
            "C",
            "D",
            "E",
            "F",
            "G",
            "H",
            "I",
            "J",
            "K",
            "L",
            "M",
            "N",
            "O",
            "P",
            "Q",
            "R",
            "S",
            "T",
            "U",
            "V",
            "W",
            "X",
            "Y",
            "Z"});
            this.selCustLetter.Location = new System.Drawing.Point(88, 52);
            this.selCustLetter.Name = "selCustLetter";
            this.selCustLetter.Size = new System.Drawing.Size(97, 21);
            this.selCustLetter.TabIndex = 162;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 170;
            this.label3.Text = "Doc Date From";
            // 
            // dtDocDateTo
            // 
            this.dtDocDateTo.CustomFormat = "dd/MM/yyyy";
            this.dtDocDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDocDateTo.Location = new System.Drawing.Point(88, 79);
            this.dtDocDateTo.Name = "dtDocDateTo";
            this.dtDocDateTo.Size = new System.Drawing.Size(97, 20);
            this.dtDocDateTo.TabIndex = 163;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(221, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 168;
            this.label2.Text = "To:";
            // 
            // cmdCustomerTo
            // 
            this.cmdCustomerTo.BackColor = System.Drawing.Color.White;
            this.cmdCustomerTo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdCustomerTo.Image = ((System.Drawing.Image)(resources.GetObject("cmdCustomerTo.Image")));
            this.cmdCustomerTo.Location = new System.Drawing.Point(353, 17);
            this.cmdCustomerTo.Name = "cmdCustomerTo";
            this.cmdCustomerTo.Size = new System.Drawing.Size(25, 23);
            this.cmdCustomerTo.TabIndex = 166;
            this.cmdCustomerTo.UseVisualStyleBackColor = false;
            this.cmdCustomerTo.Click += new System.EventHandler(this.cmdCustomerTo_Click);
            // 
            // txtCustomerTo
            // 
            this.txtCustomerTo.BackColor = System.Drawing.SystemColors.Control;
            this.txtCustomerTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustomerTo.Location = new System.Drawing.Point(256, 19);
            this.txtCustomerTo.MaxLength = 16;
            this.txtCustomerTo.Name = "txtCustomerTo";
            this.txtCustomerTo.Size = new System.Drawing.Size(97, 20);
            this.txtCustomerTo.TabIndex = 161;
            // 
            // lblOrderType
            // 
            this.lblOrderType.AutoSize = true;
            this.lblOrderType.Location = new System.Drawing.Point(7, 54);
            this.lblOrderType.Name = "lblOrderType";
            this.lblOrderType.Size = new System.Drawing.Size(54, 13);
            this.lblOrderType.TabIndex = 162;
            this.lblOrderType.Text = "Customer:";
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Location = new System.Drawing.Point(8, 22);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(80, 13);
            this.lblCustomer.TabIndex = 161;
            this.lblCustomer.Text = "Customer From:";
            // 
            // cmdFilter
            // 
            this.cmdFilter.Location = new System.Drawing.Point(300, 77);
            this.cmdFilter.Name = "cmdFilter";
            this.cmdFilter.Size = new System.Drawing.Size(72, 23);
            this.cmdFilter.TabIndex = 164;
            this.cmdFilter.Text = "Filter";
            this.cmdFilter.UseVisualStyleBackColor = true;
            this.cmdFilter.Click += new System.EventHandler(this.cmdFilter_Click);
            // 
            // cmdCustomer
            // 
            this.cmdCustomer.BackColor = System.Drawing.Color.White;
            this.cmdCustomer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdCustomer.Image = ((System.Drawing.Image)(resources.GetObject("cmdCustomer.Image")));
            this.cmdCustomer.Location = new System.Drawing.Point(185, 17);
            this.cmdCustomer.Name = "cmdCustomer";
            this.cmdCustomer.Size = new System.Drawing.Size(25, 23);
            this.cmdCustomer.TabIndex = 159;
            this.cmdCustomer.UseVisualStyleBackColor = false;
            this.cmdCustomer.Click += new System.EventHandler(this.cmdCustomer_Click);
            // 
            // dgInvoiceList
            // 
            this.dgInvoiceList.AllowUserToAddRows = false;
            this.dgInvoiceList.AllowUserToOrderColumns = true;
            this.dgInvoiceList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgInvoiceList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clCustomerCode,
            this.clInvoiceNr,
            this.clInvoiceDate,
            this.clEmailAddress,
            this.clFaxNumber,
            this.clEmailSent,
            this.clFaxSent,
            this.clSendEmail,
            this.clSendFax,
            this.clPrintInvoice});
            this.dgInvoiceList.Location = new System.Drawing.Point(12, 128);
            this.dgInvoiceList.Name = "dgInvoiceList";
            this.dgInvoiceList.RowHeadersVisible = false;
            this.dgInvoiceList.Size = new System.Drawing.Size(1126, 511);
            this.dgInvoiceList.TabIndex = 198;
            // 
            // clCustomerCode
            // 
            this.clCustomerCode.DataPropertyName = "CustomerCode";
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clCustomerCode.DefaultCellStyle = dataGridViewCellStyle1;
            this.clCustomerCode.HeaderText = "Customer";
            this.clCustomerCode.Name = "clCustomerCode";
            this.clCustomerCode.Width = 85;
            // 
            // clInvoiceNr
            // 
            this.clInvoiceNr.DataPropertyName = "InvoiceNumber";
            this.clInvoiceNr.HeaderText = "Invoice";
            this.clInvoiceNr.Name = "clInvoiceNr";
            this.clInvoiceNr.Width = 85;
            // 
            // clInvoiceDate
            // 
            this.clInvoiceDate.DataPropertyName = "InvoiceDate";
            dataGridViewCellStyle2.Format = "yyyy-MM-dd";
            dataGridViewCellStyle2.NullValue = null;
            this.clInvoiceDate.DefaultCellStyle = dataGridViewCellStyle2;
            this.clInvoiceDate.HeaderText = "Invoice Date";
            this.clInvoiceDate.Name = "clInvoiceDate";
            this.clInvoiceDate.Width = 150;
            // 
            // clEmailAddress
            // 
            this.clEmailAddress.DataPropertyName = "EmailAddress";
            this.clEmailAddress.HeaderText = "Email Address";
            this.clEmailAddress.Name = "clEmailAddress";
            this.clEmailAddress.Width = 225;
            // 
            // clFaxNumber
            // 
            this.clFaxNumber.HeaderText = "Fax Number";
            this.clFaxNumber.Name = "clFaxNumber";
            this.clFaxNumber.Visible = false;
            // 
            // clEmailSent
            // 
            this.clEmailSent.DataPropertyName = "EmailSent";
            this.clEmailSent.HeaderText = "Email Sent?";
            this.clEmailSent.Image = global::Liquid.Properties.Resources.delete21;
            this.clEmailSent.Name = "clEmailSent";
            this.clEmailSent.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // clFaxSent
            // 
            this.clFaxSent.HeaderText = "Fax Sent?";
            this.clFaxSent.Image = global::Liquid.Properties.Resources.delete21;
            this.clFaxSent.Name = "clFaxSent";
            this.clFaxSent.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clFaxSent.Visible = false;
            // 
            // clSendEmail
            // 
            this.clSendEmail.DataPropertyName = "ResendEmail";
            this.clSendEmail.FalseValue = "0";
            this.clSendEmail.HeaderText = "Send/Resend Email";
            this.clSendEmail.IndeterminateValue = "0";
            this.clSendEmail.Name = "clSendEmail";
            this.clSendEmail.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clSendEmail.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.clSendEmail.TrueValue = "1";
            this.clSendEmail.Width = 125;
            // 
            // clSendFax
            // 
            this.clSendFax.FalseValue = "0";
            this.clSendFax.HeaderText = "Send/Resend Fax";
            this.clSendFax.IndeterminateValue = "0";
            this.clSendFax.Name = "clSendFax";
            this.clSendFax.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clSendFax.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.clSendFax.TrueValue = "1";
            this.clSendFax.Visible = false;
            this.clSendFax.Width = 125;
            // 
            // clPrintInvoice
            // 
            this.clPrintInvoice.DataPropertyName = "PrintInvoice";
            this.clPrintInvoice.FalseValue = "0";
            this.clPrintInvoice.HeaderText = "Print Invoice";
            this.clPrintInvoice.IndeterminateValue = "0";
            this.clPrintInvoice.Name = "clPrintInvoice";
            this.clPrintInvoice.TrueValue = "1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkMergeEmails);
            this.groupBox1.Controls.Add(this.chkAllPrint);
            this.groupBox1.Controls.Add(this.chkAllEmail);
            this.groupBox1.Location = new System.Drawing.Point(928, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(210, 105);
            this.groupBox1.TabIndex = 200;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // chkMergeEmails
            // 
            this.chkMergeEmails.AutoSize = true;
            this.chkMergeEmails.Location = new System.Drawing.Point(19, 68);
            this.chkMergeEmails.Name = "chkMergeEmails";
            this.chkMergeEmails.Size = new System.Drawing.Size(89, 17);
            this.chkMergeEmails.TabIndex = 182;
            this.chkMergeEmails.Text = "Merge Emails";
            this.chkMergeEmails.UseVisualStyleBackColor = true;
            // 
            // chkAllPrint
            // 
            this.chkAllPrint.AutoSize = true;
            this.chkAllPrint.Checked = true;
            this.chkAllPrint.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAllPrint.Location = new System.Drawing.Point(19, 44);
            this.chkAllPrint.Name = "chkAllPrint";
            this.chkAllPrint.Size = new System.Drawing.Size(136, 17);
            this.chkAllPrint.TabIndex = 181;
            this.chkAllPrint.Text = "Check / Uncheck Print";
            this.chkAllPrint.UseVisualStyleBackColor = true;
            this.chkAllPrint.CheckedChanged += new System.EventHandler(this.chkAllPrint_CheckedChanged);
            // 
            // chkAllEmail
            // 
            this.chkAllEmail.AutoSize = true;
            this.chkAllEmail.Checked = true;
            this.chkAllEmail.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAllEmail.Location = new System.Drawing.Point(19, 21);
            this.chkAllEmail.Name = "chkAllEmail";
            this.chkAllEmail.Size = new System.Drawing.Size(145, 17);
            this.chkAllEmail.TabIndex = 179;
            this.chkAllEmail.Text = "Check / Uncheck Emails";
            this.chkAllEmail.UseVisualStyleBackColor = true;
            this.chkAllEmail.CheckedChanged += new System.EventHandler(this.chkAllEmail_CheckedChanged);
            // 
            // EmailAndFaxSend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1150, 690);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.cmdProcess);
            this.Controls.Add(this.gbFilter);
            this.Controls.Add(this.dgInvoiceList);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "EmailAndFaxSend";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Invoice Email Manager";
            this.Load += new System.EventHandler(this.EmailAndFaxSend_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.progressBar.ResumeLayout(false);
            this.progressBar.PerformLayout();
            this.gbFilter.ResumeLayout(false);
            this.gbFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgInvoiceList)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn3;
        private System.Windows.Forms.Timer progressBarTimer;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button addNote;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button AddAttachments;
        private System.Windows.Forms.ListBox lbAttachments;
        private System.Windows.Forms.Panel progressBar;
        private System.Windows.Forms.Button closeSummary;
        private System.Windows.Forms.FlowLayoutPanel checkboxPanel;
        private System.Windows.Forms.Label completedEmailsLabel;
        private System.Windows.Forms.Label totalCountLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.ProgressBar progress;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button cmdProcess;
        private System.Windows.Forms.GroupBox gbFilter;
        private System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.ComboBox selCustLetter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtDocDateTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cmdCustomerTo;
        private System.Windows.Forms.TextBox txtCustomerTo;
        private System.Windows.Forms.Label lblOrderType;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.Button cmdFilter;
        private System.Windows.Forms.Button cmdCustomer;
        private System.Windows.Forms.DataGridView dgInvoiceList;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkAllPrint;
        private System.Windows.Forms.CheckBox chkAllEmail;
        private System.Windows.Forms.ListBox lbNotes;
        private System.Windows.Forms.CheckBox chkMergeEmails;
        private System.Windows.Forms.DataGridViewTextBoxColumn clCustomerCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clInvoiceNr;
        private System.Windows.Forms.DataGridViewTextBoxColumn clInvoiceDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clEmailAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn clFaxNumber;
        private System.Windows.Forms.DataGridViewImageColumn clEmailSent;
        private System.Windows.Forms.DataGridViewImageColumn clFaxSent;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clSendEmail;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clSendFax;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clPrintInvoice;
    }
}