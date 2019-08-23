namespace Jandaya.Data.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class GetNewBookingViewModel
    {
        [Required]
        [Display(Name = "Type*")]
        public List<string> BookingTypes { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public DateTime EndDate { get; set; }
    }
}
