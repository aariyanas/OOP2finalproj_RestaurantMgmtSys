using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace RestaurantManagement.Data
{
    [Table("Inventory")]
    public class Inventory
    {
        [PrimaryKey, AutoIncrement]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [Column("Quantity")]
        public double Quantity { get; set; }

        [Column("Price")]
        public string Price { get; set; }

        [Column("Category")]
        public string Category { get; set; }

        [Column("QuantityToOrder")]
        public double QuantityToOrder { get; set; }

     
    }
}