namespace Liquid.Controls
{
    partial class QouteLine
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QouteLine));
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtUnit = new System.Windows.Forms.TextBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.txtExcPrice = new System.Windows.Forms.TextBox();
            this.txtNet = new System.Windows.Forms.TextBox();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.txtLastInvoiceDate = new System.Windows.Forms.TextBox();
            this.txtTaxType = new System.Windows.Forms.TextBox();
            this.txtDiscountType = new System.Windows.Forms.TextBox();
            this.txtUnitFormula = new System.Windows.Forms.TextBox();
            this.picDelete = new System.Windows.Forms.PictureBox();
            this.cmdCodeSearch = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picDelete)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDescription
            // 
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDescription.Location = new System.Drawing.Point(115, 3);
            this.txtDescription.MaxLength = 50;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(417, 13);
            this.txtDescription.TabIndex = 41;
            this.txtDescription.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextControl);
            // 
            // txtUnit
            // 
            this.txtUnit.BackColor = System.Drawing.Color.White;
            this.txtUnit.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUnit.Location = new System.Drawing.Point(583, 3);
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.ReadOnly = true;
            this.txtUnit.Size = new System.Drawing.Size(31, 13);
            this.txtUnit.TabIndex = 36;
            this.txtUnit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtQuantity
            // 
            this.txtQuantity.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtQuantity.Location = new System.Drawing.Point(657, 3);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(50, 13);
            this.txtQuantity.TabIndex = 46;
            this.txtQuantity.Text = "1.00";
            this.txtQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtQuantity.TextChanged += new System.EventHandler(this.txtQuantity_TextChanged);
            this.txtQuantity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextControl);
            this.txtQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numeric_KeyPress);
            this.txtQuantity.Leave += new System.EventHandler(this.txtQuantity_Leave);
            // 
            // txtExcPrice
            // 
            this.txtExcPrice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtExcPrice.Location = new System.Drawing.Point(795, 3);
            this.txtExcPrice.Name = "txtExcPrice";
            this.txtExcPrice.Size = new System.Drawing.Size(70, 13);
            this.txtExcPrice.TabIndex = 48;
            this.txtExcPrice.Text = "0.00";
            this.txtExcPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtExcPrice.TextChanged += new System.EventHandler(this.txtQuantity_TextChanged);
            this.txtExcPrice.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextControl);
            this.txtExcPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numeric_KeyPress);
            this.txtExcPrice.Leave += new System.EventHandler(this.txtExcPrice_Leave);
            // 
            // txtNet
            // 
            this.txtNet.BackColor = System.Drawing.Color.White;
            this.txtNet.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNet.Location = new System.Drawing.Point(893, 3);
            this.txtNet.Name = "txtNet";
            this.txtNet.ReadOnly = true;
            this.txtNet.Size = new System.Drawing.Size(60, 13);
            this.txtNet.TabIndex = 39;
            this.txtNet.Text = "0.00";
            this.txtNet.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtCode
            // 
            this.txtCode.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCode.Location = new System.Drawing.Point(0, 3);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(92, 13);
            this.txtCode.TabIndex = 40;
            this.txtCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextControl);
            this.txtCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCode_KeyPress);
            // 
            // txtDiscount
            // 
            this.txtDiscount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDiscount.Location = new System.Drawing.Point(735, 3);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(50, 13);
            this.txtDiscount.TabIndex = 47;
            this.txtDiscount.Text = "0.00";
            this.txtDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDiscount.TextChanged += new System.EventHandler(this.txtQuantity_TextChanged);
            this.txtDiscount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextControl);
            this.txtDiscount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numeric_KeyPress);
            this.txtDiscount.Leave += new System.EventHandler(this.txtDiscount_Leave);
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(890, 1);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(1, 20);
            this.txtStatus.TabIndex = 55;
            this.txtStatus.Visible = false;
            // 
            // txtLastInvoiceDate
            // 
            this.txtLastInvoiceDate.Location = new System.Drawing.Point(890, 1);
            this.txtLastInvoiceDate.Name = "txtLastInvoiceDate";
            this.txtLastInvoiceDate.Size = new System.Drawing.Size(1, 20);
            this.txtLastInvoiceDate.TabIndex = 58;
            this.txtLastInvoiceDate.Visible = false;
            // 
            // txtTaxType
            // 
            this.txtTaxType.Location = new System.Drawing.Point(965, 1);
            this.txtTaxType.Name = "txtTaxType";
            this.txtTaxType.Size = new System.Drawing.Size(16, 20);
            this.txtTaxType.TabIndex = 61;
            this.txtTaxType.Visible = false;
            // 
            // txtDiscountType
            // 
            this.txtDiscountType.Location = new System.Drawing.Point(966, 0);
            this.txtDiscountType.Name = "txtDiscountType";
            this.txtDiscountType.Size = new System.Drawing.Size(10, 20);
            this.txtDiscountType.TabIndex = 62;
            this.txtDiscountType.Text = "0";
            this.txtDiscountType.Visible = false;
            // 
            // txtUnitFormula
            // 
            this.txtUnitFormula.BackColor = System.Drawing.Color.White;
            this.txtUnitFormula.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUnitFormula.Location = new System.Drawing.Point(573, 4);
            this.txtUnitFormula.Name = "txtUnitFormula";
            this.txtUnitFormula.ReadOnly = true;
            this.txtUnitFormula.Size = new System.Drawing.Size(31, 13);
            this.txtUnitFormula.TabIndex = 66;
            this.txtUnitFormula.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtUnitFormula.Visible = false;
            this.txtUnitFormula.TextChanged += new System.EventHandler(this.txtUnitFormula_TextChanged);
            // 
            // picDelete
            // 
            this.picDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picDelete.Image = global::Liquid.Properties.Resources.delete1;
            this.picDelete.Location = new System.Drawing.Point(959, 2);
            this.picDelete.Name = "picDelete";
            this.picDelete.Size = new System.Drawing.Size(18, 18);
            this.picDelete.TabIndex = 60;
            this.picDelete.TabStop = false;
            this.picDelete.Click += new System.EventHandler(this.picDelete_Click);
            // 
            // cmdCodeSearch
            // 
            this.cmdCodeSearch.BackColor = System.Drawing.Color.Transparent;
            this.cmdCodeSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdCodeSearch.Image = ((System.Drawing.Image)(resources.GetObject("cmdCodeSearch.Image")));
            this.cmdCodeSearch.Location = new System.Drawing.Point(90, 0);
            this.cmdCodeSearch.Margin = new System.Windows.Forms.Padding(0);
            this.cmdCodeSearch.Name = "cmdCodeSearch";
            this.cmdCodeSearch.Size = new System.Drawing.Size(20, 20);
            this.cmdCodeSearch.TabIndex = 41;
            this.cmdCodeSearch.UseVisualStyleBackColor = false;
            this.cmdCodeSearch.Click += new System.EventHandler(this.cmdCodeSearch_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.BackColor = System.Drawing.SystemColors.HighlightText;
            // 
            // QouteLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.picDelete);
            this.Controls.Add(this.txtDiscountType);
            this.Controls.Add(this.txtDiscount);
            this.Controls.Add(this.cmdCodeSearch);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.txtNet);
            this.Controls.Add(this.txtExcPrice);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.txtUnit);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtLastInvoiceDate);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.txtTaxType);
            this.Controls.Add(this.txtUnitFormula);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "QouteLine";
            this.Size = new System.Drawing.Size(979, 20);
            this.Load += new System.EventHandler(this.SalesLine_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextControl);
            ((System.ComponentModel.ISupportInitialize)(this.picDelete)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        public System.Windows.Forms.TextBox txtDescription;
		public System.Windows.Forms.TextBox txtUnit;
		public System.Windows.Forms.TextBox txtQuantity;
		public System.Windows.Forms.TextBox txtExcPrice;
		public System.Windows.Forms.TextBox txtNet;
		public System.Windows.Forms.Button cmdCodeSearch;
		public System.Windows.Forms.TextBox txtCode;
        public System.Windows.Forms.TextBox txtDiscount;
        public System.Windows.Forms.TextBox txtStatus;
        public System.Windows.Forms.TextBox txtLastInvoiceDate;
		public System.Windows.Forms.PictureBox picDelete;
        public System.Windows.Forms.TextBox txtTaxType;
        public System.Windows.Forms.TextBox txtDiscountType;
        public System.Windows.Forms.TextBox txtUnitFormula;
        public System.Windows.Forms.ToolTip toolTip1;

	}
}
