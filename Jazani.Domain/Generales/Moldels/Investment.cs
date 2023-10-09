namespace Jazani.Domain.Generales.Moldels
{
    public class Investment
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public decimal Amountinvestd { get; set; }
        public int MiningconcessionId { get; set; }
        public int? InvestmentConceptId { get; set; }
        public int InvestmentTypeId { get; set; }
        public int CurrencyTypeId { get; set; }
        public int HolderId { get; set; }
        public int? MeasureUnitId { get; set; }
        public int DeclaredTypeId { get; set; }
        public int? PeriodTypeId { get; set; } = null;
        public DateTime RegistrationDate { get; set; }
        public bool State { get; set; }
        public virtual Holder Holder { get; set; }
        public virtual InvestmentConcept? InvestmentConcept { get; set; }
        public virtual InvestmentType InvestmentType { get; set; }
        public virtual MeasureUnit? MeasureUnit { get; set; }
        public virtual Periodtype? Periodtype { get; set; }
        public virtual MiningConcession MiningConcession { get; set; }
    }
}
