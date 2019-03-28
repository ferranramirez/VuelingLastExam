using System;
using System.Collections.Generic;
using System.Text;

namespace VuelingExam.Domain.BusinessEntities
{
    public class RateBE
    {
        public RateBE(string from, string to, decimal rate)
        {
            From = from;
            To = to;
            Rate = rate;
        }

        public string From { get; set; }
        public string To { get; set; }
        public decimal Rate { get; set; }
    }
}
