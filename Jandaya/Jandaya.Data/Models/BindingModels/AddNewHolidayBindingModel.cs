namespace Jandaya.Data.Models.BindingModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class AddNewHolidayBindingModel
    {
        public string Country { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public DateTime ChosenDate { get; set; }

        public string HolidayName { get; set; }

        public bool IsPublicHoliday { get; set; }
    }
}
