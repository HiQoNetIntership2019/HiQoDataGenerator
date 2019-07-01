using FluentValidation;
using HiQoDataGenerator.Web.ViewModels;

namespace HiQoDataGenerator.Web.ModelsValidation
{
    public class EncodingTypeValidator : AbstractValidator<EncodingTypeViewModel>
    {
        public EncodingTypeValidator()
        {
            RuleFor(x => x.Name)
                .MaximumLength(50)
                .NotNull()
                .NotEmpty();
        }
    }
}
