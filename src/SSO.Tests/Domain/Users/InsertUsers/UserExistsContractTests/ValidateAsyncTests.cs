using Moq;
using NUnit.Framework;
using SSO.Domain.Users;
using SSO.Domain.Users.InsertUsers;
using SSO.Infra.Data.MongoDatabase.Repositories.Users;
using SSO.Tests.Shared.ExtensionMethods;
using System.Threading.Tasks;

namespace SSO.Tests.Domain.Users.InsertUsers.UserExistsContractTests
{
    public class ValidateAsyncTests : BaseTest
    {
        Mock<IUserRepository> userRepositoryMock;

        [SetUp]
        public void Setup()
        {
            ResetServiceLocator();

            userRepositoryMock = new Mock<IUserRepository>();
            AddToServiceLocator(userRepositoryMock);
            AddToServiceLocator<IUserExistsContract>(new UserExistsContract(serviceLocator));
        }

        [Test]
        public async Task WillReturnUserValid()
        {
            var user = new User()
            {
                Email = "user@domain.com",
                Username = "user123",
                Password = "passwordABC123!@#"
            };

            await user.ValidateAsync<IUserExistsContract>(serviceLocator);

            Assert.True(user.Valid);
            Assert.Zero(user.CountErrors());
        }

        [Test]
        public async Task WillReturnEmailAlreadyExists()
        {
            var user = new User()
            {
                Email = "user@domain.com",
                Username = "user123",
                Password = "passwordABC123!@#"
            };

            userRepositoryMock.Setup(x => x.EmailExists(user.Email)).ReturnsAsync(true);

            await user.ValidateAsync<IUserExistsContract>(serviceLocator);

            Assert.True(!user.Valid);
            Assert.True(user.HasError("This email already exists."));
            Assert.NotZero(user.CountErrors());
        }

        [Test]
        public async Task WillReturnUsernameAlreadyExists()
        {
            var user = new User()
            {
                Email = "user@domain.com",
                Username = "user123",
                Password = "passwordABC123!@#"
            };

            userRepositoryMock.Setup(x => x.UsernameExists(user.Username)).ReturnsAsync(true);

            await user.ValidateAsync<IUserExistsContract>(serviceLocator);

            Assert.True(!user.Valid);
            Assert.True(user.HasError("This username already exists."));
            Assert.NotZero(user.CountErrors());
        }
    }
}
