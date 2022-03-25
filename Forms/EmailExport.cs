using Liquid.Classes;
using Liquid.Repository;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace Liquid.Forms
{
    public partial class EmailExport : Form
    {
        private List<string> _uniqueEmailAddresses;

        public EmailExport()
        {
            InitializeComponent();
        }

        private void cmdExport_Click(object sender, EventArgs e)
        {
            var csvString = new StringBuilder();
            _uniqueEmailAddresses.ForEach(x =>
            {
                csvString.AppendLine($"\"{x}\"");
            });
            SaveCsv(csvString);
        }

        private static void SaveCsv(StringBuilder csv)
        {
            var saveDirectory = $"{Application.StartupPath}\\EmailAddressExport";
            var csvFileName = "EmailAddresses.csv";
            var fullPath = $"{saveDirectory}\\{csvFileName}";

            if (!Directory.Exists(saveDirectory))
                Directory.CreateDirectory(saveDirectory);

            var couldClean = DoCleanUp(fullPath, csvFileName);
            Thread.Sleep(500);
            if (!couldClean) return;

            File.WriteAllText(fullPath, csv.ToString());
            Process.Start(fullPath);
        }

        public static bool DoCleanUp(string fullPath, string csvFileName)
        {
            if (!File.Exists(fullPath)) return true;

            if (MessageBox.Show("Do you want to overwrite the existing email export file?",
                    "Alert", MessageBoxButtons.YesNo) == DialogResult.No)
                return false;

            var processes = Process.GetProcessesByName("Excel");
            foreach (var process in processes)
            {
                var isExcelfileExtention = process.MainWindowTitle == csvFileName + " - Excel";
                if (!isExcelfileExtention) continue;
                process.Kill();
                Thread.Sleep(200);
                File.Delete(fullPath);
                return true;
            }
            return true;
        }

        private void EmailExport_Load(object sender, EventArgs e)
        {
            var deliveryAddressRepo = new DeliveryAddressesRepository(Connect.LiquidConnectionString, Connect.PastelConnectionString);
            var allEmailAddresses = deliveryAddressRepo.GetAll();
            _uniqueEmailAddresses = allEmailAddresses.Where(x => x.EmailAddress != "").Select(deliveryAddress => deliveryAddress.EmailAddress).Distinct().ToList();
            _uniqueEmailAddresses.Sort();
            lblUniqueCount.Text = _uniqueEmailAddresses.Count().ToString();
        }
    }
}
