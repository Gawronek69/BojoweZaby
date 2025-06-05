namespace BojoweZaby.Logic;
using BojoweZaby.Models;

public class WizardClass : FrogClassT
{
    public WizardClass()
    {
        ClassId = FrogClass.Mage;
        Name = "Wizard";
        BaseAttack = 25;
        BaseDefense = 3;
        BaseHP = 135;
        ImgPath = "static/zabson_w_pynie_mag.png"; // Path to the wizard image
    }

    public override void SpecialAbility()
    {
        Console.WriteLine("Casting a powerful spell!");
    }
}