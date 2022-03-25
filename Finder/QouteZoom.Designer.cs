namespace Liquid.Finder
{
    partial class QouteZoom
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
            this.gpFilters = new System.Windows.Forms.GroupBox();
            this.txtCustomerCode = new System.Windows.Forms.TextBox();
            this.lblCustCode = new System.Windows.Forms.Label();
            this.txtQouteNumber = new System.Windows.Forms.TextBox();
            this.lblSalesNumber = new System.Windows.Forms.Label();
            this.dgQouteZoom = new System.Windows.Forms.DataGridView();
            this.clDocNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clCustCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gpFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgQouteZoom)).BeginInit();
            this.SuspendLayout();
            // 
            // gpFilters
            // 
            this.gpFilters.Controls.Add(this.txtCustomerCode);
            this.gpFilters.Controls.Add(this.lblCustCode);
            this.gpFilters.Controls.Add(this.txtQouteNumber);
            this.gpFilters.Controls.Add(this.lblSalesNumber);
            this.gpFilters.Location = new System.Drawing.Point(11, 11);
            this.gpFilters.Name = "gpFilters";
            this.gpFilters.Size = new System.Drawing.Size(415, 60);
            this.gpFilters.TabIndex = 8;
            this.gpFilters.TabStop = false;
            this.gpFilters.Text = "Filter Results By";
            // 
            // txtCustomerCode
            // 
            this.txtCustomerCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustomerCode.Location = new System.Drawing.Point(304, 22);
            this.txtCustomerCode.MaxLength = 8;
            this.txtCustomerCode.Name = "txtCustomerCode";
            this.txtCustomerCode.Size = new System.Drawing.Size(100, 20);
            this.txtCustomerCode.TabIndex = 2;
            this.txtCustomerCode.TextChanged += new System.EventHandler(this.txtCustomerCode_TextChanged);
            // 
            // lblCustCode
            // 
            this.lblCustCode.AutoSize = true;
            this.lblCustCode.Location = new System.Drawing.Point(203, 28);
            this.lblCustCode.Name = "lblCustCode";
            this.lblCustCode.Size = new System.Drawing.Size(79, 13);
            this.lblCustCode.TabIndex = 0;
            this.lblCustCode.Text = "Customer Code";
            // 
            // txtQouteNumber
            // 
            this.txtQouteNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtQouteNumber.Location = new System.Drawing.Point(62, 22);
            this.txtQouteNumber.MaxLength = 8;
            this.txtQouteNumber.Name = "txtQouteNumber";
            this.txtQouteNumber.Size = new System.Drawing.Size(100, 20);
            this.txtQouteNumber.TabIndex = 1;
            this.txtQouteNumber.TextChanged += new System.EventHandler(this.txtQouteNumber_TextChanged);
            this.txtQouteNumber.Enter += new System.EventHandler(this.txtQouteNumber_Enter);
            this.txtQouteNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQouteNumber_KeyDown);
            
            // 
            // lblSalesNumber
            // 
            this.lblSalesNumber.AutoSize = true;
            this.lblSalesNumber.Location = new System.Drawing.Point(20, 28);
            this.lblSalesNumber.Name = "lblSalesNumber";
            this.lblSalesNumber.Size = new System.Drawing.Size(36, 13);
            this.lblSalesNumber.TabIndex = 0;
            this.lblSalesNumber.Text = "Quote";
            // 
            // dgQouteZoom
            // 
            this.dgQouteZoom.AllowUserToAddRows = false;
            this.dgQouteZoom.AllowUserToDeleteRows = false;
            this.dgQouteZoom.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgQouteZoom.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clDocNumber,
            this.clCustCode,
            this.clDate});
            this.dgQouteZoom.Location = new System.Drawing.Point(12, 82);
            this.dgQouteZoom.Name = "dgQouteZoom";
            this.dgQouteZoom.ReadOnly = true;
            this.dgQouteZoom.RowHeadersVisible = false;
            this.dgQouteZoom.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgQouteZoom.Size = new System.Drawing.Size(414, 440);
            this.dgQouteZoom.TabIndex = 9;
            this.dgQouteZoom.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgQouteZoom_CellDoubleClick);
            this.dgQouteZoom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgQouteZoom_KeyDown);
            this.dgQouteZoom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgQouteZoom_KeyPress);
            // 
            // clDocNumber
            // 
            this.clDocNumber.HeaderText = "Document Number";
            this.clDocNumber.Name = "clDocNumber";
            this.clDocNumber.ReadOnly = true;
            this.clDocNumber.Width = 125;
            // 
            // clCustCode
            // 
            this.clCustCode.HeaderText = "Customer Code";
            this.clCustCode.Name = "clCustCode";
            this.clCustCode.ReadOnly = true;
            this.clCustCode.Width = 150;
            // 
            // clDate
            // 
            this.clDate.HeaderText = "Date";
            this.clDate.Name = "clDate";
            this.clDate.ReadOnly = true;
            // 
            // QouteZoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 555);
            this.Controls.Add(this.dgQouteZoom);
            this.Controls.Add(this.gpFilters);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "QouteZoom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quote Zoom";
            this.Load += new System.EventHandler(this.QouteZoom_Load);
            this.gpFilters.ResumeLayout(false);
            this.gpFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgQouteZoom)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpFilters;
        private System.Windows.Forms.TextBox txtCustomerCode;
        private System.Windows.Forms.Label lblCustCode;
        private System.Windows.Forms.TextBox txtQouteNumber;
        private System.Windows.Forms.Label lblSalesNumber;
        private System.Windows.Forms.DataGridView dgQouteZoom;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDocNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn clCustCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDate;
    }
}