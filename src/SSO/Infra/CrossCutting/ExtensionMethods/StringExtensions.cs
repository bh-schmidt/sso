using Validation;

namespace SSO.Infra.CrossCutting.ExtensionMethods
{
    public static class StringExtensions
    {
        public static bool IsNullOrWhiteSpace([ValidatedNotNull] this string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }
    }
}
