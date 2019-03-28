using System;
using System.Collections.Generic;
using System.Text;

namespace VuelingExam.Infrastructure.DataModel
{
    public class TransactionDM
    {
        public string Sku { get; set; }
        public decimal Amount { get; set; }
        public decimal Currency { get; set; }
    }
}
