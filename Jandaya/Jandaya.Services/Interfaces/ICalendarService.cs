namespace Jandaya.Services
{
    using Jandaya.Data.Models.BindingModels;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface ICalendarService
    {
        Task<bool> CreateHoliday(AddNewHolidayBindingModel bindingModel);

        Task<List<DateTime>> GetHolidayDatesByCountryId(int id);
    }
}
