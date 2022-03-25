using System;
using System.Data;
using System.Windows.Forms;
using Pervasive.Data.SqlClient;
using Liquid.Classes;

namespace Liquid.Finder
{
    public partial class ManuInventory : Form
    {
        public TextBox txtActive;

        public string sItemCode = "";
        public string sItemDesc = "";
        public string sItemUnit = "";

        DataSet dsInventory;
        BindingSource bsInventory;

        const int WM_KEYDOWN = 0x100;
        const int WM_SYSKEYDOWN = 0x104;

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            bool bHandled = false;
            if ((msg.Msg == WM_KEYDOWN) || (msg.Msg == WM_SYSKEYDOWN))
            {
                switch (keyData)
                {
                    case Keys.Escape:
                        this.Close();
                        break;
                }

            }
            return bHandled;
        }

        public ManuInventory()
        {
            InitializeComponent();
        }

        private void ManuInventory_Load(object sender, EventArgs e)
        {            
            DBLoadInventoryGrid();

            txtActive = txtCode;
            this.ActiveControl = txtCode;

        }

        public void DBLoadInventoryGrid()
        {
            try
            {
                dgvInventory.AutoGenerateColumns = false;
                dgvInventory.DataSource = null;

                string sSql = "";

                using (PsqlConnection pasConn = new PsqlConnection(Connect.PastelConnectionString))
                {
                    pasConn.Open();

                    sSql = "SELECT RTRIM(Category) As Category, RTRIM(ItemCode) As ItemCode, RTRIM(Description) AS Description, RTRIM(UnitSize) AS UnitSize, RTRIM(ICDesc) AS ICDesc";                    
                    sSql += " FROM Inventory";
                    sSql += " LEFT JOIN InventoryCategory ON ICCode = Category ";

                    dsInventory = Connect.getDataSet(sSql, "Inventory", pasConn);

                    bsInventory = new BindingSource();
                    bsInventory.DataSource = dsInventory;
                    bsInventory.DataMember = dsInventory.Tables["Inventory"].TableName;

                    dgvInventory.DataSource = bsInventory;
                    dgvInventory.ClearSelection();

                    pasConn.Close();
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show("Error Info: " + ex.Message, "Exception Occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        
        #region FILTERS

        private void txtCode_TextChanged(object sender, EventArgs e)
        {
            string sFilter = "(ItemCode LIKE '%" + txtCode.Text.Replace("'", "''") + "%' OR '" + txtCode.Text.Replace("'", "''") + "' = '') ";
            bsInventory.Filter = sFilter;
        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {
            string sFilter = "(Description LIKE '%" + txtDescription.Text.Replace("'", "''") + "%' OR '" + txtDescription.Text.Replace("'", "''") + "' = '') ";
            bsInventory.Filter = sFilter;
        }

        private void txtCategory_TextChanged(object sender, EventArgs e)
        {
            string sFilter = "(ICDesc LIKE '%" + txtCategory.Text.Replace("'", "''") + "%' OR '" + txtCategory.Text.Replace("'", "''") + "' = '') ";
            bsInventory.Filter = sFilter;
        }
        
        #endregion

        private void dgvInventory_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            sItemCode = dgvInventory.Rows[e.RowIndex].Cells["clItemCode"].Value.ToString();
            sItemDesc = dgvInventory.Rows[e.RowIndex].Cells["clDescription"].Value.ToString();
            sItemUnit = dgvInventory.Rows[e.RowIndex].Cells["clUnitSize"].Value.ToString();
        }
                       
        #region HANDLE KEY STROKES & NAVIGATION

        private void dgvInventory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                if (dgvInventory.Rows.Count > 0)
                {
                    sItemCode = dgvInventory.SelectedRows[0].Cells["clItemCode"].Value.ToString();
                    sItemDesc = dgvInventory.SelectedRows[0].Cells["clDescription"].Value.ToString();
                    sItemUnit = dgvInventory.SelectedRows[0].Cells["clUnitSize"].Value.ToString();

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void dgvInventory_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\t' && e.KeyChar != '\b')
                txtActive.Text += e.KeyChar.ToString();

            txtActive.Focus();

            txtActive.SelectionStart = txtCode.Text.Length;
            txtActive.SelectionLength = 0;
        }

        private void txtCode_Enter(object sender, EventArgs e)
        {
            txtActive = (TextBox)sender;
        }

        private void txtCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
            }

            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
            {
                dgvInventory.Focus();
            }
        }

        private void txtDescription_Enter(object sender, EventArgs e)
        {
            txtActive = (TextBox)sender;
        }

        private void txtDescription_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
            }

            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
            {
                dgvInventory.Focus();
            }
        }

        private void txtCategory_Enter(object sender, EventArgs e)
        {
            txtActive = (TextBox)sender;
        }

        private void txtCategory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
            }

            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
            {
                dgvInventory.Focus();
            }
        }

        #endregion



    }
}
