using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WeatherApp.DAL.Model;

public class WeatherForecastHistory
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public DateTimeOffset RequestedAt { get; set; }
    public string City { get; set; } = string.Empty;
    public double Temperature { get; set; }
    public int Pressure { get; set; }
    public int Humidity { get; set; }
    public double WindSpeed { get; set; }
    public double WindGust { get; set; }
    public int WindDirection { get; set; }

    private class WeatherForecastHistoryConfiguration : IEntityTypeConfiguration<WeatherForecastHistory>
    {
        public void Configure(EntityTypeBuilder<WeatherForecastHistory> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.UserId);
        }
    }
}
