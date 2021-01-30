using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;

namespace Hahn.ApplicationProcess.December2020.Infrastructure.ExternalServices.RestCountries
{
    public interface ICountryService
    {
        Task<bool> CountryExists(string countryName);
    }

    public class CountryService : ICountryService
    {
        private readonly ICountryClient _countryClient;
        private IMemoryCache _countryCache;

        public CountryService(ICountryClient countryClient, IMemoryCache countryCache)
        {
            _countryClient = countryClient ?? throw new ArgumentNullException(nameof(countryClient));
            _countryCache = countryCache ?? throw new ArgumentNullException(nameof(countryCache));
        }

        public async Task<bool> CountryExists(string countryName)
        {
            // ToDo cash
            var response = await _countryClient.GetCountry(countryName);
            return response.IsSuccessStatusCode;
        }
    }
}