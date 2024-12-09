namespace WeatherApp.BLL.Integrations.OpenWeatherMap.Utilities;

internal class OpenWeatherMapConfiguration
{
    public const string Section = "OpenWeatherMap";
    public const string BaseURL = "https://api.openweathermap.org/data/2.5/";
    public string ApiKey { get; set; } = string.Empty;
}
