namespace Jandaya.Services
{
    using System.Collections.Generic;

    public interface ICountryService
    {
        //IEnumerable<TViewModel> GetCountries<TViewModel>();

        IEnumerable<string> GetCountries();
    }
}
