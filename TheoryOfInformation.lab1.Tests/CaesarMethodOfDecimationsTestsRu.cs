using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheoryOfInformation.lab1.Encryptions.Models.Ciphers;

namespace TestsLab1
{
    [TestClass]
    public class CaesarMethodOfDecimationsTestsRu
    {
        private AlphabetInUse _lang = AlphabetInUse.Russian;
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NotCoPrimeKeyEncrypt()
        {
            //init
            var encrypter = new CaesarMethodOfDecimations(_lang);
            var testText = "А А2АА22А А";
            //act
            encrypter.Encrypt("3", testText);
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NotCoPrimeKeyDecrypt()
        {
            //init
            var encrypter = new CaesarMethodOfDecimations(_lang);
            var testText = "А А2АА22А А";
            //act
            encrypter.Decrypt("3", testText);
        }
        
        [TestMethod]
        public void AlphabetEncrypt()
        {
            //init
            var encrypter = new CaesarMethodOfDecimations(_lang);
            var testText = "А Б В Г Д Е Ё Ж З И Й К Л М Н О П Р С Т У Ф Х Ц Ч Ш Щ Ъ Ы Ь Э Ю Я";
            var expected = "А Е Й О У Ш Э В Ж Л Р Х Ъ Я Д И Н Т Ч Ь Б Ё К П Ф Щ Ю Г З М С Ц Ы";
            
            //act
            var actual =encrypter.Encrypt("5", testText);
            //assert
            Assert.AreEqual(expected, actual);
        }
        
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void KeyLessThenZeroEncrypt()
        {
            //init
            var encrypter = new CaesarMethodOfDecimations(_lang);
            var testText = "А А2АА22А А";
            //act
            encrypter.Encrypt("-12", testText);
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void KeyLessThenZeroDecrypt()
        {
            //init
            var encrypter = new CaesarMethodOfDecimations(_lang);
            var testText = "А А2АА22А А";
            //act
            encrypter.Decrypt("-12", testText);
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void KeyIsNullEncrypt()
        {
            //init
            var encrypter = new CaesarMethodOfDecimations(_lang);
            var testText = "А А2АА22А А";
            //act
            encrypter.Encrypt(null, testText);
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void KeyIsNullDecrypt()
        {
            //init
            var encrypter = new CaesarMethodOfDecimations(_lang);
            var testText = "А А2АА22А А";
            //act
            encrypter.Decrypt(null, testText);
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void KeyIsEmptyEncrypt()
        {
            //init
            var encrypter = new CaesarMethodOfDecimations(_lang);
            var testText = "А А2АА22А А";
            //act
            encrypter.Encrypt(string.Empty, testText);
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void KeyIsEmptyDecrypt()
        {
            //init
            var encrypter = new CaesarMethodOfDecimations(_lang);
            var testText = "А А2АА22А А";
            //act
            encrypter.Decrypt(string.Empty, testText);
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TextIsEmptyEncrypt()
        {
            //init
            var encrypter = new CaesarMethodOfDecimations(_lang);
            var testText = "";
            //act
            encrypter.Encrypt(string.Empty, testText);
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TextIsEmptyDecrypt()
        {
            //init
            var encrypter = new CaesarMethodOfDecimations(_lang);
            var testText = "";
            //act
            encrypter.Decrypt(string.Empty, testText);
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TextIsNullEncrypt()
        {
            //init
            var encrypter = new CaesarMethodOfDecimations(_lang);
            //act
            encrypter.Encrypt(string.Empty, null);
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TextIsNullDecrypt()
        {
            //init
            var encrypter = new CaesarMethodOfDecimations(_lang);
            //act
            encrypter.Decrypt(string.Empty, null);
        }
        
        [TestMethod]
        public void KeyShouldBeParsedEncrypt()
        {
            //init
            var encrypter = new CaesarMethodOfDecimations(_lang);
            var testText = "А Б В Г Д Е Ё Ж З И Й К Л М Н О П Р С Т У Ф Х Ц Ч Ш Щ Ъ Ы Ь Э Ю Я";
            var expected = "А Ь Ш Ф Р М И Е Б Э Щ Х С Н Й Ё В Ю Ъ Ц Т О К Ж Г Я Ы Ч У П Л З Д";
            //act
            var actual =encrypter.Encrypt("asdasd21sda ^&*2s3d1KL17d", testText);
            //assert
            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void KeyShouldBeParsedDecrypt()
        {
            //init
            var encrypter = new CaesarMethodOfDecimations(_lang);
            var testText ="А Ь Ш Ф Р М И Е Б Э Щ Х С Н Й Ё В Ю Ъ Ц Т О К Ж Г Я Ы Ч У П Л З Д";
            var expected ="А Б В Г Д Е Ё Ж З И Й К Л М Н О П Р С Т У Ф Х Ц Ч Ш Щ Ъ Ы Ь Э Ю Я";
            //act
            var actual =encrypter.Decrypt("asdasd21sda ^&*2s3d1KL17d", testText);
            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CorrectTestPhraseWithSpacesEncrypt()
        {
            //init
            var encrypter = new CaesarMethodOfDecimations(_lang);
            var testText = "А А2АА22А А";
            var expected = "А А2АА22А А";
            //act
            var actual = encrypter.Encrypt("5", testText);
            
            //assert
            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void TestKeyParsingDecrypt()
        {
            //init
            var encrypter = new CaesarMethodOfDecimations(_lang);
            var testText = "А А2АА22А А";
            var expected = "А А2АА22А А";
            //act
            var actual = encrypter.Decrypt("afds5ksjv", testText);
            
            //assert
            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void KeyBiggerThenAlphabetEncrypt()
        {
            //init
            var encrypter = new CaesarMethodOfDecimations(_lang);
            var testText = "А А2АА22А А";
            var expected = "А А2АА22А А";
            //act
            var actual = encrypter.Encrypt("34", testText);
            
            //assert
            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void KeyBiggerThenAlphabetDecrypt()
        {
            //init
            var encrypter = new CaesarMethodOfDecimations(_lang);
            var testText = "А А2АА22А А";
            var expected = "А А2АА22А А";
            //act
            var actual = encrypter.Decrypt("34", testText);
            
            //assert
            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void SimplePhraseEncrypt()
        {
            //init
            var encrypter = new CaesarMethodOfDecimations(_lang);
            var testText = "Привет Мир";
            var expected = "НТЛЙШЬ ЯЛТ";
            //act
            var actual = encrypter.Encrypt("5", testText);
            
            //assert
            Assert.AreEqual(expected, actual);
        }
        
        
        [TestMethod]
        public void CorrectTestLetterEncrypt()
        {
            //init
            var encrypter = new CaesarMethodOfDecimations(_lang);
            var testText = "А";
            var expected = "А";
            //act
            var actual = encrypter.Encrypt("5", testText);
            
            //assert
            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void CorrectTestLetterDecrypt()
        {
            //init
            var encrypter = new CaesarMethodOfDecimations(_lang);
            var testText = "А";
            var expected = "А";
            //act
            var actual = encrypter.Decrypt("5", testText);
            
            //assert
            Assert.AreEqual(expected, actual);
        }
        
    }
}