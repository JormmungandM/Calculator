using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorProject.App
{
    /* Main class - start program */
    public class Calculator
    {
        private readonly Resources Resources;    // Dependency 

        public Calculator(Resources resources)
        {
            Resources = resources;
        }

        private void NumberEntry(String? input, RomanNumber? rn)
        {         
            do
            {
                Console.Write(Resources.GetEnterNumberMessage());
                input = Console.ReadLine();
                try
                {
                    rn = new RomanNumber(RomanNumber.Parse(input!));
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("System error. Program terminated");
                    return;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }

            } while (rn == null);

        }

        public void Run()
        {
            String? input = null;
            RomanNumber? rn1 = null, rn2 = null;

            NumberEntry(input, rn1);
            NumberEntry(input, rn2);

            Console.WriteLine(Resources.GetResultMessage() + rn1.ToString() + " + " + rn1.ToString() + " = " +rn1.Add(rn2).ToString());

        }
     }
}
