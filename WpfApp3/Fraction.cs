using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3
{
    public class Fraction
    {
      
        static int divider;
        static int denominator;

        public int Denominator
        {
            get { return denominator; }
            set
            {
                denominator = value;
                if (divider < 0 && denominator < 0)
                {
                    divider = Math.Abs(divider);
                    denominator = Math.Abs(denominator);
                }
            }
        }

        public int Divider
        {
            get { return divider; }
            set
            {
                if (value == 0)
                    throw new Exception();
                divider = value;
                if (divider < 0 && denominator < 0)
                {
                    divider = Math.Abs(divider);
                    denominator = Math.Abs(denominator);
                }
            }
        }

        public Fraction(int up, int down) //Конструктор с параметрами 
        {
            if (up < 0 && down < 0)
            {
                Divider = Math.Abs(down);
                Denominator = Math.Abs(up);
            }
            else
            {
                Divider = down;
                Denominator = up;
            }
        }

        public Fraction() //Конструктор без параметров 
        {
            Divider = 1;
            Denominator = 0;
        }


    }
}
