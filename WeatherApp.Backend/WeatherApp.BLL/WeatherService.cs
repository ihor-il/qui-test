using WeatherApp.BLL.Abstract;
using WeatherApp.BLL.Integrations;
using WeatherApp.Domain;

namespace WeatherApp.BLL;

internal class WeatherService(IExternalWeatherService externalWeatherService) : IWeatherService
{
    public async Task<WeatherForecast?> GetAsync(string city, CancellationToken cancellationToken)
    {
        return await externalWeatherService.GetWeatherDataAsync(city, cancellationToken);
    }

    public Task<IEnumerable<WeatherForecast>> GetHistoryAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
