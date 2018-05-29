using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Domains;
using Web.Events.Enterprise;
using Web.Infrastructure;

namespace Web.EventHandlers.Enterprise
{
    public class CreateEventHandler : IEventHandler<CreateItemEvent>
    {
        private IRepository<EnterpriseEntity> _repository;

        public CreateEventHandler(IRepository<EnterpriseEntity> repository)
        {
            _repository = repository;
        }
       
        public void Handle(CreateItemEvent e)
        {
            var entity = new EnterpriseEntity()
            {
                Name = e.Name,
                UserName = e.UserName,
                Address = e.Address,
                EnterpriseIntroduce = e.Desc

            };
            _repository.Create(entity);
        }
    }
}
