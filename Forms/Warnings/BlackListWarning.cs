using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Liquid.Forms.Warnings
{
    public partial class BlackListWarning : Form
    {
        public string blacklistId;
        public BlackListWarning(string Blacklist_ID)
        {
            InitializeComponent();
            blacklistId = Blacklist_ID;
        }

        private void llblViewProfile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            llblViewProfile.LinkVisited = true;
            string baseAddress = ConfigurationManager.AppSettings["KingsFraudFE"];
            System.Diagnostics.Process.Start($"{baseAddress}{blacklistId}");
        }
    }
}
