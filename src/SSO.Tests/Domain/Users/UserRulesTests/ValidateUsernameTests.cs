using FluentValidation;
using NUnit.Framework;
using SSO.Domain.Users;
using SSO.Tests.Shared.ExtensionMethods;
using System;
using System.Collections.Generic;
using System.Text;

namespace SSO.Tests.Domain.Users.UserRulesTests
{
    public class ValidateUsernameTests
    {
        AbstractValidator<User> userValidator;
        UserRules userRules = new UserRules();

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            userValidator = new InlineValidator<User>();

            userRules.ValidateUsername(userValidator.RuleFor(x => x.Username));
        }

        [Test]
        public void WillReturnUsernameNull()
        {
            var user = new User()
            {
                Username = null
            };

            var result = userValidator.Validate(user);

            Assert.True(!result.IsValid);
            Assert.True(result.HasError("'Username' must not be empty."));
        }

        [Test]
        public void WillReturnUsernameEmpty()
        {
            var user = new User()
            {
                Username = ""
            };

            var result = userValidator.Validate(user);

            Assert.True(!result.IsValid);
            Assert.True(result.HasError("'Username' must not be empty."));
        }

        [Test]
        public void WillReturnUsernameMustBeAtLeast6Characters()
        {
            var user = new User()  {  Username = "user" };

            var result = userValidator.Validate(user);

            Assert.True(!result.IsValid);
            Assert.True(result.HasError("The length of 'Username' must be at least 6 characters. You entered 4 characters."));
        }

        [Test]
        public void WillReturnUsernameMustBe20CharactersOrFewer()
        {
            var user = new User()
            {
                Username = "user12345678912345678"
            };

            var result = userValidator.Validate(user);

            Assert.True(!result.IsValid);
            Assert.True(result.HasError("The length of 'Username' must be 20 characters or fewer. You entered 21 characters."));
        }
    }
}
