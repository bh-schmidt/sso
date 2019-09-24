using SSO.Domain;

namespace SSO.Infra.CrossCutting.ExtensionMethods
{
    public static class BaseModelExtensions
    {
        public static bool IsNullOrInvalid(this BaseModel value)
        {
            return value.IsNull() || !value.Valid;
        }
    }
}
