using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.EventHandlers;
using Web.Events;

namespace Web.Utils
{
    public interface IEventHandlerFactory
    {
        IEventHandler<T> GetHandler<T>() where T : Event;
    }
}
