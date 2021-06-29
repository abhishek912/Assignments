using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentOOPs
{
    class Program
    {
		public static void Main(string[] args)
        {
			Stack<int> numbers = new Stack<int>();

			numbers.Push(1);
			numbers.Push(2);
			numbers.Push(3);
			numbers.Push(4);

			int peek = numbers.Peek();
			Console.WriteLine($"Peek : {peek}");
			numbers.Pop();

			int pop = numbers.Pop();
			Console.WriteLine($"Pop : {pop}");

			while(numbers.Count > 0)
            {

            }
		}
    }
}
