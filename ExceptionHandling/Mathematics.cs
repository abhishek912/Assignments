using System;

namespace ExceptionHandling
{
    class Mathematics
    {
        public bool Validate(string input)
        {
            int value = 0;
            if (!int.TryParse(input, out value))
            {
                Console.WriteLine("Input must be an Integer between(1-5)!!!");
                throw (new NumberFormatException("Input must be an Integer between(1-5)!!!"));
            }
            else if (value <= 0 || value > 5)
            {
                Console.WriteLine("Enter Number is Out of specified range!!!");
                throw (new NumberOutOfRange("Enter Number is Out of specified range!!!"));
            }
            return true;
        }

        public bool ValidateNum(string input)
        {
            int value = 0;
            if (!int.TryParse(input, out value))
            {
                Console.WriteLine(("Not A Number Exception!!!"));
                throw (new NumberFormatException("Not A Number Exception!!!"));
            }
            return true;
        }

        public bool IsLimitReached(int gameCount)
        {
            bool result = gameCount % 5 == 0 ? true : false;
            if (result)
            {
                Console.WriteLine($"Yay, You have played this game {gameCount} times!!!");
                throw (new GameLimitExceed($"Yay, You have played this game {gameCount} times!!!"));
            }
            return result;
        }

        public bool IsEven(int Number)
        {
            bool result = Number % 2 == 0 ? true : false;
            if (!result)
            {
                Console.WriteLine("Oops, Number you entered is not Even!!!");
                throw (new NotEvenNumber("Oops, Number you entered is not Even!!!"));
            }
            return result;
        }

        public bool IsOdd(int Number)
        {
            bool result = Number % 2 != 0 ? true : false;
            if (!result)
            {
                Console.WriteLine("Oops, Number you entered is not Odd!!!");
                throw (new NotOddNumber("Oops, Number you entered is not Odd!!!"));
            }
            return result;
        }

        public bool IsPrime(int Number)
        {
            if (Number <= 1)
            {
                Console.WriteLine("Oops, Number you entered is not Prime!!!");
                throw (new NotOddNumber("Oops, Number you entered is not Prime!!!"));
            }
            if (Number == 2 || Number == 3)
            {
                return true;
            }
            for (int i = 2; i <= Number / 2; i++)
            {
                if (Number % i == 0)
                {
                    Console.WriteLine("Oops, Number you entered is not Prime!!!");
                    throw (new NotOddNumber("Oops, Number you entered is not Prime!!!"));
                }
            }
            return true;
        }

        public bool IsNegative(int Number)
        {
            bool result = Number < 0 ? true : false;
            if (!result)
            {
                Console.WriteLine("Oops, Number you entered is not Negative!!!");
                throw (new NotOddNumber("Oops, Number you entered is not Negative!!!"));
            }
            return result;
        }

        public bool InZero(int Number)
        {
            bool result = Number == 0 ? true : false;
            if (!result)
            {
                Console.WriteLine("Oops, Number you entered is not Zero!!!");
                throw (new NotOddNumber("Oops, Number you entered is not Zero!!!"));
            }
            return result;
        }

    }
}
