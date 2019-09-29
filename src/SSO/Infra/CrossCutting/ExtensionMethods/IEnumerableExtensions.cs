using System;
using System.Collections.Generic;
using System.Linq;
using Validation;

namespace SSO.Infra.CrossCutting.ExtensionMethods
{
    public static class IEnumerableExtensions
    {
        public static bool IsNullOrEmpty<TEnumerable>([ValidatedNotNull] this IEnumerable<TEnumerable> value)
        {
            return value == null || !value.Any();
        }

        public static void ThrowIfNullOrEmpty<TEnumerable>([ValidatedNotNull] this IEnumerable<TEnumerable> value, Exception exception)
        {
            if (value.IsNullOrEmpty())
            {
                throw exception;
            }
        }

        public static void ThrowIfNullOrEmpty<TEnumerable>([ValidatedNotNull] this IEnumerable<TEnumerable> value, string attributeName)
        {
            value.ThrowIfNullOrEmpty(new ArgumentException(attributeName));
        }
    }
}
