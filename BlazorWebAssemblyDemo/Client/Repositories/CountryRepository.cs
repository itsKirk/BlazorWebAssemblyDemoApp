namespace BlazorWebAssemblyDemo.Client.Repositories;
public class CountryRepository : ICountryRepository
{
    private readonly IHttpService _httpService;
    private readonly string _url = "api/Countries";
    public CountryRepository(IHttpService httpService)
    {
        _httpService = httpService;
    }
    public async Task CreateCountryAsync(List<Country> countries)
    {
        var response = await _httpService.Post(_url, countries);
        if (!response.Success)
        {
            throw new ApplicationException(await response.GetBody());
        }
    }
    public async Task UpdateCountryAsync(Country country)
    {
        var response = await _httpService.Put($"{_url}/{country.Id}", country);
        if (!response.Success)
        {
            throw new ApplicationException(await response.GetBody());
        }
    }
    public async Task<IEnumerable<Country>> GetCountriesAsync()
    {
        var response = await _httpService.GetAll<IEnumerable<Country>>(_url);
        if (!response.Success)
        {
            throw new ApplicationException(await response.GetBody());
        }
        return response.Response;
    }
    public async Task<Country> GetCountryAsync(int id)
    {
        var response = await _httpService.Get<Country>($"{_url}/{id}");
        if (!response.Success)
        {
            throw new ApplicationException(await response.GetBody());
        }
        return response.Response;
    }
    public async Task DeleteCountryAsync(int countryId)
    {
        var response = await _httpService.Delete($"{_url}/{countryId}");
        if (!response.Success)
        {
            throw new ApplicationException(await response.GetBody());
        }
    }

}
