using System;
using Validation;

namespace SSO.Infra.CrossCutting.ExtensionMethods
{
    public static class ObjectExtensions
    {
        public static bool IsNull([ValidatedNotNull] this object value)
        {
            return value == null;
        }

        public static void ThrowIfNull([ValidatedNotNull] this object value, Exception exception)
        {
            if(value.IsNull())
            {
                throw exception;
            }
        }

        public static void ThrowIfNull([ValidatedNotNull] this object value, string attributeName)
        {
            ThrowIfNull(value, new ArgumentException(attributeName));
        }
    }
}
