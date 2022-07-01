using System.ComponentModel.DataAnnotations;
using Grocery.UI.Services;

namespace Grocery.BlazorServer.Data;

public class WeatherForecast
{
    public int Id { get; set; }
    
    public DateTime Date { get; set; }
    
    public int TemperatureC { get; set; }
    
    [Required]
    [MaxLength(30)]
    public string? Summary { get; set; }
}