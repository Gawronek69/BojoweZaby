namespace BojoweZaby.Logic;
using BojoweZaby.Models;
public abstract class FrogClassT
{
    public FrogClass ClassId { get; set; }
    public string Name { get; set; }
    public int BaseAttack { get; set; }
    public int BaseDefense { get; set; }
    public int BaseHP { get; set; }
    public abstract void SpecialAbility();

}