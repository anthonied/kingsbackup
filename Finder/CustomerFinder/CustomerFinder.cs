using Liquid.Domain;
using System.Windows.Forms;

namespace Liquid.Finder
{
    public partial class CustomerFinder : Form
    {
        public FinderViewModel ViewModel; 

        public CustomerFinder()
        {
            InitializeComponent();
        }

        public CustomerFinder(string connectionString, Customer startCustomer)
        {
            InitializeComponent();
            ViewModel = new FinderViewModel(connectionString, startCustomer);

            gcPersons.DataSource = ViewModel.AllCustomers;            
        }
        
        private void gvPersons_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            
            _setSelectedCustomer(e.RowHandle);
            this.Close();
        }

        private void _setSelectedCustomer(int dataRowIndex)
        {
            //ViewModel.SetSelectedCustomer((dynamic)gvPersons.GetRow(dataRowIndex));    
        }
    }
}
