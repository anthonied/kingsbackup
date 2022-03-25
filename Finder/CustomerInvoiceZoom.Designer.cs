namespace Liquid.Finder
{
    partial class CustomerInvoiceZoom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerInvoiceZoom));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gpFilters = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCustomerCode = new System.Windows.Forms.TextBox();
            this.lblSupplCode = new System.Windows.Forms.Label();
            this.txtDocNumber = new System.Windows.Forms.TextBox();
            this.cmdFilter = new System.Windows.Forms.Button();
            this.lblDocNumber = new System.Windows.Forms.Label();
            this.dgvCustomerInvoices = new System.Windows.Forms.DataGridView();
            this.clNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDocDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clCustCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clOrderNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDocType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clSalesman = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDiscount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gpFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomerInvoices)).BeginInit();
            this.SuspendLayout();
            // 
            // gpFilters
            // 
            this.gpFilters.Controls.Add(this.label3);
            this.gpFilters.Controls.Add(this.label1);
            this.gpFilters.Controls.Add(this.dtpFrom);
            this.gpFilters.Controls.Add(this.dtpTo);
            this.gpFilters.Controls.Add(this.txtDescription);
            this.gpFilters.Controls.Add(this.label2);
            this.gpFilters.Controls.Add(this.txtCustomerCode);
            this.gpFilters.Controls.Add(this.lblSupplCode);
            this.gpFilters.Controls.Add(this.txtDocNumber);
            this.gpFilters.Controls.Add(this.cmdFilter);
            this.gpFilters.Controls.Add(this.lblDocNumber);
            this.gpFilters.Location = new System.Drawing.Point(18, 12);
            this.gpFilters.Name = "gpFilters";
            this.gpFilters.Size = new System.Drawing.Size(625, 89);
            this.gpFilters.TabIndex = 11;
            this.gpFilters.TabStop = false;
            this.gpFilters.Text = "Filter Results By";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(220, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Ending Date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Starting Date";
            // 
            // dtpFrom
            // 
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(82, 59);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(100, 20);
            this.dtpFrom.TabIndex = 7;
            // 
            // dtpTo
            // 
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(305, 59);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(100, 20);
            this.dtpTo.TabIndex = 6;
            // 
            // txtDescription
            // 
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescription.Location = new System.Drawing.Point(507, 24);
            this.txtDescription.MaxLength = 8;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(100, 20);
            this.txtDescription.TabIndex = 3;
            this.txtDescription.TextChanged += new System.EventHandler(this.txtDescription_TextChanged);
            this.txtDescription.Enter += new System.EventHandler(this.txtDocNumber_Enter);
            this.txtDescription.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDocNumber_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(441, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Description";
            // 
            // txtCustomerCode
            // 
            this.txtCustomerCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustomerCode.Location = new System.Drawing.Point(305, 24);
            this.txtCustomerCode.MaxLength = 8;
            this.txtCustomerCode.Name = "txtCustomerCode";
            this.txtCustomerCode.Size = new System.Drawing.Size(100, 20);
            this.txtCustomerCode.TabIndex = 2;
            this.txtCustomerCode.TextChanged += new System.EventHandler(this.txtCustomerCode_TextChanged);
            this.txtCustomerCode.Enter += new System.EventHandler(this.txtDocNumber_Enter);
            this.txtCustomerCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDocNumber_KeyDown);
            // 
            // lblSupplCode
            // 
            this.lblSupplCode.AutoSize = true;
            this.lblSupplCode.Location = new System.Drawing.Point(220, 26);
            this.lblSupplCode.Name = "lblSupplCode";
            this.lblSupplCode.Size = new System.Drawing.Size(79, 13);
            this.lblSupplCode.TabIndex = 0;
            this.lblSupplCode.Text = "Customer Code";
            // 
            // txtDocNumber
            // 
            this.txtDocNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDocNumber.Location = new System.Drawing.Point(82, 24);
            this.txtDocNumber.MaxLength = 8;
            this.txtDocNumber.Name = "txtDocNumber";
            this.txtDocNumber.Size = new System.Drawing.Size(100, 20);
            this.txtDocNumber.TabIndex = 1;
            this.txtDocNumber.TextChanged += new System.EventHandler(this.txtDocNumber_TextChanged);
            this.txtDocNumber.Enter += new System.EventHandler(this.txtDocNumber_Enter);
            this.txtDocNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDocNumber_KeyDown);
            // 
            // cmdFilter
            // 
            this.cmdFilter.BackColor = System.Drawing.Color.White;
            this.cmdFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdFilter.Image = ((System.Drawing.Image)(resources.GetObject("cmdFilter.Image")));
            this.cmdFilter.Location = new System.Drawing.Point(582, 57);
            this.cmdFilter.Name = "cmdFilter";
            this.cmdFilter.Size = new System.Drawing.Size(25, 23);
            this.cmdFilter.TabIndex = 4;
            this.cmdFilter.UseVisualStyleBackColor = false;
            this.cmdFilter.Click += new System.EventHandler(this.cmdFilter_Click);
            // 
            // lblDocNumber
            // 
            this.lblDocNumber.AutoSize = true;
            this.lblDocNumber.Location = new System.Drawing.Point(9, 26);
            this.lblDocNumber.Name = "lblDocNumber";
            this.lblDocNumber.Size = new System.Drawing.Size(67, 13);
            this.lblDocNumber.TabIndex = 0;
            this.lblDocNumber.Text = "Doc Number";
            // 
            // dgvCustomerInvoices
            // 
            this.dgvCustomerInvoices.AllowUserToAddRows = false;
            this.dgvCustomerInvoices.AllowUserToDeleteRows = false;
            this.dgvCustomerInvoices.AllowUserToResizeColumns = false;
            this.dgvCustomerInvoices.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.GhostWhite;
            this.dgvCustomerInvoices.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCustomerInvoices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomerInvoices.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clNumber,
            this.clDocDate,
            this.clCustCode,
            this.clDescription,
            this.clOrderNumber,
            this.clDocType,
            this.clSalesman,
            this.clDiscount});
            this.dgvCustomerInvoices.Location = new System.Drawing.Point(18, 107);
            this.dgvCustomerInvoices.Name = "dgvCustomerInvoices";
            this.dgvCustomerInvoices.ReadOnly = true;
            this.dgvCustomerInvoices.RowHeadersVisible = false;
            this.dgvCustomerInvoices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCustomerInvoices.Size = new System.Drawing.Size(625, 362);
            this.dgvCustomerInvoices.TabIndex = 10;
            this.dgvCustomerInvoices.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCustomerInvoices_CellDoubleClick);
            this.dgvCustomerInvoices.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvCustomerInvoices_KeyDown);
            this.dgvCustomerInvoices.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgvCustomerInvoices_KeyPress);
            // 
            // clNumber
            // 
            this.clNumber.DataPropertyName = "DocumentNumber";
            this.clNumber.HeaderText = "Doc Number";
            this.clNumber.Name = "clNumber";
            this.clNumber.ReadOnly = true;
            // 
            // clDocDate
            // 
            this.clDocDate.DataPropertyName = "DocumentDate";
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.clDocDate.DefaultCellStyle = dataGridViewCellStyle2;
            this.clDocDate.HeaderText = "Doc Date";
            this.clDocDate.Name = "clDocDate";
            this.clDocDate.ReadOnly = true;
            // 
            // clCustCode
            // 
            this.clCustCode.DataPropertyName = "CustomerCode";
            this.clCustCode.HeaderText = "Cust Code";
            this.clCustCode.Name = "clCustCode";
            this.clCustCode.ReadOnly = true;
            // 
            // clDescription
            // 
            this.clDescription.DataPropertyName = "CustomerDesc";
            this.clDescription.HeaderText = "Description";
            this.clDescription.Name = "clDescription";
            this.clDescription.ReadOnly = true;
            this.clDescription.Width = 220;
            // 
            // clOrderNumber
            // 
            this.clOrderNumber.DataPropertyName = "OrderNumber";
            this.clOrderNumber.HeaderText = "Order Number";
            this.clOrderNumber.Name = "clOrderNumber";
            this.clOrderNumber.ReadOnly = true;
            // 
            // clDocType
            // 
            this.clDocType.DataPropertyName = "DocumentType";
            this.clDocType.HeaderText = "Doc Type";
            this.clDocType.Name = "clDocType";
            this.clDocType.ReadOnly = true;
            this.clDocType.Visible = false;
            // 
            // clSalesman
            // 
            this.clSalesman.DataPropertyName = "SalesmanCode";
            this.clSalesman.HeaderText = "Salesman";
            this.clSalesman.Name = "clSalesman";
            this.clSalesman.ReadOnly = true;
            this.clSalesman.Visible = false;
            // 
            // clDiscount
            // 
            this.clDiscount.DataPropertyName = "DiscountPercent";
            this.clDiscount.HeaderText = "Discount";
            this.clDiscount.Name = "clDiscount";
            this.clDiscount.ReadOnly = true;
            this.clDiscount.Visible = false;
            // 
            // CustomerInvoiceZoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 481);
            this.Controls.Add(this.gpFilters);
            this.Controls.Add(this.dgvCustomerInvoices);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CustomerInvoiceZoom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customer Invoice Finder";
            this.Load += new System.EventHandler(this.CustomerInvoiceZoom_Load);
            this.gpFilters.ResumeLayout(false);
            this.gpFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomerInvoices)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpFilters;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCustomerCode;
        private System.Windows.Forms.Label lblSupplCode;
        private System.Windows.Forms.TextBox txtDocNumber;
        private System.Windows.Forms.Button cmdFilter;
        private System.Windows.Forms.Label lblDocNumber;
        private System.Windows.Forms.DataGridView dgvCustomerInvoices;
        private System.Windows.Forms.DataGridViewTextBoxColumn clNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDocDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clCustCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn clOrderNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDocType;
        private System.Windows.Forms.DataGridViewTextBoxColumn clSalesman;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDiscount;
    }
}