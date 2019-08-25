namespace Jandaya.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICountryService
    {
        //IEnumerable<TViewModel> GetCountries<TViewModel>();

        IEnumerable<string> GetCountries();

        Task<int> GetCountryIdOfCurrUser();
    }
}
