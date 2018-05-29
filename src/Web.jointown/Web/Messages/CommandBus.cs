using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Commands;
using Web.Utils;

namespace Web.Messages
{
    public class CommandBus : IComandBus
    {
        private ICommandFactory _commandFactory;

        public CommandBus(ICommandFactory commandFactory)
        {
            _commandFactory = commandFactory;
        }
        public void Publish<T>(T command) where T : Command
        {
            var handler = _commandFactory.GetCommand<T>();
            handler.Execute(command);
        }
    }
}
