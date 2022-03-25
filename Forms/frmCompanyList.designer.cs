namespace Liquid.Forms
{
    partial class frmCompanyList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCompanyList));
            this.lblUserName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgCompanyList = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CompanyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ApplicationPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PastelConn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SOLPMSConn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnLoadCompany = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgCompanyList)).BeginInit();
            this.SuspendLayout();
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.BackColor = System.Drawing.Color.Transparent;
            this.lblUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.Location = new System.Drawing.Point(12, 10);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(127, 16);
            this.lblUserName.TabIndex = 800;
            this.lblUserName.Text = "COMPANY DATA";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(357, 15);
            this.label1.TabIndex = 801;
            this.label1.Text = "Select a company from the list below. You will be granted access";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(25, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(227, 15);
            this.label2.TabIndex = 802;
            this.label2.Text = "to this data based on your security profile";
            // 
            // dgCompanyList
            // 
            this.dgCompanyList.AllowUserToAddRows = false;
            this.dgCompanyList.AllowUserToDeleteRows = false;
            this.dgCompanyList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCompanyList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.CompanyName,
            this.DataPath,
            this.ApplicationPath,
            this.PastelConn,
            this.SOLPMSConn});
            this.dgCompanyList.Location = new System.Drawing.Point(15, 78);
            this.dgCompanyList.Name = "dgCompanyList";
            this.dgCompanyList.ReadOnly = true;
            this.dgCompanyList.RowHeadersVisible = false;
            this.dgCompanyList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgCompanyList.Size = new System.Drawing.Size(367, 150);
            this.dgCompanyList.TabIndex = 803;
            this.dgCompanyList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgCompanyList_KeyDown);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "id";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // CompanyName
            // 
            this.CompanyName.DataPropertyName = "name";
            this.CompanyName.HeaderText = "Company Name";
            this.CompanyName.Name = "CompanyName";
            this.CompanyName.ReadOnly = true;
            this.CompanyName.Width = 175;
            // 
            // DataPath
            // 
            this.DataPath.DataPropertyName = "datapath";
            this.DataPath.HeaderText = "Data Path";
            this.DataPath.Name = "DataPath";
            this.DataPath.ReadOnly = true;
            this.DataPath.Width = 188;
            // 
            // ApplicationPath
            // 
            this.ApplicationPath.DataPropertyName = "applicationpath";
            this.ApplicationPath.HeaderText = "Application Path";
            this.ApplicationPath.Name = "ApplicationPath";
            this.ApplicationPath.ReadOnly = true;
            this.ApplicationPath.Visible = false;
            // 
            // PastelConn
            // 
            this.PastelConn.DataPropertyName = "pastelconn";
            this.PastelConn.HeaderText = "Pastel Conn";
            this.PastelConn.Name = "PastelConn";
            this.PastelConn.ReadOnly = true;
            this.PastelConn.Visible = false;
            // 
            // SOLPMSConn
            // 
            this.SOLPMSConn.DataPropertyName = "solpmsconn";
            this.SOLPMSConn.HeaderText = "SOLPM Conn";
            this.SOLPMSConn.Name = "SOLPMSConn";
            this.SOLPMSConn.ReadOnly = true;
            this.SOLPMSConn.Visible = false;
            // 
            // btnLoadCompany
            // 
            this.btnLoadCompany.BackColor = System.Drawing.Color.Transparent;
            this.btnLoadCompany.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLoadCompany.BackgroundImage")));
            this.btnLoadCompany.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnLoadCompany.FlatAppearance.BorderSize = 0;
            this.btnLoadCompany.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadCompany.ForeColor = System.Drawing.Color.White;
            this.btnLoadCompany.Location = new System.Drawing.Point(120, 234);
            this.btnLoadCompany.Name = "btnLoadCompany";
            this.btnLoadCompany.Size = new System.Drawing.Size(75, 38);
            this.btnLoadCompany.TabIndex = 804;
            this.btnLoadCompany.Text = "OK";
            this.btnLoadCompany.UseVisualStyleBackColor = false;
            this.btnLoadCompany.Click += new System.EventHandler(this.btnLoadCompany_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExit.BackgroundImage")));
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(201, 234);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 38);
            this.btnExit.TabIndex = 805;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // frmCompanyList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Liquid.Properties.Resources._09;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(402, 296);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnLoadCompany);
            this.Controls.Add(this.dgCompanyList);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblUserName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmCompanyList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Company List";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmCompanyList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgCompanyList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgCompanyList;
        private System.Windows.Forms.Button btnLoadCompany;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompanyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataPath;
        private System.Windows.Forms.DataGridViewTextBoxColumn ApplicationPath;
        private System.Windows.Forms.DataGridViewTextBoxColumn PastelConn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SOLPMSConn;
    }
}