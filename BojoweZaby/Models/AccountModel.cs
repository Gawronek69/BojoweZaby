using System.ComponentModel.DataAnnotations;
using System.Security.Principal;
using Microsoft.EntityFrameworkCore;

namespace BojoweZaby.Models; 


public class AccountModel
{
    [Key]
    public int AccountId { get; set; }
    [Required]
    public string Username { get; set; } = "";
    [Required]
    public string Password { get; set; } = "";
    [Required]
    public string Login { get; set; } = "";

    [Required]
    public AccountType AccountTypeName { get; set; }

    public AccountModel() { }

    public AccountModel(int accountId, string username, string password, string login, AccountType accountTypeName)
    {
        this.AccountId = accountId;
        this.Username = username;
        this.Password = password;
        this.Login = login;
        this.AccountTypeName = accountTypeName;
    }
    
} 