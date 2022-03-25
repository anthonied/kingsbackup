namespace Liquid.Controls
{
	partial class SalesLineForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SalesLineForm));
            this.txtStore = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtUnit = new System.Windows.Forms.TextBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.txtExcPrice = new System.Windows.Forms.TextBox();
            this.txtNet = new System.Windows.Forms.TextBox();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.dtReturnDate = new System.Windows.Forms.DateTimePicker();
            this.lblReturnDate = new System.Windows.Forms.Label();
            this.lblDeliveryDate = new System.Windows.Forms.Label();
            this.dtDelivery = new System.Windows.Forms.DateTimePicker();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.cmdCredit = new System.Windows.Forms.Button();
            this.txtLastInvoiceDate = new System.Windows.Forms.TextBox();
            this.txtTaxType = new System.Windows.Forms.TextBox();
            this.txtDiscountType = new System.Windows.Forms.TextBox();
            this.txtMultiplier = new System.Windows.Forms.TextBox();
            this.chkReturn = new System.Windows.Forms.CheckBox();
            this.txtUnitFormula = new System.Windows.Forms.TextBox();
            this.txtLineRuleID = new System.Windows.Forms.TextBox();
            this.cmdFromulaFinder = new System.Windows.Forms.Button();
            this.picInfo = new System.Windows.Forms.PictureBox();
            this.picDelete = new System.Windows.Forms.PictureBox();
            this.cmdCodeSearch = new System.Windows.Forms.Button();
            this.cmdSearchStore = new System.Windows.Forms.Button();
            this.picReturned = new System.Windows.Forms.PictureBox();
            this.picScaleInfo = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.picAddLine = new System.Windows.Forms.PictureBox();
            this.txtProject = new System.Windows.Forms.TextBox();
            this.cmdProjectSearch = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picReturned)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picScaleInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAddLine)).BeginInit();
            this.SuspendLayout();
            // 
            // txtStore
            // 
            this.txtStore.BackColor = System.Drawing.Color.White;
            this.txtStore.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtStore.Location = new System.Drawing.Point(16, 0);
            this.txtStore.Name = "txtStore";
            this.txtStore.ReadOnly = true;
            this.txtStore.Size = new System.Drawing.Size(25, 13);
            this.txtStore.TabIndex = 0;
            this.txtStore.Visible = false;
            // 
            // txtDescription
            // 
            this.txtDescription.BackColor = System.Drawing.SystemColors.Control;
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDescription.Location = new System.Drawing.Point(115, 3);
            this.txtDescription.MaxLength = 37;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.Size = new System.Drawing.Size(229, 13);
            this.txtDescription.TabIndex = 41;
            this.txtDescription.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextControl);
            this.txtDescription.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDescription_KeyPress);
            // 
            // txtUnit
            // 
            this.txtUnit.BackColor = System.Drawing.Color.White;
            this.txtUnit.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUnit.Location = new System.Drawing.Point(652, 3);
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.ReadOnly = true;
            this.txtUnit.Size = new System.Drawing.Size(31, 13);
            this.txtUnit.TabIndex = 36;
            this.txtUnit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtQuantity
            // 
            this.txtQuantity.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtQuantity.Location = new System.Drawing.Point(777, 3);
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
            this.txtExcPrice.Location = new System.Drawing.Point(902, 3);
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
            this.txtNet.Location = new System.Drawing.Point(982, 3);
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
            // 
            // txtDiscount
            // 
            this.txtDiscount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDiscount.Location = new System.Drawing.Point(842, 3);
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
            // dtReturnDate
            // 
            this.dtReturnDate.CustomFormat = "dd/MM/yy";
            this.dtReturnDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtReturnDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtReturnDate.Location = new System.Drawing.Point(525, -1);
            this.dtReturnDate.Name = "dtReturnDate";
            this.dtReturnDate.Size = new System.Drawing.Size(70, 20);
            this.dtReturnDate.TabIndex = 43;
            this.dtReturnDate.Visible = false;
            this.dtReturnDate.ValueChanged += new System.EventHandler(this.dtDelivery_ValueChanged);
            this.dtReturnDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextControl);
            // 
            // lblReturnDate
            // 
            this.lblReturnDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReturnDate.Location = new System.Drawing.Point(525, 3);
            this.lblReturnDate.Margin = new System.Windows.Forms.Padding(0);
            this.lblReturnDate.Name = "lblReturnDate";
            this.lblReturnDate.Size = new System.Drawing.Size(70, 15);
            this.lblReturnDate.TabIndex = 52;
            this.lblReturnDate.Text = "-";
            this.lblReturnDate.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblDeliveryDate
            // 
            this.lblDeliveryDate.BackColor = System.Drawing.Color.Transparent;
            this.lblDeliveryDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeliveryDate.Location = new System.Drawing.Point(445, 8);
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
            this.dtDelivery.Location = new System.Drawing.Point(445, -1);
            this.dtDelivery.Name = "dtDelivery";
            this.dtDelivery.Size = new System.Drawing.Size(70, 20);
            this.dtDelivery.TabIndex = 42;
            this.dtDelivery.Visible = false;
            this.dtDelivery.ValueChanged += new System.EventHandler(this.dtDelivery_ValueChanged);
            this.dtDelivery.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextControl);
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(890, 1);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(1, 20);
            this.txtStatus.TabIndex = 55;
            this.txtStatus.Visible = false;
            // 
            // cmdCredit
            // 
            this.cmdCredit.BackColor = System.Drawing.Color.DarkRed;
            this.cmdCredit.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCredit.ForeColor = System.Drawing.Color.White;
            this.cmdCredit.Location = new System.Drawing.Point(442, 21);
            this.cmdCredit.Name = "cmdCredit";
            this.cmdCredit.Size = new System.Drawing.Size(76, 22);
            this.cmdCredit.TabIndex = 56;
            this.cmdCredit.Text = "Credit Line";
            this.cmdCredit.UseVisualStyleBackColor = false;
            this.cmdCredit.Visible = false;
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
            this.txtTaxType.Location = new System.Drawing.Point(1048, 3);
            this.txtTaxType.Name = "txtTaxType";
            this.txtTaxType.Size = new System.Drawing.Size(11, 20);
            this.txtTaxType.TabIndex = 61;
            this.txtTaxType.Visible = false;
            // 
            // txtDiscountType
            // 
            this.txtDiscountType.Location = new System.Drawing.Point(1048, 1);
            this.txtDiscountType.Name = "txtDiscountType";
            this.txtDiscountType.Size = new System.Drawing.Size(10, 20);
            this.txtDiscountType.TabIndex = 62;
            this.txtDiscountType.Text = "0";
            this.txtDiscountType.Visible = false;
            // 
            // txtMultiplier
            // 
            this.txtMultiplier.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMultiplier.Location = new System.Drawing.Point(712, 3);
            this.txtMultiplier.Name = "txtMultiplier";
            this.txtMultiplier.Size = new System.Drawing.Size(50, 13);
            this.txtMultiplier.TabIndex = 45;
            this.txtMultiplier.Text = "1.00";
            this.txtMultiplier.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMultiplier.TextChanged += new System.EventHandler(this.txtQuantity_TextChanged);
            this.txtMultiplier.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextControl);
            this.txtMultiplier.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numeric_KeyPress);
            this.txtMultiplier.Leave += new System.EventHandler(this.txtQuantity_Leave);
            // 
            // chkReturn
            // 
            this.chkReturn.AutoSize = true;
            this.chkReturn.Enabled = false;
            this.chkReturn.Location = new System.Drawing.Point(620, 3);
            this.chkReturn.Name = "chkReturn";
            this.chkReturn.Size = new System.Drawing.Size(15, 14);
            this.chkReturn.TabIndex = 44;
            this.chkReturn.UseVisualStyleBackColor = true;
            this.chkReturn.CheckedChanged += new System.EventHandler(this.chkReturn_CheckedChanged);
            // 
            // txtUnitFormula
            // 
            this.txtUnitFormula.BackColor = System.Drawing.Color.White;
            this.txtUnitFormula.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUnitFormula.Location = new System.Drawing.Point(652, 3);
            this.txtUnitFormula.Name = "txtUnitFormula";
            this.txtUnitFormula.ReadOnly = true;
            this.txtUnitFormula.Size = new System.Drawing.Size(31, 13);
            this.txtUnitFormula.TabIndex = 66;
            this.txtUnitFormula.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtUnitFormula.Visible = false;
            // 
            // txtLineRuleID
            // 
            this.txtLineRuleID.BackColor = System.Drawing.Color.White;
            this.txtLineRuleID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLineRuleID.Location = new System.Drawing.Point(652, 3);
            this.txtLineRuleID.Name = "txtLineRuleID";
            this.txtLineRuleID.ReadOnly = true;
            this.txtLineRuleID.Size = new System.Drawing.Size(33, 13);
            this.txtLineRuleID.TabIndex = 67;
            this.txtLineRuleID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtLineRuleID.Visible = false;
            this.txtLineRuleID.TextChanged += new System.EventHandler(this.dtDelivery_ValueChanged);
            // 
            // cmdFromulaFinder
            // 
            this.cmdFromulaFinder.BackColor = System.Drawing.Color.Transparent;
            this.cmdFromulaFinder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdFromulaFinder.Image = ((System.Drawing.Image)(resources.GetObject("cmdFromulaFinder.Image")));
            this.cmdFromulaFinder.Location = new System.Drawing.Point(686, -1);
            this.cmdFromulaFinder.Margin = new System.Windows.Forms.Padding(0);
            this.cmdFromulaFinder.Name = "cmdFromulaFinder";
            this.cmdFromulaFinder.Size = new System.Drawing.Size(20, 20);
            this.cmdFromulaFinder.TabIndex = 65;
            this.cmdFromulaFinder.UseVisualStyleBackColor = false;
            this.cmdFromulaFinder.Visible = false;
            this.cmdFromulaFinder.Click += new System.EventHandler(this.cmdFromulaFinder_Click);
            // 
            // picInfo
            // 
            this.picInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picInfo.Image = global::Liquid.Properties.Resources.information;
            this.picInfo.Location = new System.Drawing.Point(1048, 1);
            this.picInfo.Name = "picInfo";
            this.picInfo.Size = new System.Drawing.Size(18, 18);
            this.picInfo.TabIndex = 57;
            this.picInfo.TabStop = false;
            this.picInfo.Visible = false;
            this.picInfo.Click += new System.EventHandler(this.picInfo_Click);
            // 
            // picDelete
            // 
            this.picDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picDelete.Image = global::Liquid.Properties.Resources.delete1;
            this.picDelete.Location = new System.Drawing.Point(1048, 1);
            this.picDelete.Name = "picDelete";
            this.picDelete.Size = new System.Drawing.Size(17, 18);
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
            // cmdSearchStore
            // 
            this.cmdSearchStore.BackColor = System.Drawing.Color.Transparent;
            this.cmdSearchStore.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdSearchStore.Image = ((System.Drawing.Image)(resources.GetObject("cmdSearchStore.Image")));
            this.cmdSearchStore.Location = new System.Drawing.Point(39, -3);
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
            this.picReturned.Location = new System.Drawing.Point(620, 3);
            this.picReturned.Name = "picReturned";
            this.picReturned.Size = new System.Drawing.Size(18, 18);
            this.picReturned.TabIndex = 59;
            this.picReturned.TabStop = false;
            this.picReturned.Visible = false;
            this.picReturned.DoubleClick += new System.EventHandler(this.picReturned_DoubleClick);
            // 
            // picScaleInfo
            // 
            this.picScaleInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picScaleInfo.Image = global::Liquid.Properties.Resources.information;
            this.picScaleInfo.Location = new System.Drawing.Point(791, 1);
            this.picScaleInfo.Name = "picScaleInfo";
            this.picScaleInfo.Size = new System.Drawing.Size(18, 18);
            this.picScaleInfo.TabIndex = 68;
            this.picScaleInfo.TabStop = false;
            this.picScaleInfo.Visible = false;
            // 
            // toolTip1
            // 
            this.toolTip1.BackColor = System.Drawing.SystemColors.HighlightText;
            // 
            // picAddLine
            // 
            this.picAddLine.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picAddLine.Image = global::Liquid.Properties.Resources.add2;
            this.picAddLine.Location = new System.Drawing.Point(1086, 1);
            this.picAddLine.Name = "picAddLine";
            this.picAddLine.Size = new System.Drawing.Size(16, 17);
            this.picAddLine.TabIndex = 69;
            this.picAddLine.TabStop = false;
            this.picAddLine.Click += new System.EventHandler(this.picAddLine_Click);
            // 
            // txtProject
            // 
            this.txtProject.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtProject.Location = new System.Drawing.Point(365, 3);
            this.txtProject.Name = "txtProject";
            this.txtProject.ReadOnly = true;
            this.txtProject.Size = new System.Drawing.Size(50, 13);
            this.txtProject.TabIndex = 70;
            this.txtProject.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextControl);
            // 
            // cmdProjectSearch
            // 
            this.cmdProjectSearch.BackColor = System.Drawing.Color.Transparent;
            this.cmdProjectSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdProjectSearch.Image = ((System.Drawing.Image)(resources.GetObject("cmdProjectSearch.Image")));
            this.cmdProjectSearch.Location = new System.Drawing.Point(420, 0);
            this.cmdProjectSearch.Margin = new System.Windows.Forms.Padding(0);
            this.cmdProjectSearch.Name = "cmdProjectSearch";
            this.cmdProjectSearch.Size = new System.Drawing.Size(20, 20);
            this.cmdProjectSearch.TabIndex = 42;
            this.cmdProjectSearch.UseVisualStyleBackColor = false;
            this.cmdProjectSearch.Click += new System.EventHandler(this.cmdProjectSearch_Click);
            // 
            // SalesLineForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.cmdProjectSearch);
            this.Controls.Add(this.txtProject);
            this.Controls.Add(this.picAddLine);
            this.Controls.Add(this.picDelete);
            this.Controls.Add(this.picScaleInfo);
            this.Controls.Add(this.cmdFromulaFinder);
            this.Controls.Add(this.picInfo);
            this.Controls.Add(this.txtDiscountType);
            this.Controls.Add(this.txtMultiplier);
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
            this.Controls.Add(this.lblReturnDate);
            this.Controls.Add(this.cmdCredit);
            this.Controls.Add(this.cmdSearchStore);
            this.Controls.Add(this.txtStore);
            this.Controls.Add(this.chkReturn);
            this.Controls.Add(this.picReturned);
            this.Controls.Add(this.lblDeliveryDate);
            this.Controls.Add(this.dtReturnDate);
            this.Controls.Add(this.dtDelivery);
            this.Controls.Add(this.txtLineRuleID);
            this.Controls.Add(this.txtUnitFormula);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "SalesLineForm";
            this.Size = new System.Drawing.Size(1113, 20);
            this.Load += new System.EventHandler(this.SalesLine_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextControl);
            ((System.ComponentModel.ISupportInitialize)(this.picInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picReturned)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picScaleInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAddLine)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		public System.Windows.Forms.TextBox txtStore;
		public System.Windows.Forms.Button cmdSearchStore;
		public System.Windows.Forms.TextBox txtDescription;
		public System.Windows.Forms.TextBox txtUnit;
		public System.Windows.Forms.TextBox txtQuantity;
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
		public System.Windows.Forms.Button cmdCredit;
		public System.Windows.Forms.PictureBox picInfo;
		public System.Windows.Forms.TextBox txtLastInvoiceDate;
		public System.Windows.Forms.PictureBox picReturned;
		public System.Windows.Forms.PictureBox picDelete;
        public System.Windows.Forms.TextBox txtTaxType;
        public System.Windows.Forms.TextBox txtDiscountType;
        public System.Windows.Forms.TextBox txtMultiplier;
        public System.Windows.Forms.CheckBox chkReturn;
        public System.Windows.Forms.Button cmdFromulaFinder;
        public System.Windows.Forms.TextBox txtUnitFormula;
        public System.Windows.Forms.TextBox txtLineRuleID;
        public System.Windows.Forms.PictureBox picScaleInfo;
        public System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.PictureBox picAddLine;
        public System.Windows.Forms.TextBox txtProject;
        public System.Windows.Forms.Button cmdProjectSearch;
    }
}
