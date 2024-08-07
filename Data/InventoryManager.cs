using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.Data
{
    // This class represents an inventory item in the restaurant management system.
    public class InventoryManager
    {
        // List to store the inventory items.
        public static List<Inventory> inventoryItems;
        
        // Method to add a new inventory item.
        public static string AddInventory(string name, int quantity, double price, string category)
        {
            InventoryDBhandler db = new InventoryDBhandler();
            db.InsertInventoryDB(name, quantity, price, category);
            return "Inventory item added successfully";
        }

        // Method to retrieve all inventory items from the database.
        public static List<Inventory> RetrieveInventory()
        {
            InventoryDBhandler db = new InventoryDBhandler();
            inventoryItems = db.LoadInventoryFromDB();
            return inventoryItems;
        }

        // Method to edit an existing inventory item.
        public static string EditInventory(string name, int quantity, double price, string category)
        {
            string message = InventoryDBhandler.UpdateInventoryToDB(name, quantity, price, category);
            RetrieveInventory();
            return message;
        }

        // Method to delete an inventory item.
        public static string DeleteInventory(string name)
        {
            InventoryDBhandler db = new InventoryDBhandler();
            string message = db.DeleteInventoryDB(name);
            RetrieveInventory();
            return message;
        }
    }
}
