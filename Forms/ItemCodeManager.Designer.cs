namespace Liquid.Forms
{
    partial class ItemCodeManager
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
            this.lbActiveItems = new System.Windows.Forms.ListBox();
            this.lbBlockedItems = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFilterActiveCodes = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFilterBlockedCodes = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // lbActiveItems
            // 
            this.lbActiveItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbActiveItems.FormattingEnabled = true;
            this.lbActiveItems.ItemHeight = 16;
            this.lbActiveItems.Location = new System.Drawing.Point(18, 97);
            this.lbActiveItems.Name = "lbActiveItems";
            this.lbActiveItems.Size = new System.Drawing.Size(232, 516);
            this.lbActiveItems.TabIndex = 0;
            this.lbActiveItems.DoubleClick += new System.EventHandler(this.lbActiveItems_DoubleClick);
            // 
            // lbBlockedItems
            // 
            this.lbBlockedItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbBlockedItems.FormattingEnabled = true;
            this.lbBlockedItems.ItemHeight = 16;
            this.lbBlockedItems.Location = new System.Drawing.Point(23, 97);
            this.lbBlockedItems.Name = "lbBlockedItems";
            this.lbBlockedItems.Size = new System.Drawing.Size(232, 516);
            this.lbBlockedItems.TabIndex = 1;
            this.lbBlockedItems.DoubleClick += new System.EventHandler(this.lbBlockedItems_DoubleClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(20, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Itemcode:";
            // 
            // txtFilterActiveCodes
            // 
            this.txtFilterActiveCodes.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFilterActiveCodes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilterActiveCodes.Location = new System.Drawing.Point(95, 38);
            this.txtFilterActiveCodes.Name = "txtFilterActiveCodes";
            this.txtFilterActiveCodes.Size = new System.Drawing.Size(154, 22);
            this.txtFilterActiveCodes.TabIndex = 5;
            this.txtFilterActiveCodes.TextChanged += new System.EventHandler(this.txtFilterActiveCodes_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(25, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Itemcode:";
            // 
            // txtFilterBlockedCodes
            // 
            this.txtFilterBlockedCodes.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFilterBlockedCodes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilterBlockedCodes.Location = new System.Drawing.Point(106, 32);
            this.txtFilterBlockedCodes.Name = "txtFilterBlockedCodes";
            this.txtFilterBlockedCodes.Size = new System.Drawing.Size(144, 22);
            this.txtFilterBlockedCodes.TabIndex = 7;
            this.txtFilterBlockedCodes.TextChanged += new System.EventHandler(this.txtFilterBlockedCodes_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtFilterActiveCodes);
            this.groupBox1.Controls.Add(this.lbActiveItems);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(8, 53);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(277, 630);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Active Itemcodes:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtFilterBlockedCodes);
            this.groupBox2.Controls.Add(this.lbBlockedItems);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(343, 53);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(277, 630);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Blocked Itemcodes";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(296, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "*** Double click on item in left or right box to remove and add.";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Liquid.Properties.Resources.nav_left_blue;
            this.pictureBox1.Location = new System.Drawing.Point(304, 356);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(27, 28);
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Liquid.Properties.Resources.nav_right_blue;
            this.pictureBox2.Location = new System.Drawing.Point(303, 399);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(27, 28);
            this.pictureBox2.TabIndex = 12;
            this.pictureBox2.TabStop = false;
            // 
            // ItemCodeManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(633, 717);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ItemCodeManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Itemcode Manager";
            this.Load += new System.EventHandler(this.ItemCodeManager_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbActiveItems;
        private System.Windows.Forms.ListBox lbBlockedItems;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFilterActiveCodes;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFilterBlockedCodes;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;

    }
}