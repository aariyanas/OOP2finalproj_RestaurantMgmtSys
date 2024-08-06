using Microsoft.Identity.Client;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.Data
{
    public class EmployeeManager
    {
        public static List<Employees> employeeList;

        public static string AddEmployee(string name, string position, string email, DateTime joinDate, double wage)
        {
            EmployeeDBhandler db = new EmployeeDBhandler();
            db.InsertEmployeeDB(name , position, email, joinDate, wage);
            return "Employee added successfully";
        }

        public static List<Employees> RetrieveEmployee()
        {
            EmployeeDBhandler db = new EmployeeDBhandler();
            employeeList = db.LoadEmployeeFromDB();
            return employeeList;
        }

        public static string EditEmployee(string name, string position, string email, DateTime joinDate, double wage)
        {
            string message = EmployeeDBhandler.UpdateEmployeeToDB(name, position, email, joinDate, wage);
            RetrieveEmployee();
            return message;
        }

        public static string DeleteEmployee(string name)
        {
            EmployeeDBhandler db = new EmployeeDBhandler();
            string message = db.DeleteEmployeeDB(name);
            RetrieveEmployee();
            return message;
        }
    }
}
