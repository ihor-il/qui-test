using Asp.Versioning;
using WeatherApp.Api.Abstract;
using WeatherApp.Api.Utilities;

namespace WeatherApp.Api.Utilities;

public static class Extensions
{
    public static IServiceCollection AddAPI(this IServiceCollection services)
    {
        return services
            .AddApiVersioning()
            .AddEndpointsApiExplorer()
            .AddSwaggerGen()
            .AddScoped<ISessionService, SessionService>()
            .AddHttpContextAccessor()
            .AddControllers()
            .Services;
    }

    private static IServiceCollection AddApiVersioning(this IServiceCollection services)
    {
        return services.AddApiVersioning(options =>
        {
            options.DefaultApiVersion = new ApiVersion(1);
            options.ReportApiVersions = true;
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.ApiVersionReader = new UrlSegmentApiVersionReader();
        })
        .AddMvc()
        .AddApiExplorer(options =>
        {
            options.GroupNameFormat = "'v'V";
            options.SubstituteApiVersionInUrl = true;
        })
        .Services;
    }
}
