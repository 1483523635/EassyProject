using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Commands
{
    public class Command: ICommand
    {
        public Command(long id)
        {
            Id = id;
        }

        public long Id { get; private set; }
    }
}
