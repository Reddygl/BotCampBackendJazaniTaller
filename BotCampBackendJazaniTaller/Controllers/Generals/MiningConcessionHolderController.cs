using BotCampBackendJazaniTaller.Exceptions;
using Jazani.Application.Generales.Dtos.MiningConcessionHolders;
using Jazani.Application.Generales.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BotCampBackendJazaniTaller.Controllers.Generals
{
    [Route("api/[controller]")]
    public class MiningConcessionHolderController : ControllerBase
    {
        private readonly IMiningConcessionHolderService _miningConcessionHolderService;
        public MiningConcessionHolderController(IMiningConcessionHolderService miningConcessionHolderService)
        {
            _miningConcessionHolderService = miningConcessionHolderService;
        }

        [HttpGet]
        public async Task<IEnumerable<MiningConcessionHolderDto>> Get()
        {
            return await _miningConcessionHolderService.FindAllAsync();
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MiningConcessionHolderDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
        public async Task<Results<NotFound, Ok<MiningConcessionHolderDto>>> Get(int id, int Key)
        {
            var response = await _miningConcessionHolderService.FindByIdAndKeyAsync(id, Key);
            return TypedResults.Ok(response);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(MiningConcessionHolderDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        public async Task<Results<BadRequest, CreatedAtRoute<MiningConcessionHolderDto>>> Post([FromBody] MiningConcessionHolderSaveDto miningConcessionSaveDto)
        {
            var response = await _miningConcessionHolderService.CreateAsync(miningConcessionSaveDto);
            return TypedResults.CreatedAtRoute(response);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(MiningConcessionHolderDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        public async Task<Results<NotFound, Ok<MiningConcessionHolderDto>>> Put(int id, int key,[FromBody] MiningConcessionHolderUpdateDto miningConcessionHolderUpdate)
        {
            var response = await _miningConcessionHolderService.EditAsync(id, key, miningConcessionHolderUpdate);
            return TypedResults.Ok(response);
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(MiningConcessionHolderDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        public async Task<Results<NotFound, Ok<MiningConcessionHolderDto>>> Delete(int id, int key)
        {
            var response = await _miningConcessionHolderService.DisabledAsync(id, key);
            return TypedResults.Ok(response);
        }
    }
}
