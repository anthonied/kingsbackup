namespace Liquid.Finder
{
    partial class JcrZoom
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
            this.dgJcrZoom = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtJcr = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgJcrZoom)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgJcrZoom
            // 
            this.dgJcrZoom.AllowUserToAddRows = false;
            this.dgJcrZoom.AllowUserToDeleteRows = false;
            this.dgJcrZoom.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgJcrZoom.Location = new System.Drawing.Point(12, 99);
            this.dgJcrZoom.Name = "dgJcrZoom";
            this.dgJcrZoom.ReadOnly = true;
            this.dgJcrZoom.RowHeadersVisible = false;
            this.dgJcrZoom.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgJcrZoom.Size = new System.Drawing.Size(327, 392);
            this.dgJcrZoom.TabIndex = 0;
            this.dgJcrZoom.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgJcrZoom_CellDoubleClick);
            this.dgJcrZoom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgJcrZoom_KeyDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtJcr);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(327, 72);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter Results";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Jcr No";
            // 
            // txtJcr
            // 
            this.txtJcr.Location = new System.Drawing.Point(68, 33);
            this.txtJcr.Name = "txtJcr";
            this.txtJcr.Size = new System.Drawing.Size(141, 20);
            this.txtJcr.TabIndex = 0;
            this.txtJcr.TextChanged += new System.EventHandler(this.txtJcr_TextChanged);
            // 
            // JcrZoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 506);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgJcrZoom);
            this.Name = "JcrZoom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "JcrZoom";
            this.Load += new System.EventHandler(this.JcrZoom_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgJcrZoom)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgJcrZoom;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtJcr;
    }
}