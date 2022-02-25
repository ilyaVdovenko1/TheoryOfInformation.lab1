namespace TheoryOfInformation.lab1.Encryptions.Models.Ciphers
{
    public class WizhnersAlgorithm: ICipher
    {
        private Alphabet _alphabet;
        public WizhnersAlgorithm()
        {
            _alphabet = new EnglishAlphabet();
        }

        public WizhnersAlgorithm(AlphabetInUse language)
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