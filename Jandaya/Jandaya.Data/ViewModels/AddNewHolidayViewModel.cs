using Jandaya.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Jandaya.Data.ViewModels
{
    public class AddNewHolidayViewModel
    {
        [Display(Name = "Select Country")]
        public Country Country { get; set; }
    }
}
