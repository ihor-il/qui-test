using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using WeatherApp.Api.Abstract;
using WeatherApp.Api.Utilities;
using WeatherApp.BLL.Abstract;
using WeatherApp.Domain;

namespace WeatherApp.Api.Controllers;

[ApiVersion(1)]
[ApiController]
[Route("api/v{v:apiVersion}")]
public class WeatherForecastController(IWeatherService service, IWeatherHistoryService historyService, ISessionService session) : ControllerBase
{
    [MapToApiVersion(1)]
    [HttpGet("search/{city:required}")]
    [ProducesResponseType<WeatherForecast>(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetWeatherAsync(string city, CancellationToken cancellationToken)
    {
        var result = await service.GetAsync(city, cancellationToken);
        if (result == null) return NotFound();

        var sessionId = session.CreateSession();

        await historyService.SaveForecastAsync(sessionId, result, cancellationToken);
        return Ok(result);
    }

    [MapToApiVersion(1)]
    [HttpGet("history")]
    public async Task<IEnumerable<WeatherForecast>> GetHistoryAsync(CancellationToken cancellationToken)
    {
        var sessionId = session.CreateSession();
        return await historyService.GetHistoryAsync(sessionId, cancellationToken);
    }
}
