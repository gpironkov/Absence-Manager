using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Jandaya.Data.Models
{
    public class Calendar
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public DateTime ChosenDate { get; set; }

        [Required]
        public int CountryId { get; set; }

        public virtual Country Country { get; set; }

        public bool IsPublicHoliday { get; set; }

        public string HolidayName { get; set; }
    }
}
