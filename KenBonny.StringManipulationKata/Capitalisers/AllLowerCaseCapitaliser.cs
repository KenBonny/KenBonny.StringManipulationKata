using KenBonny.StringManipulationKata.Commands;

namespace KenBonny.StringManipulationKata.Capitalisers
{
    public class AllLowerCaseCapitaliser : ICapitaliser
    {
        public string Capitalise(Command command)
        {
            var allLowerCaseCommand = (AllLowerCaseCommand)command;
            return CapitaliseText(allLowerCaseCommand.Text);
        }

        private static string CapitaliseText(string text)
        {
            return text.ToLower();
        }
    }
}