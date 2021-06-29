using System;

namespace OOPsExercise1
{
    class Mobile : Equipment
    {
        private int numOfWheels;

        public Mobile() : base()
        {

        }

        public Mobile(int wheelsCount, int uid, string name, string description) : base(uid, name, description)
        {
            type = (int)Equipment.EquipmentType.Mobile;
            numOfWheels = wheelsCount;
        }

        public void SetWheels(int wheelCount)
        {
            numOfWheels = wheelCount;
        }

        public int GetWheels()
        {
            return numOfWheels;
        }

        public override void IncreaseMaintenanceCost(double distance)
        {
            maintenanceCost += numOfWheels * distance;
        }

        public override void DisplayEquipmentDetails()
        {
            base.DisplayEquipmentDetails();
            Console.WriteLine($"Number Of Wheels : {GetWheels()}");
            Console.WriteLine($"Equipment Type : {EquipmentType.Mobile}\n");
        }
    }
}
