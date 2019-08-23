namespace Jandaya.Services.Interfaces
{
    using Jandaya.Data.Models.BindingModels;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IBookingService
    {
        Task<bool> AddNewBookingType(AddNewBookingTypeBindingModel bindingModel);

        Task<IEnumerable<string>> GetBookingTypes();

        Task<BookAbsenceBindingModel> GetBookingDataFromModel(string userId);

        Task<string> GetCurrResourceGroupId();
    }
}
