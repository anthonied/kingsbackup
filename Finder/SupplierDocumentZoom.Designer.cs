namespace Liquid.Finder
{
    partial class SupplierDocumentZoom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SupplierDocumentZoom));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCustomerCode = new System.Windows.Forms.TextBox();
            this.lblSupplCode = new System.Windows.Forms.Label();
            this.txtDocNumber = new System.Windows.Forms.TextBox();
            this.cmdFilter = new System.Windows.Forms.Button();
            this.lblDocNumber = new System.Windows.Forms.Label();
            this.dgSupplDocs = new System.Windows.Forms.DataGridView();
            this.clNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clContact = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clTel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DocType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.gpFilters = new System.Windows.Forms.GroupBox();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgSupplDocs)).BeginInit();
            this.gpFilters.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtDescription
            // 
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescription.Location = new System.Drawing.Point(517, 24);
            this.txtDescription.MaxLength = 8;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(100, 20);
            this.txtDescription.TabIndex = 3;
            this.txtDescription.TextChanged += new System.EventHandler(this.txtDocNumber_TextChanged);
            this.txtDescription.Enter += new System.EventHandler(this.txtCustomerCode_Enter);
            this.txtDescription.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDocNumber_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(451, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Description";
            // 
            // txtCustomerCode
            // 
            this.txtCustomerCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustomerCode.Location = new System.Drawing.Point(314, 24);
            this.txtCustomerCode.MaxLength = 8;
            this.txtCustomerCode.Name = "txtCustomerCode";
            this.txtCustomerCode.Size = new System.Drawing.Size(100, 20);
            this.txtCustomerCode.TabIndex = 2;
            this.txtCustomerCode.TextChanged += new System.EventHandler(this.txtDocNumber_TextChanged);
            this.txtCustomerCode.Enter += new System.EventHandler(this.txtCustomerCode_Enter);
            this.txtCustomerCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDocNumber_KeyDown);
            // 
            // lblSupplCode
            // 
            this.lblSupplCode.AutoSize = true;
            this.lblSupplCode.Location = new System.Drawing.Point(235, 26);
            this.lblSupplCode.Name = "lblSupplCode";
            this.lblSupplCode.Size = new System.Drawing.Size(73, 13);
            this.lblSupplCode.TabIndex = 0;
            this.lblSupplCode.Text = "Supplier Code";
            // 
            // txtDocNumber
            // 
            this.txtDocNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDocNumber.Location = new System.Drawing.Point(90, 24);
            this.txtDocNumber.MaxLength = 8;
            this.txtDocNumber.Name = "txtDocNumber";
            this.txtDocNumber.Size = new System.Drawing.Size(100, 20);
            this.txtDocNumber.TabIndex = 1;
            this.txtDocNumber.TextChanged += new System.EventHandler(this.txtDocNumber_TextChanged);
            this.txtDocNumber.Enter += new System.EventHandler(this.txtCustomerCode_Enter);
            this.txtDocNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDocNumber_KeyDown);
            // 
            // cmdFilter
            // 
            this.cmdFilter.BackColor = System.Drawing.Color.White;
            this.cmdFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdFilter.Image = ((System.Drawing.Image)(resources.GetObject("cmdFilter.Image")));
            this.cmdFilter.Location = new System.Drawing.Point(641, 23);
            this.cmdFilter.Name = "cmdFilter";
            this.cmdFilter.Size = new System.Drawing.Size(25, 23);
            this.cmdFilter.TabIndex = 4;
            this.cmdFilter.UseVisualStyleBackColor = false;
            this.cmdFilter.Click += new System.EventHandler(this.cmdFilter_Click);
            // 
            // lblDocNumber
            // 
            this.lblDocNumber.AutoSize = true;
            this.lblDocNumber.Location = new System.Drawing.Point(17, 26);
            this.lblDocNumber.Name = "lblDocNumber";
            this.lblDocNumber.Size = new System.Drawing.Size(67, 13);
            this.lblDocNumber.TabIndex = 0;
            this.lblDocNumber.Text = "Doc Number";
            // 
            // dgSupplDocs
            // 
            this.dgSupplDocs.AllowUserToAddRows = false;
            this.dgSupplDocs.AllowUserToDeleteRows = false;
            this.dgSupplDocs.AllowUserToResizeColumns = false;
            this.dgSupplDocs.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.GhostWhite;
            this.dgSupplDocs.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgSupplDocs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgSupplDocs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clNumber,
            this.clContact,
            this.clTel,
            this.clDescription,
            this.DocType});
            this.dgSupplDocs.Location = new System.Drawing.Point(17, 107);
            this.dgSupplDocs.Name = "dgSupplDocs";
            this.dgSupplDocs.ReadOnly = true;
            this.dgSupplDocs.RowHeadersVisible = false;
            this.dgSupplDocs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgSupplDocs.Size = new System.Drawing.Size(687, 362);
            this.dgSupplDocs.TabIndex = 8;
            this.dgSupplDocs.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgSalesOrder_CellContentDoubleClick);
            this.dgSupplDocs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgSupplDocs_KeyDown);
            this.dgSupplDocs.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgSupplDocs_KeyPress);
            // 
            // clNumber
            // 
            this.clNumber.DataPropertyName = "DocumentNumber";
            this.clNumber.HeaderText = "Doc Number";
            this.clNumber.Name = "clNumber";
            this.clNumber.ReadOnly = true;
            // 
            // clContact
            // 
            this.clContact.DataPropertyName = "CustCode";
            this.clContact.HeaderText = "Supplier Code";
            this.clContact.Name = "clContact";
            this.clContact.ReadOnly = true;
            this.clContact.Width = 200;
            // 
            // clTel
            // 
            this.clTel.DataPropertyName = "DocumentDate";
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.clTel.DefaultCellStyle = dataGridViewCellStyle2;
            this.clTel.HeaderText = "Date";
            this.clTel.Name = "clTel";
            this.clTel.ReadOnly = true;
            this.clTel.Width = 150;
            // 
            // clDescription
            // 
            this.clDescription.DataPropertyName = "SupplDesc";
            this.clDescription.HeaderText = "Description";
            this.clDescription.Name = "clDescription";
            this.clDescription.ReadOnly = true;
            this.clDescription.Width = 220;
            // 
            // DocType
            // 
            this.DocType.DataPropertyName = "DocumentType";
            this.DocType.HeaderText = "Doc Type";
            this.DocType.Name = "DocType";
            this.DocType.ReadOnly = true;
            this.DocType.Visible = false;
            // 
            // dtpTo
            // 
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(314, 59);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(100, 20);
            this.dtpTo.TabIndex = 6;
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
            this.gpFilters.Location = new System.Drawing.Point(17, 12);
            this.gpFilters.Name = "gpFilters";
            this.gpFilters.Size = new System.Drawing.Size(687, 89);
            this.gpFilters.TabIndex = 9;
            this.gpFilters.TabStop = false;
            this.gpFilters.Text = "Filter Results By";
            // 
            // dtpFrom
            // 
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(90, 59);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(100, 20);
            this.dtpFrom.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Starting Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(235, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Ending Date";
            // 
            // SupplierDocumentZoom
            // 
            this.ClientSize = new System.Drawing.Size(723, 481);
            this.Controls.Add(this.gpFilters);
            this.Controls.Add(this.dgSupplDocs);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SupplierDocumentZoom";
            this.Text = "Supplier Document Finder";
            this.Load += new System.EventHandler(this.SupplierDocumentZoom_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgSupplDocs)).EndInit();
            this.gpFilters.ResumeLayout(false);
            this.gpFilters.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCustomerCode;
        private System.Windows.Forms.Label lblSupplCode;
        private System.Windows.Forms.TextBox txtDocNumber;
        private System.Windows.Forms.Button cmdFilter;
        private System.Windows.Forms.Label lblDocNumber;
        private System.Windows.Forms.DataGridView dgSupplDocs;
        private System.Windows.Forms.DataGridViewTextBoxColumn clNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn clContact;
        private System.Windows.Forms.DataGridViewTextBoxColumn clTel;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn DocType;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.GroupBox gpFilters;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpFrom;
    }
}