using NUnit.Framework;
using SSO.Infra.CrossCutting.ExtensionMethods;
using System;
using System.Collections.Generic;
using System.Text;

namespace SSO.Tests.Infra.CrossCutting.ExtensionMethods.ObjectExtensionsTests
{
    public class ThrowIfNullException : BaseTest
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

            var exception = Assert.Catch(() => value.ThrowIfNull(new ArgumentException(attributeName)));
            Assert.AreEqual(exception.Message, attributeName);
        }
    }
}
