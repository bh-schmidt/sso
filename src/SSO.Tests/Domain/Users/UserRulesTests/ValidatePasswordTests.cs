using FluentValidation;
using NUnit.Framework;
using SSO.Domain.Users;
using SSO.Tests.Shared.ExtensionMethods;
using System;
using System.Collections.Generic;
using System.Text;

namespace SSO.Tests.Domain.Users.UserRulesTests
{
    public class ValidatePasswordTests
    {
        AbstractValidator<User> passwordValidator;
        UserRules userRules = new UserRules();

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            passwordValidator = new InlineValidator<User>();

            userRules.ValidatePassword(passwordValidator.RuleFor(x => x.Password));
        }

        [Test]
        public void WillReturnPasswordNull()
        {
            var user = new User()
            {
                Email = "user@domain.com",
                Username = "user123",
                Password = null
            };

            var result = passwordValidator.Validate(user);

            Assert.True(!result.IsValid);
            Assert.GreaterOrEqual(result.CountErrors(), 1);
            Assert.IsTrue(result.HasError("'Password' must not be empty."));
        }

        [Test]
        public void WillReturnPasswordEmpty()
        {
            var user = new User()
            {
                Email = "user@domain.com",
                Username = "user123",
                Password = ""
            };

            var result = passwordValidator.Validate(user);

            Assert.True(!result.IsValid);
            Assert.GreaterOrEqual(result.CountErrors(), 1);
            Assert.IsTrue(result.HasError("'Password' must not be empty."));
        }

        public void WillReturnPasswordMustBeAtLeast8Characters()
        {
            var user = new User()
            {
                Email = "user@domain.com",
                Username = "user123",
                Password = "1234567"
            };

            var result = passwordValidator.Validate(user);

            Assert.True(!result.IsValid);
            Assert.GreaterOrEqual(result.CountErrors(), 1);
            Assert.GreaterOrEqual(result.CountErrors(), 1);
            Assert.IsTrue(result.HasError("The length of 'Password' must be at least 8 characters. You entered 7 characters."));
        }

        public void WillReturnPasswordMustBe30CharactersOrFewer()
        {
            var user = new User()
            {
                Email = "user@domain.com",
                Username = "user123",
                Password = "1234567891234567891234567891234"
            };

            var result = passwordValidator.Validate(user);

            Assert.True(!result.IsValid);
            Assert.GreaterOrEqual(result.CountErrors(), 1);
            Assert.IsTrue(result.HasError("The length of 'Password' must be 30 characters or fewer. You entered 31 characters."));
        }

        public void WillReturnPasswordNeedsAtLeastOneLowerCaseLetter()
        {
            var user = new User()
            {
                Email = "user@domain.com",
                Username = "user123",
                Password = "ABC123!@#"
            };

            var result = passwordValidator.Validate(user);

            Assert.True(!result.IsValid);
            Assert.GreaterOrEqual(result.CountErrors(), 1);
            Assert.IsTrue(result.HasError("The password needs at least 1 lower case letter."));
        }

        public void WillReturnPasswordNeedsAtLeastOneUpperCaseLetter()
        {
            var user = new User()
            {
                Email = "user@domain.com",
                Username = "user123",
                Password = "password123!@#"
            };

            var result = passwordValidator.Validate(user);

            Assert.True(!result.IsValid);
            Assert.GreaterOrEqual(result.CountErrors(), 1);
            Assert.IsTrue(result.HasError("The password needs at least 1 upper case letter."));
        }

        public void WillReturnPasswordNeedsAtLeastOneNumericDigit()
        {
            var user = new User()
            {
                Email = "user@domain.com",
                Username = "user123",
                Password = "passwordABC!@#"
            };

            var result = passwordValidator.Validate(user);

            Assert.True(!result.IsValid);
            Assert.GreaterOrEqual(result.CountErrors(), 1);
            Assert.IsTrue(result.HasError("The password needs at least 1 numeric digit."));
        }

        public void WillReturnPasswordNeedsAtLeastOneSpecialCharacter()
        {
            var user = new User()
            {
                Email = "user@domain.com",
                Username = "user123",
                Password = "passwordABC123"
            };

            var result = passwordValidator.Validate(user);

            Assert.True(!result.IsValid);
            Assert.GreaterOrEqual(result.CountErrors(), 1);
            Assert.IsTrue(result.HasError("The password needs at least 1 special character."));
        }
    }
}
