namespace Liquid.Forms
{
    partial class SpecialPriceListSetup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SpecialPriceListSetup));
            this.dgSpecialPriceList = new System.Windows.Forms.DataGridView();
            this.clCustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clCustomerCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clNotes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDeliveryCollection = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clSettlement = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.clRemove = new System.Windows.Forms.DataGridViewButtonColumn();
            this.clId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtCurrentId = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSettlement = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDeliveryCollection = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPriceExVat = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtItemService = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCustomerDescription = new System.Windows.Forms.TextBox();
            this.cmdSearchCustomer = new System.Windows.Forms.Button();
            this.txtCustomerCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgSpecialPriceList)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgSpecialPriceList
            // 
            this.dgSpecialPriceList.AllowUserToAddRows = false;
            this.dgSpecialPriceList.AllowUserToDeleteRows = false;
            this.dgSpecialPriceList.AllowUserToResizeColumns = false;
            this.dgSpecialPriceList.AllowUserToResizeRows = false;
            this.dgSpecialPriceList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgSpecialPriceList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clCustomerName,
            this.clCustomerCode,
            this.clItem,
            this.clPrice,
            this.clNotes,
            this.clDeliveryCollection,
            this.clSettlement,
            this.clEdit,
            this.clRemove,
            this.clId});
            this.dgSpecialPriceList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgSpecialPriceList.Location = new System.Drawing.Point(0, 150);
            this.dgSpecialPriceList.Name = "dgSpecialPriceList";
            this.dgSpecialPriceList.RowHeadersVisible = false;
            this.dgSpecialPriceList.Size = new System.Drawing.Size(1046, 395);
            this.dgSpecialPriceList.TabIndex = 0;
            this.dgSpecialPriceList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgSpecialPriceList_CellContentClick);
            // 
            // clCustomerName
            // 
            this.clCustomerName.DataPropertyName = "CustomerName";
            this.clCustomerName.HeaderText = "Name";
            this.clCustomerName.Name = "clCustomerName";
            this.clCustomerName.Width = 200;
            // 
            // clCustomerCode
            // 
            this.clCustomerCode.DataPropertyName = "CustomerCode";
            this.clCustomerCode.HeaderText = "Code";
            this.clCustomerCode.Name = "clCustomerCode";
            this.clCustomerCode.Width = 65;
            // 
            // clItem
            // 
            this.clItem.DataPropertyName = "Description";
            this.clItem.HeaderText = "Item / Discount";
            this.clItem.Name = "clItem";
            this.clItem.Width = 175;
            // 
            // clPrice
            // 
            this.clPrice.DataPropertyName = "PriceExVat";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.clPrice.DefaultCellStyle = dataGridViewCellStyle1;
            this.clPrice.HeaderText = "Price Ex Vat";
            this.clPrice.Name = "clPrice";
            this.clPrice.Width = 65;
            // 
            // clNotes
            // 
            this.clNotes.DataPropertyName = "Note";
            this.clNotes.HeaderText = "Notes / Other";
            this.clNotes.Name = "clNotes";
            this.clNotes.Width = 220;
            // 
            // clDeliveryCollection
            // 
            this.clDeliveryCollection.DataPropertyName = "CollectionDeliveryNote";
            this.clDeliveryCollection.HeaderText = "Delivery / Collection";
            this.clDeliveryCollection.Name = "clDeliveryCollection";
            this.clDeliveryCollection.Width = 120;
            // 
            // clSettlement
            // 
            this.clSettlement.DataPropertyName = "Settlement";
            this.clSettlement.HeaderText = "Settlement";
            this.clSettlement.Name = "clSettlement";
            this.clSettlement.Width = 75;
            // 
            // clEdit
            // 
            this.clEdit.DataPropertyName = "EditLabel";
            this.clEdit.HeaderText = "Edit";
            this.clEdit.Name = "clEdit";
            this.clEdit.Text = "Edit";
            this.clEdit.ToolTipText = "Edit this price list item.";
            this.clEdit.Width = 50;
            // 
            // clRemove
            // 
            this.clRemove.DataPropertyName = "RemoveLabel";
            this.clRemove.HeaderText = "Remove";
            this.clRemove.Name = "clRemove";
            this.clRemove.Text = "Remove";
            this.clRemove.ToolTipText = "Delete this line from the price list";
            this.clRemove.Width = 50;
            // 
            // clId
            // 
            this.clId.DataPropertyName = "Id";
            this.clId.HeaderText = "Id";
            this.clId.Name = "clId";
            this.clId.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtCurrentId);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtSettlement);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtDeliveryCollection);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtPriceExVat);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtNote);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtItemService);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtCustomerDescription);
            this.groupBox1.Controls.Add(this.cmdSearchCustomer);
            this.groupBox1.Controls.Add(this.txtCustomerCode);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmdCancel);
            this.groupBox1.Controls.Add(this.cmdSave);
            this.groupBox1.Location = new System.Drawing.Point(5, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1034, 144);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // txtCurrentId
            // 
            this.txtCurrentId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCurrentId.Location = new System.Drawing.Point(915, 56);
            this.txtCurrentId.MaxLength = 6;
            this.txtCurrentId.Name = "txtCurrentId";
            this.txtCurrentId.Size = new System.Drawing.Size(82, 20);
            this.txtCurrentId.TabIndex = 501;
            this.txtCurrentId.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCurrentId.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(782, 92);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(16, 13);
            this.label8.TabIndex = 171;
            this.label8.Text = "%";
            // 
            // txtSettlement
            // 
            this.txtSettlement.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSettlement.Location = new System.Drawing.Point(694, 90);
            this.txtSettlement.MaxLength = 6;
            this.txtSettlement.Name = "txtSettlement";
            this.txtSettlement.Size = new System.Drawing.Size(82, 20);
            this.txtSettlement.TabIndex = 170;
            this.txtSettlement.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(582, 93);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 13);
            this.label7.TabIndex = 169;
            this.label7.Text = "Settlement:";
            // 
            // txtDeliveryCollection
            // 
            this.txtDeliveryCollection.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDeliveryCollection.Location = new System.Drawing.Point(694, 117);
            this.txtDeliveryCollection.MaxLength = 0;
            this.txtDeliveryCollection.Name = "txtDeliveryCollection";
            this.txtDeliveryCollection.Size = new System.Drawing.Size(180, 20);
            this.txtDeliveryCollection.TabIndex = 200;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(582, 120);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 13);
            this.label6.TabIndex = 167;
            this.label6.Text = "Delivery / Collection:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(673, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(16, 13);
            this.label5.TabIndex = 166;
            this.label5.Text = "R";
            // 
            // txtPriceExVat
            // 
            this.txtPriceExVat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPriceExVat.Location = new System.Drawing.Point(694, 60);
            this.txtPriceExVat.MaxLength = 8;
            this.txtPriceExVat.Name = "txtPriceExVat";
            this.txtPriceExVat.Size = new System.Drawing.Size(82, 20);
            this.txtPriceExVat.TabIndex = 165;
            this.txtPriceExVat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(582, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 164;
            this.label4.Text = "Price Ex Vat:";
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(137, 117);
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(421, 20);
            this.txtNote.TabIndex = 163;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 162;
            this.label3.Text = "Other / Note:";
            // 
            // txtItemService
            // 
            this.txtItemService.Location = new System.Drawing.Point(137, 90);
            this.txtItemService.Name = "txtItemService";
            this.txtItemService.Size = new System.Drawing.Size(421, 20);
            this.txtItemService.TabIndex = 161;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 13);
            this.label2.TabIndex = 160;
            this.label2.Text = "Item Service / Discount:";
            // 
            // txtCustomerDescription
            // 
            this.txtCustomerDescription.BackColor = System.Drawing.SystemColors.Control;
            this.txtCustomerDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustomerDescription.Location = new System.Drawing.Point(250, 61);
            this.txtCustomerDescription.Name = "txtCustomerDescription";
            this.txtCustomerDescription.ReadOnly = true;
            this.txtCustomerDescription.Size = new System.Drawing.Size(308, 20);
            this.txtCustomerDescription.TabIndex = 500;
            // 
            // cmdSearchCustomer
            // 
            this.cmdSearchCustomer.BackColor = System.Drawing.Color.White;
            this.cmdSearchCustomer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdSearchCustomer.Image = ((System.Drawing.Image)(resources.GetObject("cmdSearchCustomer.Image")));
            this.cmdSearchCustomer.Location = new System.Drawing.Point(219, 60);
            this.cmdSearchCustomer.Name = "cmdSearchCustomer";
            this.cmdSearchCustomer.Size = new System.Drawing.Size(25, 23);
            this.cmdSearchCustomer.TabIndex = 158;
            this.cmdSearchCustomer.UseVisualStyleBackColor = false;
            this.cmdSearchCustomer.Click += new System.EventHandler(this.cmdSearchCustomer_Click);
            // 
            // txtCustomerCode
            // 
            this.txtCustomerCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustomerCode.Location = new System.Drawing.Point(137, 61);
            this.txtCustomerCode.MaxLength = 6;
            this.txtCustomerCode.Name = "txtCustomerCode";
            this.txtCustomerCode.Size = new System.Drawing.Size(82, 20);
            this.txtCustomerCode.TabIndex = 157;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 156;
            this.label1.Text = "Customer:";
            // 
            // cmdCancel
            // 
            this.cmdCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdCancel.FlatAppearance.BorderSize = 0;
            this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdCancel.Image = ((System.Drawing.Image)(resources.GetObject("cmdCancel.Image")));
            this.cmdCancel.Location = new System.Drawing.Point(48, 27);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(24, 24);
            this.cmdCancel.TabIndex = 154;
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdSave
            // 
            this.cmdSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdSave.Enabled = false;
            this.cmdSave.FlatAppearance.BorderSize = 0;
            this.cmdSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdSave.Image = ((System.Drawing.Image)(resources.GetObject("cmdSave.Image")));
            this.cmdSave.Location = new System.Drawing.Point(15, 27);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(24, 24);
            this.cmdSave.TabIndex = 153;
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // SpecialPriceListSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1046, 545);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgSpecialPriceList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SpecialPriceListSetup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customer Notes";
            this.Load += new System.EventHandler(this.SpecialPriceListSetup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgSpecialPriceList)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgSpecialPriceList;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdSearchCustomer;
        private System.Windows.Forms.TextBox txtCustomerCode;
        private System.Windows.Forms.TextBox txtCustomerDescription;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtSettlement;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDeliveryCollection;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPriceExVat;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtItemService;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCurrentId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clCustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clCustomerCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn clPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn clNotes;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDeliveryCollection;
        private System.Windows.Forms.DataGridViewTextBoxColumn clSettlement;
        private System.Windows.Forms.DataGridViewButtonColumn clEdit;
        private System.Windows.Forms.DataGridViewButtonColumn clRemove;
        private System.Windows.Forms.DataGridViewTextBoxColumn clId;
    }
}