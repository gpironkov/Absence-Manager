namespace Jandaya.Services
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Jandaya.Data;
    using Jandaya.Data.Models;
    using Jandaya.Data.Models.BindingModels;

    public class CalendarService : ICalendarService
    {
        private readonly JandayaDbContext dbContext;

        public CalendarService(JandayaDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> CreateHoliday(AddNewHolidayBindingModel bindingModel)
        {
            //var country = bindingModel.Country;
            var chosenDate = bindingModel.ChosenDate;
            var holidayName = bindingModel.HolidayName;
            var isPublic = bindingModel.IsPublicHoliday;
            //var id = bindingModel.Id;

            var countryFromDb = dbContext.Countries.SingleOrDefault(s => s.Name == bindingModel.Country);

            var calendar = new Calendar();

            //calendar.Id = bindingModel.Id;
            calendar.CountryId = countryFromDb.Id;
            calendar.ChosenDate = chosenDate;
            calendar.HolidayName = holidayName;
            calendar.IsPublicHoliday = isPublic;            

            this.dbContext.Calendars.Add(calendar);
            int result = await this.dbContext.SaveChangesAsync();            

            return result > 0;
        }
    }
}
