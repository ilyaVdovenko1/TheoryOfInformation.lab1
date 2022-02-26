using TheoryOfInformation.lab1.Interfacies;
using TheoryOfInformation.lab1.ENUMS;

namespace TheoryOfInformation.lab1.Encryptions.Models.Ciphers
{
    public class CipherFactory
    {
        public static ICipher ProduceCipher(CiphersName cipherName, LangIds langId = LangIds.EN)
        {

            switch (cipherName)
            {
                case CiphersName.CaesarMethodOfDecimations:
                    return new CaesarMethodOfDecimations(langId);
                case CiphersName.TextByColumnsCipher:
                    return new TextByColumns(langId);
                case CiphersName.WizhnersAlgorithm:
                    return new WizhnersAlgorithm(langId);
                default:
                    return new UnknownCipher();
                           
            }
        }
    }
}