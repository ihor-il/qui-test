using AutoMapper;
using WeatherApp.Domain;

namespace WeatherApp.BLL.Integrations.OpenWeatherMap.Utilities;

internal class OpenWeatherMapProfile: Profile
{
    public OpenWeatherMapProfile()
    {
        CreateMap<Model.Response, WeatherForecast>()
            .ForMember(x => x.City, opt => opt.MapFrom(x => x.Name))
            .ForMember(x => x.Temperature, opt => opt.MapFrom(x => x.Main.Temp))
            .ForMember(x => x.Pressure, opt => opt.MapFrom(x => x.Main.Pressure))
            .ForMember(x => x.Humidity, opt => opt.MapFrom(x => x.Main.Humidity))
            .ForMember(x => x.WindSpeed, opt => opt.MapFrom(x => x.Wind.Speed))
            .ForMember(x => x.WindDirection, opt => opt.MapFrom(x => x.Wind.Deg))
            .ForMember(x => x.WindGust, opt => opt.MapFrom(x => x.Wind.Gust));
    }
}
