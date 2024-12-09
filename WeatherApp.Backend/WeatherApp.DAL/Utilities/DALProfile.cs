using AutoMapper;
using WeatherApp.DAL.Model;
using WeatherApp.Domain;

namespace WeatherApp.DAL.Utilities
{
    internal class DALProfile : Profile
    {
        public DALProfile()
        {
            CreateMap<WeatherForecast, WeatherForecastHistory>().ReverseMap();
        }
    }
}
