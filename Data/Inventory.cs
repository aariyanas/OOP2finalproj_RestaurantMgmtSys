using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace RestaurantManagement.Data
{
    public class Inventory
    {
        string name;
        int quantity;
        double price;
        string category;
        int quantityToOrder;

        public Inventory()
        {
            
        }

        public string Name { get => name; set => name = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public double Price { get => price; set => price = value; }
        public string Category { get => category; set => category = value; }
        public int QuantityToOrder { get => quantityToOrder; set => quantityToOrder = value; }



        public Inventory(string name, int quantity, double price, string category)
        {
            this.name = name;
            this.quantity = quantity;
            this.price = price;
            this.category = category;
        }
    }
}