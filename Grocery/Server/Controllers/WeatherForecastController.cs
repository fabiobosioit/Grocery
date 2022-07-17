using Grocery.Business.Data;
using Grocery.Infrastructure;
using Grocery.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Grocery.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IRepository<WeatherForecast, int> _repository;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,
            IRepository<WeatherForecast, int> repository)
        {
            _logger = logger;
            this._repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<WeatherForecastListItem>> Get()
        {
            var result = await this._repository.GetAll()
                .Select(x => new WeatherForecastListItem()
                {
                    Id = x.Id, Date = x.Date, TemperatureC = x.TemperatureC
                }).ToListAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WeatherForecastDetail>> GetById(int id)
        {
            var entity = await this._repository.GetByIdAsync(id);
            if (entity == null) return NotFound();

            var result = new WeatherForecastDetail()
            {
                Id = entity.Id, Date = entity.Date, TemperatureC = entity.TemperatureC, Summary = entity.Summary
            };
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(WeatherForecastDetail model)
        {
            if (ModelState.IsValid)
            {
                var entity = new WeatherForecast()
                {
                    Id = model.Id,
                    Date = model.Date, Summary = model.Summary, TemperatureC = model.TemperatureC
                };
                await this._repository.CreateAsync(entity);
                return CreatedAtAction(nameof(GetById),
                    new { id = entity.Id } // the address where to access to read new data 
                    , entity); // return the created entity
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, WeatherForecastDetail model)
        {
            var entity = await this._repository.GetByIdAsync(id);
            if (entity == null) return NotFound();

            if (ModelState.IsValid)
            {
                entity.Date = model.Date;
                entity.Summary = model.Summary;
                entity.TemperatureC = model.TemperatureC;
                
                await this._repository.UpdateAsync(entity);

                // return Ok(entity);
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await this._repository.GetByIdAsync(id);
            if (entity == null) return NotFound();

            await this._repository.DeleteAsync(id);
            return NoContent();
        }

    }
    
}