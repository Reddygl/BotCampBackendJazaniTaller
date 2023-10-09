using Jazani.Application.Generales.Dtos.InvestmentTypes;

namespace Jazani.Application.Generales.Services
{
    public interface IInvestmentTypeService
    {
        Task<IReadOnlyList<InvestmentTypeDto>> FindAllAsync();
        Task<InvestmentTypeDto> FindByIdAsync(int id);
        Task<InvestmentTypeDto> CreateAsync(InvestmentTypeSaveDto investmentTypeSaveDto);
        Task<InvestmentTypeDto> EditAsync(int id, InvestmentTypeSaveDto investmentTypeSaveDto);
        Task<InvestmentTypeDto> DisabledAsync(int id);
    }
}
