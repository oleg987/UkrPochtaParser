using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UkrPochtaParser
{
    static class Calc
    {
        public static double GetShippingCost(double perParcel, double perKilo, double weight)
        {
            var x = (perKilo * weight + perParcel) * 1.2;
            return x;
        }
    }
}
