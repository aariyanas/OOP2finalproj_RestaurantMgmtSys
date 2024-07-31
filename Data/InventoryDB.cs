using Microsoft.Identity.Client;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.Data
{
    public class InventoryDB
    {
        private const string DB_NAME = "Inventory";
        private readonly SQLiteAsyncConnection _connection;

        public InventoryDB()
        {
            _connection = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, DB_NAME));
            _connection.CreateTableAsync<Inventory>().Wait();
        }


        public async Task<List<Inventory>> GetInventory()
        {
            return await _connection.Table<Inventory>().ToListAsync();
        }

        public async Task<Inventory> GetById(int id)
        {
            return await _connection.Table<Inventory>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public async Task<int> AddInventoryItem(Inventory newItem)
        {
            return await _connection.InsertAsync(newItem);
        }

        public async Task<int> UpdateInventoryItem(Inventory itemToUpdate)
        {
            return await _connection.UpdateAsync(itemToUpdate);
        }

        public async Task<int> DeleteInventoryItem(Inventory itemToDelete)
        {
            return await _connection.DeleteAsync(itemToDelete);
        }
    }
}
