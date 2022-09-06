using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculatorProject.App;

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

        [TestMethod] //Парсим симыолы в числа
        public void RomanNumberParse()
        {
            Assert.AreEqual(RomanNumber.Parse("I"), 1, "I == 1");
            Assert.AreEqual(RomanNumber.Parse("IV"), 4, "IV == 4");
            Assert.AreEqual(RomanNumber.Parse("XV"), 15, "XV == 15");
            Assert.AreEqual(RomanNumber.Parse("XXX"), 30, "XXX == 30");
            Assert.AreEqual(RomanNumber.Parse("CM"), 900, "CM == 900");
            Assert.AreEqual(RomanNumber.Parse("MCMXCIX"), 1999, "MCMXCIX == 1999");
            Assert.AreEqual(RomanNumber.Parse("CD"), 400, "CD == 400");
            Assert.AreEqual(RomanNumber.Parse("CDI"), 401, "CDI == 401");
            Assert.AreEqual(RomanNumber.Parse("LV"), 55, "LV == 55");
            Assert.AreEqual(RomanNumber.Parse("XL"), 40, "XL == 40");
        }
    }

    /*
    TDD - Test Driven Development - ðîçðàáîòêà óïðàâëÿåìîå òåñòàìè
    Ñóòü - ñíà÷àëà ïèøóòñÿ òåñòû, à ïîòîì ñîçäàþòñÿ ÏÎ, êîòîðîå óäîâëåòâîðÿåòñÿ ýòèìè òåñòàìè. 
    XP äîáàâëÿåò ìèíèìóì ïóòåé (áåç "çàïàñîâ")
     */

    //���� ������� �� �� �����



}

