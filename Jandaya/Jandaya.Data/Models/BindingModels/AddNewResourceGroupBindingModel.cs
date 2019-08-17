using System;
namespace Jandaya.Data.Models.BindingModels
{
    using System.ComponentModel.DataAnnotations;

    public class AddNewResourceGroupBindingModel
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
