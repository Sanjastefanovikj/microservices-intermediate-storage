using System;

namespace MicroservicesIntermediateStorage.Events
{
    public interface IEvent
    {
        Guid EventId { get; }
        DateTime OccurredAt { get; }
    }
}
