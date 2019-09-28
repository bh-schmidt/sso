using NUnit.Framework;
using SSO.Infra.CrossCutting.Cryptography;
using SSO.Infra.CrossCutting.ExtensionMethods;
using System;
using System.Collections.Generic;
using System.Text;

namespace SSO.Tests.Infra.CrossCutting.Cryptography.PasswordCryptographyTests
{
    public class GenerateRandomSaltTests : BaseTest
    {
        PasswordCryptography passwordCryptography;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            passwordCryptography = new PasswordCryptography();
        }

        [Test]
        public void WillReturnByteArray()
        {
            var bytes = passwordCryptography.GenerateRandomSalt(64);
            Assert.IsFalse(bytes.IsNullOrEmpty());
        }

        [Test]
        public void WillReturnNull()
        {
            var bytes = passwordCryptography.GenerateRandomSalt(0);
            Assert.IsNull(bytes);
        }
    }
}
