using FluentValidation;
using NUnit.Framework;
using SSO.Domain.Users;
using SSO.Tests.Shared.ExtensionMethods;
using SSO.Tests.Shared.Models;

namespace SSO.Tests.Domain.Users
{
    public class UserRulesTests:BaseTest
    {
        AbstractValidator<TestModel<string>> emailValidator;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            emailValidator = new InlineValidator<TestModel<string>>();
            emailValidator.RuleFor(x => x.Property)
                .ValidateEmail();
        }

        [Test]
        public void WillReturnSuccessBecauseEmailIsValid()
        {
            var emailModel = new TestModel<string>("email@email.com");
            var result = emailValidator.Validate(emailModel);

            Assert.IsTrue(result.IsValid);
            Assert.IsTrue(result.HasNoError());
        }

        [Test]
        public void WillReturnErrorBecauseEmailIsNull()
        {
            var emailModel = new TestModel<string>(null as string);

            var result = emailValidator.Validate(emailModel);

            Assert.IsFalse(result.IsValid);
            Assert.IsTrue(result.HasError("'Property' must not be empty."));
        }

        [Test]
        public void WillReturnErrorBecauseEmailIsEmpty()
        {
            var emailModel = new TestModel<string>("");
            var result = emailValidator.Validate(emailModel);

            Assert.IsFalse(result.IsValid);
            Assert.IsTrue(result.HasError("'Property' must not be empty."));
        }

        [Test]
        public void WillReturnErrorBecauseEmailIsInvalid()
        {
            var emailModel = new TestModel<string>("emailInvalid");
            var result = emailValidator.Validate(emailModel);

            Assert.IsFalse(result.IsValid);
            Assert.IsTrue(result.HasError("'Property' is not a valid email address."));
        }
    }
}
