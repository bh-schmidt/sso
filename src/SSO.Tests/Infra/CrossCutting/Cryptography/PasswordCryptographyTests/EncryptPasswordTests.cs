using NUnit.Framework;
using SSO.Infra.CrossCutting.Cryptography;

namespace SSO.Tests.Infra.CrossCutting.Cryptography.PasswordCryptographyTests
{
    public class EncryptPasswordTests : BaseTest
    {
        PasswordCryptography passwordCryptography;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            passwordCryptography = new PasswordCryptography();
        }

        [Test]
        public void WillReturnEncryptedPassword()
        {
            var salt = new byte[8] { 1, 21, 68, 74, 68, 26, 48, 255 };
            var password = "123456789";

            var encryptedPassword = passwordCryptography.EncryptPassword(password, salt);

            Assert.NotNull(encryptedPassword);
            Assert.AreEqual("XsW0FHEGttlb5Xd9tIx4WJ5UQ/Bxo2SeqyDVu6FwysNQjquzPG6WurAss8VsStl2+M0VWdRrFuymfeUJN2ZA+g==", encryptedPassword);
        }

        [Test]
        public void WillReturnNullBecauseSaltIsNull()
        {
            byte[] salt = null;
            var password = "123456789";

            var encryptedPassword = passwordCryptography.EncryptPassword(password, salt);

            Assert.IsNull(encryptedPassword);
        }

        [Test]
        public void WillReturnNullBecausePasswordIsNull()
        {
            var salt = new byte[8] { 1, 21, 68, 74, 68, 26, 48, 255 };
            string password = null;

            var encryptedPassword = passwordCryptography.EncryptPassword(password, salt);

            Assert.IsNull(encryptedPassword);
        }
    }
}
