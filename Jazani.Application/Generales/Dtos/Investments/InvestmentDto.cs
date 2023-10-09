using Jazani.Application.Generales.Dtos.Holders;
using Jazani.Application.Generales.Dtos.InvestmentConcepts;
using Jazani.Application.Generales.Dtos.InvestmentTypes;
using Jazani.Application.Generales.Dtos.MeasureUnits;
using Jazani.Application.Generales.Dtos.MiningConcessions;
using Jazani.Application.Generales.Dtos.Periodtypes;

namespace Jazani.Application.Generales.Dtos.Investments
{
    public class InvestmentDto
    {
        public int Id { get; set; }
        public decimal Amountinvestd { get; set; }
        public string Description { get; set; }
        public MiningConcessionSimpleDto Miningconcession { get; set; }
        public InvestmentConceptSimpleDto? InvestmentConcept { get; set; }
        public InvestmentTypeSimpleDto InvestmentType { get; set; }
        public int CurrencyType { get; set; }
        public HolderSimpleDto Holder { get; set; }
        public MeasureUnitSimpleDto? MeasureUnit { get; set; }
        public int DeclaredTypeId { get; set; }
        public PeriodtypeSimpleDto? PeriodType { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool State { get; set; }
    }
}
