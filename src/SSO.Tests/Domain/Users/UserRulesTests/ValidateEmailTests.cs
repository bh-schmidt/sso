using FluentValidation;
using NUnit.Framework;
using SSO.Domain.Users;
using SSO.Tests.Shared.ExtensionMethods;

namespace SSO.Tests.Domain.Users
{
    public class ValidateEmailTests:BaseTest
    {
        AbstractValidator<User> emailValidator;
        UserRules userRules  =  new UserRules();

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            emailValidator = new InlineValidator<User>();
            
            userRules.ValidateEmail(emailValidator.RuleFor(x => x.Email));
        }

        [Test]
        public void WillReturnSuccessBecauseEmailIsValid()
        {
            var user = new User() { Email = "email@email.com" };
            var result = emailValidator.Validate(user);

            Assert.IsTrue(result.IsValid);
            Assert.IsTrue(result.HasNoError());
        }

        [Test]
        public void WillReturnErrorBecauseEmailIsNull()
        { 
            var user = new User() { Email = null };

            var result = emailValidator.Validate(user);

            Assert.IsFalse(result.IsValid);
            Assert.IsTrue(result.HasError("'Email' must not be empty."));
        }

        [Test]
        public void WillReturnErrorBecauseEmailIsEmpty()
        {
            var user = new User() { Email = "" };
            var result = emailValidator.Validate(user);

            Assert.IsFalse(result.IsValid);
            Assert.IsTrue(result.HasError("'Email' must not be empty."));
        }

        [Test]
        public void WillReturnErrorBecauseEmailIsInvalid()
        {
            var user = new User() { Email = "emailInvalid" };
            var result = emailValidator.Validate(user);

            Assert.IsFalse(result.IsValid);
            Assert.IsTrue(result.HasError("'Email' is not a valid email address."));
        }
    }
}
