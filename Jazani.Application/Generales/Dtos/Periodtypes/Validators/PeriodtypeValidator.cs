using FluentValidation;

namespace Jazani.Application.Generales.Dtos.Periodtypes.Validators
{
    public class PeriodtypeValidator : AbstractValidator<PeriodtypeSaveDto>
    {
        public PeriodtypeValidator() 
        {
            RuleFor(x => x.Name).NotNull().NotEmpty();
            RuleFor(x => x.Time).NotNull();
        }
    }
}
