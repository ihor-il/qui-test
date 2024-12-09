using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WeatherApp.BLL.Abstract;
using WeatherApp.BLL.Integrations.OpenWeatherMap.Utilities;

namespace WeatherApp.BLL;

public static class Extensions
{
    public static IServiceCollection AddBLL(this IServiceCollection services, IConfiguration config)
    {
        return services
            .AddOpenWeatherMapIntegration(config)
            .AddScoped<IWeatherService, WeatherService>()
            .AddScoped<IWeatherHistoryService, WeatherService>();
    }
}
