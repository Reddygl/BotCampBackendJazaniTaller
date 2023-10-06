using Jazani.Application.Generales.Dtos.MiningConcessions;
using Jazani.Domain.Generales.Moldels;

namespace Jazani.Application.Generales.Dtos.MiningConcessionHolders
{
    public class MiningConcessionHolderDto
    {
        public int HolderId { get; set; }
        public int MiningConcessionId { get; set; }
        public int Percent { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool State { get; set; }
        public MiningConcessionSimpleDto MiningConcession { get; set; }
        public Holder Holder { get; set; }
    }
}
