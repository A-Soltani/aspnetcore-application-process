using System.Net.Http;
using System.Threading.Tasks;
using Refit;

namespace Hahn.ApplicationProcess.December2020.Infrastructure.ExternalServices.RestCountries
{
    public interface ICountryClient
    {
        [Get("/name/{name}")]
        Task<HttpResponseMessage> GetCountry(string name);
    }
}