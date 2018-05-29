using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Events
{
   
    public interface IHandler<TEvent> where TEvent : Event
    {
        void Handle(TEvent e);
    }
}
