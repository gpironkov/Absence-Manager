namespace Jandaya.Data.Models
{
    using Jandaya.Common.Enumerations;
    using Jandaya.Data.Models.Common;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Booking : BaseModel<string>
    {
        public Booking()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        public int BookingTypeId { get; set; }

        public virtual BookingType BookingType { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        public int Duration { get; set; }

        [MaxLength(300)]
        public string Comment { get; set; }
        //public BookingStatus Status { get; set; }
    }
}
