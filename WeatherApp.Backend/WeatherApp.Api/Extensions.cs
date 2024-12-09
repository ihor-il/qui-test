using Asp.Versioning;

namespace WeatherApp.Api;

public static class Extensions
{
    public static IServiceCollection AddAPI(this IServiceCollection services)
    {
        return services
            .AddApiVersioning()
            .AddEndpointsApiExplorer()
            .AddSwaggerGen()
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
