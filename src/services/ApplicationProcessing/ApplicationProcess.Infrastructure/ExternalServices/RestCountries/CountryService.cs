using System;
using System.Threading.Tasks;
using ApplicationProcess.Application.Interfaces.ExternalServices;
using ApplicationProcess.Infrastructure.CacheManagement;

namespace ApplicationProcess.Infrastructure.ExternalServices.RestCountries
{
    public class CountryService : ICountryService
    {
        private readonly ICountryClient _countryClient;
        private readonly ICacheProvider _cacheProvider;

        public CountryService(ICountryClient countryClient, ICacheProvider cacheProvider)
        {
            _countryClient = countryClient ?? throw new ArgumentNullException(nameof(countryClient));
            _cacheProvider = cacheProvider ?? throw new ArgumentNullException(nameof(cacheProvider));
        }

        public async Task<bool> CountryExists(string countryName)
        {
            // ToDo Redis is better to multiple APIs
            var country = _cacheProvider.GetFromCache<Country>(countryName);
            if (country != null)
                return true;

            var response = await _countryClient.GetCountry(countryName);
            if (response.IsSuccessStatusCode)
            {
                _cacheProvider.SetValue(countryName, new Country() { Name = countryName });
                return true;
            }
            return false;
        }
    }
}