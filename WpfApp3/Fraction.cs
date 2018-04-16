﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WpfApp3.Calculator;

namespace WpfApp3
{
    public class Fraction
    {
        private long numerator;              //Числитель
        private long divider;          //Знаменатель

        public long Numerator                      //Условие числителя
        {
            get { return numerator; }
            set
            {
                if (value < 0 && divider < 0)
                {
                    numerator = Math.Abs(value);
                    divider = Math.Abs(divider);
                }
                else
                    numerator = value;
            }
        }

        public long Divider                  //Условие знаменателя
        {
            get { return divider; }
            set
            {
                if (value == 0)
                    throw new Exception("Знаменатель не может быть равен нулю!");
                else if (numerator < 0 && value < 0)
                {
                    numerator = Math.Abs(numerator);
                    divider = Math.Abs(value);
                }
                else divider = value;
            }
        }

        public Fraction()                       //Конструктор без параметров
        {
            Numerator = 0;
            Divider = 1;
        }

        public Fraction(long up, long down)       //Конструктор с параметрами
        {
            Numerator = up;
            Divider = down;
        }

        public Fraction(long div, long up, long down)
        {
            Numerator = div * down + up;
            Divider = down; 
        }

        public static Fraction operator *(Fraction a, long value) //Оператор умножения дроби на число девосторонний
        {
            Fraction result = a;
            
            result.Numerator *= value;
            Reduction(result);

            return result;
        }

        public static Fraction operator *(long value, Fraction a) //Оператор умножения дроби на число правосторонний
        {
            Fraction result = a;
            
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
            result.Numerator = a.Numerator * b.Divider + b.Numerator * a.Divider;

            Reduction(result);

            return result;
        }

        public static Fraction operator -(Fraction a, Fraction b) //Оператор вычитания
        {
            Fraction result = new Fraction();

            result.Divider = a.Divider * b.Divider;
            result.Numerator = a.Numerator * b.Divider - b.Numerator * a.Divider;

            Reduction(result);

            return result;
        }

        public static Fraction operator /(Fraction a, Fraction b) //Оператор умножения
        {
            Fraction result = new Fraction();

            b = ChangeDomDen(b);

            return a * b;
        }
    }
}
