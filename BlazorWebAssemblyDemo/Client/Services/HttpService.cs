namespace BlazorWebAssemblyDemo.Client.Services;
public class HttpService : IHttpService
{
    private readonly HttpClient _httpClient;
    private readonly JsonSerializerOptions _defaultSerializerOptions;

    public HttpService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _defaultSerializerOptions = new() { PropertyNameCaseInsensitive = true };
    }
    public async Task<HttpMessenger<object>> Post<T>(string url, T data)
    {
        var jsonData = JsonSerializer.Serialize(data);
        StringContent stringContent = new(jsonData, Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync(url, stringContent);
        return new HttpMessenger<object>(null, response.IsSuccessStatusCode, response);
    }
    public async Task<HttpMessenger<object>> Put<T>(string url, T data)
    {
        var jsonData = JsonSerializer.Serialize(data);
        StringContent stringContent = new(jsonData, Encoding.UTF8, "application/json");
        var response = await _httpClient.PutAsync(url, stringContent);
        return new HttpMessenger<object>(null, response.IsSuccessStatusCode, response);
    }
    public async Task<HttpMessenger<T>> GetAll<T>(string url)
    {
        var responseHttp = await _httpClient.GetAsync(url);
        if (responseHttp.IsSuccessStatusCode)
        {
            var response = await Deserialize<T>(responseHttp, _defaultSerializerOptions);
            return new HttpMessenger<T>(response, true, responseHttp);
        }
        else
        {
            return new HttpMessenger<T>(default, false, responseHttp);
        }
    }
    public async Task<HttpMessenger<T>> Get<T>(string url)
    {
        var responseHttp = await _httpClient.GetAsync(url);
        if (responseHttp.IsSuccessStatusCode)
        {
            var response = await Deserialize<T>(responseHttp, _defaultSerializerOptions);
            return new HttpMessenger<T>(response, true, responseHttp);
        }
        else
        {
            return new HttpMessenger<T>(default, false, responseHttp);
        }
    }
    private static async Task<T> Deserialize<T>(HttpResponseMessage responseHttp, JsonSerializerOptions options)
    {
        var responseString = await responseHttp.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<T>(responseString, options);
    }
    public async Task<HttpMessenger<object>> Delete(string url)
    {
        var responseHTTP = await _httpClient.DeleteAsync(url);
        return new HttpMessenger<object>(null, responseHTTP.IsSuccessStatusCode, responseHTTP);
    }

}

