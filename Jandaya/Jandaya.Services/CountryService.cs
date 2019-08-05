namespace Jandaya.Services
{
    using Jandaya.Data;
    using Jandaya.Services.Mapping;
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

        public IEnumerable<int> GetCountryIds()
        {
            var ids = this.dbContext.Countries.Select(x => x.Id).ToList();

            return ids;
        }

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
