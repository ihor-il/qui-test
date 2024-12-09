namespace WeatherApp.BLL.Abstract;

internal interface IExternalWeatherService
{
    public Task<object?> GetWeatherDataAsync(string city, CancellationToken cancellationToken);
}
