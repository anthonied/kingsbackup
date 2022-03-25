using System;
using System.Data;
using System.Windows.Forms;
using Pervasive.Data.SqlClient;

namespace Liquid.Finder
{
    public partial class SDKUsers : Form
    {
        BindingSource bsSDKUsers;        
        public TextBox txtActive;

        public string sSelectedSDKUserCode = "";        
        public string sDescription = "";        
        public string sEmail = "";

        public Solsage_Pastel_API.solPastelSDK clsSDK = new Solsage_Pastel_API.solPastelSDK();

        const int WM_KEYDOWN = 0x100;
        const int WM_SYSKEYDOWN = 0x104;

        public SDKUsers()
        {
            InitializeComponent();
        }

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

        private void SDKUsers_Load(object sender, EventArgs e)
        {
            txtActive = txtCode;

            txtCode.CharacterCasing = CharacterCasing.Upper;
            txtDesc.CharacterCasing = CharacterCasing.Upper;
            txtEmail.CharacterCasing = CharacterCasing.Upper;

            loadSDKUsersGrid();
        }

        public DialogResult ShowDialog(string sSDKUserCode)
        {
            sSelectedSDKUserCode = sSDKUserCode;            
            
            return (this.ShowDialog());
        }

        private void loadSDKUsersGrid()
        {
            using (PsqlConnection oConn = new PsqlConnection(Liquid.Classes.Connect.PastelConnectionString))
            {
                oConn.Open();

                string sSql = "SELECT ID,Description,EmailAddress FROM AccountUser order by ID";
                dgvSDKUsers.AutoGenerateColumns = false;

                DataSet dsSDKUSers = Liquid.Classes.Connect.getDataSet(sSql, "SDKUsers", oConn);

                bsSDKUsers = new BindingSource();
                bsSDKUsers.DataSource = dsSDKUSers;
                bsSDKUsers.DataMember = dsSDKUSers.Tables[0].TableName;

                dgvSDKUsers.DataSource = bsSDKUsers;
            }

            dgvSDKUsers.Focus();
        }

        private void dgvSDKUsers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            sSelectedSDKUserCode = dgvSDKUsers.SelectedRows[0].Cells["clUserCode"].Value.ToString();
            sDescription = dgvSDKUsers.SelectedRows[0].Cells["clDescription"].Value.ToString();
            sEmail = dgvSDKUsers.SelectedRows[0].Cells["clEmail"].Value.ToString();          
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void dgvSDKUsers_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                if (dgvSDKUsers.Rows.Count > 0)
                {
                    sSelectedSDKUserCode = dgvSDKUsers.SelectedRows[0].Cells["clUserCode"].Value.ToString();
                    sDescription = dgvSDKUsers.SelectedRows[0].Cells["clDescription"].Value.ToString();
                    sEmail = dgvSDKUsers.SelectedRows[0].Cells["clEmail"].Value.ToString();

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }	
        }

        private void cmdFilter_Click(object sender, EventArgs e)
        {
            loadSDKUsersGrid();
        }

        private void txtCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                loadSDKUsersGrid();
            }

            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
            {
                dgvSDKUsers.Focus();
            }
        }

        private void dgvSDKUsers_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtCode_TextChanged(object sender, EventArgs e)
        {
            string sFilter = "(Convert(ID, 'System.String') LIKE '%" + txtCode.Text.Replace("'", "''") + "%' OR '" + txtCode.Text.Replace("'", "''") + "' = '') ";
            sFilter += " AND (Description LIKE '%" + txtDesc.Text.Replace("'", "''") + "%' OR '" + txtDesc.Text.Replace("'", "''") + "' = '') ";            
            sFilter += " AND (EmailAddress LIKE '%" + txtEmail.Text.Replace("'", "''") + "%' or '" + txtEmail.Text.Replace("'", "''") + "' = '') ";            

            bsSDKUsers.Filter = sFilter;
        }
    }
}