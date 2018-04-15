using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3
{
    public class Calculator
    {
        public static Fraction ChangeDomDen(Fraction a) //Change places of devider an denominator
        {
            int c = a.Denominator;
            a.Divider = a.Denominator;
            a.Denominator = c;
            return a;
        }

        public static Fraction Exponent(Fraction a, int exp)
        {
            a.Denominator = (int)Math.Pow(a.Denominator, exp);
            a.Divider = (int)Math.Pow(a.Divider, exp);
            Reduction(a);
            return a;
        }

        public static Fraction Reduction(Fraction fr)
        {
            int nod = 0, beg; bool ok = false;  
            int a = Math.Abs(fr.Denominator);
            int b = Math.Abs(fr.Divider);

            while (a != 0 && b != 0)
                if (a >= b) a %= b;
                else b %= a;
            nod = a + b;

            fr.Denominator /= nod;
            fr.Divider /= nod;

            return fr;

        }
    }
}
