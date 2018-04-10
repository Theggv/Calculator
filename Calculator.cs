using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3
{
    class Fraction
    {
        int total;
        int divider;
        int denominator;

        public int Total
        {
            get => total;
            set
            {
                total = value;
            }
        }
        public int Divider
        {
            get => total;
            set
            {
                divider = value;
            }
        }
        public int Denominator
        {
            get => total;
            set
            {
                denominator = value;
            }
        }

        public Fraction(int tot, int den, int div)
        {
            Total = tot;
            Divider = div;
            Denominator = den;
        }

    }

    class Calculator
    {

        public Fraction Reduction(Fraction a)
        {
            bool ok = false; int nod = 0;
            if (Math.Abs(a.Denominator) < Math.Abs(a.Divider))
            {
                for (int i = Math.Abs(a.Denominator); i > 0 && !ok; i--)
                    if (a.Denominator % i == 0 && a.Divider % i == 0)
                    {
                        ok = true; nod = i;
                    }
            }
            else
            {
                for (int i = Math.Abs(a.Divider); i > 0 && !ok; i--)
                    if (a.Denominator % i == 0 && a.Divider % i == 0)
                    {
                        ok = true; nod = i;
                    }
            }

            a.Denominator /= nod;
            a.Divider /= nod;
            return a;
        }

        public Fraction Multiplication(Fraction a, Fraction b)
        {

        }
    }
}
