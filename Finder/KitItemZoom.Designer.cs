namespace Liquid.Finder
{
    partial class KitItemZoom
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtKitName = new System.Windows.Forms.TextBox();
            this.dgKitZoom = new System.Windows.Forms.DataGridView();
            this.clKitName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgKitZoom)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtKitName);
            this.groupBox1.Location = new System.Drawing.Point(24, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(330, 89);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter Results";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Kit Name:";
            // 
            // txtKitName
            // 
            this.txtKitName.Location = new System.Drawing.Point(93, 37);
            this.txtKitName.Name = "txtKitName";
            this.txtKitName.Size = new System.Drawing.Size(150, 20);
            this.txtKitName.TabIndex = 0;
            this.txtKitName.TextChanged += new System.EventHandler(this.txtKitName_TextChanged);
            // 
            // dgKitZoom
            // 
            this.dgKitZoom.AllowUserToAddRows = false;
            this.dgKitZoom.AllowUserToDeleteRows = false;
            this.dgKitZoom.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgKitZoom.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clKitName});
            this.dgKitZoom.Location = new System.Drawing.Point(24, 142);
            this.dgKitZoom.Name = "dgKitZoom";
            this.dgKitZoom.ReadOnly = true;
            this.dgKitZoom.RowHeadersVisible = false;
            this.dgKitZoom.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgKitZoom.Size = new System.Drawing.Size(327, 251);
            this.dgKitZoom.TabIndex = 1;
            this.dgKitZoom.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dgKitZoom.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgKitZoom_CellDoubleClick);
            // 
            // clKitName
            // 
            this.clKitName.HeaderText = "Kit Name";
            this.clKitName.Name = "clKitName";
            this.clKitName.ReadOnly = true;
            this.clKitName.Width = 200;
            // 
            // KitItemZoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 418);
            this.Controls.Add(this.dgKitZoom);
            this.Controls.Add(this.groupBox1);
            this.Name = "KitItemZoom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kit Item Zoom";
            this.Load += new System.EventHandler(this.KitItemZoom_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgKitZoom)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtKitName;
        private System.Windows.Forms.DataGridView dgKitZoom;
        private System.Windows.Forms.DataGridViewTextBoxColumn clKitName;

    }
}