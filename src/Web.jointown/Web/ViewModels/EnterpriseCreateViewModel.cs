using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewModels
{
    public class EnterpriseCreateViewModel
    {
        [Key]
        [HiddenInput]
        public long Key { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        [DataType(DataType.MultilineText)] 
        public string EnterpriseIntroduce { get; set; }
        public EnterpriseCreateViewModel()
        {

        }
    }
}
