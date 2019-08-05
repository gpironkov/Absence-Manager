namespace Jandaya.Data.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;

    public class CountriesRepository
    {
        private readonly JandayaDbContext context;

        public IEnumerable<SelectListItem> GetCountries()
        {           
            using (context)
            {
                var countries2 = context.Countries.Select(x => x.Name).ToList();
                //return countries;

                List<SelectListItem> countries = context.Countries.AsNoTracking()
                    .OrderBy(n => n.Name)
                        .Select(n =>
                        new SelectListItem
                        {
                            Value = n.Id.ToString(),
                            Text = n.Name
                        }).ToList();
                var countrytip = new SelectListItem()
                {
                    Value = null,
                    Text = "--- select country ---"
                };
                countries.Insert(0, countrytip);
                return new SelectList(countries, "Value", "Text");
            }
        }
    }
}
