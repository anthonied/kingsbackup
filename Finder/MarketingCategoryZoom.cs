using System;
using System.Windows.Forms;
using Pervasive.Data.SqlClient;


namespace Liquid.Finder
{
    public partial class MarketingCategoryZoom : Form
    {
        public MarketingCategoryZoom()
        {
            InitializeComponent();
        }
        public string sResult = "";

        private void MarketingCategoryZoom_Load(object sender, EventArgs e)
        {
            LoadCategoryDetail();
        }

        private void LoadCategoryDetail()
        {
            dgCategories.Rows.Clear();
            using (PsqlConnection oConn = new PsqlConnection(Liquid.Classes.Connect.LiquidConnectionString))
            {
                oConn.Open();
                String sSql = "Select CategoryName, CategoryPercentage From SOLMARKCAT where CategoryName like '%" + txtCat.Text.Trim() + "%'";
                PsqlDataReader rdReader = Liquid.Classes.Connect.getDataCommand(sSql, oConn).ExecuteReader();
                while (rdReader.Read())
                {
                    int n = dgCategories.Rows.Add();
                    dgCategories.Rows[n].Cells[0].Value = rdReader[0].ToString();
                    dgCategories.Rows[n].Cells[1].Value = rdReader[1].ToString();
                }
                oConn.Dispose();
                rdReader.Close();
            }

        }

        private void txtCat_TextChanged(object sender, EventArgs e)
        {
            LoadCategoryDetail();
        }

        private void dgCategories_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            sResult = dgCategories.SelectedRows[0].Cells[0].Value.ToString();         
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
