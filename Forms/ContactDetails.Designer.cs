namespace Liquid.Forms
{
	partial class ContactDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContactDetails));
            this.pnlHeading = new System.Windows.Forms.Panel();
            this.lblHeading = new System.Windows.Forms.Label();
            this.lblCode = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblAd1 = new System.Windows.Forms.Label();
            this.pnlPostal = new System.Windows.Forms.Panel();
            this.txtAd5 = new System.Windows.Forms.TextBox();
            this.txtAd4 = new System.Windows.Forms.TextBox();
            this.txtAd3 = new System.Windows.Forms.TextBox();
            this.txtAd2 = new System.Windows.Forms.TextBox();
            this.txtAd1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtContact = new System.Windows.Forms.TextBox();
            this.txtTelephone = new System.Windows.Forms.TextBox();
            this.lblTelephone = new System.Windows.Forms.Label();
            this.txtFax = new System.Windows.Forms.TextBox();
            this.lblFax = new System.Windows.Forms.Label();
            this.txtMobile = new System.Windows.Forms.TextBox();
            this.lblMobile = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.cmdDelete = new System.Windows.Forms.Button();
            this.cmdNew = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdSave = new System.Windows.Forms.Button();
            this.txtAddNumber = new System.Windows.Forms.TextBox();
            this.selAddresses = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMarketer = new System.Windows.Forms.TextBox();
            this.cmdMarketerSearch = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCommissionFloor = new System.Windows.Forms.TextBox();
            this.txtCategory = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmdCategorySearch = new System.Windows.Forms.Button();
            this.pnlHeading.SuspendLayout();
            this.pnlPostal.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeading
            // 
            this.pnlHeading.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlHeading.Controls.Add(this.lblHeading);
            this.pnlHeading.Location = new System.Drawing.Point(12, 47);
            this.pnlHeading.Name = "pnlHeading";
            this.pnlHeading.Size = new System.Drawing.Size(372, 26);
            this.pnlHeading.TabIndex = 0;
            // 
            // lblHeading
            // 
            this.lblHeading.Location = new System.Drawing.Point(1, 2);
            this.lblHeading.Name = "lblHeading";
            this.lblHeading.Size = new System.Drawing.Size(370, 23);
            this.lblHeading.TabIndex = 0;
            this.lblHeading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Location = new System.Drawing.Point(14, 105);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(60, 13);
            this.lblCode.TabIndex = 1;
            this.lblCode.Text = "Description";
            // 
            // txtDescription
            // 
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescription.Location = new System.Drawing.Point(107, 102);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(189, 20);
            this.txtDescription.TabIndex = 2;
            this.txtDescription.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextControl);
            // 
            // lblAd1
            // 
            this.lblAd1.AutoSize = true;
            this.lblAd1.Location = new System.Drawing.Point(14, 140);
            this.lblAd1.Name = "lblAd1";
            this.lblAd1.Size = new System.Drawing.Size(45, 13);
            this.lblAd1.TabIndex = 3;
            this.lblAd1.Text = "Address";
            // 
            // pnlPostal
            // 
            this.pnlPostal.BackColor = System.Drawing.Color.White;
            this.pnlPostal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPostal.Controls.Add(this.txtAd5);
            this.pnlPostal.Controls.Add(this.txtAd4);
            this.pnlPostal.Controls.Add(this.txtAd3);
            this.pnlPostal.Controls.Add(this.txtAd2);
            this.pnlPostal.Controls.Add(this.txtAd1);
            this.pnlPostal.Location = new System.Drawing.Point(107, 136);
            this.pnlPostal.Name = "pnlPostal";
            this.pnlPostal.Size = new System.Drawing.Size(189, 91);
            this.pnlPostal.TabIndex = 5;
            this.pnlPostal.TabStop = true;
            // 
            // txtAd5
            // 
            this.txtAd5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAd5.Location = new System.Drawing.Point(2, 66);
            this.txtAd5.MaxLength = 30;
            this.txtAd5.Name = "txtAd5";
            this.txtAd5.Size = new System.Drawing.Size(161, 13);
            this.txtAd5.TabIndex = 8;
            this.txtAd5.TextChanged += new System.EventHandler(this.txtAd1_TextChanged);
            this.txtAd5.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextControl);
            // 
            // txtAd4
            // 
            this.txtAd4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAd4.Location = new System.Drawing.Point(2, 50);
            this.txtAd4.MaxLength = 30;
            this.txtAd4.Name = "txtAd4";
            this.txtAd4.Size = new System.Drawing.Size(161, 13);
            this.txtAd4.TabIndex = 7;
            this.txtAd4.TextChanged += new System.EventHandler(this.txtAd1_TextChanged);
            this.txtAd4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextControl);
            // 
            // txtAd3
            // 
            this.txtAd3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAd3.Location = new System.Drawing.Point(2, 34);
            this.txtAd3.MaxLength = 30;
            this.txtAd3.Name = "txtAd3";
            this.txtAd3.Size = new System.Drawing.Size(161, 13);
            this.txtAd3.TabIndex = 6;
            this.txtAd3.TextChanged += new System.EventHandler(this.txtAd1_TextChanged);
            this.txtAd3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextControl);
            // 
            // txtAd2
            // 
            this.txtAd2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAd2.Location = new System.Drawing.Point(2, 18);
            this.txtAd2.MaxLength = 30;
            this.txtAd2.Name = "txtAd2";
            this.txtAd2.Size = new System.Drawing.Size(161, 13);
            this.txtAd2.TabIndex = 5;
            this.txtAd2.TextChanged += new System.EventHandler(this.txtAd1_TextChanged);
            this.txtAd2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextControl);
            // 
            // txtAd1
            // 
            this.txtAd1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAd1.Location = new System.Drawing.Point(2, 2);
            this.txtAd1.MaxLength = 30;
            this.txtAd1.Name = "txtAd1";
            this.txtAd1.Size = new System.Drawing.Size(161, 13);
            this.txtAd1.TabIndex = 4;
            this.txtAd1.TextChanged += new System.EventHandler(this.txtAd1_TextChanged);
            this.txtAd1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextControl);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 250);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Contact Person";
            // 
            // txtContact
            // 
            this.txtContact.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtContact.Location = new System.Drawing.Point(107, 248);
            this.txtContact.Name = "txtContact";
            this.txtContact.Size = new System.Drawing.Size(189, 20);
            this.txtContact.TabIndex = 7;
            this.txtContact.TextChanged += new System.EventHandler(this.txtAd1_TextChanged);
            this.txtContact.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextControl);
            // 
            // txtTelephone
            // 
            this.txtTelephone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTelephone.Location = new System.Drawing.Point(107, 273);
            this.txtTelephone.Name = "txtTelephone";
            this.txtTelephone.Size = new System.Drawing.Size(189, 20);
            this.txtTelephone.TabIndex = 9;
            this.txtTelephone.TextChanged += new System.EventHandler(this.txtAd1_TextChanged);
            this.txtTelephone.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextControl);
            // 
            // lblTelephone
            // 
            this.lblTelephone.AutoSize = true;
            this.lblTelephone.Location = new System.Drawing.Point(14, 275);
            this.lblTelephone.Name = "lblTelephone";
            this.lblTelephone.Size = new System.Drawing.Size(58, 13);
            this.lblTelephone.TabIndex = 8;
            this.lblTelephone.Text = "Telephone";
            // 
            // txtFax
            // 
            this.txtFax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFax.Location = new System.Drawing.Point(107, 299);
            this.txtFax.Name = "txtFax";
            this.txtFax.Size = new System.Drawing.Size(189, 20);
            this.txtFax.TabIndex = 11;
            this.txtFax.TextChanged += new System.EventHandler(this.txtAd1_TextChanged);
            this.txtFax.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextControl);
            // 
            // lblFax
            // 
            this.lblFax.AutoSize = true;
            this.lblFax.Location = new System.Drawing.Point(14, 300);
            this.lblFax.Name = "lblFax";
            this.lblFax.Size = new System.Drawing.Size(24, 13);
            this.lblFax.TabIndex = 10;
            this.lblFax.Text = "Fax";
            // 
            // txtMobile
            // 
            this.txtMobile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMobile.Location = new System.Drawing.Point(107, 324);
            this.txtMobile.Name = "txtMobile";
            this.txtMobile.Size = new System.Drawing.Size(189, 20);
            this.txtMobile.TabIndex = 13;
            this.txtMobile.TextChanged += new System.EventHandler(this.txtAd1_TextChanged);
            this.txtMobile.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextControl);
            // 
            // lblMobile
            // 
            this.lblMobile.AutoSize = true;
            this.lblMobile.Location = new System.Drawing.Point(14, 325);
            this.lblMobile.Name = "lblMobile";
            this.lblMobile.Size = new System.Drawing.Size(72, 13);
            this.lblMobile.TabIndex = 12;
            this.lblMobile.Text = "Mobile Phone";
            // 
            // txtEmail
            // 
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmail.Location = new System.Drawing.Point(107, 351);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(189, 20);
            this.txtEmail.TabIndex = 15;
            this.txtEmail.TextChanged += new System.EventHandler(this.txtAd1_TextChanged);
            this.txtEmail.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextControl);
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(14, 354);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(73, 13);
            this.lblEmail.TabIndex = 14;
            this.lblEmail.Text = "Email Address";
            // 
            // cmdDelete
            // 
            this.cmdDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdDelete.Enabled = false;
            this.cmdDelete.FlatAppearance.BorderSize = 0;
            this.cmdDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdDelete.Image = global::Liquid.Properties.Resources.delete;
            this.cmdDelete.Location = new System.Drawing.Point(41, 8);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(24, 24);
            this.cmdDelete.TabIndex = 156;
            this.cmdDelete.UseVisualStyleBackColor = true;
            // 
            // cmdNew
            // 
            this.cmdNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdNew.FlatAppearance.BorderSize = 0;
            this.cmdNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdNew.Image = global::Liquid.Properties.Resources.add1;
            this.cmdNew.Location = new System.Drawing.Point(12, 8);
            this.cmdNew.Name = "cmdNew";
            this.cmdNew.Size = new System.Drawing.Size(24, 24);
            this.cmdNew.TabIndex = 155;
            this.cmdNew.UseVisualStyleBackColor = true;
            this.cmdNew.Click += new System.EventHandler(this.cmdNew_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdCancel.FlatAppearance.BorderSize = 0;
            this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdCancel.Image = ((System.Drawing.Image)(resources.GetObject("cmdCancel.Image")));
            this.cmdCancel.Location = new System.Drawing.Point(112, 8);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(24, 24);
            this.cmdCancel.TabIndex = 154;
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdSave
            // 
            this.cmdSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdSave.Enabled = false;
            this.cmdSave.FlatAppearance.BorderSize = 0;
            this.cmdSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdSave.Image = ((System.Drawing.Image)(resources.GetObject("cmdSave.Image")));
            this.cmdSave.Location = new System.Drawing.Point(80, 8);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(24, 24);
            this.cmdSave.TabIndex = 153;
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            this.cmdSave.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextControl);
            // 
            // txtAddNumber
            // 
            this.txtAddNumber.Location = new System.Drawing.Point(107, 76);
            this.txtAddNumber.Name = "txtAddNumber";
            this.txtAddNumber.Size = new System.Drawing.Size(100, 20);
            this.txtAddNumber.TabIndex = 157;
            this.txtAddNumber.Visible = false;
            this.txtAddNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextControl);
            // 
            // selAddresses
            // 
            this.selAddresses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selAddresses.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selAddresses.FormattingEnabled = true;
            this.selAddresses.Items.AddRange(new object[] {
            "* NEW *"});
            this.selAddresses.Location = new System.Drawing.Point(193, 9);
            this.selAddresses.Name = "selAddresses";
            this.selAddresses.Size = new System.Drawing.Size(191, 24);
            this.selAddresses.TabIndex = 158;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 383);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 159;
            this.label2.Text = "Marketer";
            // 
            // txtMarketer
            // 
            this.txtMarketer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMarketer.Location = new System.Drawing.Point(107, 379);
            this.txtMarketer.Name = "txtMarketer";
            this.txtMarketer.ReadOnly = true;
            this.txtMarketer.Size = new System.Drawing.Size(189, 20);
            this.txtMarketer.TabIndex = 160;
            // 
            // cmdMarketerSearch
            // 
            this.cmdMarketerSearch.BackColor = System.Drawing.Color.White;
            this.cmdMarketerSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdMarketerSearch.Image = ((System.Drawing.Image)(resources.GetObject("cmdMarketerSearch.Image")));
            this.cmdMarketerSearch.Location = new System.Drawing.Point(271, 378);
            this.cmdMarketerSearch.Name = "cmdMarketerSearch";
            this.cmdMarketerSearch.Size = new System.Drawing.Size(25, 23);
            this.cmdMarketerSearch.TabIndex = 176;
            this.cmdMarketerSearch.UseVisualStyleBackColor = false;
            this.cmdMarketerSearch.Click += new System.EventHandler(this.cmdMarketerSearch_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 434);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 177;
            this.label3.Text = "CommissionPercentage Floor";
            // 
            // txtCommissionFloor
            // 
            this.txtCommissionFloor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCommissionFloor.Location = new System.Drawing.Point(107, 431);
            this.txtCommissionFloor.Name = "txtCommissionFloor";
            this.txtCommissionFloor.Size = new System.Drawing.Size(189, 20);
            this.txtCommissionFloor.TabIndex = 178;
            this.txtCommissionFloor.TextChanged += new System.EventHandler(this.txtCommissionFloor_TextChanged);
            // 
            // txtCategory
            // 
            this.txtCategory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCategory.Location = new System.Drawing.Point(107, 405);
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.ReadOnly = true;
            this.txtCategory.Size = new System.Drawing.Size(189, 20);
            this.txtCategory.TabIndex = 180;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 408);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 179;
            this.label4.Text = "Category";
            // 
            // cmdCategorySearch
            // 
            this.cmdCategorySearch.BackColor = System.Drawing.Color.White;
            this.cmdCategorySearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdCategorySearch.Image = ((System.Drawing.Image)(resources.GetObject("cmdCategorySearch.Image")));
            this.cmdCategorySearch.Location = new System.Drawing.Point(271, 403);
            this.cmdCategorySearch.Name = "cmdCategorySearch";
            this.cmdCategorySearch.Size = new System.Drawing.Size(25, 23);
            this.cmdCategorySearch.TabIndex = 181;
            this.cmdCategorySearch.UseVisualStyleBackColor = false;
            this.cmdCategorySearch.Click += new System.EventHandler(this.cmdCategorySearch_Click);
            // 
            // ContactDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 467);
            this.Controls.Add(this.cmdCategorySearch);
            this.Controls.Add(this.txtCategory);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCommissionFloor);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmdMarketerSearch);
            this.Controls.Add(this.txtMarketer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.selAddresses);
            this.Controls.Add(this.txtAddNumber);
            this.Controls.Add(this.cmdDelete);
            this.Controls.Add(this.cmdNew);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtMobile);
            this.Controls.Add(this.lblMobile);
            this.Controls.Add(this.txtFax);
            this.Controls.Add(this.lblFax);
            this.Controls.Add(this.txtTelephone);
            this.Controls.Add(this.lblTelephone);
            this.Controls.Add(this.txtContact);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnlPostal);
            this.Controls.Add(this.lblAd1);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblCode);
            this.Controls.Add(this.pnlHeading);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ContactDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Contact Details";
            this.Load += new System.EventHandler(this.ContactDetails_Load);
            this.pnlHeading.ResumeLayout(false);
            this.pnlPostal.ResumeLayout(false);
            this.pnlPostal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Panel pnlHeading;
		private System.Windows.Forms.Label lblHeading;
		private System.Windows.Forms.Label lblCode;
		private System.Windows.Forms.TextBox txtDescription;
		private System.Windows.Forms.Label lblAd1;
		private System.Windows.Forms.Panel pnlPostal;
		private System.Windows.Forms.TextBox txtAd5;
		private System.Windows.Forms.TextBox txtAd4;
		private System.Windows.Forms.TextBox txtAd3;
		private System.Windows.Forms.TextBox txtAd2;
		private System.Windows.Forms.TextBox txtAd1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtContact;
		private System.Windows.Forms.TextBox txtTelephone;
		private System.Windows.Forms.Label lblTelephone;
		private System.Windows.Forms.TextBox txtFax;
		private System.Windows.Forms.Label lblFax;
		private System.Windows.Forms.TextBox txtMobile;
		private System.Windows.Forms.Label lblMobile;
		private System.Windows.Forms.TextBox txtEmail;
		private System.Windows.Forms.Label lblEmail;
		private System.Windows.Forms.Button cmdCancel;
		private System.Windows.Forms.Button cmdSave;
		private System.Windows.Forms.Button cmdDelete;
		private System.Windows.Forms.Button cmdNew;
		private System.Windows.Forms.TextBox txtAddNumber;
		private System.Windows.Forms.ComboBox selAddresses;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMarketer;
        private System.Windows.Forms.Button cmdMarketerSearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCommissionFloor;
        private System.Windows.Forms.TextBox txtCategory;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button cmdCategorySearch;
	}
}