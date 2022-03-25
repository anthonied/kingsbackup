namespace Liquid.Crystal_Reports
{
    partial class AssetCosts
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
            this.crystalReportViewerAssetCosts = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crystalReportViewerAssetCosts
            // 
            this.crystalReportViewerAssetCosts.ActiveViewIndex = -1;
            this.crystalReportViewerAssetCosts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewerAssetCosts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewerAssetCosts.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewerAssetCosts.Name = "crystalReportViewerAssetCosts";
            this.crystalReportViewerAssetCosts.SelectionFormula = "";
            this.crystalReportViewerAssetCosts.Size = new System.Drawing.Size(598, 342);
            this.crystalReportViewerAssetCosts.TabIndex = 1;
            this.crystalReportViewerAssetCosts.ViewTimeSelectionFormula = "";
            // 
            // AssetCosts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 342);
            this.Controls.Add(this.crystalReportViewerAssetCosts);
            this.Name = "AssetCosts";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Asset Costs Report";
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewerAssetCosts;
    }
}