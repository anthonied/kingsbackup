namespace Liquid.Forms
{
    partial class CustomerNotes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerNotes));
            this.txtNote = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdSaveNote = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmdDeleteNote = new System.Windows.Forms.Button();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtAcountCode = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(12, 39);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(227, 130);
            this.txtNote.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Enter Note Details:";
            // 
            // cmdSaveNote
            // 
            this.cmdSaveNote.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdSaveNote.FlatAppearance.BorderSize = 0;
            this.cmdSaveNote.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdSaveNote.Image = ((System.Drawing.Image)(resources.GetObject("cmdSaveNote.Image")));
            this.cmdSaveNote.Location = new System.Drawing.Point(12, 20);
            this.cmdSaveNote.Name = "cmdSaveNote";
            this.cmdSaveNote.Size = new System.Drawing.Size(24, 24);
            this.cmdSaveNote.TabIndex = 142;
            this.cmdSaveNote.UseVisualStyleBackColor = true;
            this.cmdSaveNote.Click += new System.EventHandler(this.cmdSaveNote_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtNote);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 62);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(260, 191);
            this.panel1.TabIndex = 143;
            // 
            // cmdDeleteNote
            // 
            this.cmdDeleteNote.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdDeleteNote.FlatAppearance.BorderSize = 0;
            this.cmdDeleteNote.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdDeleteNote.Image = ((System.Drawing.Image)(resources.GetObject("cmdDeleteNote.Image")));
            this.cmdDeleteNote.Location = new System.Drawing.Point(42, 20);
            this.cmdDeleteNote.Name = "cmdDeleteNote";
            this.cmdDeleteNote.Size = new System.Drawing.Size(24, 24);
            this.cmdDeleteNote.TabIndex = 152;
            this.cmdDeleteNote.UseVisualStyleBackColor = true;
            this.cmdDeleteNote.Click += new System.EventHandler(this.cmdDeleteNote_Click);
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(197, 12);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(30, 20);
            this.txtID.TabIndex = 153;
            this.txtID.Visible = false;
            // 
            // txtAcountCode
            // 
            this.txtAcountCode.Location = new System.Drawing.Point(197, 38);
            this.txtAcountCode.Name = "txtAcountCode";
            this.txtAcountCode.Size = new System.Drawing.Size(30, 20);
            this.txtAcountCode.TabIndex = 154;
            this.txtAcountCode.Visible = false;
            // 
            // CustomerNotes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(286, 267);
            this.Controls.Add(this.txtAcountCode);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.cmdDeleteNote);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cmdSaveNote);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CustomerNotes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Customer Notes";
            this.Load += new System.EventHandler(this.CustomerNotes_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdSaveNote;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button cmdDeleteNote;
        public System.Windows.Forms.TextBox txtID;
        public System.Windows.Forms.TextBox txtAcountCode;
        public System.Windows.Forms.TextBox txtNote;
    }
}