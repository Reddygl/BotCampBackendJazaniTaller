using AutoMapper;
using Jazani.Domain.Generales.Moldels;

namespace Jazani.Application.Generales.Dtos.MiningConcessionHolders.Profiles
{
    public class MiningConcessionHolderProfile : Profile
    {
        public MiningConcessionHolderProfile()
        {
            CreateMap<MiningConcessionHolder, MiningConcessionHolderDto>();
            CreateMap<MiningConcessionHolder, MiningConcessionHolderUpdateDto>().ReverseMap();
            CreateMap<MiningConcessionHolder, MiningConcessionHolderSaveDto>().ReverseMap();
        }
    }
}
