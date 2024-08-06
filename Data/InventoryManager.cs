using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.Data
{
    public class InventoryManager
    {
        public static List<Inventory> inventoryItems;

        public static string AddInventory(string name, int quantity, double price, string category)
        {
            InventoryDBhandler db = new InventoryDBhandler();
            db.InsertInventoryDB(name, quantity, price, category);
            return "Inventory item added successfully";
        }

        public static List<Inventory> RetrieveInventory()
        {
            InventoryDBhandler db = new InventoryDBhandler();
            inventoryItems = db.LoadInventoryFromDB();
            return inventoryItems;
        }

        public static string EditInventory(string name, int quantity, double price, string category)
        {
            string message = InventoryDBhandler.UpdateInventoryToDB(name, quantity, price, category);
            RetrieveInventory();
            return message;
        }

        public static string DeleteInventory(string name)
        {
            InventoryDBhandler db = new InventoryDBhandler();
            string message = db.DeleteInventoryDB(name);
            RetrieveInventory();
            return message;
        }
    }
}
