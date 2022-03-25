namespace Liquid.Controls
{
	partial class InvoiceLine
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvoiceLine));
            this.txtStore = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtUnit = new System.Windows.Forms.TextBox();
            this.txtPeriod = new System.Windows.Forms.TextBox();
            this.txtExcPrice = new System.Windows.Forms.TextBox();
            this.txtNet = new System.Windows.Forms.TextBox();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.dtReturnDate = new System.Windows.Forms.DateTimePicker();
            this.lblReturnDate = new System.Windows.Forms.Label();
            this.lblDeliveryDate = new System.Windows.Forms.Label();
            this.dtDelivery = new System.Windows.Forms.DateTimePicker();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.txtLastInvoiceDate = new System.Windows.Forms.TextBox();
            this.picInfo = new System.Windows.Forms.PictureBox();
            this.cmdCodeSearch = new System.Windows.Forms.Button();
            this.cmdSearchStore = new System.Windows.Forms.Button();
            this.picReturned = new System.Windows.Forms.PictureBox();
            this.picDelete = new System.Windows.Forms.PictureBox();
            this.txtTaxType = new System.Windows.Forms.TextBox();
            this.txtDiscountType = new System.Windows.Forms.TextBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.cmdCredit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picReturned)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDelete)).BeginInit();
            this.SuspendLayout();
            // 
            // txtStore
            // 
            this.txtStore.BackColor = System.Drawing.Color.White;
            this.txtStore.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtStore.Location = new System.Drawing.Point(0, 3);
            this.txtStore.Name = "txtStore";
            this.txtStore.ReadOnly = true;
            this.txtStore.Size = new System.Drawing.Size(35, 13);
            this.txtStore.TabIndex = 0;
            this.txtStore.Visible = false;
            // 
            // txtDescription
            // 
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDescription.Location = new System.Drawing.Point(115, 3);
            this.txtDescription.MaxLength = 40;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(240, 13);
            this.txtDescription.TabIndex = 33;
            this.txtDescription.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextControl);
            // 
            // txtUnit
            // 
            this.txtUnit.BackColor = System.Drawing.Color.White;
            this.txtUnit.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUnit.Location = new System.Drawing.Point(563, 3);
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.ReadOnly = true;
            this.txtUnit.Size = new System.Drawing.Size(50, 13);
            this.txtUnit.TabIndex = 36;
            this.txtUnit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtPeriod
            // 
            this.txtPeriod.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPeriod.Location = new System.Drawing.Point(694, 4);
            this.txtPeriod.Name = "txtPeriod";
            this.txtPeriod.Size = new System.Drawing.Size(50, 13);
            this.txtPeriod.TabIndex = 37;
            this.txtPeriod.Text = "1.00";
            this.txtPeriod.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPeriod.TextChanged += new System.EventHandler(this.txtQuantity_TextChanged);
            this.txtPeriod.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextControl);
            this.txtPeriod.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numeric_KeyPress);
            this.txtPeriod.Leave += new System.EventHandler(this.txtQuantity_Leave);
            // 
            // txtExcPrice
            // 
            this.txtExcPrice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtExcPrice.Location = new System.Drawing.Point(817, 4);
            this.txtExcPrice.Name = "txtExcPrice";
            this.txtExcPrice.Size = new System.Drawing.Size(70, 13);
            this.txtExcPrice.TabIndex = 38;
            this.txtExcPrice.Text = "0";
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
            this.txtNet.Location = new System.Drawing.Point(895, 3);
            this.txtNet.Name = "txtNet";
            this.txtNet.ReadOnly = true;
            this.txtNet.Size = new System.Drawing.Size(71, 13);
            this.txtNet.TabIndex = 39;
            this.txtNet.Text = "0";
            this.txtNet.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtCode
            // 
            this.txtCode.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCode.Location = new System.Drawing.Point(4, 3);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(86, 13);
            this.txtCode.TabIndex = 40;
            this.txtCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextControl);
            // 
            // txtDiscount
            // 
            this.txtDiscount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDiscount.Location = new System.Drawing.Point(764, 4);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(39, 13);
            this.txtDiscount.TabIndex = 42;
            this.txtDiscount.Text = "0";
            this.txtDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDiscount.TextChanged += new System.EventHandler(this.txtQuantity_TextChanged);
            this.txtDiscount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextControl);
            this.txtDiscount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numeric_KeyPress);
            this.txtDiscount.Leave += new System.EventHandler(this.txtDiscount_Leave);
            // 
            // dtReturnDate
            // 
            this.dtReturnDate.CustomFormat = "dd/MM/yy";
            this.dtReturnDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtReturnDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtReturnDate.Location = new System.Drawing.Point(482, 0);
            this.dtReturnDate.Name = "dtReturnDate";
            this.dtReturnDate.Size = new System.Drawing.Size(70, 20);
            this.dtReturnDate.TabIndex = 51;
            this.dtReturnDate.Visible = false;
            this.dtReturnDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextControl);
            // 
            // lblReturnDate
            // 
            this.lblReturnDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReturnDate.Location = new System.Drawing.Point(479, 2);
            this.lblReturnDate.Margin = new System.Windows.Forms.Padding(0);
            this.lblReturnDate.Name = "lblReturnDate";
            this.lblReturnDate.Size = new System.Drawing.Size(77, 15);
            this.lblReturnDate.TabIndex = 52;
            this.lblReturnDate.Text = "-";
            this.lblReturnDate.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblDeliveryDate
            // 
            this.lblDeliveryDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeliveryDate.Location = new System.Drawing.Point(369, 2);
            this.lblDeliveryDate.Margin = new System.Windows.Forms.Padding(0);
            this.lblDeliveryDate.Name = "lblDeliveryDate";
            this.lblDeliveryDate.Size = new System.Drawing.Size(77, 15);
            this.lblDeliveryDate.TabIndex = 54;
            this.lblDeliveryDate.Text = "-";
            this.lblDeliveryDate.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dtDelivery
            // 
            this.dtDelivery.CustomFormat = "dd/MM/yy";
            this.dtDelivery.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDelivery.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDelivery.Location = new System.Drawing.Point(378, 0);
            this.dtDelivery.Name = "dtDelivery";
            this.dtDelivery.Size = new System.Drawing.Size(70, 20);
            this.dtDelivery.TabIndex = 53;
            this.dtDelivery.Visible = false;
            this.dtDelivery.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextControl);
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(890, 1);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(100, 20);
            this.txtStatus.TabIndex = 55;
            this.txtStatus.Visible = false;
            // 
            // txtLastInvoiceDate
            // 
            this.txtLastInvoiceDate.Location = new System.Drawing.Point(890, 1);
            this.txtLastInvoiceDate.Name = "txtLastInvoiceDate";
            this.txtLastInvoiceDate.Size = new System.Drawing.Size(100, 20);
            this.txtLastInvoiceDate.TabIndex = 58;
            this.txtLastInvoiceDate.Visible = false;
            // 
            // picInfo
            // 
            this.picInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picInfo.Image = global::Liquid.Properties.Resources.information;
            this.picInfo.Location = new System.Drawing.Point(982, 1);
            this.picInfo.Name = "picInfo";
            this.picInfo.Size = new System.Drawing.Size(18, 18);
            this.picInfo.TabIndex = 57;
            this.picInfo.TabStop = false;
            this.picInfo.Visible = false;
            this.picInfo.Click += new System.EventHandler(this.picInfo_Click);
            // 
            // cmdCodeSearch
            // 
            this.cmdCodeSearch.BackColor = System.Drawing.Color.Transparent;
            this.cmdCodeSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdCodeSearch.Image = ((System.Drawing.Image)(resources.GetObject("cmdCodeSearch.Image")));
            this.cmdCodeSearch.Location = new System.Drawing.Point(92, 0);
            this.cmdCodeSearch.Margin = new System.Windows.Forms.Padding(0);
            this.cmdCodeSearch.Name = "cmdCodeSearch";
            this.cmdCodeSearch.Size = new System.Drawing.Size(20, 20);
            this.cmdCodeSearch.TabIndex = 41;
            this.cmdCodeSearch.UseVisualStyleBackColor = false;
            this.cmdCodeSearch.Click += new System.EventHandler(this.cmdCodeSearch_Click);
            // 
            // cmdSearchStore
            // 
            this.cmdSearchStore.BackColor = System.Drawing.Color.Transparent;
            this.cmdSearchStore.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdSearchStore.Location = new System.Drawing.Point(36, 0);
            this.cmdSearchStore.Margin = new System.Windows.Forms.Padding(0);
            this.cmdSearchStore.Name = "cmdSearchStore";
            this.cmdSearchStore.Size = new System.Drawing.Size(20, 20);
            this.cmdSearchStore.TabIndex = 32;
            this.cmdSearchStore.UseVisualStyleBackColor = false;
            this.cmdSearchStore.Visible = false;
            this.cmdSearchStore.Click += new System.EventHandler(this.cmdSearchStore_Click);
            // 
            // picReturned
            // 
            this.picReturned.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picReturned.Image = global::Liquid.Properties.Resources.undo1;
            this.picReturned.Location = new System.Drawing.Point(402, 1);
            this.picReturned.Name = "picReturned";
            this.picReturned.Size = new System.Drawing.Size(18, 18);
            this.picReturned.TabIndex = 59;
            this.picReturned.TabStop = false;
            this.picReturned.Visible = false;
            // 
            // picDelete
            // 
            this.picDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picDelete.Image = global::Liquid.Properties.Resources.delete1;
            this.picDelete.Location = new System.Drawing.Point(982, 2);
            this.picDelete.Name = "picDelete";
            this.picDelete.Size = new System.Drawing.Size(18, 18);
            this.picDelete.TabIndex = 60;
            this.picDelete.TabStop = false;
            this.picDelete.Click += new System.EventHandler(this.picDelete_Click);
            // 
            // txtTaxType
            // 
            this.txtTaxType.Location = new System.Drawing.Point(348, 2);
            this.txtTaxType.Name = "txtTaxType";
            this.txtTaxType.Size = new System.Drawing.Size(16, 20);
            this.txtTaxType.TabIndex = 61;
            this.txtTaxType.Visible = false;
            // 
            // txtDiscountType
            // 
            this.txtDiscountType.Location = new System.Drawing.Point(599, 0);
            this.txtDiscountType.Name = "txtDiscountType";
            this.txtDiscountType.Size = new System.Drawing.Size(10, 20);
            this.txtDiscountType.TabIndex = 62;
            this.txtDiscountType.Text = "0";
            this.txtDiscountType.Visible = false;
            // 
            // txtQuantity
            // 
            this.txtQuantity.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtQuantity.Location = new System.Drawing.Point(630, 4);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtQuantity.Size = new System.Drawing.Size(50, 13);
            this.txtQuantity.TabIndex = 63;
            this.txtQuantity.Text = "1.00";
            this.txtQuantity.TextChanged += new System.EventHandler(this.txtQuantity_TextChanged);
            this.txtQuantity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextControl);
            this.txtQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numeric_KeyPress);
            this.txtQuantity.Leave += new System.EventHandler(this.txtQuantity_Leave);
            // 
            // cmdCredit
            // 
            this.cmdCredit.BackColor = System.Drawing.Color.DarkRed;
            this.cmdCredit.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCredit.ForeColor = System.Drawing.Color.White;
            this.cmdCredit.Location = new System.Drawing.Point(481, 0);
            this.cmdCredit.Name = "cmdCredit";
            this.cmdCredit.Size = new System.Drawing.Size(71, 22);
            this.cmdCredit.TabIndex = 56;
            this.cmdCredit.Text = "Credit Line";
            this.cmdCredit.UseVisualStyleBackColor = false;
            this.cmdCredit.Visible = false;
            // 
            // InvoiceLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.txtDiscountType);
            this.Controls.Add(this.txtTaxType);
            this.Controls.Add(this.picDelete);
            this.Controls.Add(this.picReturned);
            this.Controls.Add(this.picInfo);
            this.Controls.Add(this.dtDelivery);
            this.Controls.Add(this.dtReturnDate);
            this.Controls.Add(this.txtDiscount);
            this.Controls.Add(this.cmdCodeSearch);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.txtNet);
            this.Controls.Add(this.txtExcPrice);
            this.Controls.Add(this.txtPeriod);
            this.Controls.Add(this.txtUnit);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.cmdSearchStore);
            this.Controls.Add(this.txtStore);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.txtLastInvoiceDate);
            this.Controls.Add(this.cmdCredit);
            this.Controls.Add(this.lblReturnDate);
            this.Controls.Add(this.lblDeliveryDate);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "InvoiceLine";
            this.Size = new System.Drawing.Size(1003, 20);
            this.Load += new System.EventHandler(this.InvoiceLine_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextControl);
            ((System.ComponentModel.ISupportInitialize)(this.picInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picReturned)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDelete)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		public System.Windows.Forms.TextBox txtStore;
		public System.Windows.Forms.Button cmdSearchStore;
		public System.Windows.Forms.TextBox txtDescription;
		public System.Windows.Forms.TextBox txtUnit;
		public System.Windows.Forms.TextBox txtPeriod;
		public System.Windows.Forms.TextBox txtExcPrice;
		public System.Windows.Forms.TextBox txtNet;
		public System.Windows.Forms.Button cmdCodeSearch;
		public System.Windows.Forms.TextBox txtCode;
		public System.Windows.Forms.TextBox txtDiscount;
		public System.Windows.Forms.DateTimePicker dtReturnDate;
		public System.Windows.Forms.DateTimePicker dtDelivery;
		public System.Windows.Forms.Label lblReturnDate;
		public System.Windows.Forms.Label lblDeliveryDate;
        public System.Windows.Forms.TextBox txtStatus;
		public System.Windows.Forms.PictureBox picInfo;
		public System.Windows.Forms.TextBox txtLastInvoiceDate;
		public System.Windows.Forms.PictureBox picReturned;
		public System.Windows.Forms.PictureBox picDelete;
        public System.Windows.Forms.TextBox txtTaxType;
        public System.Windows.Forms.TextBox txtDiscountType;
        public System.Windows.Forms.TextBox txtQuantity;
        public System.Windows.Forms.Button cmdCredit;

	}
}
