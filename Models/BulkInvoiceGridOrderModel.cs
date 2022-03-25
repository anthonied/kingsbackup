using Liquid.Domain;
using System;

namespace Liquid.Models
{
    public class BulkInvoiceGridOrderModel
    {
        public string DocumentNumber { get; set; }
        public string CustomerCode { get; set; }
        public string ConsolidateNumber { get; set; }
        public string DocumentDate { get; set; }
        public string LastInvoiceDate { get; set; }
        public string ContractDate { get; set; }
        public string Status { get; set; }
        public bool WasInvoicedBefore { get; set; }
        public bool HasOffHire { get; set; }
        public string OffHireStartDate { get; set; }
        public string OffHireEndDate { get; set; }
        public bool Close { get; set; }
        public int LockedStatus { get; set; }
        public string Preview { get; set; }

        private static string formatContractDate(DateTime contractDate)
        {
            return contractDate > new DateTime(1970, 1, 1) ? contractDate.ToString("yyyy-MM-dd") : "N/A";
        }

        public static BulkInvoiceGridOrderModel FromDomain(Salesorder salesorder)
        {
            return new BulkInvoiceGridOrderModel
            {
                DocumentNumber = salesorder.Header.DocumentNumber,
                CustomerCode = salesorder.Header.Customer.CustomerCode,
                ConsolidateNumber = salesorder.ConsolidateNumber,
                DocumentDate = salesorder.Header.DocumentDate.ToString("yyyy-MM-dd"),
                LastInvoiceDate =
                    salesorder.LastInvoiceDate > new DateTime(1970, 1, 1)
                        ? salesorder.LastInvoiceDate.ToString("yyyy-MM-dd")
                        : "N/A",
                ContractDate = formatContractDate(salesorder.ContractDate),
                Status = salesorder.Status.ToString().ToUpper(),
                WasInvoicedBefore = salesorder.WasInvoicedBefore,
                HasOffHire = salesorder.HasActiveCustomOffHire,
                OffHireStartDate = salesorder.OffHireStartDate.ToString(),
                OffHireEndDate = salesorder.OffHireEndDate.ToString(),
                Close = salesorder.Close,
                LockedStatus = salesorder.LockedStatus,
                Preview = salesorder.FirstLinePreview
            };
        }
    }
}