using System;
using System.Collections.Generic;
using System.Text;
using TheoryOfInformation.lab1.ENUMS;
using TheoryOfInformation.lab1.Interfacies;

namespace TheoryOfInformation.lab1.Encryptions.Models.Ciphers
{
    public class TextByColumns : ICipher
    {
        private Alphabet _alphabet;

        public TextByColumns()
        {
            _alphabet = new EnglishAlphabet();
        }

        public TextByColumns(LangIds language)
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

        public string Encrypt(string keyStr, string text)
        {
            if (string.IsNullOrEmpty(keyStr))
            {
                throw new ArgumentException("Key is empty", nameof(keyStr));
            }

            if (string.IsNullOrEmpty(text))
            {
                throw new ArgumentException("Source text is empty", nameof(text));
            }

            var key = KeyInits(ParseKey(keyStr));
            var keySorted = new int[key.Length];
            var rowsNumber = (int)Math.Round((double)text.Length / key.Length, MidpointRounding.AwayFromZero);
            Array.Copy(key, keySorted, key.Length);
            Array.Sort(keySorted);

            var table = new Dictionary<int, List<char>>();
            for (var i = 0; i < text.Length; i++)
            {
                var column = new List<char>(rowsNumber);

                for (var j = 0; j < 10; j++)
                {
                }
            }

            for (var j = 0; j < rowsNumber; j++)
            {
            }

            throw new NotImplementedException();
        }

        public string Decrypt(string key, string text)
        {
            throw new System.NotImplementedException();
        }

        private string ParseKey(string keyStr)
        {
            var keyBuilder = new StringBuilder();
            foreach (var item in keyStr)
            {
                if (_alphabet.IfCharInAlphabet(item))
                {
                    keyBuilder.Append(item);
                }
            }

            if (keyBuilder.Length == 0)
            {
                throw new ArgumentException("There are no correct chars in key string", nameof(keyStr));
            }

            return keyBuilder.ToString();
        }

        private int[] KeyInits(string key)
        {
            var keyBuilder = new List<int>();
            foreach (var letter in key)
            {
                keyBuilder.Add(_alphabet.GetCharAlphabetId(letter));
            }

            return keyBuilder.ToArray();
        }
    }
}