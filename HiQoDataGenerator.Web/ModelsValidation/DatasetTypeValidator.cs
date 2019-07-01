using FluentValidation;
using HiQoDataGenerator.Web.ViewModels;
using HiQoDataGenerator.Web.Extensions;

namespace HiQoDataGenerator.Web.ModelsValidation
{
    public class DatasetTypeValidator : AbstractValidator<DatasetTypeViewModel>
    {
        public DatasetTypeValidator()
        {
            string propertyName = "TypeName";
            RuleFor(x => x.TypeName)
                .MaximumLength(50).WithMessage(propertyName.MaximumLengthExceeded(50))
                .NotNull().WithMessage(propertyName.CanNotBeNull())
                .NotEmpty().WithMessage(propertyName.CanNotBeEmpty());
        }
    }
}
