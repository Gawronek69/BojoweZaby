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

    public List<EquipmentModel> GetItemsByFrogId(int frogId)
    {
        var eq = Equipment
            .Where(e => e.FrogId == frogId)
            .Include(e => e.Item)
            .ToList();
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

    public FrogModel? GetRandomFrog(string login)
    {
        var frogs = Frogs.Where(f => f.HP > 0).ToList();
        if (frogs.Count <= 1)
        {
            return null;
        }
        FrogModel? accountFrog = GetFrogByOwnerLogin(login);
        Random random = new Random();
        if (accountFrog == null)
        {
            return null;
        }
        frogs.Remove(accountFrog);
        int index = random.Next(frogs.Count);
        return frogs[index];
    }

    public int frogPower(FrogModel frog)
    {
        var frogEq = Equipment
            .Where(e => e.FrogId == frog.FrogId).Select(e => e.Item).ToList();
        return frogEq.Sum(i => i.BaseAttack);
    }

    public int frogDefence(FrogModel frog)
    {
        var frogEq = Equipment
            .Where(e => e.FrogId == frog.FrogId).Select(e => e.Item).ToList();
        return frogEq.Sum(i => i.BaseDefense);
    }

    public void transferEq(FrogModel attacker, FrogModel defender)
    {
        var defenderEq = Equipment.Where(e => e.FrogId == defender.FrogId).ToList();
        foreach (var eq in defenderEq)
        {
            eq.FrogId = attacker.FrogId;
            eq.Frog = attacker;
        }
        SaveChanges();
    }

    public List<ItemModel?> getFrogEq(FrogModel frog)
    {
        return Equipment
            .Where(e => e.FrogId == frog.FrogId)
            .Select(e => e.Item)
            .ToList();
    }

    public EquipmentModel? getEquipmentById(int id)
    {
        return Equipment.Include(e => e.Item).FirstOrDefault(e => e.Id == id);
    }

    public ItemModel? getItemById(int id)
    {
        return Items.FirstOrDefault(i => i.ItemId == id);
    }
    
    public void AddFight(FrogModel frog1, FrogModel frog2)
    {
        Fights.Add(new FightModel
        {
            Frog1Id = frog1.FrogId,
            Frog2Id = frog2.FrogId,
            Frog1 = frog1,
            Frog2 = frog2
        });
        SaveChanges();
    }
    


}