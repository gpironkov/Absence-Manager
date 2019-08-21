namespace Jandaya.Data.Models.BindingModels
{
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class SetUserRoleBindingModel
    {
        [Display(Name = "User name")]
        public string FullName { get; set; }

        [Required]
        [Display(Name = "User role*")]
        public List<string> Roles { get; set; }

        public string CurrentUserRole { get; set; }
    }
}
