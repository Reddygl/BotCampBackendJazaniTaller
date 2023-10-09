using AutoMapper;
using Jazani.Domain.Generales.Moldels;

namespace Jazani.Application.Generales.Dtos.MeasureUnits.Profiles
{
    public class MeasureUnitProfile : Profile
    {
        public MeasureUnitProfile()
        {
            CreateMap<MeasureUnit, MeasureUnitDto>();
            CreateMap<MeasureUnit, MeasureUnitSimpleDto>();
            CreateMap<MeasureUnit, MeasureUnitSaveDto>().ReverseMap();
        }
    }
}
