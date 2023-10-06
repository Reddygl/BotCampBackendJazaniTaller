using Jazani.Application.Generales.Dtos.MiningConcessions;

namespace Jazani.Application.Generales.Services
{
    public interface IMiningConcessionService
    {
        Task<IReadOnlyList<MiningConcessionDto>> FindAllAsync();
        Task<MiningConcessionDto> FindByIdAsync(int id);
        Task<MiningConcessionDto> CreateAsync(MiningConcessionSaveDto miningConcessionSaveDto);
        Task<MiningConcessionDto> EditAsync(int id, MiningConcessionSaveDto miningConcessionSaveDto);
        Task<MiningConcessionDto> DisabledAsync(int id);
    }
}
