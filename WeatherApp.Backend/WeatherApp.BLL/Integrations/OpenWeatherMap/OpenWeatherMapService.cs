using AutoMapper;
using Microsoft.Extensions.Options;
using System.Net.Http.Json;
using WeatherApp.BLL.Abstract;
using WeatherApp.BLL.Integrations.OpenWeatherMap.Model;
using WeatherApp.BLL.Integrations.OpenWeatherMap.Utilities;
using WeatherApp.Domain;

namespace WeatherApp.BLL.Integrations.OpenWeatherMap;

internal class OpenWeatherMapService(
    IHttpClientFactory httpFactory,
    IOptions<OpenWeatherMapConfiguration> options,
    IMapper mapper
) : IExternalWeatherService
{
    public async Task<WeatherForecast?> GetWeatherDataAsync(string city, CancellationToken cancellationToken)
    {
        var query = $"weather?q={city}&appid={options.Value.ApiKey}&units=metric";
        using var client = httpFactory.CreateClient(nameof(OpenWeatherMapService));

        try
        {
            var response = await client.GetFromJsonAsync<Response>(query, cancellationToken);
            var result = mapper.Map<WeatherForecast>(response);
            result.RequestedAt = DateTime.UtcNow;
            return result;
        }
        catch (HttpRequestException)
        {
            return null;
        }
    }
}
