namespace Liquid.Finder
{
    partial class MarketingCategoryZoom
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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.dgCategories = new System.Windows.Forms.DataGridView();
            this.clCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clPercentage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCat = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgCategories)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.txtCat);
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Location = new System.Drawing.Point(18, 20);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(306, 99);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Filter Results by";
            // 
            // dgCategories
            // 
            this.dgCategories.AllowUserToAddRows = false;
            this.dgCategories.AllowUserToDeleteRows = false;
            this.dgCategories.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCategories.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clCategory,
            this.clPercentage});
            this.dgCategories.Location = new System.Drawing.Point(18, 133);
            this.dgCategories.Name = "dgCategories";
            this.dgCategories.ReadOnly = true;
            this.dgCategories.RowHeadersVisible = false;
            this.dgCategories.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgCategories.Size = new System.Drawing.Size(306, 211);
            this.dgCategories.TabIndex = 1;
            this.dgCategories.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgCategories_CellContentClick);
            // 
            // clCategory
            // 
            this.clCategory.HeaderText = "Category";
            this.clCategory.Name = "clCategory";
            this.clCategory.ReadOnly = true;
            this.clCategory.Width = 200;
            // 
            // clPercentage
            // 
            this.clPercentage.HeaderText = "Percentage";
            this.clPercentage.Name = "clPercentage";
            this.clPercentage.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Category";
            // 
            // txtCat
            // 
            this.txtCat.Location = new System.Drawing.Point(79, 47);
            this.txtCat.Name = "txtCat";
            this.txtCat.Size = new System.Drawing.Size(176, 20);
            this.txtCat.TabIndex = 1;
            this.txtCat.TextChanged += new System.EventHandler(this.txtCat_TextChanged);
            // 
            // MarketingCategoryZoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 357);
            this.Controls.Add(this.dgCategories);
            this.Controls.Add(this.groupControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MarketingCategoryZoom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Marketing Category Zoom";
            this.Load += new System.EventHandler(this.MarketingCategoryZoom_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgCategories)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.TextBox txtCat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgCategories;
        private System.Windows.Forms.DataGridViewTextBoxColumn clCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn clPercentage;
    }
}