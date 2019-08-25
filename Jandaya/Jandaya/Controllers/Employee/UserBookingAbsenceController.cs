namespace Jandaya.Controllers.Employee
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Jandaya.Common;
    using Jandaya.Data.Models.BindingModels;
    using Jandaya.Models;
    using Jandaya.Services.Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.EmployeeRoleName)]
    //[Route("/User/Login")]
    public class UserBookingAbsenceController : Controller
    {
        private readonly IBookingService service;

        public UserBookingAbsenceController(IBookingService service)
        {
            this.service = service;
        }

        [Route("Home/Index")]
        public async Task<IActionResult> BookAbsence()
        {
            var currentResourceGroup = await this.service.GetCurrResourceGroupId();
            if (currentResourceGroup == null)
            {
                return RedirectToAction("NoResGroup", "NoResourceGroup");
            }

            var bookingData = await this.service.GetBookingDataFromModel();

            return View(bookingData);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBooking(BookAbsenceBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.SelectMany(v => v.Errors).Select(error => error.ErrorMessage));
            }

            await this.service.Create(model);

            return this.RedirectToAction(nameof(this.GetMyBookings));
        }

        public async Task<IActionResult> GetMyBookings()
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.SelectMany(v => v.Errors).Select(error => error.ErrorMessage));
            }

            var bookings = await service.GetAllBookings<BookingsAllViewModel>();
            return this.View(bookings);
        }
    }
}