using System;
using System.Collections.Generic;
using System.Text;

namespace VuelingExam.Domain.BusinessEntities
{
    public class TipBE
    {
        public TipBE(string sku, decimal amount, decimal tip, string currency)
        {
            Sku = sku;
            Amount = amount;
            Tip = tip;
            Currency = currency;
        }

        public string Sku { get; set; }
        public decimal Amount { get; set; }
        public decimal Tip { get; set; }
        public string Currency { get; set; }

        public override bool Equals(object obj)
        {
            var bE = obj as TipBE;
            return bE != null &&
                   Sku == bE.Sku &&
                   Amount == bE.Amount &&
                   Tip == bE.Tip &&
                   Currency == bE.Currency;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Sku, Amount, Tip, Currency);
        }
    }
}
