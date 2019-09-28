using Castle.Core.Internal;
using NUnit.Framework;

namespace SSO.Tests.Infra.CrossCutting.ExtensionMethods.IEnumerableExtensionsTests
{
    public class IsNullOrEmptyTests : BaseTest
    {
        [Test]
        public void WillReturnTrueBecauseIsNull()
        {
            object[] values = null;
            Assert.IsTrue(values.IsNullOrEmpty());
        }

        [Test]
        public void WillReturnTrueBecauseIsEmpty()
        {
            object[] values = new object[] { };
            Assert.IsTrue(values.IsNullOrEmpty());
        }

        [Test]
        public void WillReturnFalseBecauseIsNotEmpty()
        {
            object[] values = new object[] { 1, 2, 3};
            Assert.IsFalse(values.IsNullOrEmpty());
        }
    }
}
