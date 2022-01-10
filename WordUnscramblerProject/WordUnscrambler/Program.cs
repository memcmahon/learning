using System;
using System.IO;
using WordUnscrambler.Workers;
using WordUnscrambler.Data;

namespace WordUnscrambler
{
    class Program
    {
        private static readonly FileReader _fileReader = new FileReader();
        private static readonly WordMatcher _wordMatcher = new WordMatcher();
       
        
        static void Main(string[] args)
        {
            bool continueWordUnscramble = true;

            do
            {
                Console.WriteLine(Constants.OptionsOnHowToEnterScrambledWords);
                var option = Console.ReadLine() ?? string.Empty;

                switch (option.ToUpper())
                {
                    case Constants.File:
                        Console.Write(Constants.EnterScrambledWordsViaFile);
                        UnScrambleWordsFromFile();
                        break;
                    case Constants.Manual:
                        Console.Write(Constants.EnterScrambledWordsViaManual);
                        UnScrambleWordsFromManual();
                        break;
                    default: 
                        Console.Write(Constants.EnterScrambledWordsOptionNotRecognized);
                        break;
                }

                var continueDecision = string.Empty;
                do
                {
                    Console.WriteLine(Constants.OptionsOnContinuingTheProgram);
                    continueDecision = (Console.ReadLine() ?? string.Empty);
                } while (!continueDecision.Equals(Constants.Yes) && !continueDecision.Equals(Constants.No));

                continueWordUnscramble = continueDecision.Equals(Constants.Yes);

            } while (continueWordUnscramble);

        }

        private static void UnScrambleWordsFromFile()
        {
            try
            {
                var filename = Console.ReadLine() ?? string.Empty;
                string[] scrambledWords = _fileReader.Read(filename);
                DisplayMatchedUnscrambledWords(scrambledWords);
            }
            catch (Exception ex)
            {
                Console.WriteLine(Constants.ErrorScrambledWordsCannotBeLoaded + ex.Message);
            }
        }

        private static void UnScrambleWordsFromManual()
        {
            var manualInput = Console.ReadLine() ?? string.Empty;
            string[] scrambledWords = manualInput.Split(',');
            DisplayMatchedUnscrambledWords(scrambledWords);
        }

        private static void DisplayMatchedUnscrambledWords(string[] scrambledWords)
        {
            string [] wordList = _fileReader.Read(Constants.WordListFileName);

            List<MatchedWord> matchedWords = _wordMatcher.Match(scrambledWords, wordList);

            if (matchedWords.Any())
            {
                foreach (var matchedWord in matchedWords)
                {
                    Console.WriteLine(Constants.MatchFound, matchedWord.ScrambledWord, matchedWord.Word);
                }

            } else {
                Console.WriteLine(Constants.MatchNotFound);
            }
        }
    }
}
