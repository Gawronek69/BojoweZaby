using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace BojoweZaby.Models;

public class EquipmentModel
{
    [Key]
    public int Id { get; set; }
    public int FrogId { get; set; } 

    public int ItemId { get; set; }

    [ForeignKey(nameof(FrogId))]
    public FrogModel? Frog { get; set; }

    [ForeignKey(nameof(ItemId))]
    public ItemModel? Item { get; set; }

    public EquipmentModel() { }
    public EquipmentModel(int id, int frogId, int itemId, FrogModel? frog, ItemModel? item)
    {
        Id = id;
        FrogId = frogId;
        ItemId = itemId;
        Frog = frog;
        Item = item;
    }


}