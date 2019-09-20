using System.Collections.Generic;
using System.Linq;

namespace SSO.Infra.Helpers.Extensions
{
    public static class IEnumerableExtensions
    {
        public static bool IsNullOrEmpty<TEnumerable>(this IEnumerable<TEnumerable> value)
        {
            return value == null || !value.Any();
        }
    }
}
