using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Events;

namespace Web.EventHandlers
{
    public interface IEventHandler<TEvent> where TEvent : Event
    {
        void Handle(TEvent e);
    }
}
