namespace BojoweZaby.Logic;

using BojoweZaby.Models;

public class MonkClass : FrogClassT
{
    public MonkClass()
    {
        ClassId = FrogClass.Monk;
        Name = "Monk";
        BaseAttack = 20;
        BaseDefense = -5;
        BaseHP = 350;
    }

    public override void SpecialAbility()
    {
        Console.WriteLine("Channeling inner peace for a powerful strike!");
    }
}