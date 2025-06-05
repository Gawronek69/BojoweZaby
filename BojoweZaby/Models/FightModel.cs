using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using BojoweZaby.Models;

namespace BojoweZaby.Models;
public class FightModel
{
    [Key]
    public int Id { get; set; }

    public int Frog1Id { get; set; }
    public int Frog2Id { get; set; }

    public FrogModel? Frog1 { get; set; }
    [ForeignKey(nameof(Frog2Id))]
    public FrogModel? Frog2 { get; set; }
    public FightModel() { }
    public FightModel(int id, int frog1Id, int frog2Id, FrogModel? frog1, FrogModel? frog2)
    {
        Id = id;
        Frog1Id = frog1Id;
        Frog2Id = frog2Id;
        Frog1 = frog1;
        Frog2 = frog2;
    }
}