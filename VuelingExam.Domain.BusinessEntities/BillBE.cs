using System;
using System.Collections.Generic;
using System.Text;

namespace VuelingExam.Domain.BusinessEntities
{
    public class BillBE
    {
        public BillBE(decimal tipAmount, string currency, List<TipBE> tipList)
        {
            TipAmount = tipAmount;
            Currency = currency;
            TipList = tipList;
        }

        public decimal TipAmount { get; set; }
        public string Currency { get; set; }
        public List<TipBE> TipList { get; set; }

        public override bool Equals(object obj)
        {
            var bE = obj as BillBE;
            return bE != null &&
                   TipAmount == bE.TipAmount &&
                   Currency == bE.Currency;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(TipAmount, Currency, TipList);
        }
    }
}
