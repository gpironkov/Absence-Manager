namespace Jandaya.Tests
{
    using Jandaya.Data;
    using Jandaya.Data.Models;
    using Jandaya.Services;

    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Xunit;

    public class CountryTests
    {
        public async Task<JandayaDbContext> GetDbContext()
        {
            var countries = new List<Country>
            {
                new Country { Name = "Albania"},
                new Country { Name = "Bulgaria"},
                new Country { Name = "Germany"}
            };

            var optionsBuilder = new DbContextOptionsBuilder<JandayaDbContext>()
                                    .UseInMemoryDatabase(Guid.NewGuid().ToString());
            var dbContext = new JandayaDbContext(optionsBuilder.Options);

            foreach (var country in countries)
            {
                await dbContext.Countries.AddAsync(country);
            }

            await dbContext.SaveChangesAsync();
            return dbContext;
        }

        [Fact]
        public async Task GetCountriesShouldVerifyThatContainsSomeCountries()
        {
            var dbContext = await this.GetDbContext();
            var service = new CountryService(dbContext);
            var result = service.GetCountries();


            Assert.All(result, item => Assert.Contains("Albania", item));
            Assert.All(result, item => Assert.Contains("Bulgaria", item));
            Assert.All(result, item => Assert.Contains("Germany", item));

            //foreach (var item in result)
            //{
            //    Assert.Contains("Albania", item);
            //    Assert.Contains("Bulgaria", item);
            //    Assert.Contains("Germany", item);
            //}
        }
    }
}
