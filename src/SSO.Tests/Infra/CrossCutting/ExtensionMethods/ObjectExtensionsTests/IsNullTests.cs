using NUnit.Framework;
using SSO.Infra.CrossCutting.ExtensionMethods;

namespace SSO.Tests.Infra.CrossCutting.ExtensionMethods.ObjectExtensionsTests
{
    public class IsNullTests : BaseTest
    {
        [Test]
        public void WillReturnTrueBecauseObjectIsNull()
        {
            object value = null;
            Assert.IsTrue(value.IsNull());
        }

        [Test]
        public void WillReturnFalseBecauseTheObjectIsNotNull()
        {
            object value = new { };
            Assert.IsFalse(value.IsNull());
        }
    }
}
