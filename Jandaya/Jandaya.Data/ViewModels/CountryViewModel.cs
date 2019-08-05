namespace Jandaya.Data.ViewModels
{
    using Jandaya.Data.Models;
    using System.Collections.Generic;

    public class CountryViewModel
    {
        public JandayaDbContext DbContext { get; set; }

        public CountryViewModel(JandayaDbContext dbContext)
        {
            this.DbContext = dbContext;
        }

        public int CountryId { get; set; }

        public string CountryName { get; set; }

        public List<Country> Countries { get; set; }
    }
}
