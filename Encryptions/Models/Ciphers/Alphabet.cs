using System;
using System.Collections.Generic;
using TheoryOfInformation.lab1.ENUMS;

namespace TheoryOfInformation.lab1.Encryptions.Models.Ciphers
{
    public abstract class Alphabet
    {
        protected Dictionary<char, int> AlphabetLetterToId;
        protected string AlphabetIdToLetter;
        protected Register Register;
        protected HashSet<char> CharsSetInAlphabet;

        public int Length { get; protected set; }

        public int GetCharAlphabetId(char c)
        {
            try
            {
                if (char.IsLower(c) && Register is Register.Upper)
                {
                    c = char.ToUpper(c);
                }
                else if (char.IsUpper(c) && Register is Register.Lower)
                {
                    c = char.ToLower(c);
                }
                return AlphabetLetterToId[c];
            }
            catch (KeyNotFoundException)
            {
                return -1;
            }
        }

        public char GetCharByAlphabetId(int id)
        {
            if (id < 0 || id > AlphabetIdToLetter.Length - 1)
            {
                throw new ArgumentOutOfRangeException(nameof(id));
            }

            return AlphabetIdToLetter[id];
        }

        public bool IfCharInAlphabet(char c)
        {
            if (char.IsLower(c) && Register is Register.Upper)
            {
                c = char.ToUpper(c);
            }
            else if (char.IsUpper(c) && Register is Register.Lower)
            {
                c = char.ToLower(c);
            }
            return CharsSetInAlphabet.Contains(c);
        }

        protected void AlphabetInit(string alphabet)
        {
            if (string.IsNullOrEmpty(alphabet))
            {
                throw new ArgumentException("Alphabet is empty", nameof(alphabet));
            }
            AlphabetIdToLetter = alphabet;
            AlphabetLetterToId = new Dictionary<char, int>();

            for (int i = 0; i < alphabet.Length; i++)
            {
                AlphabetLetterToId.Add(alphabet[i], i);
            }

            Length = alphabet.Length;
        }
    }
}