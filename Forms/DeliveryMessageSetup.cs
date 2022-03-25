using Liquid.Domain;
using Liquid.Repository;
using Liquid.Classes;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Liquid.Forms
{
    public partial class DeliveryMessageSetup : Form
    {
        private List<ItemCategory> _itemCategories;

        public DeliveryMessageSetup()
        {
            InitializeComponent();
        }

        private void DeliveryMessageSetup_Load(object sender, EventArgs e)
        {
            var itemRepository = new ItemRepository(Connect.LiquidConnectionString, Connect.PastelConnectionString);

            if (noItemsInDatabase(itemRepository))
            {
                _itemCategories = itemRepository.GetInitialItemCategories();
                itemRepository.SaveDeliveryNoteMessages(_itemCategories);
            }
            else
                _itemCategories = itemRepository.GetItemCategoriesFromDatabase();
            dgItemMessage.DataSource = _itemCategories;

        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            var itemRepository = new ItemRepository(Connect.LiquidConnectionString, Connect.PastelConnectionString);
            
            itemRepository.SaveDeliveryNoteMessages(_itemCategories);
        }
        private bool noItemsInDatabase(ItemRepository itemRepository)
        {
            return itemRepository.GetItemCount() == 0;
        }
    }
}
