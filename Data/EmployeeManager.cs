using Microsoft.Identity.Client;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.Data
{
    // This class manages employee-related operations, providing a higher-level interface for adding, retrieving, editing, and deleting employees.
    public class EmployeeManager
    {
        // List to store the employees.
        public static List<Employees> employeeList;

        // Method to add a new employee.
        public static string AddEmployee(string name, string position, string email, DateTime joinDate, double wage)
        {
            EmployeeDBhandler db = new EmployeeDBhandler();
            db.InsertEmployeeDB(name , position, email, joinDate, wage);
            return "Employee added successfully";
        }

        // Method to retrieve all employees from the database.
        public static List<Employees> RetrieveEmployee()
        {
            EmployeeDBhandler db = new EmployeeDBhandler();
            employeeList = db.LoadEmployeeFromDB();
            return employeeList;
        }

        // Method to edit an existing employee.
        public static string EditEmployee(string name, string position, string email, DateTime joinDate, double wage)
        {
            string message = EmployeeDBhandler.UpdateEmployeeToDB(name, position, email, joinDate, wage);
            RetrieveEmployee();
            return message;
        }

        // Method to delete an employee.
        public static string DeleteEmployee(string name)
        {
            EmployeeDBhandler db = new EmployeeDBhandler();
            string message = db.DeleteEmployeeDB(name);
            RetrieveEmployee();
            return message;
        }
    }
}
