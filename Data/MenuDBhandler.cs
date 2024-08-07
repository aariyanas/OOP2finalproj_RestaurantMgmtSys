using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.SQLite;

namespace RestaurantManagement.Data
{
    // This class handles database operations related to the Menu in the restaurant management system.
    public class MenuDBhandler
    {
        // List to store Menu objects.
        static List<Menu> menuList = new List<Menu>();

        // Database path and connection string.
        static string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        static string dbPath = Path.Combine(baseDirectory, "menu.db");
        static string connect_string = $"Data Source={dbPath}";

        // Constructor that loads menu items from the database.
        public MenuDBhandler()
        {
            LoadMenuFromDB();
        }

        // Method to check if the 'menu' table exists in the database.
        protected bool IsTableExist()
        {
            using (SQLiteConnection connection = new SQLiteConnection(connect_string))
            {
                connection.Open();
                string sql = $"Select name from sqlite_master where  type='table' and name='menu';";
                using (SQLiteCommand cmd = new SQLiteCommand(sql, connection))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        return reader.Read();
                    }
                }
            }
        }

        // Method to create the 'menu' table if it does not exist.
        private void CreateTableDB()
        {
            if (!IsTableExist())
            {
                SQLiteConnection connection = new SQLiteConnection(connect_string);
                connection.Open();
                string sql = "Create table menu(Name TEXT(30), Price REAL, Category TEXT(30))";
                using (SQLiteCommand cmd = new SQLiteCommand(sql, connection))
                {
                    cmd.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        // Method to load menu items from the database into the menuList.
        public List<Menu> LoadMenuFromDB()
        {
            menuList.Clear();
            SQLiteConnection connection = new SQLiteConnection(connect_string);
            connection.Open();
            string sql = "SELECT * from menu";
            SQLiteCommand cmd = new SQLiteCommand(sql, connection);
            using (cmd)
            {
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string name = reader.GetString(0);
                        double price = reader.GetDouble(1);
                        string category = reader.GetString(2);
                        Menu menu = new Menu(name, price, category);
                        menuList.Add(menu);
                    }
                }
            }
            connection.Close();
            return menuList;

        }

        // Method to insert a new menu item into the database.
        public void InsertMenuDB(string name, double price, string category)
        {
            SQLiteConnection connection = new SQLiteConnection(connect_string);
            connection.Open();
            string sql = "Insert into menu values (@name, @price, @category)";
            SQLiteCommand cmd = new SQLiteCommand(sql, connection);
            using (cmd)
            {
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@category", category);
                cmd.ExecuteNonQuery();
            }
            connection.Close();
        }

        // Method to update an existing menu item in the database.
        public static string UpdateMenuToDB(string name, double price, string category)
        {
            try
            {
                SQLiteConnection connection = new SQLiteConnection(connect_string);
                connection.Open();
                string sql = "Update menu set Price = @price, Category = @category where Name = @name";
                SQLiteCommand cmd = new SQLiteCommand(sql, connection);
                using (cmd)
                {
                    cmd.Parameters.AddWithValue("@price", price);
                    cmd.Parameters.AddWithValue("@category", category);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
                return "Updated Successfully";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        // Method to delete a menu item from the database.
        public string DeleteMenuDB(string name)
        {
            try
            {
                SQLiteConnection connection = new SQLiteConnection(connect_string);
                connection.Open();
                string sql = "Delete from menu where Name = @name";
                SQLiteCommand cmd = new SQLiteCommand(sql, connection);
                using (cmd)
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.ExecuteNonQuery();
                }
                connection.Close();
                return "Deleted Successfully";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
