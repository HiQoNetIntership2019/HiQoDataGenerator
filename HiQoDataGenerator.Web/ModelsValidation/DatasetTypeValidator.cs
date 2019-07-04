using FluentValidation;
using HiQoDataGenerator.Web.ViewModels;
using HiQoDataGenerator.Web.Extensions;
using HiQoDataGenerator.Infrastructure.ValidationExtensions;

namespace HiQoDataGenerator.Web.ModelsValidation
{
    public class DatasetTypeValidator : AbstractValidator<DatasetTypeViewModel>
    {
        public DatasetTypeValidator()
        {
            RuleFor(x => x.TypeName)
                .MaxLengthWithMessage(50)
                .CanNotBeNullWithMessage()
                .CanNotBeEmptyWithMessage();

            RuleFor(x => x.FieldTypeViewModels)
                .CanNotBeNullWithMessage();

            RuleForEach(x => x.FieldTypeViewModels)
                .SetValidator(new FieldTypeValidator());
        }
    }
}
