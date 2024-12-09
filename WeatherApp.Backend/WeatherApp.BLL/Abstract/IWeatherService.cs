using WeatherApp.Domain;

namespace WeatherApp.BLL.Integrations;

public interface IWeatherService
{
    public Task<WeatherForecast?> GetAsync(string city, CancellationToken cancellationToken);

}
