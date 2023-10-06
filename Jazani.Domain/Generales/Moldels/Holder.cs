namespace Jazani.Domain.Generales.Moldels
{
    public class Holder
    {
        public int Id { get; set; }
        public virtual ICollection<MiningConcessionHolder> MiningConcessionHolders { get; set; }
    }
}
