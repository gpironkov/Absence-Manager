namespace Jandaya.Services
{
    using Jandaya.Common;
    using Jandaya.Data;
    using Jandaya.Data.Models;
    using Jandaya.Data.Models.BindingModels;
    using Jandaya.Services.Interfaces;
    using Jandaya.Services.Mapping;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class BookingService : IBookingService
    {
        private readonly JandayaDbContext dbContext;
        private readonly IUserServices userService;
        private readonly ICalendarService calendarService;
        private readonly ICountryService countryService;

        public BookingService(JandayaDbContext dbContext, IUserServices userService,
            ICalendarService calendarService, ICountryService countryService)
        {
            this.dbContext = dbContext;
            this.userService = userService;
            this.calendarService = calendarService;
            this.countryService = countryService;
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

        public async Task<BookAbsenceBindingModel> GetBookingDataFromModel()
        {
            var bookingTypes = await this.GetBookingTypes();

            var model = new BookAbsenceBindingModel();
            model.BookingTypes = bookingTypes.ToList();

            //model.Duration = 0;
            model.DaysLeft = await this.GetDaysLeft();
            model.Approver = await this.GetApprover();

            return model;
        }

        public async Task<IEnumerable<TViewModel>> GetMyTeamBookings<TViewModel>()
        {
            var currentUserId = await this.userService.GetCurrentUserId();
            var currentTeamUserIds = await this.userService.GetUserIdsByResGroupId(this.userService.GetResGroupId().ToString());

            var bookings = new List<TViewModel>();

            foreach (var item in currentTeamUserIds)
            {
                bookings = this.dbContext.Bookings
                .Include(u => u.User)
                .Include(u => u.BookingType)
                .Where(u => u.UserId == item)
                .OrderByDescending(u => u.CreatedOn)
                .To<TViewModel>()
                .ToList();
            }

            return bookings;
        }

        public async Task<IEnumerable<TViewModel>> GetMyBookings<TViewModel>()
        {
            var currentUserId = await this.userService.GetCurrentUserId();

            var bookings = this.dbContext.Bookings
                .Include(u => u.User)
                .Include(u => u.BookingType)
                .Where(u => u.UserId == currentUserId)
                .OrderByDescending(u => u.CreatedOn)
                .To<TViewModel>()
                .ToList();

            //foreach (var booking in bookings)
            //{
            //    var userName = await this.GetUserNameById(booking.User.Id);
            //}

            return bookings;
        }

        public Task<string> GetUserNameById(string userId)
        {
            var userRoleName = this.dbContext.Users
                .FirstOrDefault(u => u.Id == userId)
                .UserName;

            return Task.FromResult(userRoleName);
        }

        public Task<IEnumerable<string>> GetBookingTypes()
        {
            var bookingTypes = this.dbContext.BookingTypes.Select(x => x.Name).ToList();

            return Task.FromResult(bookingTypes.AsEnumerable());
        }

        public Task<string> GetBookingTypeIdByName(string typeName)
        {
            var bookingTypeId = this.dbContext.BookingTypes
                .FirstOrDefault(x => x.Name == typeName)
                .Id;

            return Task.FromResult(bookingTypeId);
        }

        private async Task<int> GetDaysLeft()
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

        private async void SetDurationAndDaysLeft(BookAbsenceBindingModel bindingModel, Booking booking)
        {
            var currUserId = await this.userService.GetCurrentUserId();
            var user = await this.userService.GetUserById(currUserId);

            var end = (DateTime)bindingModel.EndDate;
            var start = (DateTime)bindingModel.StartDate;
            //booking.Duration = Convert.ToInt32((a - b).TotalDays) + 2;

            var currHolidays = this.calendarService.GetHolidayDatesByCountryId(await this.countryService.GetCountryIdOfCurrUser());
            var countHolidays = currHolidays.Result.Count<DateTime>();

            var isSubtract = booking.BookingType.IsSubtractDaysLeft;

            if (countHolidays == 0)
            {
                if (!isSubtract)
                {
                    booking.Duration++;
                }
                else
                {
                    booking.Duration++;
                    user.DaysLeft--;
                }
            }

            while (start != end)
            {
                if (start.DayOfWeek != DayOfWeek.Saturday && start.DayOfWeek != DayOfWeek.Sunday)
                {
                    if (!isSubtract)
                    {
                        foreach (var holiday in await currHolidays)
                        {
                            if (start == holiday)
                            {
                                continue;
                            }
                        }

                        booking.Duration++;
                    }

                    else
                    {
                        foreach (var holiday in await currHolidays)
                        {
                            if (start == holiday)
                            {
                                continue;
                            }
                        }

                        booking.Duration++;
                        user.DaysLeft--;
                    }
                }

                start = start.AddDays(1);
            }
        }

        public async Task<bool> Create(BookAbsenceBindingModel bindingModel)
        {
            var currUserId = await this.userService.GetCurrentUserId();
            var user = await this.userService.GetUserById(currUserId);

            var booking = new Booking();

            booking.BookingType = await GetBookingTypeByName(bindingModel.BookingTypes.FirstOrDefault());

            booking.BookingTypeId = await GetBookingTypeIdByName(booking.BookingType.Name);
            booking.UserId = user.Id;
            booking.StartDate = (DateTime)bindingModel.StartDate;
            booking.EndDate = (DateTime)bindingModel.EndDate;

            SetDurationAndDaysLeft(bindingModel, booking);

            this.dbContext.Bookings.Add(booking);
            var result = await dbContext.SaveChangesAsync();

            var userFromDb = dbContext.Users.SingleOrDefault(u => u.Id == user.Id);
            userFromDb.DaysLeft = user.DaysLeft;
            this.dbContext.Users.Attach(userFromDb);
            this.dbContext.Entry(userFromDb).Property(x => x.DaysLeft).IsModified = true;

            result = await dbContext.SaveChangesAsync();

            return result > 0;
        }

        private Task<BookingType> GetBookingTypeByName(string bookingTypeName)
        {
            var bookingType = this.dbContext.BookingTypes
                .FirstOrDefault(x => x.Name == bookingTypeName);

            return Task.FromResult(bookingType);
        }
    }
}
