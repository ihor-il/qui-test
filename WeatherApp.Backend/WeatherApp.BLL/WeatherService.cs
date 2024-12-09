using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using WeatherApp.BLL.Abstract;
using WeatherApp.BLL.Integrations;
using WeatherApp.DAL;
using WeatherApp.Domain;

namespace WeatherApp.BLL;

internal class WeatherService(
    IExternalWeatherService externalWeatherService,
    DataContext context,
    IMapper mapper
) : IWeatherService, IWeatherHistoryService
{
    public async Task<WeatherForecast?> GetAsync(string city, CancellationToken cancellationToken)
    {
        return await externalWeatherService.GetWeatherDataAsync(city, cancellationToken);
    }

    public async Task<IEnumerable<WeatherForecast>> GetHistoryAsync(Guid id, CancellationToken cancellationToken)
    {
        return await context.WeatherForecastRecords
            .Where(x => x.UserId == id)
            .OrderByDescending(x => x.RequestedAt)
            .ProjectTo<WeatherForecast>(mapper.ConfigurationProvider)
            .ToArrayAsync(cancellationToken);
    }

    public Task SaveForecastAsync(Guid id, WeatherForecast forecast, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
