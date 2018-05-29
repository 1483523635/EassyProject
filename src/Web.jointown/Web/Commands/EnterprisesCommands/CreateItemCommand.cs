using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Commands.EnterprisesCommands
{
    public class CreateItemCommand : Command
    {
        public string Name { get; set; }
        public string EnterpriseIntroduce { get; set; }
        public string Address { get; set; }
        public string UserName { get; set; }
        public CreateItemCommand(long aggrationRootId, string name,
                                 string enterpirseIntroduce, string address,
                                 string userName) : base(aggrationRootId)
        {
            Name = name;
            EnterpriseIntroduce = enterpirseIntroduce;
            Address = address;
            UserName = userName;
        } 

    }
}
