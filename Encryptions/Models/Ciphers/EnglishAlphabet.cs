using System;
using TheoryOfInformation.lab1.ENUMS;

namespace TheoryOfInformation.lab1.Encryptions.Models.Ciphers
{
    public class EnglishAlphabet : Alphabet
    {
        public EnglishAlphabet(Register register = Register.Upper)
        {
            string alphabet = "";

            switch (register)
            {
                case Register.Upper:
                    AlphabetInit("ABCDEFGHIJKLMNOPQRSTUVWXYZ");
                    break;
                case Register.Lower:
                    AlphabetInit("abcdefghijklmnopqrstuvwxyz");
                    break;
                case Register.Same:
                    throw new NotImplementedException();
            }

            Register = register;
        }
        
        
        
    }
}