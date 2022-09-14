namespace CalculatorProject.App
{
    // Class for working with roman number
    public record  RomanNumber
    {
        const char ZERO_DIGIT = 'N';
        int number;

        public RomanNumber(int number_ = 0)
        {
            number = number_;
        }
       
        public int Number  // property for number 
        {
            set { number = value;  }
            get { return number; }
        }
        public override string ToString()  // Method convert number to string
        {
            if (this.number == 0)  // If number is a zero, then return "N" letter
            {
                return ZERO_DIGIT.ToString();
            }

            // check for negative
            int n = this.number < 0 ? -this.number : this.number;
            String res = this.number < 0 ? "-" : "";

            // buff letter & number
            String[] parts = { "M" , "CM" ,  "D" , "CD" ,  "C" , "XC" , "L" , "XL" , "X" , "IX" ,  "V" ,  "IV" ,  "I" }; 
            int[] values = { 1000 , 900 ,  500 ,  400 , 100 ,  90 , 50 , 40 , 10 , 9 , 5 , 4 , 1  };

            // loop converting number to string
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
        public static int Parse(String str)  // Getting a Roman number
        {          
            if(str == null)   // String is null
            {
                throw new ArgumentNullException(Resources.GetEmptyStringMessage()); 
            }
            if (str == ZERO_DIGIT.ToString())   // Zero number
            {
                return 0;
            }

            //Negative value
            bool isNegative = false;    // key for negative symbol
            if (str.StartsWith('-'))    // if the str have a negative symbol, then we switch the key and remove the symbol
            {
                isNegative = true; 
                str = str[1..]; 
            }

            if ( str.Length < 1)  // Null exception
            {
                throw new ArgumentException(Resources.GetEmptyStringMessage());
            }

            char[] digits = { 'I','V','X','L','C','D','M'};
            int[] digitValues = { 1, 5, 10, 50, 100, 500, 1000 };
            // If we have number big when true is a below
            // IX : -1 + 10; XC +10+100; XX: +10+10; CX: +100+10;

            int pos = str.Length - 1;        // Position last number
            char digit = '\0';                  // Symbol number
            int ind = 0, val = 0, res = 0;   // Position number in array

            //enumerating characters
            while (pos != -1)
            {
                digit = str[pos];                                // Symbol number
                ind = Array.IndexOf(digits, digit);   // Position number in array

                if (ind == -1)  // exeption 
                {
                    throw new ArgumentException(
                        digit == ZERO_DIGIT
                        ? Resources.GetMisplacedNMessage()
                        : Resources.GetInvalidCharMessage(digit) ); 
                }
                val = digitValues[ind];  // Digit value

                // replacing characters with numbers
                if (pos + 1 < str.Length - 1 &&  digit == str[pos + 1]  ) res += val;
                else if (res > val) res -= val;
                else res += val;

                pos -= 1;
            }

            // if key true, then return negative symbol 
            return isNegative ? -res : res;
        }

        /* Refactoring - the algorithm is repeated in each method
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
        }*/

        // New Add method after refactoring
        // Вместо дублирования алгоритма сложения мы создаем
        // объект из "сырых" данных и делегируемсложение другому методу.
        public RomanNumber Add(RomanNumber roman)
        {
            if (roman is null)
            {
                throw new ArgumentNullException(nameof(roman));
            }
            return new(this.number + roman.Number);
        }
        public RomanNumber Add(int integer)
        {         
            return this.Add(  new RomanNumber(integer)  );
        }
        public RomanNumber Add(String str)
        {
            return this.Add(  new RomanNumber(Parse(str))  );
        }


        /* Refactoring - the algorithm is repeated in each static method
        //  Static add methods (homework)
        //  Results of static methods - new objects
        static public RomanNumber Add(RomanNumber a, RomanNumber b)  //Only object
        {
            return new(a.Number + b.Number);
        }
        static public RomanNumber Add(RomanNumber a, int b)// object plus number
        {
            return new(a.Number + b);
        }
        static public RomanNumber Add(int a, RomanNumber b)  // number plus object
        {
            return new(a + b.Number);
        }
        static public RomanNumber Add(RomanNumber a, String b)  // number plus object
        {
            return new(a.Number + Parse(b));
        }
        static public RomanNumber Add(String a, RomanNumber b)  // string plus object
        {
            return new(Parse(a) + b.Number);
        }
        static public RomanNumber Add(String a, String b)  //only string
        {
            return new(Parse(a) + Parse(b));
        }
        static public RomanNumber Add(String a, int b)  // string plus number
        {
            return new(Parse(a) + b);
        }
        static public RomanNumber Add(int a, String b)  // number plus string
        {
            return new(a + Parse(b));
        }
        static public RomanNumber Add(int a, int b)  // only number
        {
            return new(a + b);
        }
        */


        /* New static Add method after refactoring

        static public RomanNumber Add(RomanNumber romanFirst, RomanNumber romanSecond)  // Only object
        {
            Refactoring - if in if
            if (romanFirst is null || romanSecond is null) {  
                throw new ArgumentNullException(
                     romanFirst is null ? nameof(romanFirst) : nameof(romanSecond));  
            }

            if (romanFirst is null)  throw new ArgumentNullException(nameof(romanFirst));
            if (romanSecond is null)  throw new ArgumentNullException(nameof(romanSecond));

            return romanFirst.Add(romanSecond);
        }
        static public RomanNumber Add(int integerFirst, int integerSecond) // only number
        {
            return new RomanNumber(integerFirst).Add(integerSecond);
        }
        static public RomanNumber Add(String str, int integer)  // string plus number
        {
            return new RomanNumber(integer).Add(str);
        }
        static public RomanNumber Add(int integer, String str)  // number plus string
        {
            return new RomanNumber(integer).Add(str);
        }
        static public RomanNumber Add(RomanNumber roman, int integer)  // object plus number
        {
            if (roman is null )
            {
                throw new ArgumentNullException("Null object");
            }
            return roman.Add(integer);
        }
        static public RomanNumber Add(int integer, RomanNumber roman)  // number plus object
        {
            if (roman is null)
            {
                throw new ArgumentNullException("Null object");
            }
            return roman.Add(integer);
        }
        static public RomanNumber Add(RomanNumber roman, String str)  // number plus object
        {
            if (roman is null)
            {
                throw new ArgumentNullException("Null object");
            }
            return roman.Add(str);
        }
        static public RomanNumber Add(String str, RomanNumber roman)  // string plus object
        {
            if (roman is null)
            {
                throw new ArgumentNullException("Null object");
            }
            return roman.Add(str);
        }
        static public RomanNumber Add(String strFirst, String strSecond)  //only string
        {
            return new RomanNumber(Parse(strFirst)).Add(strSecond);
        }
        */

        /*
        public static RomanNumber Add_Bad(object rn1, object rn2)
        {
            // Рефакторинг - разделение условий (условия внутри условия)
            //if (rn1 is null || rn2 is null)
            //{
            //  throw new ArgumentNullException(
            //        rn1 is null ? nameof(rn1) : nameof(rn2)) ;
           // }
            if (rn1 is null) throw new ArgumentNullException(nameof(rn1));
            if (rn2 is null) throw new ArgumentNullException(nameof(rn2));


             //Рефакторинг - соединение (перераспределение) условий
             //if (rn1 is int && rn2 is int) return new RomanNumber((int)rn1).Add((int)rn2);
             //else if (rn1 is String && rn2 is String) return new RomanNumber(RomanNumber.Parse((String)rn1)).Add((String)rn2);
             //else if (rn1 is int && rn2 is String) return new RomanNumber((int)rn1).Add((String)rn2);
             //else if (rn1 is String && rn2 is int) return new RomanNumber((int)rn2).Add((String)rn1);

              (rn1 is int && rn2 is int) + (rn1 is int && rn2 is String) -->
             (rn1 is int)(  rn2 is int  + rn2 is String )
              
            if (rn1 is int v1)
            {
                //Рефакторинг - если код присутствует во всех блоках, его нужно вынести
                if(rn2 is int v2) return new RomanNumber(v1).Add(v2);
                if(rn2 is String s2) return new RomanNumber(v1).Add(s2);
                
                var rn = new RomanNumber(v1);
                if (rn2 is int v2) return rn.Add(v2);
                if (rn2 is String s2) return rn.Add(s2);
            }
            if (rn1 is String s1)
            { 
                var rn = new RomanNumber(Parse(s1));
                if (rn2 is int v2) return rn.Add(v2);
                if (rn2 is String s2) return rn.Add(s2);
            }

            return new RomanNumber();
        }
        public static RomanNumber Add(object obj1, object obj2)
        {
            if (obj1 is null) throw new ArgumentNullException(nameof(obj1));
            if (obj2 is null) throw new ArgumentNullException(nameof(obj2));

            RomanNumber rn1, rn2;

            if (obj1 is int val1) rn1 = new RomanNumber(val1);
            else if (obj1 is String str1) rn1 = new RomanNumber(Parse(str1));
            else if (obj1 is RomanNumber rn) rn1 = new RomanNumber(rn);
            else throw new ArgumentException("obj1: type unsupported");

            if (obj2 is int val2) rn2 = new RomanNumber(val2);
            else if (obj2 is String str2) rn2 = new RomanNumber(Parse(str2));
            else if (obj2 is RomanNumber rn) rn2 = new RomanNumber(rn);
            else throw new ArgumentException("obj2: type unsupported");


            return rn1.Add(rn2);
        }
        */

        // Uses old static tests
        public static RomanNumber Add(object obj1, object obj2)
        {
            var pars = new object[] {obj1, obj2};   // array of input values
            var res = new RomanNumber(0);         // result object

            RomanNumber temp;                       //temp object. Stores unpacking
            for (int i = 0; i < pars.Length; i++)   //parses input value and adds to the result
            {
                if (pars[i] is null) throw new ArgumentNullException(Resources.GetEmptyObjectMessage(i+1));  // if the object is null then throw exception

                if (pars[i] is int val) temp = new RomanNumber(val);                                // int parse
                else if (pars[i] is String str) temp = new RomanNumber(Parse(str));       // string parse
                else if (pars[i] is RomanNumber rn) temp = rn;                                        // our object parse
                else throw new ArgumentException(
                    Resources.GetInvalidTypeMessage(i+1, pars[i].GetType().Name) );   // exception of unknown type

                res = res.Add(temp);   // added parsing result
            }
            return res; 
        }
    }
}
