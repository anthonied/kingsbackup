using System;
using System.Collections.Generic;

namespace Liquid.Domain
{
    public class DeletedSalesOrders
    {
        public DateTime SalesOrderDate { get; set; }
        public string SalesOrderDocumentNumber { get; set; }
        public List<string> InvoiceNumbers { get; set; }
    }
}
