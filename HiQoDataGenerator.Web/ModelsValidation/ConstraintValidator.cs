using FluentValidation;
using HiQoDataGenerator.Web.ViewModels;

namespace HiQoDataGenerator.Web.ModelsValidation
{
    public class ConstraintValidator : AbstractValidator<ConstraintViewModel>
    {
        public ConstraintValidator()
        {
            RuleFor(x => x.Name)
                .MaximumLength(50)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Description)
                .MaximumLength(50)
                .NotNull()
                .NotEmpty();
        }
    }
}
