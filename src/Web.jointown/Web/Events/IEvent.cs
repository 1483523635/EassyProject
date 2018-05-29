using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Events
{
    public interface IEvent
    {
        Guid ID { get; }
    }
}
