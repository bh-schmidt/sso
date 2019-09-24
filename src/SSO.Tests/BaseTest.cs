using FluentValidation;
using FluentValidation.Results;
using Moq;
using NUnit.Framework;
using SSO.Infra.CrossCutting.ExtensionMethods;
using SSO.Infra.CrossCutting.IoC.ServiceLocator;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace SSO.Tests
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public abstract class BaseTest
    {
        protected Mock<IServiceLocator> serviceLocatorMock;
        protected IServiceLocator serviceLocator => serviceLocatorMock?.Object;

        public BaseTest()
        {
            ValidatorOptions.LanguageManager.Enabled = false;
        }

        protected void ResetServiceLocator()
        {
            serviceLocatorMock = new Mock<IServiceLocator>();
        }

        protected void AddToServiceLocator<TInterface>(Mock<TInterface> mock) where TInterface : class
        {
            if (serviceLocatorMock.IsNull())
            {
                ResetServiceLocator();
            }

            if (!mock.IsNull())
            {
                serviceLocatorMock.Setup(x => x.Resolve<TInterface>()).Returns(mock.Object);
            }
        }

        protected void AddToServiceLocator<TInterface>(TInterface value) where TInterface : class
        {
            if (serviceLocatorMock.IsNull())
            {
                ResetServiceLocator();
            }

            if (!value.IsNull())
            {
                serviceLocatorMock.Setup(x => x.Resolve<TInterface>()).Returns(value);
            }
        }

        protected ValidationResult ValidValidationResult = new ValidationResult();
        protected ValidationResult InvalidValidationResult = new ValidationResult(new List<ValidationFailure>() {
            new ValidationFailure("Test","Test Message")
        });
    }
}
