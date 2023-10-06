using Jazani.Application.Generales.Dtos.MiningConcessionHolders;
using Jazani.Application.Generales.Services;
using Microsoft.AspNetCore.Mvc;

namespace BotCampBackendJazaniTaller.Controllers.Generals
{
    [Route("api/[controller]")]
    [ApiController]
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
        public async Task<MiningConcessionHolderDto> Get(int id, int Key)
        {
            return await _miningConcessionHolderService.FindByIdAndKeyAsync(id, Key);
        }
        [HttpPost]
        public async Task<MiningConcessionHolderDto> Post([FromBody] MiningConcessionHolderSaveDto miningConcessionSaveDto)
        {
            return await _miningConcessionHolderService.CreateAsync(miningConcessionSaveDto);
        }
        [HttpPut]
        public async Task<MiningConcessionHolderDto> Put(int id, int key,[FromBody] MiningConcessionHolderUpdateDto miningConcessionHolderUpdate)
        {
            return await _miningConcessionHolderService.EditAsync(id, key, miningConcessionHolderUpdate);
        }
        [HttpDelete("{id}")]
        public async Task<MiningConcessionHolderDto> Delete(int id, int key)
        {
            return await _miningConcessionHolderService.DisabledAsync(id, key);
        }
    }
}
