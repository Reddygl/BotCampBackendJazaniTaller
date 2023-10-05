﻿using AutoMapper;
using Jazani.Domain.Admins.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.Application.Admins.Dtos.MineralGroups.Mappers
{
    public class MineralGroupMapper : Profile
    {
        public MineralGroupMapper()
        {
            CreateMap<MineralGroup, MineralGroupDto>();
        }  
    }
}
