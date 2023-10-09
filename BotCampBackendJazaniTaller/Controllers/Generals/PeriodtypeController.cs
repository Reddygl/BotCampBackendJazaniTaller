using BotCampBackendJazaniTaller.Exceptions;
using Jazani.Application.Generales.Dtos.Periodtypes;
using Jazani.Application.Generales.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BotCampBackendJazaniTaller.Controllers.Generals
{
    [Route("api/[controller]")]
    public class PeriodtypeController : ControllerBase
    {
        private readonly IPeriodtypeService _periodtypeService;
        public PeriodtypeController(IPeriodtypeService periodtypeService)
        {
            _periodtypeService = periodtypeService;
        }

        [HttpGet]
        public async Task<IEnumerable<PeriodtypeDto>> Get()
        {
            return await _periodtypeService.FindAllAsync();
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PeriodtypeDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
        public async Task<Results<NotFound, Ok<PeriodtypeDto>>> Get(int id)
        {
            var response = await _periodtypeService.FindByIdAsync(id);
            return TypedResults.Ok(response);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(PeriodtypeDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        public async Task<Results<BadRequest, CreatedAtRoute<PeriodtypeDto>>> Post([FromBody] PeriodtypeSaveDto periodtypeSaveDto)
        {
            var response = await _periodtypeService.CreateAsync(periodtypeSaveDto);
            return TypedResults.CreatedAtRoute(response);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(PeriodtypeDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        public async Task<Results<NotFound, Ok<PeriodtypeDto>>> Put(int id, [FromBody] PeriodtypeSaveDto periodtypeSaveDto)
        {
            var response = await _periodtypeService.EditAsync(id, periodtypeSaveDto);
            return TypedResults.Ok(response);
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PeriodtypeDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
        public async Task<Results<NotFound, Ok<PeriodtypeDto>>> Delete(int id)
        {
            var response =  await _periodtypeService.DisabledAsync(id);
            return TypedResults.Ok(response);
        }
    }
}
