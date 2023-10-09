using BotCampBackendJazaniTaller.Exceptions;
using Jazani.Application.Admins.Dtos.MineralGroups;
using Jazani.Application.Admins.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BotCampBackendJazaniTaller.Controllers
{
    [Route("api/[controller]")]
    public class MineralGroupController : ControllerBase
    {
        private readonly IMineralGroupService _mineralGroupService;
        public MineralGroupController(IMineralGroupService mineralGroupService)
        {
            _mineralGroupService = mineralGroupService;
        }
        [HttpGet]
        public async Task<IEnumerable<MineralGroupDto>> Get()
        {
            return await _mineralGroupService.FindAllAsync();
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MineralGroupDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
        public async Task<Results<NotFound, Ok<MineralGroupDto>>> Get(int id)
        {
            var response = await _mineralGroupService.FindByIdAsync(id);
            return TypedResults.Ok(response);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MineralGroupDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
        public async Task<Results<BadRequest, CreatedAtRoute<MineralGroupDto>>> Post([FromBody] MineralGroupSaveDto mineralGroupSaveDto)
        {
            var response = await _mineralGroupService.CreateAsync(mineralGroupSaveDto);
            return TypedResults.CreatedAtRoute(response);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MineralGroupDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
        public async Task<Results<NotFound, Ok<MineralGroupDto>>> Put(int id, [FromBody] MineralGroupSaveDto mineralGroupSaveDto)
        {
            var response = await _mineralGroupService.EditAsync(id, mineralGroupSaveDto);
            return TypedResults.Ok(response);
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MineralGroupDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
        public async Task<Results<NotFound, Ok<MineralGroupDto>>> Delete(int id)
        {
            var response = await _mineralGroupService.DisabledAsync(id);
            return TypedResults.Ok(response);
        }
    }
}
