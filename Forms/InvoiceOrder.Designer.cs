namespace Liquid.Forms
{
    partial class InvoiceOrder
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvoiceOrder));
            this.panel15 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblSalesOrderNumber = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.cmdCreateInvoice = new System.Windows.Forms.Button();
            this.dgInvoiceItems = new System.Windows.Forms.DataGridView();
            this.clNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clItemCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clProjectCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clItemType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDeliveryDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clReturnDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clPeriod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clExValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clInvoice = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clTypeCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlPeriodLabel = new System.Windows.Forms.Panel();
            this.lblOrderNo = new System.Windows.Forms.Label();
            this.pnlDateLabel = new System.Windows.Forms.Panel();
            this.lblDate = new System.Windows.Forms.Label();
            this.pnlPeriodValue = new System.Windows.Forms.Panel();
            this.txtOrderNumber = new System.Windows.Forms.TextBox();
            this.pnlDateValue = new System.Windows.Forms.Panel();
            this.txtInvoiceDate = new System.Windows.Forms.TextBox();
            this.pnlDeliveryDateValue = new System.Windows.Forms.Panel();
            this.txtDeliveryDate = new System.Windows.Forms.TextBox();
            this.pnlSalesCodeLabel = new System.Windows.Forms.Panel();
            this.lblSalesCode = new System.Windows.Forms.Label();
            this.pnlDeliveryDateLabel = new System.Windows.Forms.Panel();
            this.lblDeliveryDate = new System.Windows.Forms.Label();
            this.pnlSalesCodeValue = new System.Windows.Forms.Panel();
            this.cmdSalesPerson = new System.Windows.Forms.Button();
            this.txtSalesCode = new System.Windows.Forms.TextBox();
            this.pnlDiscountLabel = new System.Windows.Forms.Panel();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.pnlDiscountValue = new System.Windows.Forms.Panel();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.cmdSearchCustomer = new System.Windows.Forms.Button();
            this.txtCustomerCode = new System.Windows.Forms.TextBox();
            this.txtCustomerDescription = new System.Windows.Forms.TextBox();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.panel15.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgInvoiceItems)).BeginInit();
            this.pnlPeriodLabel.SuspendLayout();
            this.pnlDateLabel.SuspendLayout();
            this.pnlPeriodValue.SuspendLayout();
            this.pnlDateValue.SuspendLayout();
            this.pnlDeliveryDateValue.SuspendLayout();
            this.pnlSalesCodeLabel.SuspendLayout();
            this.pnlDeliveryDateLabel.SuspendLayout();
            this.pnlSalesCodeValue.SuspendLayout();
            this.pnlDiscountLabel.SuspendLayout();
            this.pnlDiscountValue.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel15
            // 
            this.panel15.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel15.Controls.Add(this.label1);
            this.panel15.Controls.Add(this.lblSalesOrderNumber);
            this.panel15.Controls.Add(this.label21);
            this.panel15.Location = new System.Drawing.Point(12, 12);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(954, 36);
            this.panel15.TabIndex = 44;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(641, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(257, 15);
            this.label1.TabIndex = 10;
            this.label1.Text = " Note that only returned items can be invoiced.";
            // 
            // lblSalesOrderNumber
            // 
            this.lblSalesOrderNumber.AutoSize = true;
            this.lblSalesOrderNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalesOrderNumber.Location = new System.Drawing.Point(185, 7);
            this.lblSalesOrderNumber.Name = "lblSalesOrderNumber";
            this.lblSalesOrderNumber.Size = new System.Drawing.Size(131, 20);
            this.lblSalesOrderNumber.TabIndex = 9;
            this.lblSalesOrderNumber.Text = "SALESORDER";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(12, 7);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(177, 20);
            this.label21.TabIndex = 8;
            this.label21.Text = "Create invoice for order ";
            // 
            // cmdCreateInvoice
            // 
            this.cmdCreateInvoice.BackColor = System.Drawing.Color.Transparent;
            this.cmdCreateInvoice.Enabled = false;
            this.cmdCreateInvoice.Image = global::Liquid.Properties.Resources.replace2;
            this.cmdCreateInvoice.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCreateInvoice.Location = new System.Drawing.Point(859, 511);
            this.cmdCreateInvoice.Name = "cmdCreateInvoice";
            this.cmdCreateInvoice.Size = new System.Drawing.Size(107, 31);
            this.cmdCreateInvoice.TabIndex = 46;
            this.cmdCreateInvoice.Text = "       Create Invoice";
            this.cmdCreateInvoice.UseVisualStyleBackColor = false;
            this.cmdCreateInvoice.Click += new System.EventHandler(this.cmdCreateInvoice_Click);
            // 
            // dgInvoiceItems
            // 
            this.dgInvoiceItems.AllowUserToAddRows = false;
            this.dgInvoiceItems.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgInvoiceItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgInvoiceItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgInvoiceItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clNumber,
            this.clItemCode,
            this.clDescription,
            this.clProjectCode,
            this.clItemType,
            this.clDeliveryDate,
            this.clReturnDate,
            this.clQuantity,
            this.clPeriod,
            this.clUnit,
            this.clExValue,
            this.clInvoice,
            this.clTypeCode});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgInvoiceItems.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgInvoiceItems.Location = new System.Drawing.Point(12, 115);
            this.dgInvoiceItems.Name = "dgInvoiceItems";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgInvoiceItems.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgInvoiceItems.RowHeadersVisible = false;
            this.dgInvoiceItems.RowHeadersWidth = 51;
            this.dgInvoiceItems.Size = new System.Drawing.Size(1004, 375);
            this.dgInvoiceItems.TabIndex = 47;
            // 
            // clNumber
            // 
            this.clNumber.HeaderText = "#";
            this.clNumber.MinimumWidth = 6;
            this.clNumber.Name = "clNumber";
            this.clNumber.ReadOnly = true;
            this.clNumber.Width = 20;
            // 
            // clItemCode
            // 
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clItemCode.DefaultCellStyle = dataGridViewCellStyle2;
            this.clItemCode.HeaderText = "Item Code";
            this.clItemCode.MinimumWidth = 6;
            this.clItemCode.Name = "clItemCode";
            this.clItemCode.ReadOnly = true;
            this.clItemCode.Width = 105;
            // 
            // clDescription
            // 
            this.clDescription.HeaderText = "Item Description";
            this.clDescription.MinimumWidth = 6;
            this.clDescription.Name = "clDescription";
            this.clDescription.ReadOnly = true;
            this.clDescription.Width = 240;
            // 
            // clProjectCode
            // 
            this.clProjectCode.FillWeight = 50F;
            this.clProjectCode.HeaderText = "Project";
            this.clProjectCode.MinimumWidth = 6;
            this.clProjectCode.Name = "clProjectCode";
            this.clProjectCode.ReadOnly = true;
            this.clProjectCode.Width = 50;
            // 
            // clItemType
            // 
            this.clItemType.HeaderText = "Type";
            this.clItemType.MinimumWidth = 6;
            this.clItemType.Name = "clItemType";
            this.clItemType.Width = 140;
            // 
            // clDeliveryDate
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.clDeliveryDate.DefaultCellStyle = dataGridViewCellStyle3;
            this.clDeliveryDate.HeaderText = "Delivery  / Last Invoiced";
            this.clDeliveryDate.MinimumWidth = 6;
            this.clDeliveryDate.Name = "clDeliveryDate";
            this.clDeliveryDate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clDeliveryDate.Width = 80;
            // 
            // clReturnDate
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.clReturnDate.DefaultCellStyle = dataGridViewCellStyle4;
            this.clReturnDate.HeaderText = "Return Date";
            this.clReturnDate.MinimumWidth = 6;
            this.clReturnDate.Name = "clReturnDate";
            this.clReturnDate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clReturnDate.Width = 80;
            // 
            // clQuantity
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = null;
            this.clQuantity.DefaultCellStyle = dataGridViewCellStyle5;
            this.clQuantity.HeaderText = "Qty";
            this.clQuantity.MinimumWidth = 6;
            this.clQuantity.Name = "clQuantity";
            this.clQuantity.Width = 65;
            // 
            // clPeriod
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.clPeriod.DefaultCellStyle = dataGridViewCellStyle6;
            this.clPeriod.HeaderText = "Period";
            this.clPeriod.MinimumWidth = 6;
            this.clPeriod.Name = "clPeriod";
            this.clPeriod.Width = 65;
            // 
            // clUnit
            // 
            this.clUnit.HeaderText = "Unit";
            this.clUnit.MinimumWidth = 6;
            this.clUnit.Name = "clUnit";
            this.clUnit.ReadOnly = true;
            this.clUnit.Width = 75;
            // 
            // clExValue
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.clExValue.DefaultCellStyle = dataGridViewCellStyle7;
            this.clExValue.HeaderText = "Amount (Excl.)";
            this.clExValue.MinimumWidth = 6;
            this.clExValue.Name = "clExValue";
            this.clExValue.Visible = false;
            this.clExValue.Width = 70;
            // 
            // clInvoice
            // 
            this.clInvoice.HeaderText = "Invoice";
            this.clInvoice.MinimumWidth = 6;
            this.clInvoice.Name = "clInvoice";
            this.clInvoice.Width = 65;
            // 
            // clTypeCode
            // 
            this.clTypeCode.HeaderText = "Code";
            this.clTypeCode.MinimumWidth = 6;
            this.clTypeCode.Name = "clTypeCode";
            this.clTypeCode.Visible = false;
            this.clTypeCode.Width = 6;
            // 
            // pnlPeriodLabel
            // 
            this.pnlPeriodLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPeriodLabel.Controls.Add(this.lblOrderNo);
            this.pnlPeriodLabel.Location = new System.Drawing.Point(316, 57);
            this.pnlPeriodLabel.Name = "pnlPeriodLabel";
            this.pnlPeriodLabel.Size = new System.Drawing.Size(202, 21);
            this.pnlPeriodLabel.TabIndex = 21;
            // 
            // lblOrderNo
            // 
            this.lblOrderNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblOrderNo.Location = new System.Drawing.Point(0, 0);
            this.lblOrderNo.Name = "lblOrderNo";
            this.lblOrderNo.Size = new System.Drawing.Size(200, 19);
            this.lblOrderNo.TabIndex = 23;
            this.lblOrderNo.Text = "Order Number";
            this.lblOrderNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlDateLabel
            // 
            this.pnlDateLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDateLabel.Controls.Add(this.lblDate);
            this.pnlDateLabel.Location = new System.Drawing.Point(12, 57);
            this.pnlDateLabel.Name = "pnlDateLabel";
            this.pnlDateLabel.Size = new System.Drawing.Size(90, 21);
            this.pnlDateLabel.TabIndex = 22;
            // 
            // lblDate
            // 
            this.lblDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDate.Location = new System.Drawing.Point(0, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(88, 19);
            this.lblDate.TabIndex = 23;
            this.lblDate.Text = "Date";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlPeriodValue
            // 
            this.pnlPeriodValue.BackColor = System.Drawing.Color.White;
            this.pnlPeriodValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPeriodValue.Controls.Add(this.txtOrderNumber);
            this.pnlPeriodValue.Location = new System.Drawing.Point(316, 77);
            this.pnlPeriodValue.Name = "pnlPeriodValue";
            this.pnlPeriodValue.Size = new System.Drawing.Size(202, 21);
            this.pnlPeriodValue.TabIndex = 26;
            // 
            // txtOrderNumber
            // 
            this.txtOrderNumber.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtOrderNumber.Location = new System.Drawing.Point(6, 3);
            this.txtOrderNumber.MaxLength = 25;
            this.txtOrderNumber.Name = "txtOrderNumber";
            this.txtOrderNumber.Size = new System.Drawing.Size(194, 13);
            this.txtOrderNumber.TabIndex = 29;
            // 
            // pnlDateValue
            // 
            this.pnlDateValue.BackColor = System.Drawing.Color.Gainsboro;
            this.pnlDateValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDateValue.Controls.Add(this.txtInvoiceDate);
            this.pnlDateValue.Location = new System.Drawing.Point(12, 77);
            this.pnlDateValue.Name = "pnlDateValue";
            this.pnlDateValue.Size = new System.Drawing.Size(90, 21);
            this.pnlDateValue.TabIndex = 27;
            // 
            // txtInvoiceDate
            // 
            this.txtInvoiceDate.BackColor = System.Drawing.Color.Gainsboro;
            this.txtInvoiceDate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtInvoiceDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtInvoiceDate.Location = new System.Drawing.Point(0, 0);
            this.txtInvoiceDate.MaxLength = 25;
            this.txtInvoiceDate.Name = "txtInvoiceDate";
            this.txtInvoiceDate.Size = new System.Drawing.Size(88, 13);
            this.txtInvoiceDate.TabIndex = 30;
            // 
            // pnlDeliveryDateValue
            // 
            this.pnlDeliveryDateValue.BackColor = System.Drawing.Color.Gainsboro;
            this.pnlDeliveryDateValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDeliveryDateValue.Controls.Add(this.txtDeliveryDate);
            this.pnlDeliveryDateValue.Location = new System.Drawing.Point(227, 77);
            this.pnlDeliveryDateValue.Name = "pnlDeliveryDateValue";
            this.pnlDeliveryDateValue.Size = new System.Drawing.Size(90, 21);
            this.pnlDeliveryDateValue.TabIndex = 29;
            // 
            // txtDeliveryDate
            // 
            this.txtDeliveryDate.BackColor = System.Drawing.Color.Gainsboro;
            this.txtDeliveryDate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDeliveryDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDeliveryDate.Location = new System.Drawing.Point(0, 0);
            this.txtDeliveryDate.Name = "txtDeliveryDate";
            this.txtDeliveryDate.Size = new System.Drawing.Size(88, 13);
            this.txtDeliveryDate.TabIndex = 0;
            // 
            // pnlSalesCodeLabel
            // 
            this.pnlSalesCodeLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSalesCodeLabel.Controls.Add(this.lblSalesCode);
            this.pnlSalesCodeLabel.Location = new System.Drawing.Point(101, 57);
            this.pnlSalesCodeLabel.Name = "pnlSalesCodeLabel";
            this.pnlSalesCodeLabel.Size = new System.Drawing.Size(70, 21);
            this.pnlSalesCodeLabel.TabIndex = 24;
            // 
            // lblSalesCode
            // 
            this.lblSalesCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSalesCode.Location = new System.Drawing.Point(0, 0);
            this.lblSalesCode.Name = "lblSalesCode";
            this.lblSalesCode.Size = new System.Drawing.Size(68, 19);
            this.lblSalesCode.TabIndex = 25;
            this.lblSalesCode.Text = "Sales Code";
            this.lblSalesCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlDeliveryDateLabel
            // 
            this.pnlDeliveryDateLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDeliveryDateLabel.Controls.Add(this.lblDeliveryDate);
            this.pnlDeliveryDateLabel.Location = new System.Drawing.Point(227, 57);
            this.pnlDeliveryDateLabel.Name = "pnlDeliveryDateLabel";
            this.pnlDeliveryDateLabel.Size = new System.Drawing.Size(90, 21);
            this.pnlDeliveryDateLabel.TabIndex = 23;
            // 
            // lblDeliveryDate
            // 
            this.lblDeliveryDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDeliveryDate.Location = new System.Drawing.Point(0, 0);
            this.lblDeliveryDate.Name = "lblDeliveryDate";
            this.lblDeliveryDate.Size = new System.Drawing.Size(88, 19);
            this.lblDeliveryDate.TabIndex = 29;
            this.lblDeliveryDate.Text = "Delivery Date";
            this.lblDeliveryDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlSalesCodeValue
            // 
            this.pnlSalesCodeValue.BackColor = System.Drawing.Color.White;
            this.pnlSalesCodeValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSalesCodeValue.Controls.Add(this.cmdSalesPerson);
            this.pnlSalesCodeValue.Controls.Add(this.txtSalesCode);
            this.pnlSalesCodeValue.Location = new System.Drawing.Point(101, 77);
            this.pnlSalesCodeValue.Name = "pnlSalesCodeValue";
            this.pnlSalesCodeValue.Size = new System.Drawing.Size(70, 21);
            this.pnlSalesCodeValue.TabIndex = 28;
            // 
            // cmdSalesPerson
            // 
            this.cmdSalesPerson.BackColor = System.Drawing.Color.White;
            this.cmdSalesPerson.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdSalesPerson.Image = ((System.Drawing.Image)(resources.GetObject("cmdSalesPerson.Image")));
            this.cmdSalesPerson.Location = new System.Drawing.Point(45, -2);
            this.cmdSalesPerson.Name = "cmdSalesPerson";
            this.cmdSalesPerson.Size = new System.Drawing.Size(25, 23);
            this.cmdSalesPerson.TabIndex = 158;
            this.cmdSalesPerson.UseVisualStyleBackColor = false;
            this.cmdSalesPerson.Click += new System.EventHandler(this.cmdSalesPerson_Click);
            // 
            // txtSalesCode
            // 
            this.txtSalesCode.BackColor = System.Drawing.Color.White;
            this.txtSalesCode.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSalesCode.Location = new System.Drawing.Point(3, 2);
            this.txtSalesCode.Name = "txtSalesCode";
            this.txtSalesCode.ReadOnly = true;
            this.txtSalesCode.Size = new System.Drawing.Size(36, 13);
            this.txtSalesCode.TabIndex = 28;
            // 
            // pnlDiscountLabel
            // 
            this.pnlDiscountLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDiscountLabel.Controls.Add(this.lblDiscount);
            this.pnlDiscountLabel.Location = new System.Drawing.Point(170, 57);
            this.pnlDiscountLabel.Name = "pnlDiscountLabel";
            this.pnlDiscountLabel.Size = new System.Drawing.Size(60, 21);
            this.pnlDiscountLabel.TabIndex = 25;
            // 
            // lblDiscount
            // 
            this.lblDiscount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDiscount.Location = new System.Drawing.Point(0, 0);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(58, 19);
            this.lblDiscount.TabIndex = 26;
            this.lblDiscount.Text = "Discount%";
            this.lblDiscount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlDiscountValue
            // 
            this.pnlDiscountValue.BackColor = System.Drawing.Color.Gainsboro;
            this.pnlDiscountValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDiscountValue.Controls.Add(this.txtDiscount);
            this.pnlDiscountValue.Location = new System.Drawing.Point(170, 77);
            this.pnlDiscountValue.Name = "pnlDiscountValue";
            this.pnlDiscountValue.Size = new System.Drawing.Size(58, 21);
            this.pnlDiscountValue.TabIndex = 30;
            // 
            // txtDiscount
            // 
            this.txtDiscount.BackColor = System.Drawing.Color.Gainsboro;
            this.txtDiscount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDiscount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDiscount.Location = new System.Drawing.Point(0, 0);
            this.txtDiscount.MaxLength = 3;
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(56, 13);
            this.txtDiscount.TabIndex = 28;
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Location = new System.Drawing.Point(540, 61);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(51, 13);
            this.lblCustomer.TabIndex = 71;
            this.lblCustomer.Text = "Customer";
            // 
            // cmdSearchCustomer
            // 
            this.cmdSearchCustomer.BackColor = System.Drawing.Color.White;
            this.cmdSearchCustomer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdSearchCustomer.Image = ((System.Drawing.Image)(resources.GetObject("cmdSearchCustomer.Image")));
            this.cmdSearchCustomer.Location = new System.Drawing.Point(680, 55);
            this.cmdSearchCustomer.Name = "cmdSearchCustomer";
            this.cmdSearchCustomer.Size = new System.Drawing.Size(25, 23);
            this.cmdSearchCustomer.TabIndex = 74;
            this.cmdSearchCustomer.UseVisualStyleBackColor = false;
            this.cmdSearchCustomer.Click += new System.EventHandler(this.cmdSearchCustomer_Click);
            // 
            // txtCustomerCode
            // 
            this.txtCustomerCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustomerCode.Location = new System.Drawing.Point(598, 57);
            this.txtCustomerCode.MaxLength = 6;
            this.txtCustomerCode.Name = "txtCustomerCode";
            this.txtCustomerCode.Size = new System.Drawing.Size(82, 20);
            this.txtCustomerCode.TabIndex = 72;
            // 
            // txtCustomerDescription
            // 
            this.txtCustomerDescription.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtCustomerDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustomerDescription.Location = new System.Drawing.Point(715, 57);
            this.txtCustomerDescription.Name = "txtCustomerDescription";
            this.txtCustomerDescription.ReadOnly = true;
            this.txtCustomerDescription.Size = new System.Drawing.Size(251, 20);
            this.txtCustomerDescription.TabIndex = 73;
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // InvoiceOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(1027, 547);
            this.Controls.Add(this.lblCustomer);
            this.Controls.Add(this.cmdSearchCustomer);
            this.Controls.Add(this.txtCustomerCode);
            this.Controls.Add(this.txtCustomerDescription);
            this.Controls.Add(this.pnlPeriodLabel);
            this.Controls.Add(this.pnlDateLabel);
            this.Controls.Add(this.pnlPeriodValue);
            this.Controls.Add(this.pnlDateValue);
            this.Controls.Add(this.dgInvoiceItems);
            this.Controls.Add(this.pnlDeliveryDateValue);
            this.Controls.Add(this.cmdCreateInvoice);
            this.Controls.Add(this.pnlSalesCodeLabel);
            this.Controls.Add(this.panel15);
            this.Controls.Add(this.pnlDeliveryDateLabel);
            this.Controls.Add(this.pnlDiscountValue);
            this.Controls.Add(this.pnlSalesCodeValue);
            this.Controls.Add(this.pnlDiscountLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "InvoiceOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Create Invoice For Delivery Note";
            this.Load += new System.EventHandler(this.InvoiceOrder_Load);
            this.panel15.ResumeLayout(false);
            this.panel15.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgInvoiceItems)).EndInit();
            this.pnlPeriodLabel.ResumeLayout(false);
            this.pnlDateLabel.ResumeLayout(false);
            this.pnlPeriodValue.ResumeLayout(false);
            this.pnlPeriodValue.PerformLayout();
            this.pnlDateValue.ResumeLayout(false);
            this.pnlDateValue.PerformLayout();
            this.pnlDeliveryDateValue.ResumeLayout(false);
            this.pnlDeliveryDateValue.PerformLayout();
            this.pnlSalesCodeLabel.ResumeLayout(false);
            this.pnlDeliveryDateLabel.ResumeLayout(false);
            this.pnlSalesCodeValue.ResumeLayout(false);
            this.pnlSalesCodeValue.PerformLayout();
            this.pnlDiscountLabel.ResumeLayout(false);
            this.pnlDiscountValue.ResumeLayout(false);
            this.pnlDiscountValue.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel15;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button cmdCreateInvoice;
        private System.Windows.Forms.DataGridView dgInvoiceItems;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblSalesOrderNumber;
        private System.Windows.Forms.Panel pnlPeriodLabel;
        private System.Windows.Forms.Label lblOrderNo;
        private System.Windows.Forms.Panel pnlDateLabel;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Panel pnlPeriodValue;
        private System.Windows.Forms.TextBox txtOrderNumber;
        private System.Windows.Forms.Panel pnlDateValue;
        private System.Windows.Forms.Panel pnlDeliveryDateValue;
        private System.Windows.Forms.Panel pnlSalesCodeLabel;
        private System.Windows.Forms.Label lblSalesCode;
        private System.Windows.Forms.Panel pnlDeliveryDateLabel;
        private System.Windows.Forms.Label lblDeliveryDate;
        private System.Windows.Forms.Panel pnlSalesCodeValue;
        private System.Windows.Forms.Button cmdSalesPerson;
        private System.Windows.Forms.TextBox txtSalesCode;
        private System.Windows.Forms.Panel pnlDiscountLabel;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.Panel pnlDiscountValue;
        private System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.TextBox txtInvoiceDate;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.Button cmdSearchCustomer;
        private System.Windows.Forms.TextBox txtCustomerCode;
        private System.Windows.Forms.TextBox txtCustomerDescription;
        private System.Windows.Forms.TextBox txtDeliveryDate;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn clItemCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn clProjectCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clItemType;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDeliveryDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clReturnDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn clPeriod;
        private System.Windows.Forms.DataGridViewTextBoxColumn clUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn clExValue;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clInvoice;
        private System.Windows.Forms.DataGridViewTextBoxColumn clTypeCode;
    }
}