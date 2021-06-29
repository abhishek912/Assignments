using System;

namespace Events
{
    class Program
    {
        static Inventory items = new Inventory();
        static void Main(string[] args)
        {
            Program p = new Program();
            //Register for an event...
            items.RemovingItem += ItemRemoved;
            items.PriceUpdated += PriceUpdated;
            items.AddProduct(1, 1400, false, 10);
            items.AddProduct(2, 1000, false, 5);
            items.AddProduct(3, 500, false, 50);
            items.AddProduct(4, 10000, false, 6);
            items.AddProduct(5, 50000, false, 4);

            items.UpdateDefective(1, true);
            items.RemoveProduct(3);
            items.UpdateQuantity(2, 100);
            items.UpdateProductPrice(5, 20000);
            items.RemoveProduct(5);

            Console.WriteLine("Press Any Key to Continue...");
            Console.ReadKey();
        }

        //Handling an event with particular method...
        static void PriceUpdated(object sender, EventArgs e)
        {
            Console.WriteLine("\nEvent Handler: Price Updated.\n");
        }

        static void ItemRemoved(object sender, ItemEventArgs e)
        {
            Console.WriteLine($"Before product count is: {items.GetProductCount()}");
            items.RemoveProduct(e.ID);
            Console.WriteLine("\nEvent Handler: Item Removed...\n");
            Console.WriteLine($"After Removing product count is: {items.GetProductCount()}");
        }
    }
}
