using WeatherApp.Domain;

namespace WeatherApp.BLL.Abstract;

public interface IWeatherService
{
    public Task<WeatherForecast?> GetAsync(string city, CancellationToken cancellationToken);

}
