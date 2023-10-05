using Jazani.Domain.Admins.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.Application.Admins.Dtos.MineralGroups
{
    public class MineralGroupSaveDto
    {
        public string Name { get; set; } = default!;
        public string Slug { get; set; } = default!;
        public string? Description { get; set; }
    }
}
