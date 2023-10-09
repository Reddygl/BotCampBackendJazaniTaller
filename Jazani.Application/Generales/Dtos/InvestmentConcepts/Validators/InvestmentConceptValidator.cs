using FluentValidation;

namespace Jazani.Application.Generales.Dtos.InvestmentConcepts.Validators
{
    public class InvestmentConceptValidator : AbstractValidator<InvestmentConceptSaveDto>
    {
        public InvestmentConceptValidator() 
        {
            RuleFor(x => x.Name).NotNull().NotEmpty();
        }
    }
}
