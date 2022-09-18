using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorProject.App
{
    // Class with resources of program
    public  class Resources
    {
        public readonly String[] cultures = { "uk-UA", "en-US" };

        // UA localization
        public  String Culture { get; set; } = "uk-UA";

        private String GetAllCultures()
        {
            String temp = "\n";
            for (int i = 0; i < cultures.Length; i++)
            {
                temp += cultures[i] + "\n";
            }
            return temp;
        }
        // Exceptions resources

        // all methods has these clauses
        // checking for null culture
        // some localization (uk-UA and en-US)
        // exceptions for unsupported culture


        // Invalid message
        public  String GetInvalidCharMessage(char c, String? culture = null)
        {
            culture ??= Culture;
            return culture switch
            {
                "uk-UA" => $"Недозволений символ '{c}'",
                "en-US" => $"Invalid char '{c}'",
                _ => throw new Exception("Unsupported culture")
            };
        }
        public  String GetInvalidTypeMessage( String type, String? culture = null)
        {
            if (culture == null) culture = Culture;
            return culture switch
            {
                "uk-UA" => $"Тип аргумента '{type}' не підтримується",
                "en-US" => $"Argument type '{type}' unsupported",
                _ => throw new Exception("Unsupported culture")
            };
        }
        public String GetInvalidExpressionMessage(String? culture = null)
        {
            culture ??= Culture;
            return culture switch
            {
                "uk-UA" => $"Недозволений вираз ",
                "en-US" => $"Invalid expression",
                _ => throw new Exception("Unsupported culture")
            };
        }
        public String GetInvalidOperationMessage(String operation, String? culture = null)
        {
            culture ??= Culture;
            return culture switch
            {
                "uk-UA" => $"Недійсна операція '{operation}' ",
                "en-US" => $"Invalid operation '{operation}'",
                _ => throw new Exception("Unsupported culture")
            };
        }
        public String GetUnsupportedCultureMessage(String? Uculture, String? culture = null)
        {
            culture ??= Culture;
            return culture switch
            {
                "uk-UA" => $"Непідтримувана культура {Uculture}: ",
                "en-US" => $"Unsupported culture {Uculture}: ",
                _ => throw new Exception("Unsupported culture"),
            };
        }

        // Empty message
        public  String GetEmptyObjectMessage(String? culture = null)
        {
            culture ??= Culture;
            return culture switch
            {
                "uk-UA" => $"Порожний рядок не дозволено",
                "en-US" => $"Empty object not allowed",
                _ => throw new Exception("Unsupported culture")
            };
        }
        public  String GetEmptyObjectMessage(int objNumber, String? culture = null)
        {
            culture ??= Culture;
            return culture switch
            {
                "uk-UA" => $"Порожний об'єкт { objNumber} : не дозволено",
                "en-US" => $"Empty object {objNumber} : not allowed",
                _ => throw new Exception("Unsupported culture")
            };
        }
        public  String GetEmptyStringMessage(String? culture = null)
        {
            culture ??= Culture;
            return culture switch
            {
                "uk-UA" => $"Порожнiй рядок ",
                "en-US" => $"Empty string not allowed",
                _ => throw new Exception("Unsupported culture")
            };
        }

        // System error
        public String GetSystemErrorMessage(String? culture = null)
        {
            culture ??= Culture;
            return culture switch
            {
                "uk-UA" => $"Системна помилка. Програму припинено ",
                "en-US" => $"System error. Program terminated",
                _ => throw new Exception("Unsupported culture")
            };
        }

        // N message
        public  String GetMisplacedNMessage(String? culture = null)
        {
            culture ??= Culture;
            return culture switch
            {
                "uk-UA" => $"'N' недозволяеться у даному контекстi ",
                "en-US" => $"'N' is not allowed in this context",
                _ => throw new Exception("Unsupported culture")
            };
        }
        public String GetDivisionNMessage(String? culture = null)
        {
            culture ??= Culture;
            return culture switch
            {
                "uk-UA" => $"Ділення на нуль ('N') не допускається ",
                "en-US" => $"Division by zero ('N') is not allowed",
                _ => throw new Exception("Unsupported culture")
            };
        }


        ///////////////////////////////////////////////////////////////

        // UI resources

        // all methods has these clauses
        // checking for null culture
        // some localization (uk-UA and en-US)
        // exceptions for unsupported culture

        // Select language
        public String GetEnterLanguageMessage(String? culture = null)
        {
            culture ??= Culture;
            return culture switch
            {
                "uk-UA" => $"Оберіть мову: {GetAllCultures()} -> ",
                "en-US" => $"Select language: {GetAllCultures()} -> ",
                _ => throw new Exception("Unsupported culture"),
            };
        }

        // Enter number
        public  String GetEnterNumberMessage(String? culture = null)
        {
            culture ??= Culture;
            return culture switch
            {
                "uk-UA" => "Введiть число: ",                                   
                "en-US" => "Enter number: ",                                    
                _ => throw new Exception("Unsupported culture"),   
            };
        }

        //  Enter expression
        public String GetExpressionMessage(String? culture = null)
        {
            culture ??= Culture;
            return culture switch
            {
                "uk-UA" => "Введіть вираз (наприклад, XC + CD): ",
                "en-US" => "Enter exptrssion (like XC + CD): ",
                _ => throw new Exception("Unsupported culture"),
            };
        }

        // Enter operation
        public  String GetEnterOperationMessage(String? culture = null)
        {
            culture ??= Culture;
            return culture switch
            {
                "uk-UA" => "Введiть операцiю: ",                             
                "en-US" => "Enter operation: ",                                
                _ => throw new Exception("Unsupported culture"),   
            };
        }

        // Result
        public  String GetResultMessage(String? expression , String? result, String? culture = null) 
        {
            culture ??= Culture;            
            return culture switch
            {
                "uk-UA" => $"Результат: {expression} = {result}",                               
                "en-US" => $"Result: {expression} = {result}",                                    
                _ => throw new Exception("Unsupported culture"), 
            };
        }

    }
}
