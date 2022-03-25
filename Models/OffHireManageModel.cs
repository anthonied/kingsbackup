using Liquid.Domain;
using System;

namespace Liquid.Models
{
    public class OffHireManageModel
    {
        public string DocumentNumber { get; set; }
        public string CustomerCode { get; set; }
        public string OffHireStartDate { get; set; }
        public string OffHireEndDate { get; set; }
        public string ProjectedDays { get; set; }
        public bool Selected { get; set; }
        public bool HasOffHire { get; set; }

        public static OffHireManageModel FromDomain(Salesorder salesorder, DateTime invoiceStartDate, DateTime invoiceEndDate)
        {
            var offhireDays = 0;
            if (salesorder.HasActiveCustomOffHire)
            {
                var offhireStart = new DateTime(Math.Max(salesorder.OffHireStartDate.Ticks, invoiceStartDate.Ticks));
                var offhireEnd = new DateTime(Math.Min(salesorder.OffHireEndDate.Ticks, invoiceEndDate.Ticks));
                offhireDays = (offhireEnd - offhireStart).Days;
            }
            return new OffHireManageModel
            {
                DocumentNumber = salesorder.Header.DocumentNumber,
                CustomerCode = salesorder.Header.Customer.CustomerCode,
                OffHireStartDate = salesorder.OffHireStartDate > new DateTime(1970, 01, 01) ? salesorder.OffHireStartDate.ToString("yyyy-MM-dd") : "",
                OffHireEndDate = salesorder.OffHireEndDate > new DateTime(1970, 01, 01) ? salesorder.OffHireEndDate.ToString("yyyy-MM-dd") : "",
                HasOffHire = salesorder.HasActiveCustomOffHire,
                ProjectedDays = offhireDays > 0 ? offhireDays.ToString() : "",
        };
        }
    }
}
