using System.Threading.Tasks;

namespace ApplicationProcess.Application.Interfaces.ExternalServices
{
    public interface ICountryService
    {
        Task<bool> CountryExists(string countryName);
    }
}