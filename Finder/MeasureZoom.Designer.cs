namespace Liquid.Finder
{
    partial class MeasureZoom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MeasureZoom));
            this.lblSearchName = new System.Windows.Forms.Label();
            this.txtSearchFilter = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblAvailableRules = new System.Windows.Forms.Label();
            this.btnResetRules = new System.Windows.Forms.Button();
            this.dgvUnits = new System.Windows.Forms.DataGridView();
            this.clUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clNetMass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUnits)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSearchName
            // 
            this.lblSearchName.AutoSize = true;
            this.lblSearchName.BackColor = System.Drawing.Color.Transparent;
            this.lblSearchName.Location = new System.Drawing.Point(15, 73);
            this.lblSearchName.Name = "lblSearchName";
            this.lblSearchName.Size = new System.Drawing.Size(56, 13);
            this.lblSearchName.TabIndex = 44;
            this.lblSearchName.Text = "Search for";
            // 
            // txtSearchFilter
            // 
            this.txtSearchFilter.Location = new System.Drawing.Point(73, 70);
            this.txtSearchFilter.Name = "txtSearchFilter";
            this.txtSearchFilter.Size = new System.Drawing.Size(136, 20);
            this.txtSearchFilter.TabIndex = 45;
            this.txtSearchFilter.TextChanged += new System.EventHandler(this.txtSearchFilter_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(13, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(245, 13);
            this.label5.TabIndex = 43;
            this.label5.Text = "Type search terms in the area below to filter results";
            // 
            // lblAvailableRules
            // 
            this.lblAvailableRules.AutoSize = true;
            this.lblAvailableRules.BackColor = System.Drawing.Color.Transparent;
            this.lblAvailableRules.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvailableRules.Location = new System.Drawing.Point(12, 9);
            this.lblAvailableRules.Name = "lblAvailableRules";
            this.lblAvailableRules.Size = new System.Drawing.Size(133, 20);
            this.lblAvailableRules.TabIndex = 42;
            this.lblAvailableRules.Text = "Available Units:";
            // 
            // btnResetRules
            // 
            this.btnResetRules.FlatAppearance.BorderSize = 0;
            this.btnResetRules.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetRules.Image = ((System.Drawing.Image)(resources.GetObject("btnResetRules.Image")));
            this.btnResetRules.Location = new System.Drawing.Point(231, 65);
            this.btnResetRules.Name = "btnResetRules";
            this.btnResetRules.Size = new System.Drawing.Size(24, 28);
            this.btnResetRules.TabIndex = 46;
            this.btnResetRules.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnResetRules.UseVisualStyleBackColor = true;
            // 
            // dgvUnits
            // 
            this.dgvUnits.AllowUserToAddRows = false;
            this.dgvUnits.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clUnit,
            this.clNetMass});
            this.dgvUnits.Location = new System.Drawing.Point(16, 111);
            this.dgvUnits.Name = "dgvUnits";
            this.dgvUnits.RowHeadersVisible = false;
            this.dgvUnits.Size = new System.Drawing.Size(304, 212);
            this.dgvUnits.StandardTab = true;
            this.dgvUnits.TabIndex = 176;
            this.dgvUnits.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUnits_CellClick);
            this.dgvUnits.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvUnits_KeyDown);
            // 
            // clUnit
            // 
            this.clUnit.HeaderText = "Measured Unit";
            this.clUnit.Name = "clUnit";
            this.clUnit.Width = 200;
            // 
            // clNetMass
            // 
            this.clNetMass.HeaderText = "Net Mass";
            this.clNetMass.Name = "clNetMass";
            // 
            // MeasureZoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 351);
            this.Controls.Add(this.dgvUnits);
            this.Controls.Add(this.btnResetRules);
            this.Controls.Add(this.lblSearchName);
            this.Controls.Add(this.txtSearchFilter);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblAvailableRules);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MeasureZoom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "MeasureZoom";
            this.Load += new System.EventHandler(this.MeasureZoom_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUnits)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnResetRules;
        private System.Windows.Forms.Label lblSearchName;
        private System.Windows.Forms.TextBox txtSearchFilter;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblAvailableRules;
        private System.Windows.Forms.DataGridView dgvUnits;
        private System.Windows.Forms.DataGridViewTextBoxColumn clUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn clNetMass;
    }
}