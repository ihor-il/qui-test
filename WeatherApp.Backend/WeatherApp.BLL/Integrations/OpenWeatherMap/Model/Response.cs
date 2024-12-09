namespace WeatherApp.BLL.Integrations.OpenWeatherMap.Model;

internal class Response
{
    public Weather Main { get; set; } = new();
    public Wind Wind { get; set; } = new();
}
