namespace Liquid.Finder
{
	partial class OpenSalesOrderZoom
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OpenSalesOrderZoom));
			this.gpFilters = new System.Windows.Forms.GroupBox();
			this.txtSalesNumber = new System.Windows.Forms.TextBox();
			this.lblSalesNumber = new System.Windows.Forms.Label();
			this.dgSalesOrder = new System.Windows.Forms.DataGridView();
			this.clNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clContact = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clTel = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cmdFilter = new System.Windows.Forms.Button();
			this.lblCustomer = new System.Windows.Forms.Label();
			this.lblCustomerValue = new System.Windows.Forms.Label();
			this.gpFilters.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgSalesOrder)).BeginInit();
			this.SuspendLayout();
			// 
			// gpFilters
			// 
			this.gpFilters.Controls.Add(this.lblCustomerValue);
			this.gpFilters.Controls.Add(this.lblCustomer);
			this.gpFilters.Controls.Add(this.txtSalesNumber);
			this.gpFilters.Controls.Add(this.cmdFilter);
			this.gpFilters.Controls.Add(this.lblSalesNumber);
			this.gpFilters.Location = new System.Drawing.Point(12, 12);
			this.gpFilters.Name = "gpFilters";
			this.gpFilters.Size = new System.Drawing.Size(682, 60);
			this.gpFilters.TabIndex = 9;
			this.gpFilters.TabStop = false;
			this.gpFilters.Text = "Filter Results By";
			// 
			// txtSalesNumber
			// 
			this.txtSalesNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtSalesNumber.Location = new System.Drawing.Point(101, 25);
			this.txtSalesNumber.MaxLength = 8;
			this.txtSalesNumber.Name = "txtSalesNumber";
			this.txtSalesNumber.Size = new System.Drawing.Size(100, 20);
			this.txtSalesNumber.TabIndex = 1;
			this.txtSalesNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSalesNumber_KeyDown);
			// 
			// lblSalesNumber
			// 
			this.lblSalesNumber.AutoSize = true;
			this.lblSalesNumber.Location = new System.Drawing.Point(20, 28);
			this.lblSalesNumber.Name = "lblSalesNumber";
			this.lblSalesNumber.Size = new System.Drawing.Size(62, 13);
			this.lblSalesNumber.TabIndex = 0;
			this.lblSalesNumber.Text = "Sales Order";
			// 
			// dgSalesOrder
			// 
			this.dgSalesOrder.AllowUserToAddRows = false;
			this.dgSalesOrder.AllowUserToDeleteRows = false;
			this.dgSalesOrder.AllowUserToResizeColumns = false;
			this.dgSalesOrder.AllowUserToResizeRows = false;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.GhostWhite;
			this.dgSalesOrder.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.dgSalesOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgSalesOrder.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clNumber,
            this.clContact,
            this.clTel});
			this.dgSalesOrder.Location = new System.Drawing.Point(12, 82);
			this.dgSalesOrder.Name = "dgSalesOrder";
			this.dgSalesOrder.ReadOnly = true;
			this.dgSalesOrder.RowHeadersVisible = false;
			this.dgSalesOrder.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgSalesOrder.Size = new System.Drawing.Size(682, 333);
			this.dgSalesOrder.TabIndex = 8;
			this.dgSalesOrder.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgSalesOrder_CellDoubleClick);
			this.dgSalesOrder.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgSalesOrder_KeyDown);
			// 
			// clNumber
			// 
			this.clNumber.HeaderText = "Sales Order";
			this.clNumber.Name = "clNumber";
			this.clNumber.ReadOnly = true;
			// 
			// clContact
			// 
			this.clContact.HeaderText = "Customer Code";
			this.clContact.Name = "clContact";
			this.clContact.ReadOnly = true;
			this.clContact.Width = 200;
			// 
			// clTel
			// 
			this.clTel.HeaderText = "Date";
			this.clTel.Name = "clTel";
			this.clTel.ReadOnly = true;
			this.clTel.Width = 150;
			// 
			// cmdFilter
			// 
			this.cmdFilter.BackColor = System.Drawing.Color.White;
			this.cmdFilter.Cursor = System.Windows.Forms.Cursors.Hand;
			this.cmdFilter.Image = ((System.Drawing.Image)(resources.GetObject("cmdFilter.Image")));
			this.cmdFilter.Location = new System.Drawing.Point(207, 23);
			this.cmdFilter.Name = "cmdFilter";
			this.cmdFilter.Size = new System.Drawing.Size(25, 23);
			this.cmdFilter.TabIndex = 44;
			this.cmdFilter.UseVisualStyleBackColor = false;
			this.cmdFilter.Click += new System.EventHandler(this.cmdFilter_Click);
			// 
			// lblCustomer
			// 
			this.lblCustomer.AutoSize = true;
			this.lblCustomer.Location = new System.Drawing.Point(279, 27);
			this.lblCustomer.Name = "lblCustomer";
			this.lblCustomer.Size = new System.Drawing.Size(51, 13);
			this.lblCustomer.TabIndex = 45;
			this.lblCustomer.Text = "Customer";
			// 
			// lblCustomerValue
			// 
			this.lblCustomerValue.AutoSize = true;
			this.lblCustomerValue.Location = new System.Drawing.Point(348, 28);
			this.lblCustomerValue.Name = "lblCustomerValue";
			this.lblCustomerValue.Size = new System.Drawing.Size(0, 13);
			this.lblCustomerValue.TabIndex = 46;
			// 
			// OpenSalesOrderZoom
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(723, 438);
			this.Controls.Add(this.gpFilters);
			this.Controls.Add(this.dgSalesOrder);
			this.Name = "OpenSalesOrderZoom";
			this.Text = "Open Sales Order Zoom";
			this.Load += new System.EventHandler(this.OpenSalesOrderZoom_Load);
			this.gpFilters.ResumeLayout(false);
			this.gpFilters.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgSalesOrder)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox gpFilters;
		private System.Windows.Forms.TextBox txtSalesNumber;
		private System.Windows.Forms.Button cmdFilter;
		private System.Windows.Forms.Label lblSalesNumber;
		private System.Windows.Forms.DataGridView dgSalesOrder;
		private System.Windows.Forms.DataGridViewTextBoxColumn clNumber;
		private System.Windows.Forms.DataGridViewTextBoxColumn clContact;
		private System.Windows.Forms.DataGridViewTextBoxColumn clTel;
		private System.Windows.Forms.Label lblCustomerValue;
		private System.Windows.Forms.Label lblCustomer;
	}
}