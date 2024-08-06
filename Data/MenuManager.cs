using Microsoft.Identity.Client;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.Data
{
    public class MenuManager
    {
        public static List<Menu> menuItems;
        public static string AddMenu(string name, double price, string category)
        {
            MenuDBhandler db = new MenuDBhandler();
            db.InsertMenuDB(name, price, category);
            return "Menu item added successfully";
        }

        public static List<Menu> RetrieveMenu()
        {
           MenuDBhandler db = new MenuDBhandler();
            menuItems = db.LoadMenuFromDB();
            return menuItems;
        }

        public static string EditMenu(string name, double price, string category)
        {
            string message = MenuDBhandler.UpdateMenuToDB(name, price, category);
            RetrieveMenu();
            return message;
        }

        public static string DeleteMenu(string name)
        {
            MenuDBhandler db = new MenuDBhandler();
            string message = db.DeleteMenuDB(name);
            RetrieveMenu();
            return message;
        }
    }
}
