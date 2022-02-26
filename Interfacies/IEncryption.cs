using TheoryOfInformation.lab1.ENUMS;

namespace TheoryOfInformation.lab1.Interfacies
{
    internal interface IEncryption
    {
        string Encrypte(string text, string key);
        string Decrypte(string text, string key);
        bool HasKey { get; }
        LangIds Lang { get; }
    }
}
