using System;

namespace OOPsExercise1
{
    class Immobile : Equipment
    {
        private double weight;

        public Immobile() : base()
        {
        }

        public Immobile(double weight, int uid, string name, string description) : base(uid, name, description)
        {
            type = (int)Equipment.EquipmentType.Immobile;
            this.weight = weight;
        }

        public void SetWeight(double weight)
        {
            this.weight = weight;
        }

        public double GetWeight()
        {
            return weight;
        }

        public override void IncreaseMaintenanceCost(double distance)
        {
            maintenanceCost += weight * distance;
        }

        public override void DisplayEquipmentDetails()
        {
            base.DisplayEquipmentDetails();
            Console.WriteLine($"Weight(in kg) : {weight}kg");
            Console.WriteLine($"Equipment Type : {EquipmentType.Immobile}\n");
        }
    }
}
