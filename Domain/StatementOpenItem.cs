using System.Collections.Generic;

namespace Liquid.Domain
{
    public class StatementOpenItem
    {
        public string MatchRef { get; set; }
        public List<DebitTransaction> Debit  { get; set; }
        public List<CreditTransaction> Credit  { get; set; }
        public decimal Balance  { get; set; }
    }
}
