namespace Jandaya.Data.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;

    using AutoMapper;
    using Jandaya.Data.Models;
    using Jandaya.Services.Mapping;

    public class UsersAllViewModel : IMapFrom<User> //, IHaveCustomMappings
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public Country Country { get; set; }

        public Guid RoleId { get; set; }

        public int ResourceGroupId { get; set; }

        // Create Mapping
    }
}
