using System.Linq;
using KenBonny.StringManipulationKata.Commands;

namespace KenBonny.StringManipulationKata.Capitalisers
{
    public class CamelCaseCapitaliser : ICapitaliser
    {
        public string Capitalise(Command command)
        {
            var camelCaseCommand = (CamelCaseCommand) command;
            return CapitaliseText(camelCaseCommand.Text);
        }

        private static string CapitaliseText(string text)
        {
            var words = text.Split(' ').Select(CapitaliseFirstLetter);
            return string.Join(" ", words);
        }

        private static string CapitaliseFirstLetter(string word)
        {
            var upperFirstLetter = char.ToUpper(word[0]);
            var lowerRest = word.Substring(1).ToLower();
            return $"{upperFirstLetter}{lowerRest}";
        }
    }
}