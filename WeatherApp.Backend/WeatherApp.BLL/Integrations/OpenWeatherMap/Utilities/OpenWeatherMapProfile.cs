using AutoMapper;
using WeatherApp.Domain;

namespace WeatherApp.BLL.Integrations.OpenWeatherMap.Utilities;

internal class OpenWeatherMapProfile: Profile
{
    public OpenWeatherMapProfile()
    {
        CreateMap<Model.Response, WeatherForecast>();
    }
}
