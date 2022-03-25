namespace Liquid.Forms
{
    partial class Error
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
            this.lblMsg = new System.Windows.Forms.Label();
            this.cmdContinue = new System.Windows.Forms.Button();
            this.cmdClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(74, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(246, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Error has occured";
            // 
            // lblMsg
            // 
            this.lblMsg.Location = new System.Drawing.Point(77, 73);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(252, 54);
            this.lblMsg.TabIndex = 1;
            this.lblMsg.Text = "label2";
            this.lblMsg.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cmdContinue
            // 
            this.cmdContinue.Location = new System.Drawing.Point(113, 141);
            this.cmdContinue.Name = "cmdContinue";
            this.cmdContinue.Size = new System.Drawing.Size(75, 23);
            this.cmdContinue.TabIndex = 2;
            this.cmdContinue.Text = "Continue";
            this.cmdContinue.UseVisualStyleBackColor = true;
            this.cmdContinue.Click += new System.EventHandler(this.cmdContinue_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Location = new System.Drawing.Point(213, 141);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(75, 23);
            this.cmdClose.TabIndex = 3;
            this.cmdClose.Text = "Abort";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // Error
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.IndianRed;
            this.ClientSize = new System.Drawing.Size(406, 202);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdContinue);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Error";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Error";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.Button cmdContinue;
        private System.Windows.Forms.Button cmdClose;
    }
}