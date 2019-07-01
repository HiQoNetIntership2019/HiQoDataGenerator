using FluentValidation;
using HiQoDataGenerator.Web.ViewModels;
using HiQoDataGenerator.Web.Extensions;

namespace HiQoDataGenerator.Web.ModelsValidation
{
    public class FieldValidator : AbstractValidator<FieldViewModel>
    {
        public FieldValidator()
        {
            string propertyName = "Name";
            RuleFor(x => x.Name)
                .MaximumLength(150).WithMessage(propertyName.MaximumLengthExceeded(150))
                .NotNull().WithMessage(propertyName.CanNotBeNull())
                .NotEmpty().WithMessage(propertyName.CanNotBeEmpty());

            propertyName = "Constraints";
            RuleFor(x => x.Constraints)
                .NotNull().WithMessage(propertyName.CanNotBeNull());

            propertyName = "FieldType";
            RuleFor(x => x.FieldType)
                .NotNull().WithMessage(propertyName.CanNotBeNull());
        }
    }
}
