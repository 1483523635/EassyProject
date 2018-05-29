using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Web.Commands.EnterprisesCommands;
using Web.Datas;
using Web.Messages;
using Web.ViewModels;

namespace Web.Controllers
{
    public class EnterpriseController : Controller
    {
        private IComandBus _commandBus;

        public EnterpriseController(IComandBus commandBus)
        {
            _commandBus = commandBus;
        }


        // GET: Enterprise/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Enterprise/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Key,Name,Address,EnterpriseIntroduce")] EnterpriseCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                _commandBus.Publish(new CreateItemCommand(model.Key, model.Name, model.EnterpriseIntroduce, model.Address, User.Identity.Name));
            }
            return View(model);
        }

    }
}
