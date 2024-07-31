using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantManagement.Components;
using SQLite;

namespace RestaurantManagement.Data
{
    public static class StringExtensions
    {
        public static string ToPascalCase(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return str;

            return string.Join(" ", str.Split(new char[] { ' ', '-' }, StringSplitOptions.RemoveEmptyEntries)
                                      .Select(word => char.ToUpper(word[0]) + word.Substring(1).ToLower()));
        }
    }
}
