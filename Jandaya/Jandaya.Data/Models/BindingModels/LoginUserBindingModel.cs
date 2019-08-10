namespace Jandaya.Data.Models.BindingModels
{
    using System.ComponentModel.DataAnnotations;

    public class LoginUserBindingModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
