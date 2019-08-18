namespace Jandaya.Data.Models.BindingModels
{
    using System.ComponentModel.DataAnnotations;

    public class AddNewBookingTypeBindingModel
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public bool IsPaidTimeOff { get; set; }

        public bool IsSubtractDaysLeft { get; set; }
    }
}
