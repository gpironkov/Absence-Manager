namespace Jandaya.Services
{
    using Jandaya.Data;
    using Jandaya.Services.Mapping;
    using Microsoft.EntityFrameworkCore.Internal;
    using System.Collections.Generic;
    using System.Linq;

    public class CountryService : ICountryService
    {
        private readonly JandayaDbContext dbContext;

        public CountryService(JandayaDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<string> GetCountries()
        {
            var countries = this.dbContext.Countries.Select(x => x.Name).ToList();

            return countries;
        }

        //     public string GetCountryById(int id)
        //     {
        //         var countryId = this.dbContext.Users.Select(x => x.CountryId);
        //         var country = this.dbContext.Countries.Select(x => x.Name).Join(this.dbContext.Users u => u.)

        //     select name 
        //         from Country c
        //         join Users u on u.CountryId = c.Id
        //     }


        //public IEnumerable<TViewModel> GetCountries<TViewModel>()
        //{
        //    var countries = this.dbContext.Countries
        //        .OrderByDescending(x => x.Name)
        //        .To<TViewModel>()
        //        .ToList();

        //    return countries;
        //}
    }
}
