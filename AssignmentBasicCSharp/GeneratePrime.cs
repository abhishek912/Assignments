using System;
using System.Globalization;

namespace AssignmentBasicCSharp
{
    class GeneratePrime
    {
        private int startNumber = 2, endNumber = 1000, primeArraySize = 0;
        private int MAXSIZE = 200;
        private int[] primeNumbersArray;

        //static void Main(string[] args)
        private void MainFn()
        {
            Console.WriteLine("***Program to print Prime Numbers between two given numbers***");
            
            GeneratePrime prime = new GeneratePrime();
            prime.TakeInput();
            prime.GeneratePrimeNumbers();

            Console.WriteLine("Prime Numbers between {0} and {1} are : ", prime.startNumber, prime.endNumber);
            prime.PrintNumbers();

            Console.ReadLine();
        }

        private void TakeInput()
        {
            bool inputFlag = false;
            do
            {
                Console.Write("Please Enter the Start Number(between 2 and 1000): ");
                startNumber = Int32.Parse(Console.ReadLine(), NumberStyles.Integer);

                Console.Write("Please Enter the End Number(between 2 and 1000) : ");
                endNumber = Int32.Parse(Console.ReadLine(), NumberStyles.Integer);

                if (startNumber >= 2 && endNumber <= 1000 && startNumber < endNumber)
                {
                    inputFlag = true;
                }
                else if (startNumber > endNumber)
                {
                    Console.WriteLine("Error : Start Number should be Greater than End Number!!!");
                    Console.WriteLine("Please re-enter the two numbers.");
                }
                else if (startNumber == endNumber)
                {
                    Console.WriteLine("Error : Start Number should not be equal to the End Number!!!");
                    Console.WriteLine("Please re-enter the two numbers.");
                }
                else
                {
                    Console.WriteLine("Error : Something went wrong!!!");
                    Console.WriteLine("Please re-enter the two numbers.");
                }

            } while (!inputFlag);
        }

        private void GeneratePrimeNumbers()
        {
            primeNumbersArray = new int[MAXSIZE];
            int index = 0;
            for(int i=startNumber; i<=endNumber; i++)
            {
                if (CheckPrime(i))
                {
                    primeNumbersArray[index++] = i;
                }
            }
            primeArraySize = index;
        }

        private void PrintNumbers()
        {
            for(int i=0; i<primeArraySize; i++)
            {
                Console.WriteLine(primeNumbersArray[i]);
            }
        }

        private bool CheckPrime(int number)
        {
            if (number == 2 || number == 3)
            {
                return true;
            }
            for(int i=2; i<=number/2; i++)
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
