using System;
using System.Windows.Forms;
using Liquid.CommRepository.Enums;
using Liquid.Domain;
using Liquid.Repository;
using Liquid.Classes;

namespace Liquid.Finder
{
    public partial class MarketerZoom : Form
    {
        public MarketerZoom()
        {
            InitializeComponent();
        }

        public string sMarketerCode = "";
        public string sDescription = "";

        private void LoadGridDetails()
        {
            dgMarketerZoom.Rows.Clear();
            RepoContext.LiquidConnectionString = Connect.LiquidConnectionString;
            RepoContext.PastelConnectionString = Connect.PastelConnectionString;

            using (var marketerRepository = new MarketerRepository(ConnectionType.Liquid, Connect.LiquidConnectionString, Connect.PastelConnectionString))
            {
                var marketers = marketerRepository.GetAllMarketers();
                foreach (var marketer in marketers)
                {
                    var n = dgMarketerZoom.Rows.Add();
                    dgMarketerZoom.Rows[n].Cells[0].Value = marketer.Code;
                    dgMarketerZoom.Rows[n].Cells[1].Value = marketer.Name;
                }
            }
       }


        private void dgMarketerZoom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;           
                if (dgMarketerZoom.Rows.Count > 0)
                {
                    sMarketerCode = dgMarketerZoom.SelectedRows[0].Cells[0].Value.ToString();
                    sDescription = dgMarketerZoom.SelectedRows[0].Cells[1].Value.ToString();                                    
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }			
        }

        private void dgMarketerZoom_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            sMarketerCode = dgMarketerZoom.SelectedRows[0].Cells[0].Value.ToString();
            sDescription = dgMarketerZoom.SelectedRows[0].Cells[1].Value.ToString();         
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void MarketerZoom_Load(object sender, EventArgs e)
        {
            LoadGridDetails();
        }
    }
}
