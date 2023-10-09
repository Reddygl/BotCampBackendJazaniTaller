using AutoMapper;
using Jazani.Domain.Generales.Moldels;

namespace Jazani.Application.Generales.Dtos.Investments.Profiles
{
    public class InvestmentProfile : Profile
    {
        public InvestmentProfile() 
        {
            CreateMap<Investment, InvestmentDto>();
            CreateMap<Investment, InvestmentSaveDto>().ReverseMap();
        }
    }
}
