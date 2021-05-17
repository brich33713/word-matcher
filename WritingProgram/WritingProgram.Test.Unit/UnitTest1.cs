using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WritingProgram.Test.Unit
{
    [TestClass]
    public class UnitTest1
    {
        private readonly WordMatcher wordMatcher = new WordMatcher();
        [TestMethod]
        public void TestWordIsFindsSingleMatch()
        {
            string[] scrambledWords = { "fourth", "final", "second" };
            string[] word = { "foutrh" };
            var matchedWords = wordMatcher.Match(word, scrambledWords);
            Assert.AreEqual(1, matchedWords.Count);
            Assert.IsTrue(matchedWords[0].scrambledWord == scrambledWords[0]);
            Assert.IsTrue(matchedWords[0].word == word[0]);

        }

        [TestMethod]
        public void TestWordsFindsMultipleMatches()
        {
            string[] scrambledWords = { "fourth", "final", "second" };
            string[] word = { "foutrh","fnial" };
            var matchedWords = wordMatcher.Match(word, scrambledWords);
            Assert.AreEqual(2, matchedWords.Count);
            Assert.IsTrue(matchedWords[0].scrambledWord == scrambledWords[0]);
            Assert.IsTrue(matchedWords[0].word == word[0]);
            Assert.IsTrue(matchedWords[1].scrambledWord == scrambledWords[1]);
            Assert.IsTrue(matchedWords[1].word == word[1]);

        }
    }
}
