namespace Liquid.Finder
{
    partial class UserZoom
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
            this.dgUserZoom = new System.Windows.Forms.DataGridView();
            this.clUserCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clLockOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Password = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clTelephoneNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clCreditInvoice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clCloseOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clCancelReturn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clShortName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clReturnItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgUserZoom)).BeginInit();
            this.SuspendLayout();
            // 
            // dgUserZoom
            // 
            this.dgUserZoom.AllowUserToAddRows = false;
            this.dgUserZoom.AllowUserToDeleteRows = false;
            this.dgUserZoom.AllowUserToResizeColumns = false;
            this.dgUserZoom.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.GhostWhite;
            this.dgUserZoom.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgUserZoom.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgUserZoom.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clUserCode,
            this.clLockOrder,
            this.clDescription,
            this.UserName,
            this.UserType,
            this.Password,
            this.clTelephoneNumber,
            this.clCreditInvoice,
            this.clCloseOrder,
            this.clCancelReturn,
            this.clShortName,
            this.clReturnItem});
            this.dgUserZoom.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dgUserZoom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgUserZoom.Location = new System.Drawing.Point(0, 0);
            this.dgUserZoom.Name = "dgUserZoom";
            this.dgUserZoom.RowHeadersVisible = false;
            this.dgUserZoom.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgUserZoom.Size = new System.Drawing.Size(656, 428);
            this.dgUserZoom.TabIndex = 0;
            this.dgUserZoom.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgUserZoom_CellContentDoubleClick);
            this.dgUserZoom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UserZoom_KeyDown);
            // 
            // clUserCode
            // 
            this.clUserCode.HeaderText = "User Code";
            this.clUserCode.Name = "clUserCode";
            this.clUserCode.ReadOnly = true;
            // 
            // clLockOrder
            // 
            this.clLockOrder.HeaderText = "Lock Order";
            this.clLockOrder.Name = "clLockOrder";
            this.clLockOrder.Visible = false;
            // 
            // clDescription
            // 
            this.clDescription.FillWeight = 150F;
            this.clDescription.HeaderText = "Description";
            this.clDescription.Name = "clDescription";
            this.clDescription.ReadOnly = true;
            this.clDescription.Width = 150;
            // 
            // UserName
            // 
            this.UserName.HeaderText = "Username";
            this.UserName.Name = "UserName";
            this.UserName.ReadOnly = true;
            // 
            // UserType
            // 
            this.UserType.HeaderText = "User Type";
            this.UserType.Name = "UserType";
            this.UserType.ReadOnly = true;
            // 
            // Password
            // 
            this.Password.HeaderText = "Password";
            this.Password.Name = "Password";
            this.Password.ReadOnly = true;
            this.Password.Visible = false;
            // 
            // clTelephoneNumber
            // 
            this.clTelephoneNumber.HeaderText = "Telephone Number";
            this.clTelephoneNumber.Name = "clTelephoneNumber";
            // 
            // clCreditInvoice
            // 
            this.clCreditInvoice.HeaderText = "Credit Invoice";
            this.clCreditInvoice.Name = "clCreditInvoice";
            // 
            // clCloseOrder
            // 
            this.clCloseOrder.HeaderText = "Close Order";
            this.clCloseOrder.Name = "clCloseOrder";
            this.clCloseOrder.ReadOnly = true;
            this.clCloseOrder.Visible = false;
            // 
            // clCancelReturn
            // 
            this.clCancelReturn.HeaderText = "cancel return";
            this.clCancelReturn.Name = "clCancelReturn";
            this.clCancelReturn.ReadOnly = true;
            this.clCancelReturn.Visible = false;
            // 
            // clShortName
            // 
            this.clShortName.HeaderText = "Short Name";
            this.clShortName.Name = "clShortName";
            this.clShortName.ReadOnly = true;
            this.clShortName.Visible = false;
            // 
            // clReturnItem
            // 
            this.clReturnItem.HeaderText = "ReturnItem";
            this.clReturnItem.Name = "clReturnItem";
            this.clReturnItem.Visible = false;
            // 
            // UserZoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 428);
            this.Controls.Add(this.dgUserZoom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UserZoom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User Zoom";
            this.Load += new System.EventHandler(this.UserZoom_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgUserZoom)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgUserZoom;
        private System.Windows.Forms.DataGridViewTextBoxColumn clUserCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clLockOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Password;
        private System.Windows.Forms.DataGridViewTextBoxColumn clTelephoneNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn clCreditInvoice;
        private System.Windows.Forms.DataGridViewTextBoxColumn clCloseOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn clCancelReturn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clShortName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clReturnItem;
    }
}