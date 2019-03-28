using System;

namespace VuelingExam.Application.DTO
{
    public class TransactionDTO
    {
        public TransactionDTO(string sku, decimal amount, string currency)
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
            var dTO = obj as TransactionDTO;
            return dTO != null &&
                   Sku == dTO.Sku &&
                   Amount == dTO.Amount &&
                   Currency == dTO.Currency;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Sku, Amount, Currency);
        }
    }
}
