namespace Liquid.Finder
{
	partial class CustomerZoom
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerZoom));
            this.dgCustomers = new System.Windows.Forms.DataGridView();
            this.clNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clBlocked = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gpFilters = new System.Windows.Forms.GroupBox();
            this.txtIDNumber = new System.Windows.Forms.TextBox();
            this.txtTelephoneNumber = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chkBlocked = new System.Windows.Forms.CheckBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.cmdNew = new System.Windows.Forms.Button();
            this.txtAccountCode = new System.Windows.Forms.TextBox();
            this.cmdFilter = new System.Windows.Forms.Button();
            this.lblAccountCode = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgCustomers)).BeginInit();
            this.gpFilters.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgCustomers
            // 
            this.dgCustomers.AllowUserToAddRows = false;
            this.dgCustomers.AllowUserToDeleteRows = false;
            this.dgCustomers.AllowUserToResizeColumns = false;
            this.dgCustomers.AllowUserToResizeRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.GhostWhite;
            this.dgCustomers.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCustomers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clNumber,
            this.clDescription,
            this.clBlocked});
            this.dgCustomers.Location = new System.Drawing.Point(14, 106);
            this.dgCustomers.Name = "dgCustomers";
            this.dgCustomers.ReadOnly = true;
            this.dgCustomers.RowHeadersVisible = false;
            this.dgCustomers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgCustomers.Size = new System.Drawing.Size(700, 331);
            this.dgCustomers.TabIndex = 1;
            this.dgCustomers.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgCustomers_CellDoubleClick);
            this.dgCustomers.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgCustomers_KeyDown);
            this.dgCustomers.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgCustomers_KeyPress);
            // 
            // clNumber
            // 
            this.clNumber.DataPropertyName = "CustomerCode";
            this.clNumber.HeaderText = "Code";
            this.clNumber.Name = "clNumber";
            this.clNumber.ReadOnly = true;
            this.clNumber.Width = 75;
            // 
            // clDescription
            // 
            this.clDescription.DataPropertyName = "CustomerDesc";
            this.clDescription.HeaderText = "Description";
            this.clDescription.Name = "clDescription";
            this.clDescription.ReadOnly = true;
            this.clDescription.Width = 250;
            // 
            // clBlocked
            // 
            this.clBlocked.DataPropertyName = "Blocked";
            this.clBlocked.HeaderText = "Status";
            this.clBlocked.Name = "clBlocked";
            this.clBlocked.ReadOnly = true;
            // 
            // gpFilters
            // 
            this.gpFilters.Controls.Add(this.label3);
            this.gpFilters.Controls.Add(this.textBox1);
            this.gpFilters.Controls.Add(this.txtIDNumber);
            this.gpFilters.Controls.Add(this.txtTelephoneNumber);
            this.gpFilters.Controls.Add(this.label2);
            this.gpFilters.Controls.Add(this.label1);
            this.gpFilters.Controls.Add(this.chkBlocked);
            this.gpFilters.Controls.Add(this.txtDescription);
            this.gpFilters.Controls.Add(this.lblDescription);
            this.gpFilters.Controls.Add(this.cmdNew);
            this.gpFilters.Controls.Add(this.txtAccountCode);
            this.gpFilters.Controls.Add(this.cmdFilter);
            this.gpFilters.Controls.Add(this.lblAccountCode);
            this.gpFilters.Location = new System.Drawing.Point(14, 4);
            this.gpFilters.Name = "gpFilters";
            this.gpFilters.Size = new System.Drawing.Size(700, 73);
            this.gpFilters.TabIndex = 5;
            this.gpFilters.TabStop = false;
            this.gpFilters.Text = "Filter Results By";
            // 
            // txtIDNumber
            // 
            this.txtIDNumber.AcceptsReturn = true;
            this.txtIDNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIDNumber.Location = new System.Drawing.Point(100, 48);
            this.txtIDNumber.Name = "txtIDNumber";
            this.txtIDNumber.Size = new System.Drawing.Size(100, 20);
            this.txtIDNumber.TabIndex = 13;
            this.txtIDNumber.TextChanged += new System.EventHandler(this.txtAccountCode_TextChanged);
            this.txtIDNumber.Enter += new System.EventHandler(this.txtAccountCode_Enter);
            this.txtIDNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAccountCode_KeyDown);
            // 
            // txtTelephoneNumber
            // 
            this.txtTelephoneNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTelephoneNumber.Location = new System.Drawing.Point(284, 48);
            this.txtTelephoneNumber.Name = "txtTelephoneNumber";
            this.txtTelephoneNumber.Size = new System.Drawing.Size(125, 20);
            this.txtTelephoneNumber.TabIndex = 12;
            this.txtTelephoneNumber.TextChanged += new System.EventHandler(this.txtAccountCode_TextChanged);
            this.txtTelephoneNumber.Enter += new System.EventHandler(this.txtAccountCode_Enter);
            this.txtTelephoneNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAccountCode_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(206, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Telephone Nr";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "ID Number";
            // 
            // chkBlocked
            // 
            this.chkBlocked.AutoSize = true;
            this.chkBlocked.Location = new System.Drawing.Point(536, 50);
            this.chkBlocked.Name = "chkBlocked";
            this.chkBlocked.Size = new System.Drawing.Size(151, 17);
            this.chkBlocked.TabIndex = 9;
            this.chkBlocked.Text = "Show blocked customers?";
            this.chkBlocked.UseVisualStyleBackColor = true;
            this.chkBlocked.Visible = false;
            this.chkBlocked.CheckedChanged += new System.EventHandler(this.chkBlocked_CheckedChanged);
            // 
            // txtDescription
            // 
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescription.Location = new System.Drawing.Point(284, 18);
            this.txtDescription.MaxLength = 100;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(243, 20);
            this.txtDescription.TabIndex = 2;
            this.txtDescription.TextChanged += new System.EventHandler(this.txtAccountCode_TextChanged);
            this.txtDescription.Enter += new System.EventHandler(this.txtAccountCode_Enter);
            this.txtDescription.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAccountCode_KeyDown);
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(206, 21);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(60, 13);
            this.lblDescription.TabIndex = 0;
            this.lblDescription.Text = "Description";
            // 
            // cmdNew
            // 
            this.cmdNew.BackColor = System.Drawing.Color.White;
            this.cmdNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdNew.Image = global::Liquid.Properties.Resources.star_yellow;
            this.cmdNew.Location = new System.Drawing.Point(658, 17);
            this.cmdNew.Name = "cmdNew";
            this.cmdNew.Size = new System.Drawing.Size(25, 23);
            this.cmdNew.TabIndex = 8;
            this.cmdNew.UseVisualStyleBackColor = false;
            this.cmdNew.Click += new System.EventHandler(this.cmdNew_Click);
            // 
            // txtAccountCode
            // 
            this.txtAccountCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAccountCode.Location = new System.Drawing.Point(100, 19);
            this.txtAccountCode.MaxLength = 6;
            this.txtAccountCode.Name = "txtAccountCode";
            this.txtAccountCode.Size = new System.Drawing.Size(100, 20);
            this.txtAccountCode.TabIndex = 1;
            this.txtAccountCode.TextChanged += new System.EventHandler(this.txtAccountCode_TextChanged);
            this.txtAccountCode.Enter += new System.EventHandler(this.txtAccountCode_Enter);
            this.txtAccountCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAccountCode_KeyDown);
            // 
            // cmdFilter
            // 
            this.cmdFilter.BackColor = System.Drawing.Color.White;
            this.cmdFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdFilter.Image = ((System.Drawing.Image)(resources.GetObject("cmdFilter.Image")));
            this.cmdFilter.Location = new System.Drawing.Point(627, 17);
            this.cmdFilter.Name = "cmdFilter";
            this.cmdFilter.Size = new System.Drawing.Size(25, 23);
            this.cmdFilter.TabIndex = 7;
            this.cmdFilter.UseVisualStyleBackColor = false;
            this.cmdFilter.Click += new System.EventHandler(this.cmdFilter_Click);
            // 
            // lblAccountCode
            // 
            this.lblAccountCode.AutoSize = true;
            this.lblAccountCode.Location = new System.Drawing.Point(19, 22);
            this.lblAccountCode.Name = "lblAccountCode";
            this.lblAccountCode.Size = new System.Drawing.Size(75, 13);
            this.lblAccountCode.TabIndex = 0;
            this.lblAccountCode.Text = "Account Code";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.Red;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Location = new System.Drawing.Point(439, 48);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(18, 20);
            this.textBox1.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(463, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Fraud Entry";
            // 
            // CustomerZoom
            // 
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ClientSize = new System.Drawing.Size(726, 449);
            this.Controls.Add(this.dgCustomers);
            this.Controls.Add(this.gpFilters);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CustomerZoom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customer Zoom";
            this.Load += new System.EventHandler(this.CustomerZoom_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgCustomers)).EndInit();
            this.gpFilters.ResumeLayout(false);
            this.gpFilters.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView dgCustomers;
		private System.Windows.Forms.GroupBox gpFilters;
        private System.Windows.Forms.Label lblAccountCode;
		private System.Windows.Forms.Button cmdFilter;
        private System.Windows.Forms.Button cmdNew;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn clNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn clBlocked;
        private System.Windows.Forms.CheckBox chkBlocked;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIDNumber;
        private System.Windows.Forms.TextBox txtTelephoneNumber;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtAccountCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
    }
}