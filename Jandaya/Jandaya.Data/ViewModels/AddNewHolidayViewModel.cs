namespace Jandaya.Data.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Jandaya.Data.Models;

    public class AddNewHolidayViewModel
    {
        [Required]
        [Display(Name = "Select country*")]
        public Country Country { get; set; }

        [Required]
        [Display(Name = "Choose date*")]
        //[DataType(DataType.Text)]
        public DateTime ChosenDate { get; set; }

        [Display(Name = "Holiday name")]
        public string HolidayName { get; set; }

        [Display(Name ="Public holiday")]
        public bool IsPublicHoliday { get; set; }
    }
}
