using AutoMapper;
using Jazani.Domain.Admins.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.Application.Admins.Dtos.PendingTypes
{
    public class PendingTypeSaveDto : Profile
    {
        public PendingTypeSaveDto()
        {
            CreateMap<PendingType, PendingTypeSaveDto>().ReverseMap();
        }
    }
}
