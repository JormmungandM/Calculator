using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorProject.App
{
    // Class with resources of program
    public static class Resources
    {
        // UA localization
        public static String Culture { get; set; } = "uk-UA";


        // Exceptions resources

        // all methods has these clauses
        // checking for null culture
        // some localization (uk-UA and en-US)
        // exceptions for unsupported culture




        // Invalid Message
        public static String GetInvalidCharMessage(char c, String? culture = null)
        {
            culture ??= Culture;
            return culture switch
            {
                "uk-UA" => $"Недозволений символ '{c}'",
                "en-US" => $"Invalid char '{c}'",
                _ => throw new Exception("Unsupported culture")
            };
        }
        public static String GetInvalidTypeMessage(int objNumber, String type, String? culture = null)
        {
            if (culture == null) culture = Culture;
            return culture switch
            {
                "uk-UA" => $"obj{objNumber}: тип '{type}' не підтримується",
                "en-US" => $"obj{objNumber}: type '{type}' unsupported",
                _ => throw new Exception("Unsupported culture")
            };
        }

        // Empty Message
        public static String GetEmptyObjectMessage(String? culture = null)
        {
            culture ??= Culture;
            return culture switch
            {
                "uk-UA" => $"Порожний рядок не дозволено",
                "en-US" => $"Empty object not allowed",
                _ => throw new Exception("Unsupported culture")
            };
        }
        public static String GetEmptyObjectMessage(int objNumber, String? culture = null)
        {
            culture ??= Culture;
            return culture switch
            {
                "uk-UA" => $"Порожний об'єкт { objNumber} : не дозволено",
                "en-US" => $"Empty object {objNumber} : not allowed",
                _ => throw new Exception("Unsupported culture")
            };
        }
        public static String GetEmptyStringMessage(String? culture = null)
        {
            culture ??= Culture;
            return culture switch
            {
                "uk-UA" => $"Порожнiй рядок ",
                "en-US" => $"Empty string not allowed",
                _ => throw new Exception("Unsupported culture")
            };
        }

        // N Message
        public static String GetMisplacedNMessage(String? culture = null)
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
        public static String GetEnterNumberMessage(String? culture = null)
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
        public static String GetEnterOperationMessage(String? culture = null)
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
        public static String GetResultMessage(int res, String? culture = null) 
        {
            culture ??= Culture;            
            return culture switch
            {
                "uk-UA" => $"Результат: {res}",                               
                "en-US" => $"Result: {res}",                                    
                _ => throw new Exception("Unsupported culture"), 
            };
        }

    }
}
