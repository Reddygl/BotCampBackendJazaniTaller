namespace Jazani.Application.Generales.Dtos.Investments
{
    public class InvestmentSaveDto
    {
        public string? Description { get; set; }
        public decimal Amountinvestd { get; set; }
        public int MiningconcessionId { get; set; }
        public int InvestmentConceptId { get; set; }
        public int InvestmentTypeId { get; set; }
        public int CurrencyTypeId { get; set; }
        public int HolderId { get; set; }
        public int? MeasureUnitId { get; set; }
        public int DeclaredTypeId { get; set; }
        public int? PeriodTypeId { get; set; } = null;
    }
}
