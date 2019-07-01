using FluentValidation;
using HiQoDataGenerator.Web.ViewModels;

namespace HiQoDataGenerator.Web.ModelsValidation
{
    public class ConfigurableObjectValidator : AbstractValidator<ConfigurableObjectViewModel>
    {
        public ConfigurableObjectValidator()
        {
            RuleFor(x => x.Name)
                .MaximumLength(50)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.DateCreation)
                .NotNull();
        }
    }
}
