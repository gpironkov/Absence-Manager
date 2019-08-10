namespace Jandaya.Data.Models
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Identity;

    public class JandayaUserModel : IdentityUser
    {
        public JandayaUserModel()
        {
            this.Bookings = new HashSet<Booking>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<Booking> Bookings { get; set; }

        public ResourceGroup ResourceGroup { get; set; }

        public Country Country { get; set; }
    }
}
