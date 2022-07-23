using Grocery.Infrastructure.DataTypes;
using System.ComponentModel.DataAnnotations;

namespace Grocery.Shared;

public class WeatherForedastDetails: BaseDetails<int>
{
    //public int Id { get; set; }
    public DateTime Date { get; set; }

    public int TemperatureC { get; set; }

    [Required]
    [MaxLength(30)]
    public string? Summary { get; set; }
}