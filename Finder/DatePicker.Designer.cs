namespace Liquid.Finder
{
	partial class DatePicker
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
			this.dtDate = new System.Windows.Forms.MonthCalendar();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// dtDate
			// 
			this.dtDate.Location = new System.Drawing.Point(44, 65);
			this.dtDate.Name = "dtDate";
			this.dtDate.TabIndex = 1;
			this.dtDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DatePicker_KeyDown);
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(307, 37);
			this.label1.TabIndex = 2;
			this.label1.Text = "Please select a date and press <Enter> to close the window.";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// DatePicker
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.PapayaWhip;
			this.ClientSize = new System.Drawing.Size(331, 255);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.dtDate);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "DatePicker";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Date Picker";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DatePicker_KeyDown);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.MonthCalendar dtDate;
		private System.Windows.Forms.Label label1;

	}
}