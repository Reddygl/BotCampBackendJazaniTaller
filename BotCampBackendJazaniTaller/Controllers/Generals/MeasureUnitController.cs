using BotCampBackendJazaniTaller.Exceptions;
using Jazani.Application.Generales.Dtos.MeasureUnits;
using Jazani.Application.Generales.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BotCampBackendJazaniTaller.Controllers.Generals
{
    [Route("api/[controller]")]
    public class MeasureUnitController : ControllerBase
    {
        private readonly IMeasureUnitService _measureUnitService;
        public MeasureUnitController(IMeasureUnitService measureUnitService)
        {
            _measureUnitService = measureUnitService;
        }

        [HttpGet]
        public async Task<IEnumerable<MeasureUnitDto>> Get()
        {
            return await _measureUnitService.FindAllAsync();
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MeasureUnitDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
        public async Task<Results<NotFound, Ok<MeasureUnitDto>>> Get(int id)
        {
            var response = await _measureUnitService.FindByIdAsync(id);
            return TypedResults.Ok(response);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(MeasureUnitDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        public async Task<Results<BadRequest, CreatedAtRoute<MeasureUnitDto>>> Post([FromBody] MeasureUnitSaveDto measureUnitSaveDto)
        {
            var response = await _measureUnitService.CreateAsync(measureUnitSaveDto);
            return TypedResults.CreatedAtRoute(response);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MeasureUnitDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
        public async Task<Results<NotFound, Ok<MeasureUnitDto>>> Put(int id, [FromBody] MeasureUnitSaveDto measureUnitSaveDto)
        {
            var response = await _measureUnitService.EditAsync(id, measureUnitSaveDto);
            return TypedResults.Ok(response);
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MeasureUnitDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
        public async Task<Results<NotFound, Ok<MeasureUnitDto>>> Delete(int id)
        {
            var response = await _measureUnitService.DisabledAsync(id);
            return TypedResults.Ok(response);
        }
    }
}
