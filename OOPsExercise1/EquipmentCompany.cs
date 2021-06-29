using System;
using System.Collections.Generic;
using System.Linq;

namespace OOPsExercise1
{
    class EquipmentCompany
    {
        public List<Equipment> equipments = new List<Equipment>();

        public void ShowMenu()
        {
            Console.WriteLine("**********MENU**********");
            Console.WriteLine("\n1. Create Mobile Equipment(Press 1): ");
            Console.WriteLine("2. Create Immobile Equipment(Press 2): ");
            Console.WriteLine("3. Show Equipment Details(Press 3): ");
            Console.WriteLine("4. Move Equipment(Press 4): ");
            Console.WriteLine("5. Delete an Equipment(Press 5): ");
            Console.WriteLine("6. List All Equipment(Press 6): ");
            Console.WriteLine("7. List All Mobile Equipment(Press 7): ");
            Console.WriteLine("8. List All Immobile Equipment(Press 8): ");
            Console.WriteLine("9. List Equipment having Distance Moved is 0(Press 9): ");
            Console.WriteLine("10. Delete All Equipment(Enter 10): ");
            Console.WriteLine("11. Delete All Immobile Equipment(Enter 11): ");
            Console.WriteLine("12. Delete All Mobile Equipment(Enter 12): ");
            Console.WriteLine("13. To Exit(Enter 13): ");
            Console.Write("Please Enter your choice: ");
        }

        public void CreateMobileEquipment()
        {
            Console.Write("Enter Unique ID of the Equipment: ");
            int uid = int.Parse(Console.ReadLine());
            Console.Write("Enter Name of the Equipment: ");
            string name = Console.ReadLine();
            Console.Write("Enter Description of the Equipment: ");
            string description = Console.ReadLine();
            Console.Write("Enter Number of Wheels: ");
            int wheels = int.Parse(Console.ReadLine());

            Equipment e = new Mobile(wheels, uid, name, description);
            equipments.Add(e);
            Console.WriteLine("Success, Equipment Added!!!");
        }

        public void CreateImmobileEquipment()
        {
            Console.Write("Enter Unique ID of the Equipment: ");
            int uid = int.Parse(Console.ReadLine());
            Console.Write("Enter Name of the Equipment: ");
            string name = Console.ReadLine();
            Console.Write("Enter Description of the Equipment: ");
            string description = Console.ReadLine();
            Console.Write("Enter The Weight Of an Equipment: ");
            double weight = double.Parse(Console.ReadLine());

            Equipment e = new Immobile(weight, uid, name, description);
            equipments.Add(e);
            Console.WriteLine("Success, Equipment Added!!!");
        }

        public void MoveEquipment()
        {
            Console.WriteLine("To Move an Equipment...");
            Console.Write("Please Enter Equipment Unique ID: ");
            int uid = int.Parse(Console.ReadLine());
            Console.Write("Enter the Distance travelled : ");
            double distance = double.Parse(Console.ReadLine());
            bool flag = false;
            foreach (Equipment e in equipments)
            {
                if (e.equipmentUniqueID == uid)
                {
                    e.MoveEquipmentBy(distance);
                    flag = true;
                    break;
                }
            }
            if (!flag)
            {
                Console.WriteLine($"Error : No Equipment found with Unique Id: {uid}");
            }
        }

        public void ShowDetails()
        {
            Console.WriteLine("Enter the Equipment Unique ID: ");
            int uid = int.Parse(Console.ReadLine());
            bool flag = false;
            foreach (Equipment e in equipments)
            {
                if(e.equipmentUniqueID == uid)
                {
                    e.DisplayEquipmentDetails();
                    flag = true;
                    break;
                }
            }
            if (!flag)
            {
                Console.WriteLine($"No record found for Unique ID: {uid}");
            }
        }

        public void DeleteEquipment()
        {
            Console.WriteLine("To Delete an Equipment please enter Equipment Unique ID: ");
            int uid = int.Parse(Console.ReadLine());
            bool flag = false;
            foreach (Equipment e in equipments)
            {
                if (e.equipmentUniqueID == uid)
                {
                    equipments.Remove(e);
                    Console.WriteLine("Success, Equipment deleted!!!");
                    flag = true;
                    break;
                }
            }
            if (!flag)
            {
                Console.WriteLine($"No record found for Unique ID: {uid}");
            }
        }

        public void ListAllEquipment()
        {
            Console.WriteLine("**********List of All Equipments**********");
            Console.WriteLine("UID     Name        Description");
            foreach (Equipment e in equipments)
            {
                e.DisplayEquipmentBasicDetails();
            }
            Console.WriteLine();
        }

        public void ListAllMobileEquipment()
        {
            List<Equipment> mobileEquipments = equipments.FindAll(x => x.type == 0);
            Console.WriteLine("**********List of All Mobile Equipments**********");
            Console.WriteLine("UID     Name        Description");
            foreach (Equipment e in mobileEquipments)
            {
                e.DisplayEquipmentBasicDetails();
            }
            Console.WriteLine();
        }

        public void ListAllImmobileEquipment()
        {
            List<Equipment> immobileEquipments = equipments.FindAll(x => x.type == 1);
            Console.WriteLine("**********List of All Immobile Equipments**********");
            Console.WriteLine("UID     Name        Description");
            foreach (Equipment e in immobileEquipments)
            {
                e.DisplayEquipmentBasicDetails();
            }
            Console.WriteLine();
        }

        public void ListEquipmentZeroDistance()
        {
            List<Equipment> equipmentZeroDistance = equipments.FindAll(x => x.GetDistanceMoved() == 0.0);
            Console.WriteLine("**********List of All Equipments with zero Distance travelled**********");
            Console.WriteLine("UID     Name        Description");
            foreach (Equipment e in equipmentZeroDistance)
            {
                e.DisplayEquipmentBasicDetails();
            }
            Console.WriteLine();
        }

        public void DeleteAllImmobileEquipments()
        {
            List<Equipment> immobile = equipments.FindAll(x => x.type == 1);
            //IEnumerable<Equipment> immobile = from e in equipments
            //                           where e.type == 1
            //                           select e;

            foreach (Equipment e in immobile)
            {
                equipments.Remove(e);
            }
            Console.WriteLine("Success, All Immobile Equipments Deleted!!!");
        }

        public void DeleteAllMobileEquipments()
        {
            List<Equipment> mobile = equipments.FindAll(x => x.type == 0);
            foreach (Equipment e in mobile)
            {
                equipments.Remove(e);
            }
            Console.WriteLine("Success, All Mobile Equipments Deleted!!!");
        }

        static void Main1(string[] args)
        {
            EquipmentCompany company = new EquipmentCompany();
            Console.WriteLine("***Welcome To Equipment Management System***");        
            string choice = "0";
            do
            {
                company.ShowMenu();
                choice = Console.ReadLine();
                if (Int32.TryParse(choice, out int value))
                {
                    switch (value - 1)
                    {
                        case (int)Equipment.EquipmentType.Mobile:
                            {
                                company.CreateMobileEquipment();
                                break;
                            }

                        case (int)Equipment.EquipmentType.Immobile:
                            {
                                company.CreateImmobileEquipment();
                                break;
                            }

                        case 2:
                            {
                                company.ShowDetails();                                
                                break;
                            }

                        case 3:
                            {
                                company.MoveEquipment();
                                break;
                            }

                        case 4:
                            {
                                company.DeleteEquipment();
                                break;
                            }

                        case 5:
                            {
                                company.ListAllEquipment();
                                break;
                            }

                        case 6:
                            {
                                company.ListAllMobileEquipment();
                                break;
                            }

                        case 7:
                            {
                                company.ListAllImmobileEquipment();
                                break;
                            }

                        case 8:
                            {
                                company.ListEquipmentZeroDistance();
                                break;
                            }


                        case 9:
                            {
                                company.equipments.Clear();
                                Console.WriteLine("Success, All Equipments Deleted!!!");
                                break;
                            }

                        case 10:
                            {
                                company.DeleteAllImmobileEquipments();
                                break;
                            }

                        case 11:
                            {
                                company.DeleteAllMobileEquipments();
                                break;
                            }

                        case 12:
                            {
                                Console.WriteLine("***Exiting the Application***");
                                break;
                            }
                        default: Console.WriteLine("Error : Invalid Option!!!"); break;
                    }
                }
                else
                {
                    Console.WriteLine("Error : Wrong Input!!!");
                }
            } while (choice != "13");

            Console.WriteLine("Press Any Key To Continue...");
            Console.ReadKey();
        }
    }
}
