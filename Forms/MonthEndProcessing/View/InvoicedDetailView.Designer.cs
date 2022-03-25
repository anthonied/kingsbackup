namespace Liquid.Forms.MonthEndProcessing.View
{
    partial class InvoicedDetailView
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgInvoice = new System.Windows.Forms.DataGridView();
            this.clInvoiceNumber = new System.Windows.Forms.DataGridViewLinkColumn();
            this.clCustomerCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDeliveryNote = new System.Windows.Forms.DataGridViewLinkColumn();
            this.clAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtInvoiceMonth = new System.Windows.Forms.DateTimePicker();
            this.cmdFilter = new System.Windows.Forms.Button();
            this.selCustLetter = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgZeroInvoice = new System.Windows.Forms.DataGridView();
            this.dataGridViewLinkColumn1 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewLinkColumn2 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgInvoice)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgZeroInvoice)).BeginInit();
            this.SuspendLayout();
            // 
            // dgInvoice
            // 
            this.dgInvoice.AllowUserToAddRows = false;
            this.dgInvoice.AllowUserToDeleteRows = false;
            this.dgInvoice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgInvoice.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clInvoiceNumber,
            this.clCustomerCode,
            this.clDeliveryNote,
            this.clAmount});
            this.dgInvoice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgInvoice.Location = new System.Drawing.Point(3, 3);
            this.dgInvoice.Name = "dgInvoice";
            this.dgInvoice.ReadOnly = true;
            this.dgInvoice.RowHeadersVisible = false;
            this.dgInvoice.Size = new System.Drawing.Size(564, 321);
            this.dgInvoice.TabIndex = 0;
            this.dgInvoice.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgInvoice_CellContentClick);
            // 
            // clInvoiceNumber
            // 
            this.clInvoiceNumber.DataPropertyName = "InvoiceNumber";
            this.clInvoiceNumber.HeaderText = "Invoice Number";
            this.clInvoiceNumber.Name = "clInvoiceNumber";
            this.clInvoiceNumber.ReadOnly = true;
            this.clInvoiceNumber.Width = 120;
            // 
            // clCustomerCode
            // 
            this.clCustomerCode.DataPropertyName = "CustomerCode";
            this.clCustomerCode.HeaderText = "Customer Code";
            this.clCustomerCode.Name = "clCustomerCode";
            this.clCustomerCode.ReadOnly = true;
            this.clCustomerCode.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clCustomerCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clCustomerCode.Width = 120;
            // 
            // clDeliveryNote
            // 
            this.clDeliveryNote.DataPropertyName = "DeliveryNoteNumber";
            this.clDeliveryNote.HeaderText = "Delivery Note";
            this.clDeliveryNote.Name = "clDeliveryNote";
            this.clDeliveryNote.ReadOnly = true;
            this.clDeliveryNote.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clDeliveryNote.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // clAmount
            // 
            this.clAmount.DataPropertyName = "Amount";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.clAmount.DefaultCellStyle = dataGridViewCellStyle1;
            this.clAmount.HeaderText = "Amount";
            this.clAmount.Name = "clAmount";
            this.clAmount.ReadOnly = true;
            this.clAmount.Width = 150;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtInvoiceMonth);
            this.groupBox1.Controls.Add(this.cmdFilter);
            this.groupBox1.Controls.Add(this.selCustLetter);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(459, 90);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Invoices for";
            // 
            // dtInvoiceMonth
            // 
            this.dtInvoiceMonth.CustomFormat = "dd-MM-yyyy";
            this.dtInvoiceMonth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtInvoiceMonth.Location = new System.Drawing.Point(131, 27);
            this.dtInvoiceMonth.Name = "dtInvoiceMonth";
            this.dtInvoiceMonth.Size = new System.Drawing.Size(119, 20);
            this.dtInvoiceMonth.TabIndex = 174;
            // 
            // cmdFilter
            // 
            this.cmdFilter.Location = new System.Drawing.Point(345, 27);
            this.cmdFilter.Name = "cmdFilter";
            this.cmdFilter.Size = new System.Drawing.Size(75, 50);
            this.cmdFilter.TabIndex = 173;
            this.cmdFilter.Text = "Filter";
            this.cmdFilter.UseVisualStyleBackColor = true;
            this.cmdFilter.Click += new System.EventHandler(this.cmdFilter_Click);
            // 
            // selCustLetter
            // 
            this.selCustLetter.FormattingEnabled = true;
            this.selCustLetter.Items.AddRange(new object[] {
            "0-9",
            "A",
            "B",
            "C",
            "D",
            "E",
            "F",
            "G",
            "H",
            "I",
            "J",
            "K",
            "L",
            "M",
            "N",
            "O",
            "P",
            "Q",
            "R",
            "S",
            "T",
            "U",
            "V",
            "W",
            "X",
            "Y",
            "Z"});
            this.selCustLetter.Location = new System.Drawing.Point(131, 53);
            this.selCustLetter.Name = "selCustLetter";
            this.selCustLetter.Size = new System.Drawing.Size(119, 21);
            this.selCustLetter.TabIndex = 172;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Letter:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Only Created After:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 99);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(578, 353);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgInvoice);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(570, 327);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "All Invoices";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgZeroInvoice);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(570, 327);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Zero Invoices";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgZeroInvoice
            // 
            this.dgZeroInvoice.AllowUserToAddRows = false;
            this.dgZeroInvoice.AllowUserToDeleteRows = false;
            this.dgZeroInvoice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgZeroInvoice.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewLinkColumn1,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewLinkColumn2,
            this.dataGridViewTextBoxColumn2});
            this.dgZeroInvoice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgZeroInvoice.Location = new System.Drawing.Point(3, 3);
            this.dgZeroInvoice.Name = "dgZeroInvoice";
            this.dgZeroInvoice.ReadOnly = true;
            this.dgZeroInvoice.RowHeadersVisible = false;
            this.dgZeroInvoice.Size = new System.Drawing.Size(564, 321);
            this.dgZeroInvoice.TabIndex = 1;
            // 
            // dataGridViewLinkColumn1
            // 
            this.dataGridViewLinkColumn1.DataPropertyName = "InvoiceNumber";
            this.dataGridViewLinkColumn1.HeaderText = "Invoice Number";
            this.dataGridViewLinkColumn1.Name = "dataGridViewLinkColumn1";
            this.dataGridViewLinkColumn1.ReadOnly = true;
            this.dataGridViewLinkColumn1.Width = 120;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "CustomerCode";
            this.dataGridViewTextBoxColumn1.HeaderText = "Customer Code";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn1.Width = 120;
            // 
            // dataGridViewLinkColumn2
            // 
            this.dataGridViewLinkColumn2.DataPropertyName = "DeliveryNoteNumber";
            this.dataGridViewLinkColumn2.HeaderText = "Delivery Note";
            this.dataGridViewLinkColumn2.Name = "dataGridViewLinkColumn2";
            this.dataGridViewLinkColumn2.ReadOnly = true;
            this.dataGridViewLinkColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewLinkColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Amount";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTextBoxColumn2.HeaderText = "Amount";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 150;
            // 
            // InvoicedDetailView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 460);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "InvoicedDetailView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Summary";
            ((System.ComponentModel.ISupportInitialize)(this.dgInvoice)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgZeroInvoice)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgInvoice;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox selCustLetter;
        private System.Windows.Forms.Button cmdFilter;
        private System.Windows.Forms.DateTimePicker dtInvoiceMonth;
        private System.Windows.Forms.DataGridViewLinkColumn clInvoiceNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn clCustomerCode;
        private System.Windows.Forms.DataGridViewLinkColumn clDeliveryNote;
        private System.Windows.Forms.DataGridViewTextBoxColumn clAmount;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dgZeroInvoice;
        private System.Windows.Forms.DataGridViewLinkColumn dataGridViewLinkColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewLinkColumn dataGridViewLinkColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
    }
}