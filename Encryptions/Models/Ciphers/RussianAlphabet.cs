using System;

namespace TheoryOfInformation.lab1.Encryptions.Models.Ciphers
{
    public class RussianAlphabet : Alphabet
    {
        public RussianAlphabet(Register register = Register.Upper)
        {
            string alphabet = "";

            switch (register)
            {
                case Register.Upper:
                    AlphabetInit("АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ");
                    break;
                case Register.Lower:
                    AlphabetInit("абвгдеёжзийклмнопрстуфхцчшщъыьэюя");
                    break;
                case Register.Same:
                    throw new NotImplementedException();
            }
            
            Register = register;
        }
        
        
        
    }
}