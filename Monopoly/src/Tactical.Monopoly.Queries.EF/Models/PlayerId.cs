using System;
using System.Collections.Generic;

namespace Tactical.Monopoly.Queries.EF.Models;

public partial class PlayerId
{
    public long Id { get; set; }

    public Guid Value { get; set; }

    public short CellId { get; set; }

    public virtual Cell Cell { get; set; } = null!;

    public virtual Player ValueNavigation { get; set; } = null!;
}
