using Liquid.Domain;

namespace Liquid.Models
{
    public class SpecialPriceListEntryModel
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string CustomerCode { get; set; }
        public string Description { get; set; }
        public string PriceExVat { get; set; }
        public string Note { get; set; }
        public string CollectionDeliveryNote { get; set; }
        public string Settlement { get; set; }
        public string EditLabel { get { return "Edit"; } }
        public string RemoveLabel { get { return "Remove"; } }

        public static SpecialPriceListEntryModel FromDomain(SpecialPriceListEntry entry)
        {
            return new SpecialPriceListEntryModel
            {
                Id = entry.Id,
                CustomerName = entry.Customer.Description,
                CustomerCode = entry.Customer.CustomerCode,
                Description = entry.Description,
                PriceExVat = entry.PriceExVat == 0 ? "" : entry.PriceExVat.ToString("N2"),
                Note = entry.Note,
                CollectionDeliveryNote = entry.CollectionDeliveryNote,
                Settlement = entry.Settlement == 0 ? "" : entry.Settlement.ToString("0.00")
            };
        }
    }
}
