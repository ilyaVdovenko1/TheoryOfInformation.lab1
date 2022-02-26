using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheoryOfInformation.lab1.Encryptions.Models.Ciphers;
using TheoryOfInformation.lab1.ENUMS;

namespace TheoryOfInformation.lab1.Tests
{
    [TestClass]
    public class CaesarMethodOfDecimationsTests
    {
        private LangIds _lang = LangIds.EN;
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NotCoPrimeKeyEncrypt()
        {
            //init
            var encrypter = new CaesarMethodOfDecimations();
            var testText = "A A2AA22A A";
            //act
            encrypter.Encrypt("2", testText);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NotCoPrimeKeyDecrypt()
        {
            //init
            var encrypter = new CaesarMethodOfDecimations();
            var testText = "A A2AA22A A";
            //act
            encrypter.Decrypt("2", testText);
        }

        [TestMethod]
        public void AlphabetDecrypt()
        {
            //init
            var encrypter = new CaesarMethodOfDecimations();
            var testText = "A F K P U Z E J O T Y D I N S X C H M R W B G L Q V";
            var expected = "A B C D E F G H I J K L M N O P Q R S T U V W X Y Z";

            //act
            var actual = encrypter.Decrypt("5", testText);
            //assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void KeyLessThenZeroEncrypt()
        {
            //init
            var encrypter = new CaesarMethodOfDecimations();
            var testText = "A A2AA22A A";
            //act
            encrypter.Encrypt("-12", testText);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void KeyLessThenZeroDecrypt()
        {
            //init
            var encrypter = new CaesarMethodOfDecimations();
            var testText = "A A2AA22A A";
            //act
            encrypter.Encrypt("-12", testText);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void KeyIsNullEncrypt()
        {
            //init
            var encrypter = new CaesarMethodOfDecimations();
            var testText = "A A2AA22A A";
            //act
            encrypter.Encrypt(null, testText);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void KeyIsNullDecrypt()
        {
            //init
            var encrypter = new CaesarMethodOfDecimations();
            var testText = "A A2AA22A A";
            //act
            encrypter.Decrypt(null, testText);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void KeyIsEmptyEncrypt()
        {
            //init
            var encrypter = new CaesarMethodOfDecimations();
            var testText = "A A2AA22A A";
            //act
            encrypter.Encrypt(string.Empty, testText);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void KeyIsEmptyDecrypt()
        {
            //init
            var encrypter = new CaesarMethodOfDecimations();
            var testText = "A A2AA22A A";
            //act
            encrypter.Decrypt(string.Empty, testText);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TextIsEmptyEncrypt()
        {
            //init
            var encrypter = new CaesarMethodOfDecimations();
            var testText = "";
            //act
            encrypter.Encrypt(string.Empty, testText);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TextIsEmptyDecrypt()
        {
            //init
            var encrypter = new CaesarMethodOfDecimations();
            var testText = "";
            //act
            encrypter.Decrypt(string.Empty, testText);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TextIsNullEncrypt()
        {
            //init
            var encrypter = new CaesarMethodOfDecimations();
            //act
            encrypter.Encrypt(string.Empty, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TextIsNullDecrypt()
        {
            //init
            var encrypter = new CaesarMethodOfDecimations();
            //act
            encrypter.Decrypt(string.Empty, null);
        }

        [TestMethod]
        public void KeyShouldBeParsedEncrypt()
        {
            //init
            var encrypter = new CaesarMethodOfDecimations();
            var testText = "A B C D E F G H I J K L M N O P Q R S T U V W X Y Z";
            var expected = "A X U R O L I F C Z W T Q N K H E B Y V S P M J G D";
            //act
            var actual = encrypter.Encrypt("asdasd21sda ^&*2s3d1s3d", testText);
            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void KeyShouldBeParsedDecrypt()
        {
            //init
            var encrypter = new CaesarMethodOfDecimations();
            var testText = "A X U R O L I F C Z W T Q N K H E B Y V S P M J G D";
            var expected = "A B C D E F G H I J K L M N O P Q R S T U V W X Y Z";
            //act
            var actual = encrypter.Decrypt("asdasd21sda ^&*2s3d1s3d", testText);
            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CorrectTestPhraseWithSpacesEncrypt()
        {
            //init
            var encrypter = new CaesarMethodOfDecimations();
            var testText = "A AAAA A";
            var expected = "A AAAA A";
            //act
            var actual = encrypter.Encrypt("5", testText);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestAllLettersEncrypt()
        {
            //init
            var encrypter = new CaesarMethodOfDecimations();
            var testText = "A B C D E F G H I J K L M N O P Q R S T U V W X Y Z";
            var expected = "A F K P U Z E J O T Y D I N S X C H M R W B G L Q V";
            //act
            var actual = encrypter.Encrypt("5", testText);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestAllLettersWithKeyBiggerThenAlphabetLenEncrypt()
        {
            //init
            var encrypter = new CaesarMethodOfDecimations();
            var testText = "A B C D E F G H I J K L M N O P Q R S T U V W X Y Z";
            var expected = "A D G J M P S V Y B E H K N Q T W Z C F I L O R U X";
            //act
            var actual = encrypter.Encrypt("29", testText);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestAllLettersWithKeyBiggerThenAlphabetLenDecrypt()
        {
            //init
            var encrypter = new CaesarMethodOfDecimations();
            var testText = "A D G J M P S V Y B E H K N Q T W Z C F I L O R U X";
            var expected = "A B C D E F G H I J K L M N O P Q R S T U V W X Y Z";
            //act
            var actual = encrypter.Decrypt("29", testText);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestKeyParsingEncrypt()
        {
            //init
            var encrypter = new CaesarMethodOfDecimations();
            var testText = "A AAAA A";
            var expected = "A AAAA A";
            //act
            var actual = encrypter.Encrypt("afds5ksjv", testText);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestKeyParsingDecrypt()
        {
            //init
            var encrypter = new CaesarMethodOfDecimations();
            var testText = "A AAAA A";
            var expected = "A AAAA A";
            //act
            var actual = encrypter.Decrypt("afds5ksjv", testText);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void KeyBiggerThenAlphabetEncrypt()
        {
            //init
            var encrypter = new CaesarMethodOfDecimations();
            var testText = "A AAAA A";
            var expected = "A AAAA A";
            //act
            var actual = encrypter.Encrypt("27", testText);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void KeyBiggerThenAlphabetDecrypt()
        {
            //init
            var encrypter = new CaesarMethodOfDecimations();
            var testText = "A AAAA A";
            var expected = "A AAAA A";
            //act
            var actual = encrypter.Decrypt("27", testText);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SimplePhraseEncrypt()
        {
            //init
            var encrypter = new CaesarMethodOfDecimations();
            var testText = "Test TSET";
            var expected = "RUMR RMUR";
            //act
            var actual = encrypter.Encrypt("5", testText);

            //assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void CorrectTestLetterEncrypt()
        {
            //init
            var encrypter = new CaesarMethodOfDecimations();
            var testText = "A";
            var expected = "A";
            //act
            var actual = encrypter.Encrypt("5", testText);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CorrectTestLetterDecrypt()
        {
            //init
            var encrypter = new CaesarMethodOfDecimations();
            var testText = "A";
            var expected = "A";
            //act
            var actual = encrypter.Decrypt("5", testText);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CorrectTestPhraseFunctional1Encrypt()
        {
            //init
            var encrypter = new CaesarMethodOfDecimations(_lang);
            var testText = "Cryptography";
            var expected = "gzutfqszatvu";
            expected = expected.ToUpper();
            //act
            var actual = encrypter.Encrypt("3", testText);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CorrectTestPhraseFunctional2Encrypt()
        {
            //init
            var encrypter = new CaesarMethodOfDecimations();
            var testText = "Hello world";
            var expected = "DYBBG CGLBF";
            //act
            var actual = encrypter.Encrypt("45", testText);

            //assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void CorrectTestPhraseFunctional1Decrypt()
        {
            //init
            var encrypter = new CaesarMethodOfDecimations();
            var expected = "Cryptography";
            var testText = "gzutfqszatvu";
            expected = expected.ToUpper();
            //act
            var actual = encrypter.Decrypt("3", testText);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CorrectTestPhraseFunctional2Decrypt()
        {
            //init
            var encrypter = new CaesarMethodOfDecimations();
            var expected = "Hello world";
            var testText = "DYBBG CGLBF";
            expected = expected.ToUpper();
            //act
            var actual = encrypter.Decrypt("45", testText);

            //assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void SimplePhraseDecrypt()
        {
            //init
            var encrypter = new CaesarMethodOfDecimations();
            var testText = "RUMR RMUR";
            var expected = "TEST TSET";

            //act
            var actual = encrypter.Decrypt("5", testText);

            //assert
            Assert.AreEqual(expected, actual);
        }



    }
}