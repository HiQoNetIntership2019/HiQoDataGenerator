using FluentValidation;
using HiQoDataGenerator.Web.ViewModels;
using HiQoDataGenerator.Web.Extensions;

namespace HiQoDataGenerator.Web.ModelsValidation
{
    public class TimezoneValidator : AbstractValidator<TimezoneViewModel>
    {
        public TimezoneValidator()
        {
            string propertyName = "Value";
            RuleFor(x => x.Value)
                .MaximumLength(50).WithMessage(propertyName.MaximumLengthExceeded(50))
                .NotNull().WithMessage(propertyName.CanNotBeNull())
                .NotEmpty().WithMessage(propertyName.CanNotBeEmpty());
        }
    }
}
