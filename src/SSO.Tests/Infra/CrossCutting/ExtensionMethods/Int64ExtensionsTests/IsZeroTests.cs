using NUnit.Framework;
using SSO.Infra.CrossCutting.ExtensionMethods;

namespace SSO.Tests.Infra.CrossCutting.ExtensionMethods.Int64ExtensionsTests
{
    public class IsZeroTests : BaseTest
    {
        [Test]
        public void WillReturnTrueBecauseTheNumberIsZero()
        {
            long value = 0;
            Assert.IsTrue(value.IsZero());
        }

        [Test]
        public void WillReturnFalseBecauseTheNumberIsNotZero()
        {
            long value = 1;
            Assert.IsFalse(value.IsZero());
        }
    }
}
