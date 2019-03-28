using System;

namespace VuelingExam.Application.DTO
{
    public class TipDTO
    {
        public TipDTO(string sku, decimal amount, decimal tip, string currency)
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
            var dTO = obj as TipDTO;
            return dTO != null &&
                   Sku == dTO.Sku &&
                   Amount == dTO.Amount &&
                   Tip == dTO.Tip &&
                   Currency == dTO.Currency;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Sku, Amount, Tip, Currency);
        }
    }
}