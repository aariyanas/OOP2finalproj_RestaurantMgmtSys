using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace RestaurantManagement.Data
{
    public class Employees
    {
        string name;
        string position;
        string email;
        DateTime joinDate;
        double wage;

        public Employees()
        {
            
        }

        public string Name { get => name; set => name = value; }
        public string Position { get => position; set => position = value; }
        public string Email { get => email; set => email = value; }
        public DateTime JoinDate { get => joinDate; set => joinDate = value; }
        public double Wage { get => wage; set => wage = value; }
    }
}
