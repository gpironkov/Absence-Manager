namespace Jandaya.Services.Interfaces
{
    using Jandaya.Data.Models.BindingModels;
    using System.Threading.Tasks;

    public interface IBookingTypeService
    {
        Task<bool> AddNewBookingType(AddNewBookingTypeBindingModel bindingModel);
    }
}
