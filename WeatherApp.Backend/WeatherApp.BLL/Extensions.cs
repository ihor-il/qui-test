using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WeatherApp.BLL.Integrations;
using WeatherApp.BLL.Integrations.OpenWeatherMap;

namespace WeatherApp.BLL;

public static class Extensions
{
    public static IServiceCollection AddBLL(this IServiceCollection services, IConfiguration config)
    {
        return services
            .AddOpenWeatherMapIntegration(config)
            .AddScoped<IWeatherService, WeatherService>();
    }
}
