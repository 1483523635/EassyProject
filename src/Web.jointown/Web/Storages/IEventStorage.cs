using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Domains;
using Web.Events;

namespace Web.Storages
{
    public interface IEventStorage
    {
        IEnumerable<Event> GetEvents(long AggrationKey);
        void Save(AggrationRoot aggretionRoot);

    }
}
