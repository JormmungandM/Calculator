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


        // UA localization
        public  String Culture { get; set; } = "uk-UA";


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
        public  String GetInvalidTypeMessage(int objNumber, String type, String? culture = null)
        {
            if (culture == null) culture = Culture;
            return culture switch
            {
                "uk-UA" => $"obj{objNumber}: тип '{type}' не підтримується",
                "en-US" => $"obj{objNumber}: type '{type}' unsupported",
                _ => throw new Exception("Unsupported culture")
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



        ///////////////////////////////////////////////////////////////

        // UI resources

        // all methods has these clauses
        // checking for null culture
        // some localization (uk-UA and en-US)
        // exceptions for unsupported culture


        //Enter number
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
        public  String GetResultMessage(String? culture = null) 
        {
            culture ??= Culture;            
            return culture switch
            {
                "uk-UA" => $"Результат: ",                               
                "en-US" => $"Result: ",                                    
                _ => throw new Exception("Unsupported culture"), 
            };
        }

    }
}
