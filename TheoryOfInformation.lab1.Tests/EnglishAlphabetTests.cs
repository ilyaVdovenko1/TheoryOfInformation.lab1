using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheoryOfInformation.lab1.Encryptions.Models.Ciphers;
using TheoryOfInformation.lab1.ENUMS;

namespace TheoryOfInformation.lab1.Tests
{
    [TestClass]
    public class EnglishAlphabetTests
    {
        private const string AlphabetLower = "abcdefghijklmnopqrstuvwxyz";
        private const string AlphabetUpper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string Digits = "0123456789";
        private const string WrongCharacters = "#=1231$2>!~_+-";
        private Alphabet _currentAlphabet = new EnglishAlphabet();

        [TestMethod]
        public void IfAllLowLettersIdInAlphabetCorrect()
        {
            //init
            var chars = new char[26];

            //act

            foreach (var item in AlphabetLower)
            {
                chars[_currentAlphabet.GetCharAlphabetId(item)] = item;
            }

            var actual = new string(chars);

            //assert
            Assert.AreEqual(AlphabetLower, actual);
        }

        [TestMethod]
        public void IfDigitsCorrect()
        {
            //act and assert

            foreach (var item in Digits)
            {
                Assert.AreEqual(-1,
                    _currentAlphabet.GetCharAlphabetId(item));
            }
        }

        [TestMethod]
        public void EnglishAlphabetLower()
        {
            var encrypter = new EnglishAlphabet(Register.Lower);

            foreach (var item in Digits)
            {
                Assert.AreEqual(-1,
                    _currentAlphabet.GetCharAlphabetId(item));
            }
        }

        [TestMethod]
        public void WrongCharactersTest()
        {
            //act and assert

            foreach (var item in WrongCharacters)
            {
                Assert.AreEqual(-1,
                    _currentAlphabet.GetCharAlphabetId(item));
            }
        }

        [TestMethod]
        public void IfAllUpperLettersIdInAlphabetCorrect()
        {
            //init
            var chars = new char[26];

            //act

            foreach (var item in AlphabetUpper)
            {
                chars[_currentAlphabet.GetCharAlphabetId(item)] = item;
            }

            var actual = new string(chars);

            //assert
            Assert.AreEqual(AlphabetUpper, actual);
        }

        [TestMethod]
        public void IfAIsZero()
        {
            var tokenAlphabetId = _currentAlphabet.GetCharAlphabetId('A');
            Assert.AreEqual(0, tokenAlphabetId);
        }

        [TestMethod]
        public void IfaIsZero()
        {
            var tokenAlphabetId = _currentAlphabet.GetCharAlphabetId('a');
            Assert.AreEqual(0, tokenAlphabetId);
        }

        [TestMethod]
        public void IfBIsOne()
        {
            var tokenAlphabetId = _currentAlphabet.GetCharAlphabetId('B');
            Assert.AreEqual(1, tokenAlphabetId);
        }

        [TestMethod]
        public void IfZIs25()
        {
            var tokenAlphabetId = _currentAlphabet.GetCharAlphabetId('Z');
            Assert.AreEqual(25, tokenAlphabetId);
        }

        [TestMethod]
        public void IfzIs25()
        {
            var tokenAlphabetId = _currentAlphabet.GetCharAlphabetId('z');
            Assert.AreEqual(25, tokenAlphabetId);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void IdOfCharLessThenZero()
        {
            _currentAlphabet.GetCharByAlphabetId(-12);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void IdOfCharBiggerThenAlphabetLen()
        {
            _currentAlphabet.GetCharByAlphabetId(213);
        }
    }
}