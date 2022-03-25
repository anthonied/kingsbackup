namespace Liquid.Finder
{
	partial class SalesZoom
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SalesZoom));
			this.gpFilters = new System.Windows.Forms.GroupBox();
			this.txtSalesCode = new System.Windows.Forms.TextBox();
			this.lblCode = new System.Windows.Forms.Label();
			this.dgSalesPersons = new System.Windows.Forms.DataGridView();
			this.cmdFilter = new System.Windows.Forms.Button();
			this.clNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clContact = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.gpFilters.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgSalesPersons)).BeginInit();
			this.SuspendLayout();
			// 
			// gpFilters
			// 
			this.gpFilters.Controls.Add(this.txtSalesCode);
			this.gpFilters.Controls.Add(this.cmdFilter);
			this.gpFilters.Controls.Add(this.lblCode);
			this.gpFilters.Location = new System.Drawing.Point(12, 12);
			this.gpFilters.Name = "gpFilters";
			this.gpFilters.Size = new System.Drawing.Size(682, 60);
			this.gpFilters.TabIndex = 7;
			this.gpFilters.TabStop = false;
			this.gpFilters.Text = "Filter Results By";
			// 
			// txtSalesCode
			// 
			this.txtSalesCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtSalesCode.Location = new System.Drawing.Point(101, 25);
			this.txtSalesCode.MaxLength = 6;
			this.txtSalesCode.Name = "txtSalesCode";
			this.txtSalesCode.Size = new System.Drawing.Size(100, 20);
			this.txtSalesCode.TabIndex = 1;
			// 
			// lblCode
			// 
			this.lblCode.AutoSize = true;
			this.lblCode.Location = new System.Drawing.Point(20, 28);
			this.lblCode.Name = "lblCode";
			this.lblCode.Size = new System.Drawing.Size(61, 13);
			this.lblCode.TabIndex = 0;
			this.lblCode.Text = "Sales Code";
			// 
			// dgSalesPersons
			// 
			this.dgSalesPersons.AllowUserToAddRows = false;
			this.dgSalesPersons.AllowUserToDeleteRows = false;
			this.dgSalesPersons.AllowUserToResizeColumns = false;
			this.dgSalesPersons.AllowUserToResizeRows = false;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.GhostWhite;
			this.dgSalesPersons.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.dgSalesPersons.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgSalesPersons.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clNumber,
            this.clContact});
			this.dgSalesPersons.Location = new System.Drawing.Point(12, 81);
			this.dgSalesPersons.Name = "dgSalesPersons";
			this.dgSalesPersons.ReadOnly = true;
			this.dgSalesPersons.RowHeadersVisible = false;
			this.dgSalesPersons.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgSalesPersons.Size = new System.Drawing.Size(682, 333);
			this.dgSalesPersons.TabIndex = 6;
			this.dgSalesPersons.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgSalesPersons_CellContentDoubleClick);
			this.dgSalesPersons.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgSalesPersons_KeyDown);
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
			// clNumber
			// 
			this.clNumber.HeaderText = "Code";
			this.clNumber.Name = "clNumber";
			this.clNumber.ReadOnly = true;
			// 
			// clContact
			// 
			this.clContact.HeaderText = "Sales Rep";
			this.clContact.Name = "clContact";
			this.clContact.ReadOnly = true;
			this.clContact.Width = 200;
			// 
			// SalesZoom
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(718, 437);
			this.Controls.Add(this.gpFilters);
			this.Controls.Add(this.dgSalesPersons);
			this.Name = "SalesZoom";
			this.Text = "SalesZoom";
			this.Load += new System.EventHandler(this.SalesZoom_Load);
			this.gpFilters.ResumeLayout(false);
			this.gpFilters.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgSalesPersons)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox gpFilters;
		private System.Windows.Forms.TextBox txtSalesCode;
		private System.Windows.Forms.Button cmdFilter;
		private System.Windows.Forms.Label lblCode;
		private System.Windows.Forms.DataGridView dgSalesPersons;
		private System.Windows.Forms.DataGridViewTextBoxColumn clNumber;
		private System.Windows.Forms.DataGridViewTextBoxColumn clContact;
	}
}