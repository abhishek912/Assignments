using System;
using System.Collections.ObjectModel;

namespace DelegateLambda
{
    class ObservableCollectionClass
    {
        static void printSubjects(ObservableCollection<string> subjects)
        {
            Console.WriteLine();
            Console.WriteLine("List of Subjects is : ");
            foreach (string sub in subjects)
                Console.WriteLine(sub);
        }
        public void MainMethod()
        {
            ObservableCollection<string> subjects = new ObservableCollection<string>
            {
                "English",
                "ComputerScience",
                "Maths",
                "Science"
            };
            //Event Raiser
            subjects.CollectionChanged += Subjects_CollectionChanged;

            Console.WriteLine("Initially  :");
            printSubjects(subjects);
            Console.WriteLine();
            // Element Added
            Console.WriteLine("After Adding :");
            subjects.Add("Hindi");
            printSubjects(subjects);
            Console.WriteLine();

            // Element removed
            Console.WriteLine("After Removing :");
            subjects.Remove("Maths");
            printSubjects(subjects);
            Console.WriteLine("Exiting the Observable Class...");
            Console.Write("Press any key to continue...");

            Console.ReadLine();
        }
        enum NotifyCollectionChangedAction { Add, Remove };
        private static void Subjects_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            Console.WriteLine("List Updated !! ");
            if (e.Action.ToString().Equals(NotifyCollectionChangedAction.Add.ToString()))
                Console.WriteLine("Element Added in the collection !");


            else if (e.Action.ToString().Equals(NotifyCollectionChangedAction.Remove.ToString()))
                Console.WriteLine("Element Removed from the collection !");
        }
    }

}