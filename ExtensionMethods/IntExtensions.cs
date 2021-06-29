namespace ExtensionMethods
{
    public static class IntExtensions
    {
        public static bool IsEven(this int value)
        {
            return value % 2 == 0;
        }

        public static bool IsOdd(this int value)
        {
            return value % 2 != 0;
        }

        public static bool IsPrime(this int value)
        {

            return CheckPrime(value);
        }

        public static bool IsDivisibleBy(this int i, int value)
        {
            return i % value == 0;
        }

        private static bool CheckPrime(int number)
        {
            if (number <= 1)
            {
                return false;
            }

            if (number == 2 || number == 3)
            {
                return true;
            }
            for (int i = 2; i <= number / 2; i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
