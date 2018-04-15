using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3
{
    class Fraction
    {
      
        static int divider;
        static int denominator;

        public int Divider
        {
            get { return divider; }
            set
            {
                if (divider < 0 && denominator < 0)
                {
                    divider = Math.Abs(divider);
                    denominator = Math.Abs(denominator);
                }
            }
        }

        public int Denominator
        {
            get { return denominator; }
            set
            {
                if (denominator == 0)
                    throw new Exception;
                if (divider < 0 && denominator < 0)
                {
                    divider = Math.Abs(divider);
                    denominator = Math.Abs(denominator);
                }
            }
        }  
    }
}
