namespace Liquid.Forms
{
    partial class AddItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddItem));
            this.cmdSearch = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdSave = new System.Windows.Forms.Button();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.chkAsset = new System.Windows.Forms.CheckBox();
            this.lblAsset = new System.Windows.Forms.Label();
            this.selStore = new System.Windows.Forms.ComboBox();
            this.lblStore = new System.Windows.Forms.Label();
            this.chkBlocked = new System.Windows.Forms.CheckBox();
            this.lblBlocked = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtItemCode = new System.Windows.Forms.TextBox();
            this.lblItemCode = new System.Windows.Forms.Label();
            this.tabAssetInformation = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lblSupplier = new System.Windows.Forms.Label();
            this.txtSupplierName = new System.Windows.Forms.TextBox();
            this.cmdSupplierName = new System.Windows.Forms.Button();
            this.lblSellingPrice = new System.Windows.Forms.Label();
            this.txtSellingPrice = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblSales = new System.Windows.Forms.Label();
            this.selTaxSales = new System.Windows.Forms.ComboBox();
            this.lblPurchase = new System.Windows.Forms.Label();
            this.selTaxPurchases = new System.Windows.Forms.ComboBox();
            this.lblAllowTax = new System.Windows.Forms.Label();
            this.chkAllowTax = new System.Windows.Forms.CheckBox();
            this.lblUnit = new System.Windows.Forms.Label();
            this.chkUnit = new System.Windows.Forms.ComboBox();
            this.tabInventoryDetail = new System.Windows.Forms.TabControl();
            this.pnlHeader.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabInventoryDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdSearch
            // 
            this.cmdSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdSearch.FlatAppearance.BorderSize = 0;
            this.cmdSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdSearch.Image = ((System.Drawing.Image)(resources.GetObject("cmdSearch.Image")));
            this.cmdSearch.Location = new System.Drawing.Point(99, 12);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(24, 24);
            this.cmdSearch.TabIndex = 155;
            this.cmdSearch.UseVisualStyleBackColor = true;
            // 
            // cmdCancel
            // 
            this.cmdCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdCancel.FlatAppearance.BorderSize = 0;
            this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdCancel.Image = ((System.Drawing.Image)(resources.GetObject("cmdCancel.Image")));
            this.cmdCancel.Location = new System.Drawing.Point(53, 12);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(24, 24);
            this.cmdCancel.TabIndex = 154;
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // cmdSave
            // 
            this.cmdSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdSave.Enabled = false;
            this.cmdSave.FlatAppearance.BorderSize = 0;
            this.cmdSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdSave.Image = ((System.Drawing.Image)(resources.GetObject("cmdSave.Image")));
            this.cmdSave.Location = new System.Drawing.Point(21, 12);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(24, 24);
            this.cmdSave.TabIndex = 153;
            this.cmdSave.UseVisualStyleBackColor = true;
            // 
            // pnlHeader
            // 
            this.pnlHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlHeader.Controls.Add(this.chkAsset);
            this.pnlHeader.Controls.Add(this.lblAsset);
            this.pnlHeader.Controls.Add(this.selStore);
            this.pnlHeader.Controls.Add(this.lblStore);
            this.pnlHeader.Controls.Add(this.chkBlocked);
            this.pnlHeader.Controls.Add(this.lblBlocked);
            this.pnlHeader.Controls.Add(this.txtDescription);
            this.pnlHeader.Controls.Add(this.lblDescription);
            this.pnlHeader.Controls.Add(this.txtItemCode);
            this.pnlHeader.Controls.Add(this.lblItemCode);
            this.pnlHeader.Location = new System.Drawing.Point(21, 42);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(461, 110);
            this.pnlHeader.TabIndex = 156;
            // 
            // chkAsset
            // 
            this.chkAsset.AutoSize = true;
            this.chkAsset.Location = new System.Drawing.Point(392, 10);
            this.chkAsset.Name = "chkAsset";
            this.chkAsset.Size = new System.Drawing.Size(15, 14);
            this.chkAsset.TabIndex = 108;
            this.chkAsset.UseVisualStyleBackColor = true;
            // 
            // lblAsset
            // 
            this.lblAsset.AutoSize = true;
            this.lblAsset.Location = new System.Drawing.Point(341, 10);
            this.lblAsset.Name = "lblAsset";
            this.lblAsset.Size = new System.Drawing.Size(39, 13);
            this.lblAsset.TabIndex = 107;
            this.lblAsset.Text = "Asset?";
            // 
            // selStore
            // 
            this.selStore.FormattingEnabled = true;
            this.selStore.Items.AddRange(new object[] {
            "Current",
            "30 Days",
            "60 Days",
            "90 Days",
            "120 Days"});
            this.selStore.Location = new System.Drawing.Point(95, 60);
            this.selStore.Name = "selStore";
            this.selStore.Size = new System.Drawing.Size(312, 21);
            this.selStore.TabIndex = 106;
            this.selStore.Text = "Current";
            // 
            // lblStore
            // 
            this.lblStore.AutoSize = true;
            this.lblStore.Location = new System.Drawing.Point(3, 63);
            this.lblStore.Name = "lblStore";
            this.lblStore.Size = new System.Drawing.Size(32, 13);
            this.lblStore.TabIndex = 105;
            this.lblStore.Text = "Store";
            // 
            // chkBlocked
            // 
            this.chkBlocked.AutoSize = true;
            this.chkBlocked.Location = new System.Drawing.Point(272, 10);
            this.chkBlocked.Name = "chkBlocked";
            this.chkBlocked.Size = new System.Drawing.Size(15, 14);
            this.chkBlocked.TabIndex = 2;
            this.chkBlocked.UseVisualStyleBackColor = true;
            // 
            // lblBlocked
            // 
            this.lblBlocked.AutoSize = true;
            this.lblBlocked.Location = new System.Drawing.Point(220, 10);
            this.lblBlocked.Name = "lblBlocked";
            this.lblBlocked.Size = new System.Drawing.Size(46, 13);
            this.lblBlocked.TabIndex = 101;
            this.lblBlocked.Text = "Blocked";
            // 
            // txtDescription
            // 
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescription.Location = new System.Drawing.Point(95, 34);
            this.txtDescription.MaxLength = 40;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(312, 20);
            this.txtDescription.TabIndex = 3;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(3, 36);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(60, 13);
            this.lblDescription.TabIndex = 102;
            this.lblDescription.Text = "Description";
            // 
            // txtItemCode
            // 
            this.txtItemCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtItemCode.Location = new System.Drawing.Point(95, 8);
            this.txtItemCode.MaxLength = 6;
            this.txtItemCode.Name = "txtItemCode";
            this.txtItemCode.Size = new System.Drawing.Size(100, 20);
            this.txtItemCode.TabIndex = 1;
            // 
            // lblItemCode
            // 
            this.lblItemCode.AutoSize = true;
            this.lblItemCode.Location = new System.Drawing.Point(3, 11);
            this.lblItemCode.Name = "lblItemCode";
            this.lblItemCode.Size = new System.Drawing.Size(32, 13);
            this.lblItemCode.TabIndex = 100;
            this.lblItemCode.Text = "Code";
            // 
            // tabAssetInformation
            // 
            this.tabAssetInformation.BackColor = System.Drawing.SystemColors.Control;
            this.tabAssetInformation.Location = new System.Drawing.Point(4, 22);
            this.tabAssetInformation.Name = "tabAssetInformation";
            this.tabAssetInformation.Padding = new System.Windows.Forms.Padding(3);
            this.tabAssetInformation.Size = new System.Drawing.Size(453, 319);
            this.tabAssetInformation.TabIndex = 3;
            this.tabAssetInformation.Text = "Asset Info";
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage1.Controls.Add(this.lblSupplier);
            this.tabPage1.Controls.Add(this.txtSupplierName);
            this.tabPage1.Controls.Add(this.cmdSupplierName);
            this.tabPage1.Controls.Add(this.lblSellingPrice);
            this.tabPage1.Controls.Add(this.txtSellingPrice);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.lblUnit);
            this.tabPage1.Controls.Add(this.chkUnit);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(453, 319);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Details";
            // 
            // lblSupplier
            // 
            this.lblSupplier.AutoSize = true;
            this.lblSupplier.Location = new System.Drawing.Point(10, 45);
            this.lblSupplier.Name = "lblSupplier";
            this.lblSupplier.Size = new System.Drawing.Size(45, 13);
            this.lblSupplier.TabIndex = 160;
            this.lblSupplier.Text = "Supplier";
            // 
            // txtSupplierName
            // 
            this.txtSupplierName.BackColor = System.Drawing.SystemColors.Control;
            this.txtSupplierName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSupplierName.Location = new System.Drawing.Point(177, 43);
            this.txtSupplierName.MaxLength = 16;
            this.txtSupplierName.Name = "txtSupplierName";
            this.txtSupplierName.ReadOnly = true;
            this.txtSupplierName.Size = new System.Drawing.Size(150, 20);
            this.txtSupplierName.TabIndex = 159;
            // 
            // cmdSupplierName
            // 
            this.cmdSupplierName.BackColor = System.Drawing.Color.White;
            this.cmdSupplierName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdSupplierName.Image = ((System.Drawing.Image)(resources.GetObject("cmdSupplierName.Image")));
            this.cmdSupplierName.Location = new System.Drawing.Point(333, 40);
            this.cmdSupplierName.Name = "cmdSupplierName";
            this.cmdSupplierName.Size = new System.Drawing.Size(25, 23);
            this.cmdSupplierName.TabIndex = 158;
            this.cmdSupplierName.UseVisualStyleBackColor = false;
            // 
            // lblSellingPrice
            // 
            this.lblSellingPrice.AutoSize = true;
            this.lblSellingPrice.Location = new System.Drawing.Point(10, 20);
            this.lblSellingPrice.Name = "lblSellingPrice";
            this.lblSellingPrice.Size = new System.Drawing.Size(149, 13);
            this.lblSellingPrice.TabIndex = 113;
            this.lblSellingPrice.Text = "Selling/LeasePrice (Excl VAT)";
            // 
            // txtSellingPrice
            // 
            this.txtSellingPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSellingPrice.Location = new System.Drawing.Point(177, 18);
            this.txtSellingPrice.MaxLength = 6;
            this.txtSellingPrice.Name = "txtSellingPrice";
            this.txtSellingPrice.Size = new System.Drawing.Size(116, 20);
            this.txtSellingPrice.TabIndex = 112;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblSales);
            this.panel1.Controls.Add(this.selTaxSales);
            this.panel1.Controls.Add(this.lblPurchase);
            this.panel1.Controls.Add(this.selTaxPurchases);
            this.panel1.Controls.Add(this.lblAllowTax);
            this.panel1.Controls.Add(this.chkAllowTax);
            this.panel1.Location = new System.Drawing.Point(6, 168);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(439, 89);
            this.panel1.TabIndex = 111;
            // 
            // lblSales
            // 
            this.lblSales.AutoSize = true;
            this.lblSales.Location = new System.Drawing.Point(3, 49);
            this.lblSales.Name = "lblSales";
            this.lblSales.Size = new System.Drawing.Size(33, 13);
            this.lblSales.TabIndex = 114;
            this.lblSales.Text = "Sales";
            // 
            // selTaxSales
            // 
            this.selTaxSales.FormattingEnabled = true;
            this.selTaxSales.Items.AddRange(new object[] {
            "Current",
            "30 Days",
            "60 Days",
            "90 Days",
            "120 Days"});
            this.selTaxSales.Location = new System.Drawing.Point(68, 46);
            this.selTaxSales.Name = "selTaxSales";
            this.selTaxSales.Size = new System.Drawing.Size(312, 21);
            this.selTaxSales.TabIndex = 113;
            this.selTaxSales.Text = "Current";
            // 
            // lblPurchase
            // 
            this.lblPurchase.AutoSize = true;
            this.lblPurchase.Location = new System.Drawing.Point(3, 26);
            this.lblPurchase.Name = "lblPurchase";
            this.lblPurchase.Size = new System.Drawing.Size(57, 13);
            this.lblPurchase.TabIndex = 112;
            this.lblPurchase.Text = "Purchases";
            // 
            // selTaxPurchases
            // 
            this.selTaxPurchases.FormattingEnabled = true;
            this.selTaxPurchases.Items.AddRange(new object[] {
            "Current",
            "30 Days",
            "60 Days",
            "90 Days",
            "120 Days"});
            this.selTaxPurchases.Location = new System.Drawing.Point(68, 23);
            this.selTaxPurchases.Name = "selTaxPurchases";
            this.selTaxPurchases.Size = new System.Drawing.Size(312, 21);
            this.selTaxPurchases.TabIndex = 111;
            this.selTaxPurchases.Text = "Current";
            // 
            // lblAllowTax
            // 
            this.lblAllowTax.AutoSize = true;
            this.lblAllowTax.Location = new System.Drawing.Point(3, 4);
            this.lblAllowTax.Name = "lblAllowTax";
            this.lblAllowTax.Size = new System.Drawing.Size(59, 13);
            this.lblAllowTax.TabIndex = 109;
            this.lblAllowTax.Text = "Allow Tax?";
            // 
            // chkAllowTax
            // 
            this.chkAllowTax.AutoSize = true;
            this.chkAllowTax.Location = new System.Drawing.Point(68, 3);
            this.chkAllowTax.Name = "chkAllowTax";
            this.chkAllowTax.Size = new System.Drawing.Size(15, 14);
            this.chkAllowTax.TabIndex = 110;
            this.chkAllowTax.UseVisualStyleBackColor = true;
            // 
            // lblUnit
            // 
            this.lblUnit.AutoSize = true;
            this.lblUnit.Location = new System.Drawing.Point(10, 73);
            this.lblUnit.Name = "lblUnit";
            this.lblUnit.Size = new System.Drawing.Size(26, 13);
            this.lblUnit.TabIndex = 108;
            this.lblUnit.Text = "Unit";
            // 
            // chkUnit
            // 
            this.chkUnit.FormattingEnabled = true;
            this.chkUnit.Items.AddRange(new object[] {
            "Current",
            "30 Days",
            "60 Days",
            "90 Days",
            "120 Days"});
            this.chkUnit.Location = new System.Drawing.Point(177, 70);
            this.chkUnit.Name = "chkUnit";
            this.chkUnit.Size = new System.Drawing.Size(70, 21);
            this.chkUnit.TabIndex = 107;
            this.chkUnit.Text = "Current";
            // 
            // tabInventoryDetail
            // 
            this.tabInventoryDetail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabInventoryDetail.Controls.Add(this.tabPage1);
            this.tabInventoryDetail.Controls.Add(this.tabAssetInformation);
            this.tabInventoryDetail.Location = new System.Drawing.Point(21, 158);
            this.tabInventoryDetail.Name = "tabInventoryDetail";
            this.tabInventoryDetail.SelectedIndex = 0;
            this.tabInventoryDetail.Size = new System.Drawing.Size(461, 345);
            this.tabInventoryDetail.TabIndex = 157;
            // 
            // AddItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 515);
            this.Controls.Add(this.tabInventoryDetail);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.cmdSearch);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "AddItem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Item";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabInventoryDetail.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdSearch;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.CheckBox chkBlocked;
        private System.Windows.Forms.Label lblBlocked;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtItemCode;
        private System.Windows.Forms.Label lblItemCode;
        private System.Windows.Forms.ComboBox selStore;
        private System.Windows.Forms.Label lblStore;
        private System.Windows.Forms.CheckBox chkAsset;
        private System.Windows.Forms.Label lblAsset;
        private System.Windows.Forms.TabPage tabAssetInformation;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabControl tabInventoryDetail;
        private System.Windows.Forms.CheckBox chkAllowTax;
        private System.Windows.Forms.Label lblAllowTax;
        private System.Windows.Forms.Label lblUnit;
        private System.Windows.Forms.ComboBox chkUnit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblSales;
        private System.Windows.Forms.ComboBox selTaxSales;
        private System.Windows.Forms.Label lblPurchase;
        private System.Windows.Forms.ComboBox selTaxPurchases;
        private System.Windows.Forms.Label lblSellingPrice;
        private System.Windows.Forms.TextBox txtSellingPrice;
        private System.Windows.Forms.Button cmdSupplierName;
        private System.Windows.Forms.Label lblSupplier;
        private System.Windows.Forms.TextBox txtSupplierName;

    }
}