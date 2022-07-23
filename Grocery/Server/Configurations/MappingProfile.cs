using AutoMapper;
using Grocery.Business.Data;
using Grocery.Shared;

namespace Grocery.Server.Configurations
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<WeatherForecast, WeatherForecastListItem>();

            CreateMap<WeatherForecast, WeatherForedastDetails>()
                .ReverseMap();

        }
    }
}
