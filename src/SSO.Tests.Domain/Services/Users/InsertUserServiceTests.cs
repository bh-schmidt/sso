using Moq;
using NUnit.Framework;
using SSO.Domain.Models.Users;
using SSO.Domain.Services.Users;
using SSO.Infra.Data.Repositories.Users;
using SSO.Tests.Shared;
using SSO.Tests.Shared.Helpers.ExtensionMethods;

namespace SSO.Tests.Domain.Services.Users
{
    public class InsertUserServiceTests : BaseTest
    {
        Mock<IUserRepository> userRepositoryMock;
        InsertUserService insertUserService;

        [SetUp]
        public void Setup()
        {
            ResetServiceLocator();

            userRepositoryMock = new Mock<IUserRepository>();
            AddToServiceLocator(userRepositoryMock);

            insertUserService = new InsertUserService(serviceLocatorMock.Object);
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

            var insertedUser = insertUserService.Insert(user).Result;

            Assert.IsTrue(user.Valid);
            Assert.IsNotNull(user);
            userRepositoryMock.Verify(x => x.Insert(It.Is<User>(y => y.Equals(user))), Times.Once);
        }

        [Test]
        public void WillReturnNullUser()
        {
            User user = null;

            var insertedUser = insertUserService.Insert(user).Result;

            Assert.IsNull(user);
            userRepositoryMock.Verify(x => x.Insert(It.Is<User>(y => y.Equals(user))), Times.Never);
        }

        [Test]
        public void WillReturnInvalidUser()
        {
            var user = new User();

            var insertedUser = insertUserService.Insert(user).Result;

            Assert.IsTrue(user.Invalid);
            Assert.GreaterOrEqual(user.CountErrors(), 1);
            userRepositoryMock.Verify(x => x.Insert(It.Is<User>(y => y.Equals(user))), Times.Never);
        }
    }
}
