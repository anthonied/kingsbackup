namespace Liquid.Finder
{
    partial class StockIssueZoom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StockIssueZoom));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmdFilter = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDocNum = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRespPerson = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvStockIssueDocs = new System.Windows.Forms.DataGridView();
            this.clDocNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clRespPerson = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDocDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clSalesCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clNotes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnFilterInclBatch = new System.Windows.Forms.Button();
            this.txtInclBatch = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockIssueDocs)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmdFilter);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.dtpFrom);
            this.groupBox1.Controls.Add(this.dtpTo);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtDocNum);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtRespPerson);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(316, 78);
            this.groupBox1.TabIndex = 178;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter";
            // 
            // cmdFilter
            // 
            this.cmdFilter.BackColor = System.Drawing.Color.White;
            this.cmdFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdFilter.Image = ((System.Drawing.Image)(resources.GetObject("cmdFilter.Image")));
            this.cmdFilter.Location = new System.Drawing.Point(268, 47);
            this.cmdFilter.Name = "cmdFilter";
            this.cmdFilter.Size = new System.Drawing.Size(25, 23);
            this.cmdFilter.TabIndex = 179;
            this.cmdFilter.UseVisualStyleBackColor = false;
            this.cmdFilter.Click += new System.EventHandler(this.cmdFilter_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(135, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 13);
            this.label5.TabIndex = 178;
            this.label5.Text = "To";
            // 
            // dtpFrom
            // 
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(49, 49);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(80, 20);
            this.dtpFrom.TabIndex = 177;
            // 
            // dtpTo
            // 
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(182, 49);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(80, 20);
            this.dtpTo.TabIndex = 176;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 175;
            this.label4.Text = "From";
            // 
            // txtDocNum
            // 
            this.txtDocNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDocNum.Location = new System.Drawing.Point(49, 20);
            this.txtDocNum.MaxLength = 8;
            this.txtDocNum.Name = "txtDocNum";
            this.txtDocNum.Size = new System.Drawing.Size(80, 20);
            this.txtDocNum.TabIndex = 171;
            this.txtDocNum.TextChanged += new System.EventHandler(this.txtDocNum_TextChanged);
            this.txtDocNum.Enter += new System.EventHandler(this.txtDocNum_Enter);
            this.txtDocNum.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDocNum_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 170;
            this.label1.Text = "Doc #";
            // 
            // txtRespPerson
            // 
            this.txtRespPerson.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRespPerson.Location = new System.Drawing.Point(218, 19);
            this.txtRespPerson.MaxLength = 8;
            this.txtRespPerson.Name = "txtRespPerson";
            this.txtRespPerson.Size = new System.Drawing.Size(75, 20);
            this.txtRespPerson.TabIndex = 174;
            this.txtRespPerson.TextChanged += new System.EventHandler(this.txtRespPerson_TextChanged);
            this.txtRespPerson.Enter += new System.EventHandler(this.txtRespPerson_Enter);
            this.txtRespPerson.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRespPerson_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(135, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 173;
            this.label2.Text = "Resp Person";
            // 
            // dgvStockIssueDocs
            // 
            this.dgvStockIssueDocs.AllowUserToAddRows = false;
            this.dgvStockIssueDocs.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            this.dgvStockIssueDocs.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvStockIssueDocs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStockIssueDocs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clDocNumber,
            this.clRespPerson,
            this.clDocDate,
            this.clSalesCode,
            this.clNotes});
            this.dgvStockIssueDocs.Location = new System.Drawing.Point(12, 98);
            this.dgvStockIssueDocs.Name = "dgvStockIssueDocs";
            this.dgvStockIssueDocs.ReadOnly = true;
            this.dgvStockIssueDocs.RowHeadersVisible = false;
            this.dgvStockIssueDocs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStockIssueDocs.Size = new System.Drawing.Size(314, 360);
            this.dgvStockIssueDocs.TabIndex = 179;
            this.dgvStockIssueDocs.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStockIssueDocs_CellDoubleClick);
            this.dgvStockIssueDocs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvStockIssueDocs_KeyDown);
            this.dgvStockIssueDocs.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgvStockIssueDocs_KeyPress);
            // 
            // clDocNumber
            // 
            this.clDocNumber.DataPropertyName = "DocNumber";
            this.clDocNumber.HeaderText = "Document #";
            this.clDocNumber.Name = "clDocNumber";
            this.clDocNumber.ReadOnly = true;
            // 
            // clRespPerson
            // 
            this.clRespPerson.DataPropertyName = "RespPersonRef";
            this.clRespPerson.HeaderText = "Resp. Person";
            this.clRespPerson.Name = "clRespPerson";
            this.clRespPerson.ReadOnly = true;
            this.clRespPerson.Width = 110;
            // 
            // clDocDate
            // 
            this.clDocDate.DataPropertyName = "DocDate";
            this.clDocDate.HeaderText = "Date";
            this.clDocDate.Name = "clDocDate";
            this.clDocDate.ReadOnly = true;
            // 
            // clSalesCode
            // 
            this.clSalesCode.DataPropertyName = "SalesCode";
            this.clSalesCode.HeaderText = "Sales Code";
            this.clSalesCode.Name = "clSalesCode";
            this.clSalesCode.ReadOnly = true;
            this.clSalesCode.Visible = false;
            // 
            // clNotes
            // 
            this.clNotes.DataPropertyName = "Notes";
            this.clNotes.HeaderText = "Notes";
            this.clNotes.Name = "clNotes";
            this.clNotes.ReadOnly = true;
            this.clNotes.Visible = false;
            // 
            // btnFilterInclBatch
            // 
            this.btnFilterInclBatch.BackgroundImage = global::Liquid.Properties.Resources.search_manu;
            this.btnFilterInclBatch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnFilterInclBatch.FlatAppearance.BorderSize = 0;
            this.btnFilterInclBatch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilterInclBatch.Location = new System.Drawing.Point(303, 464);
            this.btnFilterInclBatch.Name = "btnFilterInclBatch";
            this.btnFilterInclBatch.Size = new System.Drawing.Size(25, 25);
            this.btnFilterInclBatch.TabIndex = 186;
            this.btnFilterInclBatch.UseVisualStyleBackColor = true;
            this.btnFilterInclBatch.Click += new System.EventHandler(this.btnFilterInclBatch_Click);
            // 
            // txtInclBatch
            // 
            this.txtInclBatch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInclBatch.Location = new System.Drawing.Point(209, 468);
            this.txtInclBatch.MaxLength = 0;
            this.txtInclBatch.Name = "txtInclBatch";
            this.txtInclBatch.Size = new System.Drawing.Size(88, 20);
            this.txtInclBatch.TabIndex = 185;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(128, 471);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 175;
            this.label3.Text = "Batch Number";
            // 
            // StockIssueZoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(342, 502);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnFilterInclBatch);
            this.Controls.Add(this.txtInclBatch);
            this.Controls.Add(this.dgvStockIssueDocs);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "StockIssueZoom";
            this.Text = "Stock Issue Finder";
            this.Load += new System.EventHandler(this.StockIssueZoom_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockIssueDocs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtDocNum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRespPerson;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvStockIssueDocs;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDocNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn clRespPerson;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDocDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clSalesCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clNotes;
        private System.Windows.Forms.Button btnFilterInclBatch;
        private System.Windows.Forms.TextBox txtInclBatch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Button cmdFilter;
    }
}