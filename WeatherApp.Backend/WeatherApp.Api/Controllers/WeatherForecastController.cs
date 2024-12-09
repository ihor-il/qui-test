using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace WeatherApp.Api.Controllers;

[ApiVersion(1)]
[ApiController]
[Route("api/v{v:apiVersion}")]
public class WeatherForecastController(ILogger<WeatherForecastController> logger) : ControllerBase
{
    [MapToApiVersion(1)]
    [HttpGet("search/{city:required}")]
    public Task<object> GetWeatherAsync(string city)
    {
        throw new NotImplementedException();
    }

    [MapToApiVersion(1)]
    [HttpGet("history")]
    public Task<object> GetHistoryAsync()
    {
        throw new NotImplementedException();
    }
}
