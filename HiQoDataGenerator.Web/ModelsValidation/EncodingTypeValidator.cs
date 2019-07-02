using FluentValidation;
using HiQoDataGenerator.Web.ViewModels;
using HiQoDataGenerator.Web.Extensions;

namespace HiQoDataGenerator.Web.ModelsValidation
{
    public class EncodingTypeValidator : AbstractValidator<EncodingTypeViewModel>
    {
        public EncodingTypeValidator()
        {
            RuleFor(x => x.Name)
                .MaximumLength(50).WithMessage("{PropertyName}".MaximumLengthExceeded(50))
                .NotNull().WithMessage("{PropertyName}".CanNotBeNull())
                .NotEmpty().WithMessage("{PropertyName}".CanNotBeEmpty());
        }
    }
}
