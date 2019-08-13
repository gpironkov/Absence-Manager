namespace Jandaya.Data.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;

    using AutoMapper;
    using Jandaya.Data.Models;
    using Jandaya.Services.Mapping;
    using Microsoft.AspNetCore.Identity;

    public class UsersAllViewModel : IMapFrom<User>, IMapFrom<IdentityUserRole<string>>, 
        IMapFrom<Country>, IMapFrom<ResourceGroup>, IHaveCustomMappings
    {
        public string UserName { get; set; }

        public string FullName { get; set; }

        public IdentityUserRole<string> Roles { get; set; }

        public string Email { get; set; }

        public string Country { get; set; }

        public string ResourceGroup { get; set; }

        //var countryFromDb = dbContext.Countries.SingleOrDefault(s => s.Name == createUserModel.Country);

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<User, UsersAllViewModel>()
                .ForMember(
                    u => u.FullName,
                    opt => opt.MapFrom(u => $"{u.FirstName} {u.LastName}"));

            configuration.CreateMap<Country, UsersAllViewModel>()
                .ForMember(
                    c => c.Country,
                    opt => opt.MapFrom(c => $"{c.Name}"));

            configuration.CreateMap<ResourceGroup, UsersAllViewModel>()
                .ForMember(
                    rg => rg.ResourceGroup,
                    opt => opt.MapFrom(rg => $"{rg.Name}"));
        }
    }
}
