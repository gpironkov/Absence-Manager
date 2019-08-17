namespace Jandaya.Data.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class AddNewResourceGroupViewModel
    {
        [Required]
        [MaxLength(100)]
        [Display(Name="Resource group name*")]
        public string Name { get; set; }
    }
}
