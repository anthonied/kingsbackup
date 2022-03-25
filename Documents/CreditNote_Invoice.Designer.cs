namespace Liquid.Documents
{
	partial class CreditNote_Invoice
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
			this.dgCreditNotes = new System.Windows.Forms.DataGridView();
			this.clNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clCreditNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.lblHeading = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dgCreditNotes)).BeginInit();
			this.SuspendLayout();
			// 
			// dgCreditNotes
			// 
			this.dgCreditNotes.AllowUserToAddRows = false;
			this.dgCreditNotes.AllowUserToDeleteRows = false;
			this.dgCreditNotes.AllowUserToResizeRows = false;
			this.dgCreditNotes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgCreditNotes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clNumber,
            this.clCreditNumber,
            this.clDate});
			this.dgCreditNotes.Location = new System.Drawing.Point(12, 69);
			this.dgCreditNotes.Name = "dgCreditNotes";
			this.dgCreditNotes.ReadOnly = true;
			this.dgCreditNotes.RowHeadersVisible = false;
			this.dgCreditNotes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgCreditNotes.Size = new System.Drawing.Size(415, 275);
			this.dgCreditNotes.TabIndex = 0;
			this.dgCreditNotes.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgCreditNotes_CellDoubleClick);
			// 
			// clNumber
			// 
			this.clNumber.HeaderText = "#";
			this.clNumber.Name = "clNumber";
			this.clNumber.ReadOnly = true;
			this.clNumber.Width = 25;
			// 
			// clCreditNumber
			// 
			this.clCreditNumber.HeaderText = "Credit Note";
			this.clCreditNumber.Name = "clCreditNumber";
			this.clCreditNumber.ReadOnly = true;
			this.clCreditNumber.Width = 150;
			// 
			// clDate
			// 
			this.clDate.HeaderText = "Date Created";
			this.clDate.Name = "clDate";
			this.clDate.ReadOnly = true;
			this.clDate.Width = 150;
			// 
			// lblHeading
			// 
			this.lblHeading.BackColor = System.Drawing.Color.Gainsboro;
			this.lblHeading.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblHeading.Location = new System.Drawing.Point(12, 20);
			this.lblHeading.Name = "lblHeading";
			this.lblHeading.Size = new System.Drawing.Size(415, 23);
			this.lblHeading.TabIndex = 1;
			this.lblHeading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Gainsboro;
			this.label1.Location = new System.Drawing.Point(87, 25);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(260, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Double click on the credit note to view the document.";
			// 
			// CreditNote_Invoice
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(439, 356);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.lblHeading);
			this.Controls.Add(this.dgCreditNotes);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "CreditNote_Invoice";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Credit Note For Invoice - ";
			this.Load += new System.EventHandler(this.CreditNote_Invoice_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgCreditNotes)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView dgCreditNotes;
		private System.Windows.Forms.DataGridViewTextBoxColumn clNumber;
		private System.Windows.Forms.DataGridViewTextBoxColumn clCreditNumber;
		private System.Windows.Forms.DataGridViewTextBoxColumn clDate;
		private System.Windows.Forms.Label lblHeading;
		private System.Windows.Forms.Label label1;
	}
}