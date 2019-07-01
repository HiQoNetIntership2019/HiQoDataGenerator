using FluentValidation;
using HiQoDataGenerator.Web.ViewModels;

namespace HiQoDataGenerator.Web.ModelsValidation
{
    public class CustomDatasetValueValidator : AbstractValidator<CustomDatasetValueViewModel>
    {
        public CustomDatasetValueValidator()
        {

            RuleFor(x => x.DatasetName)
                .MaximumLength(50)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Value)
                .MaximumLength(150)
                .NotNull()
                .NotEmpty();
        }
    }
}
