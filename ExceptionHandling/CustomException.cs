using System;
using System.Threading;

namespace ExceptionHandling
{
    public class NumberOutOfRange : Exception
    {
        public NumberOutOfRange(string message) : base(message) { }
    }

    public class NumberFormatException : Exception
    {
        public NumberFormatException(string message) : base(message) { }
    }

    public class GameLimitExceed : Exception
    {
        public GameLimitExceed(string message) : base(message) { }
    }

    public class NotEvenNumber : Exception
    {
        public NotEvenNumber(string message) : base(message) { }
    }

    public class NotOddNumber : Exception
    {
        public NotOddNumber(string message) : base(message) { }
    }

    public class NotPrimeNumber : Exception
    {
        public NotPrimeNumber(string message) : base(message) { }
    }

    public class NotNegativeNumber : Exception
    {
        public NotNegativeNumber(string message) : base(message) { }
    }

    public class NotZeroNumber : Exception
    {
        public NotZeroNumber(string message) : base(message) { }
    }
}
