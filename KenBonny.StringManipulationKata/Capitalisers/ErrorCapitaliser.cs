using KenBonny.StringManipulationKata.Commands;

namespace KenBonny.StringManipulationKata.Capitalisers
{
    public class ErrorCapitaliser : ICapitaliser
    {
        public string Capitalise(Command command)
        {
            var errorCommand = (ErrorCommand) command;
            return errorCommand.Text;
        }
    }
}