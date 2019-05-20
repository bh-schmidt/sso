using NUnit.Framework;
using SSO.Domain.Models.Users;
using SSO.Domain.Tests.Helpers.ExtensionMethods;

namespace SSO.Domain.Tests.Contracts.Users
{
    public class InsertUserContractTest : BaseTest
    {
        [Test]
        public void WillReturnValidUser()
        {
            var user = new User()
            {
                Email = "user@domain.com",
                Username = "user123",
                Password = "passwordABC123!@#"
            };

            user.ValidateToInsertUser();

            Assert.True(user.Valid);
            Assert.Zero(user.ValidationResult.Errors.Count);
        }

        [Test]
        public void WillReturnIdNotEmpty()
        {
            var user = new User()
            {
                Id = "123",
                Email = "user@domain.com",
                Username = "user123",
                Password = "passwordABC123!@#"
            };

            user.ValidateToInsertUser();

            Assert.True(user.Invalid);
            Assert.AreEqual(1, user.CountErrors());
            Assert.True(user.HasError("'Id' must be empty."));
        }

        [Test]
        public void WillReturnEmailEmpty()
        {
            var user = new User()
            {
                Email = "",
                Username = "user123",
                Password = "passwordABC123!@#"
            };

            user.ValidateToInsertUser();

            Assert.True(user.Invalid);
            Assert.AreEqual(2, user.CountErrors());
            Assert.True(user.HasError("'Email' must not be empty."));
            Assert.True(user.HasError("'Email' is not a valid email address."));
        }

        [Test]
        public void WillReturnEmailInvalid()
        {
            var user = new User()
            {
                Email = "email@",
                Username = "user123",
                Password = "passwordABC123!@#"
            };

            user.ValidateToInsertUser();

            Assert.True(user.Invalid);
            Assert.AreEqual(1, user.CountErrors());
            Assert.True(user.HasError("'Email' is not a valid email address."));
        }

        [Test]
        public void WillReturnUsernameEmpty()
        {
            var user = new User()
            {
                Email = "user@domain.com",
                Username = "",
                Password = "passwordABC123!@#"
            };

            user.ValidateToInsertUser();

            Assert.True(user.Invalid);
            Assert.AreEqual(2, user.CountErrors());
            Assert.True(user.HasError("'Username' must not be empty."));
            Assert.True(user.HasError("The length of 'Username' must be at least 6 characters. You entered 0 characters."));
        }

        [Test]
        public void WillReturnUsernameMustBeAtLeast6Characters()
        {
            var user = new User()
            {
                Email = "user@domain.com",
                Username = "user",
                Password = "passwordABC123!@#"
            };

            user.ValidateToInsertUser();

            Assert.True(user.Invalid);
            Assert.AreEqual(1, user.CountErrors());
            Assert.True(user.HasError("The length of 'Username' must be at least 6 characters. You entered 4 characters."));
        }

        [Test]
        public void WillReturnUsernameMustBe20CharactersOrFewer()
        {
            var user = new User()
            {
                Email = "user@domain.com",
                Username = "user12345678912345678",
                Password = "passwordABC123!@#"
            };

            user.ValidateToInsertUser();

            Assert.True(user.Invalid);
            Assert.AreEqual(1, user.CountErrors());
            Assert.True(user.HasError("The length of 'Username' must be 20 characters or fewer. You entered 21 characters."));
        }

        [Test]
        public void WillReturnPasswordEmpty()
        {
            Assert.Fail();
        }
    }
}
