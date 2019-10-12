using Moq;
using NUnit.Framework;
using SSO.Domain;
using SSO.Domain.Users;
using SSO.Domain.Users.InsertUsers;
using SSO.Tests.Shared.ExtensionMethods;
using System;

namespace SSO.Tests.Domain.Users.InsertUsers.InsertUserContractTests
{
    public class ValidateTests : BaseTest
    {
        Mock<IUserRules> userRulesMock;
        Mock<IBaseModelRules> baseModelRulesMock;

        [SetUp]
        public void Setup()
        {
            ResetServiceLocator();
        }

        [Test]
        public void WillAddRulesToContract()
        {
            userRulesMock = new Mock<IUserRules>();
            baseModelRulesMock = new Mock<IBaseModelRules>();

            AddToServiceLocator(userRulesMock.Object);
            AddToServiceLocator(baseModelRulesMock.Object);

            new InsertUserContract(serviceLocator);

            baseModelRulesMock.Verify(x => x.ValidateIdToInsert(It.IsAny<FluentValidation.IRuleBuilder<User, string>>()), Times.Once);
            userRulesMock.Verify(x => x.ValidateEmail(It.IsAny<FluentValidation.IRuleBuilder<User, string>>()), Times.Once);
            userRulesMock.Verify(x => x.ValidateUsername(It.IsAny<FluentValidation.IRuleBuilder<User, string>>()), Times.Once);
            userRulesMock.Verify(x => x.ValidatePassword(It.IsAny<FluentValidation.IRuleBuilder<User, string>>()), Times.Once);
        }

        [Test]
        public void WillThrowBaseModelRulesNull()
        {
            baseModelRulesMock = new Mock<IBaseModelRules>();
            userRulesMock = new Mock<IUserRules>();

            AddToServiceLocator(userRulesMock.Object);

            var exception = Assert.Catch(() =>
            {
                new InsertUserContract(serviceLocator);
            });

            Assert.IsInstanceOf<ArgumentNullException>(exception);
            Assert.AreEqual("Value cannot be null. (Parameter 'baseModelRules')", exception.Message);
            baseModelRulesMock.Verify(x => x.ValidateIdToInsert(It.IsAny<FluentValidation.IRuleBuilder<User, string>>()), Times.Never);
            userRulesMock.Verify(x => x.ValidateEmail(It.IsAny<FluentValidation.IRuleBuilder<User, string>>()), Times.Never);
            userRulesMock.Verify(x => x.ValidateUsername(It.IsAny<FluentValidation.IRuleBuilder<User, string>>()), Times.Never);
            userRulesMock.Verify(x => x.ValidatePassword(It.IsAny<FluentValidation.IRuleBuilder<User, string>>()), Times.Never);
        }

        [Test]
        public void WillThrowUserRulesNull()
        {
            baseModelRulesMock = new Mock<IBaseModelRules>();
            userRulesMock = new Mock<IUserRules>();

            AddToServiceLocator(baseModelRulesMock.Object);

            var exception = Assert.Catch(() =>
            {
                new InsertUserContract(serviceLocator);
            });

            Assert.IsInstanceOf<ArgumentNullException>(exception);
            Assert.AreEqual("Value cannot be null. (Parameter 'userRules')", exception.Message);
            baseModelRulesMock.Verify(x => x.ValidateIdToInsert(It.IsAny<FluentValidation.IRuleBuilder<User, string>>()), Times.Never);
            userRulesMock.Verify(x => x.ValidateEmail(It.IsAny<FluentValidation.IRuleBuilder<User, string>>()), Times.Never);
            userRulesMock.Verify(x => x.ValidateUsername(It.IsAny<FluentValidation.IRuleBuilder<User, string>>()), Times.Never);
            userRulesMock.Verify(x => x.ValidatePassword(It.IsAny<FluentValidation.IRuleBuilder<User, string>>()), Times.Never);
        }
    }
}
