namespace BojoweZaby.Logic;

using BojoweZaby.Models;

public class ArcherClass : FrogClassT
{
    public ArcherClass()
    {
        ClassId = FrogClass.Warrior; 
        Name = "Warrior";
        BaseAttack = 22;
        BaseDefense = 5;
        BaseHP = 175;
    }

    public override void SpecialAbility()
    {
        Console.WriteLine("Unleashing a powerful strike!");
    }
}