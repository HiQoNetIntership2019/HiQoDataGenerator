using FluentValidation;
using HiQoDataGenerator.Web.ViewModels;

namespace HiQoDataGenerator.Web.ModelsValidation
{
    public class ConstraintValueValidator : AbstractValidator<ConstraintValueViewModel>
    {
        public ConstraintValueValidator()
        {
            RuleFor(x => x.Id)
                .NotNull();

            RuleFor(x => x.Value)
                .MaximumLength(300)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.ConstraintViewModel)
                .NotNull();
        }
    }
}
