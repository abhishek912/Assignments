using System;
using System.Collections.Generic;

namespace OOPsExercise2
{
    public class SortByWings : IComparer<Duck>
    {
        public int Compare(Duck x, Duck y)
        {
            return x.GetWingsCount().CompareTo(y.GetWingsCount());
        }
    }
    class DuckGame
    {
        public List<Duck> ducks = new List<Duck>();

        public void ShowMenu()
        {
            Console.WriteLine("\n1. Create A Duck(Press 1): ");
            Console.WriteLine("2. Show Duck Details(Press 2): ");
            Console.WriteLine("3. Remove A Duck(Press 3): ");
            Console.WriteLine("4. Remove All Ducks(Press 4): ");          
            Console.WriteLine("5. List Ducks Details in Increasing Order of their Wings(Press 5): ");
            Console.WriteLine("6. List All Ducks(Press 6): ");
            Console.WriteLine("7. To Exit(Press 7): ");
            Console.Write("Please Enter your choice: ");
        }

        public void DuckPropertyMenu(ref int uid, ref string name, ref double weight, ref int wings, ref string fly, ref string quack)
        {
            Console.WriteLine("Please enter following details...");
            Console.Write("Enter Duck Unique ID: ");
            uid = int.Parse(Console.ReadLine());
            Console.Write("Enter Duck Name : ");
            name = Console.ReadLine();
            Console.Write("Enter Duck's weight : ");
            weight = double.Parse(Console.ReadLine());
            Console.Write("Enter the number of wings Duck have : ");
            wings = int.Parse(Console.ReadLine());
            Console.Write("Enter the Fly Type : ");
            fly = Console.ReadLine();
            Console.Write("Enter the quack property : ");
            quack = Console.ReadLine();
        }

        public void CreateRubberDuck()
        {
            string name="", fly="", quack="";
            double weight = 0.0; 
            int wings=0, uid=0;
            DuckPropertyMenu(ref uid, ref name, ref weight, ref wings, ref fly, ref quack);
            Duck d = new RubberDuck();
            d.SetDuckUID(uid);
            d.SetName(name);
            d.SetWeight(weight);
            d.SetWingsCount(wings);
            d.SetFlyProperty(fly);
            d.SetQuackProperty(quack);
            ducks.Add(d);
            Console.WriteLine("Success, Duck Created!!!");
        }

        public void CreateMallardDuck()
        {
            string name = "", fly = "", quack = "";
            double weight = 0.0;
            int wings = 0, uid=0;
            DuckPropertyMenu(ref uid, ref name, ref weight, ref wings, ref fly, ref quack);
            Duck d = new MallardDuck();
            d.SetDuckUID(uid);
            d.SetName(name);
            d.SetWeight(weight);
            d.SetWingsCount(wings);
            d.SetFlyProperty(fly);
            d.SetQuackProperty(quack);
            ducks.Add(d);
            Console.WriteLine("Success, Duck Created!!!");
        }

        public void CreateRedheadDuck()
        {
            string name = "", fly = "", quack = "";
            double weight = 0.0;
            int wings = 0, uid = 0;
            DuckPropertyMenu(ref uid, ref name, ref weight, ref wings, ref fly, ref quack);
            Duck d = new RedheadDuck();
            d.SetDuckUID(uid);
            d.SetName(name);
            d.SetWeight(weight);
            d.SetWingsCount(wings);
            d.SetFlyProperty(fly);
            d.SetQuackProperty(quack);
            ducks.Add(d);
            Console.WriteLine("Success, Duck Created!!!");
        }

        public void RemoveADuck()
        {
            Console.Write("To delete a Duck. Enter Duck Unique ID: ");
            int uid = int.Parse(Console.ReadLine());
            bool flag = false;
            foreach(Duck d in ducks)
            {
                if (d.GetDuckUID() == uid)
                {
                    ducks.Remove(d);
                    Console.WriteLine("Success, Duck Deleted!!!");
                    flag = true;
                    break;
                }
            }
            if (!flag)
            {
                Console.WriteLine($"No Duck Found with the Duck Unique ID: {uid}.");
            }
        }

        public void RemoveAllDucks()
        {
            ducks.Clear();
            Console.WriteLine("Success, All Ducks Deleted!!!");
        }

        public void ShowDetailsAccToWings()
        {
            List<Duck> temp = new List<Duck>();
            foreach(Duck d in ducks)
            {
                temp.Add(d);
            }
            SortByWings s = new SortByWings();
            temp.Sort(s);
            Console.WriteLine("**********List Of Ducks(in an increasing order of Wings**********)");
            Console.WriteLine("UID     Name     Wings(Sorted)");
            foreach (Duck d in temp)
            {
                Console.Write($"{d.GetDuckUID()}".PadRight(8));
                Console.Write($"{d.GetName()}".PadRight(10));
                Console.Write($"{d.GetWingsCount()}".PadRight(10));
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Duck Game!!!");
            DuckGame game = new DuckGame();
            string choice = "0";
            do
            {
                game.ShowMenu();
                choice = Console.ReadLine();
                if(choice == "1")
                {
                    Console.WriteLine("Enter the type of Duck you want to create!");
                    Console.WriteLine("1. Rubber Duck(Press 1): ");
                    Console.WriteLine("2. Mallard Duck(Press 2): ");
                    Console.WriteLine("3. Redhead Duck(Press 3): ");
                    Console.Write("Enter your choice: ");
                    int type = int.Parse(Console.ReadLine());

                    switch (type-1)
                    {
                        case (int)Duck.DuckType.Rubber: { game.CreateRubberDuck(); break; }
                        case (int)Duck.DuckType.Mallard: { game.CreateMallardDuck(); break; }
                        case (int)Duck.DuckType.RedHead: { game.CreateRedheadDuck(); break; }
                        default: { Console.WriteLine("Error: No Duck Type Found!!!"); break; }
                    }
                    game.ducks.Sort();

                }
                else if(choice == "2")
                {
                    Console.Write("Enter the Duck's Unique ID: ");
                    int uid = int.Parse(Console.ReadLine());
                    bool flag = false;
                    foreach (Duck duck in game.ducks)
                    {
                        if(duck.GetDuckUID() == uid)
                        {
                            duck.ShowDetails();
                            flag = true;
                            break;
                        }
                    }
                    if (!flag)
                    {
                        Console.WriteLine($"No Duck Dound with the Unique ID : {uid}.");
                    }
                }
                else if (choice == "3")
                {
                    game.RemoveADuck();   
                }
                else if (choice == "4")
                {
                    game.RemoveAllDucks();
                }
                else if (choice == "5")
                {
                    game.ShowDetailsAccToWings();
                }
                else if(choice == "6")
                {
                    Console.WriteLine("**********List Of Ducks(in an increasing order of Weights**********)");
                    Console.WriteLine("UID     Name     Weight(Sorted)");
                    foreach (Duck d in game.ducks)
                    {
                        Console.Write($"{d.GetDuckUID()}".PadRight(8));
                        Console.Write($"{d.GetName()}".PadRight(10));
                        Console.Write($"{d.GetWeight()}".PadRight(10));
                        Console.WriteLine();
                    }
                    Console.WriteLine();
                }
                else if(choice == "7")
                {
                    Console.WriteLine("***Exiting the Application***");
                    break;
                }
                else
                {
                    Console.WriteLine("Error: Wrong input!!!");
                }

            } while (choice != "7");
            Console.WriteLine("Press Any Key To Continue...");
            Console.ReadKey();
        }
    }
}
