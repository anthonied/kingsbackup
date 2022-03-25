namespace Liquid.Finder
{
	partial class LedgerZoom
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gpFilters = new System.Windows.Forms.GroupBox();
            this.txtAccountCode = new System.Windows.Forms.TextBox();
            this.lblAccountCode = new System.Windows.Forms.Label();
            this.dgLedger = new System.Windows.Forms.DataGridView();
            this.clNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.gpFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgLedger)).BeginInit();
            this.SuspendLayout();
            // 
            // gpFilters
            // 
            this.gpFilters.Controls.Add(this.txtDescription);
            this.gpFilters.Controls.Add(this.label1);
            this.gpFilters.Controls.Add(this.txtAccountCode);
            this.gpFilters.Controls.Add(this.lblAccountCode);
            this.gpFilters.Location = new System.Drawing.Point(12, 12);
            this.gpFilters.Name = "gpFilters";
            this.gpFilters.Size = new System.Drawing.Size(510, 60);
            this.gpFilters.TabIndex = 7;
            this.gpFilters.TabStop = false;
            this.gpFilters.Text = "Filter Results By";
            // 
            // txtAccountCode
            // 
            this.txtAccountCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAccountCode.Location = new System.Drawing.Point(92, 25);
            this.txtAccountCode.MaxLength = 6;
            this.txtAccountCode.Name = "txtAccountCode";
            this.txtAccountCode.Size = new System.Drawing.Size(100, 20);
            this.txtAccountCode.TabIndex = 1;
            this.txtAccountCode.TextChanged += new System.EventHandler(this.txtAccountCode_TextChanged);
            this.txtAccountCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAccountCode_KeyDown);
            // 
            // lblAccountCode
            // 
            this.lblAccountCode.AutoSize = true;
            this.lblAccountCode.Location = new System.Drawing.Point(14, 28);
            this.lblAccountCode.Name = "lblAccountCode";
            this.lblAccountCode.Size = new System.Drawing.Size(75, 13);
            this.lblAccountCode.TabIndex = 0;
            this.lblAccountCode.Text = "Account Code";
            // 
            // dgLedger
            // 
            this.dgLedger.AllowUserToAddRows = false;
            this.dgLedger.AllowUserToDeleteRows = false;
            this.dgLedger.AllowUserToResizeColumns = false;
            this.dgLedger.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.GhostWhite;
            this.dgLedger.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgLedger.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgLedger.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clNumber,
            this.clDescription});
            this.dgLedger.Location = new System.Drawing.Point(12, 81);
            this.dgLedger.Name = "dgLedger";
            this.dgLedger.ReadOnly = true;
            this.dgLedger.RowHeadersVisible = false;
            this.dgLedger.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgLedger.Size = new System.Drawing.Size(510, 333);
            this.dgLedger.TabIndex = 6;
            this.dgLedger.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgLedger_CellContentDoubleClick);
            this.dgLedger.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgLedger_KeyDown);
            // 
            // clNumber
            // 
            this.clNumber.HeaderText = "Account Code";
            this.clNumber.Name = "clNumber";
            this.clNumber.ReadOnly = true;
            this.clNumber.Width = 150;
            // 
            // clDescription
            // 
            this.clDescription.HeaderText = "Account Description";
            this.clDescription.Name = "clDescription";
            this.clDescription.ReadOnly = true;
            this.clDescription.Width = 300;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(216, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Description";
            // 
            // txtDescription
            // 
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescription.Location = new System.Drawing.Point(285, 25);
            this.txtDescription.MaxLength = 6;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(211, 20);
            this.txtDescription.TabIndex = 2;
            this.txtDescription.TextChanged += new System.EventHandler(this.txtDescription_TextChanged);
            this.txtDescription.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDescription_KeyDown);
            // 
            // LedgerZoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 445);
            this.Controls.Add(this.gpFilters);
            this.Controls.Add(this.dgLedger);
            this.Name = "LedgerZoom";
            this.Text = "LedgerZoom";
            this.Load += new System.EventHandler(this.LedgerZoom_Load);
            this.gpFilters.ResumeLayout(false);
            this.gpFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgLedger)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox gpFilters;
        private System.Windows.Forms.TextBox txtAccountCode;
		private System.Windows.Forms.Label lblAccountCode;
        private System.Windows.Forms.DataGridView dgLedger;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDescription;
	}
}