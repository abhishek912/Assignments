using System;

namespace OOPsExercise2
{
    class MallardDuck : Duck
    {
        public MallardDuck() : base()
        {

        }

        public override void ShowDetails()
        {
            base.ShowDetails();
            Console.WriteLine($"Duck Type : {DuckType.Mallard}\n");
        }
    }
}
