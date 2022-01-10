using WordUnscrambler.Workers;
using WordUnscrambler.Data;

namespace WordUnscrambler.Workers
{
    public class WordMatcher
    {
        public List<MatchedWord> Match(string[] scrambledWords, string[] wordList)
        {
            var matchedWords = new List<MatchedWord>();
            
            foreach (var scrambledWord in scrambledWords)
            {
                foreach (var word in wordList)
                {
                    if (scrambledWord.ToLower() == word.ToLower())
                        matchedWords.Add(BuildMatchedWord(scrambledWord, word));
                    else
                    {
                        var scrambledWordArray = scrambledWord.ToLower().ToCharArray();
                        var wordArray = word.ToLower().ToCharArray();
                        Array.Sort(scrambledWordArray);
                        Array.Sort(wordArray);

                        var sortedScrambledWord = String.Concat(scrambledWordArray);
                        var sortedWord = String.Concat(wordArray);

                        if (sortedScrambledWord == sortedWord)
                        {
                            matchedWords.Add(BuildMatchedWord(scrambledWord, word));
                        }    
                    }
                }
            }

            return matchedWords;
        }

        private MatchedWord BuildMatchedWord(string scrambledWord, string word)
        {
            return new MatchedWord { ScrambledWord = scrambledWord, Word = word };
        }
    }
}