using WeatherApp.Domain;

namespace WeatherApp.BLL.Abstract;

internal interface IExternalWeatherService
{
    public Task<WeatherForecast?> GetWeatherDataAsync(string city, CancellationToken cancellationToken);
}
