using System;
using System.Threading;

namespace ExceptionHandling
{
    class Game
    {
        /*public static void CheckOdd()
        {
            Mathematics m = new Mathematics();
            Console.Write("Enter Even Number: ");
            string input = Console.ReadLine();
            if (m.ValidateNum(input))
            {
                if (m.IsEven(int.Parse(input)))
                {
                    Console.WriteLine($"Success, {int.Parse(input)} is Even!!!");
                }
            }
        }*/

        static void Main(string[] args)
        {
            Mathematics m = new Mathematics();
            int gameCount = 0;
            do
            {
                Console.Write("Enter Any Number From(1-5): ");
                string input = Console.ReadLine();
                if (m.Validate(input))
                {
                    int value = int.Parse(input);
                    switch (value)
                    {
                        case 1:
                            {
                                /*ThreadStart childref = new ThreadStart(CheckOdd);
                                Thread childThread = new Thread(childref);
                                childThread.Start();
                                childThread.Join();*/
                                Console.Write("Enter Even Number: ");
                                input = Console.ReadLine();
                                if (m.ValidateNum(input))
                                {
                                    if (m.IsEven(int.Parse(input)))
                                    {
                                        Console.WriteLine($"Success, {int.Parse(input)} is Even!!!");
                                    }
                                }
                                break;
                            }

                        case 2:
                            {
                                Console.Write("Enter Odd Number: ");
                                input = Console.ReadLine();
                                if (m.ValidateNum(input))
                                {
                                    if (m.IsOdd(int.Parse(input)))
                                    {
                                        Console.WriteLine($"Success, {int.Parse(input)} is Odd!!!");
                                    }
                                }
                                break;
                            }

                        case 3:
                            {
                                Console.Write("Enter Prime Number: ");
                                input = Console.ReadLine();
                                if (m.ValidateNum(input))
                                {
                                    if (m.IsPrime(int.Parse(input)))
                                    {
                                        Console.WriteLine($"Success, {int.Parse(input)} is Prime!!!");
                                    }
                                }
                                break;
                            }

                        case 4:
                            {
                                Console.Write("Enter Negative Number: ");
                                input = Console.ReadLine();
                                if (m.ValidateNum(input))
                                {
                                    if (m.IsNegative(int.Parse(input)))
                                    {
                                        Console.WriteLine($"Success, {int.Parse(input)} is Negative!!!");
                                    }
                                }
                                break;
                            }

                        case 5:
                            {
                                Console.Write("Enter Zero: ");
                                input = Console.ReadLine();
                                if (m.ValidateNum(input))
                                {
                                    if (m.InZero(int.Parse(input)))
                                    {
                                        Console.WriteLine($"Success, {int.Parse(input)} is Zero!!!");
                                    }
                                }
                                break;
                            }
                    }
                    gameCount++;
                    if(m.IsLimitReached(gameCount))
                    {
                        Console.Write("Do you want to exit the game?(press 0): ");
                        if(Console.ReadLine() == "0")
                        {
                            break;
                        }
                    }
                }
            } while (true);
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
