namespace Jandaya.Services
{
    using Jandaya.Data.Models.BindingModels;
    using System.Threading.Tasks;

    public interface ICalendarService
    {
        Task<bool> CreateHoliday(AddNewHolidayBindingModel bindingModel);
    }
}
