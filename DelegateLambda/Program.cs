using System;

namespace DelegateLambda
{
    class Program
    {
        static void Main(string[] args)
        {
            DelegateClass d = new DelegateClass();
            d.MainMethod();
            Console.WriteLine("******************************************************************");
            ObservableCollectionClass o = new ObservableCollectionClass();
            o.MainMethod();

            Console.Write("Terminating the program. Press any key to continue...");
            Console.ReadKey();
        }
    }
}
