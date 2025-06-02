using System.ComponentModel.DataAnnotations;


namespace BojoweZaby.Models;

public class ItemModel
{
    [Key]
    public int ItemId { get; set; }
    [Required]
    public string Name { get; set; } = "";
    [Required]
    public ItemRarity Rarity { get; set; }
    [Required]
    public int BaseAttack { get; set; }
    [Required]
    public int BaseDefense { get; set; }

    public string Description { get; set; } = "";


    public ItemModel() { }

    public ItemModel(int itemId, string name, ItemRarity rarity, int baseAttack, int baseDefense, string description)
    {
        ItemId = itemId;
        Name = name;
        Rarity = rarity;
        BaseAttack = baseAttack;
        BaseDefense = baseDefense;
        Description = description;
    }

}