namespace Liquid
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.picLogin = new System.Windows.Forms.PictureBox();
            this.picClear = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkUseBackground = new System.Windows.Forms.CheckBox();
            this.lblBuildVersion = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picLogin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picClear)).BeginInit();
            this.SuspendLayout();
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.BackColor = System.Drawing.Color.Transparent;
            this.lblUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.Location = new System.Drawing.Point(10, 28);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(86, 16);
            this.lblUserName.TabIndex = 799;
            this.lblUserName.Text = "User Name";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.BackColor = System.Drawing.Color.Transparent;
            this.lblPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.Location = new System.Drawing.Point(10, 59);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(76, 16);
            this.lblPassword.TabIndex = 800;
            this.lblPassword.Text = "Password";
            // 
            // txtUserName
            // 
            this.txtUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserName.Location = new System.Drawing.Point(102, 26);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(143, 21);
            this.txtUserName.TabIndex = 0;
            this.txtUserName.Leave += new System.EventHandler(this.txtUserName_Leave);
            // 
            // txtPassword
            // 
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(102, 54);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(143, 21);
            this.txtPassword.TabIndex = 1;
            // 
            // picLogin
            // 
            this.picLogin.BackColor = System.Drawing.Color.Transparent;
            this.picLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.picLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picLogin.Image = global::Liquid.Properties.Resources.login_button1;
            this.picLogin.Location = new System.Drawing.Point(102, 81);
            this.picLogin.Name = "picLogin";
            this.picLogin.Size = new System.Drawing.Size(72, 28);
            this.picLogin.TabIndex = 801;
            this.picLogin.TabStop = false;
            this.picLogin.Click += new System.EventHandler(this.cmdlogin_Click);
            // 
            // picClear
            // 
            this.picClear.BackColor = System.Drawing.Color.Transparent;
            this.picClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.picClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picClear.Image = global::Liquid.Properties.Resources.clear_button11;
            this.picClear.Location = new System.Drawing.Point(173, 81);
            this.picClear.Name = "picClear";
            this.picClear.Size = new System.Drawing.Size(72, 28);
            this.picClear.TabIndex = 802;
            this.picClear.TabStop = false;
            this.picClear.Click += new System.EventHandler(this.cmdClear_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Location = new System.Drawing.Point(7, 155);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 9);
            this.label1.TabIndex = 803;
            this.label1.Text = "Use Background";
            // 
            // chkUseBackground
            // 
            this.chkUseBackground.AutoSize = true;
            this.chkUseBackground.BackColor = System.Drawing.Color.Transparent;
            this.chkUseBackground.Checked = true;
            this.chkUseBackground.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUseBackground.Location = new System.Drawing.Point(84, 152);
            this.chkUseBackground.Name = "chkUseBackground";
            this.chkUseBackground.Size = new System.Drawing.Size(15, 14);
            this.chkUseBackground.TabIndex = 804;
            this.chkUseBackground.UseVisualStyleBackColor = false;
            // 
            // lblBuildVersion
            // 
            this.lblBuildVersion.AutoSize = true;
            this.lblBuildVersion.BackColor = System.Drawing.Color.Transparent;
            this.lblBuildVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuildVersion.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblBuildVersion.Location = new System.Drawing.Point(105, 155);
            this.lblBuildVersion.Name = "lblBuildVersion";
            this.lblBuildVersion.Size = new System.Drawing.Size(27, 9);
            this.lblBuildVersion.TabIndex = 805;
            this.lblBuildVersion.Text = "Build";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Liquid.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(355, 175);
            this.Controls.Add(this.lblBuildVersion);
            this.Controls.Add(this.chkUseBackground);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picClear);
            this.Controls.Add(this.picLogin);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUserName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picLogin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picClear)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUserName;
		private System.Windows.Forms.Label lblPassword;
		public System.Windows.Forms.TextBox txtUserName;
		public System.Windows.Forms.TextBox txtPassword;
		private System.Windows.Forms.PictureBox picLogin;
		private System.Windows.Forms.PictureBox picClear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkUseBackground;
        private System.Windows.Forms.Label lblBuildVersion;
    }
}