namespace Jandaya.Controllers.Manager
{
    using Jandaya.Services.Interfaces;
    using Jandaya.Models;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;
    using System.Threading.Tasks;
    using Jandaya.Common;
    using Microsoft.AspNetCore.Authorization;
    using Jandaya.Data.Models.BindingModels;

    [Authorize(Roles = GlobalConstants.ManagerRoleName)]
    public class ManagerController : Controller
    {
        private readonly IBookingService service;

        public ManagerController(IBookingService service)
        {
            this.service = service;
        }

        public IActionResult Index()
        {
            return RedirectToAction("BookAbsence", "UserBookingAbsence");
        }

        public async Task<IActionResult> BookingsInYourTeam()
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.SelectMany(v => v.Errors).Select(error => error.ErrorMessage));
            }

            var bookings = await service.GetMyTeamBookings<BookingsAllViewModel>();
            return this.View(bookings);
        }

        public async Task<IActionResult> ApproveBookings(string id)
        {
            var bookingsForApprove = await this.service.GetBookingForApprove(id);

            return this.View(bookingsForApprove);
        }

        [HttpPost]
        public async Task<IActionResult> ApproveBookings(ApproveBookingsBindingModel model, string id)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.SelectMany(v => v.Errors).Select(error => error.ErrorMessage));
            }

            await this.service.SetBookingStatus(id, model);

            return RedirectToAction(nameof(this.BookingsInYourTeam));
        }
    }
}