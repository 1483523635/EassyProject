using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Commands;

namespace Web.CommandHandlers
{
    public interface ICommandHandler<TCommand> where TCommand : Command
    {
        void Execute(TCommand command);
    }
}
