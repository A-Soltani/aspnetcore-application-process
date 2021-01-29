using System;
using System.Threading.Tasks;

namespace Hahn.ApplicationProcess.December2020.Infrastructure.ExternalServices.RestCountries
{
    public interface ICountryService
    {
        Task<bool> CountryExists(string countryName);
    }

    public class CountryService : ICountryService
    {
        private readonly ICountryClient _countryClient;

        public CountryService(ICountryClient countryClient) =>
            _countryClient = countryClient ?? throw new ArgumentNullException(nameof(countryClient));

        public async Task<bool> CountryExists(string countryName)
        {
            var response = await _countryClient.GetCountry(countryName);
            return response.IsSuccessStatusCode;
        }
    }
}