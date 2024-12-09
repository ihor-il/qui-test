using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using WeatherApp.BLL.Integrations;
using WeatherApp.Domain;

namespace WeatherApp.Api.Controllers;

[ApiVersion(1)]
[ApiController]
[Route("api/v{v:apiVersion}")]
public class WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherService service) : ControllerBase
{
    [MapToApiVersion(1)]
    [HttpGet("search/{city:required}")]
    [ProducesResponseType<WeatherForecast>(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetWeatherAsync(string city, CancellationToken cancellationToken)
    {
        var result = await service.GetAsync(city, cancellationToken);
        if (result == null) return NotFound();

        return Ok(result);
    }

    [MapToApiVersion(1)]
    [HttpGet("history")]
    public Task<object> GetHistoryAsync()
    {
        throw new NotImplementedException();
    }
}
