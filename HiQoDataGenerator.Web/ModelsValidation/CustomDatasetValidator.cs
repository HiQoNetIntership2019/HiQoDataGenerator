using FluentValidation;
using HiQoDataGenerator.Web.ViewModels;

namespace HiQoDataGenerator.Web.ModelsValidation
{
    public class CustomDatasetValidator : AbstractValidator<CustomDatasetViewModel>
    {
        public CustomDatasetValidator()
        {
            RuleFor(x => x.Name)
                .MaximumLength(50)
                .NotNull()
                .NotEmpty();
        }
    }
}
