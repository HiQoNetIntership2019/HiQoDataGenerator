namespace HiQoDataGenerator.Web.Extensions
{
    public static class ValidationMessages
    {
        public static string CanNotBeEmpty(this string fieldName) =>
            $"field {fieldName} can not be empty";

        public static string CanNotBeNull(this string fieldName) =>
            $"field {fieldName} can not be null";

        public static string MaximumLengthExceeded(this string fieldName, int maxLength) =>
            $"The value of the field '{fieldName}' can not be more than {maxLength}";
    }
}
