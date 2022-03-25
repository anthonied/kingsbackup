namespace Liquid.Forms
{
    partial class DeliveryMessageSetup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeliveryMessageSetup));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdSave = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgItemMessage = new System.Windows.Forms.DataGridView();
            this.ItemType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Prefix = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Message = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgItemMessage)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdCancel
            // 
            this.cmdCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdCancel.FlatAppearance.BorderSize = 0;
            this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdCancel.Image = ((System.Drawing.Image)(resources.GetObject("cmdCancel.Image")));
            this.cmdCancel.Location = new System.Drawing.Point(53, 12);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(24, 24);
            this.cmdCancel.TabIndex = 156;
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Visible = false;
            // 
            // cmdSave
            // 
            this.cmdSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdSave.FlatAppearance.BorderSize = 0;
            this.cmdSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdSave.Image = ((System.Drawing.Image)(resources.GetObject("cmdSave.Image")));
            this.cmdSave.Location = new System.Drawing.Point(21, 12);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(24, 24);
            this.cmdSave.TabIndex = 155;
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(21, 51);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(514, 60);
            this.panel1.TabIndex = 165;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(7, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(185, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "Item Messages On Delivery Note";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.dgItemMessage);
            this.panel2.Location = new System.Drawing.Point(21, 138);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(514, 355);
            this.panel2.TabIndex = 165;
            // 
            // dgItemMessage
            // 
            this.dgItemMessage.AllowUserToAddRows = false;
            this.dgItemMessage.AllowUserToDeleteRows = false;
            this.dgItemMessage.AllowUserToResizeRows = false;
            this.dgItemMessage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgItemMessage.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ItemType,
            this.Prefix,
            this.Message});
            this.dgItemMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgItemMessage.Location = new System.Drawing.Point(0, 0);
            this.dgItemMessage.Name = "dgItemMessage";
            this.dgItemMessage.RowHeadersVisible = false;
            this.dgItemMessage.Size = new System.Drawing.Size(512, 353);
            this.dgItemMessage.TabIndex = 0;
            // 
            // ItemType
            // 
            this.ItemType.DataPropertyName = "Name";
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ItemType.DefaultCellStyle = dataGridViewCellStyle1;
            this.ItemType.HeaderText = "Item Type";
            this.ItemType.Name = "ItemType";
            this.ItemType.ReadOnly = true;
            this.ItemType.Width = 120;
            // 
            // Prefix
            // 
            this.Prefix.DataPropertyName = "Prefix";
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Prefix.DefaultCellStyle = dataGridViewCellStyle2;
            this.Prefix.HeaderText = "Prefix";
            this.Prefix.Name = "Prefix";
            this.Prefix.ReadOnly = true;
            this.Prefix.Width = 50;
            // 
            // Message
            // 
            this.Message.DataPropertyName = "DeliveryNoteMessage";
            this.Message.HeaderText = "Message";
            this.Message.Name = "Message";
            this.Message.Width = 330;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(327, 122);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(207, 13);
            this.label1.TabIndex = 166;
            this.label1.Text = "Double click on the selected field to edit it.";
            // 
            // DeliveryMessageSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 525);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "DeliveryMessageSetup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Delivery Message Setup";
            this.Load += new System.EventHandler(this.DeliveryMessageSetup_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgItemMessage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgItemMessage;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Prefix;
        private System.Windows.Forms.DataGridViewTextBoxColumn Message;
        private System.Windows.Forms.Label label1;
    }
}