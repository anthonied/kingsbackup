namespace Liquid.Forms.MonthEndProcessing.View
{
    partial class InvoiceCompleteResultsView
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgResults = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ResultLabel = new System.Windows.Forms.Label();
            this.headerColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSalesorder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvoiceCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValueColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgResults)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgResults
            // 
            this.dgResults.AllowUserToAddRows = false;
            this.dgResults.AllowUserToDeleteRows = false;
            this.dgResults.AllowUserToResizeColumns = false;
            this.dgResults.AllowUserToResizeRows = false;
            this.dgResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.headerColumn,
            this.colSalesorder,
            this.InvoiceCol,
            this.ValueColumn});
            this.dgResults.Location = new System.Drawing.Point(12, 84);
            this.dgResults.Name = "dgResults";
            this.dgResults.ReadOnly = true;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgResults.RowHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dgResults.RowHeadersVisible = false;
            this.dgResults.Size = new System.Drawing.Size(474, 150);
            this.dgResults.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(2, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "Invoice Results For:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(474, 39);
            this.panel1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Azure;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.ResultLabel);
            this.panel2.Location = new System.Drawing.Point(344, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(142, 39);
            this.panel2.TabIndex = 3;
            // 
            // ResultLabel
            // 
            this.ResultLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResultLabel.Location = new System.Drawing.Point(3, 6);
            this.ResultLabel.Name = "ResultLabel";
            this.ResultLabel.Size = new System.Drawing.Size(134, 23);
            this.ResultLabel.TabIndex = 0;
            this.ResultLabel.Text = "...";
            this.ResultLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // headerColumn
            // 
            this.headerColumn.DataPropertyName = "Header";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.headerColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.headerColumn.HeaderText = "Header";
            this.headerColumn.Name = "headerColumn";
            this.headerColumn.ReadOnly = true;
            this.headerColumn.Width = 190;
            // 
            // colSalesorder
            // 
            this.colSalesorder.DataPropertyName = "SalesorderCount";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colSalesorder.DefaultCellStyle = dataGridViewCellStyle7;
            this.colSalesorder.HeaderText = "Salesorder";
            this.colSalesorder.Name = "colSalesorder";
            this.colSalesorder.ReadOnly = true;
            // 
            // InvoiceCol
            // 
            this.InvoiceCol.DataPropertyName = "InvoiceCount";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.InvoiceCol.DefaultCellStyle = dataGridViewCellStyle8;
            this.InvoiceCol.HeaderText = "Invoice";
            this.InvoiceCol.Name = "InvoiceCol";
            this.InvoiceCol.ReadOnly = true;
            // 
            // ValueColumn
            // 
            this.ValueColumn.DataPropertyName = "Value";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ValueColumn.DefaultCellStyle = dataGridViewCellStyle9;
            this.ValueColumn.HeaderText = "Value";
            this.ValueColumn.Name = "ValueColumn";
            this.ValueColumn.ReadOnly = true;
            this.ValueColumn.Width = 75;
            // 
            // InvoiceCompleteResultsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(498, 262);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgResults);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "InvoiceCompleteResultsView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Invoice Results";
            ((System.ComponentModel.ISupportInitialize)(this.dgResults)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgResults;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label ResultLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn headerColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSalesorder;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvoiceCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValueColumn;
    }
}