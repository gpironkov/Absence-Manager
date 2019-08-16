namespace Jandaya.Data.Models.BindingModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class AddNewHolidayBindingModel
    {
        public string Country { get; set; }

        public DateTime ChosenDate { get; set; }

        //public int Id { get; set; }

        public string HolidayName { get; set; }

        public bool IsPublicHoliday { get; set; }
    }
}
