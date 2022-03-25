namespace Liquid.Documents
{
    partial class SalesOrderAuthorization
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblClientName = new System.Windows.Forms.Label();
            this.lblClientCode = new System.Windows.Forms.Label();
            this.lblAuthorizedBy = new System.Windows.Forms.Label();
            this.cmdAuthorize = new System.Windows.Forms.Button();
            this.cmdDecline = new System.Windows.Forms.Button();
            this.cbbAuthorizedPerson = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Client:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Code:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(10, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Processed By:";
            // 
            // lblClientName
            // 
            this.lblClientName.AutoSize = true;
            this.lblClientName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClientName.Location = new System.Drawing.Point(71, 16);
            this.lblClientName.Name = "lblClientName";
            this.lblClientName.Size = new System.Drawing.Size(86, 15);
            this.lblClientName.TabIndex = 5;
            this.lblClientName.Text = "Client Name";
            // 
            // lblClientCode
            // 
            this.lblClientCode.AutoSize = true;
            this.lblClientCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClientCode.Location = new System.Drawing.Point(71, 34);
            this.lblClientCode.Name = "lblClientCode";
            this.lblClientCode.Size = new System.Drawing.Size(81, 15);
            this.lblClientCode.TabIndex = 6;
            this.lblClientCode.Text = "Client Code";
            // 
            // lblAuthorizedBy
            // 
            this.lblAuthorizedBy.AutoSize = true;
            this.lblAuthorizedBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAuthorizedBy.ForeColor = System.Drawing.Color.Gray;
            this.lblAuthorizedBy.Location = new System.Drawing.Point(83, 154);
            this.lblAuthorizedBy.Name = "lblAuthorizedBy";
            this.lblAuthorizedBy.Size = new System.Drawing.Size(86, 13);
            this.lblAuthorizedBy.TabIndex = 7;
            this.lblAuthorizedBy.Text = "Kingshire Person";
            // 
            // cmdAuthorize
            // 
            this.cmdAuthorize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.cmdAuthorize.Location = new System.Drawing.Point(183, 149);
            this.cmdAuthorize.Name = "cmdAuthorize";
            this.cmdAuthorize.Size = new System.Drawing.Size(75, 23);
            this.cmdAuthorize.TabIndex = 8;
            this.cmdAuthorize.Text = "Authorize";
            this.cmdAuthorize.UseVisualStyleBackColor = false;
            this.cmdAuthorize.Click += new System.EventHandler(this.cmdAuthorize_Click);
            // 
            // cmdDecline
            // 
            this.cmdDecline.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.cmdDecline.Location = new System.Drawing.Point(261, 149);
            this.cmdDecline.Name = "cmdDecline";
            this.cmdDecline.Size = new System.Drawing.Size(75, 23);
            this.cmdDecline.TabIndex = 9;
            this.cmdDecline.Text = "Decline";
            this.cmdDecline.UseVisualStyleBackColor = false;
            this.cmdDecline.Click += new System.EventHandler(this.cmdDecline_Click);
            // 
            // cbbAuthorizedPerson
            // 
            this.cbbAuthorizedPerson.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbAuthorizedPerson.FormattingEnabled = true;
            this.cbbAuthorizedPerson.Location = new System.Drawing.Point(75, 23);
            this.cbbAuthorizedPerson.Name = "cbbAuthorizedPerson";
            this.cbbAuthorizedPerson.Size = new System.Drawing.Size(245, 23);
            this.cbbAuthorizedPerson.TabIndex = 10;
            this.cbbAuthorizedPerson.SelectedIndexChanged += new System.EventHandler(this.cbbAuthorizedPerson_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblClientName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lblClientCode);
            this.groupBox1.Location = new System.Drawing.Point(12, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(324, 62);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Customer Details";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cbbAuthorizedPerson);
            this.groupBox2.Location = new System.Drawing.Point(12, 77);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(324, 59);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Please select the authorized person that cleared the order";
            // 
            // SalesOrderAuthorization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(350, 181);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmdDecline);
            this.Controls.Add(this.cmdAuthorize);
            this.Controls.Add(this.lblAuthorizedBy);
            this.Controls.Add(this.label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SalesOrderAuthorization";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Authorization";
            this.Load += new System.EventHandler(this.SalesOrderAuthorization_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblClientName;
        private System.Windows.Forms.Label lblClientCode;
        private System.Windows.Forms.Label lblAuthorizedBy;
        private System.Windows.Forms.Button cmdAuthorize;
        private System.Windows.Forms.Button cmdDecline;
        private System.Windows.Forms.ComboBox cbbAuthorizedPerson;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}