namespace Liquid.Finder
{
    partial class ProjectZoom
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtProjectDescription = new System.Windows.Forms.TextBox();
            this.txtProjectNumber = new System.Windows.Forms.TextBox();
            this.dgProjectZoom = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgProjectZoom)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtProjectDescription);
            this.groupBox1.Controls.Add(this.txtProjectNumber);
            this.groupBox1.Location = new System.Drawing.Point(20, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(450, 96);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter Results";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(181, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Description:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Project:";
            // 
            // txtProjectDescription
            // 
            this.txtProjectDescription.Location = new System.Drawing.Point(250, 42);
            this.txtProjectDescription.Name = "txtProjectDescription";
            this.txtProjectDescription.Size = new System.Drawing.Size(181, 20);
            this.txtProjectDescription.TabIndex = 2;
            this.txtProjectDescription.TextChanged += new System.EventHandler(this.txtProjectDescription_TextChanged);
            // 
            // txtProjectNumber
            // 
            this.txtProjectNumber.Location = new System.Drawing.Point(65, 42);
            this.txtProjectNumber.Name = "txtProjectNumber";
            this.txtProjectNumber.Size = new System.Drawing.Size(100, 20);
            this.txtProjectNumber.TabIndex = 1;
            this.txtProjectNumber.TextChanged += new System.EventHandler(this.txtProjectNumber_TextChanged);
            this.txtProjectNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtProjectNumber_KeyDown);
            // 
            // dgProjectZoom
            // 
            this.dgProjectZoom.AllowUserToAddRows = false;
            this.dgProjectZoom.AllowUserToDeleteRows = false;
            this.dgProjectZoom.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgProjectZoom.Location = new System.Drawing.Point(20, 122);
            this.dgProjectZoom.Name = "dgProjectZoom";
            this.dgProjectZoom.ReadOnly = true;
            this.dgProjectZoom.RowHeadersVisible = false;
            this.dgProjectZoom.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgProjectZoom.Size = new System.Drawing.Size(450, 394);
            this.dgProjectZoom.TabIndex = 1;
            this.dgProjectZoom.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgProjectZoom_CellContentClick);
            this.dgProjectZoom.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgProjectZoom_CellDoubleClick);
            this.dgProjectZoom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgProjectZoom_KeyDown);
            // 
            // ProjectZoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 528);
            this.Controls.Add(this.dgProjectZoom);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ProjectZoom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Project Zoom";
            this.Load += new System.EventHandler(this.ProjectZoom_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgProjectZoom)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtProjectDescription;
        private System.Windows.Forms.TextBox txtProjectNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgProjectZoom;
    }
}