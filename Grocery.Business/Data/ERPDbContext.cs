using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace Grocery.Business.Data;

public class ERPDbContext: DbContext
{
    public ERPDbContext(DbContextOptions opt):base(opt){}
    
    // public DbSet<WeatherForecast>? WeatherForecasts { get; set; }
    // or
    public DbSet<WeatherForecast> WeatherForecasts => Set<WeatherForecast>();
}