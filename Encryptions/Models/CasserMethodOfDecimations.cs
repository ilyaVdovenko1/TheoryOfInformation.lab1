using System;
using TheoryOfInformation.lab1.Encryptions.Models.Ciphers;
using TheoryOfInformation.lab1.ENUMS;
using TheoryOfInformation.lab1.Interfacies;

namespace TheoryOfInformation.lab1.Encryptions.Models
{
    internal class CasserMethodOfDecimations : IEncryption
    {
        /*ToDo:
         * 1. Change language in cipher
         * 2. Group enums in Structs
         * 3. Refactor ctrs of this class
         * 4. Check Ui for requirements
         *
         *
         *
         *
         */
        public bool HasKey => false;

        public LangIds Lang => LangIds.RU;

        private readonly ICipher Cipher;

        public CasserMethodOfDecimations()
        {
            Cipher = CipherFactory.ProduceCipher(CiphersName.CaesarMethodOfDecimations, Lang);
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