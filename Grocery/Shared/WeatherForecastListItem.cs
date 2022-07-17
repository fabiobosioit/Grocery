using System.ComponentModel.DataAnnotations;

namespace Grocery.Shared
{
    public class WeatherForecastListItem
    {
        public int Id { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime Date { get; set; }

        [Display(Name ="Temp (C)")]
        public int TemperatureC { get; set; }

        [Display(Name ="Temp (F)")]
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    }
}