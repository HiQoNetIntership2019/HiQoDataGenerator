using FluentValidation;
using HiQoDataGenerator.Web.ViewModels;
using HiQoDataGenerator.Web.Extensions;

namespace HiQoDataGenerator.Web.ModelsValidation
{
    public class EncodingTypeValidator : AbstractValidator<EncodingTypeViewModel>
    {
        public EncodingTypeValidator()
        {
            string propertyName = "Name";
            RuleFor(x => x.Name)
                .MaximumLength(50).WithMessage(propertyName.MaximumLengthExceeded(50))
                .NotNull().WithMessage(propertyName.CanNotBeNull())
                .NotEmpty().WithMessage(propertyName.CanNotBeEmpty());
        }
    }
}
