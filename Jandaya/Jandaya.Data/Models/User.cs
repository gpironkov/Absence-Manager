namespace Jandaya.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Jandaya.Data.Models.Common;

    using Microsoft.AspNetCore.Identity;

    public class User : IdentityUser, IAuditInfo, IDeletableEntity
    {
        public User()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Roles = new HashSet<IdentityUserRole<string>>();
        }

        // Audit info
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        // Deletable entity
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        public string ResourceGroupId { get; set; }

        public virtual ResourceGroup ResourceGroup { get; set; }

        public int CountryId { get; set; }

        public virtual Country Country { get; set; }

        public List<Booking> Bookings { get; set; } = new List<Booking>();

        [Range(0, int.MaxValue, ErrorMessage = "Days left can not be a negative number")]
        public int DaysLeft { get; set; }
    }
}