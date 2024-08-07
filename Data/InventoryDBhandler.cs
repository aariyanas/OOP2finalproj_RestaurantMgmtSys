using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.SQLite;

namespace RestaurantManagement.Data
{
    // This class handles database operations related to the Inventory in the restaurant management system.
    public class InventoryDBhandler
    {
        // List to store Inventory objects.
        static List<Inventory> inventoryList = new List<Inventory>();

        // Database path and connection string.
        static string baseInventoryDirectory = AppDomain.CurrentDomain.BaseDirectory;
        static string dbInventoryPath = Path.Combine(baseInventoryDirectory, "inventory.db");
        static string connect_inventory_string = $"Data Source={dbInventoryPath}";

        // Constructor that loads inventory items from the database.
        public InventoryDBhandler()
        {
            LoadInventoryFromDB();
        }

        // Method to check if the 'inventory' table exists in the database.
        protected bool IsTableExist()
        {
            using (SQLiteConnection connection = new SQLiteConnection(connect_inventory_string))
            {
                connection.Open();
                string sql = $"Select name from sqlite_master where  type='table' and name='inventory';";
                using (SQLiteCommand cmd = new SQLiteCommand(sql, connection))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        return reader.Read();
                    }
                }
            }
        }

        // Method to create the 'inventory' table if it does not exist.
        private void CreateTableDB()
        {
            if (!IsTableExist())
            {
                SQLiteConnection connection = new SQLiteConnection(connect_inventory_string);
                connection.Open();
                string sql = "Create table inventory(Name TEXT(30), Quantity INTEGER, Price REAL, Category TEXT(30), QuantityToOrder INTEGER)";
                using (SQLiteCommand cmd = new SQLiteCommand(sql, connection))
                {
                    cmd.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        // Method to load inventory items from the database.
        public List<Inventory> LoadInventoryFromDB()
        {
            inventoryList.Clear();
            SQLiteConnection connection = new SQLiteConnection(connect_inventory_string);
            connection.Open();
            string sql = "SELECT * from inventory";
            SQLiteCommand cmd = new SQLiteCommand(sql, connection);
            using (cmd)
            {
                using(SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string name = reader.GetString(0);
                        int quantity = reader.GetInt32(1);
                        double price = reader.GetDouble(2);
                        string category = reader.GetString(3);
                        Inventory inventory = new Inventory(name, quantity, price, category);
                        inventoryList.Add(inventory);
                    }
                }
            }
            connection.Close();
            return inventoryList;
        }

        // Method to insert an inventory item into the database.
        public void InsertInventoryDB(string name, int quantity, double price, string category)
        {
            SQLiteConnection connection = new SQLiteConnection(connect_inventory_string);
            connection.Open();
            string sql = "Insert into inventory values (@name, @quantity, @price, @category)";
            SQLiteCommand cmd = new SQLiteCommand(sql, connection);
            using (cmd)
            {
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@quantity", quantity);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@category", category);
                cmd.ExecuteNonQuery();
            }

            connection.Close();
        }

        // Method to update an existing inventory item in the database.
        public static string UpdateInventoryToDB(string name, int quantity, double price, string category)
        {
            try
            {
                SQLiteConnection connection = new SQLiteConnection(connect_inventory_string);
                connection.Open();
                string sql = "Update inventory set Quantity = @quantity, Price = @price, Category = @category, where Name = @name";
                SQLiteCommand cmd = new SQLiteCommand(sql, connection);
                using (cmd)
                {
                    cmd.Parameters.AddWithValue("@quantity", quantity);
                    cmd.Parameters.AddWithValue("@price", price);
                    cmd.Parameters.AddWithValue("@category", category);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
                
                return "Inventory item updated successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        // Method to delete an inventory item from the database.
        public string DeleteInventoryDB(string name)
        {
            try
            {
                SQLiteConnection connection = new SQLiteConnection(connect_inventory_string);
                connection.Open();
                string sql = "Delete from inventory where Name = @name";
                SQLiteCommand cmd = new SQLiteCommand(sql, connection);
                using (cmd)
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.ExecuteNonQuery();
                }
                connection.Close();
                return "Inventory item deleted successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        // Method to update the quantity of an inventory item in the database.
        public void UpdateQuantityInDB(string name, int newQuantity)
        {
            try
            {
                using (var connection = new SQLiteConnection(connect_inventory_string))
                {
                    connection.Open();
                    string sql = "UPDATE inventory SET Quantity = @quantity WHERE Name = @name";
                    using (var cmd = new SQLiteCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue("@quantity", newQuantity);
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle or log the exception as needed
                throw;
            }
        }


    }
}
