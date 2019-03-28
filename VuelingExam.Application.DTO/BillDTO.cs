using System;
using System.Collections.Generic;
using System.Text;

namespace VuelingExam.Application.DTO
{
    public class BillDTO
    {
        public BillDTO(decimal tipAmount, string currency, List<TipDTO> tipList)
        {
            TipAmount = tipAmount;
            Currency = currency;
            TipList = tipList;
        }

        public decimal TipAmount { get; set; }
        public string Currency { get; set; }
        public List<TipDTO> TipList { get; set; }

        public override bool Equals(object obj)
        {
            var dTO = obj as BillDTO;
            return dTO != null &&
                   TipAmount == dTO.TipAmount &&
                   Currency == dTO.Currency;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(TipAmount, Currency, TipList);
        }
    }
}
