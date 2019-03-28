using System;
using System.Collections.Generic;
using System.Text;

namespace VuelingExam.Infrastructure.DataModel
{
    public class TransactionDM
    {
        public TransactionDM(string sku, decimal amount, string currency)
        {
            Sku = sku;
            Amount = amount;
            Currency = currency;
        }

        public string Sku { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }

        public override bool Equals(object obj)
        {
            var dM = obj as TransactionDM;
            return dM != null &&
                   Sku == dM.Sku &&
                   Amount == dM.Amount &&
                   Currency == dM.Currency;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Sku, Amount, Currency);
        }
    }
}
