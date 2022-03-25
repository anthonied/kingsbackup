namespace Liquid.Forms
{
	partial class VerifyUser
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
			this.lblUserName = new System.Windows.Forms.Label();
			this.lblPassword = new System.Windows.Forms.Label();
			this.txtUserName = new System.Windows.Forms.TextBox();
			this.txtPassword = new System.Windows.Forms.TextBox();
			this.cmdlogin = new System.Windows.Forms.Button();
			this.cmdClear = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.SuspendLayout();
			// 
			// lblUserName
			// 
			this.lblUserName.AutoSize = true;
			this.lblUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblUserName.Location = new System.Drawing.Point(38, 50);
			this.lblUserName.Name = "lblUserName";
			this.lblUserName.Size = new System.Drawing.Size(70, 15);
			this.lblUserName.TabIndex = 799;
			this.lblUserName.Text = "User Name";
			// 
			// lblPassword
			// 
			this.lblPassword.AutoSize = true;
			this.lblPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblPassword.Location = new System.Drawing.Point(38, 81);
			this.lblPassword.Name = "lblPassword";
			this.lblPassword.Size = new System.Drawing.Size(61, 15);
			this.lblPassword.TabIndex = 800;
			this.lblPassword.Text = "Password";
			// 
			// txtUserName
			// 
			this.txtUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtUserName.Location = new System.Drawing.Point(119, 47);
			this.txtUserName.Name = "txtUserName";
			this.txtUserName.Size = new System.Drawing.Size(126, 21);
			this.txtUserName.TabIndex = 0;
			this.txtUserName.Leave += new System.EventHandler(this.txtUserName_Leave);
			// 
			// txtPassword
			// 
			this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtPassword.Location = new System.Drawing.Point(119, 78);
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.PasswordChar = '*';
			this.txtPassword.Size = new System.Drawing.Size(126, 21);
			this.txtPassword.TabIndex = 1;
			// 
			// cmdlogin
			// 
			this.cmdlogin.Location = new System.Drawing.Point(119, 124);
			this.cmdlogin.Name = "cmdlogin";
			this.cmdlogin.Size = new System.Drawing.Size(57, 23);
			this.cmdlogin.TabIndex = 2;
			this.cmdlogin.Text = "Login";
			this.cmdlogin.UseVisualStyleBackColor = true;
			this.cmdlogin.Click += new System.EventHandler(this.cmdlogin_Click);
			// 
			// cmdClear
			// 
			this.cmdClear.Location = new System.Drawing.Point(186, 124);
			this.cmdClear.Name = "cmdClear";
			this.cmdClear.Size = new System.Drawing.Size(59, 23);
			this.cmdClear.TabIndex = 3;
			this.cmdClear.Text = "Clear";
			this.cmdClear.UseVisualStyleBackColor = true;
			this.cmdClear.Click += new System.EventHandler(this.cmdClear_Click);
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Location = new System.Drawing.Point(13, 13);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(259, 163);
			this.panel1.TabIndex = 801;
			// 
			// Login
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 188);
			this.Controls.Add(this.cmdClear);
			this.Controls.Add(this.cmdlogin);
			this.Controls.Add(this.txtPassword);
			this.Controls.Add(this.txtUserName);
			this.Controls.Add(this.lblPassword);
			this.Controls.Add(this.lblUserName);
			this.Controls.Add(this.panel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "Login";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Confirm Credentials";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUserName;
		private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Button cmdlogin;
        private System.Windows.Forms.Button cmdClear;
        private System.Windows.Forms.Panel panel1;
		public System.Windows.Forms.TextBox txtUserName;
		public System.Windows.Forms.TextBox txtPassword;
    }
}