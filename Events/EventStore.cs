using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MicroservicesIntermediateStorage.Events;

namespace MicroservicesIntermediateStorage.Events
{
    public interface IEventStore
    {
        Task SaveEventAsync(IEvent @event);
        Task<IEnumerable<IEvent>> GetEventsAsync(Guid aggregateId);
    }

    public class InMemoryEventStore : IEventStore
    {
        private readonly Dictionary<Guid, List<IEvent>> _eventStorage = new();

        public Task SaveEventAsync(IEvent @event)
        {
            if (!_eventStorage.ContainsKey(@event.EventId))
            {
                _eventStorage[@event.EventId] = new List<IEvent>();
            }
            _eventStorage[@event.EventId].Add(@event);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<IEvent>> GetEventsAsync(Guid aggregateId)
        {
            _eventStorage.TryGetValue(aggregateId, out var events);
            return Task.FromResult((IEnumerable<IEvent>)(events ?? new List<IEvent>()));
        }
    }
}
