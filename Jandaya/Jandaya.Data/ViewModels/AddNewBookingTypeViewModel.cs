namespace Jandaya.Data.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class AddNewBookingTypeViewModel
    {
        [Required]
        [MaxLength(50)]
        [Display(Name = "Name*")]
        public string Name { get; set; }

        [Display(Name = "Paid absence")]
        public bool IsPaidTimeOff { get; set; }

        [Display(Name = "Subtract days from annual leave?")]
        public bool IsSubtractDaysLeft { get; set; }
    }
}
