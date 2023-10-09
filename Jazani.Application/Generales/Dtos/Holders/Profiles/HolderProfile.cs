using AutoMapper;
using Jazani.Application.Generales.Dtos.MiningConcessions;
using Jazani.Domain.Generales.Moldels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.Application.Generales.Dtos.Holders.Profiles
{
    public class HolderProfile : Profile
    {
        public HolderProfile()
        {
            CreateMap<Holder, HolderDto>();
            CreateMap<Holder, HolderSimpleDto>();
            CreateMap<Holder, HolderSaveDto>().ReverseMap();
        }
    }
}
