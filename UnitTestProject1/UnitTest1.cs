using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfApp3;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        static Fraction a = new Fraction(2, 3);      //Init fraction 2/3
        static Fraction b = new Fraction(-6, 5);     //Init fraction -6/5
        static Fraction c = new Fraction(-10, 5);    //Init fraction -10/5
        static Fraction d = new Fraction(-16, -80);  //Init Fraction -16/-80

        [TestMethod]
        public void Reduction1()
        {
            Fraction c = new Fraction(-10, 5);    //Init fraction -10/5
            c = Calculator.Reduction(c);
            Assert.AreEqual(c.Divider,1);
            Assert.AreEqual(c.Numerator, -2);
        }

        [TestMethod]
        public void Reduction2()
        {
            Fraction d = new Fraction(-16, -80);  //Init Fraction -16/-80
            c = Calculator.Reduction(d);
            Assert.AreEqual(d.Divider, 5);
            Assert.AreEqual(d.Numerator, 1);
        }

        [TestMethod]
        public void Reduction3()
        {
            Fraction d = new Fraction(2,3);  
            c = Calculator.Reduction(d);
            Assert.AreEqual(d.Divider, 3);
            Assert.AreEqual(d.Numerator, 2);
        }

        [TestMethod]
        public void Constuct1()
        {
            Fraction a = new Fraction(2, 3);
            Assert.AreEqual(a.Numerator, 2);
            Assert.AreEqual(a.Divider, 3);
        }

        [TestMethod]
        public void Construct2()
        {
            Fraction a = new Fraction(-16, -80);
            Assert.AreEqual(a.Numerator, 16);
            Assert.AreEqual(a.Divider, 80);
        }

        [TestMethod]
        public void Construct3()
        {
            bool ok = false;
            try
            {
                Fraction a = new Fraction(-16, 0);
                Assert.AreEqual(a.Numerator, 16);
                Assert.AreEqual(a.Divider, 80);
            }
            catch (Exception)
            {
                ok = true;
            }
            Assert.AreEqual(true, ok);
        }

        [TestMethod]
        public void Construct4()
        {
            Fraction a = new Fraction(1, 2, 3);
            Assert.AreEqual(a.Numerator, 5);
            Assert.AreEqual(a.Divider, 3);
        }

        [TestMethod]
        public void Construct5()
        {
            Fraction a = new Fraction(2, 1, 7);
            Assert.AreEqual(a.Numerator, 15);
            Assert.AreEqual(a.Divider, 7);
        }

        [TestMethod]
        public void Plus1()
        {
            Fraction a = new Fraction(2, 5);
            Fraction b = new Fraction(7, 8);
            Fraction res = a + b;

            Assert.AreEqual(res.Numerator, 51);
            Assert.AreEqual(res.Divider, 40);
        }

        [TestMethod]
        public void Plus2()
        {
            Fraction a = new Fraction(3, 5);
            Fraction b = new Fraction(1, 5);
            Fraction res = a + b;

            Assert.AreEqual(res.Divider, 5);
            Assert.AreEqual(res.Numerator, 4);
        }
        [TestMethod]
        public void Plus4()
        {
            Fraction a = new Fraction(3, 7);
            Fraction b = new Fraction(1, 7);
            Fraction res = a + b;

            Assert.AreEqual(res.Divider, 7);
            Assert.AreEqual(res.Numerator, 4);
        }

        [TestMethod]
        public void Divdider1()
        {
            Fraction a = new Fraction(1, 7);
            Assert.AreEqual(a.Numerator, 1);
            Assert.AreEqual(a.Divider, 7);
        }

        [TestMethod]
        public void Plus5()
        {
            Fraction a = new Fraction(3, 1, 8);
            Fraction b = new Fraction(3, 7, 8);
            Fraction res = a + b;

            Assert.AreEqual(res.Divider, 1);
            Assert.AreEqual(res.Numerator, 7);
        }

        [TestMethod]
        public void Plus6()
        {
            Fraction a = new Fraction(3, 5, 8);
            Fraction b = new Fraction(3, 7, 8);
            Fraction res = a + b;

            Assert.AreEqual(res.Divider, 2 );
            Assert.AreEqual(res.Numerator, 15);
        }

        [TestMethod]
        public void Allocate1()
        {
            Fraction a = new Fraction(2, 3);
            long div = Calculator.AllocateDivPart(a);
            Assert.AreEqual(div, 0);
        }

        [TestMethod]
        public void Allocate2()
        {
            Fraction a = new Fraction(3, 3);
            long div = Calculator.AllocateDivPart(a);
            Assert.AreEqual(div, 1);
        }

        [TestMethod]
        public void Allocate3()
        {
            Fraction a = new Fraction(4, 3);
            long div = Calculator.AllocateDivPart(a);
            Assert.AreEqual(div, 1);
        }

        [TestMethod]
        public void Allocate4()
        {
            Fraction a = new Fraction(80, 16);
            long div = Calculator.AllocateDivPart(a);
            Assert.AreEqual(div, 5);
        }

        [TestMethod]
        public void Allocate5()
        {
            Fraction a = new Fraction(17,4,7);
            long div = Calculator.AllocateDivPart(a);
            Assert.AreEqual(div, 17);
        }

        [TestMethod]
        public void Pow1()
        {
            Fraction a = new Fraction(2, 4);
            a = Calculator.Exponent(a, 3);
            Assert.AreEqual(a.Divider, 8);
            Assert.AreEqual(a.Numerator, 1);
        }



    }
}
