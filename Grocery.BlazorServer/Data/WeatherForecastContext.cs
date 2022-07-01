using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace Grocery.BlazorServer.Data;

public class WeatherForecastContext: DbContext
{
    public WeatherForecastContext(DbContextOptions opt):base(opt){}
    
    // public DbSet<WeatherForecast>? WeatherForecasts { get; set; }
    // or
    public DbSet<WeatherForecast> WeatherForecasts => Set<WeatherForecast>();
}