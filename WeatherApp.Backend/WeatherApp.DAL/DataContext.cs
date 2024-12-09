using Microsoft.EntityFrameworkCore;
using WeatherApp.DAL.Model;

namespace WeatherApp.DAL;

internal class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<WeatherForecastHistory> WeatherForecastHistoryRecords { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
    }
}
