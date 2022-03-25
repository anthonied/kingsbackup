namespace Liquid.Forms
{
    partial class InsuranceExceptions
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
            this.dgInsurance = new System.Windows.Forms.DataGridView();
            this.clDocumentNumber = new System.Windows.Forms.DataGridViewLinkColumn();
            this.clCustomerCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgInsurance)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgInsurance
            // 
            this.dgInsurance.AllowUserToAddRows = false;
            this.dgInsurance.AllowUserToDeleteRows = false;
            this.dgInsurance.AllowUserToResizeColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgInsurance.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgInsurance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgInsurance.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clDocumentNumber,
            this.clCustomerCode});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgInsurance.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgInsurance.Location = new System.Drawing.Point(6, 19);
            this.dgInsurance.Name = "dgInsurance";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgInsurance.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgInsurance.RowHeadersVisible = false;
            this.dgInsurance.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgInsurance.Size = new System.Drawing.Size(215, 200);
            this.dgInsurance.TabIndex = 165;
            this.dgInsurance.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgInsurance_CellContentClick);
            // 
            // clDocumentNumber
            // 
            this.clDocumentNumber.HeaderText = "Document Number";
            this.clDocumentNumber.Name = "clDocumentNumber";
            this.clDocumentNumber.Width = 110;
            // 
            // clCustomerCode
            // 
            this.clCustomerCode.HeaderText = "Customer Code";
            this.clCustomerCode.Name = "clCustomerCode";
            this.clCustomerCode.ReadOnly = true;
            this.clCustomerCode.Width = 102;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgInsurance);
            this.groupBox1.Location = new System.Drawing.Point(3, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(228, 225);
            this.groupBox1.TabIndex = 169;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Zero Insurance Line Items";
            // 
            // InsuranceExceptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(237, 241);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "InsuranceExceptions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sales Order Exceptions";
            this.Load += new System.EventHandler(this.InsuranceExceptions_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgInsurance)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgInsurance;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridViewLinkColumn clDocumentNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn clCustomerCode;
    }
}