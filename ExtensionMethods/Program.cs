using System;
using System.Collections.Generic;

namespace ExtensionMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            Random r = new Random();
            int i;
            Console.Write("List Elements: ");
            for(i=0; i<10; i++)
            {
                list.Add(r.Next(60));
                Console.Write(list[i]+" ");
            }
            Console.WriteLine();

            i = r.Next(100);
            Console.WriteLine($"{i} IsEven: {i.IsEven()}");
            i = r.Next(100);
            Console.WriteLine($"{i} IsOdd: {i.IsOdd()}");
            i = r.Next(100);
            Console.WriteLine($"{i} IsPrime: {i.IsPrime()}");
            i = r.Next(100);
            Console.WriteLine($"{i} IsDivisibleBy 5: {i.IsDivisibleBy(5)}");

            Console.WriteLine($"CustomAll(true, if all elements satisfies the condition) method: {list.CustomAll()}");
            Console.WriteLine($"CustomAny(true, if any element satisfies the condition) method: {list.CustomAny()}");
            Console.WriteLine($"CustomMax(Find Maximum element) method: {list.CustomMax()}");
            Console.WriteLine($"CustomMin(Find Minimum element) method: {list.CustomMin()}");

            Func<int, bool> inBetween = delegate (int ele) { return ele >= 12 && ele <= 25; };
            IEnumerable<int> newList = list.CustomWhere(inBetween);
            Console.Write($"CustomWhere(List of Elements satisfying the condition) method: ");
            foreach (var ele in newList)
            {
                Console.Write(ele+" ");
            }
            Console.WriteLine();

            newList = list.CustomWhere(inBetween);
            Console.Write($"CustomSelect(List of Elements satisfying the condition) method: ");
            foreach (var ele in newList)
            {
                Console.Write(ele + " ");
            }
            Console.WriteLine();

            Console.Write("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
