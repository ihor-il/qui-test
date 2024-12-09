using WeatherApp.Domain;

namespace WeatherApp.BLL.Abstract;

public interface IWeatherHistoryService
{
    public Task SaveForecastAsync(Guid id, WeatherForecast forecast, CancellationToken cancellationToken);
    public Task<IEnumerable<WeatherForecast>> GetHistoryAsync(Guid id, CancellationToken cancellationToken);
}
