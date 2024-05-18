namespace Tactical.Monopoly.Queries.EF.Models;

public class BoardScore
{
    public long Id { get; set; }

    public int Score { get; set; }

    public Guid PlayerId { get; set; }

    public Guid BoardId { get; set; }

    public virtual Board Board { get; set; } = null!;
}
