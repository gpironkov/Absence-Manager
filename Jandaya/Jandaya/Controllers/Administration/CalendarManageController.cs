namespace Jandaya.Controllers.Administration
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Jandaya.Data;
    using Jandaya.Data.Models.BindingModels;
    using Jandaya.Services;
    using Microsoft.AspNetCore.Mvc;

    public class CalendarManageController : AdminController
    {
        public ICalendarService CalendarService { get; }

        public CalendarManageController(ICalendarService calendarService)
        {
            this.CalendarService = calendarService;
        }

        public IActionResult CreateHoliday() => View();

        [HttpPost]
        public async Task<IActionResult> CreateHoliday(AddNewHolidayBindingModel bindingModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.SelectMany(v => v.Errors).Select(error => error.ErrorMessage));
            }

            await this.CalendarService.CreateHoliday(bindingModel);

            return Redirect("/");
        }
    }
}