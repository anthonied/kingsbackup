using System;
using Pervasive.Data.SqlClient;
using System.Windows.Forms;

namespace Liquid.Forms
{
    public partial class PublicHoliday : Form
    {
        public PublicHoliday()
        {
            InitializeComponent();
        }

        private void PublicHoliday_Load(object sender, EventArgs e)
        {
            loadPublicHolidays();
        }
        
        private void loadPublicHolidays()
        {
            dgPublicHolidays.Rows.Clear();
            
            using (PsqlConnection oConn = new PsqlConnection(Liquid.Classes.Connect.LiquidConnectionString))
            {
                oConn.Open();
                string sSql = "select * from SOLPH";
                PsqlDataReader rdReader = Liquid.Classes.Connect.getDataCommand(sSql, oConn).ExecuteReader();
                while (rdReader.Read())
                {
                    int n = dgPublicHolidays.Rows.Add();
                    dgPublicHolidays.Rows[n].Cells[0].Value = rdReader["PublicHolidayName"].ToString();
                    dgPublicHolidays.Rows[n].Cells[1].Value = rdReader["PublicHolidayDate"].ToString();
                    dgPublicHolidays.Rows[n].Cells[2].Value = rdReader["id"].ToString(); 
                }
                rdReader.Close();
                oConn.Dispose();
            }
        }

        private void dgPublicHolidays_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cmdAddGroup_Click(object sender, EventArgs e)
        {
            if (txtPublicHolidayName.Text == "")
            {
                MessageBox.Show("Please Fill In Name of Public Holiday");
                return;
            }
                
            using (PsqlConnection oConn = new PsqlConnection(Liquid.Classes.Connect.LiquidConnectionString))
                {
                    oConn.Open();
                    if (txtPhId.Text == "")//new item
                    {
                        string sSql = "Insert into SOLPH (PublicHolidayName, PublicHolidayDate) VALUES ";
                        sSql += "(";
                        sSql += "'" + txtPublicHolidayName.Text + "'";
                        sSql += ",'" + dtPublicHolidayDate.Value.ToString("MM-dd-yyyy") + "'";
                        sSql += ")";
                        int iRet = Liquid.Classes.Connect.getDataCommand(sSql, oConn).ExecuteNonQuery();
                        sSql = "SELECT @@IDENTITY FROM SOLPH";
                        txtPhId.Text = Liquid.Classes.Connect.getDataCommand(sSql, oConn).ExecuteScalar().ToString();
                    }
                    else
                    {
                        string sSql = "Update SOLPH set ";
                        sSql += " PublicHolidayName  = '" + txtPublicHolidayName.Text + "'";
                        sSql += ", PublicHolidayDate = '" + dtPublicHolidayDate.Text + "'"; 
                        sSql += " where id = " + txtPhId.Text;

                        int iRet = Liquid.Classes.Connect.getDataCommand(sSql, oConn).ExecuteNonQuery();
                    }
                    oConn.Dispose();
                }

                loadPublicHolidays();
                cmdDeleteGroup.Enabled = true;
                int iRowIndex = 0;
                
                foreach (DataGridViewRow dgRow in dgPublicHolidays.Rows)
                {
                    if (dgRow.Cells["clPhId"].Value.ToString() == txtPhId.Text.Trim())
                    {
                        iRowIndex = dgRow.Index;
                    }
                }
                
                dgPublicHolidays.CurrentCell = dgPublicHolidays.Rows[iRowIndex].Cells[0];
        }

        private void cmdDeleteGroup_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This will permanently remove this Holiday. Are you sure?", "Remove Holiday", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (PsqlConnection oConn = new PsqlConnection(Liquid.Classes.Connect.LiquidConnectionString))
                {
                    string sSql = "delete from SOLPH where id = " + txtPhId.Text;
                    txtPublicHolidayName.Text = "";
                    dgPublicHolidays.Rows.Clear();
                    int ireturn = Liquid.Classes.Connect.getDataCommand(sSql, oConn).ExecuteNonQuery();
                    oConn.Dispose();
                }
                loadPublicHolidays();
            }
            txtPhId.Text = "";
            cmdDeleteGroup.Enabled = false;
        }

        private void dgPublicHolidays_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtPublicHolidayName.Text = dgPublicHolidays.Rows[e.RowIndex].Cells["clHolidayName"].Value.ToString();
            dtPublicHolidayDate.Value = Convert.ToDateTime(dgPublicHolidays.Rows[e.RowIndex].Cells["clHolidayDate"].Value.ToString());
            txtPhId.Text = dgPublicHolidays.Rows[e.RowIndex].Cells["clPhId"].Value.ToString();
            cmdDeleteGroup.Enabled = true;

        }

        private void cmdNewGroup_Click(object sender, EventArgs e)
        {
            txtPhId.Text = "";
            txtPublicHolidayName.Text = "";
            cmdDeleteGroup.Enabled = false;
        }

        
    }
}