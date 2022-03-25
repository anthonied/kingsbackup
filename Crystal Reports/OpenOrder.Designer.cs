namespace Liquid.Crystal_Reports
{
    partial class OpenOrder
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
            this.crViewerOpenOrders = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crViewerOpenOrders
            // 
            this.crViewerOpenOrders.ActiveViewIndex = -1;
            this.crViewerOpenOrders.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crViewerOpenOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crViewerOpenOrders.Location = new System.Drawing.Point(0, 0);
            this.crViewerOpenOrders.Name = "crViewerOpenOrders";
            this.crViewerOpenOrders.SelectionFormula = "";
            this.crViewerOpenOrders.Size = new System.Drawing.Size(568, 350);
            this.crViewerOpenOrders.TabIndex = 2;
            this.crViewerOpenOrders.ViewTimeSelectionFormula = "";
            this.crViewerOpenOrders.Load += new System.EventHandler(this.crViewerOpenOrders_Load);
            // 
            // OpenOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 350);
            this.Controls.Add(this.crViewerOpenOrders);
            this.Name = "OpenOrder";
            this.Text = "OpenOrder";
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer crViewerOpenOrders;
    }
}