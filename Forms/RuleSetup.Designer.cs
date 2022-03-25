namespace Liquid.Forms
{
    partial class RuleSetup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RuleSetup));
            this.lblRuleName = new System.Windows.Forms.Label();
            this.lblRuleDesc = new System.Windows.Forms.Label();
            this.txtRuleName = new System.Windows.Forms.TextBox();
            this.txtRuleDesc = new System.Windows.Forms.TextBox();
            this.chkSpecialEvent = new System.Windows.Forms.CheckBox();
            this.selSpecialRule = new System.Windows.Forms.ComboBox();
            this.dgvRuleParameters = new System.Windows.Forms.DataGridView();
            this.btnAddPropertyRow = new System.Windows.Forms.Button();
            this.btnRemovePropertyRow = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.lblRuleParameters = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearchRules = new System.Windows.Forms.Button();
            this.txtRuleID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSaveRule = new System.Windows.Forms.Button();
            this.btnClearForm = new System.Windows.Forms.Button();
            this.txtRuleUnit = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.colDayValBegin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colToText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDayValEnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPMTPercentage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PKiRParameterID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clReturnPeriod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chkDayOrDate = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRuleParameters)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRuleName
            // 
            this.lblRuleName.AutoSize = true;
            this.lblRuleName.Location = new System.Drawing.Point(29, 66);
            this.lblRuleName.Name = "lblRuleName";
            this.lblRuleName.Size = new System.Drawing.Size(70, 13);
            this.lblRuleName.TabIndex = 0;
            this.lblRuleName.Text = "Rule Name *:";
            // 
            // lblRuleDesc
            // 
            this.lblRuleDesc.AutoSize = true;
            this.lblRuleDesc.Location = new System.Drawing.Point(29, 92);
            this.lblRuleDesc.Name = "lblRuleDesc";
            this.lblRuleDesc.Size = new System.Drawing.Size(88, 13);
            this.lblRuleDesc.TabIndex = 1;
            this.lblRuleDesc.Text = "Rule Description:";
            // 
            // txtRuleName
            // 
            this.txtRuleName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRuleName.Location = new System.Drawing.Point(127, 64);
            this.txtRuleName.MaxLength = 4;
            this.txtRuleName.Name = "txtRuleName";
            this.txtRuleName.Size = new System.Drawing.Size(92, 20);
            this.txtRuleName.TabIndex = 2;
            // 
            // txtRuleDesc
            // 
            this.txtRuleDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRuleDesc.Location = new System.Drawing.Point(127, 90);
            this.txtRuleDesc.Multiline = true;
            this.txtRuleDesc.Name = "txtRuleDesc";
            this.txtRuleDesc.Size = new System.Drawing.Size(254, 54);
            this.txtRuleDesc.TabIndex = 3;
            // 
            // chkSpecialEvent
            // 
            this.chkSpecialEvent.AutoSize = true;
            this.chkSpecialEvent.Location = new System.Drawing.Point(32, 180);
            this.chkSpecialEvent.Name = "chkSpecialEvent";
            this.chkSpecialEvent.Size = new System.Drawing.Size(89, 17);
            this.chkSpecialEvent.TabIndex = 5;
            this.chkSpecialEvent.Text = "Special Rule:";
            this.chkSpecialEvent.UseVisualStyleBackColor = true;
            this.chkSpecialEvent.CheckedChanged += new System.EventHandler(this.chkSpecialEvent_CheckedChanged);
            // 
            // selSpecialRule
            // 
            this.selSpecialRule.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selSpecialRule.Enabled = false;
            this.selSpecialRule.FormattingEnabled = true;
            this.selSpecialRule.Location = new System.Drawing.Point(127, 178);
            this.selSpecialRule.Name = "selSpecialRule";
            this.selSpecialRule.Size = new System.Drawing.Size(121, 21);
            this.selSpecialRule.TabIndex = 6;
            // 
            // dgvRuleParameters
            // 
            this.dgvRuleParameters.AllowUserToAddRows = false;
            this.dgvRuleParameters.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDayValBegin,
            this.colToText,
            this.colDayValEnd,
            this.colPMTPercentage,
            this.PKiRParameterID,
            this.clReturnPeriod});
            this.dgvRuleParameters.Location = new System.Drawing.Point(22, 309);
            this.dgvRuleParameters.Name = "dgvRuleParameters";
            this.dgvRuleParameters.RowHeadersVisible = false;
            this.dgvRuleParameters.Size = new System.Drawing.Size(359, 201);
            this.dgvRuleParameters.StandardTab = true;
            this.dgvRuleParameters.TabIndex = 7;
            this.dgvRuleParameters.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvRuleParameters_EditingControlShowing);
            this.dgvRuleParameters.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgvRuleParameters_KeyPress);
            // 
            // btnAddPropertyRow
            // 
            this.btnAddPropertyRow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddPropertyRow.FlatAppearance.BorderSize = 0;
            this.btnAddPropertyRow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddPropertyRow.Image = global::Liquid.Properties.Resources.add1;
            this.btnAddPropertyRow.Location = new System.Drawing.Point(25, 272);
            this.btnAddPropertyRow.Name = "btnAddPropertyRow";
            this.btnAddPropertyRow.Size = new System.Drawing.Size(35, 31);
            this.btnAddPropertyRow.TabIndex = 8;
            this.btnAddPropertyRow.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddPropertyRow.UseVisualStyleBackColor = true;
            this.btnAddPropertyRow.Click += new System.EventHandler(this.btnAddPropertyRow_Click);
            // 
            // btnRemovePropertyRow
            // 
            this.btnRemovePropertyRow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRemovePropertyRow.FlatAppearance.BorderSize = 0;
            this.btnRemovePropertyRow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemovePropertyRow.Image = global::Liquid.Properties.Resources.delete;
            this.btnRemovePropertyRow.Location = new System.Drawing.Point(58, 272);
            this.btnRemovePropertyRow.Name = "btnRemovePropertyRow";
            this.btnRemovePropertyRow.Size = new System.Drawing.Size(36, 31);
            this.btnRemovePropertyRow.TabIndex = 9;
            this.btnRemovePropertyRow.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRemovePropertyRow.UseVisualStyleBackColor = true;
            this.btnRemovePropertyRow.Click += new System.EventHandler(this.btnRemovePropertyRow_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(22, 253);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(301, 13);
            this.label5.TabIndex = 32;
            this.label5.Text = "Please use the controls below to set up parameters for this rule";
            // 
            // lblRuleParameters
            // 
            this.lblRuleParameters.AutoSize = true;
            this.lblRuleParameters.BackColor = System.Drawing.Color.Transparent;
            this.lblRuleParameters.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRuleParameters.Location = new System.Drawing.Point(21, 226);
            this.lblRuleParameters.Name = "lblRuleParameters";
            this.lblRuleParameters.Size = new System.Drawing.Size(148, 20);
            this.lblRuleParameters.TabIndex = 31;
            this.lblRuleParameters.Text = "Rule Parameters:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 20);
            this.label1.TabIndex = 33;
            this.label1.Text = "Rule Details:";
            // 
            // btnSearchRules
            // 
            this.btnSearchRules.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearchRules.FlatAppearance.BorderSize = 0;
            this.btnSearchRules.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchRules.Image = ((System.Drawing.Image)(resources.GetObject("btnSearchRules.Image")));
            this.btnSearchRules.Location = new System.Drawing.Point(292, 60);
            this.btnSearchRules.Name = "btnSearchRules";
            this.btnSearchRules.Size = new System.Drawing.Size(24, 24);
            this.btnSearchRules.TabIndex = 159;
            this.btnSearchRules.UseVisualStyleBackColor = true;
            this.btnSearchRules.Click += new System.EventHandler(this.btnSearchRules_Click);
            // 
            // txtRuleID
            // 
            this.txtRuleID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRuleID.Location = new System.Drawing.Point(127, 38);
            this.txtRuleID.Name = "txtRuleID";
            this.txtRuleID.ReadOnly = true;
            this.txtRuleID.Size = new System.Drawing.Size(92, 20);
            this.txtRuleID.TabIndex = 160;
            this.txtRuleID.Text = "*NEW*";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 161;
            this.label2.Text = "Rule Number :";
            // 
            // btnSaveRule
            // 
            this.btnSaveRule.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaveRule.FlatAppearance.BorderSize = 0;
            this.btnSaveRule.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveRule.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveRule.Image")));
            this.btnSaveRule.Location = new System.Drawing.Point(94, 275);
            this.btnSaveRule.Name = "btnSaveRule";
            this.btnSaveRule.Size = new System.Drawing.Size(24, 24);
            this.btnSaveRule.TabIndex = 162;
            this.btnSaveRule.UseVisualStyleBackColor = true;
            this.btnSaveRule.Click += new System.EventHandler(this.btnSaveRule_Click);
            // 
            // btnClearForm
            // 
            this.btnClearForm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClearForm.FlatAppearance.BorderSize = 0;
            this.btnClearForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearForm.Image = ((System.Drawing.Image)(resources.GetObject("btnClearForm.Image")));
            this.btnClearForm.Location = new System.Drawing.Point(322, 60);
            this.btnClearForm.Name = "btnClearForm";
            this.btnClearForm.Size = new System.Drawing.Size(24, 24);
            this.btnClearForm.TabIndex = 163;
            this.btnClearForm.UseVisualStyleBackColor = true;
            this.btnClearForm.Click += new System.EventHandler(this.btnClearForm_Click);
            // 
            // txtRuleUnit
            // 
            this.txtRuleUnit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRuleUnit.Location = new System.Drawing.Point(127, 151);
            this.txtRuleUnit.MaxLength = 4;
            this.txtRuleUnit.Name = "txtRuleUnit";
            this.txtRuleUnit.Size = new System.Drawing.Size(92, 20);
            this.txtRuleUnit.TabIndex = 164;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 165;
            this.label3.Text = "Rule Unit:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(221, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 166;
            this.label4.Text = "(Max 4 Char)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(221, 66);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 167;
            this.label6.Text = "(Max 4 Char)";
            // 
            // colDayValBegin
            // 
            this.colDayValBegin.HeaderText = "Begin Value";
            this.colDayValBegin.Name = "colDayValBegin";
            // 
            // colToText
            // 
            this.colToText.HeaderText = "";
            this.colToText.Name = "colToText";
            this.colToText.ReadOnly = true;
            this.colToText.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colToText.Visible = false;
            this.colToText.Width = 50;
            // 
            // colDayValEnd
            // 
            this.colDayValEnd.HeaderText = "End Value";
            this.colDayValEnd.Name = "colDayValEnd";
            // 
            // colPMTPercentage
            // 
            this.colPMTPercentage.HeaderText = "Period";
            this.colPMTPercentage.Name = "colPMTPercentage";
            this.colPMTPercentage.Width = 75;
            // 
            // PKiRParameterID
            // 
            this.PKiRParameterID.HeaderText = "Parameter ID";
            this.PKiRParameterID.Name = "PKiRParameterID";
            this.PKiRParameterID.Visible = false;
            // 
            // clReturnPeriod
            // 
            this.clReturnPeriod.HeaderText = "Return Period";
            this.clReturnPeriod.Name = "clReturnPeriod";
            this.clReturnPeriod.Width = 80;
            // 
            // chkDayOrDate
            // 
            this.chkDayOrDate.AutoSize = true;
            this.chkDayOrDate.Location = new System.Drawing.Point(32, 205);
            this.chkDayOrDate.Name = "chkDayOrDate";
            this.chkDayOrDate.Size = new System.Drawing.Size(214, 17);
            this.chkDayOrDate.TabIndex = 168;
            this.chkDayOrDate.Text = "Use dates to calculate the period value.";
            this.chkDayOrDate.UseVisualStyleBackColor = true;
            // 
            // RuleSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 531);
            this.Controls.Add(this.chkDayOrDate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtRuleUnit);
            this.Controls.Add(this.btnClearForm);
            this.Controls.Add(this.btnSaveRule);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtRuleID);
            this.Controls.Add(this.btnSearchRules);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblRuleParameters);
            this.Controls.Add(this.btnRemovePropertyRow);
            this.Controls.Add(this.btnAddPropertyRow);
            this.Controls.Add(this.dgvRuleParameters);
            this.Controls.Add(this.selSpecialRule);
            this.Controls.Add(this.chkSpecialEvent);
            this.Controls.Add(this.txtRuleDesc);
            this.Controls.Add(this.txtRuleName);
            this.Controls.Add(this.lblRuleDesc);
            this.Controls.Add(this.lblRuleName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "RuleSetup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rule Setup";
            ((System.ComponentModel.ISupportInitialize)(this.dgvRuleParameters)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRuleName;
        private System.Windows.Forms.Label lblRuleDesc;
        private System.Windows.Forms.TextBox txtRuleName;
        private System.Windows.Forms.TextBox txtRuleDesc;
        private System.Windows.Forms.CheckBox chkSpecialEvent;
        private System.Windows.Forms.ComboBox selSpecialRule;
        private System.Windows.Forms.DataGridView dgvRuleParameters;
        private System.Windows.Forms.Button btnAddPropertyRow;
        private System.Windows.Forms.Button btnRemovePropertyRow;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblRuleParameters;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearchRules;
        private System.Windows.Forms.TextBox txtRuleID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSaveRule;
        private System.Windows.Forms.Button btnClearForm;
        private System.Windows.Forms.TextBox txtRuleUnit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDayValBegin;
        private System.Windows.Forms.DataGridViewTextBoxColumn colToText;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDayValEnd;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPMTPercentage;
        private System.Windows.Forms.DataGridViewTextBoxColumn PKiRParameterID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clReturnPeriod;
        private System.Windows.Forms.CheckBox chkDayOrDate;
    }
}