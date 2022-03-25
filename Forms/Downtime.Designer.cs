namespace Liquid.Forms
{
	partial class Downtime
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Downtime));
			this.panel1 = new System.Windows.Forms.Panel();
			this.lblAsset = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.cmdSave = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.dtDateFrom = new System.Windows.Forms.DateTimePicker();
			this.dtDateTo = new System.Windows.Forms.DateTimePicker();
			this.txtDays = new System.Windows.Forms.TextBox();
			this.panel2 = new System.Windows.Forms.Panel();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.lblAsset);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Location = new System.Drawing.Point(12, 45);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(334, 60);
			this.panel1.TabIndex = 167;
			// 
			// lblAsset
			// 
			this.lblAsset.AutoSize = true;
			this.lblAsset.Location = new System.Drawing.Point(179, 23);
			this.lblAsset.Name = "lblAsset";
			this.lblAsset.Size = new System.Drawing.Size(0, 13);
			this.lblAsset.TabIndex = 2;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(3, 21);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(158, 15);
			this.label3.TabIndex = 1;
			this.label3.Text = "Down Time For Lease Item:";
			// 
			// cmdCancel
			// 
			this.cmdCancel.Cursor = System.Windows.Forms.Cursors.Hand;
			this.cmdCancel.FlatAppearance.BorderSize = 0;
			this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmdCancel.Image = ((System.Drawing.Image)(resources.GetObject("cmdCancel.Image")));
			this.cmdCancel.Location = new System.Drawing.Point(44, 12);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.Size = new System.Drawing.Size(24, 23);
			this.cmdCancel.TabIndex = 166;
			this.cmdCancel.UseVisualStyleBackColor = true;
			this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
			// 
			// cmdSave
			// 
			this.cmdSave.Cursor = System.Windows.Forms.Cursors.Hand;
			this.cmdSave.Enabled = false;
			this.cmdSave.FlatAppearance.BorderSize = 0;
			this.cmdSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmdSave.Image = ((System.Drawing.Image)(resources.GetObject("cmdSave.Image")));
			this.cmdSave.Location = new System.Drawing.Point(12, 12);
			this.cmdSave.Name = "cmdSave";
			this.cmdSave.Size = new System.Drawing.Size(24, 23);
			this.cmdSave.TabIndex = 165;
			this.cmdSave.UseVisualStyleBackColor = true;
			this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 11);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(90, 13);
			this.label1.TabIndex = 168;
			this.label1.Text = "Down Time From:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(3, 51);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(80, 13);
			this.label2.TabIndex = 169;
			this.label2.Text = "Down Time To:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(3, 91);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(79, 13);
			this.label4.TabIndex = 170;
			this.label4.Text = "Result In Days:";
			// 
			// dtDateFrom
			// 
			this.dtDateFrom.Location = new System.Drawing.Point(125, 6);
			this.dtDateFrom.Name = "dtDateFrom";
			this.dtDateFrom.Size = new System.Drawing.Size(200, 20);
			this.dtDateFrom.TabIndex = 171;
			this.dtDateFrom.ValueChanged += new System.EventHandler(this.dtDateFrom_ValueChanged);
			// 
			// dtDateTo
			// 
			this.dtDateTo.Location = new System.Drawing.Point(125, 46);
			this.dtDateTo.Name = "dtDateTo";
			this.dtDateTo.Size = new System.Drawing.Size(200, 20);
			this.dtDateTo.TabIndex = 172;
			this.dtDateTo.ValueChanged += new System.EventHandler(this.dtDateFrom_ValueChanged);
			// 
			// txtDays
			// 
			this.txtDays.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtDays.Location = new System.Drawing.Point(125, 86);
			this.txtDays.Name = "txtDays";
			this.txtDays.Size = new System.Drawing.Size(46, 20);
			this.txtDays.TabIndex = 173;
			this.txtDays.Text = "0.00";
			this.txtDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;			
			this.txtDays.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDays_KeyPress);
			// 
			// panel2
			// 
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Controls.Add(this.label1);
			this.panel2.Controls.Add(this.txtDays);
			this.panel2.Controls.Add(this.label2);
			this.panel2.Controls.Add(this.dtDateTo);
			this.panel2.Controls.Add(this.label4);
			this.panel2.Controls.Add(this.dtDateFrom);
			this.panel2.Location = new System.Drawing.Point(12, 127);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(334, 124);
			this.panel2.TabIndex = 168;
			// 
			// Downtime
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(358, 274);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.cmdCancel);
			this.Controls.Add(this.cmdSave);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "Downtime";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Down Time";
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button cmdCancel;
		private System.Windows.Forms.Button cmdSave;
		private System.Windows.Forms.Label lblAsset;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.DateTimePicker dtDateFrom;
		private System.Windows.Forms.DateTimePicker dtDateTo;
		private System.Windows.Forms.TextBox txtDays;
		private System.Windows.Forms.Panel panel2;

	}
}