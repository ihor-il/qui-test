using Microsoft.EntityFrameworkCore;
using WeatherApp.DAL.Model;

namespace WeatherApp.DAL;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<WeatherForecastHistory> WeatherForecastRecords { get; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
    }
}
