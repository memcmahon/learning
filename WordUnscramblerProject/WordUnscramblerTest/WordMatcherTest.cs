using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordUnscrambler.Workers;

namespace WordUnscramblerTest;

[TestClass]
public class WordMatcherTest
{
    [TestMethod]
    public void TestMatchReturnsResultForMatchingWord()
    {
        var matcher = new WordMatcher();
        string[] scrambledWords = { "omre" };
        string[] words = { "rome", "cat", "act", "here" };
        var matchedWords = matcher.Match(scrambledWords, words);

        Assert.IsTrue(matchedWords.Count == 1);
        Assert.IsTrue(matchedWords[0].ScrambledWord == "omre");
        Assert.IsTrue(matchedWords[0].Word == "rome");
    }
}