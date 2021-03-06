﻿using System.Collections.Generic;
using KenBonny.StringManipulationKata.Commands;

namespace KenBonny.StringManipulationKata.Capitalisers
{
    public class AlternativeAlternatingWordCaseCapitaliser : ICapitaliser
    {
        private readonly List<string> _capitalisedWords;
        
        public AlternativeAlternatingWordCaseCapitaliser()
        {
            _capitalisedWords = new List<string>();
        }

        public string Capitalise(Command command)
        {
            var alternativeAlternatingWordCaseCommand = (AlternativeAlternatingWordCaseCommand) command;
            return CapitaliseText(alternativeAlternatingWordCaseCommand.Text);
        }

        private string CapitaliseText(string text)
        {
            var words = text.Split(' ');
            var capitaliseWord = false;
            
            foreach (var word in words)
            {
                if (capitaliseWord)
                {
                    AddUpperWord(word);
                }
                else
                {
                    AddLowerWord(word);
                }

                capitaliseWord = !capitaliseWord;
            }
            
            return string.Join(" ", _capitalisedWords);
        }

        private void AddLowerWord(string word)
        {
            var lower = word.ToLower();
            _capitalisedWords.Add(lower);
        }

        private void AddUpperWord(string word)
        {
            var upper = word.ToUpper();
            _capitalisedWords.Add(upper);
        }
    }
}