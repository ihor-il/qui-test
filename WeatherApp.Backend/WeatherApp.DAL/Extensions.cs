using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

namespace WeatherApp.DAL;

public static class Extensions
{
    public static IServiceCollection AddDAL(this IServiceCollection services, IConfiguration config)
    {
        return services
            .AddDbContext<DataContext>(opt => opt.UseSqlServer(config.GetConnectionString("Default")));
    }
}
