using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Commands;

namespace Web.Messages
{
    public interface IComandBus
    {
        void Publish<T>(T commmand) where T : Command;
    }
}
