namespace Liquid.Finder
{
    partial class CustomerFinder
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
            this.gcPersons = new DevExpress.XtraGrid.GridControl();
            this.gvPersons = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.columnCustomerCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.columnCustomerDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.columnCreditLimit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.columnAccountOpened = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gcPersons)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPersons)).BeginInit();
            this.SuspendLayout();
            // 
            // gcPersons
            // 
            this.gcPersons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcPersons.Location = new System.Drawing.Point(0, 0);
            this.gcPersons.MainView = this.gvPersons;
            this.gcPersons.Name = "gcPersons";
            this.gcPersons.Size = new System.Drawing.Size(653, 400);
            this.gcPersons.TabIndex = 0;
            this.gcPersons.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvPersons});
            // 
            // gvPersons
            // 
            this.gvPersons.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.columnCustomerCode,
            this.columnCustomerDescription,
            this.columnCreditLimit,
            this.columnAccountOpened});
            this.gvPersons.GridControl = this.gcPersons;
            this.gvPersons.Name = "gvPersons";
            this.gvPersons.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gvPersons.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gvPersons.OptionsBehavior.Editable = false;
            this.gvPersons.OptionsBehavior.ReadOnly = true;
            this.gvPersons.OptionsCustomization.AllowColumnMoving = false;
            this.gvPersons.OptionsCustomization.AllowColumnResizing = false;
            this.gvPersons.OptionsCustomization.AllowQuickHideColumns = false;
            this.gvPersons.OptionsFilter.ShowAllTableValuesInFilterPopup = true;
            this.gvPersons.OptionsFind.AlwaysVisible = true;
            this.gvPersons.OptionsFind.FindMode = DevExpress.XtraEditors.FindMode.Always;
            this.gvPersons.OptionsFind.ShowCloseButton = false;
            this.gvPersons.OptionsFind.ShowFindButton = false;
            this.gvPersons.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gvPersons_RowClick);
            // 
            // columnCustomerCode
            // 
            this.columnCustomerCode.Caption = "Customer Code";
            this.columnCustomerCode.FieldName = "CustomerCode";
            this.columnCustomerCode.Name = "columnCustomerCode";
            this.columnCustomerCode.Visible = true;
            this.columnCustomerCode.VisibleIndex = 0;
            // 
            // columnCustomerDescription
            // 
            this.columnCustomerDescription.Caption = "Customer Description";
            this.columnCustomerDescription.FieldName = "CustomerDescription";
            this.columnCustomerDescription.Name = "columnCustomerDescription";
            this.columnCustomerDescription.Visible = true;
            this.columnCustomerDescription.VisibleIndex = 1;
            this.columnCustomerDescription.Width = 300;
            // 
            // columnCreditLimit
            // 
            this.columnCreditLimit.Caption = "Credit Limit";
            this.columnCreditLimit.FieldName = "CreditLimit";
            this.columnCreditLimit.Name = "columnCreditLimit";
            this.columnCreditLimit.Visible = true;
            this.columnCreditLimit.VisibleIndex = 2;
            // 
            // columnAccountOpened
            // 
            this.columnAccountOpened.Caption = "Account Opened";
            this.columnAccountOpened.DisplayFormat.FormatString = "d";
            this.columnAccountOpened.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.columnAccountOpened.FieldName = "AccountOpened";
            this.columnAccountOpened.Name = "columnAccountOpened";
            this.columnAccountOpened.Visible = true;
            this.columnAccountOpened.VisibleIndex = 3;
            // 
            // CustomerFinder
            // 
            this.ClientSize = new System.Drawing.Size(653, 400);
            this.Controls.Add(this.gcPersons);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CustomerFinder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.gcPersons)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPersons)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcPersons;
        private DevExpress.XtraGrid.Views.Grid.GridView gvPersons;
        private DevExpress.XtraGrid.Columns.GridColumn columnCustomerCode;
        private DevExpress.XtraGrid.Columns.GridColumn columnCustomerDescription;
        private DevExpress.XtraGrid.Columns.GridColumn columnCreditLimit;
        private DevExpress.XtraGrid.Columns.GridColumn columnAccountOpened;

    }
}