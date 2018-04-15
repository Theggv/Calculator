using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3
{
    public class Calculator
    {
        public static Fraction ChangeDomDen(Fraction a) //Change places of devider an Numerator
        {
            int c = a.Numerator;
            a.Divider = a.Numerator;
            a.Numerator = c;

            return a;
        }

        public static Fraction Exponent(Fraction a, int exp)
        {
            a.Numerator = (int)Math.Pow(a.Numerator, exp);
            a.Divider = (int)Math.Pow(a.Divider, exp);
            Reduction(a);

            return a;
        }

        public static Fraction Reduction(Fraction fr)
        {
            int nod = 0, beg; bool ok = false;  
            int a = Math.Abs(fr.Numerator);
            int b = Math.Abs(fr.Divider);

            while (a != 0 && b != 0)
                if (a >= b) a %= b;
                else b %= a;
            nod = a + b;

            fr.Numerator /= nod;
            fr.Divider /= nod;

            return fr;
        }
    }
}
