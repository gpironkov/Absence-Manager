namespace Jandaya.Data.Models
{
    using Jandaya.Data.Models.Common;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class ResourceGroup : BaseModel<string>
    {
        public ResourceGroup()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public List<User> Users { get; set; } = new List<User>();
    }
}
