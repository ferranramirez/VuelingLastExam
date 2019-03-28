using System;
using System.Collections.Generic;
using System.Text;

namespace VuelingExam.Infrastructure.DataModel
{
    public class RateDM
    {
        public RateDM(int rateId, string from, string to, decimal rate)
        {
            RateId = rateId;
            From = from;
            To = to;
            Rate = rate;
        }

        public int RateId { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public decimal Rate { get; set; }
    }
}
