using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackQueueQues
{
    class Program
    {
        static int[] prime;
        static void Main(string[] args)
        {
            //Question : Next Greater Element
            /*int T = int.Parse(Console.ReadLine());
            while(T > 0)
            {
                int N = int.Parse(Console.ReadLine());
                int[] arr = new int[N];
                string[] input = Console.ReadLine().Split(' ');
                for(int i = 0; i < N; i++)
                {
                    arr[i] = int.Parse(input[i]);
                }

                NextGreaterElement(arr);
                T--;
            }*/

            //Question : Stock Span
            /*int N = int.Parse(Console.ReadLine());
            int[] price = new int[N]; 
            for(int i=0; i<N; i++)
            {
                price[i] = int.Parse(Console.ReadLine());
            }

            Stack<int> indexStack = new Stack<int>();
            indexStack.Push(0);
            int[] stockSpan = new int[N];
            stockSpan[0] = 1;

            for(int i = 1; i < N; i++)
            {
                int count = 1;
                while(indexStack.Count > 0 && price[indexStack.Peek()] <= price[i])
                {
                    count += stockSpan[indexStack.Pop()];
                }
                indexStack.Push(i);
                stockSpan[i] = count;
            }
            for(int i = 0; i < price.Length; i++)
            {
                Console.Write(stockSpan[i] + " ");
            }
            Console.WriteLine("END");*/

            //Question : Playing with cards
            /*string[] input = Console.ReadLine().Split(' ');
            int N = int.Parse(input[0]), Q = int.Parse(input[1]);
            prime = new int[Q];
            Stack<int> A = new Stack<int>();
            input = Console.ReadLine().Split(' ');
            for (int i = 0; i < N; i++)
            {
                A.Push(int.Parse(input[i]));
            }
            GeneratePrime(Q);
            PlayingCards(A, Q);*/

            //Question : Hoodies at coding blocks
            int Q = int.Parse(Console.ReadLine());
            Queue<int> courseQueue = new Queue<int>();
            List<Queue<int>> queueOfStudentsEachCourse = new List<Queue<int>>();
            for(int i = 0; i < 4; i++)
            {
                queueOfStudentsEachCourse.Add(new Queue<int>());
            }

            for (int i = 0; i<Q; i++)
            {
                string[] input = Console.ReadLine().Split(' ');
                if(input[0] == "E")
                {
                    int course = int.Parse(input[1]);
                    int roll = int.Parse(input[2]);

                    if(courseQueue.Contains(course))
                    {
                        queueOfStudentsEachCourse[course - 1].Enqueue(roll);
                    }
                    else
                    {
                        courseQueue.Enqueue(course);
                        queueOfStudentsEachCourse[course - 1].Enqueue(roll);
                    }
                }
                else
                {
                    int course = courseQueue.Peek();
                    int roll = queueOfStudentsEachCourse[course - 1].Dequeue();
                    if(queueOfStudentsEachCourse[course - 1].Count == 0)
                    {
                        courseQueue.Dequeue();
                    }
                    Console.WriteLine($"{course} {roll}");
                }
            }

            Console.WriteLine("Press any key to continue . . . ");
            Console.ReadLine();
        }

        static void PlayingCards(Stack<int> A, int Q)
        {
            for (int i = 0; i < Q; i++)
            {
                Stack<int> A1 = new Stack<int>();
                Stack<int> B = new Stack<int>();
                while (A.Count > 0)
                {
                    if (A.Peek() % prime[i] == 0)
                    {
                        B.Push(A.Pop());
                    }
                    else
                    {
                        A1.Push(A.Pop());
                    }
                }
                PrintStack(B);
                A = A1;
            }
            PrintStack(A);
        }

        static void PrintStack(Stack<int> st)
        {
            while (st.Count > 0)
            {
                Console.WriteLine(st.Pop());
            }
        }

        static void GeneratePrime(int Q)
        {
            int primeIndex = 0;
            int candidatePrime = 2;
    
            while (primeIndex < Q)
            {
                if (IsPrime(candidatePrime))
                {
                    prime[primeIndex] = candidatePrime;
                    primeIndex++;
                }
                candidatePrime++;
            }
        }

        static bool IsPrime(int num)
        {
            for (int i = 2; i <= num / 2; i++)
            {
                if (num % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        static void NextGreaterElement(int[] arr)
        {
            Stack<int> indexStack = new Stack<int>();
            int[] nextGreater = new int[arr.Length];
            //pushing indexes to the stack
            indexStack.Push(0);
            for(int i=1; i<arr.Length; i++)
            {
                //poping element while stack top is smaller
                while (indexStack.Count > 0 && arr[indexStack.Peek()] < arr[i])
                {
                    nextGreater[indexStack.Pop()] = arr[i];
                }
                indexStack.Push(i);
            }

            while(indexStack.Count > 0)
            {
                nextGreater[indexStack.Pop()] = -1;
            }

            for(int i = 0; i<arr.Length; i++)
            {
                Console.WriteLine($"{arr[i]},{nextGreater[i]}");
            }
        }
    }
}
