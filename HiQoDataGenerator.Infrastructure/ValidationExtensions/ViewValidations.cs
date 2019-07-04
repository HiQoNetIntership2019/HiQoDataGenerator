using FluentValidation;

namespace HiQoDataGenerator.Infrastructure.ValidationExtensions
{
    public static class ViewValidations
    {
        public static IRuleBuilderOptions<T, TProp> CanNotBeEmptyWithMessage<T, TProp>(this IRuleBuilder<T, TProp> options)
        {
            return options.NotEmpty().WithMessage("field {PropertyName} can not be empty");
        }

        public static IRuleBuilderOptions<T, TProp> CanNotBeNullWithMessage<T, TProp>(this IRuleBuilder<T, TProp> options)
        {
            return options.NotNull().WithMessage("field {PropertyName} can not be empty");
        }

        public static IRuleBuilderOptions<T, string> MaxLengthWithMessage<T>(this IRuleBuilder<T, string> options, int length)
        {
            return options.MaximumLength(length).WithMessage($"The value of the field {{PropertyName}} can not be more than {length}");
        }

    }
}
