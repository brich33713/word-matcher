using System;
using System.Collections.Generic;

namespace WritingProgram
{
    public class WordMatcher
    {
        public List<MatchedWord> Match(string[] words, string[] scrambledWords)
        {
            var matchedWords = new List<MatchedWord>();

            foreach(var word in words)
            {
                foreach(var scrambledWord in scrambledWords)
                {
                    if (word.Equals(scrambledWord, StringComparison.OrdinalIgnoreCase) || compareSortedWords(word,scrambledWord))
                    {
                        MatchedWord matchedWord = new MatchedWord(word, scrambledWord);
                        matchedWords.Add(matchedWord);
                    } 
                }
            }

            return matchedWords;
        }

        /* private MatchedWord createMatchedWord(string word, string scrambledWord)
        {
            MatchedWord matchedWord = new MatchedWord
            {
                Word = word,
                ScrambledWord = scrambledWord
            };

            return matchedWord;
        } */

        private bool compareSortedWords(string word, string scrambledWord)
        {
            var sortedWordArray = word.ToCharArray();
            var sortedScrambledWordArray = scrambledWord.ToCharArray();

            Array.Sort(sortedWordArray);
            Array.Sort(sortedScrambledWordArray);

            var sortedWord  = new string(sortedWordArray);
            var sortedScrambledWord = new string(sortedScrambledWordArray);

            return sortedWord == sortedScrambledWord;
        }
    }
}