using Jazani.Application.Generales.Dtos.Periodtypes;

namespace Jazani.Application.Generales.Services
{
    public interface IPeriodtypeService
    {
        Task<IReadOnlyList<PeriodtypeDto>> FindAllAsync();
        Task<PeriodtypeDto> FindByIdAsync(int id);
        Task<PeriodtypeDto> CreateAsync(PeriodtypeSaveDto periodtypeSaveDto);
        Task<PeriodtypeDto> EditAsync(int id, PeriodtypeSaveDto periodtypeSaveDto);
        Task<PeriodtypeDto> DisabledAsync(int id);
    }
}
