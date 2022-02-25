using System;
using TheoryOfInformation.lab1.Structs;
using TheoryOfInformation.lab1.Encryptions.Models.Ciphers;

namespace TheoryOfInformation.lab1.Encryptions.Models
{
    internal class CasserMethodOfDecimations : IEncryption
    {
        public bool HasKey => false;

        public LangIds Lang => LangIds.RU;

        private readonly ICipher Cipher;

        private CasserMethodOfDecimations()
        {
            Cipher = CipherFactory.ProduceCipher(Ciphers.Ciphers.CaesarMethodOfDecimations, Lang);
        }

        public string Decrypte(string text, string key)
        {
            if (string.IsNullOrEmpty(text))
            {
                throw new ArgumentNullException(nameof(text));
            }

            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException(nameof(key));
            }

            return Cipher.Decrypt(key, text);
        }

        public string Encrypte(string text, string key)
        {
            if (string.IsNullOrEmpty(text))
            {
                throw new ArgumentNullException(nameof(text));
            }

            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException(nameof(key));
            }

            return Cipher.Encrypt(key, text);
        }

        public override string ToString()
        {
            return "Цезарь";
        }
    }
}