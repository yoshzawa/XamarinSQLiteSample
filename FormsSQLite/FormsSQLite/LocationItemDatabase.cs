using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Threading.Tasks;



namespace FormsSQLite
{
    public class LocationItemDatabase
    {
        readonly SQLiteAsyncConnection database;

        public LocationItemDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<LocationItem>().Wait();
        }

        public Task<List<LocationItem>> GetItemsAsync()
        {
            return database.Table<LocationItem>().ToListAsync();
        }

        public Task<List<LocationItem>> GetItemsNotDoneAsync()
        {
            return database.QueryAsync<LocationItem>("SELECT * FROM [LocationItem] WHERE [Done] = 0");
        }

        public Task<LocationItem> GetItemAsync(int id)
        {
            return database.Table<LocationItem>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(LocationItem item)
        {
            if (item.ID != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(LocationItem item)
        {
            return database.DeleteAsync(item);
        }
    }
}
