using Jazani.Application.Generales.Dtos.Holders;

namespace Jazani.Application.Generales.Services
{
    public interface IHolderService
    {
        Task<IReadOnlyList<HolderDto>> FindAllAsync();
        Task<HolderDto> FindByIdAsync(int id);
        Task<HolderDto> CreateAsync(HolderSaveDto investmentSaveDto);
        Task<HolderDto> EditAsync(int id, HolderSaveDto investmentSaveDto);
        Task<HolderDto> DisabledAsync(int id);
    }
}
