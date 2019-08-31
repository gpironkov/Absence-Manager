namespace Jandaya.Data.Models.BindingModels
{
    using Jandaya.Common.Enumerations;
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ApproveBookingsBindingModel
    {
        [Display(Name = "User name")]
        public string FullName { get; set; }

        [Display(Name = "Type")]
        public string BookingType { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Start")]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "End")]
        public DateTime EndDate { get; set; }

        [Required]
        [EnumDataType(typeof(BookingStatus))]
        [Display(Name = "Status*")]
        public BookingStatus Status { get; set; }

        public string CurrentStatus { get; set; }
    }
}
