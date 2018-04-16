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

        public static void AddOperation(Fraction firstForm, SignForm.SignIndex sign, Fraction secondForm, Fraction result, int digit)
        {
            _Stack.Push(new OperationInfo(firstForm, sign, secondForm, result, digit));
        }

        public static void CancelOperation(MainWindow mainWindow)
        {
            var operInfo = _Stack.Pop();

            if (operInfo.Sign == SignForm.SignIndex.Exp)
            {
                mainWindow.Add_ExpForm();

                var firstForm = operInfo.FirstForm;
                mainWindow._FirstForm.RewriteResult(firstForm.Numerator / firstForm.Divider,
                    firstForm.Numerator, firstForm.Divider);

                mainWindow._SignForm.ChangeSign(operInfo.Sign);

                mainWindow.ExpForm.Rewrite_Result(operInfo.Digit);

                var result = operInfo.ResultForm;
                mainWindow._ResultForm.RewriteResult(result.Numerator / result.Divider,
                    result.Numerator, result.Divider);
            }
            else
            {
                mainWindow.Remove_ExpForm();

                var firstForm = operInfo.FirstForm;
                mainWindow._FirstForm.RewriteResult(firstForm.Numerator / firstForm.Divider,
                    firstForm.Numerator, firstForm.Divider);

                mainWindow._SignForm.ChangeSign(operInfo.Sign);

                var secondForm = operInfo.SecondForm;
                mainWindow._FirstForm.RewriteResult(secondForm.Numerator / secondForm.Divider,
                    secondForm.Numerator, secondForm.Divider);

                var result = operInfo.ResultForm;
                mainWindow._ResultForm.RewriteResult(result.Numerator / result.Divider,
                    result.Numerator, result.Divider);
            }
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
