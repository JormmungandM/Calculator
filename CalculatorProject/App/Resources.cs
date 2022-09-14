using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorProject.App
{
    // Class with Resources of program
    public static class Resources
    {
        // UA localization
        public static String Culture { get; set; } = "uk-UA";

        public static String GetEmptyStringMessage(String? culture = null)
        {
            if (culture == null) culture = Culture;         
            switch (culture)
            {
                case "uk-UA": return "Порожнiй рядок ";
                case "en-US": return "Empty string not allowed";
            }
            throw new Exception("Unsupported culture");
        }

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

        public static String GetEmptyObjectMessage(String? culture = null)
        {
            if (culture == null) culture = Culture;
            return culture switch
            {
                "uk-UA" => $"Порожний рядок не дозволено",
                "en-US" => $"Empty object not allowed",
                _ => throw new Exception("Unsupported culture")
            };
        }

        public static String GetEmptyObjectMessage(int objNumber, String? culture = null)
        {
            if (culture == null) culture = Culture;
            return culture switch
            {
                "uk-UA" => $"Порожний об'єкт { objNumber} : не дозволено",
                "en-US" => $"Empty object {objNumber} : not allowed",
                _ => throw new Exception("Unsupported culture")
            };
        }

        public static String GetMisplacedNMessage(String? culture = null)
        {
            if (culture == null) culture = Culture;
            return culture switch
            {
                "uk-UA" => $"'N' недозволяеться у даному контекстi ",
                "en-US" => $"'N' is not allowed in this context",
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


    }
}
