using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace BojoweZaby.Models;

public class FrogModel
{
    [Key]
    public int FrogId { get; set; }
    [Required]
    public string Name { get; set; } = "";
    [Required]
    [Range(0, 10000, ErrorMessage = "HP must be between 0 and 10000.")]
    public int HP { get; set; } = 0;
    [Required]
    public int BaseAttack { get; set; } = 0;
    [Required]
    public int BaseDefense { get; set; } = 0;
    [Required]
    public FrogClass ClassId { get; set; }
    [Required]
    public int AccountId { get; set; }

    [Required]
    [ForeignKey("AccountId")]
    public AccountModel Account { get; set; }

    public FrogModel() { }
    public FrogModel(int frogId, string name, int hp, int baseAttack, int baseDefense, FrogClass frogClass, int accountId, AccountModel account)
    {
        this.FrogId = frogId;
        this.Name = name;
        this.HP = hp;
        this.BaseAttack = baseAttack;
        this.BaseDefense = baseDefense;
        this.ClassId = frogClass;
        this.AccountId = accountId;
        this.Account = account;

    }
    
    




}