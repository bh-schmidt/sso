using FluentValidation;
using NUnit.Framework;
using System.Diagnostics.CodeAnalysis;

namespace SSO.Domain.Tests.Tests
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public abstract class BaseTest
    {
        public BaseTest()
        {
            ValidatorOptions.LanguageManager.Enabled = false;
        }
    }
}
