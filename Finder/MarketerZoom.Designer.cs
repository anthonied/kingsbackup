namespace Liquid.Finder
{
    partial class MarketerZoom
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
            this.dgMarketerZoom = new System.Windows.Forms.DataGridView();
            this.clMarketer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgMarketerZoom)).BeginInit();
            this.SuspendLayout();
            // 
            // dgMarketerZoom
            // 
            this.dgMarketerZoom.AllowUserToAddRows = false;
            this.dgMarketerZoom.AllowUserToDeleteRows = false;
            this.dgMarketerZoom.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgMarketerZoom.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clMarketer,
            this.clDescription});
            this.dgMarketerZoom.Location = new System.Drawing.Point(12, 12);
            this.dgMarketerZoom.Name = "dgMarketerZoom";
            this.dgMarketerZoom.ReadOnly = true;
            this.dgMarketerZoom.RowHeadersVisible = false;
            this.dgMarketerZoom.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgMarketerZoom.Size = new System.Drawing.Size(408, 436);
            this.dgMarketerZoom.TabIndex = 1;
            this.dgMarketerZoom.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgMarketerZoom_CellDoubleClick);
            this.dgMarketerZoom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgMarketerZoom_KeyDown);
            // 
            // clMarketer
            // 
            this.clMarketer.HeaderText = "clMarketer";
            this.clMarketer.Name = "clMarketer";
            this.clMarketer.ReadOnly = true;
            // 
            // clDescription
            // 
            this.clDescription.HeaderText = "clDescription";
            this.clDescription.Name = "clDescription";
            this.clDescription.ReadOnly = true;
            this.clDescription.Width = 300;
            // 
            // MarketerZoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 483);
            this.Controls.Add(this.dgMarketerZoom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MarketerZoom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Marketer Zoom";
            this.Load += new System.EventHandler(this.MarketerZoom_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgMarketerZoom)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgMarketerZoom;
        private System.Windows.Forms.DataGridViewTextBoxColumn clMarketer;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDescription;
    }
}