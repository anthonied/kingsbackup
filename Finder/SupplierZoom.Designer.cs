namespace Liquid.Finder
{
    partial class SupplierZoom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SupplierZoom));
            this.dgSupplier = new System.Windows.Forms.DataGridView();
            this.clCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clContact = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clTel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cell = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gpFilters = new System.Windows.Forms.GroupBox();
            this.txtCellPhone = new System.Windows.Forms.TextBox();
            this.lblCell = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtTelephone = new System.Windows.Forms.TextBox();
            this.lblTelephone = new System.Windows.Forms.Label();
            this.txtContact = new System.Windows.Forms.TextBox();
            this.lblContact = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtAccountCode = new System.Windows.Forms.TextBox();
            this.cmdFilter = new System.Windows.Forms.Button();
            this.lblAccountCode = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgSupplier)).BeginInit();
            this.gpFilters.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgSupplier
            // 
            this.dgSupplier.AllowUserToAddRows = false;
            this.dgSupplier.AllowUserToDeleteRows = false;
            this.dgSupplier.AllowUserToResizeColumns = false;
            this.dgSupplier.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.GhostWhite;
            this.dgSupplier.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgSupplier.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgSupplier.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clCode,
            this.clDescription,
            this.clContact,
            this.clTel,
            this.clEmail,
            this.Cell});
            this.dgSupplier.Location = new System.Drawing.Point(16, 97);
            this.dgSupplier.Name = "dgSupplier";
            this.dgSupplier.ReadOnly = true;
            this.dgSupplier.RowHeadersVisible = false;
            this.dgSupplier.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgSupplier.Size = new System.Drawing.Size(720, 333);
            this.dgSupplier.TabIndex = 6;
            this.dgSupplier.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgSupplier_CellDoubleClick);
            this.dgSupplier.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgSupplier_KeyDown);
            this.dgSupplier.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgSupplier_KeyPress);
            // 
            // clCode
            // 
            this.clCode.DataPropertyName = "SupplCode";
            this.clCode.HeaderText = "Code";
            this.clCode.Name = "clCode";
            this.clCode.ReadOnly = true;
            this.clCode.Width = 75;
            // 
            // clDescription
            // 
            this.clDescription.DataPropertyName = "SupplDesc";
            this.clDescription.HeaderText = "Description";
            this.clDescription.Name = "clDescription";
            this.clDescription.ReadOnly = true;
            this.clDescription.Width = 150;
            // 
            // clContact
            // 
            this.clContact.DataPropertyName = "Contact";
            this.clContact.HeaderText = "Contact";
            this.clContact.Name = "clContact";
            this.clContact.ReadOnly = true;
            this.clContact.Width = 150;
            // 
            // clTel
            // 
            this.clTel.DataPropertyName = "Telephone";
            this.clTel.HeaderText = "Telephone";
            this.clTel.Name = "clTel";
            this.clTel.ReadOnly = true;
            this.clTel.Width = 125;
            // 
            // clEmail
            // 
            this.clEmail.DataPropertyName = "Email";
            this.clEmail.HeaderText = "Email";
            this.clEmail.Name = "clEmail";
            this.clEmail.ReadOnly = true;
            this.clEmail.Width = 200;
            // 
            // Cell
            // 
            this.Cell.DataPropertyName = "Cellphone";
            this.Cell.HeaderText = "Cellphone";
            this.Cell.Name = "Cell";
            this.Cell.ReadOnly = true;
            this.Cell.Visible = false;
            // 
            // gpFilters
            // 
            this.gpFilters.Controls.Add(this.txtCellPhone);
            this.gpFilters.Controls.Add(this.lblCell);
            this.gpFilters.Controls.Add(this.txtEmail);
            this.gpFilters.Controls.Add(this.lblEmail);
            this.gpFilters.Controls.Add(this.txtTelephone);
            this.gpFilters.Controls.Add(this.lblTelephone);
            this.gpFilters.Controls.Add(this.txtContact);
            this.gpFilters.Controls.Add(this.lblContact);
            this.gpFilters.Controls.Add(this.txtDescription);
            this.gpFilters.Controls.Add(this.lblDescription);
            this.gpFilters.Controls.Add(this.txtAccountCode);
            this.gpFilters.Controls.Add(this.cmdFilter);
            this.gpFilters.Controls.Add(this.lblAccountCode);
            this.gpFilters.Location = new System.Drawing.Point(16, 20);
            this.gpFilters.Name = "gpFilters";
            this.gpFilters.Size = new System.Drawing.Size(720, 71);
            this.gpFilters.TabIndex = 7;
            this.gpFilters.TabStop = false;
            this.gpFilters.Text = "Filter Results By";
            // 
            // txtCellPhone
            // 
            this.txtCellPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCellPhone.Location = new System.Drawing.Point(555, 46);
            this.txtCellPhone.MaxLength = 6;
            this.txtCellPhone.Name = "txtCellPhone";
            this.txtCellPhone.Size = new System.Drawing.Size(100, 20);
            this.txtCellPhone.TabIndex = 6;
            this.txtCellPhone.TextChanged += new System.EventHandler(this.txtAccountCode_TextChanged);
            this.txtCellPhone.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAccountCode_KeyDown);
            this.txtCellPhone.Enter += new System.EventHandler(this.txtAccountCode_Enter);
            // 
            // lblCell
            // 
            this.lblCell.AutoSize = true;
            this.lblCell.Location = new System.Drawing.Point(474, 49);
            this.lblCell.Name = "lblCell";
            this.lblCell.Size = new System.Drawing.Size(58, 13);
            this.lblCell.TabIndex = 0;
            this.lblCell.Text = "Cell Phone";
            // 
            // txtEmail
            // 
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmail.Location = new System.Drawing.Point(555, 20);
            this.txtEmail.MaxLength = 6;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(100, 20);
            this.txtEmail.TabIndex = 5;
            this.txtEmail.TextChanged += new System.EventHandler(this.txtAccountCode_TextChanged);
            this.txtEmail.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAccountCode_KeyDown);
            this.txtEmail.Enter += new System.EventHandler(this.txtAccountCode_Enter);
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(474, 23);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(35, 13);
            this.lblEmail.TabIndex = 0;
            this.lblEmail.Text = "E-mail";
            // 
            // txtTelephone
            // 
            this.txtTelephone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTelephone.Location = new System.Drawing.Point(328, 45);
            this.txtTelephone.MaxLength = 6;
            this.txtTelephone.Name = "txtTelephone";
            this.txtTelephone.Size = new System.Drawing.Size(100, 20);
            this.txtTelephone.TabIndex = 4;
            this.txtTelephone.TextChanged += new System.EventHandler(this.txtAccountCode_TextChanged);
            this.txtTelephone.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAccountCode_KeyDown);
            this.txtTelephone.Enter += new System.EventHandler(this.txtAccountCode_Enter);
            // 
            // lblTelephone
            // 
            this.lblTelephone.AutoSize = true;
            this.lblTelephone.Location = new System.Drawing.Point(247, 48);
            this.lblTelephone.Name = "lblTelephone";
            this.lblTelephone.Size = new System.Drawing.Size(58, 13);
            this.lblTelephone.TabIndex = 0;
            this.lblTelephone.Text = "Telephone";
            // 
            // txtContact
            // 
            this.txtContact.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtContact.Location = new System.Drawing.Point(328, 19);
            this.txtContact.MaxLength = 6;
            this.txtContact.Name = "txtContact";
            this.txtContact.Size = new System.Drawing.Size(100, 20);
            this.txtContact.TabIndex = 3;
            this.txtContact.TextChanged += new System.EventHandler(this.txtAccountCode_TextChanged);
            this.txtContact.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAccountCode_KeyDown);
            this.txtContact.Enter += new System.EventHandler(this.txtAccountCode_Enter);
            // 
            // lblContact
            // 
            this.lblContact.AutoSize = true;
            this.lblContact.Location = new System.Drawing.Point(247, 22);
            this.lblContact.Name = "lblContact";
            this.lblContact.Size = new System.Drawing.Size(44, 13);
            this.lblContact.TabIndex = 0;
            this.lblContact.Text = "Contact";
            // 
            // txtDescription
            // 
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescription.Location = new System.Drawing.Point(100, 45);
            this.txtDescription.MaxLength = 6;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(100, 20);
            this.txtDescription.TabIndex = 2;
            this.txtDescription.TextChanged += new System.EventHandler(this.txtAccountCode_TextChanged);
            this.txtDescription.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAccountCode_KeyDown);
            this.txtDescription.Enter += new System.EventHandler(this.txtAccountCode_Enter);
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(19, 48);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(60, 13);
            this.lblDescription.TabIndex = 0;
            this.lblDescription.Text = "Description";
            // 
            // txtAccountCode
            // 
            this.txtAccountCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAccountCode.Location = new System.Drawing.Point(100, 19);
            this.txtAccountCode.MaxLength = 6;
            this.txtAccountCode.Name = "txtAccountCode";
            this.txtAccountCode.Size = new System.Drawing.Size(100, 20);
            this.txtAccountCode.TabIndex = 1;
            this.txtAccountCode.TextChanged += new System.EventHandler(this.txtAccountCode_TextChanged);
            this.txtAccountCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAccountCode_KeyDown);
            this.txtAccountCode.Enter += new System.EventHandler(this.txtAccountCode_Enter);
            // 
            // cmdFilter
            // 
            this.cmdFilter.BackColor = System.Drawing.Color.White;
            this.cmdFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdFilter.Image = ((System.Drawing.Image)(resources.GetObject("cmdFilter.Image")));
            this.cmdFilter.Location = new System.Drawing.Point(678, 17);
            this.cmdFilter.Name = "cmdFilter";
            this.cmdFilter.Size = new System.Drawing.Size(25, 23);
            this.cmdFilter.TabIndex = 7;
            this.cmdFilter.UseVisualStyleBackColor = false;
            this.cmdFilter.Click += new System.EventHandler(this.cmdFilter_Click);
            // 
            // lblAccountCode
            // 
            this.lblAccountCode.AutoSize = true;
            this.lblAccountCode.Location = new System.Drawing.Point(19, 22);
            this.lblAccountCode.Name = "lblAccountCode";
            this.lblAccountCode.Size = new System.Drawing.Size(75, 13);
            this.lblAccountCode.TabIndex = 0;
            this.lblAccountCode.Text = "Account Code";
            // 
            // SupplierZoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 450);
            this.Controls.Add(this.dgSupplier);
            this.Controls.Add(this.gpFilters);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SupplierZoom";
            this.Text = "Supplier Zoom";
            this.Load += new System.EventHandler(this.SupplierZoom_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgSupplier)).EndInit();
            this.gpFilters.ResumeLayout(false);
            this.gpFilters.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgSupplier;
        private System.Windows.Forms.GroupBox gpFilters;
        private System.Windows.Forms.TextBox txtCellPhone;
        private System.Windows.Forms.Label lblCell;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtTelephone;
        private System.Windows.Forms.Label lblTelephone;
        private System.Windows.Forms.TextBox txtContact;
        private System.Windows.Forms.Label lblContact;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtAccountCode;
        private System.Windows.Forms.Button cmdFilter;
        private System.Windows.Forms.Label lblAccountCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn clContact;
        private System.Windows.Forms.DataGridViewTextBoxColumn clTel;
        private System.Windows.Forms.DataGridViewTextBoxColumn clEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cell;
    }
}