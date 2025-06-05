using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BojoweZaby.Models;
using Microsoft.EntityFrameworkCore;
using BojoweZaby.Logic;
using System.Runtime.InteropServices;

namespace BojoweZaby.Controllers;

public class PlayerController : Controller
{
    private readonly ILogger<PlayerController> _logger;
    private readonly AppDbContext _context;

    public PlayerController(ILogger<PlayerController> logger, AppDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Dashboard()
    {
        if (checkCredentials() != null)
        {
            return checkCredentials();
        }

        FrogModel? frog = _context.GetFrogByOwnerLogin(HttpContext.Session.GetString("Login"));
        if (frog == null)
        {
            return View();
        }
        ViewBag.EffectiveAttack = _context.frogPower(frog);
        ViewBag.EffectiveDefense = _context.frogDefence(frog);
        HttpContext.Session.SetString("FrogId", frog.FrogId.ToString());
        return View(frog);

    }

    public IActionResult CreateFrog()
    {
        if (checkCredentials() != null)
        {
            return checkCredentials();
        }

        ViewBag.ClassTypes = Enum.GetValues(typeof(FrogClass));
        Console.WriteLine("Available Frog Classes: " + string.Join(", ", ViewBag.ClassTypes));
        return View();
    }

    [HttpPost]
    public IActionResult CreateFrog(IFormCollection form)
    {
        if (checkCredentials() != null)
        {
            return checkCredentials();
        }

        string name = form["Name"];
        string classId = form["ClassId"];
        Enum.TryParse<FrogClass>(classId, out FrogClass frogClass);

        FrogClassT frogClassT = null;

        switch (frogClass)
        {
            case FrogClass.Warrior:
                frogClassT = new WarriorClass { Name = name };
                break;
            case FrogClass.Archer:
                frogClassT = new ArcherClass { Name = name };
                break;
            case FrogClass.Mage:
                frogClassT = new WizardClass { Name = name };
                break;
            case FrogClass.Monk:
                frogClassT = new MonkClass { Name = name };
                break;
            default:
                ViewBag.Error = "Invalid frog class selected.";
                return View();
        }

        AccountModel? account = _context.GetAccountByLogin(HttpContext.Session.GetString("Login"));


        _context.Frogs.Add(new FrogModel
        {
            Name = frogClassT.Name,
            ClassId = frogClass,
            BaseAttack = frogClassT.BaseAttack,
            BaseDefense = frogClassT.BaseDefense,
            HP = frogClassT.BaseHP,
            MaxHp = frogClassT.BaseHP,
            AccountId = account.AccountId,
            Account = account,
            ImgPath = frogClassT.ImgPath
        });

        _context.SaveChanges();


        return RedirectToAction("Dashboard", "Player");
    }

    public IActionResult Equipment()
    {
        if (checkCredentials() != null)
        {
            return checkCredentials();
        }

        List<EquipmentModel> items = _context.GetItemsByFrogId(int.Parse(HttpContext.Session.GetString("FrogId")));
        if (items == null)
        {
            HttpContext.Session.Remove("FrogId");
            return RedirectToAction("Dashboard", "Player");
        }
        return View(items);
    }

    public IActionResult Explore()
    {
        if (checkCredentials() != null)
        {
            return checkCredentials();
        }

        FrogModel? frog = _context.GetFrogByOwnerLogin(HttpContext.Session.GetString("Login"));
        if (frog == null)
        {
            return RedirectToAction("Dashboard", "Player");
        }

        var randomItem = _context.retriveRandomItem();

        if (randomItem != null)
        {
            _context.Equipment.Add(new EquipmentModel
            {
                FrogId = frog.FrogId,
                Frog = frog,
                ItemId = randomItem.ItemId,
                Item = randomItem
            });
            _context.SaveChanges();
            return View(randomItem);
        }


        return RedirectToAction("Dashboard", "Player");

    }

    public IActionResult Attack()
    {
        if (checkCredentials() != null)
        {
            return checkCredentials();
        }

        FrogModel? frog = _context.GetFrogByOwnerLogin(HttpContext.Session.GetString("Login"));
        var enemyFrog = _context.GetRandomFrog(HttpContext.Session.GetString("Login"));
        _context.AddFight(frog, enemyFrog);
        if (Fight.attackFrog(frog, enemyFrog, _context))
        {
            var gainedEq = _context.getFrogEq(enemyFrog);
            ViewBag.Eq = gainedEq;
            _context.transferEq(frog, enemyFrog);
            ViewBag.Win = "You defeated the enemy frog!";
        }
        else
        {
            ViewBag.Attack = "You attacked the enemy frog!";
        }

        return View("Attack", "Player");
    }

    public IActionResult Fights()
    {
        if (checkCredentials() != null)
        {
            return checkCredentials();
        }
        FrogModel? frog = _context.GetFrogByOwnerLogin(HttpContext.Session.GetString("Login"));
        var fights = _context.Fights
            .Include(f => f.Frog1)
            .Include(f => f.Frog2)
            .Where(f => f.Frog1.FrogId == frog.FrogId || f.Frog2.FrogId == frog.FrogId)
            .ToList();

        return View(fights);
    }

    public IActionResult DeleteFrog()
    {
        if (checkCredentials() != null)
        {
            return checkCredentials();
        }

        FrogModel? frog = _context.GetFrogByOwnerLogin(HttpContext.Session.GetString("Login"));
        if (frog == null)
        {
            return RedirectToAction("Dashboard", "Player");
        }

        _context.Frogs.Remove(frog);
        _context.SaveChanges();
        HttpContext.Session.Remove("FrogId");

        return RedirectToAction("Dashboard", "Player");
    }

    [Route("Player/EatItem")]
    public IActionResult EatItem(int eqId)
    {
        if (checkCredentials() != null)
        {
            return checkCredentials();
        }
        Console.WriteLine($"Eating item with ID: {eqId}");
        FrogModel? frog = _context.GetFrogByOwnerLogin(HttpContext.Session.GetString("Login"));
        if (frog == null)
        {
            return RedirectToAction("Dashboard", "Player");
        }

        EquipmentModel? item = _context.getEquipmentById(eqId);

        Console.WriteLine($"Item found: {item.ItemId}");

        int healAmount = Healing.heal(item.Item);
        if (frog.HP + healAmount > frog.MaxHp)
        {
            frog.HP = frog.MaxHp;
        }
        _context.Remove(item);
        _context.SaveChanges();

        return RedirectToAction("Dashboard", "Player");
    }

    private IActionResult checkCredentials()
    {
        if (HttpContext.Session.GetString("Login") == null)
        {
            return RedirectToAction("Login", "Home");
        }

        if (HttpContext.Session.GetString("AccountType") != AccountType.Player.ToString())
        {
            return RedirectToAction("Dashboard", "Admin");
        }

        return null;
    }
    
    

}