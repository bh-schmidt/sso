using Api.Infra.CrossCutting.ExtensionMethods;
using Api.Infra.CrossCutting.IoC.ServiceLocator;
using FluentValidation;
using Moq;
using NUnit.Framework;
using System.Diagnostics.CodeAnalysis;

namespace SSO.Tests.Shared
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public abstract class BaseTest
    {
        protected Mock<IServiceLocator> serviceLocatorMock;

        public BaseTest()
        {
            ValidatorOptions.LanguageManager.Enabled = false;
        }

        protected void ResetServiceLocator()
        {
            serviceLocatorMock = new Mock<IServiceLocator>();
        }

        protected void AddToServiceLocator<T>(Mock<T> mock) where T : class
        {
            if (serviceLocatorMock.IsNull())
            {
                ResetServiceLocator();
            }

            if (mock.IsNotNull())
            {
                serviceLocatorMock.Setup(x => x.Resolve<T>()).Returns(mock.Object);
            }
        }
    }
}
