using Jazani.Application.Generales.Dtos.MiningConcessionHolders;

namespace Jazani.Application.Generales.Services
{
    public interface IMiningConcessionHolderService
    {
        Task<IReadOnlyList<MiningConcessionHolderDto>> FindAllAsync();
        Task<MiningConcessionHolderDto> FindByIdAndKeyAsync(int id, int key);
        Task<MiningConcessionHolderDto> CreateAsync(MiningConcessionHolderSaveDto miningConcessionSaveDto);
        Task<MiningConcessionHolderDto> EditAsync(int id, int key, MiningConcessionHolderUpdateDto miningConcessionHolderUpdate);
        Task<MiningConcessionHolderDto> DisabledAsync(int id, int key);
    }
}
