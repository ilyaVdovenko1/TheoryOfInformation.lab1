using TheoryOfInformation.lab1.ENUMS;
using TheoryOfInformation.lab1.Interfacies;

namespace TheoryOfInformation.lab1.Encryptions.Models.Ciphers
{
    public class UnknownCipher : ICipher
    {
        private Alphabet _alphabet;
        public UnknownCipher()
        {
            _alphabet = new EnglishAlphabet();
        }

        public UnknownCipher(LangIds language)
        {
            switch (language)
            {
                case LangIds.EN:
                    _alphabet = new EnglishAlphabet();
                    break;
                case LangIds.RU:
                    _alphabet = new RussianAlphabet();
                    break;
                
            }
        }
        public string Encrypt(string key, string text)
        {
            throw new System.NotImplementedException();
        }

        public string Decrypt(string key, string text)
        {
            throw new System.NotImplementedException();
        }
        
    }
}