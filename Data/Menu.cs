using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace RestaurantManagement.Data
{
    // This class represents a menu item in the restaurant management system.
    public class Menu
    {
        // Fields to store the name, price, and category of the menu item.
        private string name;
        private double price;
        private string category;

        // Default constructor.
        public Menu()
        {
            
        }

        // Accessors and modifiers
        // Properties to get and set the name, price, and category of the menu item.
        public string Name { get => name; set => name = value; }
        public double Price { get => price; set => price = value; }
        public string Category { get => category; set => category = value; }

        // Parameterized constructor to initialize a menu item with specified values.
        public Menu(string name, double price, string category)
        {
            Name = name;
            Price = price;
            Category = category;
        }
    }
}
