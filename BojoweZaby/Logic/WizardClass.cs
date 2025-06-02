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
    }

    public override void SpecialAbility()
    {
        Console.WriteLine("Casting a powerful spell!");
    }
}