using System.ComponentModel.DataAnnotations;
using Grocery.Infrastructure;

namespace Grocery.Business.Data;

public class WeatherForecast : IEntity<int>
{
    public int Id { get; set; }
    
    public DateTime Date { get; set; }
    
    public int TemperatureC { get; set; }
    
    [Required]
    [MaxLength(30)]
    public string? Summary { get; set; }
}