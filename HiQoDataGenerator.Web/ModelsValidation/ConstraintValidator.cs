using FluentValidation;
using HiQoDataGenerator.Web.Extensions;
using HiQoDataGenerator.Web.ViewModels;

namespace HiQoDataGenerator.Web.ModelsValidation
{
    public class ConstraintValidator : AbstractValidator<ConstraintViewModel>
    {
        public ConstraintValidator()
        {
            string propertyName = "Name";
            RuleFor(x => x.Name)
                .MaximumLength(50).WithMessage(propertyName.MaximumLengthExceeded(50))
                .NotNull().WithMessage(propertyName.CanNotBeNull())
                .NotEmpty().WithMessage(propertyName.CanNotBeEmpty());

            propertyName = "Description";
            RuleFor(x => x.Description)
                .MaximumLength(50).WithMessage(propertyName.MaximumLengthExceeded(50))
                .NotNull().WithMessage(propertyName.CanNotBeNull())
                .NotEmpty().WithMessage(propertyName.CanNotBeEmpty());
        }
    }
}
