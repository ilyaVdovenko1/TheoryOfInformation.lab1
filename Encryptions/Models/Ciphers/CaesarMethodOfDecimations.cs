using System;
using System.Text;
using TheoryOfInformation.lab1.Interfacies;

namespace TheoryOfInformation.lab1.Encryptions.Models.Ciphers
{
    public class CaesarMethodOfDecimations : ICipher
    {
        private readonly Alphabet _alphabet;
        public CaesarMethodOfDecimations()
        {
            _alphabet = new EnglishAlphabet();
        }

        public CaesarMethodOfDecimations(AlphabetInUse language)
        {
            switch (language)
            {
                case AlphabetInUse.English:
                    _alphabet = new EnglishAlphabet();
                    break;
                case AlphabetInUse.Russian:
                    _alphabet = new RussianAlphabet();
                    break;
                
            }
        }
        
        public string Encrypt(string keyStr, string text)
        {
            if (keyStr is null)
            {
                throw new ArgumentNullException(nameof(keyStr));
            }

            if (string.IsNullOrEmpty(text))
            {
                throw new ArgumentException("Text is null or empty", nameof(text));
            }
            
            var key = ParseKey(keyStr);
            
            if (!IfNumbersСoPrime(_alphabet.Length, key))
            {
                throw new ArgumentException("Key value is not co prime with alphabet length", nameof(keyStr));
            }
            
            var encryptedText = new StringBuilder();

            foreach (var token in text)
            {
                var tokenAlphabetId = _alphabet.GetCharAlphabetId(token);
                if (tokenAlphabetId > _alphabet.Length || tokenAlphabetId < 0)
                {
                    encryptedText.Append(token);
                }
                else
                {
                    encryptedText.Append(_alphabet.GetCharByAlphabetId((tokenAlphabetId * key) % _alphabet.Length));
                }
            }

            return encryptedText.ToString();

        }

        public string Decrypt(string keyStr, string text)
        {
            if (keyStr is null)
            {
                throw new ArgumentNullException(nameof(keyStr));
            }

            if (string.IsNullOrEmpty(text))
            {
                throw new ArgumentException("Text is null or empty", nameof(text));
            }
            
            var key = ParseKey(keyStr);
            var decryptedText = new StringBuilder();
            var inverseKey = InverseModulo(key, _alphabet.Length);
            foreach (var token in text)
            {
                var tokenAlphabetId = _alphabet.GetCharAlphabetId(token);
                if (tokenAlphabetId > _alphabet.Length || tokenAlphabetId < 0)
                {
                    decryptedText.Append(token);
                }
                else
                {
                    decryptedText.Append(_alphabet.GetCharByAlphabetId((inverseKey * _alphabet.GetCharAlphabetId(token)) % _alphabet.Length));
                }
            }
            return decryptedText.ToString();
        }

        private int ParseKey(string keyStr)
        {
            var keyBuilder = new StringBuilder();
            foreach (var item in keyStr)
            {
                if (char.IsDigit(item))
                {
                    keyBuilder.Append(item);
                }
            }
            
            if (!int.TryParse(keyBuilder.ToString(), out var key))
            {
                throw new ArgumentException("Key is not correct", nameof(keyStr));
            }
            
            return key;
        }

        private bool IfNumbersСoPrime(int a, int b)
        {
            while (b != 0)
            {
                var temp = b;
                b = a % b;
                a = temp;
            }

            return a == 1;
        }

        private int InverseModulo(int key, int module)
        {
            var result = 0;
            var coefficient = module;
            var newResult = 1;
            var newCoefficient = key;
            while (newCoefficient != 0)
            {
                var quotient = coefficient / newCoefficient;
                (result, newResult) = (newResult, result - quotient * newResult);
                (coefficient, newCoefficient) = (newCoefficient, coefficient - quotient * newCoefficient);
            }

            if (coefficient > 1)
            {
                throw new ArgumentException("Key value is not co prime with alphabet length", nameof(key));
            }

            return result < 0 ? result + module : result;
        }
        
    }
}