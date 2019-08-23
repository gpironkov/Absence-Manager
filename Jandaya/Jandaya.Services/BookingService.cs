namespace Jandaya.Services
{
    using Jandaya.Common;
    using Jandaya.Data;
    using Jandaya.Data.Models;
    using Jandaya.Data.Models.BindingModels;
    using Jandaya.Services.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class BookingService : IBookingService
    {
        private readonly JandayaDbContext dbContext;
        private readonly IUserServices userService;

        public BookingService(JandayaDbContext dbContext, IUserServices userService)
        {
            this.dbContext = dbContext;
            this.userService = userService;
        }

        public async Task<bool> AddNewBookingType(AddNewBookingTypeBindingModel bindingModel)
        {
            var name = bindingModel.Name;
            var isPaid = bindingModel.IsPaidTimeOff;
            var isSubtract = bindingModel.IsSubtractDaysLeft;

            var bookingType = new BookingType();

            bookingType.Name = name;
            bookingType.IsPaidTimeOff = isPaid;
            bookingType.IsSubtractDaysLeft = isSubtract;

            this.dbContext.BookingTypes.Add(bookingType);
            var result = await dbContext.SaveChangesAsync();

            return result > 0;
        }

        public async Task<BookAbsenceBindingModel> GetBookingDataFromModel(string userId)
        {
            var bookingTypes = await this.GetBookingTypes();

            var model = new BookAbsenceBindingModel();
            model.BookingTypes = bookingTypes.ToList();
            //var a = model.EndDate;
            //var b = model.StartDate;
            //model.Duration = Convert.ToInt32((a - b).TotalDays);

            model.Duration = 0;
            model.DaysLeft = await this.GetDaysLeft(userId);
            model.Approver = await this.GetApprover();

            return model;
        }

        public async Task<IEnumerable<string>> GetBookingTypes()
        {
            var bookingTypes = this.dbContext.BookingTypes.Select(x => x.Name).ToList();

            return bookingTypes;
        }

        private async Task<int> GetDaysLeft(string userId)
        {
            var currUserId = await this.userService.GetCurrentUserId();
            var user = await this.userService.GetUserById(currUserId);

            var daysLetft = user.DaysLeft;

            return daysLetft;
        }

        private async Task<string> GetApprover()
        {
            var managerRoleId = await this.userService.GetRoleIdByName(GlobalConstants.ManagerRoleName);
            //var managerIds = this.dbContext.UserRoles.Where(x => x.RoleId == managerRoleId).Select(x => x.UserId).ToList();

            var resourceGroup = await this.GetCurrResourceGroupId();

            User approver = this.dbContext.Users
                .Include(u => u.Roles)
                .Where(u => u.IsDeleted == false && u.Roles.Any(r => r.RoleId == managerRoleId))
                .Where(u => u.ResourceGroupId == resourceGroup)
                .SingleOrDefault();

            if (approver == null)
                return string.Empty;

            return $"{approver.FirstName}" + " " + $"{approver.LastName}";
        }

        public async Task<string> GetCurrResourceGroupId()
        {
            var currUserId = await this.userService.GetCurrentUserId();
            var user = await this.userService.GetUserById(currUserId);
            var resourceGroup = user.ResourceGroupId;

            return resourceGroup;
        }
    }
}
