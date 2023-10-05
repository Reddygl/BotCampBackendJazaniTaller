using AutoMapper;
using Jazani.Application.Admins.Dtos.MineralGroups;
using Jazani.Domain.Admins.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.Application.Admins.Dtos.PendingTypes.Mappers
{
    public class PendingTypeSaveMapper : Profile
    {
        public PendingTypeSaveMapper()
        {
            CreateMap<PendingType, PendingTypeSaveDto>().ReverseMap();
        }
    }
}
