using System.Net.Http;
using System.Threading.Tasks;
using Refit;

namespace Hahn.ApplicationProcess.December2020.Infrastructure.ExternalServices.RestCountries
{
    public interface ICountryClient
    {
        [Get("/name/{name}")]
        Task<ApiResponse<HttpResponseMessage>> GetCountry(string name);
    }
}