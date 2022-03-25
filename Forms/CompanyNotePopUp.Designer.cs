namespace Liquid.Forms
{
    partial class CompanyNotePopUp
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblCompanyNote = new System.Windows.Forms.Label();
            this.cmdContinue = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdSearch = new System.Windows.Forms.Button();
            this.lblCompanyName = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblCompanyNote);
            this.panel1.Location = new System.Drawing.Point(16, 53);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(278, 178);
            this.panel1.TabIndex = 1;
            // 
            // lblCompanyNote
            // 
            this.lblCompanyNote.AutoSize = true;
            this.lblCompanyNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompanyNote.Location = new System.Drawing.Point(3, 7);
            this.lblCompanyNote.Name = "lblCompanyNote";
            this.lblCompanyNote.Size = new System.Drawing.Size(52, 15);
            this.lblCompanyNote.TabIndex = 0;
            this.lblCompanyNote.Text = "No Note";
            // 
            // cmdContinue
            // 
            this.cmdContinue.Location = new System.Drawing.Point(161, 242);
            this.cmdContinue.Name = "cmdContinue";
            this.cmdContinue.Size = new System.Drawing.Size(58, 23);
            this.cmdContinue.TabIndex = 2;
            this.cmdContinue.Text = "Continue";
            this.cmdContinue.UseVisualStyleBackColor = true;
            this.cmdContinue.Click += new System.EventHandler(this.cmdContinue_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(236, 242);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(58, 23);
            this.cmdCancel.TabIndex = 1;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdSearch
            // 
            this.cmdSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdSearch.FlatAppearance.BorderSize = 0;
            this.cmdSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdSearch.Image = global::Liquid.Properties.Resources.info_321;
            this.cmdSearch.Location = new System.Drawing.Point(12, 3);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(35, 44);
            this.cmdSearch.TabIndex = 153;
            this.cmdSearch.UseVisualStyleBackColor = true;
            // 
            // lblCompanyName
            // 
            this.lblCompanyName.AutoSize = true;
            this.lblCompanyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompanyName.Location = new System.Drawing.Point(56, 18);
            this.lblCompanyName.Name = "lblCompanyName";
            this.lblCompanyName.Size = new System.Drawing.Size(45, 16);
            this.lblCompanyName.TabIndex = 1;
            this.lblCompanyName.Text = "label2";
            // 
            // CompanyNotePopUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(314, 272);
            this.Controls.Add(this.lblCompanyName);
            this.Controls.Add(this.cmdSearch);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdContinue);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "CompanyNotePopUp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Company Note";
            this.Load += new System.EventHandler(this.CompanyNote_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label lblCompanyNote;
        public System.Windows.Forms.Button cmdContinue;
        public System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdSearch;
        public System.Windows.Forms.Label lblCompanyName;
    }
}