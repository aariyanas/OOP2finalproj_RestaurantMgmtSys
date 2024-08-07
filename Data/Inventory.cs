using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace RestaurantManagement.Data
{
    // This class represents an inventory item in the restaurant management system.
    public class Inventory
    {
        // Fields to store the name, quantity, price, and category of the inventory item.
        string name;
        int quantity;
        double price;
        string category;
        int quantityToOrder;

        // Default constructor.
        public Inventory()
        {
            
        }

        // Properties to get and set the name, quantity, price, and category of the inventory item.
        public string Name { get => name; set => name = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public double Price { get => price; set => price = value; }
        public string Category { get => category; set => category = value; }
        public int QuantityToOrder { get => quantityToOrder; set => quantityToOrder = value; }


        // Parameterized constructor to initialize an inventory item with specified values.
        public Inventory(string name, int quantity, double price, string category)
        {
            this.name = name;
            this.quantity = quantity;
            this.price = price;
            this.category = category;
        }
    }
}