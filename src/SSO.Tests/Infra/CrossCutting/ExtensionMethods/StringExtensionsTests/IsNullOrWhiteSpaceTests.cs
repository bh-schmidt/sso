using NUnit.Framework;
using SSO.Infra.CrossCutting.ExtensionMethods;
using System;
using System.Collections.Generic;
using System.Text;

namespace SSO.Tests.Infra.CrossCutting.ExtensionMethods.StringExtensionsTests
{
    public class IsNullOrWhiteSpaceTests : BaseTest
    {
        [Test]
        public void WillReturnTrueBecauseIsNull()
        {
            string value = null;

            Assert.IsTrue(value.IsNullOrWhiteSpace());
        }

        [Test]
        public void WillReturnTrueBecauseIsEmpty()
        {
            string value = "";

            Assert.IsTrue(value.IsNullOrWhiteSpace());
        }

        [Test]
        public void WillReturnTrueBecauseIsWhiteSpace()
        {
            string value = " ";

            Assert.IsTrue(value.IsNullOrWhiteSpace());
        }

        [Test]
        public void WillReturnFalseBecauseContainsAValidValue()
        {
            string value = "abc";

            Assert.IsFalse(value.IsNullOrWhiteSpace());
        }
    }
}
