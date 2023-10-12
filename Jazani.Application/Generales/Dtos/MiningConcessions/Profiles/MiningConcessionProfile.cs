using AutoMapper;
using Jazani.Domain.Generales.Moldels;

namespace Jazani.Application.Generales.Dtos.MiningConcessions.Profiles
{
    public class MiningConcessionProfile : Profile
    {
        public MiningConcessionProfile() {
            CreateMap<MiningConcession, MiningConcessionDto>();
            CreateMap<MiningConcession, MiningConcessionSimpleDto>();
            CreateMap<MiningConcession, MiningConcessionSaveDto>().ReverseMap();
            //add
            CreateMap<MiningConcession, MiningConcessionSaveDto>();
            CreateMap<MiningConcession, MiningConcessionSimpleDto>().ReverseMap();
        }
    }
}
