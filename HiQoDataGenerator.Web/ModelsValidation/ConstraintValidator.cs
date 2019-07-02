using FluentValidation;
using HiQoDataGenerator.Web.Extensions;
using HiQoDataGenerator.Web.ViewModels;

namespace HiQoDataGenerator.Web.ModelsValidation
{
    public class ConstraintValidator : AbstractValidator<ConstraintViewModel>
    {
        public ConstraintValidator()
        {
            RuleFor(x => x.Name)
                .MaximumLength(50).WithMessage("{PropertyName}".MaximumLengthExceeded(50))
                .NotNull().WithMessage("{PropertyName}".CanNotBeNull())
                .NotEmpty().WithMessage("{PropertyName}".CanNotBeEmpty());

            RuleFor(x => x.Description)
                .MaximumLength(50).WithMessage("{PropertyName}".MaximumLengthExceeded(50))
                .NotNull().WithMessage("{PropertyName}".CanNotBeNull())
                .NotEmpty().WithMessage("{PropertyName}".CanNotBeEmpty());
        }
    }
}
