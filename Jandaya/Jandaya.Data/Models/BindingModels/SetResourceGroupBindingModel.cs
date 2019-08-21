namespace Jandaya.Data.Models.BindingModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class SetResourceGroupBindingModel
    {
        [Display(Name="User name")]
        public string FullName { get; set; }

        [Required]
        [Display(Name = "Resource group name*")]
        public List<string> Name { get; set; }
    }
}
