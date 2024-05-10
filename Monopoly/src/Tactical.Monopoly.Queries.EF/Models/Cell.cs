using System;
using System.Collections.Generic;

namespace Tactical.Monopoly.Queries.EF.Models;

public partial class Cell
{
    public short Id { get; set; }

    public Guid BoardId { get; set; }

    public string Name { get; set; } = null!;

    public short Position { get; set; }

    public int Group { get; set; }

    public short Price { get; set; }

    public bool Buyable { get; set; }

    public Guid OwnerId { get; set; }

    public int NumberOfHouse { get; set; }

    public bool Manufacturable { get; set; }

    public int PriceOfHouse { get; set; }

    public virtual Board Board { get; set; } = null!;

    public virtual ICollection<PlayerId> PlayerIds { get; set; } = new List<PlayerId>();
}
