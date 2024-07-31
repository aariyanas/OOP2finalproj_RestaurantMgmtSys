using Microsoft.Identity.Client;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.Data
{
    public class MenuDB
    {
        private const string DB_NAME = "restaurant.db";
        private readonly SQLiteAsyncConnection _connection;

        public MenuDB()
        {
            _connection = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, DB_NAME));
            _connection.CreateTableAsync<Menu>();
        }
        
        public async Task<List<Menu>> GetMenu()
        {
            return await _connection.Table<Menu>().ToListAsync();
        }

        public async Task<Menu> GetById(int id)
        {
            return await _connection.Table<Menu>().Where(m => m.Id == id).FirstOrDefaultAsync();
        }

        public async Task<int> AddMenuItem(Menu newItem)
        {
            return await _connection.InsertAsync(newItem);
        }

        public async Task<int> DeleteMenuItem(Menu itemToDelete)
        {
            return await _connection.DeleteAsync(itemToDelete);
        }
    }
}
