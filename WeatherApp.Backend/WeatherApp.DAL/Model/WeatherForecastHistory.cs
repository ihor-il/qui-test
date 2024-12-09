using WeatherApp.Domain;

namespace WeatherApp.DAL.Model;

internal class WeatherForecastHistory
{
    public Guid UserId { get; set; }
    public WeatherForecast Forecast { get; set; } = default!;
}
