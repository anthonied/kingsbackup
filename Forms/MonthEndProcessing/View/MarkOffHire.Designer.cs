namespace Liquid.Forms.MonthEndProcessing.View
{
    partial class MarkOffHire
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
            this.lblDeliveryNumber = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtOffHireStartDate = new System.Windows.Forms.DateTimePicker();
            this.dtOffHireEndDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmdSaveOffhireDates = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblDeliveryNumber
            // 
            this.lblDeliveryNumber.AutoSize = true;
            this.lblDeliveryNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeliveryNumber.Location = new System.Drawing.Point(132, 10);
            this.lblDeliveryNumber.Name = "lblDeliveryNumber";
            this.lblDeliveryNumber.Size = new System.Drawing.Size(71, 18);
            this.lblDeliveryNumber.TabIndex = 0;
            this.lblDeliveryNumber.Text = "#######";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Delivery Note Number:";
            // 
            // dtOffHireStartDate
            // 
            this.dtOffHireStartDate.Location = new System.Drawing.Point(15, 67);
            this.dtOffHireStartDate.Name = "dtOffHireStartDate";
            this.dtOffHireStartDate.Size = new System.Drawing.Size(200, 20);
            this.dtOffHireStartDate.TabIndex = 2;
            // 
            // dtOffHireEndDate
            // 
            this.dtOffHireEndDate.Location = new System.Drawing.Point(15, 116);
            this.dtOffHireEndDate.Name = "dtOffHireEndDate";
            this.dtOffHireEndDate.Size = new System.Drawing.Size(200, 20);
            this.dtOffHireEndDate.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Start Date:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "End Date:";
            // 
            // cmdSaveOffhireDates
            // 
            this.cmdSaveOffhireDates.Location = new System.Drawing.Point(15, 153);
            this.cmdSaveOffhireDates.Name = "cmdSaveOffhireDates";
            this.cmdSaveOffhireDates.Size = new System.Drawing.Size(200, 29);
            this.cmdSaveOffhireDates.TabIndex = 6;
            this.cmdSaveOffhireDates.Text = "Save";
            this.cmdSaveOffhireDates.UseVisualStyleBackColor = true;
            this.cmdSaveOffhireDates.Click += new System.EventHandler(this.cmdSaveOffhireDates_Click);
            // 
            // MarkOffHire
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(232, 204);
            this.Controls.Add(this.cmdSaveOffhireDates);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtOffHireEndDate);
            this.Controls.Add(this.dtOffHireStartDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblDeliveryNumber);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MarkOffHire";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mark Off-Hire Dates";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDeliveryNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtOffHireStartDate;
        private System.Windows.Forms.DateTimePicker dtOffHireEndDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button cmdSaveOffhireDates;
    }
}