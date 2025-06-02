using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BojoweZaby.Models;
using Microsoft.EntityFrameworkCore;

namespace BojoweZaby.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly AppDbContext _context;

    public HomeController(ILogger<HomeController> logger, AppDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        if (HttpContext.Session.GetString("Login") == null)
        {
            // User is already logged in, redirect to the appropriate dashboard
           return RedirectToAction("Login");
        }
        return View();
    }

    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(string login, string password)
    {
        Console.WriteLine($"Login attempt with login: {login} and password: {password}");
        
        if(_context.checkCredentials(login, password) == false)
        {
            ViewBag.Error = "Invalid login or password.";
            return View();
        }

        AccountType? accountType = _context.GetAccountType(login);

        

        if (accountType == AccountType.Admin)
        {
            HttpContext.Session.SetString("Login", login);
            HttpContext.Session.SetString("AccountType", accountType.ToString());
            HttpContext.Session.SetString("Username", _context.GetUsername(login));
            return RedirectToAction("Dashboard", "Admin");
        }
        else if (accountType == AccountType.Player) 
        {
            HttpContext.Session.SetString("Login", login);
            HttpContext.Session.SetString("AccountType", accountType.ToString());
            HttpContext.Session.SetString("Username", _context.GetUsername(login));

            return RedirectToAction("Dashboard", "Player");
        }else{
            ViewBag.Error = "Account type not found.";
            return View();
        }
        

    }

    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Login");
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    

}
