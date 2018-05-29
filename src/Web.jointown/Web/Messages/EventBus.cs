using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Events;
using Web.Utils;

namespace Web.Messages
{
    public class EventBus : IEventBus
    {
        private IEventHandlerFactory _eventHandlerFactory;

        public EventBus(IEventHandlerFactory eventHandlerFactory)
        {
            _eventHandlerFactory = eventHandlerFactory;
        }
        public void publish<T>(T @event) where T : Event
        {
            var handler = _eventHandlerFactory.GetHandler<T>();
            if (handler == null) throw new InvalidOperationException($"unRegister Handlers {nameof(T)}");
            handler.Handle(@event);
        }
    }
}
