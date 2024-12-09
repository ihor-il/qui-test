using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WeatherApp.BLL.Abstract;

namespace WeatherApp.BLL.Integrations.OpenWeatherMap;

internal static class Extensions
{
    public static IServiceCollection AddOpenWeatherMapIntegration(this IServiceCollection services, IConfiguration config)
    {
        return services
            .Configure<OpenWeatherMapConfiguration>(config.GetSection(OpenWeatherMapConfiguration.Section))
            .AddHttpClient<OpenWeatherMapService>(opt =>
            {
                opt.BaseAddress = new Uri(OpenWeatherMapConfiguration.BaseURL);
            })
            .Services
            .AddScoped<IExternalWeatherService, OpenWeatherMapService>();
    }
}
