using System;
using System.Data;
using System.Windows.Forms;
using Pervasive.Data.SqlClient;

namespace Liquid.Finder
{
    public partial class SupplierZoom : Form
    {
        BindingSource bsSuppliers;
        public TextBox txtActive;

        public string sResult = "";
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

        public SupplierZoom()
        {
            InitializeComponent();
        }

        private void SupplierZoom_Load(object sender, EventArgs e)
        {
            txtActive = txtAccountCode;

            txtAccountCode.CharacterCasing = CharacterCasing.Upper;
            txtDescription.CharacterCasing = CharacterCasing.Upper;
            txtContact.CharacterCasing = CharacterCasing.Upper;
            loadSupplierGrid();
        }

        private void loadSupplierGrid()
        {
            //dgSupplier.Rows.Clear();
          
            PsqlConnection oConn = new PsqlConnection(Liquid.Classes.Connect.PastelConnectionString);
            oConn.Open();

            string sSql = "SELECT SupplCode, SupplDesc, Contact, Telephone, Email,Cellphone FROM SupplierMaster ";
            sSql += " WHERE (SupplCode LIKE '%" + txtAccountCode.Text + "%' OR '" + txtAccountCode.Text + "' = '') ";
            sSql += " AND (UPPER(SupplDesc) LIKE '%" + txtDescription.Text + "%' OR '" + txtDescription.Text + "' = '') ";
            sSql += " AND(UPPER(Contact) LIKE '%" + txtContact.Text + "%' OR '" + txtContact.Text + "' = '') ";
            sSql += " AND (REPLACE(Telephone,' ','') LIKE '%" + txtTelephone.Text.Replace(" ", "") + "%' OR '" + txtTelephone.Text.Replace(" ", "") + "' = '') ";
            sSql += " AND (Email LIKE '%" + txtEmail.Text + "%' OR '" + txtEmail.Text + "' = '') ";
            sSql += " AND (REPLACE(Cellphone,' ','') LIKE '%" + txtCellPhone.Text.Replace(" ", "") + "%' OR '" + txtCellPhone.Text + "' = '') ";
            sSql += " ORDER BY SupplCode ";

            //JR
            dgSupplier.AutoGenerateColumns = false;

            DataSet dsSuppliers = Liquid.Classes.Connect.getDataSet(sSql, "Suppliers", oConn);

            bsSuppliers = new BindingSource();
            bsSuppliers.DataSource = dsSuppliers;
            bsSuppliers.DataMember = dsSuppliers.Tables["Suppliers"].TableName;

            dgSupplier.DataSource = bsSuppliers;

           /*PsqlDataReader rdReader = Liquid.Classes.Connect.getDataCommand(sSql, oConn).ExecuteReader();
            while (rdReader.Read())
            {
                int n = dgSupplier.Rows.Add();
                dgSupplier.Rows[n].Cells["clCode"].Value = rdReader["SupplCode"].ToString();
                dgSupplier.Rows[n].Cells["clDescription"].Value = rdReader["SupplDesc"].ToString();
                dgSupplier.Rows[n].Cells["clContact"].Value = rdReader["Contact"].ToString();
                dgSupplier.Rows[n].Cells["clTel"].Value = rdReader["Telephone"].ToString();
                dgSupplier.Rows[n].Cells["clEmail"].Value = rdReader["Email"].ToString();
            }
            rdReader.Close();*/

            oConn.Dispose();
            dgSupplier.Focus();
        }

        private void dgSupplier_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            sResult = dgSupplier.SelectedRows[0].Cells["clCode"].Value.ToString();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void dgSupplier_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (dgSupplier.Rows.Count > 0)
                {
                    e.SuppressKeyPress = true;
                    if (dgSupplier.Rows.Count > 0)
                    {                        
                        sResult = dgSupplier.SelectedRows[0].Cells["clCode"].Value.ToString();
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
            }
            else
            {
                //if (e.KeyValue > 40)
                //{
                //    e.SuppressKeyPress = true;
                //    txtAccountCode.Text += char.ConvertFromUtf32(e.KeyValue).ToString();
                //    txtAccountCode.Focus();
                //    txtAccountCode.SelectionStart = txtAccountCode.Text.Length;
                //    txtAccountCode.SelectionLength = 0;
                //}

            }
        }

        private void txtAccountCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                loadSupplierGrid();
            }
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
            {
                dgSupplier.Focus();
            }
        }

        private void cmdFilter_Click(object sender, EventArgs e)
        {   
            loadSupplierGrid();
        }

        private void dgSupplier_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\t' && e.KeyChar != '\b')
                txtActive.Text += e.KeyChar.ToString();

            txtActive.Focus();
            txtActive.SelectionStart = txtActive.Text.Length;
            txtActive.SelectionLength = 0;
        }

        private void txtAccountCode_TextChanged(object sender, EventArgs e)
        {
            string sFilter = "(SupplCode LIKE '%" + txtAccountCode.Text.Replace("'", "''") + "%' OR '" + txtAccountCode.Text.Replace("'", "''") + "' = '') ";
            sFilter += " AND (SupplDesc LIKE '%" + txtDescription.Text.Replace("'", "''") + "%' OR '" + txtDescription.Text.Replace("'", "''") + "' = '') ";
            sFilter += " AND(Contact LIKE '%" + txtContact.Text.Replace("'", "''") + "%' OR '" + txtContact.Text.Replace("'", "''") + "' = '') ";
            sFilter += " AND (Telephone LIKE '%" + txtTelephone.Text.Replace(" ", "") + "%' OR '" + txtTelephone.Text.Replace(" ", "") + "' = '') ";
            sFilter += " AND (Email LIKE '%" + txtEmail.Text.Replace("'", "''") + "%' OR '" + txtEmail.Text.Replace("'", "''") + "' = '') ";
            sFilter += " AND (Cellphone LIKE '%" + txtCellPhone.Text.Replace(" ", "") + "%' OR '" + txtCellPhone.Text + "' = '') ";

            bsSuppliers.Filter = sFilter;
        }

        private void txtAccountCode_Enter(object sender, EventArgs e)
        {
            txtActive = (TextBox)sender;
        }

        
        
    }
}