namespace Solsage_Process_Management_System.Forms
{
    partial class Integrity_Check
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Integrity_Check));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlRules = new System.Windows.Forms.Panel();
            this.busyPanel = new System.Windows.Forms.Panel();
            this.lblrecord = new System.Windows.Forms.Label();
            this.lblretrive = new System.Windows.Forms.Label();
            this.busyGiff = new System.Windows.Forms.PictureBox();
            this.gbFilter = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnProcess = new System.Windows.Forms.Button();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.rulesCheckBoxList = new System.Windows.Forms.CheckedListBox();
            this.errorListDatagridView = new System.Windows.Forms.DataGridView();
            this.RowNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DocumentNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeliveryDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Discount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabctrlerrorlist = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.duplicateDataGridView = new System.Windows.Forms.DataGridView();
            this.DuplicateRowNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DuplicateDocumentDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DuplicateOrderNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DuplicateDocumentNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpDeliveryDates = new System.Windows.Forms.TabPage();
            this.dgDeliveryDates = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlRules.SuspendLayout();
            this.busyPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.busyGiff)).BeginInit();
            this.gbFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorListDatagridView)).BeginInit();
            this.tabctrlerrorlist.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.duplicateDataGridView)).BeginInit();
            this.tpDeliveryDates.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDeliveryDates)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlRules
            // 
            this.pnlRules.Controls.Add(this.busyPanel);
            this.pnlRules.Controls.Add(this.gbFilter);
            this.pnlRules.Location = new System.Drawing.Point(2, 2);
            this.pnlRules.Name = "pnlRules";
            this.pnlRules.Size = new System.Drawing.Size(690, 127);
            this.pnlRules.TabIndex = 0;
            // 
            // busyPanel
            // 
            this.busyPanel.BackColor = System.Drawing.SystemColors.Control;
            this.busyPanel.Controls.Add(this.lblrecord);
            this.busyPanel.Controls.Add(this.lblretrive);
            this.busyPanel.Controls.Add(this.busyGiff);
            this.busyPanel.Location = new System.Drawing.Point(440, 3);
            this.busyPanel.Name = "busyPanel";
            this.busyPanel.Size = new System.Drawing.Size(239, 119);
            this.busyPanel.TabIndex = 164;
            this.busyPanel.Visible = false;
            // 
            // lblrecord
            // 
            this.lblrecord.AutoSize = true;
            this.lblrecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblrecord.Location = new System.Drawing.Point(138, 63);
            this.lblrecord.Name = "lblrecord";
            this.lblrecord.Size = new System.Drawing.Size(85, 20);
            this.lblrecord.TabIndex = 168;
            this.lblrecord.Text = "Records ...";
            // 
            // lblretrive
            // 
            this.lblretrive.AutoSize = true;
            this.lblretrive.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblretrive.Location = new System.Drawing.Point(138, 43);
            this.lblretrive.Name = "lblretrive";
            this.lblretrive.Size = new System.Drawing.Size(80, 20);
            this.lblretrive.TabIndex = 167;
            this.lblretrive.Text = "Retrieving";
            // 
            // busyGiff
            // 
            this.busyGiff.Image = ((System.Drawing.Image)(resources.GetObject("busyGiff.Image")));
            this.busyGiff.Location = new System.Drawing.Point(19, 12);
            this.busyGiff.Name = "busyGiff";
            this.busyGiff.Size = new System.Drawing.Size(101, 99);
            this.busyGiff.TabIndex = 165;
            this.busyGiff.TabStop = false;
            // 
            // gbFilter
            // 
            this.gbFilter.Controls.Add(this.label2);
            this.gbFilter.Controls.Add(this.btnProcess);
            this.gbFilter.Controls.Add(this.dtpTo);
            this.gbFilter.Controls.Add(this.dtpFrom);
            this.gbFilter.Controls.Add(this.lblCustomer);
            this.gbFilter.Controls.Add(this.rulesCheckBoxList);
            this.gbFilter.Location = new System.Drawing.Point(12, 15);
            this.gbFilter.Margin = new System.Windows.Forms.Padding(5);
            this.gbFilter.Name = "gbFilter";
            this.gbFilter.Size = new System.Drawing.Size(420, 107);
            this.gbFilter.TabIndex = 163;
            this.gbFilter.TabStop = false;
            this.gbFilter.Text = "Filter Results";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(221, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 168;
            this.label2.Text = "Date To:";
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(283, 54);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(118, 40);
            this.btnProcess.TabIndex = 6;
            this.btnProcess.Text = "Filter";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // dtpTo
            // 
            this.dtpTo.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTo.CustomFormat = "dd/MM/yyyy";
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTo.Location = new System.Drawing.Point(273, 19);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(128, 20);
            this.dtpTo.TabIndex = 4;
            // 
            // dtpFrom
            // 
            this.dtpFrom.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFrom.CustomFormat = "dd/MM/yyyy";
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFrom.Location = new System.Drawing.Point(70, 19);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(128, 20);
            this.dtpFrom.TabIndex = 3;
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Location = new System.Drawing.Point(8, 22);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(59, 13);
            this.lblCustomer.TabIndex = 161;
            this.lblCustomer.Text = "Date From:";
            // 
            // rulesCheckBoxList
            // 
            this.rulesCheckBoxList.CheckOnClick = true;
            this.rulesCheckBoxList.FormattingEnabled = true;
            this.rulesCheckBoxList.Items.AddRange(new object[] {
            "Non-lease Price Variations",
            "Duplicate Invoices",
            "Delivery Dates"});
            this.rulesCheckBoxList.Location = new System.Drawing.Point(11, 45);
            this.rulesCheckBoxList.Name = "rulesCheckBoxList";
            this.rulesCheckBoxList.Size = new System.Drawing.Size(194, 49);
            this.rulesCheckBoxList.TabIndex = 1;
            // 
            // errorListDatagridView
            // 
            this.errorListDatagridView.AllowUserToAddRows = false;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.errorListDatagridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.errorListDatagridView.ColumnHeadersHeight = 50;
            this.errorListDatagridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.errorListDatagridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RowNumber,
            this.DocumentNumber,
            this.DeliveryDate,
            this.ItemCode,
            this.Price,
            this.Discount,
            this.Total});
            this.errorListDatagridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.errorListDatagridView.Location = new System.Drawing.Point(3, 3);
            this.errorListDatagridView.Name = "errorListDatagridView";
            this.errorListDatagridView.ReadOnly = true;
            this.errorListDatagridView.RowHeadersVisible = false;
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.errorListDatagridView.RowsDefaultCellStyle = dataGridViewCellStyle16;
            this.errorListDatagridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.errorListDatagridView.Size = new System.Drawing.Size(676, 433);
            this.errorListDatagridView.TabIndex = 0;
            this.errorListDatagridView.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.errorListDatagridView_CellMouseDoubleClick);
            // 
            // RowNumber
            // 
            this.RowNumber.HeaderText = "#";
            this.RowNumber.Name = "RowNumber";
            this.RowNumber.ReadOnly = true;
            this.RowNumber.Width = 50;
            // 
            // DocumentNumber
            // 
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DocumentNumber.DefaultCellStyle = dataGridViewCellStyle12;
            this.DocumentNumber.HeaderText = "Document Number";
            this.DocumentNumber.Name = "DocumentNumber";
            this.DocumentNumber.ReadOnly = true;
            // 
            // DeliveryDate
            // 
            this.DeliveryDate.HeaderText = "Delivery Date";
            this.DeliveryDate.Name = "DeliveryDate";
            this.DeliveryDate.ReadOnly = true;
            // 
            // ItemCode
            // 
            this.ItemCode.HeaderText = "Item Code";
            this.ItemCode.Name = "ItemCode";
            this.ItemCode.ReadOnly = true;
            // 
            // Price
            // 
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Price.DefaultCellStyle = dataGridViewCellStyle13;
            this.Price.HeaderText = "Price";
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            // 
            // Discount
            // 
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Discount.DefaultCellStyle = dataGridViewCellStyle14;
            this.Discount.HeaderText = "Discount";
            this.Discount.Name = "Discount";
            this.Discount.ReadOnly = true;
            // 
            // Total
            // 
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Total.DefaultCellStyle = dataGridViewCellStyle15;
            this.Total.HeaderText = "Total";
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            // 
            // tabctrlerrorlist
            // 
            this.tabctrlerrorlist.Controls.Add(this.tabPage1);
            this.tabctrlerrorlist.Controls.Add(this.tabPage2);
            this.tabctrlerrorlist.Controls.Add(this.tpDeliveryDates);
            this.tabctrlerrorlist.Location = new System.Drawing.Point(2, 135);
            this.tabctrlerrorlist.Name = "tabctrlerrorlist";
            this.tabctrlerrorlist.SelectedIndex = 0;
            this.tabctrlerrorlist.Size = new System.Drawing.Size(690, 465);
            this.tabctrlerrorlist.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.errorListDatagridView);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(682, 439);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Non-lease Price Variations";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.duplicateDataGridView);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(682, 439);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Duplicate Invoices";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // duplicateDataGridView
            // 
            this.duplicateDataGridView.AllowUserToAddRows = false;
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.duplicateDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle17;
            this.duplicateDataGridView.ColumnHeadersHeight = 50;
            this.duplicateDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.duplicateDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DuplicateRowNumber,
            this.DuplicateDocumentDate,
            this.DuplicateOrderNumber,
            this.DuplicateDocumentNumber});
            this.duplicateDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.duplicateDataGridView.Location = new System.Drawing.Point(3, 3);
            this.duplicateDataGridView.Name = "duplicateDataGridView";
            this.duplicateDataGridView.ReadOnly = true;
            this.duplicateDataGridView.RowHeadersVisible = false;
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.duplicateDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle20;
            this.duplicateDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.duplicateDataGridView.Size = new System.Drawing.Size(676, 433);
            this.duplicateDataGridView.TabIndex = 1;
            this.duplicateDataGridView.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.duplicateDatagridView_CellMouseDoubleClick);
            // 
            // DuplicateRowNumber
            // 
            this.DuplicateRowNumber.HeaderText = "#";
            this.DuplicateRowNumber.Name = "DuplicateRowNumber";
            this.DuplicateRowNumber.ReadOnly = true;
            this.DuplicateRowNumber.Width = 50;
            // 
            // DuplicateDocumentDate
            // 
            this.DuplicateDocumentDate.HeaderText = "Document Date";
            this.DuplicateDocumentDate.Name = "DuplicateDocumentDate";
            this.DuplicateDocumentDate.ReadOnly = true;
            this.DuplicateDocumentDate.Width = 125;
            // 
            // DuplicateOrderNumber
            // 
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.DuplicateOrderNumber.DefaultCellStyle = dataGridViewCellStyle18;
            this.DuplicateOrderNumber.HeaderText = "Order Number";
            this.DuplicateOrderNumber.Name = "DuplicateOrderNumber";
            this.DuplicateOrderNumber.ReadOnly = true;
            this.DuplicateOrderNumber.Width = 200;
            // 
            // DuplicateDocumentNumber
            // 
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DuplicateDocumentNumber.DefaultCellStyle = dataGridViewCellStyle19;
            this.DuplicateDocumentNumber.HeaderText = "Document Number";
            this.DuplicateDocumentNumber.Name = "DuplicateDocumentNumber";
            this.DuplicateDocumentNumber.ReadOnly = true;
            this.DuplicateDocumentNumber.Width = 250;
            // 
            // tpDeliveryDates
            // 
            this.tpDeliveryDates.Controls.Add(this.dgDeliveryDates);
            this.tpDeliveryDates.Location = new System.Drawing.Point(4, 22);
            this.tpDeliveryDates.Name = "tpDeliveryDates";
            this.tpDeliveryDates.Padding = new System.Windows.Forms.Padding(3);
            this.tpDeliveryDates.Size = new System.Drawing.Size(682, 439);
            this.tpDeliveryDates.TabIndex = 2;
            this.tpDeliveryDates.Text = "Delivery Dates";
            this.tpDeliveryDates.UseVisualStyleBackColor = true;
            // 
            // dgDeliveryDates
            // 
            this.dgDeliveryDates.AllowUserToAddRows = false;
            this.dgDeliveryDates.AllowUserToDeleteRows = false;
            this.dgDeliveryDates.AllowUserToResizeRows = false;
            this.dgDeliveryDates.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDeliveryDates.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgDeliveryDates.Location = new System.Drawing.Point(3, 3);
            this.dgDeliveryDates.Name = "dgDeliveryDates";
            this.dgDeliveryDates.RowHeadersVisible = false;
            this.dgDeliveryDates.Size = new System.Drawing.Size(676, 433);
            this.dgDeliveryDates.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 603);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(207, 13);
            this.label1.TabIndex = 169;
            this.label1.Text = "* Double click a specific Invoice to view it.";
            // 
            // Integrity_Check
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 632);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabctrlerrorlist);
            this.Controls.Add(this.pnlRules);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "Integrity_Check";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Integrity Check";
            this.Load += new System.EventHandler(this.Integrity_Check_Load);
            this.pnlRules.ResumeLayout(false);
            this.busyPanel.ResumeLayout(false);
            this.busyPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.busyGiff)).EndInit();
            this.gbFilter.ResumeLayout(false);
            this.gbFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorListDatagridView)).EndInit();
            this.tabctrlerrorlist.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.duplicateDataGridView)).EndInit();
            this.tpDeliveryDates.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgDeliveryDates)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlRules;
        private System.Windows.Forms.CheckedListBox rulesCheckBoxList;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.DataGridView errorListDatagridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.GroupBox gbFilter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.TabControl tabctrlerrorlist;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.PictureBox busyGiff;
        private System.Windows.Forms.Panel busyPanel;
        private System.Windows.Forms.Label lblretrive;
        private System.Windows.Forms.Label lblrecord;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn DocumentNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn DeliveryDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Discount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView duplicateDataGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn DuplicateRowNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn DuplicateDocumentDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn DuplicateOrderNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn DuplicateDocumentNumber;
        private System.Windows.Forms.TabPage tpDeliveryDates;
        private System.Windows.Forms.DataGridView dgDeliveryDates;

    }
}