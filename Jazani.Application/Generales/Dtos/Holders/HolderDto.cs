using Jazani.Domain.Generales.Moldels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.Application.Generales.Dtos.Holders
{
    public class HolderDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string MaidenName { get; set; } = default!;
        public string DocumentNumber { get; set; } = default!;
        public DateTime RegistrationDate { get; set; }
        public int HolderRegimeId { get; set; }
        public int HolderGroupId { get; set; }
        public int RegistryOfficeId { get; set; }
        public int IdentificationDocumentId { get; set; }
        public int HolderTypeId { get; set; }
        public bool State { get; set; }
    }
}
