using BotCampBackendJazaniTaller.Exceptions;
using Jazani.Application.Generales.Dtos.InvestmentConcepts;
using Jazani.Application.Generales.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BotCampBackendJazaniTaller.Controllers.Generals
{
    [Route("api/[controller]")]
    public class InvestmentConceptController : ControllerBase
    {
        private readonly IInvestmentConceptService _investmentConceptService;
        public InvestmentConceptController(IInvestmentConceptService investmentConceptService)
        {
            _investmentConceptService = investmentConceptService;
        }

        [HttpGet]
        public async Task<IEnumerable<InvestmentConceptDto>> Get()
        {
            return await _investmentConceptService.FindAllAsync();
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(InvestmentConceptDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
        public async Task<Results<NotFound, Ok<InvestmentConceptDto>>> Get(int id)
        {
            var response = await _investmentConceptService.FindByIdAsync(id);
            return TypedResults.Ok(response);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(InvestmentConceptDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        public async Task<Results<BadRequest, CreatedAtRoute<InvestmentConceptDto>>> Post([FromBody] InvestmentConceptSaveDto investmentConceptSaveDto)
        {
            var response =await _investmentConceptService.CreateAsync(investmentConceptSaveDto);
            return TypedResults.CreatedAtRoute(response);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(InvestmentConceptDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        public async Task<Results<NotFound, Ok<InvestmentConceptDto>>> Put(int id, [FromBody] InvestmentConceptSaveDto investmentConceptSaveDto)
        {
            var response = await _investmentConceptService.EditAsync(id, investmentConceptSaveDto);
            return TypedResults.Ok(response);
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(InvestmentConceptDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        public async Task<Results<NotFound, Ok<InvestmentConceptDto>>> Delete(int id)
        {
            var response = await _investmentConceptService.DisabledAsync(id);
            return TypedResults.Ok(response);
        }
    }
}
