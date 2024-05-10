using System;

namespace Tactical.Framework.Core.Abstractions;

public interface IEvent
{
    public DateTime? PublishedOn { get; set; }
}
