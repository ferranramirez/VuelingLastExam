using System;
using System.Collections.Generic;
using System.Text;

namespace VuelingExam.Domain.BusinessEntities
{
    public class TransactionBE
    {
        public TransactionBE(string sku, decimal amount, string currency)
        {
            Sku = sku;
            Amount = amount;
            Currency = currency;
        }

        public string Sku { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
    }
}
