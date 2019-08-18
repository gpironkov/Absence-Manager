namespace Jandaya.Data.Models
{
    using Jandaya.Data.Models.Common;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class BookingType : BaseModel<string>
    {
        public BookingType()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public bool IsPaidTimeOff { get; set; }

        public bool IsSubtractDaysLeft { get; set; }

        public List<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
