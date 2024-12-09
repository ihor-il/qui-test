using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Domain;

namespace WeatherApp.BLL.Integrations.OpenWeatherMap.Model;

internal static class MappingExtensions
{
    public static WeatherForecast ToWeatherForecast(this Response response)
        => new()
        {
            City = response.Name,
            Temperature = response.Main.Temp,
            Pressure = response.Main.Pressure,
            Humidity = response.Main.Humidity,
            WindSpeed = response.Wind.Speed,
            WindDirection = response.Wind.Deg,
            WindGust = response.Wind.Gust,
            RequestedAt = DateTimeOffset.FromUnixTimeSeconds(response.Dt)
        };

}
