using System.ComponentModel.DataAnnotations.Schema;
using BojoweZaby.Models;
public class FightModel
{
    public int Id { get; set; }

    public int Account1Id { get; set; }

    public int Account2Id { get; set; }

    public int Frog1Id { get; set; }
    public int Frog2Id { get; set; }

    public int WinnerId { get; set; }


    [ForeignKey(nameof(Account1Id))]
    public AccountModel? Account1 { get; set; }
    [ForeignKey(nameof(Account2Id))]
    public AccountModel? Account2 { get; set; }
    [ForeignKey(nameof(Frog1Id))]
    public FrogModel? Frog1 { get; set; }
    [ForeignKey(nameof(Frog2Id))]
    public FrogModel? Frog2 { get; set; }
    public int Round { get; set; } = 0;

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