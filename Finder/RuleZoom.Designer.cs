namespace Liquid.Finder
{
    partial class RuleZoom
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RuleZoom));
            this.lblSearchName = new System.Windows.Forms.Label();
            this.txtSearchFilter = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblAvailableRules = new System.Windows.Forms.Label();
            this.dgvAvailableRules = new System.Windows.Forms.DataGridView();
            this.PKiRuleID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sRuleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clRuleUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnResetRules = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAvailableRules)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSearchName
            // 
            this.lblSearchName.AutoSize = true;
            this.lblSearchName.BackColor = System.Drawing.Color.Transparent;
            this.lblSearchName.Location = new System.Drawing.Point(15, 73);
            this.lblSearchName.Name = "lblSearchName";
            this.lblSearchName.Size = new System.Drawing.Size(56, 13);
            this.lblSearchName.TabIndex = 38;
            this.lblSearchName.Text = "Search for";
            // 
            // txtSearchFilter
            // 
            this.txtSearchFilter.Location = new System.Drawing.Point(73, 70);
            this.txtSearchFilter.Name = "txtSearchFilter";
            this.txtSearchFilter.Size = new System.Drawing.Size(136, 20);
            this.txtSearchFilter.TabIndex = 39;
            this.txtSearchFilter.TextChanged += new System.EventHandler(this.txtSearchFilter_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(13, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(245, 13);
            this.label5.TabIndex = 37;
            this.label5.Text = "Type search terms in the area below to filter results";
            // 
            // lblAvailableRules
            // 
            this.lblAvailableRules.AutoSize = true;
            this.lblAvailableRules.BackColor = System.Drawing.Color.Transparent;
            this.lblAvailableRules.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvailableRules.Location = new System.Drawing.Point(12, 9);
            this.lblAvailableRules.Name = "lblAvailableRules";
            this.lblAvailableRules.Size = new System.Drawing.Size(137, 20);
            this.lblAvailableRules.TabIndex = 36;
            this.lblAvailableRules.Text = "Available Rules:";
            // 
            // dgvAvailableRules
            // 
            this.dgvAvailableRules.AllowUserToAddRows = false;
            this.dgvAvailableRules.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAvailableRules.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAvailableRules.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PKiRuleID,
            this.sRuleName,
            this.clDescription,
            this.clRuleUnit});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAvailableRules.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvAvailableRules.Location = new System.Drawing.Point(12, 114);
            this.dgvAvailableRules.Name = "dgvAvailableRules";
            this.dgvAvailableRules.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAvailableRules.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvAvailableRules.RowHeadersVisible = false;
            this.dgvAvailableRules.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAvailableRules.Size = new System.Drawing.Size(333, 254);
            this.dgvAvailableRules.StandardTab = true;
            this.dgvAvailableRules.TabIndex = 35;
            this.dgvAvailableRules.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAvailableRules_CellContentDoubleClick);
            // 
            // PKiRuleID
            // 
            this.PKiRuleID.DataPropertyName = "PKiRuleID";
            this.PKiRuleID.HeaderText = "Rule #";
            this.PKiRuleID.Name = "PKiRuleID";
            this.PKiRuleID.ReadOnly = true;
            this.PKiRuleID.Width = 50;
            // 
            // sRuleName
            // 
            this.sRuleName.DataPropertyName = "sRuleName";
            this.sRuleName.HeaderText = "Rule Name";
            this.sRuleName.Name = "sRuleName";
            this.sRuleName.ReadOnly = true;
            this.sRuleName.Width = 80;
            // 
            // clDescription
            // 
            this.clDescription.DataPropertyName = "sRuleDescription";
            this.clDescription.HeaderText = "Description";
            this.clDescription.Name = "clDescription";
            this.clDescription.ReadOnly = true;
            this.clDescription.Width = 200;
            // 
            // clRuleUnit
            // 
            this.clRuleUnit.DataPropertyName = "sRuleUnit";
            this.clRuleUnit.HeaderText = "Rule Unit";
            this.clRuleUnit.Name = "clRuleUnit";
            this.clRuleUnit.ReadOnly = true;
            this.clRuleUnit.Visible = false;
            // 
            // btnResetRules
            // 
            this.btnResetRules.FlatAppearance.BorderSize = 0;
            this.btnResetRules.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetRules.Image = ((System.Drawing.Image)(resources.GetObject("btnResetRules.Image")));
            this.btnResetRules.Location = new System.Drawing.Point(210, 64);
            this.btnResetRules.Name = "btnResetRules";
            this.btnResetRules.Size = new System.Drawing.Size(24, 28);
            this.btnResetRules.TabIndex = 41;
            this.btnResetRules.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnResetRules.UseVisualStyleBackColor = true;
            this.btnResetRules.Click += new System.EventHandler(this.btnResetRules_Click);
            // 
            // RuleZoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 386);
            this.Controls.Add(this.btnResetRules);
            this.Controls.Add(this.lblSearchName);
            this.Controls.Add(this.txtSearchFilter);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblAvailableRules);
            this.Controls.Add(this.dgvAvailableRules);
            this.Name = "RuleZoom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search Rules";
            ((System.ComponentModel.ISupportInitialize)(this.dgvAvailableRules)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnResetRules;
        private System.Windows.Forms.Label lblSearchName;
        private System.Windows.Forms.TextBox txtSearchFilter;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblAvailableRules;
        private System.Windows.Forms.DataGridView dgvAvailableRules;
        private System.Windows.Forms.DataGridViewTextBoxColumn PKiRuleID;
        private System.Windows.Forms.DataGridViewTextBoxColumn sRuleName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn clRuleUnit;
    }
}