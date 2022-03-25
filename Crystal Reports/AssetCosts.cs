using System.Windows.Forms;

namespace Liquid.Crystal_Reports
{
    public partial class AssetCosts : Form
    {
        public AssetCosts()
        {
            InitializeComponent();
        }

        public void printThisDocument()
        {
            crystalReportViewerAssetCosts.PrintReport();

            this.Close();
        }
    }
}