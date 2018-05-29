using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Web.Events;
using Web.Utils;

namespace Web.Domains
{
    public class AggrationRoot : IEventProvider
    {
        private List<Event> _changes;

        [Key]
        public long Key { get; set; }

        protected AggrationRoot()
        {
            _changes = new List<Event>();
        }

        public void LoadFromHistory(IEnumerable<Event> history)
        {
            foreach (var e in history)
            {
                ApplyChange(e, false);
            }
        }


        public IEnumerable<Event> GetUnCommitChanges()
        {
            return _changes;
        }
        public void MarkChangesAsCommitted()
        {
            _changes.Clear();
        }

        protected void ApplyChange(Event @event)
        {
            ApplyChange(@event, true);
        }

        private void ApplyChange(Event @event, bool isNew)
        {
            dynamic d = this;
            d.Handle(Converter.ChangeType(@event, @event.GetType()));
            if (isNew)
            {
                _changes.Add(@event);
            }
        }
    }
}
