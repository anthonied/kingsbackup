namespace Liquid.Controls
{
	partial class CreditLine
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.txtDescription = new System.Windows.Forms.TextBox();
			this.txtUnit = new System.Windows.Forms.TextBox();
			this.txtQuantity = new System.Windows.Forms.TextBox();
			this.txtExcPrice = new System.Windows.Forms.TextBox();
			this.txtNet = new System.Windows.Forms.TextBox();
			this.txtCode = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.cmdRemoveCredit = new System.Windows.Forms.Button();
			this.txtStore = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// txtDescription
			// 
			this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtDescription.ForeColor = System.Drawing.Color.Maroon;
			this.txtDescription.Location = new System.Drawing.Point(177, 3);
			this.txtDescription.MaxLength = 40;
			this.txtDescription.Name = "txtDescription";
			this.txtDescription.Size = new System.Drawing.Size(240, 13);
			this.txtDescription.TabIndex = 59;
			// 
			// txtUnit
			// 
			this.txtUnit.BackColor = System.Drawing.Color.White;
			this.txtUnit.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtUnit.ForeColor = System.Drawing.Color.Maroon;
			this.txtUnit.Location = new System.Drawing.Point(587, 3);
			this.txtUnit.Name = "txtUnit";
			this.txtUnit.ReadOnly = true;
			this.txtUnit.Size = new System.Drawing.Size(50, 13);
			this.txtUnit.TabIndex = 60;
			this.txtUnit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// txtQuantity
			// 
			this.txtQuantity.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtQuantity.ForeColor = System.Drawing.Color.Maroon;
			this.txtQuantity.Location = new System.Drawing.Point(653, 3);
			this.txtQuantity.Name = "txtQuantity";
			this.txtQuantity.Size = new System.Drawing.Size(70, 13);
			this.txtQuantity.TabIndex = 61;
			this.txtQuantity.Text = "1.00";
			this.txtQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtQuantity.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtExcPrice_KeyUp);
			this.txtQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numeric_KeyPress);
			// 
			// txtExcPrice
			// 
			this.txtExcPrice.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtExcPrice.ForeColor = System.Drawing.Color.Maroon;
			this.txtExcPrice.Location = new System.Drawing.Point(798, 3);
			this.txtExcPrice.Name = "txtExcPrice";
			this.txtExcPrice.Size = new System.Drawing.Size(70, 13);
			this.txtExcPrice.TabIndex = 62;
			this.txtExcPrice.Text = "0";
			this.txtExcPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtExcPrice.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtExcPrice_KeyUp);
			this.txtExcPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numeric_KeyPress);
			// 
			// txtNet
			// 
			this.txtNet.BackColor = System.Drawing.Color.White;
			this.txtNet.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtNet.ForeColor = System.Drawing.Color.Maroon;
			this.txtNet.Location = new System.Drawing.Point(881, 3);
			this.txtNet.Name = "txtNet";
			this.txtNet.ReadOnly = true;
			this.txtNet.Size = new System.Drawing.Size(80, 13);
			this.txtNet.TabIndex = 63;
			this.txtNet.Text = "0";
			this.txtNet.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtCode
			// 
			this.txtCode.BackColor = System.Drawing.Color.White;
			this.txtCode.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtCode.ForeColor = System.Drawing.Color.Maroon;
			this.txtCode.Location = new System.Drawing.Point(61, 3);
			this.txtCode.Name = "txtCode";
			this.txtCode.ReadOnly = true;
			this.txtCode.Size = new System.Drawing.Size(86, 13);
			this.txtCode.TabIndex = 64;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.White;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.Maroon;
			this.label1.Location = new System.Drawing.Point(1, 3);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(46, 12);
			this.label1.TabIndex = 65;
			this.label1.Text = "CREDIT";
			// 
			// cmdRemoveCredit
			// 
			this.cmdRemoveCredit.BackColor = System.Drawing.Color.DarkRed;
			this.cmdRemoveCredit.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cmdRemoveCredit.ForeColor = System.Drawing.Color.White;
			this.cmdRemoveCredit.Location = new System.Drawing.Point(501, -1);
			this.cmdRemoveCredit.Name = "cmdRemoveCredit";
			this.cmdRemoveCredit.Size = new System.Drawing.Size(76, 22);
			this.cmdRemoveCredit.TabIndex = 66;
			this.cmdRemoveCredit.Text = "Remove";
			this.cmdRemoveCredit.UseVisualStyleBackColor = false;
			
			// 
			// txtStore
			// 
			this.txtStore.BackColor = System.Drawing.Color.White;
			this.txtStore.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtStore.ForeColor = System.Drawing.Color.Maroon;
			this.txtStore.Location = new System.Drawing.Point(3, 4);
			this.txtStore.Name = "txtStore";
			this.txtStore.ReadOnly = true;
			this.txtStore.Size = new System.Drawing.Size(86, 13);
			this.txtStore.TabIndex = 67;
			this.txtStore.Visible = false;
			// 
			// CreditLine
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.Controls.Add(this.cmdRemoveCredit);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtCode);
			this.Controls.Add(this.txtNet);
			this.Controls.Add(this.txtExcPrice);
			this.Controls.Add(this.txtQuantity);
			this.Controls.Add(this.txtUnit);
			this.Controls.Add(this.txtDescription);
			this.Controls.Add(this.txtStore);
			this.Name = "CreditLine";
			this.Size = new System.Drawing.Size(963, 20);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		public System.Windows.Forms.TextBox txtDescription;
		public System.Windows.Forms.TextBox txtUnit;
		public System.Windows.Forms.TextBox txtQuantity;
		public System.Windows.Forms.TextBox txtExcPrice;
		public System.Windows.Forms.TextBox txtNet;
		public System.Windows.Forms.TextBox txtCode;
		private System.Windows.Forms.Label label1;
		public System.Windows.Forms.Button cmdRemoveCredit;
		public System.Windows.Forms.TextBox txtStore;

	}
}
