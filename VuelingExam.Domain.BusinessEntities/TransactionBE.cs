using System;
using System.Collections.Generic;
using System.Text;

namespace VuelingExam.Domain.BusinessEntities
{
    public class TransactionBE
    {
        public string Sku { get; set; }
        public decimal Amount { get; set; }
        public decimal Tip { get; set; }
        public string Currency { get; set; }
    }
}
