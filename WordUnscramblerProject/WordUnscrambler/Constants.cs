namespace WordUnscrambler
{
    class Constants
    {
        public const string OptionsOnHowToEnterScrambledWords = "Please enter the option - F for File and M for Manual";
        public const string OptionsOnContinuingTheProgram = "Would you like to continue? Y/N";
        
        public const string EnterScrambledWordsViaFile = "Enter full path, including the file name: ";
        public const string EnterScrambledWordsViaManual = "Enter words scrambled words manually, separated by ',': ";
        public const string EnterScrambledWordsOptionNotRecognized = "The option was not recognized.";
        
        public const string ErrorScrambledWordsCannotBeLoaded = "Scrambled words were not loaded because there was an error.";
        public const string ErrorProgramWillBeTerminated = "Program will be terminated because there was an error.";
        
        public const string MatchFound = "MATCH FOUND FOR {0}: {1}";
        public const string MatchNotFound = "NO MATCHES HAVE BEEN FOUND";

        public const string Yes = "Y";
        public const string No = "N";
        public const string File = "F";
        public const string Manual = "M";

        public const string WordListFileName = "wordlist.txt";
    }
}