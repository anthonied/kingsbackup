using System;
using System.Windows.Forms;

namespace Liquid.Forms
{
	public partial class Downtime : Form
	{
		public Downtime()
		{
			InitializeComponent();
		}
		public double dDays = 0;
		public DateTime dtTo;
		public DateTime dtFrom;
        private bool bSaturdaysInvoice;
        private bool bSundaysInvoice;
		public DialogResult ShowDialog(string sAssetCode, DateTime dtStartDate,bool bInvoiceSaturdays, bool bInvoiceSundays)
		{
            bSaturdaysInvoice = bInvoiceSaturdays;
            bSundaysInvoice = bInvoiceSundays;
			lblAsset.Text = sAssetCode;
			dtDateFrom.Value = dtStartDate;
			dtDateTo.Value = dtStartDate;
            
			return this.ShowDialog();
           
		}

		private void dtDateFrom_ValueChanged(object sender, EventArgs e)
		{
            
			cmdSave.Enabled = true;
			dtDateTo.Value = new DateTime(dtDateTo.Value.Year, dtDateTo.Value.Month, dtDateTo.Value.Day, 0, 0, 0);
			dtDateFrom.Value = new DateTime(dtDateFrom.Value.Year, dtDateFrom.Value.Month, dtDateFrom.Value.Day, 0, 0, 0);

            if (dtDateFrom.Value <= dtDateTo.Value)
            {
                int iDays = ((TimeSpan)(dtDateTo.Value - dtDateFrom.Value)).Days;
                iDays++;  //include the startday
                int iSaturdays = 0;
                int iSundays = 0;
                if (!bSaturdaysInvoice)
                    iSaturdays = CountDays(DayOfWeek.Saturday, dtDateFrom.Value, dtDateTo.Value);
                if (!bSundaysInvoice)
                    iSundays = CountDays(DayOfWeek.Sunday, dtDateFrom.Value, dtDateTo.Value);
                iDays = iDays - iSaturdays - iSundays;

                if (iDays >= 0)
                {
                    txtDays.Text = Convert.ToDouble(iDays).ToString();
                }
                else
                {
                    txtDays.Text = "0";
                    //MessageBox.Show("To date must be after from date.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                txtDays.Text = "0";
            }
		}

        static int CountDays(DayOfWeek day, DateTime start, DateTime end)
        {
            TimeSpan ts = end - start; // Total duration
            int count = (int)Math.Floor(ts.TotalDays / 7);   // Number of whole weeks
            int remainder = (int)(ts.TotalDays % 7);         // Number of remaining days
            int sinceLastDay = (int)(end.DayOfWeek - day);   // Number of days since last [day]
            if (sinceLastDay < 0)
                sinceLastDay += 7;                           // Adjust for negative days since last [day]
            // If the days in excess of an even week are greater than or equal to the number days since the last [day], then count this one, too.
            if (remainder >= sinceLastDay)
                count++;
            return count;
        }

		private void txtDays_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (((e.KeyChar < '0') || (e.KeyChar > '9')) && e.KeyChar.ToString() != "\b" && e.KeyChar != '.')
			{
				e.Handled = true;
			}
		}

		private void cmdCancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.No;
			this.Close();
		}

		private void cmdSave_Click(object sender, EventArgs e)
		{
            if (dtDateFrom.Value <= dtDateTo.Value)
            {
                string sDays = txtDays.Text;
                if (sDays.Substring(sDays.Length - 1, 1) == ".")
                    sDays = sDays.Remove(sDays.Length - 1, 1);
                dtFrom = dtDateFrom.Value;
                //LL Date changes from selected to what is put in downtime. Removed adn added date
                //dtTo = dtFrom.AddDays(Convert.ToInt32(Convert.ToDouble(sDays)) -1);
                dtTo = dtDateTo.Value;
                this.DialogResult = DialogResult.OK;
                dDays = Convert.ToDouble(sDays);
                this.Close();
            }
            else
            {
                MessageBox.Show("To date must be after from date.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
		}

	

		

	

	}
}