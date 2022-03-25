namespace Liquid.Finder
{
    partial class PickingSlipItemZoom
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
            this.cmdAddKit = new System.Windows.Forms.Button();
            this.gpFilters = new System.Windows.Forms.GroupBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblStoreValue = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.lblCode = new System.Windows.Forms.Label();
            this.dgInventory = new System.Windows.Forms.DataGridView();
            this.clCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDelNoteNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clKit = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gpFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgInventory)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdAddKit
            // 
            this.cmdAddKit.Location = new System.Drawing.Point(570, 31);
            this.cmdAddKit.Name = "cmdAddKit";
            this.cmdAddKit.Size = new System.Drawing.Size(86, 20);
            this.cmdAddKit.TabIndex = 51;
            this.cmdAddKit.Text = "Add Kit";
            this.cmdAddKit.UseVisualStyleBackColor = true;
            this.cmdAddKit.Click += new System.EventHandler(this.cmdAddKit_Click);
            // 
            // gpFilters
            // 
            this.gpFilters.Controls.Add(this.cmdAddKit);
            this.gpFilters.Controls.Add(this.txtDescription);
            this.gpFilters.Controls.Add(this.lblDescription);
            this.gpFilters.Controls.Add(this.lblStoreValue);
            this.gpFilters.Controls.Add(this.txtCode);
            this.gpFilters.Controls.Add(this.lblCode);
            this.gpFilters.Location = new System.Drawing.Point(12, 13);
            this.gpFilters.Name = "gpFilters";
            this.gpFilters.Size = new System.Drawing.Size(662, 74);
            this.gpFilters.TabIndex = 11;
            this.gpFilters.TabStop = false;
            this.gpFilters.Text = "Filter Results By";
            // 
            // txtDescription
            // 
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescription.Location = new System.Drawing.Point(298, 31);
            this.txtDescription.MaxLength = 40;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(208, 20);
            this.txtDescription.TabIndex = 2;
            this.txtDescription.TextChanged += new System.EventHandler(this.txtDescription_TextChanged);
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(222, 35);
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
            this.txtCode.Location = new System.Drawing.Point(48, 31);
            this.txtCode.MaxLength = 6;
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(145, 20);
            this.txtCode.TabIndex = 1;
            this.txtCode.TextChanged += new System.EventHandler(this.txtCode_TextChanged);
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Location = new System.Drawing.Point(9, 35);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(32, 13);
            this.lblCode.TabIndex = 0;
            this.lblCode.Text = "Code";
            // 
            // dgInventory
            // 
            this.dgInventory.AllowUserToAddRows = false;
            this.dgInventory.AllowUserToDeleteRows = false;
            this.dgInventory.AllowUserToResizeColumns = false;
            this.dgInventory.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.GhostWhite;
            this.dgInventory.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgInventory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clCode,
            this.clDescription,
            this.clDelNoteNumber,
            this.clKit,
            this.clUnit});
            this.dgInventory.Location = new System.Drawing.Point(12, 104);
            this.dgInventory.Name = "dgInventory";
            this.dgInventory.RowHeadersVisible = false;
            this.dgInventory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgInventory.Size = new System.Drawing.Size(662, 445);
            this.dgInventory.TabIndex = 10;
            this.dgInventory.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgInventory_CellContentClick);
            this.dgInventory.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgInventory_CellDoubleClick);
            this.dgInventory.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgInventory_KeyDown);
            // 
            // clCode
            // 
            this.clCode.DataPropertyName = "ItemCode";
            this.clCode.HeaderText = "Inventory Code";
            this.clCode.Name = "clCode";
            this.clCode.Width = 150;
            // 
            // clDescription
            // 
            this.clDescription.DataPropertyName = "Description";
            this.clDescription.HeaderText = "Description";
            this.clDescription.Name = "clDescription";
            this.clDescription.Width = 325;
            // 
            // clDelNoteNumber
            // 
            this.clDelNoteNumber.DataPropertyName = "DocNumber";
            this.clDelNoteNumber.HeaderText = "Del. Note No";
            this.clDelNoteNumber.Name = "clDelNoteNumber";
            // 
            // clKit
            // 
            this.clKit.DataPropertyName = "clKit";
            this.clKit.FalseValue = "0";
            this.clKit.HeaderText = "Kit";
            this.clKit.IndeterminateValue = "0";
            this.clKit.Name = "clKit";
            this.clKit.TrueValue = "1";
            this.clKit.Width = 75;
            // 
            // clUnit
            // 
            this.clUnit.DataPropertyName = "Unit";
            this.clUnit.HeaderText = "Unit";
            this.clUnit.Name = "clUnit";
            this.clUnit.Visible = false;
            // 
            // PickingSlipItemZoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 578);
            this.Controls.Add(this.gpFilters);
            this.Controls.Add(this.dgInventory);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "PickingSlipItemZoom";
            this.Text = "Picking Slip Item Zoom";
            this.Load += new System.EventHandler(this.PickingSlipItemZoom_Load);
            this.gpFilters.ResumeLayout(false);
            this.gpFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgInventory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdAddKit;
        private System.Windows.Forms.GroupBox gpFilters;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblStoreValue;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.DataGridView dgInventory;
        private System.Windows.Forms.DataGridViewTextBoxColumn clCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDelNoteNumber;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clKit;
        private System.Windows.Forms.DataGridViewTextBoxColumn clUnit;
    }
}