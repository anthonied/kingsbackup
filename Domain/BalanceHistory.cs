namespace Liquid.Domain
{
    public class BalanceHistory
    {
        public decimal Days120 { get; set; }
        public decimal Days90 { get; set; }
        public decimal Days60 { get; set; }
        public decimal Days30 { get; set; }
        public decimal Current { get; set; }
        public decimal AmountDue { get; set; }
    }
}
