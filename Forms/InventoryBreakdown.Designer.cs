namespace Liquid.Forms
{
    partial class InventoryBreakdown
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
            this.panel15 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblItemcode = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblQtyOnHand = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblNetMassPerUnit = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.lblQtySold = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblUnitNetMass = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblUnitPrice = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.lblQtyLeft = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblQtyOnOrder = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblUnit = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.lblTotalPrice = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lblPriceQtyOnOrder = new System.Windows.Forms.Label();
            this.panel15.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel15
            // 
            this.panel15.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel15.Controls.Add(this.label1);
            this.panel15.Controls.Add(this.lblItemcode);
            this.panel15.Location = new System.Drawing.Point(6, 8);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(526, 36);
            this.panel15.TabIndex = 45;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(641, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(257, 15);
            this.label1.TabIndex = 10;
            this.label1.Text = " Note that only returned items can be invoiced.";
            // 
            // lblItemcode
            // 
            this.lblItemcode.AutoSize = true;
            this.lblItemcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemcode.Location = new System.Drawing.Point(6, 9);
            this.lblItemcode.Name = "lblItemcode";
            this.lblItemcode.Size = new System.Drawing.Size(86, 16);
            this.lblItemcode.TabIndex = 9;
            this.lblItemcode.Text = "ITEMCODE";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 46;
            this.label2.Text = "Qty On Hand:";
            // 
            // lblQtyOnHand
            // 
            this.lblQtyOnHand.Location = new System.Drawing.Point(120, 25);
            this.lblQtyOnHand.Name = "lblQtyOnHand";
            this.lblQtyOnHand.Size = new System.Drawing.Size(50, 13);
            this.lblQtyOnHand.TabIndex = 47;
            this.lblQtyOnHand.Text = "0";
            this.lblQtyOnHand.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 13);
            this.label4.TabIndex = 48;
            this.label4.Text = "Net Mass Per Unit:";
            // 
            // lblNetMassPerUnit
            // 
            this.lblNetMassPerUnit.AutoSize = true;
            this.lblNetMassPerUnit.Location = new System.Drawing.Point(137, 25);
            this.lblNetMassPerUnit.Name = "lblNetMassPerUnit";
            this.lblNetMassPerUnit.Size = new System.Drawing.Size(13, 13);
            this.lblNetMassPerUnit.TabIndex = 49;
            this.lblNetMassPerUnit.Text = "0";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.lblQtySold);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.lblUnitNetMass);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lblNetMassPerUnit);
            this.groupBox1.Location = new System.Drawing.Point(6, 50);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(246, 112);
            this.groupBox1.TabIndex = 50;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Scale Info";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(11, 75);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 13);
            this.label10.TabIndex = 54;
            this.label10.Text = "Qty Sold:";
            // 
            // lblQtySold
            // 
            this.lblQtySold.AutoSize = true;
            this.lblQtySold.Location = new System.Drawing.Point(137, 75);
            this.lblQtySold.Name = "lblQtySold";
            this.lblQtySold.Size = new System.Drawing.Size(13, 13);
            this.lblQtySold.TabIndex = 55;
            this.lblQtySold.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 50);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 13);
            this.label8.TabIndex = 52;
            this.label8.Text = "Unit Net Mass:";
            // 
            // lblUnitNetMass
            // 
            this.lblUnitNetMass.AutoSize = true;
            this.lblUnitNetMass.Location = new System.Drawing.Point(137, 50);
            this.lblUnitNetMass.Name = "lblUnitNetMass";
            this.lblUnitNetMass.Size = new System.Drawing.Size(13, 13);
            this.lblUnitNetMass.TabIndex = 53;
            this.lblUnitNetMass.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(2, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 18);
            this.label6.TabIndex = 50;
            this.label6.Text = "Unit Price:";
            // 
            // lblUnitPrice
            // 
            this.lblUnitPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUnitPrice.Location = new System.Drawing.Point(161, 80);
            this.lblUnitPrice.Name = "lblUnitPrice";
            this.lblUnitPrice.Size = new System.Drawing.Size(78, 20);
            this.lblUnitPrice.TabIndex = 51;
            this.lblUnitPrice.Text = "0.00";
            this.lblUnitPrice.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.lblQtyLeft);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.lblQtyOnOrder);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.lblQtyOnHand);
            this.groupBox2.Location = new System.Drawing.Point(6, 168);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(246, 111);
            this.groupBox2.TabIndex = 51;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Inventory Levels";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(11, 75);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(47, 13);
            this.label14.TabIndex = 50;
            this.label14.Text = "Qty Left:";
            // 
            // lblQtyLeft
            // 
            this.lblQtyLeft.Location = new System.Drawing.Point(120, 75);
            this.lblQtyLeft.Name = "lblQtyLeft";
            this.lblQtyLeft.Size = new System.Drawing.Size(50, 13);
            this.lblQtyLeft.TabIndex = 51;
            this.lblQtyLeft.Text = "0";
            this.lblQtyLeft.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(11, 50);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(72, 13);
            this.label12.TabIndex = 48;
            this.label12.Text = "Qty On Order:";
            // 
            // lblQtyOnOrder
            // 
            this.lblQtyOnOrder.Location = new System.Drawing.Point(120, 50);
            this.lblQtyOnOrder.Name = "lblQtyOnOrder";
            this.lblQtyOnOrder.Size = new System.Drawing.Size(50, 13);
            this.lblQtyOnOrder.TabIndex = 49;
            this.lblQtyOnOrder.Text = "0";
            this.lblQtyOnOrder.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.lblUnit);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.lblTotalPrice);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.lblPriceQtyOnOrder);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.lblUnitPrice);
            this.groupBox3.Location = new System.Drawing.Point(258, 50);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(274, 229);
            this.groupBox3.TabIndex = 52;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Pricing";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(2, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 18);
            this.label3.TabIndex = 56;
            this.label3.Text = "Unit:";
            // 
            // lblUnit
            // 
            this.lblUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUnit.Location = new System.Drawing.Point(162, 30);
            this.lblUnit.Name = "lblUnit";
            this.lblUnit.Size = new System.Drawing.Size(78, 20);
            this.lblUnit.TabIndex = 57;
            this.lblUnit.Text = "EACH";
            this.lblUnit.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(2, 180);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(83, 18);
            this.label18.TabIndex = 54;
            this.label18.Text = "Total Price:";
            // 
            // lblTotalPrice
            // 
            this.lblTotalPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPrice.Location = new System.Drawing.Point(170, 180);
            this.lblTotalPrice.Name = "lblTotalPrice";
            this.lblTotalPrice.Size = new System.Drawing.Size(67, 20);
            this.lblTotalPrice.TabIndex = 55;
            this.lblTotalPrice.Text = "0.00";
            this.lblTotalPrice.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(2, 130);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(101, 18);
            this.label16.TabIndex = 52;
            this.label16.Text = "Qty On Order:";
            // 
            // lblPriceQtyOnOrder
            // 
            this.lblPriceQtyOnOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPriceQtyOnOrder.Location = new System.Drawing.Point(182, 130);
            this.lblPriceQtyOnOrder.Name = "lblPriceQtyOnOrder";
            this.lblPriceQtyOnOrder.Size = new System.Drawing.Size(55, 20);
            this.lblPriceQtyOnOrder.TabIndex = 53;
            this.lblPriceQtyOnOrder.Text = "0";
            this.lblPriceQtyOnOrder.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // InventoryBreakdown
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(539, 292);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel15);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "InventoryBreakdown";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Inventory Breakdown";
            this.Load += new System.EventHandler(this.InventoryBreakdown_Load);
            this.panel15.ResumeLayout(false);
            this.panel15.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel15;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblQtyOnHand;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblNetMassPerUnit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblUnitNetMass;
        private System.Windows.Forms.Label lblUnitPrice;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblQtySold;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblQtyLeft;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblQtyOnOrder;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label lblTotalPrice;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblPriceQtyOnOrder;
        public System.Windows.Forms.Label lblItemcode;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label lblUnit;
    }
}