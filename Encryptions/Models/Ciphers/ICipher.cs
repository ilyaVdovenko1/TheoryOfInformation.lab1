namespace TheoryOfInformation.lab1.Encryptions.Models.Ciphers
{
    public interface ICipher
    {
        string Encrypt(string key, string text);
        string Decrypt(string key, string text);
    }
}