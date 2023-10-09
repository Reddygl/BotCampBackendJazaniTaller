using BotCampBackendJazaniTaller.Exceptions;
using Jazani.Application.Generales.Dtos.Holders;
using Jazani.Application.Generales.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BotCampBackendJazaniTaller.Controllers.Generals
{
    [Route("api/[controller]")]
    public class HolderController : ControllerBase
    {
        private readonly IHolderService _holderService;
        public HolderController(IHolderService holderService)
        {
            _holderService = holderService;
        }

        [HttpGet]
        public async Task<IEnumerable<HolderDto>> Get()
        {
            return await _holderService.FindAllAsync();
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(HolderDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
        public async Task<Results<NotFound, Ok<HolderDto>>> Get(int id)
        {
            var response = await _holderService.FindByIdAsync(id);
            return TypedResults.Ok(response);
        }
    }
}
