using Jazani.Application.Generales.Dtos.InvestmentConcepts;

namespace Jazani.Application.Generales.Services
{
    public interface IInvestmentConceptService
    {
        Task<IReadOnlyList<InvestmentConceptDto>> FindAllAsync();
        Task<InvestmentConceptDto> FindByIdAsync(int id);
        Task<InvestmentConceptDto> CreateAsync(InvestmentConceptSaveDto investmentSaveDto);
        Task<InvestmentConceptDto> EditAsync(int id, InvestmentConceptSaveDto investmentSaveDto);
        Task<InvestmentConceptDto> DisabledAsync(int id);
    }
}
