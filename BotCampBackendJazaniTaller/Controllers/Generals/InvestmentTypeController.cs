using BotCampBackendJazaniTaller.Exceptions;
using Jazani.Application.Generales.Dtos.InvestmentTypes;
using Jazani.Application.Generales.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BotCampBackendJazaniTaller.Controllers.Generals
{
    [Route("api/[controller]")]
    public class InvestmentTypeController : ControllerBase
    {
        private readonly IInvestmentTypeService _investmentTypeService;
        public InvestmentTypeController(IInvestmentTypeService investmentTypeService)
        {
            _investmentTypeService = investmentTypeService;
        }

        [HttpGet]
        public async Task<IEnumerable<InvestmentTypeDto>> Get()
        {
            return await _investmentTypeService.FindAllAsync();
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(InvestmentTypeDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
        public async Task<Results<NotFound, Ok<InvestmentTypeDto>>> Get(int id)
        {
            var response = await _investmentTypeService.FindByIdAsync(id);
            return TypedResults.Ok(response);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(InvestmentTypeDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        public async Task<Results<BadRequest, CreatedAtRoute<InvestmentTypeDto>>> Post([FromBody] InvestmentTypeSaveDto investmentTypeSaveDto)
        {
            var response = await _investmentTypeService.CreateAsync(investmentTypeSaveDto);
            return TypedResults.CreatedAtRoute(response);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(InvestmentTypeDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        public async Task<Results<NotFound, Ok<InvestmentTypeDto>>> Put(int id, [FromBody] InvestmentTypeSaveDto investmentTypeSaveDto)
        {
            var response = await _investmentTypeService.EditAsync(id, investmentTypeSaveDto);
            return TypedResults.Ok(response);
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(InvestmentTypeDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        public async Task<Results<NotFound, Ok<InvestmentTypeDto>>> Delete(int id)
        {
            var response = await _investmentTypeService.DisabledAsync(id);
            return TypedResults.Ok(response);
        }
    }
}
