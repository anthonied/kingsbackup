using Liquid.Classes;
using Liquid.Repository;
using System;
using System.Windows.Forms;

namespace Liquid.Finder
{
    public partial class JobCodeZoom : Form
    {
        public string sJobCode =  "";
        public string sDescripion = "";

        //private BindingSource bindingSource;

        public JobCodeZoom()
        {
            InitializeComponent();
        }

        private void JobCodeZoom_Load(object sender, EventArgs e)
        {
            LoadGridView();
            this.ActiveControl = txtCode;
        }

        private void LoadGridView()
        {
            using (var repo = new CostCodeRepository(Connect.LiquidConnectionString, Connect.PastelConnectionString))
            {
                var bindingSource = repo.GetBindingSource();
                dgvJobCodes.DataSource = bindingSource;
                dgvJobCodes.ClearSelection();
            }
        }

        private void dgvJobCodes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            sJobCode = dgvJobCodes.Rows[e.RowIndex].Cells["cJobCode"].Value.ToString();
            sDescripion = dgvJobCodes.Rows[e.RowIndex].Cells["cDescription"].Value.ToString();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        #region FILTERS

        private void txtCode_TextChanged(object sender, EventArgs e)
        {
            string sFilter = "(JobCode LIKE '%" + txtCode.Text.Replace("'", "''") + "%' OR '" + txtCode.Text.Replace("'", "''") + "' = '') ";
            var bindingSource = (BindingSource) dgvJobCodes.DataSource;
            bindingSource.Filter = sFilter;           
        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {
            string sFilter = "(Description LIKE '%" + txtDescription.Text.Replace("'", "''") + "%' OR '" + txtDescription.Text.Replace("'", "''") + "' = '') ";
            var bindingSource = (BindingSource)dgvJobCodes.DataSource;
            bindingSource.Filter = sFilter;
        }

        #endregion

        private void dgvJobCodes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                if (dgvJobCodes.Rows.Count > 0)
                {
                    sJobCode = dgvJobCodes.SelectedRows[0].Cells["cJobCode"].Value.ToString();
                    sDescripion = dgvJobCodes.SelectedRows[0].Cells["cDescription"].Value.ToString();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void txtCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                LoadGridView();
                txtCode_TextChanged(null, null);
                dgvJobCodes.Focus();
            }

            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
            {
                dgvJobCodes.Focus();
            }
        }
    }
}
