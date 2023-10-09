using FluentValidation;

namespace Jazani.Application.Generales.Dtos.MiningConcessions.Validators
{
    public class MiningConcessionValidator : AbstractValidator<MiningConcessionSaveDto>
    {
        public MiningConcessionValidator()
        {
            RuleFor(x => x.Code).NotNull().NotEmpty();
            RuleFor(x => x.Name).NotNull().NotEmpty();
            RuleFor(x => x.MineralTypeId).NotNull();
            RuleFor(x => x.OriginId).NotNull();
            RuleFor(x => x.TypeId).NotNull();
            RuleFor(x => x.SituationId).NotNull();
            RuleFor(x => x.ConditionId).NotNull();
        }
    }
}
