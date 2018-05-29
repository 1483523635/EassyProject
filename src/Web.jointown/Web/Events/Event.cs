using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Events
{
    public class Event : IEvent
    {
        public Guid ID { get; private set; }
        public long AggrationRootID { get; set; }
        public int Version { get; set; }
    }
}
