using System.Net.Http;
using System.Threading.Tasks;
using Refit;

namespace ApplicationProcess.Infrastructure.ExternalServices.RestCountries
{
    public interface ICountryClient
    {
        [Get("/name/{name}")]
        Task<ApiResponse<HttpResponseMessage>> GetCountry(string name);
    }
}