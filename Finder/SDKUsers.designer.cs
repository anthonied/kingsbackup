namespace Liquid.Finder
{
    partial class SDKUsers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SDKUsers));
            this.cmdFilter = new System.Windows.Forms.Button();
            this.gpFilters = new System.Windows.Forms.GroupBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.lblStoreCode = new System.Windows.Forms.Label();
            this.dgvSDKUsers = new System.Windows.Forms.DataGridView();
            this.clUserCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gpFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSDKUsers)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdFilter
            // 
            this.cmdFilter.BackColor = System.Drawing.Color.White;
            this.cmdFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdFilter.Image = ((System.Drawing.Image)(resources.GetObject("cmdFilter.Image")));
            this.cmdFilter.Location = new System.Drawing.Point(516, 22);
            this.cmdFilter.Name = "cmdFilter";
            this.cmdFilter.Size = new System.Drawing.Size(25, 23);
            this.cmdFilter.TabIndex = 44;
            this.cmdFilter.UseVisualStyleBackColor = false;
            this.cmdFilter.Click += new System.EventHandler(this.cmdFilter_Click);
            // 
            // gpFilters
            // 
            this.gpFilters.Controls.Add(this.txtEmail);
            this.gpFilters.Controls.Add(this.label2);
            this.gpFilters.Controls.Add(this.txtDesc);
            this.gpFilters.Controls.Add(this.label1);
            this.gpFilters.Controls.Add(this.txtCode);
            this.gpFilters.Controls.Add(this.cmdFilter);
            this.gpFilters.Controls.Add(this.lblStoreCode);
            this.gpFilters.Location = new System.Drawing.Point(12, 12);
            this.gpFilters.Name = "gpFilters";
            this.gpFilters.Size = new System.Drawing.Size(554, 60);
            this.gpFilters.TabIndex = 8;
            this.gpFilters.TabStop = false;
            this.gpFilters.Text = "Filter Results By";
            // 
            // txtEmail
            // 
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmail.Location = new System.Drawing.Point(410, 23);
            this.txtEmail.MaxLength = 6;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(100, 20);
            this.txtEmail.TabIndex = 48;
            this.txtEmail.TextChanged += new System.EventHandler(this.txtCode_TextChanged);
            this.txtEmail.Enter += new System.EventHandler(this.txtCode_Enter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(372, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 47;
            this.label2.Text = "Email";
            // 
            // txtDesc
            // 
            this.txtDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDesc.Location = new System.Drawing.Point(251, 23);
            this.txtDesc.MaxLength = 6;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(100, 20);
            this.txtDesc.TabIndex = 46;
            this.txtDesc.TextChanged += new System.EventHandler(this.txtCode_TextChanged);
            this.txtDesc.Enter += new System.EventHandler(this.txtCode_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(188, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 45;
            this.label1.Text = "Description";
            // 
            // txtCode
            // 
            this.txtCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCode.Location = new System.Drawing.Point(69, 23);
            this.txtCode.MaxLength = 6;
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(100, 20);
            this.txtCode.TabIndex = 1;
            this.txtCode.TextChanged += new System.EventHandler(this.txtCode_TextChanged);
            this.txtCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCode_KeyDown);
            this.txtCode.Enter += new System.EventHandler(this.txtCode_Enter);
            // 
            // lblStoreCode
            // 
            this.lblStoreCode.AutoSize = true;
            this.lblStoreCode.Location = new System.Drawing.Point(6, 26);
            this.lblStoreCode.Name = "lblStoreCode";
            this.lblStoreCode.Size = new System.Drawing.Size(57, 13);
            this.lblStoreCode.TabIndex = 0;
            this.lblStoreCode.Text = "User Code";
            // 
            // dgvSDKUsers
            // 
            this.dgvSDKUsers.AllowUserToAddRows = false;
            this.dgvSDKUsers.AllowUserToDeleteRows = false;
            this.dgvSDKUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSDKUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clUserCode,
            this.clDescription,
            this.clEmail});
            this.dgvSDKUsers.Location = new System.Drawing.Point(12, 78);
            this.dgvSDKUsers.Name = "dgvSDKUsers";
            this.dgvSDKUsers.ReadOnly = true;
            this.dgvSDKUsers.RowHeadersVisible = false;
            this.dgvSDKUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSDKUsers.Size = new System.Drawing.Size(554, 284);
            this.dgvSDKUsers.TabIndex = 9;
            this.dgvSDKUsers.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSDKUsers_CellDoubleClick);
            this.dgvSDKUsers.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvSDKUsers_KeyDown);
            this.dgvSDKUsers.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgvSDKUsers_KeyPress);
            // 
            // clUserCode
            // 
            this.clUserCode.DataPropertyName = "ID";
            this.clUserCode.HeaderText = "User Code";
            this.clUserCode.Name = "clUserCode";
            this.clUserCode.ReadOnly = true;
            // 
            // clDescription
            // 
            this.clDescription.DataPropertyName = "Description";
            this.clDescription.HeaderText = "Description";
            this.clDescription.Name = "clDescription";
            this.clDescription.ReadOnly = true;
            this.clDescription.Width = 200;
            // 
            // clEmail
            // 
            this.clEmail.DataPropertyName = "EmailAddress";
            this.clEmail.HeaderText = "Email";
            this.clEmail.Name = "clEmail";
            this.clEmail.ReadOnly = true;
            this.clEmail.Width = 200;
            // 
            // SDKUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 374);
            this.Controls.Add(this.dgvSDKUsers);
            this.Controls.Add(this.gpFilters);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SDKUsers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SDKUsers";
            this.Load += new System.EventHandler(this.SDKUsers_Load);
            this.gpFilters.ResumeLayout(false);
            this.gpFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSDKUsers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdFilter;
        private System.Windows.Forms.GroupBox gpFilters;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label lblStoreCode;
        private System.Windows.Forms.DataGridView dgvSDKUsers;
        private System.Windows.Forms.DataGridViewTextBoxColumn clUserCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn clEmail;
    }
}