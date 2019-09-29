using NUnit.Framework;
using SSO.Infra.CrossCutting.ExtensionMethods;
using System;
using System.Collections.Generic;
using System.Text;

namespace SSO.Tests.Infra.CrossCutting.ExtensionMethods.IEnumerableExtensionsTests
{
    public class ThrowIfNullOrEmptyException : BaseTest
    {
        [Test]
        public void WontThrowBecauseIsNotNullNorEmpty()
        {
            byte[] value = new byte[] { 1, 2, 3 };
            var attributeName = nameof(value);

            Assert.DoesNotThrow(() => value.ThrowIfNullOrEmpty(new ArgumentException(attributeName)));
        }

        [Test]
        public void WillThrowExceptionBecauseIsNull()
        {
            byte[] value = null;
            var attributeName = nameof(value);

            var exception = Assert.Catch(() => value.ThrowIfNullOrEmpty(new ArgumentException(attributeName)));
            Assert.AreEqual(exception.Message, attributeName);
        }

        [Test]
        public void WillThrowExceptionBecauseIsEmpty()
        {
            byte[] value = Array.Empty<byte>();
            var attributeName = nameof(value);

            var exception = Assert.Catch(() => value.ThrowIfNullOrEmpty(new ArgumentException(attributeName)));
            Assert.AreEqual(exception.Message, attributeName);
        }
    }
}
