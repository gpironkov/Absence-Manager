namespace Jandaya.Data.ViewModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using AutoMapper;

    using Jandaya.Data.Models;
    using Jandaya.Services.Mapping;

    //using Jandaya.Common;

    public class CreateUserViewModel //: IMapFrom<User>
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public Country Country { get; set; }
    }
}
