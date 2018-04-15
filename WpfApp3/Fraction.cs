using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WpfApp3.Calculator;

namespace WpfApp3
{
     public class Fraction
    {
        public static int numerator;              //Числитель
        public static int divider;          //Знаменатель

        public int Numerator                      //Условие числителя
        {
            get { return numerator; }
            set
            {
                if (numerator < 0 && divider < 0)
                {
                    numerator = Math.Abs(numerator);
                    divider = Math.Abs(divider);
                }
                else numerator = value;
            }
        }

        public int Divider                  //Условие знаменателя
        {
            get { return divider; }
            set
            {
                if (divider == 0)
                    throw new Exception("Знаменатель не может быть равен нулю!");
                else if (numerator < 0 && divider < 0)
                {
                    numerator = Math.Abs(numerator);
                    divider = Math.Abs(divider);
                }
                else divider = value;
            }
        }

        public Fraction(int up, int down)       //Конструктор с параметрами
        {
            numerator = up;
            divider = down;

            if (numerator<0 && divider < 0)
            {
                numerator = Math.Abs(numerator);
                divider = Math.Abs(divider);
            }
        }

        public Fraction()                       //Конструктор без параметров
        {
            numerator = 0;
            divider = 1;
        }

        public Fraction (int div, int up, int down)
        {
            numerator = div * down + up;
            divider = down;

            if (numerator < 0 && divider < 0)
            {
                numerator = Math.Abs(numerator);
                divider = Math.Abs(divider);
            }
        }

        public static Fraction operator *(Fraction a, int value) //Оператор умножения дроби на число девосторонний
        {
            Fraction result = a;

            result.Divider *= value;
            result.Numerator *= value;
            Reduction(result);


            return result;
        }

        public static Fraction operator *(int value, Fraction a) //Оператор умножения дроби на число правосторонний
        {
            Fraction result = a;

            result.Divider *= value;
            result.Numerator *= value;
            Reduction(result);


            return result;
        }

        public static Fraction operator *(Fraction a, Fraction b) //Оператор умножения дроби на дробь
        {
            Fraction result = new Fraction();

            result.Divider = a.Divider * b.Divider;
            result.Numerator = a.Numerator * b.Numerator;
            Reduction(result);


            return result;
        }

        public static Fraction operator +(Fraction a, Fraction b) //Оператор сложения
        {
            Fraction result = new Fraction();

            result.Divider = a.Divider * b.Divider;
            a *= b.Divider;
            b *= a.Divider;
            result.Numerator = a.Numerator + b.Numerator;
            Reduction(result);
            return result;
        }

        public static Fraction operator -(Fraction a, Fraction b) //Оператор вычитания
        {
            Fraction result = new Fraction();

            result.Divider = a.Divider * b.Divider;
            a *= b.Divider;
            b *= a.Divider;
            result.Numerator = a.Numerator - b.Numerator;
            Reduction(result);
            return result;
        }

        public static Fraction operator /(Fraction a, Fraction b) //Оператор умножения
        {
            Fraction result = new Fraction();

            b = ChangeDomDen(b);

            result.Divider = a.Divider * b.Divider;
            result.Numerator = a.Numerator * b.Numerator;
            Reduction(result);

            return result;
        }
    }
}
