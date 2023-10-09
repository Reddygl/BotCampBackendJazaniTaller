using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.Application.Generales.Dtos.Holders
{
    public class HolderSaveDto
    {
        public string Name { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string MaidenName { get; set; } = default!;
        public string DocumentNumber { get; set; } = default!;
        public int HolderRegimeId { get; set; }
        public int HolderGroupId { get; set; }
        public int RegistryOfficeId { get; set; }
        public int IdentificationDocumentId { get; set; }
        public int HolderTypeId { get; set; }
    }
}
