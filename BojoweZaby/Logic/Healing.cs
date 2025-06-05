using BojoweZaby.Models;

namespace BojoweZaby.Logic;

public class Healing
{
    public static int heal(ItemModel item) {
        return (item.BaseDefense + item.BaseAttack) * ((int)item.Rarity + 2) / 12;    
    }
}