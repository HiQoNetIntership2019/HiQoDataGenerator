using FluentValidation;
using HiQoDataGenerator.Infrastructure.ValidationExtensions;
using HiQoDataGenerator.Web.ViewModels;

namespace HiQoDataGenerator.Web.ModelsValidation
{
    public class DatasetValidator : AbstractValidator<DatasetViewModel>
    {
        public DatasetValidator()
        {
            RuleFor(x => x.Name)
                .MaxLengthWithMessage(50)
                .CanNotBeNullWithMessage()
                .CanNotBeEmptyWithMessage();

            RuleFor(x => x.TypeId)
                .CanNotBeNullWithMessage();

            RuleFor(x => x.IsDefined)
                .CanNotBeNullWithMessage();
        }
    }
}
