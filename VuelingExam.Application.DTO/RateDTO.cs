using System;

namespace VuelingExam.Application.DTO
{
    public class RateDTO
    {
        public RateDTO(string from, string to, decimal rate)
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
            var dM = obj as RateDTO;
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
