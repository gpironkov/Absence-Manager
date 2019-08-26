namespace Jandaya.Controllers.Manager
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;

    public class ManagerController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("BookAbsence", "UserBookingAbsence");
        }

        public IActionResult BookingsInYourTeam()
        {
            return View();
        }
    }
}