namespace Liquid.Forms
{
    partial class DuplicateInvoices
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbFilter = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtInvoiceMonth = new System.Windows.Forms.DateTimePicker();
            this.cmdFilter = new System.Windows.Forms.Button();
            this.dgDefiniteDuplicates = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgPropableDuplicate = new System.Windows.Forms.DataGridView();
            this.clSalesOrderNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clInvoiceNumbers = new System.Windows.Forms.DataGridViewLinkColumn();
            this.dataGridViewLinkColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clInvoices = new System.Windows.Forms.DataGridViewLinkColumn();
            this.gbFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDefiniteDuplicates)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgPropableDuplicate)).BeginInit();
            this.SuspendLayout();
            // 
            // gbFilter
            // 
            this.gbFilter.Controls.Add(this.label3);
            this.gbFilter.Controls.Add(this.dtInvoiceMonth);
            this.gbFilter.Controls.Add(this.cmdFilter);
            this.gbFilter.Location = new System.Drawing.Point(14, 14);
            this.gbFilter.Margin = new System.Windows.Forms.Padding(5);
            this.gbFilter.Name = "gbFilter";
            this.gbFilter.Size = new System.Drawing.Size(331, 48);
            this.gbFilter.TabIndex = 163;
            this.gbFilter.TabStop = false;
            this.gbFilter.Text = "Filter Results";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 170;
            this.label3.Text = "Month:";
            // 
            // dtInvoiceMonth
            // 
            this.dtInvoiceMonth.CustomFormat = "MMMM yyyy";
            this.dtInvoiceMonth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtInvoiceMonth.Location = new System.Drawing.Point(89, 13);
            this.dtInvoiceMonth.Name = "dtInvoiceMonth";
            this.dtInvoiceMonth.Size = new System.Drawing.Size(118, 20);
            this.dtInvoiceMonth.TabIndex = 169;
            // 
            // cmdFilter
            // 
            this.cmdFilter.Location = new System.Drawing.Point(247, 14);
            this.cmdFilter.Name = "cmdFilter";
            this.cmdFilter.Size = new System.Drawing.Size(75, 23);
            this.cmdFilter.TabIndex = 4;
            this.cmdFilter.Text = "Filter";
            this.cmdFilter.UseVisualStyleBackColor = true;
            this.cmdFilter.Click += new System.EventHandler(this.cmdFilter_Click);
            // 
            // dgDefiniteDuplicates
            // 
            this.dgDefiniteDuplicates.AllowUserToAddRows = false;
            this.dgDefiniteDuplicates.AllowUserToDeleteRows = false;
            this.dgDefiniteDuplicates.AllowUserToResizeColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgDefiniteDuplicates.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgDefiniteDuplicates.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDefiniteDuplicates.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clSalesOrderNum,
            this.clCount,
            this.clInvoiceNumbers});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgDefiniteDuplicates.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgDefiniteDuplicates.Location = new System.Drawing.Point(12, 100);
            this.dgDefiniteDuplicates.Name = "dgDefiniteDuplicates";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgDefiniteDuplicates.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgDefiniteDuplicates.RowHeadersVisible = false;
            this.dgDefiniteDuplicates.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgDefiniteDuplicates.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgDefiniteDuplicates.Size = new System.Drawing.Size(828, 224);
            this.dgDefiniteDuplicates.TabIndex = 164;
            this.dgDefiniteDuplicates.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgDefiniteDuplicates_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 166;
            this.label1.Text = "Definite:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 327);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 167;
            this.label2.Text = "Probable:";
            // 
            // dgPropableDuplicate
            // 
            this.dgPropableDuplicate.AllowUserToAddRows = false;
            this.dgPropableDuplicate.AllowUserToDeleteRows = false;
            this.dgPropableDuplicate.AllowUserToResizeColumns = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgPropableDuplicate.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgPropableDuplicate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPropableDuplicate.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewLinkColumn1,
            this.dataGridViewTextBoxColumn1,
            this.clInvoices});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgPropableDuplicate.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgPropableDuplicate.Location = new System.Drawing.Point(12, 343);
            this.dgPropableDuplicate.Name = "dgPropableDuplicate";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgPropableDuplicate.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgPropableDuplicate.RowHeadersVisible = false;
            this.dgPropableDuplicate.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgPropableDuplicate.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgPropableDuplicate.Size = new System.Drawing.Size(828, 227);
            this.dgPropableDuplicate.TabIndex = 168;
            this.dgPropableDuplicate.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgPropableDuplicate_CellClick);
            // 
            // clSalesOrderNum
            // 
            this.clSalesOrderNum.DataPropertyName = "DocumentNumber";
            this.clSalesOrderNum.HeaderText = "Customer";
            this.clSalesOrderNum.Name = "clSalesOrderNum";
            this.clSalesOrderNum.ReadOnly = true;
            this.clSalesOrderNum.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clSalesOrderNum.Width = 200;
            // 
            // clCount
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            this.clCount.DefaultCellStyle = dataGridViewCellStyle2;
            this.clCount.HeaderText = "Count";
            this.clCount.Name = "clCount";
            this.clCount.Width = 50;
            // 
            // clInvoiceNumbers
            // 
            this.clInvoiceNumbers.HeaderText = "Invoices";
            this.clInvoiceNumbers.Name = "clInvoiceNumbers";
            this.clInvoiceNumbers.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clInvoiceNumbers.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.clInvoiceNumbers.Width = 500;
            // 
            // dataGridViewLinkColumn1
            // 
            this.dataGridViewLinkColumn1.DataPropertyName = "DocumentNumber";
            this.dataGridViewLinkColumn1.HeaderText = "Customer";
            this.dataGridViewLinkColumn1.Name = "dataGridViewLinkColumn1";
            this.dataGridViewLinkColumn1.ReadOnly = true;
            this.dataGridViewLinkColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewLinkColumn1.Width = 200;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTextBoxColumn1.HeaderText = "Count";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 50;
            // 
            // clInvoices
            // 
            this.clInvoices.HeaderText = "Invoices";
            this.clInvoices.Name = "clInvoices";
            this.clInvoices.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clInvoices.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.clInvoices.Width = 500;
            // 
            // DuplicateInvoices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 582);
            this.Controls.Add(this.dgPropableDuplicate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgDefiniteDuplicates);
            this.Controls.Add(this.gbFilter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "DuplicateInvoices";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Duplicate Invoices";
            this.Load += new System.EventHandler(this.DuplicateInvoices_Load);
            this.gbFilter.ResumeLayout(false);
            this.gbFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDefiniteDuplicates)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgPropableDuplicate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbFilter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtInvoiceMonth;
        private System.Windows.Forms.Button cmdFilter;
        private System.Windows.Forms.DataGridView dgDefiniteDuplicates;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgPropableDuplicate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clSalesOrderNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn clCount;
        private System.Windows.Forms.DataGridViewLinkColumn clInvoiceNumbers;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewLinkColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewLinkColumn clInvoices;
    }
}