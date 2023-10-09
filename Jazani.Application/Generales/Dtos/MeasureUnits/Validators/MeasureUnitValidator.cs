using FluentValidation;

namespace Jazani.Application.Generales.Dtos.MeasureUnits.Validators
{
    public class MeasureUnitValidator : AbstractValidator<MeasureUnitSaveDto>
    {
        public MeasureUnitValidator() 
        {
            RuleFor(x => x.Name).NotNull().NotEmpty();
            RuleFor(x => x.Symbol).NotNull().NotEmpty();
        }
    }
}
