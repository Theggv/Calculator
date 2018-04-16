using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3
{
    public class OperationInfo
    {
        private Fraction _FirstForm;
        private Fraction _SecondFrom;
        private long _Digit;

        private SignForm.SignIndex _Sign;
        private Fraction _Result;

        public Fraction FirstForm { get => _FirstForm; }

        public Fraction SecondForm { get => _SecondFrom; }

        public long Digit { get => _Digit; }

        public SignForm.SignIndex Sign { get => _Sign; }

        public Fraction ResultForm { get => _Result; }

        public OperationInfo(Fraction firstForm, SignForm.SignIndex sign, Fraction secondForm, Fraction result, long digit)
        {
            _FirstForm = firstForm;
            _Sign = sign;
            _SecondFrom = secondForm;
            _Result = result;
            _Digit = digit;
        }
    }
}
