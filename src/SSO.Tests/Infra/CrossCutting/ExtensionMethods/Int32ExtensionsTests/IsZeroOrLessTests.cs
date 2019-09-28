using NUnit.Framework;
using SSO.Infra.CrossCutting.ExtensionMethods;

namespace SSO.Tests.Infra.CrossCutting.ExtensionMethods.Int32ExtensionsTests
{
    public class IsZeroOrLessTests : BaseTest
    {
        [Test]
        public void WillReturnTrueBecauseIsZero()
        {
            int value = 0;
            Assert.IsTrue(value.IsZeroOrLess());
        }

        [Test]
        public void WillReturnTrueBecauseIsLessThanZero()
        {
            int value = -1;
            Assert.IsTrue(value.IsZeroOrLess());
        }

        [Test]
        public void WillReturnFalseBecauseIsGreaterThanZero()
        {
            int value = 1;
            Assert.IsFalse(value.IsZeroOrLess());
        }
    }
}
