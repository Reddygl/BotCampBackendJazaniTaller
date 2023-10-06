using Jazani.Application.Generales.Dtos.MiningConcessions;
using Jazani.Application.Generales.Services;
using Microsoft.AspNetCore.Mvc;

namespace BotCampBackendJazaniTaller.Controllers.Generals
{
    [Route("api/[controller]")]
    [ApiController]
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
        public async Task<MiningConcessionDto> Get(int id)
        {
            return await _miningConcessionService.FindByIdAsync(id);
        }
        [HttpPost]
        public async Task<MiningConcessionDto> Post([FromBody] MiningConcessionSaveDto miningConcessionSaveDto)
        {
            return await _miningConcessionService.CreateAsync(miningConcessionSaveDto);
        }
        [HttpPut]
        public async Task<MiningConcessionDto> Put(int id, [FromBody] MiningConcessionSaveDto miningConcessionSaveDto)
        {
            return await _miningConcessionService.EditAsync(id, miningConcessionSaveDto);
        }
        [HttpDelete]
        public async Task<MiningConcessionDto> Delete(int id)
        {
            return await _miningConcessionService.DisabledAsync(id);
        }
    }
}
