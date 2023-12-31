﻿namespace Jazani.Domain.Generales.Moldels
{
    public class Holder
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
        public virtual ICollection<MiningConcessionHolder> MiningConcessionHolders { get; set; }
        public virtual ICollection<Investment> Investments { get; set; }
    }
}
