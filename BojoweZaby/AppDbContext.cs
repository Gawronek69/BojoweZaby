using Microsoft.EntityFrameworkCore;
using BojoweZaby.Models;
using BCrypt.Net;
public class AppDbContext : DbContext
{
    public DbSet<FrogModel> Frogs { get; set; }
    public DbSet<AccountModel> Accounts { get; set; }
    public DbSet<ItemModel> Items { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<FightModel> Fights { get; set; }
    public DbSet<EquipmentModel> Equipment { get; set; }
    public DbSet<AccountModel> AccountModels { get; set; }
    public DbSet<FrogModel> FrogModels { get; set; }
    public DbSet<ItemModel> ItemModels { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

    }

    public AccountType? GetAccountType(string login)
    {
        var account = Accounts.FirstOrDefault(a => a.Login == login);
        if (account == null)
        {
            return null;
        }
        return account.AccountTypeName;
    }

    public string GetUsername(string login)
    {
        var account = Accounts.FirstOrDefault(a => a.Login == login);
        if (account == null)
        {
            return string.Empty;
        }
        return account.Username;
    }



    public bool checkCredentials(string login, string password)
    {
        var account = Accounts.FirstOrDefault(a => a.Login == login);
        if (account == null)
        {
            return false;
        }
        else
        {
            return BCrypt.Net.BCrypt.Verify(password, account.Password);
        }

    }

    public AccountModel? GetAccountByLogin(string login)
    {
        return Accounts.FirstOrDefault(a => a.Login == login);
    }

    public FrogModel? GetFrogByOwnerLogin(string login)
    {
        return Frogs.Include(f => f.Account).FirstOrDefault(f => f.Account.Login == login);
    }

    public List<ItemModel> GetItemsByFrogId(int frogId)
    {
        var eq = from e in Equipment
                 where e.FrogId == frogId
                 select e.Item;
        return eq.ToList();
    }

    public ItemModel? retriveRandomItem()
    {
        var items = Items.ToList();
        if (items.Count == 0)
        {
            return null;
        }
        Random random = new Random();
        int index = random.Next(items.Count);
        return items[index];
    }
    
    


}