using FluentValidation;

namespace Jazani.Application.Generales.Dtos.InvestmentTypes.Validators
{
    public class InvestmentTypeValidator : AbstractValidator<InvestmentTypeSaveDto>
    {
        public InvestmentTypeValidator() 
        {
            RuleFor(x => x.Name).NotNull().NotEmpty();
        }
    }
}
