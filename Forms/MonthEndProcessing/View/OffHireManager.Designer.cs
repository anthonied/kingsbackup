namespace Liquid.Forms.MonthEndProcessing.View
{
    partial class OffHireManager
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbFilter = new System.Windows.Forms.GroupBox();
            this.txtCustomerPrefix = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDocDateTo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCustomerTo = new System.Windows.Forms.TextBox();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.dgSalesOrder = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtInvoiceDateTo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtInvoiceDateFrom = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtOffhireEnd = new System.Windows.Forms.DateTimePicker();
            this.dtOffhireStart = new System.Windows.Forms.DateTimePicker();
            this.cmdOffHireAll = new System.Windows.Forms.Button();
            this.cmdRemoveAll = new System.Windows.Forms.Button();
            this.chkSelectAll = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.clSalesOrderNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LockedStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clClient = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clOffHireStartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clOffHireEndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clLastInvoiceDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clSelected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.HasOffHire = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clCancel = new System.Windows.Forms.DataGridViewLinkColumn();
            this.gbFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgSalesOrder)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbFilter
            // 
            this.gbFilter.Controls.Add(this.txtCustomerPrefix);
            this.gbFilter.Controls.Add(this.label1);
            this.gbFilter.Controls.Add(this.txtDocDateTo);
            this.gbFilter.Controls.Add(this.label3);
            this.gbFilter.Controls.Add(this.label2);
            this.gbFilter.Controls.Add(this.txtCustomerTo);
            this.gbFilter.Controls.Add(this.lblCustomer);
            this.gbFilter.Controls.Add(this.txtCustomer);
            this.gbFilter.Location = new System.Drawing.Point(5, 14);
            this.gbFilter.Margin = new System.Windows.Forms.Padding(5);
            this.gbFilter.Name = "gbFilter";
            this.gbFilter.Size = new System.Drawing.Size(619, 49);
            this.gbFilter.TabIndex = 163;
            this.gbFilter.TabStop = false;
            this.gbFilter.Text = "Filter Results";
            // 
            // txtCustomerPrefix
            // 
            this.txtCustomerPrefix.BackColor = System.Drawing.SystemColors.Control;
            this.txtCustomerPrefix.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustomerPrefix.Location = new System.Drawing.Point(593, 19);
            this.txtCustomerPrefix.MaxLength = 16;
            this.txtCustomerPrefix.Name = "txtCustomerPrefix";
            this.txtCustomerPrefix.ReadOnly = true;
            this.txtCustomerPrefix.Size = new System.Drawing.Size(20, 20);
            this.txtCustomerPrefix.TabIndex = 173;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(508, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 172;
            this.label1.Text = "Customer Letter:";
            // 
            // txtDocDateTo
            // 
            this.txtDocDateTo.BackColor = System.Drawing.SystemColors.Control;
            this.txtDocDateTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDocDateTo.Location = new System.Drawing.Point(399, 19);
            this.txtDocDateTo.MaxLength = 16;
            this.txtDocDateTo.Name = "txtDocDateTo";
            this.txtDocDateTo.ReadOnly = true;
            this.txtDocDateTo.Size = new System.Drawing.Size(97, 20);
            this.txtDocDateTo.TabIndex = 171;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(324, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 170;
            this.label3.Text = "Doc Date To:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(190, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 168;
            this.label2.Text = "To:";
            // 
            // txtCustomerTo
            // 
            this.txtCustomerTo.BackColor = System.Drawing.SystemColors.Control;
            this.txtCustomerTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustomerTo.Location = new System.Drawing.Point(215, 19);
            this.txtCustomerTo.MaxLength = 16;
            this.txtCustomerTo.Name = "txtCustomerTo";
            this.txtCustomerTo.ReadOnly = true;
            this.txtCustomerTo.Size = new System.Drawing.Size(97, 20);
            this.txtCustomerTo.TabIndex = 167;
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Location = new System.Drawing.Point(8, 21);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(80, 13);
            this.lblCustomer.TabIndex = 161;
            this.lblCustomer.Text = "Customer From:";
            // 
            // txtCustomer
            // 
            this.txtCustomer.BackColor = System.Drawing.SystemColors.Control;
            this.txtCustomer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustomer.Location = new System.Drawing.Point(89, 19);
            this.txtCustomer.MaxLength = 16;
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.ReadOnly = true;
            this.txtCustomer.Size = new System.Drawing.Size(97, 20);
            this.txtCustomer.TabIndex = 160;
            // 
            // dgSalesOrder
            // 
            this.dgSalesOrder.AllowUserToAddRows = false;
            this.dgSalesOrder.AllowUserToDeleteRows = false;
            this.dgSalesOrder.AllowUserToResizeColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgSalesOrder.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgSalesOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgSalesOrder.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clSalesOrderNum,
            this.LockedStatus,
            this.clClient,
            this.clOffHireStartDate,
            this.clOffHireEndDate,
            this.clLastInvoiceDate,
            this.clSelected,
            this.HasOffHire,
            this.clCancel});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgSalesOrder.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgSalesOrder.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgSalesOrder.Location = new System.Drawing.Point(0, 118);
            this.dgSalesOrder.Name = "dgSalesOrder";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgSalesOrder.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgSalesOrder.RowHeadersVisible = false;
            this.dgSalesOrder.RowHeadersWidth = 51;
            this.dgSalesOrder.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgSalesOrder.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgSalesOrder.Size = new System.Drawing.Size(986, 561);
            this.dgSalesOrder.TabIndex = 164;
            this.dgSalesOrder.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgSalesOrder_CellClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtInvoiceDateTo);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtInvoiceDateFrom);
            this.groupBox1.Location = new System.Drawing.Point(658, 14);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(318, 49);
            this.groupBox1.TabIndex = 174;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Invoice Period";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(174, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 13);
            this.label6.TabIndex = 168;
            this.label6.Text = "To:";
            // 
            // txtInvoiceDateTo
            // 
            this.txtInvoiceDateTo.BackColor = System.Drawing.SystemColors.Control;
            this.txtInvoiceDateTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInvoiceDateTo.Location = new System.Drawing.Point(203, 19);
            this.txtInvoiceDateTo.MaxLength = 16;
            this.txtInvoiceDateTo.Name = "txtInvoiceDateTo";
            this.txtInvoiceDateTo.ReadOnly = true;
            this.txtInvoiceDateTo.Size = new System.Drawing.Size(97, 20);
            this.txtInvoiceDateTo.TabIndex = 167;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 13);
            this.label7.TabIndex = 161;
            this.label7.Text = "Date From:";
            // 
            // txtInvoiceDateFrom
            // 
            this.txtInvoiceDateFrom.BackColor = System.Drawing.SystemColors.Control;
            this.txtInvoiceDateFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInvoiceDateFrom.Location = new System.Drawing.Point(71, 19);
            this.txtInvoiceDateFrom.MaxLength = 16;
            this.txtInvoiceDateFrom.Name = "txtInvoiceDateFrom";
            this.txtInvoiceDateFrom.ReadOnly = true;
            this.txtInvoiceDateFrom.Size = new System.Drawing.Size(97, 20);
            this.txtInvoiceDateFrom.TabIndex = 160;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtOffhireEnd);
            this.groupBox2.Controls.Add(this.dtOffhireStart);
            this.groupBox2.Controls.Add(this.cmdOffHireAll);
            this.groupBox2.Controls.Add(this.cmdRemoveAll);
            this.groupBox2.Controls.Add(this.chkSelectAll);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Location = new System.Drawing.Point(5, 62);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(971, 48);
            this.groupBox2.TabIndex = 174;
            this.groupBox2.TabStop = false;
            // 
            // dtOffhireEnd
            // 
            this.dtOffhireEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtOffhireEnd.Location = new System.Drawing.Point(215, 18);
            this.dtOffhireEnd.Name = "dtOffhireEnd";
            this.dtOffhireEnd.Size = new System.Drawing.Size(97, 20);
            this.dtOffhireEnd.TabIndex = 179;
            // 
            // dtOffhireStart
            // 
            this.dtOffhireStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtOffhireStart.Location = new System.Drawing.Point(89, 18);
            this.dtOffhireStart.Name = "dtOffhireStart";
            this.dtOffhireStart.Size = new System.Drawing.Size(97, 20);
            this.dtOffhireStart.TabIndex = 178;
            // 
            // cmdOffHireAll
            // 
            this.cmdOffHireAll.Location = new System.Drawing.Point(327, 16);
            this.cmdOffHireAll.Name = "cmdOffHireAll";
            this.cmdOffHireAll.Size = new System.Drawing.Size(109, 23);
            this.cmdOffHireAll.TabIndex = 177;
            this.cmdOffHireAll.Text = "Apply To Selected";
            this.cmdOffHireAll.UseVisualStyleBackColor = true;
            this.cmdOffHireAll.Click += new System.EventHandler(this.cmdOffHireAll_Click);
            // 
            // cmdRemoveAll
            // 
            this.cmdRemoveAll.Location = new System.Drawing.Point(844, 16);
            this.cmdRemoveAll.Name = "cmdRemoveAll";
            this.cmdRemoveAll.Size = new System.Drawing.Size(109, 23);
            this.cmdRemoveAll.TabIndex = 176;
            this.cmdRemoveAll.Text = "Remove Selected";
            this.cmdRemoveAll.UseVisualStyleBackColor = true;
            this.cmdRemoveAll.Click += new System.EventHandler(this.cmdRemoveAll_Click);
            // 
            // chkSelectAll
            // 
            this.chkSelectAll.AutoSize = true;
            this.chkSelectAll.Location = new System.Drawing.Point(748, 21);
            this.chkSelectAll.Name = "chkSelectAll";
            this.chkSelectAll.Size = new System.Drawing.Size(15, 14);
            this.chkSelectAll.TabIndex = 175;
            this.chkSelectAll.UseVisualStyleBackColor = true;
            this.chkSelectAll.CheckedChanged += new System.EventHandler(this.chkSelectAll_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(661, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 174;
            this.label4.Text = "(De)Select All:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(190, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(23, 13);
            this.label8.TabIndex = 168;
            this.label8.Text = "To:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 21);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 13);
            this.label9.TabIndex = 161;
            this.label9.Text = "Date From:";
            // 
            // clSalesOrderNum
            // 
            this.clSalesOrderNum.DataPropertyName = "DocumentNumber";
            this.clSalesOrderNum.HeaderText = "Sales Order";
            this.clSalesOrderNum.MinimumWidth = 6;
            this.clSalesOrderNum.Name = "clSalesOrderNum";
            this.clSalesOrderNum.ReadOnly = true;
            this.clSalesOrderNum.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clSalesOrderNum.Width = 105;
            // 
            // LockedStatus
            // 
            this.LockedStatus.DataPropertyName = "LockedStatus";
            this.LockedStatus.HeaderText = "LockedStatus";
            this.LockedStatus.MinimumWidth = 6;
            this.LockedStatus.Name = "LockedStatus";
            this.LockedStatus.Visible = false;
            this.LockedStatus.Width = 125;
            // 
            // clClient
            // 
            this.clClient.DataPropertyName = "CustomerCode";
            this.clClient.HeaderText = "Customer";
            this.clClient.MinimumWidth = 6;
            this.clClient.Name = "clClient";
            this.clClient.ReadOnly = true;
            this.clClient.Width = 125;
            // 
            // clOffHireStartDate
            // 
            this.clOffHireStartDate.DataPropertyName = "OffHireStartDate";
            this.clOffHireStartDate.HeaderText = "Off Hire Start";
            this.clOffHireStartDate.MinimumWidth = 6;
            this.clOffHireStartDate.Name = "clOffHireStartDate";
            this.clOffHireStartDate.Width = 125;
            // 
            // clOffHireEndDate
            // 
            this.clOffHireEndDate.DataPropertyName = "OffHireEndDate";
            this.clOffHireEndDate.HeaderText = "Off Hire End";
            this.clOffHireEndDate.MinimumWidth = 6;
            this.clOffHireEndDate.Name = "clOffHireEndDate";
            this.clOffHireEndDate.ReadOnly = true;
            this.clOffHireEndDate.Width = 120;
            // 
            // clLastInvoiceDate
            // 
            this.clLastInvoiceDate.DataPropertyName = "ProjectedDays";
            this.clLastInvoiceDate.HeaderText = "Days Not To Invoice";
            this.clLastInvoiceDate.MinimumWidth = 6;
            this.clLastInvoiceDate.Name = "clLastInvoiceDate";
            this.clLastInvoiceDate.Width = 120;
            // 
            // clSelected
            // 
            this.clSelected.DataPropertyName = "Selected";
            this.clSelected.HeaderText = "Selected";
            this.clSelected.MinimumWidth = 6;
            this.clSelected.Name = "clSelected";
            this.clSelected.Width = 125;
            // 
            // HasOffHire
            // 
            this.HasOffHire.DataPropertyName = "HasOffHire";
            this.HasOffHire.HeaderText = "clHassOffHire";
            this.HasOffHire.Name = "HasOffHire";
            this.HasOffHire.ReadOnly = true;
            this.HasOffHire.Visible = false;
            // 
            // clCancel
            // 
            this.clCancel.HeaderText = "Cancel Off Hire";
            this.clCancel.Name = "clCancel";
            this.clCancel.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // OffHireManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(986, 679);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgSalesOrder);
            this.Controls.Add(this.gbFilter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "OffHireManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Temporary Off Hire Manager";
            this.Load += new System.EventHandler(this.OffHireManager_Load);
            this.gbFilter.ResumeLayout(false);
            this.gbFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgSalesOrder)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbFilter;
        private System.Windows.Forms.TextBox txtCustomerPrefix;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDocDateTo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCustomerTo;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.DataGridView dgSalesOrder;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtInvoiceDateTo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtInvoiceDateFrom;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox chkSelectAll;
        private System.Windows.Forms.DateTimePicker dtOffhireEnd;
        private System.Windows.Forms.DateTimePicker dtOffhireStart;
        private System.Windows.Forms.Button cmdOffHireAll;
        private System.Windows.Forms.Button cmdRemoveAll;
        private System.Windows.Forms.DataGridViewTextBoxColumn clSalesOrderNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn LockedStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn clClient;
        private System.Windows.Forms.DataGridViewTextBoxColumn clOffHireStartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clOffHireEndDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clLastInvoiceDate;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clSelected;
        private System.Windows.Forms.DataGridViewCheckBoxColumn HasOffHire;
        private System.Windows.Forms.DataGridViewLinkColumn clCancel;
    }
}