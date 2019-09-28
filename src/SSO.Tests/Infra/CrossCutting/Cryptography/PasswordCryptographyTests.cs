using Castle.Core.Internal;
using NUnit.Framework;
using SSO.Infra.CrossCutting.Cryptography;

namespace SSO.Tests.Infra.CrossCutting.Cryptography
{
    public class PasswordCryptographyTests : BaseTest
    {
        PasswordCryptography passwordCryptography;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            passwordCryptography = new PasswordCryptography();
        }

        [Test]
        public void GenerateRandomSaltShouldReturnByteArray()
        {
            var bytes = passwordCryptography.GenerateRandomSalt(64);
            Assert.IsFalse(bytes.IsNullOrEmpty());
        }

        [Test]
        public void GenerateRandomSaltShouldReturnNull()
        {
            var bytes = passwordCryptography.GenerateRandomSalt(0);
            Assert.IsNull(bytes);
        }

        [Test]
        public void EncryptPasswordShouldReturnEncryptedPassword()
        {
            var salt = new byte[8] { 1, 21, 68, 74, 68, 26, 48, 255 };
            var password = "123456789";

            var encryptedPassword = passwordCryptography.EncryptPassword(password, salt);

            Assert.NotNull(encryptedPassword);
            Assert.AreEqual("XsW0FHEGttlb5Xd9tIx4WJ5UQ/Bxo2SeqyDVu6FwysNQjquzPG6WurAss8VsStl2+M0VWdRrFuymfeUJN2ZA+g==", encryptedPassword);
        }

        [Test]
        public void EncryptPasswordShouldReturnNullBecauseSaltIsNull()
        {
            byte[] salt = null;
            var password = "123456789";

            var encryptedPassword = passwordCryptography.EncryptPassword(password, salt);

            Assert.IsNull(encryptedPassword);
        }

        [Test]
        public void EncryptPasswordShouldReturnNullBecausePasswordIsNull()
        {
            var salt = new byte[8] { 1, 21, 68, 74, 68, 26, 48, 255 };
            string password = null;

            var encryptedPassword = passwordCryptography.EncryptPassword(password, salt);

            Assert.IsNull(encryptedPassword);
        }
    }
}
