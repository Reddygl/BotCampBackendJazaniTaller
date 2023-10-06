namespace Jazani.Domain.Generales.Moldels
{
    public class MiningConcessionHolder
    { 
        public int HolderId { get; set; }
        public int MiningConcessionId { get; set; }
        public decimal Percent { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool State { get; set; }
        public virtual MiningConcession MiningConcession { get; set; }
        public virtual Holder Holder { get; set; }
    }
}
