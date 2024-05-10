using System;
using System.Collections.Generic;

namespace Tactical.Monopoly.Queries.EF.Models;

public partial class Player
{
    public Guid Id { get; set; }

    public Guid? BoardId { get; set; }

    public virtual ICollection<PlayerId> PlayerIds { get; set; } = new List<PlayerId>();
}
