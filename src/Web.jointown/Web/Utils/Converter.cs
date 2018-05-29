using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Utils
{
    
    public static  class Converter
    {
        public static dynamic ChangeType(dynamic source,Type desc)
        {
            return Convert.ChangeType(source, desc);
        }
    }
}
