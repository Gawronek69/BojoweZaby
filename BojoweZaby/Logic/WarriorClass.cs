namespace BojoweZaby.Logic;

using BojoweZaby.Models;

public class WarriorClass : FrogClassT
{
    public WarriorClass()
    {
        ClassId = FrogClass.Warrior;
        Name = "Warrior";
        BaseAttack = 15;
        BaseDefense = 7;
        BaseHP = 200;
        ImgPath = "static/zabson_w_pynie_rycerz.png"; // Path to the warrior image
    }

    public override void SpecialAbility()
    {
        Console.WriteLine("Unleashing a powerful strike!");
    }
}