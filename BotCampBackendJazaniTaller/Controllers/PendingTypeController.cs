using BotCampBackendJazaniTaller.Exceptions;
using Jazani.Application.Admins.Dtos.PendingTypes;
using Jazani.Application.Admins.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BotCampBackendJazaniTaller.Controllers
{
    [Route("api/[controller]")]
    public class PendingTypeController : ControllerBase
    {
        private readonly IPendingTypeService _pendingTypeService;
        public PendingTypeController(IPendingTypeService pendingTypeService)
        {
            _pendingTypeService = pendingTypeService;
        }
        [HttpGet]
        public async Task<IEnumerable<PendingTypeDto>> Get()
        {
            return await _pendingTypeService.FindAllAsync();
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PendingTypeDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
        public async Task<Results<NotFound, Ok<PendingTypeDto>>> Get(int id)
        {
            var response = await _pendingTypeService.FindByIdAsync(id);
            return TypedResults.Ok(response);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PendingTypeDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
        public async Task<Results<BadRequest, CreatedAtRoute<PendingTypeDto>>> Post([FromBody] PendingTypeSaveDto pendingTypeSaveDto)
        {
            var response = await _pendingTypeService.CreateAsync(pendingTypeSaveDto);
            return TypedResults.CreatedAtRoute(response);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PendingTypeDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
        public async Task<Results<NotFound, Ok<PendingTypeDto>>> Put(int id, [FromBody] PendingTypeSaveDto pendingTypeSaveDto)
        {
            var response = await _pendingTypeService.EditAsync(id, pendingTypeSaveDto);
            return TypedResults.Ok(response);
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PendingTypeDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
        public async Task<Results<NotFound, Ok<PendingTypeDto>>> Delete(int id)
        {
            var response = await _pendingTypeService.DisabledAsync(id);
            return TypedResults.Ok(response);
        }
    }
}
