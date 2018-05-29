using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Infrastructure.Tools
{
    public enum Status
    {
       [Display(Name ="未审核")]
       UnAdult,
       [Display(Name ="已通过")]
       Pass,
       [Display(Name ="已拒绝")]
       Deny
    }
}
