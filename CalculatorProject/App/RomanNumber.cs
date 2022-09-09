﻿namespace CalculatorProject.App
{
    //Class for working with roman number
    public record  RomanNumber
    {
        int number;

        public RomanNumber(int number_ = 0)
        {
            number = number_;
        }

        //property for number 
        public int Number {
            set { number = value;  }
            get { return number; }
        }

        public override string ToString()
        {
            if (this.number == 0)
            {
                return "N";
            }
            int n = this.number < 0 ? -this.number : this.number;
            String res = this.number < 0 ? "-" : "";
            String[] parts = { "M" , "CM" ,  "D" , "CD" ,  "C" , "XC" , "L" , "XL" , "X" , "IX" ,  "V" ,  "IV" ,  "I" };
            int[] values = { 1000 , 900 ,  500 ,  400 , 100 ,  90 , 50 , 40 , 10 , 9 , 5 , 4 , 1  };

            for (int j = 0; j <= parts.Length - 1; j++)
            {
                while (n >= values[j])
                {
                    n -= values[j];
                    res += parts[j];
                }
            }

            return res;
        }

        //Getting a Roman number
        public static int Parse(String str)
        {          
            if(str == null)//String is null
            {
                throw new ArgumentNullException(); 
            }
            if (str == "N") //Zero number
            {
                return 0;
            }

            //Negative value
            bool isNegative = false; //key for negative symbol
            if (str.StartsWith('-'))//if the str have a negative symbol, then we switch the key and remove the symbol
            {
                isNegative = true; 
                str = str[1..]; 
            }

            if ( str.Length < 1)//Null exception
            {
                throw new ArgumentException("Empty string not allowed");
            }

            char[] digits = { 'I','V','X','L','C','D','M'};
            int[] digitValues = { 1, 5, 10, 50, 100, 500, 1000 };
            //If we have number big when true is a below
            // IX : -1 + 10; XC +10+100; XX: +10+10; CX: +100+10;

            int pos = str.Length - 1; // Position last number
            char digit = '\0'; //Symbol number
            int ind = 0, val = 0, res = 0; //Position number in array

            //enumerating characters
            while (pos != -1)
            {
                digit = str[pos]; //Symbol number
                ind = Array.IndexOf(digits, digit); //Position number in array

                if (ind == -1)//exeption 
                {
                    throw new ArgumentException($"Invalid char {digit}");
                }
                val = digitValues[ind]; //Digit value

                //replacing characters with numbers
                if (pos + 1 < str.Length - 1 &&  digit == str[pos + 1]  ) res += val;
                else if (res > val) res -= val;
                else res += val;

                pos -= 1;
            }

            //if key true, then return negative symbol 
            return isNegative ? -res : res;
        }


        public RomanNumber Add( RomanNumber rn)
        {
            if (rn is null)
            {
                throw new ArgumentNullException(nameof(rn));
            }
            return new(this.number + rn.Number);
        }
        public RomanNumber Add(int rn)
        {
            return new(this.number + rn);
        }
        public RomanNumber Add(String rn)
        {
            return new(this.number + Parse(rn));
        }



        //Static add methods (homework)
        //Results of static methods - new objects
        static public RomanNumber Add(RomanNumber a, RomanNumber b) //Only object
        {
            return new(a.Number + b.Number);
        }

        static public RomanNumber Add(RomanNumber a, int b)// object plus number
        {
            return new(a.Number + b);
        }

        static public RomanNumber Add(int a, RomanNumber b)// number plus object
        {
            return new(a + b.Number);
        }

        static public RomanNumber Add(RomanNumber a, String b) // number plus object
        {
            return new(a.Number + Parse(b));
        }

        static public RomanNumber Add(String a, RomanNumber b)// string plus object
        {
            return new(Parse(a) + b.Number);
        }

        static public RomanNumber Add(String a, String b)//only string
        {
            return new(Parse(a) + Parse(b));
        }

        static public RomanNumber Add(String a, int b)// string plus number
        {
            return new(Parse(a) + b);
        }

        static public RomanNumber Add(int a, String b)// number plus string
        {
            return new(a + Parse(b));
        }

        static public RomanNumber Add(int a, int b)// only number
        {
            return new(a + b);
        }

    }
}
