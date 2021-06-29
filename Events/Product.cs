using System;

namespace Events
{
    class Product : IEquatable<Product>
    {
        private int productID;
        private double productPrice;
        private bool isDefective;

        public Product(int id, double price, bool isDef)
        {
            productID = id;
            productPrice = price;
            isDefective = isDef;
        }

        public int ID
        {
            get { return productID; }
            set { productID = ID; }
        }

        public double Price
        {
            get { return productPrice; }
            set { productPrice = Price; }
        }

        public bool IsDefective
        {
            get { return isDefective; }
            set { isDefective = IsDefective; }
        }
        
        public bool Equals(Product other)
        {
            return productID.Equals(other.productID);
        }
    }
}
