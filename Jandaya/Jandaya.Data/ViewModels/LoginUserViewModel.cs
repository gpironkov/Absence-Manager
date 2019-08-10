namespace Jandaya.Data.ViewModels
{
    using System.ComponentModel.DataAnnotations;
    using Jandaya.Data.Models;

    public class LoginUserViewModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
