using Jazani.Application.Admins.Dtos.MineralGroups;
using Jazani.Application.Admins.Dtos.PendingTypes;
using Jazani.Application.Admins.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BotCampBackendJazaniTaller.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        public async Task<MineralGroupDto> Get(int id)
        {
            return await _mineralGroupService.FindByIdAsync(id);
        }
        [HttpPost]
        public async Task<MineralGroupDto> Post([FromBody] MineralGroupSaveDto mineralGroupSaveDto)
        {
            return await _mineralGroupService.CreateAsync(mineralGroupSaveDto);
        }
        [HttpPut]
        public async Task<MineralGroupDto> Put(int id, [FromBody] MineralGroupSaveDto mineralGroupSaveDto)
        {
            return await _mineralGroupService.EditAsync(id, mineralGroupSaveDto);
        }
        [HttpDelete]
        public async Task<MineralGroupDto> Delete(int id)
        {
            return await _mineralGroupService.DisabledAsync(id);
        }
    }
}
