namespace Jandaya.Services.Interfaces
{
    using Jandaya.Data.Models;
    using Jandaya.Data.Models.BindingModels;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IBookingService
    {
        Task<Booking> GetBookingById(string id);

        Task<IEnumerable<TViewModel>> GetMyBookings<TViewModel>();

        Task<IEnumerable<TViewModel>> GetMyTeamBookings<TViewModel>();

        Task<bool> Create(BookAbsenceBindingModel bindingModel);

        Task<BookAbsenceBindingModel> GetBookingDataFromModel();

        Task<ApproveBookingsBindingModel> GetBookingForApprove(string id);

        Task<bool> AddNewBookingType(AddNewBookingTypeBindingModel bindingModel);

        Task<IEnumerable<string>> GetBookingTypes();        

        Task<string> GetCurrResourceGroupId();

        Task SetBookingStatus(string bookingId, ApproveBookingsBindingModel model);
    }
}
