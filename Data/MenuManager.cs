using Microsoft.Identity.Client;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.Data
{
    // This class manages menu-related operations, providing a higher-level interface for adding, retrieving, editing, and deleting menu items.
    public class MenuManager
    {
        // List to store the menu items.
        public static List<Menu> menuItems;

        // Method to add a new menu item.
        public static string AddMenu(string name, double price, string category)
        {
            MenuDBhandler db = new MenuDBhandler();
            db.InsertMenuDB(name, price, category);
            return "Menu item added successfully";
        }

        // Method to retrieve all menu items from the database.
        public static List<Menu> RetrieveMenu()
        {
           MenuDBhandler db = new MenuDBhandler();
            menuItems = db.LoadMenuFromDB();
            return menuItems;
        }

        // Method to edit an existing menu item.
        public static string EditMenu(string name, double price, string category)
        {
            string message = MenuDBhandler.UpdateMenuToDB(name, price, category);
            RetrieveMenu();
            return message;
        }

        // Method to delete a menu item.
        public static string DeleteMenu(string name)
        {
            MenuDBhandler db = new MenuDBhandler();
            string message = db.DeleteMenuDB(name);
            RetrieveMenu();
            return message;
        }
    }
}
