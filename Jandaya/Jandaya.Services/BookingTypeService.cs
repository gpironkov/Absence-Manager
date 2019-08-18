namespace Jandaya.Services
{
    using Jandaya.Data;
    using Jandaya.Data.Models;
    using Jandaya.Data.Models.BindingModels;
    using Jandaya.Services.Interfaces;
    using System;
    using System.Threading.Tasks;

    public class BookingTypeService : IBookingTypeService
    {
        private readonly JandayaDbContext dbContext;

        public BookingTypeService(JandayaDbContext dbContext)
        {
            this.dbContext = dbContext;
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
    }
}
