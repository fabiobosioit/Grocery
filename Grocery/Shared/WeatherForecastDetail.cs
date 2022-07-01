using System.ComponentModel.DataAnnotations;

namespace Grocery.Shared;

public class WeatherForecastDetail
{
    public int Id { get; set; }
    public DateTime Date { get; set; }

    public int TemperatureC { get; set; }

    [Required]
    [MaxLength(30)]
    public string? Summary { get; set; }
}