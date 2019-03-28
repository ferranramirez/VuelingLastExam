using System;
using System.Collections.Generic;
using System.Text;

namespace VuelingExam.Domain.BusinessEntities
{
    public class Pair
    {
        public Pair(string first, decimal second)
        {
            First = first;
            Second = second;
        }
        public string First { get; set; }
        public decimal Second { get; set; }
    }
}
