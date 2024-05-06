
using BurgerMobile.Models;
using SQLite;

public class SQLiteDbContext
{
    const string DataBaseFileName = "sqlitedatabase.db3";
    static string DatabasePath => Path.Combine(FileSystem.AppDataDirectory, DataBaseFileName);
    const SQLite.SQLiteOpenFlags Flags = SQLite.SQLiteOpenFlags.ReadWrite
                                         | SQLite.SQLiteOpenFlags.Create
                                         | SQLite.SQLiteOpenFlags.SharedCache;
    SQLiteAsyncConnection Database;

    public SQLiteDbContext()
    {
        Database = new SQLiteAsyncConnection(DatabasePath, Flags);
        InitializeDatabase();
    }

    async Task InitializeDatabase()
    {
        if (Database is not null)
        {
            await Database.CreateTableAsync<Burger>();
            await Database.CreateTableAsync<Otzav>();
            await Database.CreateTableAsync<BurgerCombo>();
        }
    }

    public async Task<List<Burger>> GetAllBurgers()
    {
        await InitializeDatabase();

        var burgers = await Database.Table<Burger>().ToListAsync();

        return burgers;
    }

    public async Task<int> AddBurgersAsyns(Burger burger)
    {
        await InitializeDatabase();
        if (burger.Id != 0)
        {
            return await Database.UpdateAsync(burger);
        }
        else
        {
            return await Database.InsertAsync(burger);
        }
    }

    public async Task<int> DeleteBurgerAsyns(Burger burger)
    {
        await InitializeDatabase();
        return await Database.DeleteAsync(burger);
    }

    public async Task<List<BurgerCombo>> GetAllCombos()
    {
        await InitializeDatabase();
        var combos = await Database.Table<BurgerCombo>().ToListAsync();
        return combos;
    } 
}