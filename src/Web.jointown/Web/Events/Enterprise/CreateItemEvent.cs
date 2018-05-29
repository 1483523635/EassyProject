using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Infrastructure.Tools;

namespace Web.Events.Enterprise
{
    public class CreateItemEvent: Event
    {
        public string Name { get; set; }
        public string Desc { get; set; }
        public string Address { get; set; }
        public string UserName { get; set; }
        public CreateItemEvent(long aggrationRootId,string name,string desc,string address,string userName)
        {
            AggrationRootID = aggrationRootId;
            Name = name;
            Desc = desc;
            Address = address;
            UserName = userName;
        }
        public CreateItemEvent() { }
    }
}
