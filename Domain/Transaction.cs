using System;
namespace Liquid.Domain
{    
    public abstract class Transaction
    {
        public DateTime TransDate { get; set; }
        public string ClientCode { get; set; }
        public string Reference { get; set; }
        public string Description { get; set; }
        public  decimal Value { get; set; }
        public decimal Balance { get; set; }
        public abstract decimal DebitValue { get;}
        public abstract decimal CreditValue { get;}
    }
    
    public class DebitTransaction : Transaction //inherent of "Transaction"
    {
        public override decimal DebitValue
        {
            get
            {
                return Value;
            }
        }
        public override decimal CreditValue 
        {
            get
            {
                return 0m;
            }            
        }
    }

    public class CreditTransaction : Transaction //inherent of "Transaction"
    {
        public override decimal DebitValue
        {
            get
            {
                return 0m;
            }            
        }
        public override decimal CreditValue
        {
            get
            {
                return Value;
            }            
        }
    }

}
