using System.Collections.Generic;
using System.Linq;

namespace Api.Infra.CrossCutting.ExtensionMethods
{
    public static class IEnumerableExtensions
    {
        public static bool IsNullOrEmpty<TEnumerable>(this IEnumerable<TEnumerable> value)
        {
            return value == null || !value.Any();
        }
    }
}
