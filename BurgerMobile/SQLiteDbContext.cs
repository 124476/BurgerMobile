
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
            await Database.CreateTableAsync<BCombo>();
            await Database.CreateTableAsync<ComboAndBurger>();
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

    public async Task<List<BCombo>> GetAllCombos()
    {
        await InitializeDatabase();
        var combos = await Database.Table<BCombo>().ToListAsync();
        return combos;
    } 


    public async Task<int> AddCombo(BCombo burgerCombo){
        await InitializeDatabase();
        if (burgerCombo.Id != 0)
        {
            return await Database.UpdateAsync(burgerCombo);
        }
        else
        {
            return await Database.InsertAsync(burgerCombo);
        }
    }
    public async Task<int> DeleteCombo(BCombo burgerCombo)
    {
        await InitializeDatabase();
        return await Database.DeleteAsync(burgerCombo);
    }
    public async Task<List<Otzav>> GetAllOtzav()
    {
        await InitializeDatabase();
        var otzavs = await Database.Table<Otzav>().ToListAsync();
        return otzavs;
    }
    public async Task<int> AddOtzav(Otzav otzav)
    {
        await InitializeDatabase();
        if (otzav.Id != 0)
        {
            return await Database.UpdateAsync(otzav);
        }
        else
        {
            return await Database.InsertAsync(otzav);
        }
    }
    public async Task<int> DeleteOtzav(Otzav otzav)
    {
        await InitializeDatabase();
        return await Database.DeleteAsync(otzav);
    }
    public async Task<List<ComboAndBurger>> GetAllComboAndBurgers()
    {
        await InitializeDatabase();
        var otzavs = await Database.Table<ComboAndBurger>().ToListAsync();
        return otzavs;
    }
    public async Task<int> AddComboAndBurger(ComboAndBurger otzav)
    {
        await InitializeDatabase();
        if (otzav.Id != 0)
        {
            return await Database.UpdateAsync(otzav);
        }
        else
        {
            return await Database.InsertAsync(otzav);
        }
    }
    public async Task<int> DeleteComboAndBurger(ComboAndBurger otzav)
    {
        await InitializeDatabase();
        return await Database.DeleteAsync(otzav);
    }
}