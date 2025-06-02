using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BojoweZaby.Models;
using Microsoft.EntityFrameworkCore;
using BojoweZaby.Logic;

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
        if (HttpContext.Session.GetString("Login") == null)
        {
            return RedirectToAction("Login", "Home");
        }

        FrogModel? frog = _context.GetFrogByOwnerLogin(HttpContext.Session.GetString("Login"));
        if (frog == null)
        {
            return View();
        }
        HttpContext.Session.SetString("FrogId", frog.FrogId.ToString());
        return View(frog);

    }

    public IActionResult CreateFrog()
    {
        if (HttpContext.Session.GetString("Login") == null)
        {
            return RedirectToAction("Login", "Home");
        }
        ViewBag.ClassTypes = Enum.GetValues(typeof(FrogClass));
        Console.WriteLine("Available Frog Classes: " + string.Join(", ", ViewBag.ClassTypes));
        return View();
    }

    [HttpPost]
    public IActionResult CreateFrog(IFormCollection form)
    {
        if (HttpContext.Session.GetString("Login") == null)
        {
            return RedirectToAction("Login", "Home");
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
            AccountId = account.AccountId,
            Account = account
        });
        _context.SaveChanges();


        return RedirectToAction("Dashboard", "Player");
    }

    public IActionResult Equipment()
    {
        if (HttpContext.Session.GetString("Login") == null)
        {
            return RedirectToAction("Login", "Home");
        }

        List<ItemModel> items = _context.GetItemsByFrogId(int.Parse(HttpContext.Session.GetString("FrogId") ?? "-1"));
        if (items == null)
        {
            HttpContext.Session.Remove("FrogId");
            return RedirectToAction("Dashboard", "Player");
        }
        return View(items);
    }

    public IActionResult Explore()
    {
        if (HttpContext.Session.GetString("Login") == null)
        {
            return RedirectToAction("Login", "Home");
        }

        FrogModel? frog = _context.GetFrogByOwnerLogin(HttpContext.Session.GetString("Login"));
        if (frog == null)
        {
            return RedirectToAction("Dashboard", "Player");
        }
        
        return View();
    }

}