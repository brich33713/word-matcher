using System;
using System.Collections.Generic;
using System.Linq;

namespace WritingProgram
{
    public class Program
    {
        private static readonly FileReader fileReader = new FileReader();
        private static readonly WordMatcher wordMatcher = new WordMatcher();
        static string comparisionFile = "testFile.txt";
        static void Main(string[] args)
        {
            
            
            bool continuing = true;
            do
            {
                Console.WriteLine(Constants.OptionsOnHowToEnterScrambledWords);
                string resp = Console.ReadLine() ?? String.Empty;

                switch (resp.ToUpper())
                {
                    case Constants.fileCommand:
                        Console.WriteLine(Constants.FileNamePrompt);
                        ExecuteFile();
                        break;
                    case Constants.manualCommand:
                        Console.WriteLine(Constants.ManualWordPrompt);
                        ExecuteManual();
                        break;
                    default:
                        Console.WriteLine(Constants.ImproperResponse);
                        break;
                }

                string answer;
                do
                {
                    Console.Write(Constants.OptionsOnHowToContinue);
                    answer = Console.ReadLine();
                } while (!answer.Equals(Constants.yes, StringComparison.OrdinalIgnoreCase) && !answer.Equals(Constants.no, StringComparison.OrdinalIgnoreCase));

                continuing = (answer.ToUpper() == Constants.no) ? false : true;
            } while (continuing);
        }

        private static void ExecuteManual()
        {
            string[] words = Console.ReadLine().Split(',');
            DisplayMatches(words);
        }


        private static void ExecuteFile()
        {
            try
            {
                string fileName = Console.ReadLine() ?? String.Empty;
                string[] words = fileReader.Read(fileName);
                DisplayMatches(words);
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void DisplayMatches(string[] words)
        {
            string[] scrambledWords = fileReader.Read(comparisionFile);

            List<MatchedWord> matchedWords = wordMatcher.Match(words, scrambledWords);

            if (matchedWords.Any())
            {
                foreach (var matchedWord in matchedWords)
                {
                    Console.WriteLine("Found Match for {0}: {1}", matchedWord.word, matchedWord.scrambledWord);
                }
            }
            else
            {
                Console.WriteLine("No matches have been found.");
            }
        }
    }
}
