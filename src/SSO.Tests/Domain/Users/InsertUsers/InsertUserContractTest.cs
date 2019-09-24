using NUnit.Framework;
using SSO.Domain.Users;
using SSO.Domain.Users.InsertUsers;
using SSO.Tests.Shared.ExtensionMethods;

namespace SSO.Tests.Domain.Models.Contracts.Users
{
    public class InsertUserContractTest : BaseTest
    {
        [SetUp]
        public void Setup()
        {
            ResetServiceLocator();

            AddToServiceLocator<IInsertUserContract>(new InsertUserContract());
        }

        [Test]
        public void WillReturnValidUser()
        {
            var user = new User()
            {
                Email = "user@domain.com",
                Username = "user123",
                Password = "passwordABC123!@#"
            };

            user.Validate<IInsertUserContract>(serviceLocator);

            Assert.True(user.Valid);
            Assert.Zero(user.CountErrors());
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

            user.Validate<IInsertUserContract>(serviceLocator);

            Assert.True(!user.Valid);
            Assert.True(user.HasError("'Id' must be empty."));
        }

        [Test]
        public void WillReturnEmailNull()
        {
            var user = new User()
            {
                Email = null,
                Username = "user123",
                Password = "passwordABC123!@#"
            };

            user.Validate<IInsertUserContract>(serviceLocator);

            Assert.True(!user.Valid);
            Assert.True(user.HasError("'Email' must not be empty."));
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

            user.Validate<IInsertUserContract>(serviceLocator);

            Assert.True(!user.Valid);
            Assert.True(user.HasError("'Email' must not be empty."));
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

            user.Validate<IInsertUserContract>(serviceLocator);

            Assert.True(!user.Valid);
            Assert.True(user.HasError("'Email' is not a valid email address."));
        }

        [Test]
        public void WillReturnUsernameNull()
        {
            var user = new User()
            {
                Email = "user@domain.com",
                Username = null,
                Password = "passwordABC123!@#"
            };

            user.Validate<IInsertUserContract>(serviceLocator);

            Assert.True(!user.Valid);
            Assert.True(user.HasError("'Username' must not be empty."));
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

            user.Validate<IInsertUserContract>(serviceLocator);

            Assert.True(!user.Valid);
            Assert.True(user.HasError("'Username' must not be empty."));
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

            user.Validate<IInsertUserContract>(serviceLocator);

            Assert.True(!user.Valid);
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

            user.Validate<IInsertUserContract>(serviceLocator);

            Assert.True(!user.Valid);
            Assert.True(user.HasError("The length of 'Username' must be 20 characters or fewer. You entered 21 characters."));
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

            user.Validate<IInsertUserContract>(serviceLocator);

            Assert.True(!user.Valid);
            Assert.GreaterOrEqual(user.CountErrors(), 1);
            Assert.IsTrue(user.HasError("'Password' must not be empty."));
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

            user.Validate<IInsertUserContract>(serviceLocator);

            Assert.True(!user.Valid);
            Assert.GreaterOrEqual(user.CountErrors(), 1);
            Assert.IsTrue(user.HasError("'Password' must not be empty."));
        }

        public void WillReturnPasswordMustBeAtLeast8Characters()
        {
            var user = new User()
            {
                Email = "user@domain.com",
                Username = "user123",
                Password = "1234567"
            };

            user.Validate<IInsertUserContract>(serviceLocator);

            Assert.True(!user.Valid);
            Assert.GreaterOrEqual(user.CountErrors(), 1);
            Assert.GreaterOrEqual(user.CountErrors(), 1);
            Assert.IsTrue(user.HasError("The length of 'Password' must be at least 8 characters. You entered 7 characters."));
        }

        public void WillReturnPasswordMustBe30CharactersOrFewer()
        {
            var user = new User()
            {
                Email = "user@domain.com",
                Username = "user123",
                Password = "1234567891234567891234567891234"
            };

            user.Validate<IInsertUserContract>(serviceLocator);

            Assert.True(!user.Valid);
            Assert.GreaterOrEqual(user.CountErrors(), 1);
            Assert.IsTrue(user.HasError("The length of 'Password' must be 30 characters or fewer. You entered 31 characters."));
        }

        public void WillReturnPasswordNeedsAtLeastOneLowerCaseLetter()
        {
            var user = new User()
            {
                Email = "user@domain.com",
                Username = "user123",
                Password = "ABC123!@#"
            };

            user.Validate<IInsertUserContract>(serviceLocator);

            Assert.True(!user.Valid);
            Assert.GreaterOrEqual(user.CountErrors(), 1);
            Assert.IsTrue(user.HasError("The password needs at least 1 lower case letter."));
        }

        public void WillReturnPasswordNeedsAtLeastOneUpperCaseLetter()
        {
            var user = new User()
            {
                Email = "user@domain.com",
                Username = "user123",
                Password = "password123!@#"
            };

            user.Validate<IInsertUserContract>(serviceLocator);

            Assert.True(!user.Valid);
            Assert.GreaterOrEqual(user.CountErrors(), 1);
            Assert.IsTrue(user.HasError("The password needs at least 1 upper case letter."));
        }

        public void WillReturnPasswordNeedsAtLeastOneNumericDigit()
        {
            var user = new User()
            {
                Email = "user@domain.com",
                Username = "user123",
                Password = "passwordABC!@#"
            };

            user.Validate<IInsertUserContract>(serviceLocator);

            Assert.True(!user.Valid);
            Assert.GreaterOrEqual(user.CountErrors(), 1);
            Assert.IsTrue(user.HasError("The password needs at least 1 numeric digit."));
        }

        public void WillReturnPasswordNeedsAtLeastOneSpecialCharacter()
        {
            var user = new User()
            {
                Email = "user@domain.com",
                Username = "user123",
                Password = "passwordABC123"
            };

            user.Validate<IInsertUserContract>(serviceLocator);

            Assert.True(!user.Valid);
            Assert.GreaterOrEqual(user.CountErrors(), 1);
            Assert.IsTrue(user.HasError("The password needs at least 1 special character."));
        }
    }
}
