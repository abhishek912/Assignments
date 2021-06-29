using System;

namespace OOPsExercise2
{
    class RubberDuck : Duck
    {
        public RubberDuck() : base()
        {

        }

        public override void ShowDetails()
        {
            base.ShowDetails();
            Console.WriteLine($"Duck Type : {DuckType.Rubber}\n");
        }
    }
}
