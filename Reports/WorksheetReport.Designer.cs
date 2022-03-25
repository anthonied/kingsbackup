namespace Liquid.Reports
{
    partial class WorksheetReport
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
            this.crViewerWorksheet = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crViewerWorksheet
            // 
            this.crViewerWorksheet.ActiveViewIndex = -1;
            this.crViewerWorksheet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crViewerWorksheet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crViewerWorksheet.Location = new System.Drawing.Point(0, 0);
            this.crViewerWorksheet.Name = "crViewerWorksheet";
            this.crViewerWorksheet.ShowGroupTreeButton = false;
            this.crViewerWorksheet.Size = new System.Drawing.Size(580, 569);
            this.crViewerWorksheet.TabIndex = 0;
            this.crViewerWorksheet.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // WorksheetReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 569);
            this.Controls.Add(this.crViewerWorksheet);
            this.Name = "WorksheetReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "WorksheetReport";
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer crViewerWorksheet;

    }
}