using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace RestaurantManagement.Data
{
    public class Menu
    {
        string name;
        double price;
        string category;

        public Menu()
        {
            
        }

        public string Name { get => name; set => name = value; }
        public double Price { get => price; set => price = value; }
        public string Category { get => category; set => category = value; }

        public Menu(string name, double price, string category)
        {
            this.name = name;
            this.price = price;
            this.category = category;
        }
    }
}
