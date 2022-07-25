using AutoMapper;
using Grocery.Business.Data;
using Grocery.Infrastructure;
using Grocery.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq.Expressions;

namespace Grocery.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController
        : CRUDController<WeatherForecastListItem, WeatherForedastDetails, int, WeatherForecast>
    {
        public WeatherForecastController(ILogger<WeatherForecastController> logger,
            IRepository<WeatherForecast, int> repository,
            IMapper mapper)
            : base(logger, repository, mapper) { }

        protected override Expression<Func<WeatherForecast, bool>>? ApplyFilter(string filterText)
        {
            return x=>x.Summary!=null && x.Summary.Contains(filterText);
        }
    }

}