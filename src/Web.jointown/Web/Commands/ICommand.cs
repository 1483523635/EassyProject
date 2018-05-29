using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Commands
{
    public interface ICommand
    {
        long Id { get; }
    }
}
