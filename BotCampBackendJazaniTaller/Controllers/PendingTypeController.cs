using Jazani.Application.Admins.Dtos.PendingTypes;
using Jazani.Application.Admins.Services;
using Microsoft.AspNetCore.Mvc;

namespace BotCampBackendJazaniTaller.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        public async Task<PendingTypeDto> Get(int id)
        {
            return await _pendingTypeService.FindByIdAsync(id);
        }
        [HttpPost]
        public async Task<PendingTypeDto> Post([FromBody] PendingTypeSaveDto pendingTypeSaveDto)
        {
            return await _pendingTypeService.CreateAsync(pendingTypeSaveDto);
        }
        [HttpPut]
        public async Task<PendingTypeDto> Put(int id, [FromBody] PendingTypeSaveDto pendingTypeSaveDto)
        {
            return await _pendingTypeService.EditAsync(id, pendingTypeSaveDto);
        }
        [HttpDelete]
        public async Task<PendingTypeDto> Delete(int id)
        {
            return await _pendingTypeService.DisabledAsync(id);
        }
    }
}
