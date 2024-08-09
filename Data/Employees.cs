using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace RestaurantManagement.Data
{
    // This class represents an employee in the restaurant management system.
    public class Employees
    {
        // Fields to store the name, position, email, join date, and wage of the employee.
        string name;
        string position;
        string email;
        DateTime joinDate;
        double wage;

        // Default constructor.
        public Employees()
        {

        }

        // Parameterized constructor to initialize an employee with specified values.
        public string Name { get => name; set => name = value; }
        public string Position { get => position; set => position = value; }
        public string Email { get => email; set => email = value; }
        public DateTime JoinDate { get => joinDate; set => joinDate = value; }
        public double Wage { get => wage; set => wage = value; }
    }
}
