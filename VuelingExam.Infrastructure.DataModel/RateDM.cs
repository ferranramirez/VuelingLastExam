using System;
using System.Collections.Generic;
using System.Text;

namespace VuelingExam.Infrastructure.DataModel
{
    public class RateDM
    {
        public RateDM(string from, string to, decimal rate)
        {
            From = from;
            To = to;
            Rate = rate;
        }

        public string From { get; set; }
        public string To { get; set; }
        public decimal Rate { get; set; }

        public override bool Equals(object obj)
        {
            var dM = obj as RateDM;
            return dM != null &&
                   From == dM.From &&
                   To == dM.To &&
                   Rate == dM.Rate;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(From, To, Rate);
        }
    }
}
