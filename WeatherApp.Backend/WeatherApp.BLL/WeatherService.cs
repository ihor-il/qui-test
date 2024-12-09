using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using WeatherApp.BLL.Abstract;
using WeatherApp.DAL;
using WeatherApp.DAL.Model;
using WeatherApp.Domain;

namespace WeatherApp.BLL;

internal class WeatherService(
    IExternalWeatherService externalWeatherService,
    IMapper mapper,
    DataContext context
) : IWeatherService, IWeatherHistoryService
{
    public async Task<WeatherForecast?> GetAsync(string city, CancellationToken cancellationToken)
    {
        return await externalWeatherService.GetWeatherDataAsync(city, cancellationToken);
    }

    public async Task<IEnumerable<WeatherForecast>> GetHistoryAsync(Guid id, CancellationToken cancellationToken)
    {
        return await context.WeatherForecastHistoryRecords
            .Where(x => x.UserId == id)
            .OrderByDescending(x => x.RequestedAt)
            .ProjectTo<WeatherForecast>(mapper.ConfigurationProvider)
            .ToArrayAsync(cancellationToken);
    }

    public async Task SaveForecastAsync(Guid id, WeatherForecast forecast, CancellationToken cancellationToken)
    {
        var record = mapper.Map<WeatherForecastHistory>(forecast);

        record.Id = Guid.NewGuid();
        record.UserId = id;

        context.Add(record);
        await context.SaveChangesAsync(cancellationToken);
    }
}
