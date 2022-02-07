
namespace BlazorWebAssemblyDemo.Client.Repositories;

public interface ICountryRepository
{
    Task CreateCountryAsync(List<Country> countries);
    Task DeleteCountryAsync(int countryId);
    Task<IEnumerable<Country>> GetCountriesAsync();
    Task<Country> GetCountryAsync(int id);
    Task UpdateCountryAsync(Country country);
}