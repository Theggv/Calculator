using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3
{
    class Calculator
    {
        public static Fraction ChangeDomDen(Fraction a) //Change places of devider an denominator
        {
            int c = a.Divider;
            a.Numerator = a.Divider;
            a.Divider = c;
            return a;
        }
    }
}
