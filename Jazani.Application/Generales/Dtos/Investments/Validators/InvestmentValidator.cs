using FluentValidation;

namespace Jazani.Application.Generales.Dtos.Investments.Validators
{
    public class InvestmentValidator : AbstractValidator<InvestmentSaveDto>
    {
        public InvestmentValidator() 
        {
            RuleFor(x => x.Amountinvestd).NotNull();
            RuleFor(x => x.MiningconcessionId).NotNull();
            RuleFor(x => x.InvestmentTypeId).NotNull();
            RuleFor(x => x.CurrencyTypeId).NotNull();
            RuleFor(x => x.HolderId).NotNull();
            RuleFor(x => x.DeclaredTypeId).NotNull();
        }
    }
}
