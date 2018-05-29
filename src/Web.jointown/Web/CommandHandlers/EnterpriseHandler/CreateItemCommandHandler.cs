using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Commands.EnterprisesCommands;
using Web.Domains;
using Web.Infrastructure;
using Web.Storages;

namespace Web.CommandHandlers.EnterpriseHandler
{
    public class CreateItemCommandHandler : ICommandHandler<CreateItemCommand>
    {
        private IEventStorage _storage;

        public CreateItemCommandHandler(IEventStorage storage)
        {
            _storage = storage;
        }
        public void Execute(CreateItemCommand command)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));
            if (_storage == null)
                throw new InvalidOperationException($"the {nameof(_storage)} was not init");
            var aggregate = new EnterpriseEntity(command.Id, command.Name, command.EnterpriseIntroduce, command.Address, command.UserName);
            _storage.Save(aggregate);
        }
    }
}
