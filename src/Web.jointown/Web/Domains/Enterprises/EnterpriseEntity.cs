using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Events.Enterprise;
using Web.Infrastructure;
using Web.Infrastructure.Tools;
using Web.Events;
namespace Web.Domains
{
    public class EnterpriseEntity : AggrationRoot, IHandler<CreateItemEvent>
    {

        public string Name { get; set; }
        public string EnterpriseIntroduce { get; set; }
        public string Address { get; set; }
        public DateTime CreatTime { get; set; }
        public Status AdultStatus { get; set; }
        public string UserName { get; set; }

        public EnterpriseEntity()
        {
            CreatTime = DateTime.Now;
            AdultStatus = Status.UnAdult;
        }
        public EnterpriseEntity(long key, string name, string enterpriseIntroduce, string address, string userName) : this()
        {
            ApplyChange(new CreateItemEvent(key, name, enterpriseIntroduce, address, userName));
        }
        public void Handle(CreateItemEvent e)
        {
            Name = e.Name;
            EnterpriseIntroduce = e.Desc;
            Address = e.Address;
            UserName = e.UserName;
        }
    }
}
