using AutoMapper;
using Jazani.Domain.Generales.Moldels;

namespace Jazani.Application.Generales.Dtos.InvestmentTypes.Profiles
{
    public class InvestmentTypeProfile : Profile
    {
        public InvestmentTypeProfile() 
        {
            CreateMap<InvestmentType, InvestmentTypeDto>();
            CreateMap<InvestmentType, InvestmentTypeSimpleDto>();
            CreateMap<InvestmentType, InvestmentTypeSaveDto>().ReverseMap();
        }
    }
}
