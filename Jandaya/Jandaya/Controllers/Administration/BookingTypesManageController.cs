namespace Jandaya.Controllers.Administration
{
    using System.Linq;
    using System.Threading.Tasks;
    using Jandaya.Data.Models.BindingModels;
    using Jandaya.Services.Interfaces;
    using Microsoft.AspNetCore.Mvc;

    public class BookingTypesManageController : AdminController
    {
        public IBookingTypeService BookingTypeService { get; }

        public BookingTypesManageController(IBookingTypeService bookingTypeService)
        {
            this.BookingTypeService = bookingTypeService;
        }

        public IActionResult BookingTypes() => View();

        [HttpPost]
        public async Task<IActionResult> BookingTypes(AddNewBookingTypeBindingModel bindinhModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.SelectMany(v => v.Errors).Select(error => error.ErrorMessage));
            }

            await this.BookingTypeService.AddNewBookingType(bindinhModel);

            return Redirect("/");
        }
    }
}