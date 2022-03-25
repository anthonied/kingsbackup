namespace Liquid.Finder
{
    partial class BatchZoom
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtItemDesc = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSupplier = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBatchNum = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtItemCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvBatches = new System.Windows.Forms.DataGridView();
            this.clBatchNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clItemCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clItemDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clSupplier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDocNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clQtyOnHand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clItemUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBatches)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtItemDesc);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtSupplier);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtBatchNum);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtItemCode);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(17, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(635, 51);
            this.groupBox1.TabIndex = 177;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter";
            // 
            // txtItemDesc
            // 
            this.txtItemDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtItemDesc.Location = new System.Drawing.Point(537, 19);
            this.txtItemDesc.MaxLength = 6;
            this.txtItemDesc.Name = "txtItemDesc";
            this.txtItemDesc.Size = new System.Drawing.Size(80, 20);
            this.txtItemDesc.TabIndex = 178;
            this.txtItemDesc.TextChanged += new System.EventHandler(this.txtItemDesc_TextChanged);
            this.txtItemDesc.Enter += new System.EventHandler(this.txtItemDesc_Enter);
            this.txtItemDesc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtItemDesc_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(466, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 177;
            this.label4.Text = "Description";
            // 
            // txtSupplier
            // 
            this.txtSupplier.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSupplier.Location = new System.Drawing.Point(373, 19);
            this.txtSupplier.MaxLength = 6;
            this.txtSupplier.Name = "txtSupplier";
            this.txtSupplier.Size = new System.Drawing.Size(80, 20);
            this.txtSupplier.TabIndex = 176;
            this.txtSupplier.TextChanged += new System.EventHandler(this.txtSupplier_TextChanged);
            this.txtSupplier.Enter += new System.EventHandler(this.txtSupplier_Enter);
            this.txtSupplier.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSupplier_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(312, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 175;
            this.label3.Text = "Supplier";
            // 
            // txtBatchNum
            // 
            this.txtBatchNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBatchNum.Location = new System.Drawing.Point(56, 19);
            this.txtBatchNum.MaxLength = 8;
            this.txtBatchNum.Name = "txtBatchNum";
            this.txtBatchNum.Size = new System.Drawing.Size(80, 20);
            this.txtBatchNum.TabIndex = 171;
            this.txtBatchNum.TextChanged += new System.EventHandler(this.txtBatchNum_TextChanged);
            this.txtBatchNum.Enter += new System.EventHandler(this.txtBatchNum_Enter);
            this.txtBatchNum.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBatchNum_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 170;
            this.label1.Text = "Batch #";
            // 
            // txtItemCode
            // 
            this.txtItemCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtItemCode.Location = new System.Drawing.Point(216, 19);
            this.txtItemCode.MaxLength = 8;
            this.txtItemCode.Name = "txtItemCode";
            this.txtItemCode.Size = new System.Drawing.Size(80, 20);
            this.txtItemCode.TabIndex = 174;
            this.txtItemCode.TextChanged += new System.EventHandler(this.txtItemCode_TextChanged);
            this.txtItemCode.Enter += new System.EventHandler(this.txtItemCode_Enter);
            this.txtItemCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtItemCode_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(155, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 173;
            this.label2.Text = "Item Code";
            // 
            // dgvBatches
            // 
            this.dgvBatches.AllowUserToAddRows = false;
            this.dgvBatches.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Gainsboro;
            this.dgvBatches.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvBatches.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBatches.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clBatchNum,
            this.clItemCode,
            this.clItemDesc,
            this.clSupplier,
            this.clDocNumber,
            this.clQtyOnHand,
            this.clItemUnit});
            this.dgvBatches.Location = new System.Drawing.Point(12, 69);
            this.dgvBatches.Name = "dgvBatches";
            this.dgvBatches.ReadOnly = true;
            this.dgvBatches.RowHeadersVisible = false;
            this.dgvBatches.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvBatches.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBatches.Size = new System.Drawing.Size(644, 422);
            this.dgvBatches.TabIndex = 178;
            this.dgvBatches.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBatches_CellDoubleClick);
            this.dgvBatches.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvBatches_KeyDown);
            this.dgvBatches.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgvBatches_KeyPress);
            // 
            // clBatchNum
            // 
            this.clBatchNum.DataPropertyName = "BatchNumber";
            this.clBatchNum.HeaderText = "Batch #";
            this.clBatchNum.Name = "clBatchNum";
            this.clBatchNum.ReadOnly = true;
            this.clBatchNum.Width = 110;
            // 
            // clItemCode
            // 
            this.clItemCode.DataPropertyName = "ItemCode";
            this.clItemCode.HeaderText = "Item Code";
            this.clItemCode.Name = "clItemCode";
            this.clItemCode.ReadOnly = true;
            this.clItemCode.Width = 90;
            // 
            // clItemDesc
            // 
            this.clItemDesc.DataPropertyName = "Description";
            this.clItemDesc.HeaderText = "Description";
            this.clItemDesc.Name = "clItemDesc";
            this.clItemDesc.ReadOnly = true;
            this.clItemDesc.Width = 120;
            // 
            // clSupplier
            // 
            this.clSupplier.DataPropertyName = "Supplier";
            this.clSupplier.HeaderText = "Supplier";
            this.clSupplier.Name = "clSupplier";
            this.clSupplier.ReadOnly = true;
            this.clSupplier.Width = 130;
            // 
            // clDocNumber
            // 
            this.clDocNumber.DataPropertyName = "DocumentNumber";
            this.clDocNumber.HeaderText = "Doc Num";
            this.clDocNumber.Name = "clDocNumber";
            this.clDocNumber.ReadOnly = true;
            this.clDocNumber.Width = 80;
            // 
            // clQtyOnHand
            // 
            this.clQtyOnHand.DataPropertyName = "QtyOnHand";
            this.clQtyOnHand.HeaderText = "Qty on Hand";
            this.clQtyOnHand.Name = "clQtyOnHand";
            this.clQtyOnHand.ReadOnly = true;
            this.clQtyOnHand.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clQtyOnHand.Width = 90;
            // 
            // clItemUnit
            // 
            this.clItemUnit.DataPropertyName = "UnitSize";
            this.clItemUnit.HeaderText = "Unit";
            this.clItemUnit.Name = "clItemUnit";
            this.clItemUnit.ReadOnly = true;
            this.clItemUnit.Visible = false;
            // 
            // BatchZoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 503);
            this.Controls.Add(this.dgvBatches);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "BatchZoom";
            this.Text = "Batch Finder";
            this.Load += new System.EventHandler(this.BatchZoom_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBatches)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtBatchNum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtItemCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvBatches;
        private System.Windows.Forms.TextBox txtSupplier;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtItemDesc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn clBatchNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn clItemCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clItemDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn clSupplier;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDocNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn clQtyOnHand;
        private System.Windows.Forms.DataGridViewTextBoxColumn clItemUnit;
    }
}