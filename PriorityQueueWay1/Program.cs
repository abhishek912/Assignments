using System;

namespace PriorityQueueWay1
{
    class Program
    {
        static void Main(string[] args)
        {
            PriorityQueue<int> queue = new PriorityQueue<int>(true);

            Random rnd = new Random();
            Console.WriteLine("Enqueue: ");
            for (int i = 0; i < 10; i++)
            {
                int x = rnd.Next(100);
                Console.WriteLine($"{x}");
                queue.Enqueue(x, x);
            }

            Console.WriteLine($"Peek: {queue.Peek()}");
            queue.Dequeue();
            Console.WriteLine($"Highest Priority: {queue.GetHeighestPriority()}");
            queue.Dequeue();
            Console.WriteLine($"Peek: {queue.Peek()}");
            Console.WriteLine($"Number of elements: {queue.Count}");
            Console.WriteLine($"Constains 12: {queue.Contains(12)}");

            Console.WriteLine("Dequeue: ");
            while (queue.Count > 0)
            {
                Console.WriteLine(queue.Dequeue());
            }
            Console.Write("Press any key to Consitue...");
            Console.ReadLine();
        }
    }
}
