namespace Liquid.Forms
{
    partial class SpecialCustomerNotes
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
            this.dgCustomerSalesOrderNotes = new System.Windows.Forms.DataGridView();
            this.clItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clNotes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDeliveryCollection = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clSettlement = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clCustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clCustomerCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.clRemove = new System.Windows.Forms.DataGridViewButtonColumn();
            this.clId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgCustomerSalesOrderNotes)).BeginInit();
            this.SuspendLayout();
            // 
            // dgCustomerSalesOrderNotes
            // 
            this.dgCustomerSalesOrderNotes.AllowUserToAddRows = false;
            this.dgCustomerSalesOrderNotes.AllowUserToDeleteRows = false;
            this.dgCustomerSalesOrderNotes.AllowUserToResizeColumns = false;
            this.dgCustomerSalesOrderNotes.AllowUserToResizeRows = false;
            this.dgCustomerSalesOrderNotes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCustomerSalesOrderNotes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clItem,
            this.clPrice,
            this.clNotes,
            this.clDeliveryCollection,
            this.clSettlement,
            this.clCustomerName,
            this.clCustomerCode,
            this.clEdit,
            this.clRemove,
            this.clId});
            this.dgCustomerSalesOrderNotes.Location = new System.Drawing.Point(12, 12);
            this.dgCustomerSalesOrderNotes.MultiSelect = false;
            this.dgCustomerSalesOrderNotes.Name = "dgCustomerSalesOrderNotes";
            this.dgCustomerSalesOrderNotes.ReadOnly = true;
            this.dgCustomerSalesOrderNotes.RowHeadersVisible = false;
            this.dgCustomerSalesOrderNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgCustomerSalesOrderNotes.Size = new System.Drawing.Size(645, 272);
            this.dgCustomerSalesOrderNotes.TabIndex = 184;
            // 
            // clItem
            // 
            this.clItem.DataPropertyName = "Description";
            this.clItem.HeaderText = "Item / Discount";
            this.clItem.Name = "clItem";
            this.clItem.ReadOnly = true;
            this.clItem.Width = 150;
            // 
            // clPrice
            // 
            this.clPrice.DataPropertyName = "PriceExVat";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.clPrice.DefaultCellStyle = dataGridViewCellStyle1;
            this.clPrice.HeaderText = "Price";
            this.clPrice.Name = "clPrice";
            this.clPrice.ReadOnly = true;
            this.clPrice.Width = 65;
            // 
            // clNotes
            // 
            this.clNotes.DataPropertyName = "Note";
            this.clNotes.HeaderText = "Notes / Other";
            this.clNotes.Name = "clNotes";
            this.clNotes.ReadOnly = true;
            this.clNotes.Width = 180;
            // 
            // clDeliveryCollection
            // 
            this.clDeliveryCollection.DataPropertyName = "CollectionDeliveryNote";
            this.clDeliveryCollection.HeaderText = "Delivery / Collection";
            this.clDeliveryCollection.Name = "clDeliveryCollection";
            this.clDeliveryCollection.ReadOnly = true;
            this.clDeliveryCollection.Width = 160;
            // 
            // clSettlement
            // 
            this.clSettlement.DataPropertyName = "Settlement";
            this.clSettlement.HeaderText = "Settlement";
            this.clSettlement.Name = "clSettlement";
            this.clSettlement.ReadOnly = true;
            this.clSettlement.Width = 90;
            // 
            // clCustomerName
            // 
            this.clCustomerName.DataPropertyName = "CustomerName";
            this.clCustomerName.HeaderText = "Name";
            this.clCustomerName.Name = "clCustomerName";
            this.clCustomerName.ReadOnly = true;
            this.clCustomerName.Visible = false;
            this.clCustomerName.Width = 200;
            // 
            // clCustomerCode
            // 
            this.clCustomerCode.DataPropertyName = "CustomerCode";
            this.clCustomerCode.HeaderText = "Code";
            this.clCustomerCode.Name = "clCustomerCode";
            this.clCustomerCode.ReadOnly = true;
            this.clCustomerCode.Visible = false;
            this.clCustomerCode.Width = 65;
            // 
            // clEdit
            // 
            this.clEdit.DataPropertyName = "EditLabel";
            this.clEdit.HeaderText = "Edit";
            this.clEdit.Name = "clEdit";
            this.clEdit.ReadOnly = true;
            this.clEdit.Text = "Edit";
            this.clEdit.ToolTipText = "Edit this price list item.";
            this.clEdit.Visible = false;
            this.clEdit.Width = 50;
            // 
            // clRemove
            // 
            this.clRemove.DataPropertyName = "RemoveLabel";
            this.clRemove.HeaderText = "Remove";
            this.clRemove.Name = "clRemove";
            this.clRemove.ReadOnly = true;
            this.clRemove.Text = "Remove";
            this.clRemove.ToolTipText = "Delete this line from the price list";
            this.clRemove.Visible = false;
            this.clRemove.Width = 50;
            // 
            // clId
            // 
            this.clId.DataPropertyName = "Id";
            this.clId.HeaderText = "Id";
            this.clId.Name = "clId";
            this.clId.ReadOnly = true;
            this.clId.Visible = false;
            // 
            // SpecialCustomerNotes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 296);
            this.Controls.Add(this.dgCustomerSalesOrderNotes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SpecialCustomerNotes";
            this.Text = "Customer Notes";
            ((System.ComponentModel.ISupportInitialize)(this.dgCustomerSalesOrderNotes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgCustomerSalesOrderNotes;
        private System.Windows.Forms.DataGridViewTextBoxColumn clItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn clPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn clNotes;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDeliveryCollection;
        private System.Windows.Forms.DataGridViewTextBoxColumn clSettlement;
        private System.Windows.Forms.DataGridViewTextBoxColumn clCustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clCustomerCode;
        private System.Windows.Forms.DataGridViewButtonColumn clEdit;
        private System.Windows.Forms.DataGridViewButtonColumn clRemove;
        private System.Windows.Forms.DataGridViewTextBoxColumn clId;
    }
}