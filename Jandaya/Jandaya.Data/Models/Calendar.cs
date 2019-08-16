namespace Jandaya.Data.Models
{
    using Jandaya.Data.Models.Common;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Calendar : BaseModel<string>
    {
        public Calendar()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        public DateTime ChosenDate { get; set; }

        [Required]
        public int CountryId { get; set; }

        public virtual Country Country { get; set; }

        public bool IsPublicHoliday { get; set; }

        public string HolidayName { get; set; }
    }
}
