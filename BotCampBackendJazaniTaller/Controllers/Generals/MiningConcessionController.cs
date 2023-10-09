using BotCampBackendJazaniTaller.Exceptions;
using Jazani.Application.Generales.Dtos.MiningConcessions;
using Jazani.Application.Generales.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BotCampBackendJazaniTaller.Controllers.Generals
{
    [Route("api/[controller]")]
    public class MiningConcessionController : ControllerBase
    {
        private readonly IMiningConcessionService _miningConcessionService;
        public MiningConcessionController(IMiningConcessionService miningConcessionService)
        {
            _miningConcessionService = miningConcessionService;
        }

        [HttpGet]
        public async Task<IEnumerable<MiningConcessionDto>> Get()
        {
            return await _miningConcessionService.FindAllAsync();
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MiningConcessionDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
        public async Task<Results<NotFound, Ok<MiningConcessionDto>>> Get(int id)
        {
            var response = await _miningConcessionService.FindByIdAsync(id);
            return TypedResults.Ok(response);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(MiningConcessionDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        public async Task<Results<BadRequest, CreatedAtRoute<MiningConcessionDto>>> Post([FromBody] MiningConcessionSaveDto miningConcessionSaveDto)
        {
            var response = await _miningConcessionService.CreateAsync(miningConcessionSaveDto);
            return TypedResults.CreatedAtRoute(response);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(MiningConcessionDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        public async Task<Results<NotFound, Ok<MiningConcessionDto>>> Put(int id, [FromBody] MiningConcessionSaveDto miningConcessionSaveDto)
        {
            var response = await _miningConcessionService.EditAsync(id, miningConcessionSaveDto);
            return TypedResults.Ok(response);
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(MiningConcessionDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        public async Task<Results<NotFound, Ok<MiningConcessionDto>>> Delete(int id)
        {
            var response = await _miningConcessionService.DisabledAsync(id);
            return TypedResults.Ok(response);
        }
    }
}
