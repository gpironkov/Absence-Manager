using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Jandaya.Controllers.Employee
{
    public class NoResourceGroupController : Controller
    {
        //[Route("Home/Index")]
        public IActionResult NoResGroup()
        {
            return View();
        }
    }
}