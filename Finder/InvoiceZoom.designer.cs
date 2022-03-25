namespace Liquid.Finder
{
    partial class InvoiceZoom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvoiceZoom));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gpFilters = new System.Windows.Forms.GroupBox();
            this.cmdFilterInvoiceZoom = new System.Windows.Forms.Button();
            this.txtSite = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSalesOrder = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCustomerCode = new System.Windows.Forms.TextBox();
            this.lblCustCode = new System.Windows.Forms.Label();
            this.txtSalesNumber = new System.Windows.Forms.TextBox();
            this.cmdFilter = new System.Windows.Forms.Button();
            this.lblSalesNumber = new System.Windows.Forms.Label();
            this.dgSalesOrder = new System.Windows.Forms.DataGridView();
            this.clNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clContact = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clSite = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clTel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clSalesOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gpFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgSalesOrder)).BeginInit();
            this.SuspendLayout();
            // 
            // gpFilters
            // 
            this.gpFilters.Controls.Add(this.cmdFilterInvoiceZoom);
            this.gpFilters.Controls.Add(this.txtSite);
            this.gpFilters.Controls.Add(this.label3);
            this.gpFilters.Controls.Add(this.txtSalesOrder);
            this.gpFilters.Controls.Add(this.label1);
            this.gpFilters.Controls.Add(this.txtDescription);
            this.gpFilters.Controls.Add(this.label2);
            this.gpFilters.Controls.Add(this.txtCustomerCode);
            this.gpFilters.Controls.Add(this.lblCustCode);
            this.gpFilters.Controls.Add(this.txtSalesNumber);
            this.gpFilters.Controls.Add(this.cmdFilter);
            this.gpFilters.Controls.Add(this.lblSalesNumber);
            this.gpFilters.Location = new System.Drawing.Point(12, 12);
            this.gpFilters.Name = "gpFilters";
            this.gpFilters.Size = new System.Drawing.Size(881, 89);
            this.gpFilters.TabIndex = 9;
            this.gpFilters.TabStop = false;
            this.gpFilters.Text = "Filter Results By";
            // 
            // cmdFilterInvoiceZoom
            // 
            this.cmdFilterInvoiceZoom.Location = new System.Drawing.Point(506, 60);
            this.cmdFilterInvoiceZoom.Name = "cmdFilterInvoiceZoom";
            this.cmdFilterInvoiceZoom.Size = new System.Drawing.Size(75, 23);
            this.cmdFilterInvoiceZoom.TabIndex = 9;
            this.cmdFilterInvoiceZoom.Text = "Filter";
            this.cmdFilterInvoiceZoom.UseVisualStyleBackColor = true;
            this.cmdFilterInvoiceZoom.Visible = false;
            this.cmdFilterInvoiceZoom.Click += new System.EventHandler(this.cmdFilterInvoiceZoom_Click);
            // 
            // txtSite
            // 
            this.txtSite.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSite.Location = new System.Drawing.Point(347, 58);
            this.txtSite.Name = "txtSite";
            this.txtSite.Size = new System.Drawing.Size(100, 20);
            this.txtSite.TabIndex = 8;
            this.txtSite.TextChanged += new System.EventHandler(this.txtSalesNumber_TextChanged);
            this.txtSite.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSalesNumber_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(244, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Site";
            // 
            // txtSalesOrder
            // 
            this.txtSalesOrder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSalesOrder.Location = new System.Drawing.Point(101, 58);
            this.txtSalesOrder.Name = "txtSalesOrder";
            this.txtSalesOrder.Size = new System.Drawing.Size(100, 20);
            this.txtSalesOrder.TabIndex = 6;
            this.txtSalesOrder.TextChanged += new System.EventHandler(this.txtSalesNumber_TextChanged);
            this.txtSalesOrder.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSalesNumber_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Sales Order";
            // 
            // txtDescription
            // 
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescription.Location = new System.Drawing.Point(587, 30);
            this.txtDescription.MaxLength = 8;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(100, 20);
            this.txtDescription.TabIndex = 3;
            this.txtDescription.TextChanged += new System.EventHandler(this.txtSalesNumber_TextChanged);
            this.txtDescription.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSalesNumber_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(503, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Description";
            // 
            // txtCustomerCode
            // 
            this.txtCustomerCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustomerCode.Location = new System.Drawing.Point(347, 26);
            this.txtCustomerCode.MaxLength = 8;
            this.txtCustomerCode.Name = "txtCustomerCode";
            this.txtCustomerCode.Size = new System.Drawing.Size(100, 20);
            this.txtCustomerCode.TabIndex = 2;
            this.txtCustomerCode.TextChanged += new System.EventHandler(this.txtSalesNumber_TextChanged);
            this.txtCustomerCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSalesNumber_KeyDown);
            // 
            // lblCustCode
            // 
            this.lblCustCode.AutoSize = true;
            this.lblCustCode.Location = new System.Drawing.Point(244, 29);
            this.lblCustCode.Name = "lblCustCode";
            this.lblCustCode.Size = new System.Drawing.Size(79, 13);
            this.lblCustCode.TabIndex = 0;
            this.lblCustCode.Text = "Customer Code";
            // 
            // txtSalesNumber
            // 
            this.txtSalesNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSalesNumber.Location = new System.Drawing.Point(101, 25);
            this.txtSalesNumber.MaxLength = 8;
            this.txtSalesNumber.Name = "txtSalesNumber";
            this.txtSalesNumber.Size = new System.Drawing.Size(100, 20);
            this.txtSalesNumber.TabIndex = 1;
            this.txtSalesNumber.TextChanged += new System.EventHandler(this.txtSalesNumber_TextChanged);
            this.txtSalesNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSalesNumber_KeyDown);
            // 
            // cmdFilter
            // 
            this.cmdFilter.BackColor = System.Drawing.Color.White;
            this.cmdFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdFilter.Image = ((System.Drawing.Image)(resources.GetObject("cmdFilter.Image")));
            this.cmdFilter.Location = new System.Drawing.Point(768, 29);
            this.cmdFilter.Name = "cmdFilter";
            this.cmdFilter.Size = new System.Drawing.Size(25, 23);
            this.cmdFilter.TabIndex = 4;
            this.cmdFilter.UseVisualStyleBackColor = false;
            this.cmdFilter.Click += new System.EventHandler(this.cmdFilter_Click);
            // 
            // lblSalesNumber
            // 
            this.lblSalesNumber.AutoSize = true;
            this.lblSalesNumber.Location = new System.Drawing.Point(20, 28);
            this.lblSalesNumber.Name = "lblSalesNumber";
            this.lblSalesNumber.Size = new System.Drawing.Size(42, 13);
            this.lblSalesNumber.TabIndex = 0;
            this.lblSalesNumber.Text = "Invoice";
            // 
            // dgSalesOrder
            // 
            this.dgSalesOrder.AllowUserToAddRows = false;
            this.dgSalesOrder.AllowUserToDeleteRows = false;
            this.dgSalesOrder.AllowUserToResizeColumns = false;
            this.dgSalesOrder.AllowUserToResizeRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.GhostWhite;
            this.dgSalesOrder.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgSalesOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgSalesOrder.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clNumber,
            this.clContact,
            this.clSite,
            this.clTel,
            this.clDescription,
            this.clSalesOrder});
            this.dgSalesOrder.Location = new System.Drawing.Point(12, 128);
            this.dgSalesOrder.Name = "dgSalesOrder";
            this.dgSalesOrder.ReadOnly = true;
            this.dgSalesOrder.RowHeadersVisible = false;
            this.dgSalesOrder.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgSalesOrder.Size = new System.Drawing.Size(881, 333);
            this.dgSalesOrder.TabIndex = 8;
            this.dgSalesOrder.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgSalesOrder_CellContentDoubleClick);
            this.dgSalesOrder.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgSalesOrder_CellContentDoubleClick);
            this.dgSalesOrder.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgSalesOrder_KeyDown);
            this.dgSalesOrder.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgSalesOrder_KeyPress);
            // 
            // clNumber
            // 
            this.clNumber.DataPropertyName = "DocumentNumber";
            this.clNumber.HeaderText = "Invoice";
            this.clNumber.Name = "clNumber";
            this.clNumber.ReadOnly = true;
            // 
            // clContact
            // 
            this.clContact.DataPropertyName = "CustCode";
            this.clContact.HeaderText = "Customer Code";
            this.clContact.Name = "clContact";
            this.clContact.ReadOnly = true;
            this.clContact.Width = 200;
            // 
            // clSite
            // 
            this.clSite.DataPropertyName = "Site";
            this.clSite.HeaderText = "Site";
            this.clSite.Name = "clSite";
            this.clSite.ReadOnly = true;
            // 
            // clTel
            // 
            this.clTel.DataPropertyName = "DocumentDate";
            this.clTel.HeaderText = "Date";
            this.clTel.Name = "clTel";
            this.clTel.ReadOnly = true;
            this.clTel.Width = 150;
            // 
            // clDescription
            // 
            this.clDescription.DataPropertyName = "CustomerDesc";
            this.clDescription.HeaderText = "Description";
            this.clDescription.Name = "clDescription";
            this.clDescription.ReadOnly = true;
            this.clDescription.Width = 220;
            // 
            // clSalesOrder
            // 
            this.clSalesOrder.DataPropertyName = "Salesorder";
            this.clSalesOrder.HeaderText = "Salesorder";
            this.clSalesOrder.Name = "clSalesOrder";
            this.clSalesOrder.ReadOnly = true;
            // 
            // InvoiceZoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(907, 512);
            this.Controls.Add(this.gpFilters);
            this.Controls.Add(this.dgSalesOrder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "InvoiceZoom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "InvoiceZoom";
            this.Load += new System.EventHandler(this.SalesOrderZoom_Load);
            this.gpFilters.ResumeLayout(false);
            this.gpFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgSalesOrder)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpFilters;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCustomerCode;
        private System.Windows.Forms.Label lblCustCode;
        private System.Windows.Forms.TextBox txtSalesNumber;
        private System.Windows.Forms.Button cmdFilter;
        private System.Windows.Forms.Label lblSalesNumber;
        private System.Windows.Forms.DataGridView dgSalesOrder;
        private System.Windows.Forms.TextBox txtSalesOrder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSite;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cmdFilterInvoiceZoom;
        private System.Windows.Forms.DataGridViewTextBoxColumn clNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn clContact;
        private System.Windows.Forms.DataGridViewTextBoxColumn clSite;
        private System.Windows.Forms.DataGridViewTextBoxColumn clTel;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn clSalesOrder;
    }
}