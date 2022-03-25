namespace Liquid.Forms
{
    partial class MonthEndProcessings
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MonthEndProcessings));
            this.dgOpenSalesOrder = new System.Windows.Forms.DataGridView();
            this.clSalesOrderNum = new System.Windows.Forms.DataGridViewLinkColumn();
            this.LockedStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clClient = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clConsolidateNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clSalesOrderDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clLastInvoiceDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clSalesOrderStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clPreview = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chkInvoice = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.chkOffHire = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.txtOffHireStartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtOffHireEndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chkClose = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cmdFilter = new System.Windows.Forms.Button();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.gbFilter = new System.Windows.Forms.GroupBox();
            this.selCustLetter = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtDocDateTo = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdCustomerTo = new System.Windows.Forms.Button();
            this.txtCustomerTo = new System.Windows.Forms.TextBox();
            this.cmdCustomer = new System.Windows.Forms.Button();
            this.chkAllInvoice = new System.Windows.Forms.CheckBox();
            this.lblInvoicedate = new System.Windows.Forms.Label();
            this.dtInvoiceUpToDate = new System.Windows.Forms.DateTimePicker();
            this.cmdGenerateInvoices = new System.Windows.Forms.Button();
            this.lblCurrPerEnd = new System.Windows.Forms.Label();
            this.selPeriodEnd = new System.Windows.Forms.ComboBox();
            this.lblFixedCurrPerEnd = new System.Windows.Forms.Label();
            this.dtCurrPeriodStart = new System.Windows.Forms.DateTimePicker();
            this.dtCurrPeriodEnd = new System.Windows.Forms.DateTimePicker();
            this.dtInvoiceDate = new System.Windows.Forms.DateTimePicker();
            this.lblInvDate = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.ctxBulkInvoiceGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmOffHire = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmCancelOffHire = new System.Windows.Forms.ToolStripMenuItem();
            this.label8 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.progressBarText = new System.Windows.Forms.Label();
            this.lblSelectCount = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.chkViewLockedItems = new System.Windows.Forms.CheckBox();
            this.chkInvoicedThisPeriod = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_offHire = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgOpenSalesOrder)).BeginInit();
            this.gbFilter.SuspendLayout();
            this.ctxBulkInvoiceGrid.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgOpenSalesOrder
            // 
            this.dgOpenSalesOrder.AllowUserToAddRows = false;
            this.dgOpenSalesOrder.AllowUserToDeleteRows = false;
            this.dgOpenSalesOrder.AllowUserToResizeColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgOpenSalesOrder.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgOpenSalesOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgOpenSalesOrder.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clSalesOrderNum,
            this.LockedStatus,
            this.clClient,
            this.clConsolidateNumber,
            this.clSalesOrderDate,
            this.clLastInvoiceDate,
            this.clSalesOrderStatus,
            this.clPreview,
            this.chkInvoice,
            this.chkOffHire,
            this.txtOffHireStartDate,
            this.txtOffHireEndDate,
            this.chkClose});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgOpenSalesOrder.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgOpenSalesOrder.Location = new System.Drawing.Point(13, 90);
            this.dgOpenSalesOrder.Name = "dgOpenSalesOrder";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgOpenSalesOrder.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgOpenSalesOrder.RowHeadersVisible = false;
            this.dgOpenSalesOrder.RowHeadersWidth = 51;
            this.dgOpenSalesOrder.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgOpenSalesOrder.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgOpenSalesOrder.Size = new System.Drawing.Size(904, 431);
            this.dgOpenSalesOrder.TabIndex = 0;
            this.dgOpenSalesOrder.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgOpenSalesOrder_CellClick);
            this.dgOpenSalesOrder.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgOpenSalesOrder_CellMouseClick);
            this.dgOpenSalesOrder.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgOpenSalesOrder_CellMouseUp);
            this.dgOpenSalesOrder.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgOpenSalesOrder_CellValueChanged_1);
            // 
            // clSalesOrderNum
            // 
            this.clSalesOrderNum.DataPropertyName = "DocumentNumber";
            this.clSalesOrderNum.HeaderText = "Sales Order";
            this.clSalesOrderNum.LinkColor = System.Drawing.Color.White;
            this.clSalesOrderNum.MinimumWidth = 6;
            this.clSalesOrderNum.Name = "clSalesOrderNum";
            this.clSalesOrderNum.ReadOnly = true;
            this.clSalesOrderNum.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clSalesOrderNum.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.clSalesOrderNum.Width = 105;
            // 
            // LockedStatus
            // 
            this.LockedStatus.DataPropertyName = "LockedStatus";
            this.LockedStatus.HeaderText = "LockedStatus";
            this.LockedStatus.MinimumWidth = 6;
            this.LockedStatus.Name = "LockedStatus";
            this.LockedStatus.Visible = false;
            this.LockedStatus.Width = 125;
            // 
            // clClient
            // 
            this.clClient.DataPropertyName = "CustomerCode";
            this.clClient.HeaderText = "Customer";
            this.clClient.MinimumWidth = 6;
            this.clClient.Name = "clClient";
            this.clClient.ReadOnly = true;
            this.clClient.Width = 125;
            // 
            // clConsolidateNumber
            // 
            this.clConsolidateNumber.DataPropertyName = "ConsolidateNumber";
            this.clConsolidateNumber.HeaderText = "Consolidate Nr";
            this.clConsolidateNumber.MinimumWidth = 6;
            this.clConsolidateNumber.Name = "clConsolidateNumber";
            this.clConsolidateNumber.Width = 125;
            // 
            // clSalesOrderDate
            // 
            this.clSalesOrderDate.DataPropertyName = "DocumentDate";
            this.clSalesOrderDate.HeaderText = "Sales Order Date";
            this.clSalesOrderDate.MinimumWidth = 6;
            this.clSalesOrderDate.Name = "clSalesOrderDate";
            this.clSalesOrderDate.ReadOnly = true;
            this.clSalesOrderDate.Width = 120;
            // 
            // clLastInvoiceDate
            // 
            this.clLastInvoiceDate.DataPropertyName = "LastInvoiceDate";
            this.clLastInvoiceDate.HeaderText = "Last Invoice Date";
            this.clLastInvoiceDate.MinimumWidth = 6;
            this.clLastInvoiceDate.Name = "clLastInvoiceDate";
            this.clLastInvoiceDate.Width = 120;
            // 
            // clSalesOrderStatus
            // 
            this.clSalesOrderStatus.DataPropertyName = "Status";
            this.clSalesOrderStatus.FillWeight = 80F;
            this.clSalesOrderStatus.HeaderText = "Sales Order Status";
            this.clSalesOrderStatus.MinimumWidth = 6;
            this.clSalesOrderStatus.Name = "clSalesOrderStatus";
            this.clSalesOrderStatus.ReadOnly = true;
            this.clSalesOrderStatus.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clSalesOrderStatus.Width = 120;
            // 
            // clPreview
            // 
            this.clPreview.DataPropertyName = "Preview";
            this.clPreview.HeaderText = "Preview";
            this.clPreview.MinimumWidth = 6;
            this.clPreview.Name = "clPreview";
            this.clPreview.ReadOnly = true;
            this.clPreview.Width = 125;
            // 
            // chkInvoice
            // 
            this.chkInvoice.DataPropertyName = "Invoice";
            this.chkInvoice.FalseValue = "false";
            this.chkInvoice.HeaderText = "Invoice?";
            this.chkInvoice.IndeterminateValue = "";
            this.chkInvoice.MinimumWidth = 6;
            this.chkInvoice.Name = "chkInvoice";
            this.chkInvoice.TrueValue = "true";
            this.chkInvoice.Width = 50;
            // 
            // chkOffHire
            // 
            this.chkOffHire.DataPropertyName = "HasCustomOffHire";
            this.chkOffHire.FalseValue = "false";
            this.chkOffHire.HeaderText = "Has Offhire";
            this.chkOffHire.MinimumWidth = 6;
            this.chkOffHire.Name = "chkOffHire";
            this.chkOffHire.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.chkOffHire.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.chkOffHire.TrueValue = "true";
            this.chkOffHire.Visible = false;
            this.chkOffHire.Width = 125;
            // 
            // txtOffHireStartDate
            // 
            this.txtOffHireStartDate.DataPropertyName = "OffHireStartDate";
            this.txtOffHireStartDate.HeaderText = "Off Hire Start Date";
            this.txtOffHireStartDate.MinimumWidth = 6;
            this.txtOffHireStartDate.Name = "txtOffHireStartDate";
            this.txtOffHireStartDate.Visible = false;
            this.txtOffHireStartDate.Width = 125;
            // 
            // txtOffHireEndDate
            // 
            this.txtOffHireEndDate.DataPropertyName = "OffHireEndDate";
            this.txtOffHireEndDate.HeaderText = "Off Hire End Date";
            this.txtOffHireEndDate.MinimumWidth = 6;
            this.txtOffHireEndDate.Name = "txtOffHireEndDate";
            this.txtOffHireEndDate.Visible = false;
            this.txtOffHireEndDate.Width = 125;
            // 
            // chkClose
            // 
            this.chkClose.DataPropertyName = "Close";
            this.chkClose.HeaderText = "Close";
            this.chkClose.MinimumWidth = 6;
            this.chkClose.Name = "chkClose";
            this.chkClose.Visible = false;
            this.chkClose.Width = 125;
            // 
            // cmdFilter
            // 
            this.cmdFilter.Location = new System.Drawing.Point(366, 19);
            this.cmdFilter.Name = "cmdFilter";
            this.cmdFilter.Size = new System.Drawing.Size(75, 50);
            this.cmdFilter.TabIndex = 4;
            this.cmdFilter.Text = "Filter";
            this.cmdFilter.UseVisualStyleBackColor = true;
            this.cmdFilter.Click += new System.EventHandler(this.cmdFilter_Click);
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
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Location = new System.Drawing.Point(8, 22);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(80, 13);
            this.lblCustomer.TabIndex = 161;
            this.lblCustomer.Text = "Customer From:";
            // 
            // gbFilter
            // 
            this.gbFilter.Controls.Add(this.selCustLetter);
            this.gbFilter.Controls.Add(this.label3);
            this.gbFilter.Controls.Add(this.dtDocDateTo);
            this.gbFilter.Controls.Add(this.label2);
            this.gbFilter.Controls.Add(this.cmdCustomerTo);
            this.gbFilter.Controls.Add(this.txtCustomerTo);
            this.gbFilter.Controls.Add(this.lblCustomer);
            this.gbFilter.Controls.Add(this.cmdFilter);
            this.gbFilter.Controls.Add(this.cmdCustomer);
            this.gbFilter.Controls.Add(this.txtCustomer);
            this.gbFilter.Location = new System.Drawing.Point(13, 9);
            this.gbFilter.Margin = new System.Windows.Forms.Padding(5);
            this.gbFilter.Name = "gbFilter";
            this.gbFilter.Size = new System.Drawing.Size(449, 75);
            this.gbFilter.TabIndex = 162;
            this.gbFilter.TabStop = false;
            this.gbFilter.Text = "Filter Results";
            // 
            // selCustLetter
            // 
            this.selCustLetter.FormattingEnabled = true;
            this.selCustLetter.Items.AddRange(new object[] {
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
            this.selCustLetter.Location = new System.Drawing.Point(239, 48);
            this.selCustLetter.Name = "selCustLetter";
            this.selCustLetter.Size = new System.Drawing.Size(119, 21);
            this.selCustLetter.TabIndex = 171;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 170;
            this.label3.Text = "Doc Date To:";
            // 
            // dtDocDateTo
            // 
            this.dtDocDateTo.CustomFormat = "dd/MM/yyyy";
            this.dtDocDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDocDateTo.Location = new System.Drawing.Point(88, 48);
            this.dtDocDateTo.Name = "dtDocDateTo";
            this.dtDocDateTo.Size = new System.Drawing.Size(118, 20);
            this.dtDocDateTo.TabIndex = 169;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(210, 22);
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
            this.cmdCustomerTo.Location = new System.Drawing.Point(333, 17);
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
            this.txtCustomerTo.Location = new System.Drawing.Point(239, 19);
            this.txtCustomerTo.MaxLength = 16;
            this.txtCustomerTo.Name = "txtCustomerTo";
            this.txtCustomerTo.Size = new System.Drawing.Size(97, 20);
            this.txtCustomerTo.TabIndex = 167;
            // 
            // cmdCustomer
            // 
            this.cmdCustomer.BackColor = System.Drawing.Color.White;
            this.cmdCustomer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdCustomer.Image = ((System.Drawing.Image)(resources.GetObject("cmdCustomer.Image")));
            this.cmdCustomer.Location = new System.Drawing.Point(181, 17);
            this.cmdCustomer.Name = "cmdCustomer";
            this.cmdCustomer.Size = new System.Drawing.Size(25, 23);
            this.cmdCustomer.TabIndex = 159;
            this.cmdCustomer.UseVisualStyleBackColor = false;
            this.cmdCustomer.Click += new System.EventHandler(this.cmdCustomer_Click);
            // 
            // chkAllInvoice
            // 
            this.chkAllInvoice.AutoSize = true;
            this.chkAllInvoice.Location = new System.Drawing.Point(822, 70);
            this.chkAllInvoice.Name = "chkAllInvoice";
            this.chkAllInvoice.Size = new System.Drawing.Size(15, 14);
            this.chkAllInvoice.TabIndex = 0;
            this.chkAllInvoice.UseVisualStyleBackColor = true;
            this.chkAllInvoice.CheckedChanged += new System.EventHandler(this.chkAllInvoice_CheckedChanged);
            // 
            // lblInvoicedate
            // 
            this.lblInvoicedate.AutoSize = true;
            this.lblInvoicedate.Location = new System.Drawing.Point(935, 54);
            this.lblInvoicedate.Name = "lblInvoicedate";
            this.lblInvoicedate.Size = new System.Drawing.Size(128, 13);
            this.lblInvoicedate.TabIndex = 164;
            this.lblInvoicedate.Text = "Invoices sales lines up to:";
            this.lblInvoicedate.Visible = false;
            // 
            // dtInvoiceUpToDate
            // 
            this.dtInvoiceUpToDate.Location = new System.Drawing.Point(1069, 51);
            this.dtInvoiceUpToDate.Name = "dtInvoiceUpToDate";
            this.dtInvoiceUpToDate.Size = new System.Drawing.Size(150, 20);
            this.dtInvoiceUpToDate.TabIndex = 165;
            this.dtInvoiceUpToDate.Visible = false;
            // 
            // cmdGenerateInvoices
            // 
            this.cmdGenerateInvoices.Location = new System.Drawing.Point(768, 533);
            this.cmdGenerateInvoices.Name = "cmdGenerateInvoices";
            this.cmdGenerateInvoices.Size = new System.Drawing.Size(128, 56);
            this.cmdGenerateInvoices.TabIndex = 166;
            this.cmdGenerateInvoices.Text = "Generate Invoices";
            this.cmdGenerateInvoices.UseVisualStyleBackColor = true;
            this.cmdGenerateInvoices.Click += new System.EventHandler(this.cmdGenerateInvoices_Click);
            // 
            // lblCurrPerEnd
            // 
            this.lblCurrPerEnd.AutoSize = true;
            this.lblCurrPerEnd.Location = new System.Drawing.Point(21, 536);
            this.lblCurrPerEnd.Name = "lblCurrPerEnd";
            this.lblCurrPerEnd.Size = new System.Drawing.Size(62, 13);
            this.lblCurrPerEnd.TabIndex = 167;
            this.lblCurrPerEnd.Text = "Period End:";
            // 
            // selPeriodEnd
            // 
            this.selPeriodEnd.FormattingEnabled = true;
            this.selPeriodEnd.Location = new System.Drawing.Point(98, 533);
            this.selPeriodEnd.MaxDropDownItems = 50;
            this.selPeriodEnd.Name = "selPeriodEnd";
            this.selPeriodEnd.Size = new System.Drawing.Size(121, 21);
            this.selPeriodEnd.TabIndex = 168;
            this.selPeriodEnd.SelectedIndexChanged += new System.EventHandler(this.selPeriodEnd_SelectedIndexChanged);
            // 
            // lblFixedCurrPerEnd
            // 
            this.lblFixedCurrPerEnd.AutoSize = true;
            this.lblFixedCurrPerEnd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblFixedCurrPerEnd.Location = new System.Drawing.Point(632, 16);
            this.lblFixedCurrPerEnd.Name = "lblFixedCurrPerEnd";
            this.lblFixedCurrPerEnd.Size = new System.Drawing.Size(102, 13);
            this.lblFixedCurrPerEnd.TabIndex = 169;
            this.lblFixedCurrPerEnd.Text = "Current Period End: ";
            // 
            // dtCurrPeriodStart
            // 
            this.dtCurrPeriodStart.Location = new System.Drawing.Point(938, 90);
            this.dtCurrPeriodStart.Name = "dtCurrPeriodStart";
            this.dtCurrPeriodStart.Size = new System.Drawing.Size(150, 20);
            this.dtCurrPeriodStart.TabIndex = 170;
            this.dtCurrPeriodStart.Visible = false;
            // 
            // dtCurrPeriodEnd
            // 
            this.dtCurrPeriodEnd.Location = new System.Drawing.Point(1091, 90);
            this.dtCurrPeriodEnd.Name = "dtCurrPeriodEnd";
            this.dtCurrPeriodEnd.Size = new System.Drawing.Size(150, 20);
            this.dtCurrPeriodEnd.TabIndex = 171;
            this.dtCurrPeriodEnd.Visible = false;
            // 
            // dtInvoiceDate
            // 
            this.dtInvoiceDate.CustomFormat = "dd MMM yyyy";
            this.dtInvoiceDate.Location = new System.Drawing.Point(1069, 24);
            this.dtInvoiceDate.Name = "dtInvoiceDate";
            this.dtInvoiceDate.Size = new System.Drawing.Size(150, 20);
            this.dtInvoiceDate.TabIndex = 173;
            this.dtInvoiceDate.Visible = false;
            // 
            // lblInvDate
            // 
            this.lblInvDate.AutoSize = true;
            this.lblInvDate.Location = new System.Drawing.Point(935, 30);
            this.lblInvDate.Name = "lblInvDate";
            this.lblInvDate.Size = new System.Drawing.Size(72, 13);
            this.lblInvDate.TabIndex = 172;
            this.lblInvDate.Text = "Invoice date :";
            this.lblInvDate.Visible = false;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Lime;
            this.panel3.Location = new System.Drawing.Point(473, 16);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(25, 14);
            this.panel3.TabIndex = 185;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(506, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 12);
            this.label7.TabIndex = 186;
            this.label7.Text = "- Off-Hire";
            // 
            // ctxBulkInvoiceGrid
            // 
            this.ctxBulkInvoiceGrid.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ctxBulkInvoiceGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmOffHire,
            this.tsmCancelOffHire});
            this.ctxBulkInvoiceGrid.Name = "ctxBulkInvoiceGrid";
            this.ctxBulkInvoiceGrid.Size = new System.Drawing.Size(158, 48);
            this.ctxBulkInvoiceGrid.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.ctxBulkInvoiceGrid_ItemClicked);
            // 
            // tsmOffHire
            // 
            this.tsmOffHire.Name = "tsmOffHire";
            this.tsmOffHire.Size = new System.Drawing.Size(157, 22);
            this.tsmOffHire.Text = "Add Off-Hire";
            // 
            // tsmCancelOffHire
            // 
            this.tsmCancelOffHire.Name = "tsmCancelOffHire";
            this.tsmCancelOffHire.Size = new System.Drawing.Size(157, 22);
            this.tsmCancelOffHire.Text = "Cancel Off-Hire";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(506, 51);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 188;
            this.label8.Text = "- Locked Order";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Black;
            this.panel4.Location = new System.Drawing.Point(473, 51);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(25, 14);
            this.panel4.TabIndex = 187;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(506, 34);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 12);
            this.label9.TabIndex = 190;
            this.label9.Text = "- Future Off-Hire";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.LimeGreen;
            this.panel5.Location = new System.Drawing.Point(473, 34);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(25, 14);
            this.panel5.TabIndex = 189;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "Status";
            this.dataGridViewImageColumn1.Image = ((System.Drawing.Image)(resources.GetObject("dataGridViewImageColumn1.Image")));
            this.dataGridViewImageColumn1.MinimumWidth = 6;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewImageColumn1.Width = 80;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(13, 566);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(749, 23);
            this.progressBar1.TabIndex = 191;
            // 
            // progressBarText
            // 
            this.progressBarText.AutoSize = true;
            this.progressBarText.Location = new System.Drawing.Point(419, 550);
            this.progressBarText.Name = "progressBarText";
            this.progressBarText.Size = new System.Drawing.Size(0, 13);
            this.progressBarText.TabIndex = 192;
            // 
            // lblSelectCount
            // 
            this.lblSelectCount.Location = new System.Drawing.Point(812, 50);
            this.lblSelectCount.Name = "lblSelectCount";
            this.lblSelectCount.Size = new System.Drawing.Size(33, 17);
            this.lblSelectCount.TabIndex = 193;
            this.lblSelectCount.Text = "0";
            this.lblSelectCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Indigo;
            this.panel6.Location = new System.Drawing.Point(473, 68);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(25, 14);
            this.panel6.TabIndex = 190;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(506, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 12);
            this.label1.TabIndex = 194;
            this.label1.Text = "- Invoiced this period";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(859, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 12);
            this.label4.TabIndex = 195;
            this.label4.Text = "- Select All";
            // 
            // chkViewLockedItems
            // 
            this.chkViewLockedItems.AutoSize = true;
            this.chkViewLockedItems.Location = new System.Drawing.Point(635, 52);
            this.chkViewLockedItems.Name = "chkViewLockedItems";
            this.chkViewLockedItems.Size = new System.Drawing.Size(15, 14);
            this.chkViewLockedItems.TabIndex = 196;
            this.chkViewLockedItems.UseVisualStyleBackColor = true;
            this.chkViewLockedItems.CheckedChanged += new System.EventHandler(this.chkViewLockedItems_CheckedChanged);
            // 
            // chkInvoicedThisPeriod
            // 
            this.chkInvoicedThisPeriod.AutoSize = true;
            this.chkInvoicedThisPeriod.Checked = true;
            this.chkInvoicedThisPeriod.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkInvoicedThisPeriod.Location = new System.Drawing.Point(635, 70);
            this.chkInvoicedThisPeriod.Name = "chkInvoicedThisPeriod";
            this.chkInvoicedThisPeriod.Size = new System.Drawing.Size(15, 14);
            this.chkInvoicedThisPeriod.TabIndex = 197;
            this.chkInvoicedThisPeriod.UseVisualStyleBackColor = true;
            this.chkInvoicedThisPeriod.CheckedChanged += new System.EventHandler(this.chkInvoicedThisPeriod_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(859, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 198;
            this.label5.Text = "- # Invoices";
            // 
            // btn_offHire
            // 
            this.btn_offHire.Location = new System.Drawing.Point(812, 11);
            this.btn_offHire.Name = "btn_offHire";
            this.btn_offHire.Size = new System.Drawing.Size(105, 33);
            this.btn_offHire.TabIndex = 199;
            this.btn_offHire.Text = "Temp Off Hire";
            this.btn_offHire.UseVisualStyleBackColor = true;
            this.btn_offHire.Click += new System.EventHandler(this.btn_offHireReport_Click);
            // 
            // MonthEndProcessings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 593);
            this.Controls.Add(this.btn_offHire);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.chkInvoicedThisPeriod);
            this.Controls.Add(this.chkViewLockedItems);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.lblSelectCount);
            this.Controls.Add(this.progressBarText);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.chkAllInvoice);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.dgOpenSalesOrder);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.dtInvoiceDate);
            this.Controls.Add(this.lblInvDate);
            this.Controls.Add(this.dtCurrPeriodEnd);
            this.Controls.Add(this.dtCurrPeriodStart);
            this.Controls.Add(this.lblFixedCurrPerEnd);
            this.Controls.Add(this.selPeriodEnd);
            this.Controls.Add(this.lblCurrPerEnd);
            this.Controls.Add(this.cmdGenerateInvoices);
            this.Controls.Add(this.dtInvoiceUpToDate);
            this.Controls.Add(this.lblInvoicedate);
            this.Controls.Add(this.gbFilter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MonthEndProcessings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Month End Processings";
            this.Load += new System.EventHandler(this.MonthEndProcessings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgOpenSalesOrder)).EndInit();
            this.gbFilter.ResumeLayout(false);
            this.gbFilter.PerformLayout();
            this.ctxBulkInvoiceGrid.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgOpenSalesOrder;
        private System.Windows.Forms.Button cmdFilter;
        private System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.Button cmdCustomer;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.GroupBox gbFilter;
        private System.Windows.Forms.CheckBox chkAllInvoice;
        private System.Windows.Forms.Label lblInvoicedate;
        private System.Windows.Forms.DateTimePicker dtInvoiceUpToDate;
        private System.Windows.Forms.Button cmdGenerateInvoices;
        private System.Windows.Forms.Label lblCurrPerEnd;
        private System.Windows.Forms.ComboBox selPeriodEnd;
        private System.Windows.Forms.Label lblFixedCurrPerEnd;
        private System.Windows.Forms.DateTimePicker dtCurrPeriodStart;
        private System.Windows.Forms.DateTimePicker dtCurrPeriodEnd;
        private System.Windows.Forms.DateTimePicker dtInvoiceDate;
        private System.Windows.Forms.Label lblInvDate;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cmdCustomerTo;
        private System.Windows.Forms.TextBox txtCustomerTo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtDocDateTo;
        private System.Windows.Forms.ComboBox selCustLetter;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ContextMenuStrip ctxBulkInvoiceGrid;
        private System.Windows.Forms.ToolStripMenuItem tsmOffHire;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ToolStripMenuItem tsmCancelOffHire;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label progressBarText;
        private System.Windows.Forms.Label lblSelectCount;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkViewLockedItems;
        private System.Windows.Forms.CheckBox chkInvoicedThisPeriod;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewLinkColumn clSalesOrderNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn LockedStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn clClient;
        private System.Windows.Forms.DataGridViewTextBoxColumn clConsolidateNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn clSalesOrderDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clLastInvoiceDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clSalesOrderStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn clPreview;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chkInvoice;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chkOffHire;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtOffHireStartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtOffHireEndDate;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chkClose;
        private System.Windows.Forms.Button btn_offHire;
    }
}
