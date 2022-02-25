using System;
using TheoryOfInformation.lab1.Structs;

namespace TheoryOfInformation.lab1.Encryptions.Models.Ciphers
{
    public class CipherFactory
    {
        public static ICipher ProduceCipher(Ciphers cipherName, LangIds langIds = LangIds.EN)
        {

            AlphabetInUse lang;
            switch (langIds)
            {
                case LangIds.EN:
                    lang = AlphabetInUse.English;
                    break;
                case LangIds.RU:
                    lang = AlphabetInUse.Russian;
                    break;
                default:
                    throw new ArgumentException("There are no such language", nameof(langIds));
            }
            switch (cipherName)
            {
                case Ciphers.CaesarMethodOfDecimations:
                    return new CaesarMethodOfDecimations(lang);
                case Ciphers.TextByColumnsCipher:
                    return new TextByColumns(lang);
                case Ciphers.WizhnersAlgorithm:
                    return new WizhnersAlgorithm(lang);
                default:
                    return new UnknownCipher();
                           
            }
        }
    }
}