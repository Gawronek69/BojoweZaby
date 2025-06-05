using BojoweZaby.Models;

namespace BojoweZaby.Logic;

public class Fight
{

    public static bool attackFrog(FrogModel attacker, FrogModel defender, AppDbContext _context)
    {
        int attackDamage = _context.frogPower(attacker);
        int frogDefence = _context.frogDefence(defender);

        defender.HP -= Math.Max(attackDamage - frogDefence, 0);

        if (defender.HP <= 0)
        {
            defender.HP = 0;
            defender.ImgPath = "static/zabson_w_pynie_dead.png"; 
            _context.SaveChanges();
            return true;
        }
        else
        {
            _context.SaveChanges();
            return false;
        }
    }
    
}