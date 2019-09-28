namespace SSO.Infra.CrossCutting.Cryptography
{
    public interface IPasswordCryptography
    {
        byte[] GenerateRandomSalt(int byteArraySize);
        string EncryptPassword(string password, byte[] salt);
    }
}
