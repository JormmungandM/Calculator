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

        private RomanNumber NumberEntry()
        {
            String? input;
            RomanNumber? rn = null;
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
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }

            } while (rn == null);
            return rn;
        }

        public void RunOld()
        {
            ;
            RomanNumber
                rn1 = NumberEntry(),
                    rn2 = NumberEntry();

            Console.WriteLine(Resources.GetResultMessage(rn1!.ToString(), rn2!.ToString(), rn1.Add(rn2).ToString())); //Old method GetResultMessage

        }

        // Splitting the expressions and returning the result
        public RomanNumber EvalExpressions (String expression)
        {
            String[] parts = expression!.Split(" ", StringSplitOptions.RemoveEmptyEntries); //splitting a string

            if (parts.Length != 3) throw new ArgumentException(Resources.GetInvalidExpressionMessage());   // exceptions for an expression where there is more than one operation

            // Create roman numbers
            RomanNumber rn1 = new(RomanNumber.Parse(parts[0]));
            RomanNumber rn2 = new(RomanNumber.Parse(parts[2]));


            // will return the result of the operation selected by the user
            return parts[1] switch
            {
                "+" => rn1.Add(rn2),                                                                                                             //  Addition operation
                "-" => rn1.Sub(rn2),                                                                                                              //  Subtraction operation
                "*" => rn1.Mul(rn2),                                                                                                              //  Multiplication operation
                "/" => rn1.Div(rn2),                                                                                                               //  Division operation
                _ => throw new ArgumentException(Resources.GetInvalidOperationMessage(parts[1]))      //  Exception if unsupported operation
            };
        }

        public void Run()
        {
            String? userIn;  // User input

            // Writing a message and reading a answer
            Console.Write(Resources.GetEnterLanguageMessage());  
            userIn = Console.ReadLine() ?? "";

            if(Array.IndexOf(Resources.cultures, userIn) == -1)   
                throw new Exception(Resources.GetUnsupportedCultureMessage(userIn));  // Exception if unsupported culture
            else  
                Resources.Culture = userIn;  // Setting user culture

            RomanNumber res = null!;  // value to result operation
            do
            {
                Console.Write(Resources.GetExpressionMessage());      // Expression input message
                userIn = Console.ReadLine() ?? "";                                  // Reading a answer
                try
                {
                    res = EvalExpressions(userIn);  // Using a method to get a result
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);  // Exception if invalid expression
                }
            }while (res is null);
            
            Console.WriteLine(Resources.GetResultMessage(userIn, res.ToString()));  // Getting a message with result to console
            
        }



     }
}
