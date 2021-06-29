using System;
using System.Collections.Generic;

namespace Events
{
    class ItemEventArgs : EventArgs
    {
        public double Price { set; get; }
        public int ID { set; get; }

        public Product p;
    }
    class Inventory
    {
        //Using EventHandler delegates...
        public event EventHandler<ItemEventArgs> RemovingItem;
        public event EventHandler PriceUpdated;

        //Defining delegate
        /*public delegate void DefectiveItemEventHandler(object source, ItemEventArgs i);
        public delegate void ItemPriceEventHandler(object source, EventArgs i);*/

        //Defining Events
        //public event DefectiveItemEventHandler RemovingItem;
        //public event ItemPriceEventHandler PriceUpdated;

        private Dictionary<Product, int> products;
        private double inventoryValue;

        public Inventory()
        {
            products = new Dictionary<Product, int>();
            inventoryValue = 0;
        }

        public void AddProduct(int id, double price, bool isDef, int quantity = 1)
        {
            Console.WriteLine($"Before Updation Value: {inventoryValue}");
            Product newProduct = new Product(id, price, isDef);
            products.Add(newProduct, quantity);
            inventoryValue += price * quantity;
            Console.WriteLine($"After Updation Value: {inventoryValue}");
            Console.WriteLine("Product Added To The Inventory!!!\n");
        }

        public void RemoveProduct(int id)
        {
            foreach (Product p in products.Keys)
            {
                if (p.ID == id)
                {
                    Console.WriteLine($"Before Updation Value: {inventoryValue}");
                    inventoryValue -= p.Price * products[p];
                    products.Remove(p);
                    Console.WriteLine($"After Updation Value: {inventoryValue}");
                    Console.WriteLine("Product Removed From Inventory!!!\n");
                    break;
                }
            }
        }

        public int GetProductCount()
        {
            return products.Count;
        }

        public void UpdateQuantity(int id, int quantity)
        {
            foreach (Product p in products.Keys)
            {
                if (p.ID == id)
                {
                    Console.WriteLine($"Before Updation Quantity: {products[p]}");
                    inventoryValue -= p.Price * products[p];
                    inventoryValue += p.Price * quantity;
                    products[p] = quantity;
                    Console.WriteLine($"After Updation Value: {products[p]}");
                    Console.WriteLine("Product Quantity Updated!!!\n");
                    break;
                }
            }
        }

        public void UpdateProductPrice(int id, double price)
        {
            foreach (Product p in products.Keys)
            {
                if (p.ID == id)
                {
                    Console.WriteLine($"Before Updation Value: {inventoryValue}");
                    inventoryValue -= p.Price * products[p];
                    inventoryValue += price * products[p];
                    p.Price = price;
                    Console.WriteLine($"After Updation Value: {inventoryValue}");
                    Console.WriteLine("Product Price Updated!!!\n");
                    //Raising an event...
                    OnPriceUpdated(EventArgs.Empty);
                    break;
                }
            }
        }

        public void UpdateDefective(int id, bool isdef)
        {
            if (isdef)
            {
                //Raising an event...
                OnItemDefective(id);
            }
        }

        protected virtual void OnPriceUpdated(EventArgs e)
        {
            PriceUpdated?.Invoke(this, e) ;
        }

        protected virtual void OnItemDefective(int id)
        {
            RemovingItem?.Invoke(this,  new ItemEventArgs() { ID = id});
        }
    }
}
