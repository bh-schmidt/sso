using SSO.Domain.Models;
using System.Linq;

namespace SSO.Domain.Tests.Helpers.ExtensionMethods
{
    public static class BaseModelExtensions
    {
        public static int CountErrors(this BaseModel baseModel)
        {
            return baseModel.ValidationResult.Errors.Count;
        }

        public static bool HasError(this BaseModel baseModel, string message)
        {
            return baseModel.ValidationResult.Errors.Any(x => x.ErrorMessage == message);
        }

        public static bool HasError(this BaseModel baseModel, string code, string message)
        {
            return baseModel.ValidationResult.Errors.Any(x => x.ErrorMessage == message && x.ErrorCode == code);
        }
    }
}
