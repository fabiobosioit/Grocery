using System.ComponentModel.DataAnnotations;

namespace Grocery.Shared
{
    public class WeatherForecastListItem
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int TemperatureC { get; set; }
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    }
}