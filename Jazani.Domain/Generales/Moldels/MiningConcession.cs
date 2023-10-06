namespace Jazani.Domain.Generales.Moldels
{
    public class MiningConcession
    {
        public int Id { get; set; }
        public string Code { get; set; } = default!;
        public string Name { get; set; } = default!;
        public int MineralTypeId { get; set; }
        public int OriginId { get; set; }
        public int TypeId { get; set; }
        public int SituationId { get; set; }
        public int MiningunitId { get; set; }
        public int ConditionId { get; set; }
        public int StatemanagementId { get; set; }
        public string? Description { get; set; }
        public string? Observation { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool State { get; set; }
        public virtual ICollection<MiningConcessionHolder> MiningConcessionHolders { get; set; }
    }
}
