using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentBasicCSharp
{
    class BasicCSharp
    {
        static void Main(string[] args)
        {
            //Converts input number(string) to Integer using Convert.ToInt method
            Console.WriteLine("******Convert.ToInt******");
            Console.WriteLine("Please Enter the number : ");
            string input = Console.ReadLine();
            int firstNumber = Convert.ToInt16(input);
            Console.WriteLine("String number --> {0} & Converted to Int16 --> {1}", input, firstNumber);

            Console.WriteLine("Please Enter the number : ");
            int secondNumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("String number --> {0} & Converted to Int32 --> {1}", Convert.ToString(secondNumber), secondNumber);

            Console.WriteLine("Please Enter the number : ");
            long thirdNumber = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine("String number --> {0} & Converted to Int64 --> {1}", Convert.ToString(thirdNumber), thirdNumber);


            //Converts input number(string) to Integer using int.Parse method
            /*
            * long Parse(String, NumberStyle, IFormatProvider)
            * 
            * About parameters:
            * String: string to be parsed or converted.
            * NumberStyle(optional): defines the style element that are allowed for the parse operation to succedd
            * IFormatProvider(optional): to specify the curture like indian, UK, US, etc.
            * 
            * Exception(may occur): ArgumentNullException, FormatException, OverflowException
            */
            Console.WriteLine("******Parse******");
            Console.WriteLine("Please Enter the number : ");
            long amount = Int64.Parse(Console.ReadLine(), NumberStyles.Float|NumberStyles.AllowThousands, new CultureInfo("en-GB")); //Input Ex: 12,000.00 12,000 12000.00
            Console.WriteLine("Ämount is : {0}", amount);

            Console.WriteLine("Please Enter the number : ");
            amount = Int64.Parse(Console.ReadLine(), NumberStyles.Currency|NumberStyles.AllowDecimalPoint, new CultureInfo("en-US"));
            Console.WriteLine("Ämount is : {0}", amount);

            Console.WriteLine("Please Enter the number : ");
            amount = Int64.Parse(Console.ReadLine(), NumberStyles.AllowCurrencySymbol);
            Console.WriteLine("Ämount is : {0}", amount);

            Console.WriteLine("Please Enter the number : ");
            amount = Int64.Parse(Console.ReadLine());       //used with simple input like trailing spaces, +, -
            Console.WriteLine("Ämount is : {0}", amount);

            /* bool TryParse(String, NumberStyles(optional), IFormatProvider(optional), Int64)
             *       
             * About parameters:
             * Int64(result): When this method returns, contains the 64-bit signed integer value 
             *                equivalent of the number contained in string, if the conversion succeeded, 
             *                or zero if the conversion failed.
             */
            Console.WriteLine("******TryParse******");
            Console.WriteLine("Please enter the number : ");
            bool value = Int64.TryParse(Console.ReadLine(), out long number);
            if (value)
            {
                Console.WriteLine("Parsed number is {0} & {1}: ", number, value);
            }
            else
            {
                Console.WriteLine("Sorry cannot parse {0} & {1}: ", number, value);
            }
            Console.ReadKey();

            Console.WriteLine("Please enter the number : ");
            NumberFormatInfo provider = new NumberFormatInfo();
            provider.NumberDecimalSeparator = ".";
            provider.NumberGroupSeparator = ",";
            double num = Convert.ToDouble(Console.ReadLine(), provider);
            Console.WriteLine(num);

            if (double.TryParse(Console.ReadLine(), out double result))
            {
                Console.WriteLine("Converted value : {0}", result);
            }
            else
            {
                Console.WriteLine("Cannot be converted");
            }
            string num1 = Console.ReadLine();
            Console.WriteLine("Converted value of {0} is {1}", num1, Double.Parse(num1));
            
            Console.ReadKey();
        }
    }
}

