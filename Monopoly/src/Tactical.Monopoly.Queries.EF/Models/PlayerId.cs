namespace Tactical.Monopoly.Queries.EF.Models;

public class PlayerId
{
    public long Id { get; set; }

    public Guid Value { get; set; }

    public short CellId { get; set; }

    public virtual Cell Cell { get; set; } = null!;

    //public virtual Player Player { get; set; } = null!;
}
