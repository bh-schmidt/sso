using SSO.Domain;
using System.Linq;

namespace SSO.Tests.Shared.ExtensionMethods
{
    public static class BaseModelExtensions
    {
        public static int CountErrors(this BaseModel baseModel)
        {
            var count = baseModel?.ValidationResult?.Errors?.Count;
            return count.HasValue ? count.Value : 0;
        }

        public static bool HasError(this BaseModel baseModel, string message)
        {
            return baseModel.ValidationResult.Errors.Any(x => x.ErrorMessage == message);
        }
    }
}
