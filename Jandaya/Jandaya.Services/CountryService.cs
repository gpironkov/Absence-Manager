namespace Jandaya.Services
{
    using Jandaya.Data;
    using Jandaya.Services.Mapping;
    using Microsoft.EntityFrameworkCore.Internal;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class CountryService : ICountryService
    {
        private readonly JandayaDbContext dbContext;
        private readonly IUserServices userService;

        public CountryService(JandayaDbContext dbContext, IUserServices userService)
        {
            this.dbContext = dbContext;
            this.userService = userService;
        }

        public IEnumerable<string> GetCountries()
        {
            var countries = this.dbContext.Countries.Select(x => x.Name).ToList();

            return countries;
        }

        public async Task<int> GetCountryIdOfCurrUser()
        {
            var currUserId = await this.userService.GetCurrentUserId();
            var user = await this.userService.GetUserById(currUserId);

            var countryId = user.CountryId;

            return countryId;
        }
    }
}
