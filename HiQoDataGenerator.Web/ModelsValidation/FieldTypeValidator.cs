using FluentValidation;
using HiQoDataGenerator.Web.ViewModels;

namespace HiQoDataGenerator.Web.ModelsValidation
{
    public class FieldTypeValidator : AbstractValidator<FieldTypeViewModel>
    {
        public FieldTypeValidator()
        {
            RuleFor(x => x.Name)
                .MaximumLength(50)
                .NotNull()
                .NotEmpty();
        } 
    }
}
