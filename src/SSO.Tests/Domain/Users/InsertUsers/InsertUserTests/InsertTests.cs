using Moq;
using NUnit.Framework;
using SSO.Domain.Users;
using SSO.Domain.Users.InsertUsers;
using SSO.Infra.CrossCutting.Cryptography;
using SSO.Infra.Data.MongoDatabase.Repositories.Users;
using SSO.Tests.Shared.ExtensionMethods;
using System.Threading;

namespace SSO.Tests.Domain.Users.InsertUsers.InsertUserTests
{
    public class InsertTests : BaseTest
    {
        Mock<IUserRepository> userRepositoryMock;
        Mock<IUserExistsContract> userExistsContractMock;
        Mock<IInsertUserContract> insertUserContractMock;
        Mock<IPasswordCryptography> passwordCryptographyMock;
        InsertUser insertUser;

        [SetUp]
        public void Setup()
        {
            ResetServiceLocator();

            userRepositoryMock = new Mock<IUserRepository>();
            userExistsContractMock = new Mock<IUserExistsContract>();
            insertUserContractMock = new Mock<IInsertUserContract>();
            passwordCryptographyMock = new Mock<IPasswordCryptography>();

            AddToServiceLocator(userRepositoryMock);
            AddToServiceLocator(userExistsContractMock);
            AddToServiceLocator(insertUserContractMock);
            AddToServiceLocator(passwordCryptographyMock);

            insertUser = new InsertUser(serviceLocator);
        }

        [Test]
        public void WillInsertUser()
        {
            var user = new User()
            {
                Email = "user@domain.com",
                Username = "user123",
                Password = "passwordABC123!@#"
            };

            var salt = new byte[] { 1, 2, 3 };

            insertUserContractMock.Setup(x => x.Validate(It.IsAny<object>())).Returns(ValidValidationResult);
            userExistsContractMock.Setup(x => x.ValidateAsync(It.IsAny<object>(), It.IsAny<CancellationToken>())).ReturnsAsync(ValidValidationResult);
            passwordCryptographyMock.Setup(x => x.GenerateRandomSalt(It.IsAny<int>())).Returns(salt);
            passwordCryptographyMock.Setup(x => x.EncryptPassword(user.Password, salt)).Returns("987654321");

            var insertedUser = insertUser.Insert(user).Result;

            Assert.IsTrue(user.Valid);
            Assert.IsNotNull(user);
            serviceLocatorMock.Verify(x => x.Resolve<IUserRepository>(), Times.Once);
            userRepositoryMock.Verify(x => x.Insert(It.Is<User>(y => y.Equals(user))), Times.Once);
            passwordCryptographyMock.Verify(x => x.GenerateRandomSalt(It.IsAny<int>()), Times.Once);
            passwordCryptographyMock.Verify(x => x.EncryptPassword(It.IsAny<string>(), salt), Times.Once);
        }

        [Test]
        public void WillReturnNullUser()
        {
            User user = null;

            var insertedUser = insertUser.Insert(user).Result;

            Assert.IsNull(user);
            userRepositoryMock.Verify(x => x.Insert(It.Is<User>(y => y.Equals(user))), Times.Never);
        }

        [Test]
        public void WillReturnInvalidUser()
        {
            var user = new User();

            insertUserContractMock.Setup(x => x.Validate(It.IsAny<object>())).Returns(InvalidValidationResult);

            var insertedUser = insertUser.Insert(user).Result;

            Assert.IsTrue(!user.Valid);
            Assert.GreaterOrEqual(user.CountErrors(), 1);
            userRepositoryMock.Verify(x => x.Insert(It.Is<User>(y => y.Equals(user))), Times.Never);
        }
    }
}
