using FluentValidation;
using Moq;
using NUnit.Framework;
using SSO.Domain;
using SSO.Domain.Users;
using SSO.Domain.Users.InsertUsers;
using SSO.Infra.CrossCutting.ExtensionMethods;

namespace SSO.Tests.Infra.CrossCutting.ExtensionMethods.BaseModelExtensionsTests
{
    public class IsNullOrInvalidTests : BaseTest
    {
        Mock<IInsertUserContract> insertUserContract;

        [SetUp]
        public void SetUp()
        {
            insertUserContract = new Mock<IInsertUserContract>();

            AddToServiceLocator(insertUserContract);
        }

        [Test]
        public void WillReturnTrueBecauseIsNull()
        {
            BaseModel value = null;
            Assert.IsTrue(value.IsNullOrInvalid());
        }

        [Test]
        public void WillReturnTrueBecauseIsInvalid()
        {
            BaseModel value = new User();

            insertUserContract.Setup(x => x.Validate(value)).Returns(InvalidValidationResult);

            value.Validate<IInsertUserContract>(serviceLocator);

            Assert.IsTrue(value.IsNullOrInvalid());
        }

        [Test]
        public void WillReturnFalseBecauseIsValid()
        {
            BaseModel value = new User();

            insertUserContract.Setup(x => x.Validate(value)).Returns(ValidValidationResult);

            value.Validate<IInsertUserContract>(serviceLocator);

            Assert.IsFalse(value.IsNullOrInvalid());
        }
    }
}
