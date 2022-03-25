namespace Liquid.Finder
{
    partial class JobCodeZoom
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
            this.dgvJobCodes = new System.Windows.Forms.DataGridView();
            this.cJobCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gpFilters = new System.Windows.Forms.GroupBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblStoreValue = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.lblCode = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJobCodes)).BeginInit();
            this.gpFilters.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvJobCodes
            // 
            this.dgvJobCodes.AllowUserToAddRows = false;
            this.dgvJobCodes.AllowUserToDeleteRows = false;
            this.dgvJobCodes.AllowUserToResizeColumns = false;
            this.dgvJobCodes.AllowUserToResizeRows = false;
            this.dgvJobCodes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvJobCodes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cJobCode,
            this.cDescription});
            this.dgvJobCodes.Location = new System.Drawing.Point(12, 104);
            this.dgvJobCodes.Name = "dgvJobCodes";
            this.dgvJobCodes.ReadOnly = true;
            this.dgvJobCodes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvJobCodes.Size = new System.Drawing.Size(500, 334);
            this.dgvJobCodes.TabIndex = 0;
            this.dgvJobCodes.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvJobCodes_CellDoubleClick);
            this.dgvJobCodes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvJobCodes_KeyDown);
            // 
            // cJobCode
            // 
            this.cJobCode.DataPropertyName = "JobCode";
            this.cJobCode.HeaderText = "Job Code";
            this.cJobCode.MaxInputLength = 5;
            this.cJobCode.Name = "cJobCode";
            this.cJobCode.ReadOnly = true;
            this.cJobCode.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // cDescription
            // 
            this.cDescription.DataPropertyName = "Description";
            this.cDescription.HeaderText = "Description";
            this.cDescription.Name = "cDescription";
            this.cDescription.ReadOnly = true;
            this.cDescription.Width = 340;
            // 
            // gpFilters
            // 
            this.gpFilters.Controls.Add(this.txtDescription);
            this.gpFilters.Controls.Add(this.lblDescription);
            this.gpFilters.Controls.Add(this.lblStoreValue);
            this.gpFilters.Controls.Add(this.txtCode);
            this.gpFilters.Controls.Add(this.lblCode);
            this.gpFilters.Location = new System.Drawing.Point(12, 12);
            this.gpFilters.Name = "gpFilters";
            this.gpFilters.Size = new System.Drawing.Size(500, 56);
            this.gpFilters.TabIndex = 9;
            this.gpFilters.TabStop = false;
            this.gpFilters.Text = "Filter Results By";
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
            // JobCodeZoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 451);
            this.Controls.Add(this.gpFilters);
            this.Controls.Add(this.dgvJobCodes);
            this.Name = "JobCodeZoom";
            this.Text = "JobCodeZoom";
            this.Load += new System.EventHandler(this.JobCodeZoom_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvJobCodes)).EndInit();
            this.gpFilters.ResumeLayout(false);
            this.gpFilters.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvJobCodes;
        private System.Windows.Forms.DataGridViewTextBoxColumn cJobCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDescription;
        private System.Windows.Forms.GroupBox gpFilters;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblStoreValue;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label lblCode;
    }
}