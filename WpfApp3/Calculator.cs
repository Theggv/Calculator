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
        private const int _NUMCANCELS = 15;
        public static Stack<OperationInfo> _Stack = new Stack<OperationInfo>(_NUMCANCELS);

        private static Fraction a;
        private static Fraction b;
        private static Fraction res;

        private static Tools tool;
        private static long exp;
        
        public enum Tools { Plus, Minus, Multi, Divide, Exp, Change, Red }

        public static Tools Tool
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

        public long Exp
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

        public Calculator()
        {
            A = new Fraction();
            B = new Fraction();
        }

        public static void SaveOperation(Fraction firstForm, SignForm.SignIndex sign,
            Fraction secondForm, Fraction result, long digit)
        {
            _Stack.Push(new OperationInfo(firstForm, sign, secondForm, result, digit, Tool));
        }

        public static void CancelOperation(MainWindow mainWindow)
        {
            if (_Stack.Count <= 1)
                return;

            _Stack.Pop();

            if (_Stack.Count == 0)
                return;

            var operInfo = _Stack.Peek();

            Tool = operInfo.Tool;

            if (operInfo.Sign == SignForm.SignIndex.Exp)
            {
                mainWindow.Add_ExpForm();

                var firstForm = operInfo.FirstForm;
                mainWindow._FirstForm.RewriteResult(firstForm.Numerator, firstForm.Divider);

                mainWindow._SignForm.ChangeSign(operInfo.Sign);

                mainWindow.ExpForm.Rewrite_Result(operInfo.Digit);

                var result = operInfo.ResultForm;
                mainWindow._ResultForm.RewriteResult(result.Numerator, result.Divider);
            }
            else
            {
                mainWindow.Remove_ExpForm();

                var firstForm = operInfo.FirstForm;
                mainWindow._FirstForm.RewriteResult(firstForm.Numerator, firstForm.Divider);

                mainWindow._SignForm.ChangeSign(operInfo.Sign);

                var secondForm = operInfo.SecondForm;
                mainWindow._SecondForm.RewriteResult(secondForm.Numerator, secondForm.Divider);

                var result = operInfo.ResultForm;
                mainWindow._ResultForm.RewriteResult(result.Numerator, result.Divider);
            }
        }
        public static long AllocateDivPart(Fraction a)
        {
            return a.Numerator / a.Divider;
        }

        public static Fraction ChangeDomDen(Fraction a) // Change places of divider and numerator
        {
            long c = a.Divider;

            a.Divider = a.Numerator;
            a.Numerator = c;

            return a;
        }

        public static Fraction Exponent(Fraction a, long exp)
        {
            a.Numerator = (long)Math.Pow(a.Numerator, exp);
            a.Divider = (long)Math.Pow(a.Divider, exp);

            Reduction(a);

            return a;
        }

        public static Fraction Reduction(Fraction fr)
        {
            long nod = 0;
            long a = Math.Abs(fr.Numerator);
            long b = Math.Abs(fr.Divider);

            while (a != 0 && b != 0)
                if (a >= b)
                    a %= b;
                else
                    b %= a;

            nod = a + b;

            fr.Numerator /= nod;
            fr.Divider /= nod;

            return fr;
        }
    }
}
