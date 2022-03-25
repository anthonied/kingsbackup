using System.Drawing;
using Liquid.Domain;

namespace Liquid.Models
{
    public class EmailAndPrintInvoiceModel
    {
        public string CustomerCode { get; set; }
        public string InvoiceNumber { get; set; }
        public string InvoiceDate { get; set; }
        public string EmailAddress { get; set; }
        public Bitmap EmailSent { get; set; }
        public int PrintInvoice { get; set; }
        public int ResendEmail { get; set; }


        public static EmailAndPrintInvoiceModel FromInvoiceHeaderDomain(InvoiceHeader invoiceHeader, bool wasEmailSent, DeliveryAddress customerDeliveryAddress, bool isvalidEmail)
        {
            return new EmailAndPrintInvoiceModel
            {
                CustomerCode = invoiceHeader.Customer.CustomerCode,
                InvoiceNumber = invoiceHeader.DocumentNumber,
                InvoiceDate = invoiceHeader.DocumentDate.ToString(),
                EmailAddress = customerDeliveryAddress.EmailAddress,
                EmailSent = !wasEmailSent ?  Liquid.Properties.Resources.delete21 :  Liquid.Properties.Resources.check21 ,
                PrintInvoice = isvalidEmail ? 0 : 1   ,
                ResendEmail = isvalidEmail  ? 1 : 0,

            };
        }

        
    }
}