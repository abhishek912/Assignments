using System;
using System.Collections.Generic;
using System.Linq;

namespace DelegateLambda
{
    public delegate int Helper();
    public delegate List<int> Helper1();
    public delegate List<int> Helper2(int[] list);
    public delegate List<int> Helper3(int[] list, int value, int divisibleBy);
    class DelegateClass
    {
        public static List<int> FindDivisibleAndAdd(int[] list, int value = 0, int divisibleBy = 1)
        {
            return list.Where(x => (x % divisibleBy == 0)).Select(x => x + value).ToList();
        }

        public static bool CheckPrime(int number)
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

        public static List<int> GetElementsGreaterThanFive(int[] list)
        {
            return list.Where(x => x > 5).ToList();
        }

        public static List<int> GetElementsLessThanFive(int[] list)
        {
            return list.Where(x => x < 5).ToList();
        }

        public void MainMethod()
        {
            int[] list = new int[10];
            Random rnd = new Random();
            Console.Write("My List : ");
            for (int i = 0; i < 10; i++)
            {
                list[i] = rnd.Next(100);
                Console.Write(list[i]+" ");
            }
            Console.WriteLine("\n");
            
            Helper h;

            h = () => list.Where(x => x % 2 != 0).First();
            Console.WriteLine($"Odd Value present in a list is: {h()}\n");

            h = () => { return list.Where(x => x % 2 == 0).First(); };
            Console.WriteLine($"Even Value present in a list is: {h()}\n");

            h = delegate () { return list.Where(x => CheckPrime(x) == true ).First(); };
            Console.WriteLine($"Prime Value present in a list is: {h()}\n");

            Helper1 h1 = () => { return list.Where(x => CheckPrime(x) == true).ToList(); };
            if(h1().Count > 1)
            {
                Console.WriteLine($"Another Prime Value present in a list is: {h1()[1]}\n");
            }
            else
            {
                Console.WriteLine($"No other Prime Value present in a list.\n");
            }

            Helper2 h2 = GetElementsGreaterThanFive;
            List<int> elements = h2(list);
            Console.Write("Elements greater than 5 are: ");
            foreach(var e in elements)
            {
                Console.Write(e+" ");
            }
            Console.WriteLine("\n");

            h2 = GetElementsLessThanFive;
            elements = h2(list);
            Console.Write("Elements less than 5 are: ");
            foreach (var e in elements)
            {
                Console.Write(e + " ");
            }
            Console.WriteLine("\n");

            h2 = (list1) => { return list1.Where(x => x % 3 == 0).ToList(); };
            Console.Write("Elements divisible by 3 are: ");
            foreach (var e in h2(list))
            {
                Console.Write(e + " ");
            }
            Console.WriteLine("\n");

            h2 = delegate(int[] list1) 
            {
                return list1.Where(x => (x % 3 == 0) ).Select(x => x + 1).ToList();
            };
            Console.Write("Elements divisible by 3 Added 1 to them: ");
            foreach (var e in h2(list))
            {
                Console.Write(e + " ");
            }
            Console.WriteLine("\n");

            h2 = (list1) => { return list1.Where(x => (x % 3 == 0)).Select(x => x + 2).ToList(); };
            Console.Write("Elements divisible by 3 Added 2 to them: ");
            foreach (var e in h2(list))
            {
                Console.Write(e + " ");
            }
            Console.WriteLine("\n");        

            Helper3 h3 = FindDivisibleAndAdd;
            List<int>list3 = h3(list, 10, 5);
            Console.Write("Elements divisible by 5 Added 10 to them: ");
            foreach (var e in list3)
            {
                Console.Write(e + " ");
            }
            Console.WriteLine("\n");
            Console.WriteLine("Exiting the Delegate Class!!!");
            Console.Write("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
