using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculatorProject.App;


namespace TestProject
{

    [TestClass]
    public class AppTest
    {
        private Resources Resources { get; set; } = new();

        public AppTest()
        {
            RomanNumber.Resources = Resources;
        }

        [TestMethod]

        public void Calculator()
        {
            //  create calc object
            CalculatorProject.App.Calculator calc = new(Resources);
            // must be not null
            //Assert.IsNotNull(calc);
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
        public void RomanNumberParseN()   // Testing "N" letter 
        {
            Assert.AreEqual(0, RomanNumber.Parse("N"));  // Added simple test for "N" letter

            // Exceptions for "N" letter
            Assert.ThrowsException<ArgumentException>(() => { RomanNumber.Parse("XN"); } );
            Assert.ThrowsException<ArgumentException>(() => { RomanNumber.Parse("MNX"); } );
            Assert.ThrowsException<ArgumentException>(() => { RomanNumber.Parse("NL"); } );
        }

        [TestMethod]
        public void RomanNumberParseInvalidDigits()
        {
            // with some number the function should return an exception       
            // Assert.AreEqual(0, RomanNumber.Parse("XXA")); //this an exception 
           
            var exc = Assert.ThrowsException<ArgumentException>(() => { RomanNumber.Parse("XXA"); } );
            var exp = new ArgumentException(Resources.GetInvalidCharMessage('A'));
            Assert.AreEqual(exp.Message, exc.Message);

            var exc_1 = Assert.ThrowsException<ArgumentException>(() => { RomanNumber.Parse("XMLB"); });
            var exp_1 = new ArgumentException(Resources.GetInvalidCharMessage('B'));
            Assert.AreEqual(exp.Message, exc.Message);

            var exc_2 = Assert.ThrowsException<ArgumentException>(() => { RomanNumber.Parse("SXII"); });
            var exp_2 = new ArgumentException(Resources.GetInvalidCharMessage('S'));
            Assert.AreEqual(exp.Message, exc.Message);

            var exc_3 = Assert.ThrowsException<ArgumentException>(() => { RomanNumber.Parse("MIK"); });
            var exp_3 = new ArgumentException(Resources.GetInvalidCharMessage('K'));
            Assert.AreEqual(exp.Message, exc.Message);

        }

        [TestMethod]
        public void RomanNumberParseEmpty()
        {
            // ArgumentException ñ óâåäîìëåíèåì  Empty string not allowed
            // Assert.AreEqual( "Empty string not allowed",  Assert.ThrowsException<ArgumentException>(() => RomanNumber.Parse("")).Message);

            // ArgumentNullException áåç óâåäîìëåíèé 
            Assert.ThrowsException<ArgumentNullException>(() => RomanNumber.Parse(null!));
        }

        [TestMethod]
        public void RomanNumberCtor()   // Testing constructors to generate numbers
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
            // Íàïèñàòü òåñòû êîòîðûå áóäóò ïðîéäåíû òîëüóî åñëè RomanNumber - ññûëî÷íûé òèï.

            RomanNumber rn1 = new(10);
            RomanNumber rn2 = rn1;
            Assert.AreSame(rn1, rn2);               // rn1, rn2 - ññûëêà íà îäèí îáúåêò

            RomanNumber rn3 = rn1 with { };      // êëîíèîâàíèå 
            Assert.AreNotSame(rn3, rn1);        // ïðîâåðêà êëîíèðîâàíèÿ 
            Assert.AreEqual(rn3, rn1);              // íåîäíèêîâûå íî ðàâíûå
            Assert.IsTrue(rn1 == rn2);              //

            RomanNumber rn4 = rn1 with { Number = 20 };

            Assert.AreNotSame(rn4 , rn1);
            Assert.AreNotEqual(rn4, rn1);
            Assert.IsFalse(rn1 == rn4);
            Assert.IsFalse(rn1.Equals(rn4));
        }

        [TestMethod]
        public void RomanNumberNegative()  // Testing negative RomanNumber
        {
            //tests
            Assert.AreEqual(-10, RomanNumber.Parse("-X"));
            Assert.AreEqual(-400, RomanNumber.Parse("-CD"));
            Assert.AreEqual(-1900, RomanNumber.Parse("-MCM"));

            //more test
            RomanNumber rn = new() { Number = -10 };
            Assert.AreEqual("-X", rn.ToString());
            rn.Number = -90;
            Assert.AreEqual("-XC", rn.ToString());

            //Exceptions. The minus must come only first and with letters, but without the letter N
            Assert.ThrowsException<ArgumentException>(() => RomanNumber.Parse("M-CM"));
            Assert.ThrowsException<ArgumentException>(() => RomanNumber.Parse("M-"));
            Assert.ThrowsException<ArgumentException>(() => RomanNumber.Parse("-"));
            Assert.ThrowsException<ArgumentException>(() => RomanNumber.Parse("-N"));
            Assert.ThrowsException<ArgumentException>(() => RomanNumber.Parse("--X"));
            Assert.ThrowsException<ArgumentException>(() => RomanNumber.Parse("-C-X"));
        }
    }


    [TestClass]
    public class OperationTest   // Test class for operations with Roman number
    {
        private Resources Resources { get; set; } = new();
        public OperationTest()
        {
            RomanNumber.Resources = Resources;
        }

        [TestMethod]
        public void RomanNumberAddTest()
        {
            RomanNumber a = new(10);
            RomanNumber b = new(15);
            RomanNumber c = new(25);
            RomanNumber d = new(-15);

            Assert.AreEqual(20, a.Add(a).Number);
            Assert.AreEqual(25, a.Add(b).Number);
            Assert.AreEqual(19, a.Add(new RomanNumber(9)).Number);
            Assert.AreEqual(5, a.Add(new RomanNumber(-5)).Number);
            Assert.AreEqual(10, a.Add(new RomanNumber()).Number);
            Assert.AreEqual(15, b.Add(new RomanNumber(0)).Number);

            Assert.AreEqual("XXV", a.Add(b).ToString());
            Assert.AreEqual("-V", d.Add(a).ToString());

            //Assert.ThrowsException<ArgumentNullException>(() => a.Add(null!));

            Assert.AreEqual(c, a.Add(b));

        }

        [TestMethod]
        public void AddValueTest()
        {
            var rn = new RomanNumber(10);
            Assert.AreEqual(20,      rn.Add(10).Number);                 
            Assert.AreEqual("V",     rn.Add(-5).ToString());            
            Assert.AreEqual(rn,     rn.Add(0));            
               
        }

        [TestMethod]
        public void AddStringTest()
        {
            var rn = new RomanNumber(10);
            Assert.AreEqual(30, rn.Add("XX").Number);
            Assert.AreEqual("-XL", rn.Add("-L").ToString());
            Assert.AreEqual(rn, rn.Add("N"));

            Assert.ThrowsException<ArgumentException>(() => rn.Add(""));
            Assert.ThrowsException<ArgumentException>(() => rn.Add("-"));
            Assert.ThrowsException<ArgumentException>(() => rn.Add("10"));
            Assert.ThrowsException<ArgumentException>(() => rn.Add("10"));
            Assert.ThrowsException<ArgumentNullException>(() => rn.Add((String)null!));
        }

        [TestMethod] 
        public void AddStaticValueTest()  // Testing when the result of add operation is a prime number
        {
            // a little objects for testing
            RomanNumber rn5 = new(5);
            RomanNumber rn8 = new(8);
            RomanNumber rn10 = new(10);
            RomanNumber rn9 = new(9);
            RomanNumber rn13 = new(13);

            Assert.AreEqual(0, RomanNumber.Add("-V", rn5).Number);
            Assert.AreEqual(10, RomanNumber.Add(rn10, "N").Number);
            Assert.AreEqual(-5, RomanNumber.Add("-V", "N").Number);
            Assert.AreEqual(13, RomanNumber.Add(rn5, rn8).Number);
            Assert.AreEqual(20, RomanNumber.Add(rn10, 10).Number);
            Assert.AreEqual(15, RomanNumber.Add(15, "N").Number);
            Assert.AreEqual(-10, RomanNumber.Add(20, -30).Number);

            // a little Exeptions 
            Assert.ThrowsException<ArgumentException>(() => RomanNumber.Add("-",  "I"));
            Assert.ThrowsException<ArgumentException>(() => RomanNumber.Add("NB",  "X"));
            Assert.ThrowsException<ArgumentException>(() => RomanNumber.Add("C",  "-"));
            Assert.ThrowsException<ArgumentException>(() => RomanNumber.Add("",  "x"));
            Assert.ThrowsException<ArgumentException>(() => RomanNumber.Add("V",  "QW"));

            Assert.ThrowsException<ArgumentNullException>(() => RomanNumber.Add((String)null!, (String)null!));
            Assert.ThrowsException<ArgumentNullException>(() => RomanNumber.Add((String)null!, 3));
            Assert.ThrowsException<ArgumentNullException>(() => RomanNumber.Add("V", (String)null!));
        }

        [TestMethod]
        public void AddStaticStringTest()  // Testing when the result of add operation is a string
        {
            //a little objects for testing
            RomanNumber rn8 = new(8);

            Assert.AreEqual("-X", RomanNumber.Add(20, -30).ToString());
            Assert.AreEqual("-V", RomanNumber.Add("-V", "N").ToString());
            Assert.AreEqual("X", RomanNumber.Add(rn8, 2).ToString());
            Assert.AreEqual("XVIII", RomanNumber.Add("IX", 9).ToString());
        }

        [TestMethod]
        public void AddStaticObjectTest()   // Testing when the result of add operation is a object
        {
            // a little objects for testing
            RomanNumber rn5 = new(5);
            RomanNumber rn8 = new(8);
            RomanNumber rn10 = new(10);

            Assert.AreEqual(rn10, RomanNumber.Add(5, 5));
            Assert.AreEqual(rn5, RomanNumber.Add(15, "-X"));
            Assert.AreEqual(rn8, RomanNumber.Add(rn10, -2));
        }



        [TestMethod]
        public void MinusStaticTest()   // Testing when the result of minus operation is a object
        {
            RomanNumber rn = new(0);
            RomanNumber rn_5 = new(-5);
            RomanNumber rn8 = new(8);
            RomanNumber rn10 = new(10);

            Assert.AreEqual(6, RomanNumber.Sub(10, 4).Number);
            Assert.AreEqual(9, RomanNumber.Sub(15, 6).Number);

            Assert.AreEqual("N", RomanNumber.Sub(10, "X").ToString());
            Assert.AreEqual(3, RomanNumber.Sub(rn8, "V").Number);
            Assert.AreEqual(rn10, RomanNumber.Sub(15, "V"));

            Assert.AreEqual("-V", RomanNumber.Sub(5, "X").ToString());
            Assert.AreEqual("-II", RomanNumber.Sub(rn8, rn10).ToString());
            Assert.AreEqual(rn_5, RomanNumber.Sub(15, "XX"));

            Assert.ThrowsException<ArgumentException>(() => rn.Sub(""));
            Assert.ThrowsException<ArgumentException>(() => rn.Sub("-"));
            Assert.ThrowsException<ArgumentException>(() => rn.Sub("-N"));
            Assert.ThrowsException<ArgumentException>(() => rn.Sub("XN"));
        }




    }


}
