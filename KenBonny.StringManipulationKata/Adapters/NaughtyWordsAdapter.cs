using System;
using System.Collections.Generic;
using System.Linq;
using KenBonny.StringManipulationKata.Capitalisers;
using KenBonny.StringManipulationKata.Commands;

namespace KenBonny.StringManipulationKata.Adapters
{
    public class NaughtyWordsAdapter : ICapitaliser
    {
        private readonly ICapitaliser _capitaliser;
        private readonly IReadOnlyCollection<string> _naughtyWords;

        public NaughtyWordsAdapter(ICapitaliser capitaliser, string[] naughtyWords)
        {
            _capitaliser = capitaliser;
            _naughtyWords = naughtyWords;
        }
        
        public string Capitalise(Command command)
        {
            command.Text = RemoveNaugthyWords(command.Text);
            
            return _capitaliser.Capitalise(command);
        }

        private string RemoveNaugthyWords(string text)
        {
            var cleanWords = text.Split(' ').Where(IsNotNaughtyWord);

            return string.Join(" ", cleanWords);
        }

        private bool IsNotNaughtyWord(string word)
        {
            return _naughtyWords.All(naughty => !naughty.Equals(word, StringComparison.OrdinalIgnoreCase));
        }
    }
}