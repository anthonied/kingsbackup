using System;
using System.Windows.Forms;
using Pervasive.Data.SqlClient;

namespace Liquid.Finder
{
    public partial class AssetZoom : Form
    {
        public string sAssetNumber = "";
        public string sDescription = "";
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
        public AssetZoom()
        {
            InitializeComponent();
        }

        private void AssetZoom_Load(object sender, EventArgs e)
        {
            BuildAssetDataGrid();
        }

        private void BuildAssetDataGrid()
        {
            dgAssetData.Rows.Clear();
            using (PsqlConnection oConn = new PsqlConnection(Liquid.Classes.Connect.LiquidConnectionString))
            {
                oConn.Open();

                string sSql = "select * from SOLAS ";
                sSql += "where AssetNumber like '%" + txtFilterAsset.Text + "%' ";
                sSql += "or Description like '%" + txtFilterAsset.Text + "%' ";
                sSql += "order by AssetNumber";

                PsqlDataReader rdReader = Liquid.Classes.Connect.getDataCommand(sSql,oConn).ExecuteReader();
                while (rdReader.Read())
                {
                    int n = dgAssetData.Rows.Add();
                    dgAssetData.Rows[n].Cells["clAssetNumber"].Value = rdReader["AssetNumber"].ToString().Trim();
                    dgAssetData.Rows[n].Cells["clDescription"].Value = rdReader["Description"].ToString().Trim();
                }
                rdReader.Close();
                oConn.Dispose();
            }

        }

        private void cmdAssetSearch_Click(object sender, EventArgs e)
        {
            BuildAssetDataGrid();
        }

        private void dgAssetData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            sAssetNumber = dgAssetData.Rows[e.RowIndex].Cells["clAssetNumber"].Value.ToString();
            sDescription = dgAssetData.Rows[e.RowIndex].Cells["clDescription"].Value.ToString();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void dgAssetData_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                if (dgAssetData.Rows.Count > 0)
                {
                    sAssetNumber = dgAssetData.SelectedRows[0].Cells["clAssetNumber"].Value.ToString();
                    sDescription = dgAssetData.SelectedRows[0].Cells["clDescription"].Value.ToString();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void dgAssetData_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtFilterAsset.Text += e.KeyChar.ToString();
            txtFilterAsset.Focus();
            txtFilterAsset.SelectionStart = txtFilterAsset.Text.Length;
            txtFilterAsset.SelectionLength = 0;
        }

        private void txtFilterAsset_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BuildAssetDataGrid();
            }
        }
    }
}