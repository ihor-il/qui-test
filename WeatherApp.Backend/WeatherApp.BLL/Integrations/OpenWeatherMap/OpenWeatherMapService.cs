using Microsoft.Extensions.Options;
using System.Net.Http.Json;
using WeatherApp.BLL.Abstract;
using WeatherApp.BLL.Integrations.OpenWeatherMap.Model;
using WeatherApp.Domain;

namespace WeatherApp.BLL.Integrations.OpenWeatherMap;

internal class OpenWeatherMapService(
    IHttpClientFactory httpFactory,
    IOptions<OpenWeatherMapConfiguration> options
) : IExternalWeatherService
{
    public async Task<WeatherForecast?> GetWeatherDataAsync(string city, CancellationToken cancellationToken)
    {
        var query = $"weather?q={city}&appid={options.Value.ApiKey}&units=metric";
        using var client = httpFactory.CreateClient(nameof(OpenWeatherMapService));

        try
        {
            var response = await client.GetFromJsonAsync<Response>(query, cancellationToken);
            return response?.ToWeatherForecast();
        }
        catch (HttpRequestException)
        {
            return null;
        }
    }
}
