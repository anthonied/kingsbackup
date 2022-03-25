namespace Liquid.Documents
{
	partial class SalesLineInfo
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
			this.lblCode = new System.Windows.Forms.Label();
			this.lblDescription = new System.Windows.Forms.Label();
			this.lblLastInvoice = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 20);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(58, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Line Code:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 50);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(63, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Description:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 80);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(94, 13);
			this.label3.TabIndex = 2;
			this.label3.Text = "Last Invoice Date:";
			// 
			// lblCode
			// 
			this.lblCode.AutoSize = true;
			this.lblCode.Location = new System.Drawing.Point(136, 20);
			this.lblCode.Name = "lblCode";
			this.lblCode.Size = new System.Drawing.Size(0, 13);
			this.lblCode.TabIndex = 3;
			// 
			// lblDescription
			// 
			this.lblDescription.AutoSize = true;
			this.lblDescription.Location = new System.Drawing.Point(136, 50);
			this.lblDescription.Name = "lblDescription";
			this.lblDescription.Size = new System.Drawing.Size(0, 13);
			this.lblDescription.TabIndex = 4;
			// 
			// lblLastInvoice
			// 
			this.lblLastInvoice.AutoSize = true;
			this.lblLastInvoice.Location = new System.Drawing.Point(136, 80);
			this.lblLastInvoice.Name = "lblLastInvoice";
			this.lblLastInvoice.Size = new System.Drawing.Size(0, 13);
			this.lblLastInvoice.TabIndex = 5;
			// 
			// SalesLineInfo
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(349, 126);
			this.Controls.Add(this.lblLastInvoice);
			this.Controls.Add(this.lblDescription);
			this.Controls.Add(this.lblCode);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "SalesLineInfo";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Sales Line Info";
			this.Load += new System.EventHandler(this.SalesLineInfo_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label lblCode;
		private System.Windows.Forms.Label lblDescription;
		private System.Windows.Forms.Label lblLastInvoice;
	}
}