using System;

namespace OOPsExercise2
{
    class RedheadDuck : Duck
    {
        public RedheadDuck() : base()
        {

        }

        public override void ShowDetails()
        {
            base.ShowDetails();
            Console.WriteLine($"Duck Type : {DuckType.RedHead}\n");
        }
    }
}
