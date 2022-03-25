namespace Liquid.Finder
{
	partial class StoreZoom
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StoreZoom));
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			this.gpFilters = new System.Windows.Forms.GroupBox();
			this.txtCode = new System.Windows.Forms.TextBox();
			this.cmdFilter = new System.Windows.Forms.Button();
			this.lblStoreCode = new System.Windows.Forms.Label();
			this.dgStores = new System.Windows.Forms.DataGridView();
			this.clNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clTel = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clFax = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.gpFilters.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgStores)).BeginInit();
			this.SuspendLayout();
			// 
			// gpFilters
			// 
			this.gpFilters.Controls.Add(this.txtCode);
			this.gpFilters.Controls.Add(this.cmdFilter);
			this.gpFilters.Controls.Add(this.lblStoreCode);
			this.gpFilters.Location = new System.Drawing.Point(8, 11);
			this.gpFilters.Name = "gpFilters";
			this.gpFilters.Size = new System.Drawing.Size(682, 60);
			this.gpFilters.TabIndex = 7;
			this.gpFilters.TabStop = false;
			this.gpFilters.Text = "Filter Results By";
			// 
			// txtCode
			// 
			this.txtCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtCode.Location = new System.Drawing.Point(101, 25);
			this.txtCode.MaxLength = 6;
			this.txtCode.Name = "txtCode";
			this.txtCode.Size = new System.Drawing.Size(100, 20);
			this.txtCode.TabIndex = 1;
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
			// lblStoreCode
			// 
			this.lblStoreCode.AutoSize = true;
			this.lblStoreCode.Location = new System.Drawing.Point(20, 28);
			this.lblStoreCode.Name = "lblStoreCode";
			this.lblStoreCode.Size = new System.Drawing.Size(60, 13);
			this.lblStoreCode.TabIndex = 0;
			this.lblStoreCode.Text = "Store Code";
			// 
			// dgStores
			// 
			this.dgStores.AllowUserToAddRows = false;
			this.dgStores.AllowUserToDeleteRows = false;
			this.dgStores.AllowUserToResizeColumns = false;
			this.dgStores.AllowUserToResizeRows = false;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.GhostWhite;
			this.dgStores.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.dgStores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgStores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clNumber,
            this.clDescription,
            this.clTel,
            this.clFax});
			this.dgStores.Location = new System.Drawing.Point(8, 80);
			this.dgStores.Name = "dgStores";
			this.dgStores.ReadOnly = true;
			this.dgStores.RowHeadersVisible = false;
			this.dgStores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgStores.Size = new System.Drawing.Size(682, 333);
			this.dgStores.TabIndex = 6;
			this.dgStores.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgStores_CellDoubleClick);
			this.dgStores.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgStores_KeyDown);
			// 
			// clNumber
			// 
			this.clNumber.HeaderText = "Code";
			this.clNumber.Name = "clNumber";
			this.clNumber.ReadOnly = true;
			// 
			// clDescription
			// 
			this.clDescription.HeaderText = "Description";
			this.clDescription.Name = "clDescription";
			this.clDescription.ReadOnly = true;
			this.clDescription.Width = 200;
			// 
			// clTel
			// 
			this.clTel.HeaderText = "Telephone";
			this.clTel.Name = "clTel";
			this.clTel.ReadOnly = true;
			this.clTel.Width = 150;
			// 
			// clFax
			// 
			this.clFax.HeaderText = "Fax";
			this.clFax.Name = "clFax";
			this.clFax.ReadOnly = true;
			this.clFax.Width = 200;
			// 
			// StoreZoom
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(698, 441);
			this.Controls.Add(this.gpFilters);
			this.Controls.Add(this.dgStores);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "StoreZoom";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Store Zoom";
			this.Load += new System.EventHandler(this.StoreZoom_Load);
			this.gpFilters.ResumeLayout(false);
			this.gpFilters.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgStores)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox gpFilters;
		private System.Windows.Forms.TextBox txtCode;
		private System.Windows.Forms.Button cmdFilter;
		private System.Windows.Forms.Label lblStoreCode;
		private System.Windows.Forms.DataGridView dgStores;
		private System.Windows.Forms.DataGridViewTextBoxColumn clNumber;
		private System.Windows.Forms.DataGridViewTextBoxColumn clDescription;
		private System.Windows.Forms.DataGridViewTextBoxColumn clTel;
		private System.Windows.Forms.DataGridViewTextBoxColumn clFax;
	}
}