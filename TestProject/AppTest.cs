using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculatorProject.App;
using System;


namespace TestProject
{
    [TestClass]
    public class AppTest
    {
        [TestMethod]
        public void Calculator()
        {
            //  create calc object
            CalculatorProject.App.Calculator calc = new();
            // must be not null
            Assert.IsNotNull(calc);
        }

        [TestMethod]
        public void RomanNumberParse1MoreDigits()
        {
            Assert.AreEqual(1, RomanNumber.Parse("I"));
        }

        [TestMethod]
        public void RomanNumberParse2MoreDigits()
        {
            Assert.AreEqual(4, RomanNumber.Parse("IV"));
            Assert.AreEqual(15, RomanNumber.Parse("XV"));
            Assert.AreEqual(900, RomanNumber.Parse("CM"));
            Assert.AreEqual(400, RomanNumber.Parse("CD"));
            Assert.AreEqual(55, RomanNumber.Parse("LV"));
            Assert.AreEqual(40, RomanNumber.Parse("XL"));
        }

        [TestMethod]
        public void RomanNumberParse3MoreDigits()
        {
            Assert.AreEqual(30, RomanNumber.Parse("XXX"));
            Assert.AreEqual(401, RomanNumber.Parse("CDI"));
            Assert.AreEqual(1999, RomanNumber.Parse("MCMXCIX"));
        }

        [TestMethod]
        public void RomanNumberParseInvalidDigits()
        {
            // with some number the function should return an exception       
            //Assert.AreEqual(0, RomanNumber.Parse("XXA")); //this an exception 
           
            var exc = Assert.ThrowsException<ArgumentException>(() => { RomanNumber.Parse("XXA"); } );
            var exp = new ArgumentException("Invalid char A");
            Assert.AreEqual(exp.Message, exc.Message);

            var exc_1 = Assert.ThrowsException<ArgumentException>(() => { RomanNumber.Parse("XMLB"); });
            var exp_1 = new ArgumentException("Invalid char B");
            Assert.AreEqual(exp.Message, exc.Message);

            var exc_2 = Assert.ThrowsException<ArgumentException>(() => { RomanNumber.Parse("SXII"); });
            var exp_2 = new ArgumentException("Invalid char S");
            Assert.AreEqual(exp.Message, exc.Message);

            var exc_3 = Assert.ThrowsException<ArgumentException>(() => { RomanNumber.Parse("MIK"); });
            var exp_3 = new ArgumentException("Invalid char K");
            Assert.AreEqual(exp.Message, exc.Message);

        }

        [TestMethod]
        public void RomanNumberParseEmpty()
        {
            // ArgumentException с уведомлением  Empty string not allowed
            //Assert.AreEqual( "Empty string not allowed",  Assert.ThrowsException<ArgumentException>(() => RomanNumber.Parse("")).Message);

            // ArgumentNullException без уведомлений 
            Assert.ThrowsException<ArgumentNullException>(() => RomanNumber.Parse(null!));
        }

        [TestMethod]
        public void RomanNumberCtor() //Testing constructors to generate numbers
        {           
            RomanNumber romanNumber = new();
            Assert.IsNotNull(romanNumber);
            romanNumber = new(10);
            Assert.IsNotNull(romanNumber);
            romanNumber = new(0);
            Assert.IsNotNull(romanNumber);
        }

        [TestMethod]
        public void RomanNumberToString()
        {
            RomanNumber romanNumber = new(0);
            Assert.AreEqual("N", romanNumber.ToString());

             romanNumber = new(90);
            Assert.AreEqual("XC", romanNumber.ToString());

             romanNumber = new(20);
            Assert.AreEqual("XX", romanNumber.ToString());

             romanNumber = new(1999);
            Assert.AreEqual("MCMXCIX", romanNumber.ToString());       
        }

        [TestMethod]
        public void RomanNumberToStringParseCrossTest()
        {
            
            RomanNumber num = new();
            for (int n = 0; n <= 2022; ++n)
            {
                num.Number = n;
                Assert.AreEqual(n, RomanNumber.Parse(num.ToString()));
            }

        }


        [TestMethod]
        public  void RomanNumberTypeTest()
        {
            // Написать тесты которые будут пройдены тольуо если RomanNumber - ссылочный тип.

            RomanNumber rn1 = new(10);
            RomanNumber rn2 = rn1;
            Assert.AreSame(rn1, rn2);               // rn1, rn2 - ссылка на один объект

            RomanNumber rn3 = rn1 with { };      // клониование 
            Assert.AreNotSame(rn3, rn1);        // проверка клонирования 
            Assert.AreEqual(rn3, rn1);              // неодниковые но равные
            Assert.IsTrue(rn1 == rn2);              //

            RomanNumber rn4 = rn1 with { Number = 20 };

            Assert.AreNotSame(rn4 , rn1);
            Assert.AreNotEqual(rn4, rn1);
            Assert.IsFalse(rn1 == rn4);
            Assert.IsFalse(rn1.Equals(rn4));
        }

    }
}
