using System.Collections.Generic;
using System.Linq;

namespace SSO.Infra.CrossCutting.ExtensionMethods
{
    public static class IEnumerableExtensions
    {
        public static bool IsNullOrEmpty<TEnumerable>(this IEnumerable<TEnumerable> value)
        {
            return value == null || !value.Any();
        }
    }
}
