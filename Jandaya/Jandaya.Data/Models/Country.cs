namespace Jandaya.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class Country
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public List<User> Users { get; set; } = new List<User>();

        public List<Calendar> Calendars { get; set; } = new List<Calendar>();
    }
}
