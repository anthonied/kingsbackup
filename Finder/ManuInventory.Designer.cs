namespace Liquid.Finder
{
    partial class ManuInventory
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
            this.dgvInventory = new System.Windows.Forms.DataGridView();
            this.clItemCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clUnitSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gpFilters = new System.Windows.Forms.GroupBox();
            this.txtCategory = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblStoreValue = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.lblCode = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).BeginInit();
            this.gpFilters.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvInventory
            // 
            this.dgvInventory.AllowUserToAddRows = false;
            this.dgvInventory.AllowUserToDeleteRows = false;
            this.dgvInventory.AllowUserToResizeColumns = false;
            this.dgvInventory.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            this.dgvInventory.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInventory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clItemCode,
            this.clDescription,
            this.clCategory,
            this.clUnitSize});
            this.dgvInventory.Location = new System.Drawing.Point(13, 84);
            this.dgvInventory.Name = "dgvInventory";
            this.dgvInventory.ReadOnly = true;
            this.dgvInventory.RowHeadersVisible = false;
            this.dgvInventory.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvInventory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInventory.Size = new System.Drawing.Size(545, 333);
            this.dgvInventory.TabIndex = 7;
            this.dgvInventory.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInventory_CellDoubleClick);
            this.dgvInventory.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvInventory_KeyDown);
            this.dgvInventory.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgvInventory_KeyPress);
            // 
            // clItemCode
            // 
            this.clItemCode.DataPropertyName = "ItemCode";
            this.clItemCode.HeaderText = "Item Code";
            this.clItemCode.Name = "clItemCode";
            this.clItemCode.ReadOnly = true;
            this.clItemCode.Width = 125;
            // 
            // clDescription
            // 
            this.clDescription.DataPropertyName = "Description";
            this.clDescription.HeaderText = "Description";
            this.clDescription.Name = "clDescription";
            this.clDescription.ReadOnly = true;
            this.clDescription.Width = 225;
            // 
            // clCategory
            // 
            this.clCategory.DataPropertyName = "ICDesc";
            this.clCategory.HeaderText = "Category";
            this.clCategory.Name = "clCategory";
            this.clCategory.ReadOnly = true;
            this.clCategory.Width = 125;
            // 
            // clUnitSize
            // 
            this.clUnitSize.DataPropertyName = "UnitSize";
            this.clUnitSize.HeaderText = "Units";
            this.clUnitSize.Name = "clUnitSize";
            this.clUnitSize.ReadOnly = true;
            this.clUnitSize.Width = 65;
            // 
            // gpFilters
            // 
            this.gpFilters.Controls.Add(this.txtCategory);
            this.gpFilters.Controls.Add(this.label1);
            this.gpFilters.Controls.Add(this.txtDescription);
            this.gpFilters.Controls.Add(this.lblDescription);
            this.gpFilters.Controls.Add(this.lblStoreValue);
            this.gpFilters.Controls.Add(this.txtCode);
            this.gpFilters.Controls.Add(this.lblCode);
            this.gpFilters.Location = new System.Drawing.Point(13, 15);
            this.gpFilters.Name = "gpFilters";
            this.gpFilters.Size = new System.Drawing.Size(545, 56);
            this.gpFilters.TabIndex = 8;
            this.gpFilters.TabStop = false;
            this.gpFilters.Text = "Filter Results By";
            // 
            // txtCategory
            // 
            this.txtCategory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCategory.Location = new System.Drawing.Point(414, 25);
            this.txtCategory.MaxLength = 40;
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.Size = new System.Drawing.Size(100, 20);
            this.txtCategory.TabIndex = 51;
            this.txtCategory.TextChanged += new System.EventHandler(this.txtCategory_TextChanged);
            this.txtCategory.Enter += new System.EventHandler(this.txtCategory_Enter);
            this.txtCategory.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCategory_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(359, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 50;
            this.label1.Text = "Category";
            // 
            // txtDescription
            // 
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescription.Location = new System.Drawing.Point(238, 25);
            this.txtDescription.MaxLength = 40;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(100, 20);
            this.txtDescription.TabIndex = 2;
            this.txtDescription.TextChanged += new System.EventHandler(this.txtDescription_TextChanged);
            this.txtDescription.Enter += new System.EventHandler(this.txtDescription_Enter);
            this.txtDescription.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDescription_KeyDown);
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(172, 27);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(60, 13);
            this.lblDescription.TabIndex = 0;
            this.lblDescription.Text = "Description";
            // 
            // lblStoreValue
            // 
            this.lblStoreValue.AutoSize = true;
            this.lblStoreValue.Location = new System.Drawing.Point(111, 50);
            this.lblStoreValue.Name = "lblStoreValue";
            this.lblStoreValue.Size = new System.Drawing.Size(0, 13);
            this.lblStoreValue.TabIndex = 49;
            // 
            // txtCode
            // 
            this.txtCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCode.Location = new System.Drawing.Point(48, 25);
            this.txtCode.MaxLength = 6;
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(100, 20);
            this.txtCode.TabIndex = 1;
            this.txtCode.TextChanged += new System.EventHandler(this.txtCode_TextChanged);
            this.txtCode.Enter += new System.EventHandler(this.txtCode_Enter);
            this.txtCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCode_KeyDown);
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Location = new System.Drawing.Point(10, 27);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(32, 13);
            this.lblCode.TabIndex = 0;
            this.lblCode.Text = "Code";
            // 
            // ManuInventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 430);
            this.Controls.Add(this.gpFilters);
            this.Controls.Add(this.dgvInventory);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ManuInventory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inventory Finder";
            this.Load += new System.EventHandler(this.ManuInventory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).EndInit();
            this.gpFilters.ResumeLayout(false);
            this.gpFilters.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvInventory;
        private System.Windows.Forms.GroupBox gpFilters;
        private System.Windows.Forms.TextBox txtCategory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblStoreValue;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clItemCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn clCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn clUnitSize;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}