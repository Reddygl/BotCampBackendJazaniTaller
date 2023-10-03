using AutoMapper;
using Jazani.Domain.Admins.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.Application.Admins.Dtos.PendingTypes.Mappers
{
    public class PendingTypeMapper : Profile
    {
        public PendingTypeMapper() 
        {
            CreateMap<PendingType, PendingTypeDto>();
        }  
    }
}
