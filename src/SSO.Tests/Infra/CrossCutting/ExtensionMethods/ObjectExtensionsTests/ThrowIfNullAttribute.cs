using NUnit.Framework;
using SSO.Infra.CrossCutting.ExtensionMethods;

namespace SSO.Tests.Infra.CrossCutting.ExtensionMethods.ObjectExtensionsTests
{
    public class ThrowIfNullAttribute : BaseTest
    {
        [Test]
        public void WontThrowExceptionBecauseIsNotNull()
        {
            object value = new { };
            Assert.DoesNotThrow(() => value.ThrowIfNull(nameof(value)));
        }

        [Test]
        public void WillThrowExceptionBecauseIsNull()
        {
            object value = null;
            var attributeName = nameof(value);

            var exception = Assert.Catch(() => value.ThrowIfNull(attributeName));
            Assert.AreEqual(exception.Message, attributeName);
        }
    }
}
