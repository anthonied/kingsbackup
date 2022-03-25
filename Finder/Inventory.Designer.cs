namespace Liquid.Finder
{
	partial class Inventory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inventory));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gpFilters = new System.Windows.Forms.GroupBox();
            this.cmdAddKit = new System.Windows.Forms.Button();
            this.cmdAddComment = new System.Windows.Forms.Button();
            this.chkKitItem = new System.Windows.Forms.CheckBox();
            this.lblKit = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblStoreValue = new System.Windows.Forms.Label();
            this.lblStoreLabel = new System.Windows.Forms.Label();
            this.cmdInventorySearch = new System.Windows.Forms.Button();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.lblCode = new System.Windows.Forms.Label();
            this.dgInventory = new System.Windows.Forms.DataGridView();
            this.clCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clKit = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clQuoteNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gpFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgInventory)).BeginInit();
            this.SuspendLayout();
            // 
            // gpFilters
            // 
            this.gpFilters.Controls.Add(this.cmdAddKit);
            this.gpFilters.Controls.Add(this.cmdAddComment);
            this.gpFilters.Controls.Add(this.chkKitItem);
            this.gpFilters.Controls.Add(this.lblKit);
            this.gpFilters.Controls.Add(this.txtDescription);
            this.gpFilters.Controls.Add(this.lblDescription);
            this.gpFilters.Controls.Add(this.lblStoreValue);
            this.gpFilters.Controls.Add(this.lblStoreLabel);
            this.gpFilters.Controls.Add(this.cmdInventorySearch);
            this.gpFilters.Controls.Add(this.txtCode);
            this.gpFilters.Controls.Add(this.lblCode);
            this.gpFilters.Location = new System.Drawing.Point(12, 10);
            this.gpFilters.Name = "gpFilters";
            this.gpFilters.Size = new System.Drawing.Size(553, 74);
            this.gpFilters.TabIndex = 7;
            this.gpFilters.TabStop = false;
            this.gpFilters.Text = "Filter Results By";
            // 
            // cmdAddKit
            // 
            this.cmdAddKit.Location = new System.Drawing.Point(452, 48);
            this.cmdAddKit.Name = "cmdAddKit";
            this.cmdAddKit.Size = new System.Drawing.Size(86, 23);
            this.cmdAddKit.TabIndex = 51;
            this.cmdAddKit.Text = "Add Kit";
            this.cmdAddKit.UseVisualStyleBackColor = true;
            this.cmdAddKit.Visible = false;
            this.cmdAddKit.Click += new System.EventHandler(this.cmdAddKit_Click);
            // 
            // cmdAddComment
            // 
            this.cmdAddComment.Location = new System.Drawing.Point(452, 47);
            this.cmdAddComment.Name = "cmdAddComment";
            this.cmdAddComment.Size = new System.Drawing.Size(86, 23);
            this.cmdAddComment.TabIndex = 50;
            this.cmdAddComment.Text = "Add Comment";
            this.cmdAddComment.UseVisualStyleBackColor = true;
            this.cmdAddComment.Visible = false;
            this.cmdAddComment.Click += new System.EventHandler(this.cmdAddComment_Click);
            // 
            // chkKitItem
            // 
            this.chkKitItem.AutoSize = true;
            this.chkKitItem.Location = new System.Drawing.Point(452, 23);
            this.chkKitItem.Name = "chkKitItem";
            this.chkKitItem.Size = new System.Drawing.Size(15, 14);
            this.chkKitItem.TabIndex = 3;
            this.chkKitItem.UseVisualStyleBackColor = true;
            this.chkKitItem.Visible = false;
            this.chkKitItem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chkKitItem_KeyDown);
            // 
            // lblKit
            // 
            this.lblKit.AutoSize = true;
            this.lblKit.Location = new System.Drawing.Point(397, 24);
            this.lblKit.Name = "lblKit";
            this.lblKit.Size = new System.Drawing.Size(48, 13);
            this.lblKit.TabIndex = 0;
            this.lblKit.Text = "Kit Item?";
            this.lblKit.Visible = false;
            // 
            // txtDescription
            // 
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescription.Location = new System.Drawing.Point(259, 22);
            this.txtDescription.MaxLength = 40;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(100, 20);
            this.txtDescription.TabIndex = 2;
            this.txtDescription.TextChanged += new System.EventHandler(this.txtDescription_TextChanged);
            this.txtDescription.Enter += new System.EventHandler(this.txtCode_Enter);
            this.txtDescription.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCode_KeyDown);
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(184, 24);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(60, 13);
            this.lblDescription.TabIndex = 0;
            this.lblDescription.Text = "Description";
            // 
            // lblStoreValue
            // 
            this.lblStoreValue.AutoSize = true;
            this.lblStoreValue.Location = new System.Drawing.Point(111, 50);
            this.lblStoreValue.Name = "lblStoreValue";
            this.lblStoreValue.Size = new System.Drawing.Size(0, 13);
            this.lblStoreValue.TabIndex = 49;
            // 
            // lblStoreLabel
            // 
            this.lblStoreLabel.AutoSize = true;
            this.lblStoreLabel.Location = new System.Drawing.Point(19, 50);
            this.lblStoreLabel.Name = "lblStoreLabel";
            this.lblStoreLabel.Size = new System.Drawing.Size(77, 13);
            this.lblStoreLabel.TabIndex = 48;
            this.lblStoreLabel.Text = "Selected Store";
            // 
            // cmdInventorySearch
            // 
            this.cmdInventorySearch.BackColor = System.Drawing.Color.White;
            this.cmdInventorySearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdInventorySearch.Image = ((System.Drawing.Image)(resources.GetObject("cmdInventorySearch.Image")));
            this.cmdInventorySearch.Location = new System.Drawing.Point(513, 18);
            this.cmdInventorySearch.Name = "cmdInventorySearch";
            this.cmdInventorySearch.Size = new System.Drawing.Size(25, 23);
            this.cmdInventorySearch.TabIndex = 4;
            this.cmdInventorySearch.UseVisualStyleBackColor = false;
            this.cmdInventorySearch.Click += new System.EventHandler(this.cmdInventorySearch_Click);
            // 
            // txtCode
            // 
            this.txtCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCode.Location = new System.Drawing.Point(66, 21);
            this.txtCode.MaxLength = 6;
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(100, 20);
            this.txtCode.TabIndex = 1;
            this.txtCode.TextChanged += new System.EventHandler(this.txtCode_TextChanged);
            this.txtCode.Enter += new System.EventHandler(this.txtCode_Enter);
            this.txtCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCode_KeyDown);
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Location = new System.Drawing.Point(19, 24);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(32, 13);
            this.lblCode.TabIndex = 0;
            this.lblCode.Text = "Code";
            // 
            // dgInventory
            // 
            this.dgInventory.AllowUserToAddRows = false;
            this.dgInventory.AllowUserToDeleteRows = false;
            this.dgInventory.AllowUserToResizeColumns = false;
            this.dgInventory.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.GhostWhite;
            this.dgInventory.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgInventory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clCode,
            this.clDescription,
            this.clKit,
            this.clQuoteNumber});
            this.dgInventory.Location = new System.Drawing.Point(12, 99);
            this.dgInventory.Name = "dgInventory";
            this.dgInventory.ReadOnly = true;
            this.dgInventory.RowHeadersVisible = false;
            this.dgInventory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgInventory.Size = new System.Drawing.Size(553, 333);
            this.dgInventory.TabIndex = 6;
            this.dgInventory.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgInventory_CellContentClick);
            this.dgInventory.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgInventory_CellDoubleClick);
            this.dgInventory.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgInventory_KeyDown);
            this.dgInventory.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgInventory_KeyPress);
            // 
            // clCode
            // 
            this.clCode.DataPropertyName = "ItemCode";
            this.clCode.HeaderText = "Inventory Code";
            this.clCode.Name = "clCode";
            this.clCode.ReadOnly = true;
            this.clCode.Width = 150;
            // 
            // clDescription
            // 
            this.clDescription.DataPropertyName = "Description";
            this.clDescription.HeaderText = "Description";
            this.clDescription.Name = "clDescription";
            this.clDescription.ReadOnly = true;
            this.clDescription.Width = 350;
            // 
            // clKit
            // 
            this.clKit.DataPropertyName = "clKit";
            this.clKit.FalseValue = "0";
            this.clKit.HeaderText = "Kit";
            this.clKit.IndeterminateValue = "0";
            this.clKit.Name = "clKit";
            this.clKit.ReadOnly = true;
            this.clKit.TrueValue = "1";
            this.clKit.Width = 50;
            // 
            // clQuoteNumber
            // 
            this.clQuoteNumber.DataPropertyName = "DocNumber";
            this.clQuoteNumber.HeaderText = "QuoteNumber";
            this.clQuoteNumber.Name = "clQuoteNumber";
            this.clQuoteNumber.ReadOnly = true;
            this.clQuoteNumber.Visible = false;
            // 
            // Inventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 444);
            this.Controls.Add(this.gpFilters);
            this.Controls.Add(this.dgInventory);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Inventory";
            this.Text = "Inventory";
            this.Load += new System.EventHandler(this.Inventory_Load);
            this.gpFilters.ResumeLayout(false);
            this.gpFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgInventory)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox gpFilters;
		private System.Windows.Forms.TextBox txtCode;
		private System.Windows.Forms.Label lblCode;
		private System.Windows.Forms.DataGridView dgInventory;
		private System.Windows.Forms.Label lblStoreValue;
		private System.Windows.Forms.Label lblStoreLabel;
        private System.Windows.Forms.Button cmdInventorySearch;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblKit;
        private System.Windows.Forms.CheckBox chkKitItem;
        public System.Windows.Forms.Button cmdAddComment;
        private System.Windows.Forms.DataGridViewTextBoxColumn clCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDescription;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clKit;
        private System.Windows.Forms.DataGridViewTextBoxColumn clQuoteNumber;
        private System.Windows.Forms.Button cmdAddKit;
	}
}