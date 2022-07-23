using AutoMapper;
using AutoMapper.QueryableExtensions;
using Grocery.Infrastructure;
using Grocery.Infrastructure.DataTypes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Grocery.Server.Controllers
{
    [ApiController]
    // [Route("[controller]")]
    public class CRUDController<ListItemType, DetailsType, IdType, EntityType> : ControllerBase
        where ListItemType : BaseListItemDetails<IdType>
        where DetailsType : BaseDetails<IdType>
        where EntityType : class, IEntity<IdType>, new()
    {
        
        protected readonly ILogger<CRUDController<ListItemType, DetailsType, IdType, EntityType>> _logger;
        protected readonly IRepository<EntityType, IdType> _repository;
        protected readonly IMapper _mapper;

        public CRUDController(ILogger<CRUDController<ListItemType, DetailsType, IdType, EntityType>> logger,
            IRepository<EntityType, IdType> repository,
            IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public virtual async Task<ActionResult<ListItemType>> Get()
        {
            var result = await _repository.GetAll()
                .ProjectTo<ListItemType>(_mapper.ConfigurationProvider)
                .ToListAsync();
                //.Select(x => new WeatherForecastListItem ()
                //{
                //    Id = x.Id, Date = x.Date, TemperatureC = x.TemperatureC
                //}).ToListAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public virtual async Task<ActionResult<DetailsType>> GetById(IdType id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return NotFound();

            var result = _mapper.Map<DetailsType>(entity);
            /*
            new WeatherForedastDetails()
            {
                Id = entity.Id, Date = entity.Date, TemperatureC = entity.TemperatureC, Summary = entity.Summary
            };*/
            return Ok(result);
        }

        [HttpPost]
        public virtual async Task<IActionResult> Post(DetailsType model)
        {
            if (ModelState.IsValid)
            {
                var entity = _mapper.Map<EntityType>(model);
                /*new WeatherForecast()
                {
                    Id = model.Id,
                    Date = model.Date, Summary = model.Summary, TemperatureC = model.TemperatureC
                };
                */
                await _repository.CreateAsync(entity);
                model.Id=entity.Id;

                return CreatedAtAction(nameof(GetById),
                    new { id = model.Id }   // the address where to access to read new data 
                    , model);               // return the created entity
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public virtual async Task<IActionResult> Put(IdType id, DetailsType model)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return NotFound();

            if (ModelState.IsValid)
            {
                entity = _mapper.Map<EntityType>(model);

                /*
                entity.Date = model.Date;
                entity.Summary = model.Summary;
                entity.TemperatureC = model.TemperatureC;
                */

                await _repository.UpdateAsync(entity);

                // return Ok(entity);
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }
        
        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> Delete(IdType id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return NotFound();

            await _repository.DeleteAsync(id);
            return NoContent();
        }

    }
    
}