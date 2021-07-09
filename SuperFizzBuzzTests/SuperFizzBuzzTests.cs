using NUnit.Framework;
using SuperFizzBuzz.Library;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SuperFizzBuzz.Tests
{
    [TestFixture]
    public class SuperFizzBuzzTests
    {
        private IFizzBuzz _fizzBuzz;

        [OneTimeSetUp]
        public void Init()
        {
            _fizzBuzz = new Library.SuperFizzBuzz();
        }

        [Test]
        public void ShouldThrowAnExceptionWhenThereIsNoSequence()
        {
            try
            {
                var result = _fizzBuzz.GetFizzBuzz(null, null).ToList();
                Assert.Fail();
            }
            catch (ArgumentException)
            {
                Assert.Pass();
            }
        }

        [Test]
        public void ShouldNoPrintTokensWhenThereIsNoSequence()
        {
            var tokenList = new List<Token>()
                {new Token() {DivisionBy = 3, Output = "Fizz"}, new Token() {DivisionBy = 5, Output = "Buzz"}};

            var result = _fizzBuzz.GetFizzBuzz(new List<int>(), tokenList).ToList();

            Assert.That(result.Count, Is.EqualTo(0));
        }

        [Test]
        public void ShouldThrowAnExceptionWhenThereIsNoTokenList()
        {
            try
            {
                var result = _fizzBuzz.GetFizzBuzz(1, 10, null).ToList();
                Assert.Fail();
            }
            catch (ArgumentException)
            {
                Assert.Pass();
            }
        }

        [Test]
        public void ShouldPrintNumbersWhenThereIsNoTokenList()
        {
            var tokenList = new List<Token>();

            var result = _fizzBuzz.GetFizzBuzz(1, 100, tokenList).ToList();

            Assert.That(result.Count, Is.EqualTo(100));
            Assert.That(result.Select(_ => _).ToArray(), Is.EqualTo(Enumerable.Range(1, 100).Select(x => x.ToString()).ToArray()));
        }

        [Test]
        public void ShouldPrintAllTokensWhenIsZero()
        {
            var tokenList = new List<Token>()
                {new Token() {DivisionBy = 3, Output = "Fizz"}, new Token() {DivisionBy = 5, Output = "Buzz"}, new Token() {DivisionBy = 10, Output = "Bazz"}};

            var result = _fizzBuzz.GetFizzBuzz(0, 0, tokenList).ToList();

            Assert.That(result.Count, Is.EqualTo(1));
            Assert.That(result[0], Is.EqualTo("FizzBuzzBazz"));
        }

        [Test]
        public void ShouldPrintAllTokensWhenDivisionByIsOne()
        {
            var tokenList = new List<Token>()
                {new Token() {DivisionBy = 1, Output = "Fizz"}, new Token() {DivisionBy = 1, Output = "Buzz"}, new Token() {DivisionBy = 1, Output = "Bazz"}};

            var result = _fizzBuzz.GetFizzBuzz(1, 10, tokenList).ToList();

            Assert.That(result.Count, Is.EqualTo(10));
            Assert.That(result.Select(_ => _), Is.All.EqualTo("FizzBuzzBazz"));
        }

        [Test]
        public void ShouldStartFromTheLowerValueWhenBoundariesAreNegative()
        {
            var tokenList = new List<Token>()
                {new Token() {DivisionBy = 31, Output = "Fizz"}};

            var result = _fizzBuzz.GetFizzBuzz(5, -5, tokenList).ToList();

            Assert.That(result.Count, Is.EqualTo(11));
            Assert.That(result.Select(_ => _).ToArray(), Is.EqualTo(new string[] { "5", "4", "3", "2", "1", "Fizz", "-1", "-2", "-3", "-4", "-5" }.Select(_ => _).ToArray()));
        }

        [Test]
        public void ShouldGetAllTokensForASequenceWhenIsUserProvided()
        {
            var tokenList = new List<Token>()
                {new Token() {DivisionBy = 2, Output = "Fizz"}, new Token() {DivisionBy = 3, Output = "Buzz"}, new Token() {DivisionBy = 5, Output = "Bazz"}};

            var result = _fizzBuzz.GetFizzBuzz(new List<int>(){ 2, 3, 5 }, tokenList).ToList();

            Assert.That(result.Count, Is.EqualTo(3));
            Assert.That(result[0], Is.EqualTo("Fizz"));
            Assert.That(result[1], Is.EqualTo("Buzz"));
            Assert.That(result[2], Is.EqualTo("Bazz"));
        }

        [TestCase(52, ExpectedResult = "FrogDuck")]
        [TestCase(36, ExpectedResult = "FrogChicken")]
        [TestCase(468, ExpectedResult = "FrogDuckChicken")]
        public string ShouldGetTokens(int index)
        {
            var tokenList = new List<Token>()
                {new Token() {DivisionBy = 4, Output = "Frog"}, new Token() {DivisionBy = 13, Output = "Duck"}, new Token() {DivisionBy = 9, Output = "Chicken"}};

            var result = _fizzBuzz.GetFizzBuzz(start:0, end: 469, tokenList).ToList();

            Assert.That(result.Count, Is.EqualTo(470));
            return result[index];
        }

        [TestCase(0, ExpectedResult = "ChickenFrog")]
        [TestCase(3, ExpectedResult = "Frog")]
        [TestCase(6, ExpectedResult = "ChickenFrog")]
        [TestCase(3, ExpectedResult = "Frog")]
        [TestCase(12, ExpectedResult = "ChickenFrog")]
        public string ShouldGetTokensWithinTheTokenListOrderedProvided(int index)
        {
            var tokenList = new List<Token>()
                {new Token() {DivisionBy = 6, Output = "Chicken"}, new Token() {DivisionBy = 3, Output = "Frog"}};

            var result = _fizzBuzz.GetFizzBuzz(start: 0, end: 12, tokenList).ToList();

            Assert.That(result.Count, Is.EqualTo(13));
            return result[index];
        }
    }
}