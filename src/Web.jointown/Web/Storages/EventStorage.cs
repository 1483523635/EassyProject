using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Domains;
using Web.Events;
using Web.Messages;
using Web.Utils;

namespace Web.Storages
{
    public class EventStorage : IEventStorage
    {
        private IEventBus _eventBus;
        private List<Event> _events;

        public EventStorage(IEventBus eventBus)
        {
            _eventBus = eventBus;
            _events = new List<Event>();
        }

        public IEnumerable<Event> GetEvents(long AggrationKey)
        {
            var events = _events.Where(e => e.AggrationRootID.Equals(AggrationKey)).ToList();
            if (events.Count == 0) throw new Exception($"the AggrationKey was not found,{AggrationKey}");
            return events;
        }

        public void Save(AggrationRoot aggretionRoot)
        {
            var unCommitChanges = aggretionRoot.GetUnCommitChanges();
            foreach (var @event in unCommitChanges)
            {
                _events.Add(@event);
            }
            foreach (var @event in unCommitChanges)
            {
                dynamic desEvent = Converter.ChangeType(@event, @event.GetType());
                _eventBus.publish(desEvent);
            }
        }
    }
}
