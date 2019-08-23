namespace Jandaya.Controllers.Employee
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Jandaya.Common;
    using Jandaya.Data.Models.BindingModels;
    using Jandaya.Services.Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    //[Authorize(Roles = GlobalConstants.EmployeeRoleName)]
    public class UserBookingAbsenceController : Controller
    {
        private readonly IBookingService service;

        public UserBookingAbsenceController(IBookingService service)
        {
            this.service = service;
        }

        [Route("Home/Index")]
        public async Task<IActionResult> BookAbsence(string userId)
        {
            var currentResourceGroup = await this.service.GetCurrResourceGroupId();
            if (currentResourceGroup == null)
            {
                return RedirectToAction("NoResGroup", "NoResourceGroup");
            }

            var bookingData = await this.service.GetBookingDataFromModel(userId);

            return View(bookingData);
        }

        [HttpPost]
        public IActionResult BookAbsence(BookAbsenceBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.SelectMany(v => v.Errors).Select(error => error.ErrorMessage));
            }

            return View();
        }
    }
}