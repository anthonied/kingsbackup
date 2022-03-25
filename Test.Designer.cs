namespace Liquid
{
	partial class Test
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmdGetInventory = new System.Windows.Forms.Button();
            this.txtSdkResults = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdInvoice = new System.Windows.Forms.Button();
            this.cmdSalesTest = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.cmdPrint = new System.Windows.Forms.Button();
            this.dgIntegrity = new System.Windows.Forms.DataGridView();
            this.clSalesOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clLiquid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clPastel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clCustomer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clitemdescrip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblForecastValue = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblPastelOrders = new System.Windows.Forms.Label();
            this.lblLiquidOrders = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.cmdInvoiceIntegrity = new System.Windows.Forms.Button();
            this.chkPastelLiquidIntegrity = new System.Windows.Forms.Button();
            this.chkSOIntegrity = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgIntegrity)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdGetInventory
            // 
            this.cmdGetInventory.Location = new System.Drawing.Point(12, 407);
            this.cmdGetInventory.Name = "cmdGetInventory";
            this.cmdGetInventory.Size = new System.Drawing.Size(161, 23);
            this.cmdGetInventory.TabIndex = 0;
            this.cmdGetInventory.Text = "Get Inventory Qty";
            this.cmdGetInventory.UseVisualStyleBackColor = true;
            this.cmdGetInventory.Click += new System.EventHandler(this.cmdGetInventory_Click);
            // 
            // txtSdkResults
            // 
            this.txtSdkResults.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtSdkResults.Location = new System.Drawing.Point(0, 478);
            this.txtSdkResults.Multiline = true;
            this.txtSdkResults.Name = "txtSdkResults";
            this.txtSdkResults.Size = new System.Drawing.Size(1077, 107);
            this.txtSdkResults.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 452);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Result returned from Pastel";
            // 
            // cmdInvoice
            // 
            this.cmdInvoice.Location = new System.Drawing.Point(12, 325);
            this.cmdInvoice.Name = "cmdInvoice";
            this.cmdInvoice.Size = new System.Drawing.Size(161, 23);
            this.cmdInvoice.TabIndex = 3;
            this.cmdInvoice.Text = "Create Invoice";
            this.cmdInvoice.UseVisualStyleBackColor = true;
            this.cmdInvoice.Visible = false;
            this.cmdInvoice.Click += new System.EventHandler(this.cmdInvoice_Click);
            // 
            // cmdSalesTest
            // 
            this.cmdSalesTest.Location = new System.Drawing.Point(234, 407);
            this.cmdSalesTest.Name = "cmdSalesTest";
            this.cmdSalesTest.Size = new System.Drawing.Size(137, 23);
            this.cmdSalesTest.TabIndex = 4;
            this.cmdSalesTest.Text = "test Salesorder";
            this.cmdSalesTest.UseVisualStyleBackColor = true;
            this.cmdSalesTest.Click += new System.EventHandler(this.cmdSalesTest_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(234, 363);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(137, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Test GRN Link";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmdPrint
            // 
            this.cmdPrint.Location = new System.Drawing.Point(12, 363);
            this.cmdPrint.Name = "cmdPrint";
            this.cmdPrint.Size = new System.Drawing.Size(161, 23);
            this.cmdPrint.TabIndex = 6;
            this.cmdPrint.Text = "Test Print";
            this.cmdPrint.UseVisualStyleBackColor = true;
            this.cmdPrint.Click += new System.EventHandler(this.cmdPrint_Click);
            // 
            // dgIntegrity
            // 
            this.dgIntegrity.AllowUserToAddRows = false;
            this.dgIntegrity.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgIntegrity.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgIntegrity.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgIntegrity.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clSalesOrder,
            this.clLiquid,
            this.clPastel,
            this.clStatus,
            this.clCustomer,
            this.clitemdescrip});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgIntegrity.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgIntegrity.Dock = System.Windows.Forms.DockStyle.Right;
            this.dgIntegrity.Location = new System.Drawing.Point(467, 0);
            this.dgIntegrity.Name = "dgIntegrity";
            this.dgIntegrity.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgIntegrity.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgIntegrity.RowHeadersVisible = false;
            this.dgIntegrity.Size = new System.Drawing.Size(610, 478);
            this.dgIntegrity.TabIndex = 7;
            // 
            // clSalesOrder
            // 
            this.clSalesOrder.HeaderText = "Sales Order";
            this.clSalesOrder.Name = "clSalesOrder";
            this.clSalesOrder.ReadOnly = true;
            this.clSalesOrder.Width = 150;
            // 
            // clLiquid
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.clLiquid.DefaultCellStyle = dataGridViewCellStyle2;
            this.clLiquid.HeaderText = "Liquid Lines";
            this.clLiquid.Name = "clLiquid";
            this.clLiquid.ReadOnly = true;
            this.clLiquid.Width = 80;
            // 
            // clPastel
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.clPastel.DefaultCellStyle = dataGridViewCellStyle3;
            this.clPastel.HeaderText = "Pastel Lines";
            this.clPastel.Name = "clPastel";
            this.clPastel.ReadOnly = true;
            this.clPastel.Width = 80;
            // 
            // clStatus
            // 
            this.clStatus.HeaderText = "Status";
            this.clStatus.Name = "clStatus";
            this.clStatus.ReadOnly = true;
            this.clStatus.Width = 80;
            // 
            // clCustomer
            // 
            this.clCustomer.HeaderText = "customer";
            this.clCustomer.Name = "clCustomer";
            this.clCustomer.ReadOnly = true;
            // 
            // clitemdescrip
            // 
            this.clitemdescrip.HeaderText = "description";
            this.clitemdescrip.Name = "clitemdescrip";
            this.clitemdescrip.ReadOnly = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblForecastValue);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lblPastelOrders);
            this.groupBox1.Controls.Add(this.lblLiquidOrders);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(428, 165);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Integrity Check";
            // 
            // lblForecastValue
            // 
            this.lblForecastValue.AutoSize = true;
            this.lblForecastValue.Location = new System.Drawing.Point(163, 105);
            this.lblForecastValue.Name = "lblForecastValue";
            this.lblForecastValue.Size = new System.Drawing.Size(13, 13);
            this.lblForecastValue.TabIndex = 5;
            this.lblForecastValue.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "# Forecast Check";
            // 
            // lblPastelOrders
            // 
            this.lblPastelOrders.AutoSize = true;
            this.lblPastelOrders.Location = new System.Drawing.Point(163, 58);
            this.lblPastelOrders.Name = "lblPastelOrders";
            this.lblPastelOrders.Size = new System.Drawing.Size(13, 13);
            this.lblPastelOrders.TabIndex = 3;
            this.lblPastelOrders.Text = "0";
            // 
            // lblLiquidOrders
            // 
            this.lblLiquidOrders.AutoSize = true;
            this.lblLiquidOrders.Location = new System.Drawing.Point(163, 33);
            this.lblLiquidOrders.Name = "lblLiquidOrders";
            this.lblLiquidOrders.Size = new System.Drawing.Size(13, 13);
            this.lblLiquidOrders.TabIndex = 2;
            this.lblLiquidOrders.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "# Pastel Orders";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "# Liquid Orders";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(234, 325);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(137, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "Test Transfers";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // cmdInvoiceIntegrity
            // 
            this.cmdInvoiceIntegrity.Location = new System.Drawing.Point(234, 278);
            this.cmdInvoiceIntegrity.Name = "cmdInvoiceIntegrity";
            this.cmdInvoiceIntegrity.Size = new System.Drawing.Size(137, 23);
            this.cmdInvoiceIntegrity.TabIndex = 10;
            this.cmdInvoiceIntegrity.Text = "Invoice Integrity";
            this.cmdInvoiceIntegrity.UseVisualStyleBackColor = true;
            this.cmdInvoiceIntegrity.Click += new System.EventHandler(this.cmdInvoiceIntegrity_Click);
            // 
            // chkPastelLiquidIntegrity
            // 
            this.chkPastelLiquidIntegrity.Location = new System.Drawing.Point(12, 235);
            this.chkPastelLiquidIntegrity.Name = "chkPastelLiquidIntegrity";
            this.chkPastelLiquidIntegrity.Size = new System.Drawing.Size(161, 23);
            this.chkPastelLiquidIntegrity.TabIndex = 12;
            this.chkPastelLiquidIntegrity.Text = "Pastel Liquid Integrity";
            this.chkPastelLiquidIntegrity.UseVisualStyleBackColor = true;
            this.chkPastelLiquidIntegrity.Click += new System.EventHandler(this.chkPastelLiquidIntegrity_Click);
            // 
            // chkSOIntegrity
            // 
            this.chkSOIntegrity.Location = new System.Drawing.Point(234, 235);
            this.chkSOIntegrity.Name = "chkSOIntegrity";
            this.chkSOIntegrity.Size = new System.Drawing.Size(137, 23);
            this.chkSOIntegrity.TabIndex = 13;
            this.chkSOIntegrity.Text = "Sales Order Integrity";
            this.chkSOIntegrity.UseVisualStyleBackColor = true;
            this.chkSOIntegrity.Click += new System.EventHandler(this.chkSOIntegrity_Click);
            // 
            // Test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1077, 585);
            this.Controls.Add(this.chkSOIntegrity);
            this.Controls.Add(this.chkPastelLiquidIntegrity);
            this.Controls.Add(this.cmdInvoiceIntegrity);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgIntegrity);
            this.Controls.Add(this.cmdPrint);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cmdSalesTest);
            this.Controls.Add(this.cmdInvoice);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSdkResults);
            this.Controls.Add(this.cmdGetInventory);
            this.Name = "Test";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Test";
            this.Load += new System.EventHandler(this.Test_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgIntegrity)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button cmdGetInventory;
		private System.Windows.Forms.TextBox txtSdkResults;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button cmdInvoice;
		private System.Windows.Forms.Button cmdSalesTest;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button cmdPrint;
        private System.Windows.Forms.DataGridView dgIntegrity;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblPastelOrders;
        private System.Windows.Forms.Label lblLiquidOrders;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button cmdInvoiceIntegrity;
        private System.Windows.Forms.DataGridViewTextBoxColumn clSalesOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn clLiquid;
        private System.Windows.Forms.DataGridViewTextBoxColumn clPastel;
        private System.Windows.Forms.DataGridViewTextBoxColumn clStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn clCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn clitemdescrip;
        private System.Windows.Forms.Label lblForecastValue;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button chkPastelLiquidIntegrity;
        private System.Windows.Forms.Button chkSOIntegrity;
	}
}