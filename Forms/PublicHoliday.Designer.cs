namespace Liquid.Forms
{
    partial class PublicHoliday
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PublicHoliday));
            this.dgPublicHolidays = new System.Windows.Forms.DataGridView();
            this.clHolidayName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clHolidayDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clPhId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtPublicHolidayName = new System.Windows.Forms.TextBox();
            this.dtPublicHolidayDate = new System.Windows.Forms.DateTimePicker();
            this.cmdDeleteGroup = new System.Windows.Forms.Button();
            this.cmdAddGroup = new System.Windows.Forms.Button();
            this.txtPhId = new System.Windows.Forms.TextBox();
            this.cmdNewGroup = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgPublicHolidays)).BeginInit();
            this.SuspendLayout();
            // 
            // dgPublicHolidays
            // 
            this.dgPublicHolidays.AllowUserToAddRows = false;
            this.dgPublicHolidays.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPublicHolidays.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clHolidayName,
            this.clHolidayDate,
            this.clPhId});
            this.dgPublicHolidays.Location = new System.Drawing.Point(22, 22);
            this.dgPublicHolidays.Name = "dgPublicHolidays";
            this.dgPublicHolidays.ReadOnly = true;
            this.dgPublicHolidays.RowHeadersVisible = false;
            this.dgPublicHolidays.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgPublicHolidays.Size = new System.Drawing.Size(403, 275);
            this.dgPublicHolidays.TabIndex = 0;
            this.dgPublicHolidays.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgPublicHolidays_CellDoubleClick);
            this.dgPublicHolidays.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgPublicHolidays_CellContentClick);
            // 
            // clHolidayName
            // 
            this.clHolidayName.HeaderText = "Holiday Name";
            this.clHolidayName.Name = "clHolidayName";
            this.clHolidayName.ReadOnly = true;
            this.clHolidayName.Width = 200;
            // 
            // clHolidayDate
            // 
            this.clHolidayDate.HeaderText = "Holiday Date";
            this.clHolidayDate.Name = "clHolidayDate";
            this.clHolidayDate.ReadOnly = true;
            this.clHolidayDate.Width = 200;
            // 
            // clPhId
            // 
            this.clPhId.HeaderText = "PhId";
            this.clPhId.Name = "clPhId";
            this.clPhId.ReadOnly = true;
            this.clPhId.Visible = false;
            // 
            // txtPublicHolidayName
            // 
            this.txtPublicHolidayName.Location = new System.Drawing.Point(22, 328);
            this.txtPublicHolidayName.Name = "txtPublicHolidayName";
            this.txtPublicHolidayName.Size = new System.Drawing.Size(300, 20);
            this.txtPublicHolidayName.TabIndex = 1;
            // 
            // dtPublicHolidayDate
            // 
            this.dtPublicHolidayDate.Location = new System.Drawing.Point(22, 361);
            this.dtPublicHolidayDate.Name = "dtPublicHolidayDate";
            this.dtPublicHolidayDate.Size = new System.Drawing.Size(239, 20);
            this.dtPublicHolidayDate.TabIndex = 2;
            // 
            // cmdDeleteGroup
            // 
            this.cmdDeleteGroup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdDeleteGroup.FlatAppearance.BorderSize = 0;
            this.cmdDeleteGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdDeleteGroup.Image = global::Liquid.Properties.Resources.delete;
            this.cmdDeleteGroup.Location = new System.Drawing.Point(82, 403);
            this.cmdDeleteGroup.Name = "cmdDeleteGroup";
            this.cmdDeleteGroup.Size = new System.Drawing.Size(25, 24);
            this.cmdDeleteGroup.TabIndex = 162;
            this.cmdDeleteGroup.UseVisualStyleBackColor = true;
            this.cmdDeleteGroup.Click += new System.EventHandler(this.cmdDeleteGroup_Click);
            // 
            // cmdAddGroup
            // 
            this.cmdAddGroup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdAddGroup.FlatAppearance.BorderSize = 0;
            this.cmdAddGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdAddGroup.Image = ((System.Drawing.Image)(resources.GetObject("cmdAddGroup.Image")));
            this.cmdAddGroup.Location = new System.Drawing.Point(52, 403);
            this.cmdAddGroup.Name = "cmdAddGroup";
            this.cmdAddGroup.Size = new System.Drawing.Size(24, 24);
            this.cmdAddGroup.TabIndex = 161;
            this.cmdAddGroup.UseVisualStyleBackColor = true;
            this.cmdAddGroup.Click += new System.EventHandler(this.cmdAddGroup_Click);
            // 
            // txtPhId
            // 
            this.txtPhId.Location = new System.Drawing.Point(382, 299);
            this.txtPhId.Name = "txtPhId";
            this.txtPhId.Size = new System.Drawing.Size(42, 20);
            this.txtPhId.TabIndex = 163;
            this.txtPhId.Visible = false;
            // 
            // cmdNewGroup
            // 
            this.cmdNewGroup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdNewGroup.FlatAppearance.BorderSize = 0;
            this.cmdNewGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdNewGroup.Image = global::Liquid.Properties.Resources.add1;
            this.cmdNewGroup.Location = new System.Drawing.Point(22, 402);
            this.cmdNewGroup.Name = "cmdNewGroup";
            this.cmdNewGroup.Size = new System.Drawing.Size(24, 24);
            this.cmdNewGroup.TabIndex = 164;
            this.cmdNewGroup.UseVisualStyleBackColor = true;
            this.cmdNewGroup.Click += new System.EventHandler(this.cmdNewGroup_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 307);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 13);
            this.label1.TabIndex = 165;
            this.label1.Text = "Enter Name of Public Holiday:";
            // 
            // PublicHoliday
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 443);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdNewGroup);
            this.Controls.Add(this.txtPhId);
            this.Controls.Add(this.cmdDeleteGroup);
            this.Controls.Add(this.cmdAddGroup);
            this.Controls.Add(this.dtPublicHolidayDate);
            this.Controls.Add(this.txtPublicHolidayName);
            this.Controls.Add(this.dgPublicHolidays);
            this.Name = "PublicHoliday";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Public Holiday Setup";
            this.Load += new System.EventHandler(this.PublicHoliday_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgPublicHolidays)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgPublicHolidays;
        private System.Windows.Forms.TextBox txtPublicHolidayName;
        private System.Windows.Forms.DateTimePicker dtPublicHolidayDate;
        private System.Windows.Forms.Button cmdDeleteGroup;
        private System.Windows.Forms.Button cmdAddGroup;
        private System.Windows.Forms.TextBox txtPhId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clHolidayName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clHolidayDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clPhId;
        private System.Windows.Forms.Button cmdNewGroup;
        private System.Windows.Forms.Label label1;
    }
}