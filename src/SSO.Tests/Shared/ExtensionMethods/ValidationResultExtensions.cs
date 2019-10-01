using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SSO.Tests.Shared.ExtensionMethods
{
    public static class ValidationResultExtensions
    {
        public static int CountErrors(this ValidationResult validation)
        {
            var count = validation?.Errors?.Count;
            return count ?? 0;
        }

        public static bool HasError(this ValidationResult validation, string message)
        {
            return validation.Errors.Any(x => x.ErrorMessage == message);
        }

        public static bool HasNoError(this ValidationResult validation)
        {
            return !validation.Errors.Any();
        }
    }
}
