using KenBonny.StringManipulationKata.Commands;

namespace KenBonny.StringManipulationKata.Capitalisers
{
    public class AllUpperCaseCapitaliser : ICapitaliser
    {
        public string Capitalise(Command command)
        {
            var allUpperCaseCommand = (AllUpperCaseCommand) command;
            return CapitaliseText(allUpperCaseCommand.Text);
        }

        private static string CapitaliseText(string text)
        {
            return text.ToUpper();
        }
    }
}