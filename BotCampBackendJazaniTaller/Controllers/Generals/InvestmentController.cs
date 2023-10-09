using BotCampBackendJazaniTaller.Exceptions;
using Jazani.Application.Generales.Dtos.Investments;
using Jazani.Application.Generales.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BotCampBackendJazaniTaller.Controllers.Generals
{
    [Route("api/[controller]")]
    public class InvestmentController : ControllerBase
    {
        private readonly IInvestmentService _investmentService;
        public InvestmentController(IInvestmentService investmentService)
        {
            _investmentService = investmentService;
        }

        [HttpGet]
        public async Task<IEnumerable<InvestmentDto>> Get()
        {
            return await _investmentService.FindAllAsync();
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(InvestmentDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
        public async Task<Results<NotFound, Ok<InvestmentDto>>> Get(int id)
        {
            var response = await _investmentService.FindByIdAsync(id);
            return TypedResults.Ok(response);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(InvestmentDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        public async Task<Results<BadRequest, CreatedAtRoute<InvestmentDto>>> Post([FromBody] InvestmentSaveDto investmentSaveDto)
        {
            var response = await _investmentService.CreateAsync(investmentSaveDto);
            return TypedResults.CreatedAtRoute(response);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(InvestmentDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        public async Task<Results<NotFound, Ok<InvestmentDto>>> Put(int id, [FromBody] InvestmentSaveDto investmentSaveDto)
        {
            var response = await _investmentService.EditAsync(id, investmentSaveDto);
            return TypedResults.Ok(response);
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(InvestmentDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        public async Task<Results<NotFound, Ok<InvestmentDto>>> Delete(int id)
        {
            var response = await _investmentService.DisabledAsync(id);
            return TypedResults.Ok(response);
        }
    }
}
