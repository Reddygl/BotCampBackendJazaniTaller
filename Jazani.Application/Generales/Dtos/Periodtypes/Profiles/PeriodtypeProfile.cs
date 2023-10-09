using AutoMapper;
using Jazani.Domain.Generales.Moldels;

namespace Jazani.Application.Generales.Dtos.Periodtypes.Profiles
{
    public class PeriodtypeProfile : Profile
    {
        public PeriodtypeProfile() 
        {
            CreateMap<Periodtype, PeriodtypeDto>();
            CreateMap<Periodtype, PeriodtypeSimpleDto>();
            CreateMap<Periodtype, PeriodtypeSaveDto>().ReverseMap();
        }
    }
}
