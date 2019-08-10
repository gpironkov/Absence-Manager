using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Jandaya.Controllers.Administration
{
    public class ResourceGroupsManageController : Controller
    {
        public IActionResult ResourceGroups()
        {
            return View();
        }
    }
}