namespace Liquid.Finder
{
    partial class IssueInventoryZoom
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
            this.dgIssueInventory = new System.Windows.Forms.DataGridView();
            this.clDocumentNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clAssetNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clReference = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbFilter = new System.Windows.Forms.GroupBox();
            this.cmdFilter = new System.Windows.Forms.Button();
            this.txtAssetNumber = new System.Windows.Forms.TextBox();
            this.lblAssetNumber = new System.Windows.Forms.Label();
            this.txtReference = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDocNumber = new System.Windows.Forms.TextBox();
            this.lblDocNum = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgIssueInventory)).BeginInit();
            this.gbFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgIssueInventory
            // 
            this.dgIssueInventory.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgIssueInventory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgIssueInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgIssueInventory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clDocumentNumber,
            this.clAssetNumber,
            this.clReference});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgIssueInventory.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgIssueInventory.Location = new System.Drawing.Point(14, 109);
            this.dgIssueInventory.Name = "dgIssueInventory";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgIssueInventory.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgIssueInventory.RowHeadersVisible = false;
            this.dgIssueInventory.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgIssueInventory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgIssueInventory.Size = new System.Drawing.Size(419, 325);
            this.dgIssueInventory.TabIndex = 0;
            this.dgIssueInventory.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgIssueInventory_CellDoubleClick);
            this.dgIssueInventory.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgIssueInventory_KeyDown);
            this.dgIssueInventory.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgIssueInventory_KeyPress);
            // 
            // clDocumentNumber
            // 
            this.clDocumentNumber.DataPropertyName = "DocNumber";
            this.clDocumentNumber.HeaderText = "Document";
            this.clDocumentNumber.Name = "clDocumentNumber";
            this.clDocumentNumber.ReadOnly = true;
            // 
            // clAssetNumber
            // 
            this.clAssetNumber.DataPropertyName = "AssetNumber";
            this.clAssetNumber.HeaderText = "Asset";
            this.clAssetNumber.Name = "clAssetNumber";
            this.clAssetNumber.ReadOnly = true;
            // 
            // clReference
            // 
            this.clReference.DataPropertyName = "Reference";
            this.clReference.HeaderText = "Reference";
            this.clReference.Name = "clReference";
            this.clReference.ReadOnly = true;
            this.clReference.Width = 215;
            // 
            // gbFilter
            // 
            this.gbFilter.Controls.Add(this.cmdFilter);
            this.gbFilter.Controls.Add(this.txtAssetNumber);
            this.gbFilter.Controls.Add(this.lblAssetNumber);
            this.gbFilter.Controls.Add(this.txtReference);
            this.gbFilter.Controls.Add(this.label1);
            this.gbFilter.Controls.Add(this.txtDocNumber);
            this.gbFilter.Controls.Add(this.lblDocNum);
            this.gbFilter.Location = new System.Drawing.Point(14, 12);
            this.gbFilter.Name = "gbFilter";
            this.gbFilter.Size = new System.Drawing.Size(419, 91);
            this.gbFilter.TabIndex = 1;
            this.gbFilter.TabStop = false;
            this.gbFilter.Text = "Filter By";
            // 
            // cmdFilter
            // 
            this.cmdFilter.Location = new System.Drawing.Point(356, 62);
            this.cmdFilter.Name = "cmdFilter";
            this.cmdFilter.Size = new System.Drawing.Size(51, 23);
            this.cmdFilter.TabIndex = 4;
            this.cmdFilter.Text = "Filter";
            this.cmdFilter.UseVisualStyleBackColor = true;
            this.cmdFilter.Click += new System.EventHandler(this.cmdFilter_Click);
            this.cmdFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmdFilter_KeyDown);
            // 
            // txtAssetNumber
            // 
            this.txtAssetNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAssetNumber.Location = new System.Drawing.Point(117, 51);
            this.txtAssetNumber.Name = "txtAssetNumber";
            this.txtAssetNumber.Size = new System.Drawing.Size(100, 20);
            this.txtAssetNumber.TabIndex = 2;
            this.txtAssetNumber.TextChanged += new System.EventHandler(this.txtAssetNumber_TextChanged);
            this.txtAssetNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAssetNumber_KeyDown);
            this.txtAssetNumber.Enter += new System.EventHandler(this.txtDocNumber_Enter);
            // 
            // lblAssetNumber
            // 
            this.lblAssetNumber.AutoSize = true;
            this.lblAssetNumber.Location = new System.Drawing.Point(15, 54);
            this.lblAssetNumber.Name = "lblAssetNumber";
            this.lblAssetNumber.Size = new System.Drawing.Size(73, 13);
            this.lblAssetNumber.TabIndex = 4;
            this.lblAssetNumber.Text = "Asset Number";
            // 
            // txtReference
            // 
            this.txtReference.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtReference.Location = new System.Drawing.Point(307, 25);
            this.txtReference.Name = "txtReference";
            this.txtReference.Size = new System.Drawing.Size(100, 20);
            this.txtReference.TabIndex = 3;
            this.txtReference.TextChanged += new System.EventHandler(this.txtReference_TextChanged);
            this.txtReference.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtReference_KeyDown);
            this.txtReference.Enter += new System.EventHandler(this.txtDocNumber_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(231, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Reference";
            // 
            // txtDocNumber
            // 
            this.txtDocNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDocNumber.Location = new System.Drawing.Point(117, 26);
            this.txtDocNumber.Name = "txtDocNumber";
            this.txtDocNumber.Size = new System.Drawing.Size(100, 20);
            this.txtDocNumber.TabIndex = 1;
            this.txtDocNumber.TextChanged += new System.EventHandler(this.txtDocNumber_TextChanged);
            this.txtDocNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDocNumber_KeyDown);
            this.txtDocNumber.Enter += new System.EventHandler(this.txtDocNumber_Enter);
            // 
            // lblDocNum
            // 
            this.lblDocNum.AutoSize = true;
            this.lblDocNum.Location = new System.Drawing.Point(15, 29);
            this.lblDocNum.Name = "lblDocNum";
            this.lblDocNum.Size = new System.Drawing.Size(96, 13);
            this.lblDocNum.TabIndex = 0;
            this.lblDocNum.Text = "Document Number";
            // 
            // IssueInventoryZoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 449);
            this.Controls.Add(this.gbFilter);
            this.Controls.Add(this.dgIssueInventory);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "IssueInventoryZoom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Issue Inventory Zoom";
            this.Load += new System.EventHandler(this.IssueInventoryZoom_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgIssueInventory)).EndInit();
            this.gbFilter.ResumeLayout(false);
            this.gbFilter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgIssueInventory;
        private System.Windows.Forms.GroupBox gbFilter;
        private System.Windows.Forms.TextBox txtAssetNumber;
        private System.Windows.Forms.Label lblAssetNumber;
        private System.Windows.Forms.TextBox txtReference;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDocNumber;
        private System.Windows.Forms.Label lblDocNum;
        private System.Windows.Forms.Button cmdFilter;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDocumentNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn clAssetNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn clReference;
    }
}