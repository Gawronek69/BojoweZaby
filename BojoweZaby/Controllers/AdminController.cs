using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BojoweZaby.Models;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;
namespace BojoweZaby.Controllers;

public class AdminController : Controller
{
    private readonly ILogger<AdminController> _logger;
    private readonly AppDbContext _context;

    public AdminController(ILogger<AdminController> logger, AppDbContext context)
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

        return View();
    }

    public IActionResult Users()
    {
        if (HttpContext.Session.GetString("Login") == null)
        {
            return RedirectToAction("Login", "Home");
        }

        return View(_context.Accounts.ToList());
    }

    public IActionResult Items()
    {
        if (HttpContext.Session.GetString("Login") == null)
        {
            return RedirectToAction("Login", "Home");
        }

        return View(_context.Items.ToList());
    }

    public IActionResult ItemCreation()
    {

        if (HttpContext.Session.GetString("Login") == null)
        {
            return RedirectToAction("Login", "Home");
        }

        return View();

    }

    [HttpPost]
    public IActionResult ItemCreation(IFormCollection form)
    {
        //Validation on frontend

        string name = form["itemName"];
        string? rarity = form["itemRarity"];
        Enum.TryParse<ItemRarity>(rarity, out var parsedRarity);
        string? baseAttack = form["itemAttack"];
        Int32.TryParse(baseAttack, out int parsedBaseAttack);
        string? baseDefense = form["itemDefense"];
        Int32.TryParse(baseDefense, out int parsedBaseDefense);
        string? desc = form["itemDesc"];

        _context.Add(new ItemModel { Name = name, Rarity = parsedRarity, BaseAttack = parsedBaseAttack, BaseDefense = parsedBaseDefense, Description = desc });
        _context.SaveChanges();
        return RedirectToAction("Items");
    }

    public IActionResult DeleteItem(int id)
    {
        if (HttpContext.Session.GetString("Login") == null)
        {
            return RedirectToAction("Login", "Home");
        }

        var item = _context.Items.Find(id);
        if (item != null)
        {
            _context.Items.Remove(item);
            _context.SaveChanges();
        }
        return RedirectToAction("Items");
    }

    public IActionResult EditItem(int id)
    {
        if (HttpContext.Session.GetString("Login") == null)
        {
            return RedirectToAction("Login", "Home");
        }

        var item = _context.Items.Find(id);
        if (item == null)
        {
            return NotFound();
        }

        ViewBag.ItemRarities = Enum.GetValues(typeof(ItemRarity));

        return View(item);
    }

    [HttpPost]
    public IActionResult EditItem(int id, IFormCollection form)
    {
        if (HttpContext.Session.GetString("Login") == null)
        {
            return RedirectToAction("Login", "Home");
        }

        var item = _context.Items.Find(id);
        if (item == null)
        {
            return NotFound();
        }

        item.Name = form["itemName"];
        string? rarity = form["itemRarity"];
        Enum.TryParse<ItemRarity>(rarity, out var parsedRarity);
        item.Rarity = parsedRarity;
        string? baseAttack = form["itemAttack"];
        Int32.TryParse(baseAttack, out int parsedBaseAttack);
        item.BaseAttack = parsedBaseAttack;
        string? baseDefense = form["itemDefense"];
        Int32.TryParse(baseDefense, out int parsedBaseDefense);
        item.BaseDefense = parsedBaseDefense;
        item.Description = form["itemDesc"];

        _context.Update(item);
        _context.SaveChanges();

        return RedirectToAction("Items");
    }

    public IActionResult UserCreation()
    {
        if (HttpContext.Session.GetString("Login") == null)
        {
            return RedirectToAction("Login", "Home");
        }

        return View();
    }

    [HttpPost]
    public IActionResult UserCreation(IFormCollection form)
    {
        if (HttpContext.Session.GetString("Login") == null)
        {
            return RedirectToAction("Login", "Home");
        }
        //TODO
        string? username = form["username"];
        string? password = BCrypt.Net.BCrypt.HashPassword(form["password"]); ;
        string? login = form["login"];
        string? accountType = form["accountType"];
        Enum.TryParse<AccountType>(accountType, out var parsedAccountType);
        _context.Add(new AccountModel { Username = username, Password = password, Login = login, AccountTypeName = parsedAccountType });
        _context.SaveChanges();
        return RedirectToAction("Users");
    }


    public IActionResult DeleteUser(int id)
    {
        if (HttpContext.Session.GetString("Login") == null)
        {
            return RedirectToAction("Login", "Home");
        }

        var user = _context.Accounts.Find(id);
        if (user != null)
        {
            _context.Accounts.Remove(user);
            _context.SaveChanges();
        }
        return RedirectToAction("Users");
    }

    public IActionResult EditUser(int id)
    {
        if (HttpContext.Session.GetString("Login") == null)
        {
            return RedirectToAction("Login", "Home");
        }

        var user = _context.Accounts.Find(id);
        if (user == null)
        {
            return NotFound();
        }
        return View(user);
    }
    
    [HttpPost]
     public IActionResult EditUser(int id, IFormCollection form)
    {
        if (HttpContext.Session.GetString("Login") == null)
        {
            return RedirectToAction("Login", "Home");
        }

        var user = _context.Accounts.Find(id);
        if (user == null)
        {
            return NotFound();
        }

        user.Username = form["username"];
        user.Login = form["login"]; 
        Console.WriteLine($"{user.Password}\n{form["password"]}");
        if (user.Password != form["password"])
        {

            user.Password = BCrypt.Net.BCrypt.HashPassword(form["password"]);
        }
        _context.Update(user);
        _context.SaveChanges();

        return RedirectToAction("Users");
    }
    
}