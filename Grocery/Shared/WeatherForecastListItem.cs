using Grocery.Infrastructure.Attributes;
using Grocery.Infrastructure.DataTypes;
using System.ComponentModel.DataAnnotations;

namespace Grocery.Shared
{
    public class WeatherForecastListItem : BaseListItemDetails<int>
    {
        //public int Id { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime Date { get; set; }

        [Display(Name ="Temp (C)")]
        public int TemperatureC { get; set; }

        [Hidden]
        [Display(Name ="Temp (F)")]
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    }
}