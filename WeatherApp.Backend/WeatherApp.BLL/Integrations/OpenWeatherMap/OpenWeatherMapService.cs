using Microsoft.Extensions.Options;
using System.Net.Http.Json;
using WeatherApp.BLL.Abstract;
using WeatherApp.BLL.Integrations.OpenWeatherMap.Model;

namespace WeatherApp.BLL.Integrations.OpenWeatherMap;

internal class OpenWeatherMapService(
    IHttpClientFactory httpFactory,
    IOptions<OpenWeatherMapConfiguration> options
) : IExternalWeatherService
{
    public async Task<object> GetWeatherDataAsync(string city, CancellationToken cancellationToken)
    {
        var query = $"weather?q={city}&appid={options.Value.ApiKey}";
        using var client = httpFactory.CreateClient(nameof(OpenWeatherMapService));

        try
        {
            var result = await client.GetFromJsonAsync<Response>(query, cancellationToken);
            return result;
        }
        catch (HttpRequestException)
        {
            return null;
        }
    }
}
