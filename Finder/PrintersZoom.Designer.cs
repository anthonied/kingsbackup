namespace Liquid.Finder
{
    partial class PrintersZoom
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
            this.dgvPrinters = new System.Windows.Forms.DataGridView();
            this.clPrinterName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrinters)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPrinters
            // 
            this.dgvPrinters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPrinters.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clPrinterName});
            this.dgvPrinters.Location = new System.Drawing.Point(12, 41);
            this.dgvPrinters.Name = "dgvPrinters";
            this.dgvPrinters.RowHeadersVisible = false;
            this.dgvPrinters.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPrinters.Size = new System.Drawing.Size(255, 150);
            this.dgvPrinters.TabIndex = 0;
            this.dgvPrinters.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPrinters_CellDoubleClick);
            this.dgvPrinters.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvPrinters_KeyDown);
            // 
            // clPrinterName
            // 
            this.clPrinterName.HeaderText = "Printer Name";
            this.clPrinterName.Name = "clPrinterName";
            this.clPrinterName.Width = 250;
            // 
            // PrintersZoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(279, 206);
            this.Controls.Add(this.dgvPrinters);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "PrintersZoom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PrintersZoom";
            this.Load += new System.EventHandler(this.PrintersZoom_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrinters)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPrinters;
        private System.Windows.Forms.DataGridViewTextBoxColumn clPrinterName;
    }
}