namespace Jandaya.Models
{
    using AutoMapper;
    using Jandaya.Data.Models;
    using Jandaya.Services.Mapping;
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;

    public class UsersAllViewModel : IMapFrom<User>, IMapFrom<IdentityUserRole<string>>, IHaveCustomMappings,
        IMapFrom<Country> //, IMapFrom<ResourceGroup>
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string FullName { get; set; }

        public List<IdentityUserRole<string>> Roles { get; set; }

        public string Email { get; set; }

        public string Country { get; set; }

        public string ResourceGroup { get; set; }

        //var countryFromDb = dbContext.Countries.SingleOrDefault(s => s.Name == createUserModel.Country);

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<User, UsersAllViewModel>()
                .ForMember(
                    u => u.FullName,
                    opt => opt.MapFrom(u => $"{u.FirstName} {u.LastName}"))
                .ForMember(
                    c => c.Country,
                    opt => opt.MapFrom(c => $"{c.Country.Name}"))
                .ForMember(
                    rg => rg.ResourceGroup,
                    opt => opt.MapFrom(rg => $"{rg.ResourceGroup.Name}"));

            //configuration.CreateMap<ResourceGroup, UsersAllViewModel>()
            //    .ForMember(
            //        rg => rg.ResourceGroup,
            //        opt => opt.MapFrom(rg => $"{rg.Name}"));
        }
    }
}
