using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.SQLite;


namespace RestaurantManagement.Data
{
    // This class handles database operations related to the Employees in the restaurant management system.
    public class EmployeeDBhandler
    {
        // List to store Employee objects.
        static List<Employees> employeeList = new List<Employees>();

        // Database path and connection string.
        static string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        static string dbEmpPath = Path.Combine(baseDirectory, "employee.db");
        static string connect_emp_string = $"Data Source={dbEmpPath}";

        // Constructor that loads employee items from the database.
        public EmployeeDBhandler()
        {
            LoadEmployeeFromDB();
        }

        // Method to check if the 'employee' table exists in the database.
        protected bool IsTableExist()
        {
            using (SQLiteConnection connection = new SQLiteConnection(connect_emp_string))
            {
                connection.Open();
                string sql = $"Select name from sqlite_master where  type='table' and name='employee';";
                using (SQLiteCommand cmd = new SQLiteCommand(sql, connection))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        return reader.Read();
                    }
                }
            }
        }

        // Method to create the 'employee' table if it does not exist.
        private void CreateTableDB()
        {
            if (!IsTableExist())
            {
                SQLiteConnection connection = new SQLiteConnection(connect_emp_string);
                connection.Open();
                string sql = "Create table employee(Name TEXT(30), Position TEXT(30), Email TEXT(30), JoinDate TEXT(30), Wage REAL)";
                using (SQLiteCommand cmd = new SQLiteCommand(sql, connection))
                {
                    cmd.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        // Method to load employee items from the database.
        public List<Employees> LoadEmployeeFromDB()
        {
            employeeList.Clear();
            SQLiteConnection connection = new SQLiteConnection(connect_emp_string);
            connection.Open();
            string sql = "SELECT * from employee";
            SQLiteCommand cmd = new SQLiteCommand(sql, connection);
            using (cmd)
            {
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Employees emp = new Employees();
                        emp.Name = reader["Name"].ToString();
                        emp.Position = reader["Position"].ToString();
                        emp.Email = reader["Email"].ToString();
                        emp.JoinDate = Convert.ToDateTime(reader["JoinDate"]);
                        emp.Wage = Convert.ToDouble(reader["Wage"]);
                        employeeList.Add(emp);
                    }
                }
            }
            connection.Close();
            return employeeList;
        }

        // Method to insert an employee item into the database.
        public void InsertEmployeeDB(string name, string position, string email, DateTime joinDate, double wage)
        {
            SQLiteConnection connection = new SQLiteConnection(connect_emp_string);
            connection.Open();
            string sql = $"Insert into employee(Name, Position, Email, JoinDate, Wage) values('{name}', '{position}', '{email}', '{joinDate}', '{wage}')";
            SQLiteCommand cmd = new SQLiteCommand(sql, connection);
            using (cmd)
            {
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@position", position);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@joinDate", joinDate);
                cmd.Parameters.AddWithValue("@wage", wage);
                cmd.ExecuteNonQuery();
            }
            connection.Close();
        }

        // Method to update an existing employee item in the database.
        public static string UpdateEmployeeToDB(string name, string position, string email, DateTime joinDate, double wage)
        {
            try
            {
                SQLiteConnection connection = new SQLiteConnection(connect_emp_string);
                connection.Open();
                string sql = "Update employee set Position = @position, Email = @email, JoinDate = @joinDate, Wage = @wage where Name = @name";
                SQLiteCommand cmd = new SQLiteCommand(sql, connection);
                using (cmd)
                {
                    cmd.Parameters.AddWithValue("@position", position);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@joinDate", joinDate);
                    cmd.Parameters.AddWithValue("@wage", wage);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
                return "Employee updated successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        // Method to delete an employee item from the database.
        public string DeleteEmployeeDB(string name)
        {
            try
            {
                SQLiteConnection connection = new SQLiteConnection(connect_emp_string);
                connection.Open();
                string sql = "Delete from employee where Name = @name";
                SQLiteCommand cmd = new SQLiteCommand(sql, connection);
                using (cmd)
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.ExecuteNonQuery();
                }
                connection.Close();
                return "Employee deleted successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}