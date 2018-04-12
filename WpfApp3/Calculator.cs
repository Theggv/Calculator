﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3
{
    class Calculator
    {
        public Fraction ChangeDomDen(Fraction a) //Change places of devider an denominator
        {
            int c = a.Denominator;
            a.Divider = a.Denominator;
            a.Denominator = c;
            return a;
        }

        public Fraction Multiplication(Fraction a, Fraction b)
        {
            Fraction res = new Fraction();
            res.Denominator = a.Denominator * b.Divider;
            res.Divider = a.Divider * b.Denominator;
            Reduction(a);
            return res;
        }

        public Fraction Division(Fraction a, Fraction b)
        {
            Fraction res = new Fraction();
            res.Denominator = a.Denominator * b.Denominator;
            res.Divider = a.Divider * b.Divider;
            Reduction(res);
            return res;
        }

        public Fraction Exponent(Fraction a, int exp)
        {
            a.Denominator = (int)Math.Pow(a.Denominator, exp);
            a.Divider = (int)Math.Pow(a.Divider, exp);
            Reduction(a);
            return a;
        }

        public Fraction Reduction(Fraction a)
        {
            int nod = 0, beg; bool ok = false;  
            int aDen = Math.Abs(a.Denominator);
            int aDiv = Math.Abs(a.Divider);

            if (aDen < aDiv) beg = aDen;         //if denominator>divider then change the begining number of the cycle
            else beg = aDiv;

            for (int i = beg; i > 0 && !ok; i--)
            {
                if (aDen % i == 0 && aDiv % i == 0) { nod = i; ok = true; }  //find the max value, which divide denominator and divider 
            }

            if (ok)
            {
                a.Denominator = aDen / nod;
                a.Divider = aDiv / nod;
            }

            return a;

        }
    }
}
