using SSO.Domain;
using Validation;

namespace SSO.Infra.CrossCutting.ExtensionMethods
{
    public static class BaseModelExtensions
    {
        public static bool IsNullOrInvalid([ValidatedNotNull] this BaseModel value)
        {
            return value.IsNull() || !value.Valid;
        }
    }
}
