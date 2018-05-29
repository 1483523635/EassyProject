using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Events;

namespace Web.Messages
{
    public interface IEventBus
    {
        void publish<T>(T @event) where T : Event;
    }
}
