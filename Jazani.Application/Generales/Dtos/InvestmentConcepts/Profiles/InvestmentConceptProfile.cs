using AutoMapper;
using Jazani.Domain.Generales.Moldels;

namespace Jazani.Application.Generales.Dtos.InvestmentConcepts.Profiles
{
    public class InvestmentConceptProfile : Profile
    {
        public InvestmentConceptProfile()
        {
            CreateMap<InvestmentConcept, InvestmentConceptDto>();
            CreateMap<InvestmentConcept, InvestmentConceptSimpleDto>();
            CreateMap<InvestmentConcept, InvestmentConceptSaveDto>().ReverseMap();
        }
    }
}
