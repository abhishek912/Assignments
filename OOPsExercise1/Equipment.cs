using System;

namespace OOPsExercise1
{
    abstract class Equipment
    {
        public int equipmentUniqueID;
        private string equipmentName;
        private string equipmentDescription;
        private double distanceMoved;
        protected double maintenanceCost;
        public int type;
        public enum EquipmentType { Mobile, Immobile };

        public Equipment()
        {
        }

        public Equipment(int uid, string name, string description)
        {
            equipmentUniqueID = uid;
            equipmentName = name;
            equipmentDescription = description;
            distanceMoved = 0.0;
            maintenanceCost = 0.0;
        }

        public void SetName(string name)
        {
            equipmentName = name;
        }

        public string GetName()
        {
            return equipmentName;
        }    

        public void SetDescription(string description)
        {
            equipmentDescription = description;
        }

        public string GetDescription()
        {
            return equipmentDescription;
        }

        public double GetDistanceMoved()
        {
            return distanceMoved;
        }

        public double GetMaintenanceCost()
        {
            return maintenanceCost;
        }

        public void MoveEquipmentBy(double distance)
        {
            IncreaseDiatanceMoved(distance);
            IncreaseMaintenanceCost(distance);
        }

        private void IncreaseDiatanceMoved(double distance)
        {
            distanceMoved += distance;
        }

        public abstract void IncreaseMaintenanceCost(double distance);

        public virtual void DisplayEquipmentDetails()
        {
            Console.WriteLine($"**********Details Of Equipment with Unique ID: {equipmentUniqueID}**********");
            Console.WriteLine($"Equipment Name : {equipmentName}");
            Console.WriteLine($"Equipment Description : {equipmentDescription}");
            Console.WriteLine($"Distance moved Till Now(in km) : {distanceMoved}km");
            Console.WriteLine($"Maintainance Cost(in Rs.) : Rs.{maintenanceCost}/-");
        }

        public void DisplayEquipmentBasicDetails()
        {
            Console.Write($"{equipmentUniqueID}".PadRight(6));
            Console.Write($"{equipmentName}".PadRight(15));
            Console.Write($"{equipmentDescription}".PadLeft(8));
            Console.WriteLine();
        }
    }
}
