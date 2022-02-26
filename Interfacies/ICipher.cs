namespace TheoryOfInformation.lab1.Interfacies
{
    public interface ICipher
    {
        string Encrypt(string key, string text);
        string Decrypt(string key, string text);
    }
}