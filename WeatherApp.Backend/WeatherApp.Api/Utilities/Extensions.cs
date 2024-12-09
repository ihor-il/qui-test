using Asp.Versioning;
using System.Runtime.CompilerServices;
using WeatherApp.Api.Abstract;
using WeatherApp.Api.Utilities;

namespace WeatherApp.Api.Utilities;

public static class Extensions
{
    public static IServiceCollection AddAPI(this IServiceCollection services, IWebHostEnvironment env)
    {
        return services
            .AddApiVersioning()
            .AddEndpointsApiExplorer()
            .AddSwaggerGen()
            .AddScoped<ISessionService, SessionService>()
            .AddHttpContextAccessor()
            .SetupCors(env)
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

    private static IServiceCollection SetupCors(this IServiceCollection services, IWebHostEnvironment env) 
    {
        if (!env.IsDevelopment()) return services;

        return services.AddCors(options =>
        {
            options.AddDefaultPolicy(builder =>
            {
                builder.AllowAnyMethod().AllowAnyOrigin().AllowAnyHeader();
            });
        });
    }
}
