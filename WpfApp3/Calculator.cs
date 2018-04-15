using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3
{
    public class Calculator
    {
        static Fraction a;
        static Fraction b;
        static Fraction res;
        public enum Tools { Plus, Minus, Multi, Divide, Exp, Change, Red}
        static Tools tool;
        static int exp;
        public Tools Tool
        {
            get => tool;
            set => tool = value;
        }
        public Fraction A
        {
            get => a;
            set => a = value;
        }
        public Fraction B
        {
            get => b;
            set => b = value;
        }
        public Fraction Res
        {
            get => res;
            set => res = value;
        }

        public int Exp
        {
            get => exp;
            set => exp = value;
        }

        public Fraction Calculation()
        {
            res = new Fraction();
            switch (tool)
            {
                case Tools.Divide:
                    res = a / b;
                    break;
                case Tools.Minus:
                    res = a - b;
                    break;
                case Tools.Plus:
                    res = a + b;
                    break;
                case Tools.Multi:
                    res = a * b;
                    break;
                case Tools.Exp:
                    res = Exponent(a, exp);
                    break;
                case Tools.Change:
                    res = ChangeDomDen(a);
                    break;
                case Tools.Red:
                    res = Reduction(a);
                    break;
            }
            return res;
        }

        public static int AllocateDivPart(Fraction a)
        {
            return a.Numerator / a.Divider;
        }

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
            a = Reduction(a);
            return a;
        }

        public static Fraction Reduction(Fraction fr)
        {
            int nod = 0, beg; bool ok = false;  
            int a = Math.Abs(fr.Numerator);
            int b = Math.Abs(fr.Divider);

            while (a > 0 && b > 0)
                if (a >= b) a %= b;
                else b %= a;
            nod = a + b;

            fr.Numerator /= nod;
            fr.Divider /= nod;

            return fr;

        }

        public Calculator()
        {
            A = new Fraction();
            B = new Fraction();
        }

    }
}
