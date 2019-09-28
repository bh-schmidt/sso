using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using SSO.Infra.CrossCutting.ExtensionMethods;
using System;
using System.Security.Cryptography;

namespace SSO.Infra.CrossCutting.Cryptography
{
    public class PasswordCryptography : IPasswordCryptography
    {
        private const int IterationCount = 9573;
        private const int BytesRequested = 64;

        public byte[] GenerateRandomSalt(int byteArraySize)
        {
            if (byteArraySize.IsZeroOrLess())
            {
                return null;
            }

            byte[] salt = new byte[byteArraySize];

            using (var saltGenerator = RandomNumberGenerator.Create())
            {
                saltGenerator.GetBytes(salt);
            }

            return salt;
        }

        public string EncryptPassword(string password, byte[] salt)
        {
            if (password.IsNullOrWhiteSpace() || salt.IsNull())
            {
                return null;
            }

            var hash = KeyDerivation.Pbkdf2(password, salt, KeyDerivationPrf.HMACSHA1, IterationCount, BytesRequested);

            return Convert.ToBase64String(hash);
        }
    }
}
