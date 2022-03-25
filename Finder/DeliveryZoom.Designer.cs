﻿namespace Liquid.Finder
{
    partial class DeliveryZoom
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
            this.gpFilters = new System.Windows.Forms.GroupBox();
            this.txtCustomerCode = new System.Windows.Forms.TextBox();
            this.lblCustCode = new System.Windows.Forms.Label();
            this.txtDeliveryNote = new System.Windows.Forms.TextBox();
            this.lblSalesNumber = new System.Windows.Forms.Label();
            this.clCustCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDocNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgDeliveryZoom = new System.Windows.Forms.DataGridView();
            this.clDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gpFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDeliveryZoom)).BeginInit();
            this.SuspendLayout();
            // 
            // gpFilters
            // 
            this.gpFilters.Controls.Add(this.txtCustomerCode);
            this.gpFilters.Controls.Add(this.lblCustCode);
            this.gpFilters.Controls.Add(this.txtDeliveryNote);
            this.gpFilters.Controls.Add(this.lblSalesNumber);
            this.gpFilters.Location = new System.Drawing.Point(12, 12);
            this.gpFilters.Name = "gpFilters";
            this.gpFilters.Size = new System.Drawing.Size(431, 60);
            this.gpFilters.TabIndex = 10;
            this.gpFilters.TabStop = false;
            this.gpFilters.Text = "Filter Results By";
            // 
            // txtCustomerCode
            // 
            this.txtCustomerCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustomerCode.Location = new System.Drawing.Point(315, 26);
            this.txtCustomerCode.MaxLength = 8;
            this.txtCustomerCode.Name = "txtCustomerCode";
            this.txtCustomerCode.Size = new System.Drawing.Size(100, 20);
            this.txtCustomerCode.TabIndex = 2;
            this.txtCustomerCode.TextChanged += new System.EventHandler(this.txtCustomerCode_TextChanged);
            // 
            // lblCustCode
            // 
            this.lblCustCode.AutoSize = true;
            this.lblCustCode.Location = new System.Drawing.Point(222, 29);
            this.lblCustCode.Name = "lblCustCode";
            this.lblCustCode.Size = new System.Drawing.Size(79, 13);
            this.lblCustCode.TabIndex = 0;
            this.lblCustCode.Text = "Customer Code";
            // 
            // txtDeliveryNote
            // 
            this.txtDeliveryNote.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDeliveryNote.Location = new System.Drawing.Point(101, 25);
            this.txtDeliveryNote.MaxLength = 8;
            this.txtDeliveryNote.Name = "txtDeliveryNote";
            this.txtDeliveryNote.Size = new System.Drawing.Size(100, 20);
            this.txtDeliveryNote.TabIndex = 1;
            this.txtDeliveryNote.TextChanged += new System.EventHandler(this.txtDeliveryNote_TextChanged);
            this.txtDeliveryNote.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDeliveryNote_KeyDown);
            // 
            // lblSalesNumber
            // 
            this.lblSalesNumber.AutoSize = true;
            this.lblSalesNumber.Location = new System.Drawing.Point(20, 28);
            this.lblSalesNumber.Name = "lblSalesNumber";
            this.lblSalesNumber.Size = new System.Drawing.Size(71, 13);
            this.lblSalesNumber.TabIndex = 0;
            this.lblSalesNumber.Text = "Delivery Note";
            // 
            // clCustCode
            // 
            this.clCustCode.HeaderText = "Customer Code";
            this.clCustCode.Name = "clCustCode";
            this.clCustCode.ReadOnly = true;
            this.clCustCode.Width = 150;
            // 
            // clDocNumber
            // 
            this.clDocNumber.HeaderText = "Document Number";
            this.clDocNumber.Name = "clDocNumber";
            this.clDocNumber.ReadOnly = true;
            this.clDocNumber.Width = 125;
            // 
            // dgDeliveryZoom
            // 
            this.dgDeliveryZoom.AllowUserToAddRows = false;
            this.dgDeliveryZoom.AllowUserToDeleteRows = false;
            this.dgDeliveryZoom.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDeliveryZoom.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clDocNumber,
            this.clCustCode,
            this.clDate});
            this.dgDeliveryZoom.Location = new System.Drawing.Point(13, 83);
            this.dgDeliveryZoom.Name = "dgDeliveryZoom";
            this.dgDeliveryZoom.ReadOnly = true;
            this.dgDeliveryZoom.RowHeadersVisible = false;
            this.dgDeliveryZoom.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgDeliveryZoom.Size = new System.Drawing.Size(430, 440);
            this.dgDeliveryZoom.TabIndex = 11;
            this.dgDeliveryZoom.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgDeliveryZoom_CellDoubleClick);
            this.dgDeliveryZoom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgDeliveryZoom_KeyDown);
            // 
            // clDate
            // 
            this.clDate.HeaderText = "Date";
            this.clDate.Name = "clDate";
            this.clDate.ReadOnly = true;
            this.clDate.Width = 150;
            // 
            // DeliveryZoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 545);
            this.Controls.Add(this.gpFilters);
            this.Controls.Add(this.dgDeliveryZoom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "DeliveryZoom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Delivery Zoom";
            this.Load += new System.EventHandler(this.DeliveryZoom_Load);
            this.gpFilters.ResumeLayout(false);
            this.gpFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDeliveryZoom)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpFilters;
        private System.Windows.Forms.TextBox txtCustomerCode;
        private System.Windows.Forms.Label lblCustCode;
        private System.Windows.Forms.TextBox txtDeliveryNote;
        private System.Windows.Forms.Label lblSalesNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn clCustCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDocNumber;
        private System.Windows.Forms.DataGridView dgDeliveryZoom;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDate;
    }
}