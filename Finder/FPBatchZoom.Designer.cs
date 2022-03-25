namespace Liquid.Finder
{
    partial class FPBatchZoom
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtItemDesc = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBatchNum = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtItemCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvFPBatches = new System.Windows.Forms.DataGridView();
            this.clBatchNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clItemCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clItemDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clQtyOnHand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFPBatches)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtItemDesc);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtBatchNum);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtItemCode);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(8, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(494, 51);
            this.groupBox1.TabIndex = 182;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter";
            // 
            // txtItemDesc
            // 
            this.txtItemDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtItemDesc.Location = new System.Drawing.Point(335, 19);
            this.txtItemDesc.MaxLength = 6;
            this.txtItemDesc.Name = "txtItemDesc";
            this.txtItemDesc.Size = new System.Drawing.Size(70, 20);
            this.txtItemDesc.TabIndex = 178;
            this.txtItemDesc.TextChanged += new System.EventHandler(this.txtItemDesc_TextChanged);
            this.txtItemDesc.Enter += new System.EventHandler(this.txtItemDesc_Enter);
            this.txtItemDesc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBatchNum_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(269, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 177;
            this.label4.Text = "Description";
            // 
            // txtBatchNum
            // 
            this.txtBatchNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBatchNum.Location = new System.Drawing.Point(56, 19);
            this.txtBatchNum.MaxLength = 8;
            this.txtBatchNum.Name = "txtBatchNum";
            this.txtBatchNum.Size = new System.Drawing.Size(70, 20);
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
            this.txtItemCode.Location = new System.Drawing.Point(193, 19);
            this.txtItemCode.MaxLength = 8;
            this.txtItemCode.Name = "txtItemCode";
            this.txtItemCode.Size = new System.Drawing.Size(70, 20);
            this.txtItemCode.TabIndex = 174;
            this.txtItemCode.TextChanged += new System.EventHandler(this.txtItemCode_TextChanged);
            this.txtItemCode.Enter += new System.EventHandler(this.txtItemCode_Enter);
            this.txtItemCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBatchNum_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(132, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 173;
            this.label2.Text = "Item Code";
            // 
            // dgvFPBatches
            // 
            this.dgvFPBatches.AllowUserToAddRows = false;
            this.dgvFPBatches.AllowUserToDeleteRows = false;
            this.dgvFPBatches.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFPBatches.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clBatchNum,
            this.clItemCode,
            this.clItemDesc,
            this.clQtyOnHand,
            this.clUnit});
            this.dgvFPBatches.Location = new System.Drawing.Point(8, 66);
            this.dgvFPBatches.MultiSelect = false;
            this.dgvFPBatches.Name = "dgvFPBatches";
            this.dgvFPBatches.ReadOnly = true;
            this.dgvFPBatches.RowHeadersVisible = false;
            this.dgvFPBatches.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvFPBatches.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFPBatches.Size = new System.Drawing.Size(494, 379);
            this.dgvFPBatches.TabIndex = 181;
            this.dgvFPBatches.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFPBatches_CellDoubleClick);
            this.dgvFPBatches.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvFPBatches_KeyDown);
            this.dgvFPBatches.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgvFPBatches_KeyPress);
            // 
            // clBatchNum
            // 
            this.clBatchNum.DataPropertyName = "BatchNumber";
            this.clBatchNum.HeaderText = "Batch #";
            this.clBatchNum.Name = "clBatchNum";
            this.clBatchNum.ReadOnly = true;
            // 
            // clItemCode
            // 
            this.clItemCode.DataPropertyName = "ItemCode";
            this.clItemCode.HeaderText = "Item Code";
            this.clItemCode.Name = "clItemCode";
            this.clItemCode.ReadOnly = true;
            this.clItemCode.Width = 85;
            // 
            // clItemDesc
            // 
            this.clItemDesc.DataPropertyName = "PDescription";
            this.clItemDesc.HeaderText = "Description";
            this.clItemDesc.Name = "clItemDesc";
            this.clItemDesc.ReadOnly = true;
            this.clItemDesc.Width = 190;
            // 
            // clQtyOnHand
            // 
            this.clQtyOnHand.DataPropertyName = "QtyOnHand";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomRight;
            this.clQtyOnHand.DefaultCellStyle = dataGridViewCellStyle1;
            this.clQtyOnHand.HeaderText = "Qty Avail";
            this.clQtyOnHand.Name = "clQtyOnHand";
            this.clQtyOnHand.ReadOnly = true;
            this.clQtyOnHand.Width = 95;
            // 
            // clUnit
            // 
            this.clUnit.DataPropertyName = "PUnit";
            this.clUnit.HeaderText = "Unit";
            this.clUnit.Name = "clUnit";
            this.clUnit.ReadOnly = true;
            this.clUnit.Visible = false;
            // 
            // FPBatchZoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 457);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvFPBatches);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FPBatchZoom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Final Product Batch Finder";
            this.Load += new System.EventHandler(this.FPBatchZoom_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFPBatches)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtItemDesc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBatchNum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtItemCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvFPBatches;
        private System.Windows.Forms.DataGridViewTextBoxColumn clBatchNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn clItemCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clItemDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn clQtyOnHand;
        private System.Windows.Forms.DataGridViewTextBoxColumn clUnit;
    }
}