using System.Text;
using KenBonny.StringManipulationKata.Commands;

namespace KenBonny.StringManipulationKata.Capitalisers
{
    public class AlternatingCaseCapitaliser : ICapitaliser
    {
        private readonly StringBuilder _capitalisedTextBuilder;
        
        public AlternatingCaseCapitaliser()
        {
            _capitalisedTextBuilder = new StringBuilder();
        }

        public string Capitalise(Command command)
        {
            var alternatingCaseCommand = (AlternatingCaseCommand)command;
            return CapitaliseText(alternatingCaseCommand.Text);
        }

        private string CapitaliseText(string text)
        {
            _capitalisedTextBuilder.Clear();
            var convertToUpper = true;
            
            foreach (var character in text)
            {
                if (IsSpace(character))
                {
                    continue;
                }
                
                if (convertToUpper)
                {
                    AddUpperCharacter(character);
                }
                else
                {
                    AddLowerCharacter(character);
                }

                convertToUpper = !convertToUpper;
            }

            return _capitalisedTextBuilder.ToString();
        }

        private static bool IsSpace(char character)
        {
            return character == ' ';
        }

        private void AddLowerCharacter(char character)
        {
            var lower = char.ToLower(character);
            _capitalisedTextBuilder.Append(lower);
        }

        private void AddUpperCharacter(char character)
        {
            var upper = char.ToUpper(character);
            _capitalisedTextBuilder.Append(upper);
        }
    }
}