namespace Jandaya.ViewComponents
{
    using Microsoft.AspNetCore.Mvc;
    using Jandaya.Services;
    using System.Collections.Generic;

    public class CountriesViewComponent : ViewComponent
    {
        private readonly ICountryService countryService;

        public CountriesViewComponent(ICountryService countryService)
        {
            this.countryService = countryService;
        }

        public IViewComponentResult Invoke()
        {
            return this.View(new CountryViewComponentViewModel
            {
                Name = countryService.GetCountries()
            });
        }
    }

    public class CountryViewComponentViewModel
    {
        //public int Id { get; set; }

        public IEnumerable<string> Name { get; set; }
    }
}
