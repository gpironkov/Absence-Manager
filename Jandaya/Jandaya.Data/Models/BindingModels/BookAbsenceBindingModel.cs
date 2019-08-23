using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Jandaya.Data.Models.BindingModels
{
    public class BookAbsenceBindingModel
    {
        [Required]
        [Display(Name = "Type*")]
        public List<string> BookingTypes { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Start*")]
        public DateTime? StartDate { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "End*")]
        public DateTime? EndDate { get; set; }

        [MaxLength(300)]
        public string Comment { get; set; }

        [Display(Name = "Duration: ")]
        public int Duration { get; set; }

        [Display(Name = "Days Left: ")]
        public int DaysLeft { get; set; }

        [Display(Name = "Approver: ")]
        public string Approver { get; set; }
    }
}
