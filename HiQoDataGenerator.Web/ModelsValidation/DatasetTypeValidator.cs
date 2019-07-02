using FluentValidation;
using HiQoDataGenerator.Web.ViewModels;
using HiQoDataGenerator.Web.Extensions;

namespace HiQoDataGenerator.Web.ModelsValidation
{
    public class DatasetTypeValidator : AbstractValidator<DatasetTypeViewModel>
    {
        public DatasetTypeValidator()
        {
            RuleFor(x => x.TypeName)
                .MaximumLength(50).WithMessage("{PropertyName}".MaximumLengthExceeded(50))
                .NotNull().WithMessage("{PropertyName}".CanNotBeNull())
                .NotEmpty().WithMessage("{PropertyName}".CanNotBeEmpty());
        }
    }
}
