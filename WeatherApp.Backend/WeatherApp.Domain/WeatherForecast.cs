namespace WeatherApp.Domain;

public class WeatherForecast
{
    public DateTimeOffset RequestedAt { get; set; }
    public string City { get; set; } = string.Empty;
    public double Temperature { get; set; }
    public int Pressure { get; set; }
    public int Humidity { get; set; }
    public double WindSpeed { get; set; }
    public double WindGust { get; set; }
    public int WindDirection { get; set; }
}
