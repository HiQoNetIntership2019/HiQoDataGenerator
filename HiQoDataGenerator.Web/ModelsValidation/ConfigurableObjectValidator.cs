using FluentValidation;
using HiQoDataGenerator.Web.ViewModels;
using HiQoDataGenerator.Web.Extensions;

namespace HiQoDataGenerator.Web.ModelsValidation
{
    public class ConfigurableObjectValidator : AbstractValidator<ConfigurableObjectViewModel>
    {
      
        public ConfigurableObjectValidator()
        {
            string propertyName = "Name";
            RuleFor(x => x.Name)
                .MaximumLength(50).WithMessage(propertyName.MaximumLengthExceeded(50))
                .NotNull().WithMessage(propertyName.CanNotBeNull())
                .NotEmpty().WithMessage(propertyName.CanNotBeEmpty());

            propertyName = "DateCreation";
            RuleFor(x => x.DateCreation)
                .NotNull().WithMessage(propertyName.CanNotBeNull());
        }
    }
}
