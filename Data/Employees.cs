using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace RestaurantManagement.Data
{
    [Table("Employees")]
    public class Employees
    {
        [PrimaryKey, AutoIncrement]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [Column("Position")]
        public double Position { get; set; }

        [Column("Email")]
        public string Email { get; set; }

        [Column("JoinDate")]
        public string JoinDate { get; set; }

        [Column("Wage")]
        public double Wage { get; set; }
    }
}
