using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorProject.App
{
    //Class for working with roman number
    public class RomanNumber
    {
        //Getting a number 
        public static int Parse(String str)
        {          
            char[] digits = {'N', 'I','V','X','L','C','D','M'};
            int[] digitValues = {0, 1, 5, 10, 50, 100, 500, 1000 };
            //If we have number big when true is a below
            // IX : -1 + 10; XC +10+100; XX: +10+10; CX: +100+10;

            int pos = str.Length - 1; // Position last number
            char digit = '\0'; //Symbol number
            int ind = 0, val = 0, res = 0; //Position number in array

            IEnumerable<char> charN =
                from ch in str
                where ch == 'N'
                select ch;
            if (charN.Count() > 1) throw new ArgumentException("No more than one 'N' is allowed");

            while (pos != -1)
            {
                digit = str[pos]; //Symbol number
                ind = Array.IndexOf(digits, digit); //Position number in array

                if (ind == -1)
                {
                    throw new ArgumentException($"Invalid char {digit}");
                }

                val = digitValues[ind]; //Digit value

                if (pos + 1 < str.Length - 1 &&  digit == str[pos + 1]  ) res += val;
                else if (res > val) res -= val;
                else res += val;

                pos -= 1;
            }
            return res;
            // тут результат обозначает результат
        }
    }
}
