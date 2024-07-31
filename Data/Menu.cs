using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace RestaurantManagement.Data
{
    [Table("Menu")]
    public class Menu
    {
        [PrimaryKey, AutoIncrement]
        [Column("Id")]
        public int Id  { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [Column("Price")]
        public double Price { get; set; }

        [Column("Category")]
        public string Category { get; set; }
    }
}
