using System;

namespace OOPsExercise2
{
    public abstract class Duck : IDuck, IComparable<Duck>
    {
        private int duckUID;
        private string name;
        private double weight;
        private int numOfWings;
        private string flyProperty;
        private string quackProperty;
        public enum DuckType { Rubber, Mallard, RedHead };

        public Duck()
        {
            name = "";
            weight = 0.0;
            numOfWings = 0;
            flyProperty = "N/A";
            quackProperty = "N/A";
        }

        public void SetDuckUID(int uid)
        {
            duckUID = uid;
        }

        public void SetFlyProperty(string flyType)
        {
            flyProperty = flyType;
        }

        public void SetQuackProperty(string quackType)
        {
            quackProperty = quackType;
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        public void SetWeight(double weight)
        {
            this.weight = weight;
        }

        public void SetWingsCount(int num)
        {
            numOfWings = num;
        }

        public int GetDuckUID()
        {
            return duckUID;
        }

        public string GetFlyProperty()
        {
            return flyProperty;
        }

        public string GetQuackProperty()
        {
            return quackProperty;
        }

        public string GetName()
        {
            return name;
        }

        public double GetWeight()
        {
            return weight;
        }

        public int GetWingsCount()
        {
            return numOfWings;
        }

        public virtual void ShowDetails()
        {
            Console.WriteLine($"Unique ID : {duckUID}");
            Console.WriteLine($"Name : {name}");
            Console.WriteLine($"Weight(in kg) : {weight}kg");
            Console.WriteLine($"Number Of Wings : {numOfWings}");
            Console.WriteLine($"Fly Type : {flyProperty}");
            Console.WriteLine($"Quack Type : {quackProperty}");
        }

        public int CompareTo(Duck other)
        {
            return this.GetWeight().CompareTo(other.GetWeight());
        }
    }
}
