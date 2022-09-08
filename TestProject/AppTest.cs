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
        public void RomanNumberParse()
        { }


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
            Assert.AreEqual(
                "Empty string not allowed",
                Assert.ThrowsException<ArgumentException>(
                    () => RomanNumber.Parse("")
                    ).Message
              );

            Assert.ThrowsException<ArgumentNullException>(
                () => RomanNumber.Parse(""));

        }
    }
}
