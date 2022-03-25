namespace Liquid.Forms
{
    partial class Users
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Users));
            this.cmdSearch = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdSave = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtTel = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtShortName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUserCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblUseType = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.selUserType = new System.Windows.Forms.ComboBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.chkLockOrder = new System.Windows.Forms.CheckBox();
            this.chkCloseOrder = new System.Windows.Forms.CheckBox();
            this.chkCancelReturn = new System.Windows.Forms.CheckBox();
            this.chkCreditInvoice = new System.Windows.Forms.CheckBox();
            this.chkReturnItems = new System.Windows.Forms.CheckBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdSearch
            // 
            this.cmdSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdSearch.FlatAppearance.BorderSize = 0;
            this.cmdSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdSearch.Image = ((System.Drawing.Image)(resources.GetObject("cmdSearch.Image")));
            this.cmdSearch.Location = new System.Drawing.Point(87, 12);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(24, 23);
            this.cmdSearch.TabIndex = 155;
            this.cmdSearch.UseVisualStyleBackColor = true;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdCancel.FlatAppearance.BorderSize = 0;
            this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdCancel.Image = ((System.Drawing.Image)(resources.GetObject("cmdCancel.Image")));
            this.cmdCancel.Location = new System.Drawing.Point(41, 12);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(24, 23);
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
            this.cmdSave.Location = new System.Drawing.Point(9, 12);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(24, 23);
            this.cmdSave.TabIndex = 153;
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(9, 41);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(317, 298);
            this.tabControl1.TabIndex = 157;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.txtTel);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.txtShortName);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.txtUserCode);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.txtDescription);
            this.tabPage1.Controls.Add(this.lblUseType);
            this.tabPage1.Controls.Add(this.lblPassword);
            this.tabPage1.Controls.Add(this.lblUserName);
            this.tabPage1.Controls.Add(this.selUserType);
            this.tabPage1.Controls.Add(this.txtPassword);
            this.tabPage1.Controls.Add(this.txtUserName);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(309, 272);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "User";
            // 
            // txtTel
            // 
            this.txtTel.Location = new System.Drawing.Point(160, 103);
            this.txtTel.Name = "txtTel";
            this.txtTel.Size = new System.Drawing.Size(121, 20);
            this.txtTel.TabIndex = 23;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Telephone Number";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Short Name (Max 2 Char)";
            // 
            // txtShortName
            // 
            this.txtShortName.Location = new System.Drawing.Point(160, 75);
            this.txtShortName.MaxLength = 2;
            this.txtShortName.Name = "txtShortName";
            this.txtShortName.Size = new System.Drawing.Size(121, 20);
            this.txtShortName.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "User Code";
            // 
            // txtUserCode
            // 
            this.txtUserCode.BackColor = System.Drawing.Color.Gainsboro;
            this.txtUserCode.Location = new System.Drawing.Point(160, 22);
            this.txtUserCode.MaxLength = 5;
            this.txtUserCode.Name = "txtUserCode";
            this.txtUserCode.ReadOnly = true;
            this.txtUserCode.Size = new System.Drawing.Size(121, 20);
            this.txtUserCode.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Name (Max 15 Chars)";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(160, 48);
            this.txtDescription.MaxLength = 15;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(121, 20);
            this.txtDescription.TabIndex = 11;
            this.txtDescription.TextChanged += new System.EventHandler(this.txtDescription_TextChanged);
            // 
            // lblUseType
            // 
            this.lblUseType.AutoSize = true;
            this.lblUseType.Location = new System.Drawing.Point(18, 198);
            this.lblUseType.Name = "lblUseType";
            this.lblUseType.Size = new System.Drawing.Size(56, 13);
            this.lblUseType.TabIndex = 17;
            this.lblUseType.Text = "User Type";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(18, 166);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(127, 13);
            this.lblPassword.TabIndex = 16;
            this.lblPassword.Text = "Password (Max 10 Chars)";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(18, 135);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(129, 13);
            this.lblUserName.TabIndex = 13;
            this.lblUserName.Text = "Username (Max 10 Chars)";
            // 
            // selUserType
            // 
            this.selUserType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selUserType.FormattingEnabled = true;
            this.selUserType.Location = new System.Drawing.Point(160, 195);
            this.selUserType.Name = "selUserType";
            this.selUserType.Size = new System.Drawing.Size(121, 21);
            this.selUserType.TabIndex = 15;
            this.selUserType.SelectedIndexChanged += new System.EventHandler(this.txtDescription_TextChanged);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(160, 163);
            this.txtPassword.MaxLength = 10;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(121, 20);
            this.txtPassword.TabIndex = 14;
            this.txtPassword.TextChanged += new System.EventHandler(this.txtDescription_TextChanged);
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(160, 132);
            this.txtUserName.MaxLength = 10;
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(121, 20);
            this.txtUserName.TabIndex = 12;
            this.txtUserName.TextChanged += new System.EventHandler(this.txtDescription_TextChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.chkReturnItems);
            this.tabPage2.Controls.Add(this.chkLockOrder);
            this.tabPage2.Controls.Add(this.chkCloseOrder);
            this.tabPage2.Controls.Add(this.chkCancelReturn);
            this.tabPage2.Controls.Add(this.chkCreditInvoice);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(309, 272);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Security";
            // 
            // chkLockOrder
            // 
            this.chkLockOrder.AutoSize = true;
            this.chkLockOrder.Location = new System.Drawing.Point(18, 85);
            this.chkLockOrder.Name = "chkLockOrder";
            this.chkLockOrder.Size = new System.Drawing.Size(146, 17);
            this.chkLockOrder.TabIndex = 3;
            this.chkLockOrder.Text = "User can lock sales order";
            this.chkLockOrder.UseVisualStyleBackColor = true;
            this.chkLockOrder.CheckedChanged += new System.EventHandler(this.txtDescription_TextChanged);
            // 
            // chkCloseOrder
            // 
            this.chkCloseOrder.AutoSize = true;
            this.chkCloseOrder.Location = new System.Drawing.Point(18, 62);
            this.chkCloseOrder.Name = "chkCloseOrder";
            this.chkCloseOrder.Size = new System.Drawing.Size(156, 17);
            this.chkCloseOrder.TabIndex = 2;
            this.chkCloseOrder.Text = "User can close sales orders";
            this.chkCloseOrder.UseVisualStyleBackColor = true;
            this.chkCloseOrder.CheckedChanged += new System.EventHandler(this.txtDescription_TextChanged);
            // 
            // chkCancelReturn
            // 
            this.chkCancelReturn.AutoSize = true;
            this.chkCancelReturn.Location = new System.Drawing.Point(18, 39);
            this.chkCancelReturn.Name = "chkCancelReturn";
            this.chkCancelReturn.Size = new System.Drawing.Size(260, 17);
            this.chkCancelReturn.TabIndex = 1;
            this.chkCancelReturn.Text = "User can cancel returned inventory in sales order.";
            this.chkCancelReturn.UseVisualStyleBackColor = true;
            this.chkCancelReturn.CheckedChanged += new System.EventHandler(this.txtDescription_TextChanged);
            // 
            // chkCreditInvoice
            // 
            this.chkCreditInvoice.AutoSize = true;
            this.chkCreditInvoice.Location = new System.Drawing.Point(18, 16);
            this.chkCreditInvoice.Name = "chkCreditInvoice";
            this.chkCreditInvoice.Size = new System.Drawing.Size(143, 17);
            this.chkCreditInvoice.TabIndex = 0;
            this.chkCreditInvoice.Text = "User can credit invoices.";
            this.chkCreditInvoice.UseVisualStyleBackColor = true;
            this.chkCreditInvoice.CheckedChanged += new System.EventHandler(this.txtDescription_TextChanged);
            // 
            // chkReturnItems
            // 
            this.chkReturnItems.AutoSize = true;
            this.chkReturnItems.Location = new System.Drawing.Point(18, 108);
            this.chkReturnItems.Name = "chkReturnItems";
            this.chkReturnItems.Size = new System.Drawing.Size(127, 17);
            this.chkReturnItems.TabIndex = 4;
            this.chkReturnItems.Text = "User can return Items";
            this.chkReturnItems.UseVisualStyleBackColor = true;
            this.chkReturnItems.CheckedChanged += new System.EventHandler(this.txtDescription_TextChanged);
            // 
            // Users
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 351);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.cmdSearch);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Users";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Users";
            this.Load += new System.EventHandler(this.Users_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdSearch;
        private System.Windows.Forms.Button cmdCancel;
		private System.Windows.Forms.Button cmdSave;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.CheckBox chkCreditInvoice;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtUserCode;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtDescription;
		private System.Windows.Forms.Label lblUseType;
		private System.Windows.Forms.Label lblPassword;
		private System.Windows.Forms.Label lblUserName;
		private System.Windows.Forms.ComboBox selUserType;
		private System.Windows.Forms.TextBox txtPassword;
		private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.CheckBox chkCancelReturn;
        private System.Windows.Forms.CheckBox chkCloseOrder;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtShortName;
        private System.Windows.Forms.TextBox txtTel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkLockOrder;
        private System.Windows.Forms.CheckBox chkReturnItems;
    }
}