using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.CommandHandlers;
using Web.Commands;

namespace Web.Utils
{
    public interface ICommandFactory
    {
        ICommandHandler<T> GetCommand<T>() where T : Command;
    }
}
