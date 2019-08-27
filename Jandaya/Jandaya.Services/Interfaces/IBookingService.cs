namespace Jandaya.Services.Interfaces
{
    using Jandaya.Data.Models.BindingModels;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IBookingService
    {
        Task<IEnumerable<TViewModel>> GetMyBookings<TViewModel>();

        Task<IEnumerable<TViewModel>> GetMyTeamBookings<TViewModel>();

        Task<bool> Create(BookAbsenceBindingModel bindingModel);

        Task<BookAbsenceBindingModel> GetBookingDataFromModel();

        Task<bool> AddNewBookingType(AddNewBookingTypeBindingModel bindingModel);

        Task<IEnumerable<string>> GetBookingTypes();        

        Task<string> GetCurrResourceGroupId();
    }
}
