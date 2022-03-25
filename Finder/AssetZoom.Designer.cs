namespace Liquid.Finder
{
    partial class AssetZoom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AssetZoom));
            this.dgAssetData = new System.Windows.Forms.DataGridView();
            this.clAssetNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmdAssetSearch = new System.Windows.Forms.Button();
            this.txtFilterAsset = new System.Windows.Forms.TextBox();
            this.bgFilterResults = new System.Windows.Forms.GroupBox();
            this.lblAssetNumber = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgAssetData)).BeginInit();
            this.bgFilterResults.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgAssetData
            // 
            this.dgAssetData.AllowUserToAddRows = false;
            this.dgAssetData.AllowUserToDeleteRows = false;
            this.dgAssetData.AllowUserToResizeColumns = false;
            this.dgAssetData.AllowUserToResizeRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.GhostWhite;
            this.dgAssetData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgAssetData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgAssetData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clAssetNumber,
            this.clDescription});
            this.dgAssetData.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dgAssetData.Location = new System.Drawing.Point(21, 70);
            this.dgAssetData.Name = "dgAssetData";
            this.dgAssetData.RowHeadersVisible = false;
            this.dgAssetData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgAssetData.Size = new System.Drawing.Size(393, 321);
            this.dgAssetData.TabIndex = 0;
            this.dgAssetData.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgAssetData_CellDoubleClick);
            this.dgAssetData.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgAssetData_KeyDown);
            this.dgAssetData.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgAssetData_KeyPress);
            // 
            // clAssetNumber
            // 
            this.clAssetNumber.HeaderText = "Asset Number";
            this.clAssetNumber.Name = "clAssetNumber";
            this.clAssetNumber.ReadOnly = true;
            this.clAssetNumber.Width = 140;
            // 
            // clDescription
            // 
            this.clDescription.HeaderText = "Description";
            this.clDescription.Name = "clDescription";
            this.clDescription.ReadOnly = true;
            this.clDescription.Width = 250;
            // 
            // cmdAssetSearch
            // 
            this.cmdAssetSearch.BackColor = System.Drawing.Color.White;
            this.cmdAssetSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdAssetSearch.Image = ((System.Drawing.Image)(resources.GetObject("cmdAssetSearch.Image")));
            this.cmdAssetSearch.Location = new System.Drawing.Point(213, 17);
            this.cmdAssetSearch.Name = "cmdAssetSearch";
            this.cmdAssetSearch.Size = new System.Drawing.Size(25, 23);
            this.cmdAssetSearch.TabIndex = 50;
            this.cmdAssetSearch.UseVisualStyleBackColor = false;
            this.cmdAssetSearch.Click += new System.EventHandler(this.cmdAssetSearch_Click);
            // 
            // txtFilterAsset
            // 
            this.txtFilterAsset.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFilterAsset.Location = new System.Drawing.Point(92, 19);
            this.txtFilterAsset.MaxLength = 6;
            this.txtFilterAsset.Name = "txtFilterAsset";
            this.txtFilterAsset.Size = new System.Drawing.Size(118, 20);
            this.txtFilterAsset.TabIndex = 49;
            this.txtFilterAsset.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFilterAsset_KeyDown);
            // 
            // bgFilterResults
            // 
            this.bgFilterResults.Controls.Add(this.txtFilterAsset);
            this.bgFilterResults.Controls.Add(this.cmdAssetSearch);
            this.bgFilterResults.Controls.Add(this.lblAssetNumber);
            this.bgFilterResults.Location = new System.Drawing.Point(21, 12);
            this.bgFilterResults.Name = "bgFilterResults";
            this.bgFilterResults.Size = new System.Drawing.Size(393, 52);
            this.bgFilterResults.TabIndex = 51;
            this.bgFilterResults.TabStop = false;
            this.bgFilterResults.Text = "Filter Results By";
            // 
            // lblAssetNumber
            // 
            this.lblAssetNumber.AutoSize = true;
            this.lblAssetNumber.Location = new System.Drawing.Point(26, 22);
            this.lblAssetNumber.Name = "lblAssetNumber";
            this.lblAssetNumber.Size = new System.Drawing.Size(56, 13);
            this.lblAssetNumber.TabIndex = 48;
            this.lblAssetNumber.Text = "Search for";
            // 
            // AssetZoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 406);
            this.Controls.Add(this.bgFilterResults);
            this.Controls.Add(this.dgAssetData);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AssetZoom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Assets";
            this.Load += new System.EventHandler(this.AssetZoom_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgAssetData)).EndInit();
            this.bgFilterResults.ResumeLayout(false);
            this.bgFilterResults.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgAssetData;
        private System.Windows.Forms.Button cmdAssetSearch;
        private System.Windows.Forms.TextBox txtFilterAsset;
        private System.Windows.Forms.GroupBox bgFilterResults;
        private System.Windows.Forms.Label lblAssetNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn clAssetNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDescription;
    }
}