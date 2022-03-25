namespace Liquid.Forms.Qoutes
{
    partial class ItemCodeQoutes
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
            this.dgQoutes = new System.Windows.Forms.DataGridView();
            this.clDocNumber = new System.Windows.Forms.DataGridViewLinkColumn();
            this.clCustomerCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDocDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtQoute = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgQoutes)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgQoutes
            // 
            this.dgQoutes.AllowUserToAddRows = false;
            this.dgQoutes.AllowUserToDeleteRows = false;
            this.dgQoutes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgQoutes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clDocNumber,
            this.clCustomerCode,
            this.clDocDate});
            this.dgQoutes.Location = new System.Drawing.Point(12, 104);
            this.dgQoutes.Name = "dgQoutes";
            this.dgQoutes.ReadOnly = true;
            this.dgQoutes.RowHeadersVisible = false;
            this.dgQoutes.Size = new System.Drawing.Size(415, 271);
            this.dgQoutes.TabIndex = 0;
            this.dgQoutes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgQoutes_CellContentClick);
            // 
            // clDocNumber
            // 
            this.clDocNumber.HeaderText = "Qoute Number";
            this.clDocNumber.Name = "clDocNumber";
            this.clDocNumber.ReadOnly = true;
            this.clDocNumber.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clDocNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.clDocNumber.Width = 150;
            // 
            // clCustomerCode
            // 
            this.clCustomerCode.HeaderText = "Customer Code";
            this.clCustomerCode.Name = "clCustomerCode";
            this.clCustomerCode.ReadOnly = true;
            this.clCustomerCode.Width = 110;
            // 
            // clDocDate
            // 
            this.clDocDate.HeaderText = "Doc Date";
            this.clDocDate.Name = "clDocDate";
            this.clDocDate.ReadOnly = true;
            this.clDocDate.Width = 150;
            // 
            // txtQoute
            // 
            this.txtQoute.Location = new System.Drawing.Point(59, 27);
            this.txtQoute.Name = "txtQoute";
            this.txtQoute.Size = new System.Drawing.Size(117, 20);
            this.txtQoute.TabIndex = 1;
            this.txtQoute.TextChanged += new System.EventHandler(this.txtQoute_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Quote";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtQoute);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(415, 73);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter Results";
            // 
            // ItemCodeQoutes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 401);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgQoutes);
            this.Name = "ItemCodeQoutes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quote Zoom";
            this.Load += new System.EventHandler(this.ItemCodeQoutes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgQoutes)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgQoutes;
        private System.Windows.Forms.TextBox txtQoute;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridViewLinkColumn clDocNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn clCustomerCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDocDate;
    }
}